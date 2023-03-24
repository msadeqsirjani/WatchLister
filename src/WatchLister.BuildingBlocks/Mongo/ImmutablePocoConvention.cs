namespace WatchLister.BuildingBlocks.Mongo;

public class ImmutablePocoConvention : ConventionBase, IClassMapConvention
{
    private readonly BindingFlags _bindingFlags;

    public ImmutablePocoConvention() : this(BindingFlags.Instance | BindingFlags.Public) { }

    public ImmutablePocoConvention(BindingFlags bindingFlags) => _bindingFlags = bindingFlags | BindingFlags.DeclaredOnly;

    public void Apply(BsonClassMap classMap)
    {
        var readonlyProperties = classMap.ClassType
            .GetTypeInfo()
            .GetProperties(_bindingFlags)
            .Where(x => IsReadonlyProperty(classMap, x))
            .ToList();

        foreach (var constructor in classMap.ClassType.GetConstructors())
        {
            var matchedProperties = GetMatchingProperties(constructor, readonlyProperties);

            if (!matchedProperties.Any())
            {
                continue;
            }
            
            classMap.MapConstructor(constructor);

            foreach (var property in matchedProperties)
            {
                classMap.MapMember(property);
            }
        }
    }

    private static List<PropertyInfo> GetMatchingProperties(MethodBase constructor, IReadOnlyCollection<PropertyInfo> properties)
    {
        var matchedProperties = new List<PropertyInfo>();
        var constructorProperties = constructor.GetParameters();
        foreach (var property in constructorProperties)
        {
            var matchedProperty = properties.FirstOrDefault(x => ParameterMatchProperty(property, x));
            
            if (matchedProperty != null)
            {
                matchedProperties.Add(matchedProperty);
            }
            else
            {
                return new List<PropertyInfo>();
            }
        }

        return matchedProperties;
    }

    private static bool ParameterMatchProperty(ParameterInfo parameter, PropertyInfo property) =>
        string.Equals(property.Name, parameter.Name, StringComparison.InvariantCultureIgnoreCase) &&
        parameter.ParameterType == property.PropertyType;

    private static bool IsReadonlyProperty(BsonClassMap classMap, PropertyInfo propertyInfo)
    {
        if (!propertyInfo.CanRead)
        {
            return false;
        }

        if (propertyInfo.CanWrite)
        {
            return false;
        }

        if (propertyInfo.GetIndexParameters().Length != 0)
        {
            return false;
        }

        var methodInfo = propertyInfo.GetGetMethod();

        return methodInfo?.IsVirtual != true || methodInfo.GetBaseDefinition().DeclaringType == classMap.ClassType;
    }
}