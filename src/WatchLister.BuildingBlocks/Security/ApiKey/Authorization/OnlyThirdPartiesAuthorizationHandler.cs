namespace WatchLister.BuildingBlocks.Security.ApiKey.Authorization;

public class OnlyThirdPartiesAuthorizationHandler : AuthorizationHandler<OnlyThirdPartiesRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyThirdPartiesRequirement requirement)
    {
        if (context.User.IsInRole(Roles.ThirdParty)) context.Succeed(requirement);

        return Task.CompletedTask;
    }
}