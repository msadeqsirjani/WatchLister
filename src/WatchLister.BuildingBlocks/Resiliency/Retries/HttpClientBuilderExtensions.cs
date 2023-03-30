namespace WatchLister.BuildingBlocks.Resiliency.Retries;

public static class HttpClientBuilderExtensions
{
    public static IHttpClientBuilder AddCustomPolicyHandlers(this IHttpClientBuilder httpClientBuilder,
        IConfiguration configuration, string policySectionName)
    {
        var policyConfig = new PolicyConfiguration();
        configuration.Bind(policySectionName, policyConfig);

        var circuitBreakerPolicyConfig = (ICircuitBreakerPolicyConfiguration)policyConfig;
        var retryPolicyConfig = (IRetryPolicyConfiguration)policyConfig;

        return httpClientBuilder
            .AddRetryPolicyHandler(retryPolicyConfig)
            .AddCircuitBreakerHandler(circuitBreakerPolicyConfig);
    }

    public static IHttpClientBuilder AddRetryPolicyHandler(this IHttpClientBuilder httpClientBuilder,
        IRetryPolicyConfiguration retryPolicyConfig)
    {
        return httpClientBuilder.AddPolicyHandler((sp, _) =>
        {
            var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
            var retryLogger = loggerFactory.CreateLogger("PollyHttpRetryPoliciesLogger");

            return HttpRetryPolicies.GetHttpRetryPolicy(retryLogger, retryPolicyConfig);
        });
    }

    public static IHttpClientBuilder AddCircuitBreakerHandler(this IHttpClientBuilder httpClientBuilder,
        ICircuitBreakerPolicyConfiguration circuitBreakerPolicyConfig)
    {
        return httpClientBuilder.AddPolicyHandler((sp, _) =>
        {
            var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
            var circuitBreakerLogger = loggerFactory.CreateLogger("PollyHttpCircuitBreakerPoliciesLogger");

            return HttpCircuitBreakerPolicies.GetHttpCircuitBreakerPolicy(circuitBreakerLogger, circuitBreakerPolicyConfig);
        });
    }
}