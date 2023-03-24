namespace WatchLister.BuildingBlocks.Utils;

public static class ObjectExtensions
{
    public static string GetQueryString(this object obj)
    {
        var properties = from property in obj.GetType().GetProperties()
                         where property.GetValue(obj, null) != null
                         select $"{property.Name}-{HttpUtility.UrlEncode(property.GetValue(obj, null).ToString())}";

        return string.Join("&", properties.ToArray());
    }
}