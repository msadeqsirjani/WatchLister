namespace WatchLister.BuildingBlocks.Resiliency.Retries;

public static class HttpPolicyBuilders
{
    public static PolicyBuilder<HttpResponseMessage> GetBaseBuilder()
    {
        return HttpPolicyExtensions.HandleTransientHttpError();
    }
}