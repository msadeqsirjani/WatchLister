namespace WatchLister.Core.General;

public enum TmdbStatusCode
{
    Unknown = 0,

    /// <summary>
    ///     200: Success.
    /// </summary>
    Success = 1,

    /// <summary>
    ///     501: Invalid service: this service does not exist.
    /// </summary>
    InvalidService = 2,

    /// <summary>
    ///     401: Authentication failed: You do not have permissions to access the service.
    /// </summary>
    InsufficientPermissions = 3,

    /// <summary>
    ///     405: Invalid format: This service doesn't exist in that format.
    /// </summary>
    InvalidFormat = 4,

    /// <summary>
    ///     422: Invalid parameters: Your request parameters are incorrect.
    /// </summary>
    InvalidParameters = 5,

    /// <summary>
    ///     404: Invalid id: The pre-requisite id is invalid or not found.
    /// </summary>
    InvalidId = 6,

    /// <summary>
    ///     401: Invalid API key: You must be granted a valid key.
    /// </summary>
    InvalidApiKey = 7,

    /// <summary>
    ///     403: Duplicate entry: The data you tried to submit already exists.
    /// </summary>
    DuplicateEntry = 8,

    /// <summary>
    ///     503: Service offline: This service is temporarily offline, try again later.
    /// </summary>
    ServiceOffline = 9,

    /// <summary>
    ///     503: Service offline: This service is temporarily offline, try again later.
    /// </summary>
    SuspendedApiKey = 10,

    /// <summary>
    ///     503: Service offline: This service is temporarily offline, try again later.
    /// </summary>
    InternalError = 11,

    /// <summary>
    ///     201: The item/record was updated successfully.
    /// </summary>
    SuccessfulUpdate = 12,

    /// <summary>
    ///     200: The item/record was deleted successfully.
    /// </summary>
    SuccessfulDelete = 13,

    /// <summary>
    ///     401: Authentication failed.
    /// </summary>
    AuthenticationFailed = 14,

    /// <summary>
    ///     500: Failed.
    /// </summary>
    Failed = 15,

    /// <summary>
    ///     401: Device denied.
    /// </summary>
    DeviceDenied = 16,

    /// <summary>
    ///     401: Session denied.
    /// </summary>
    SessionDenied = 17,

    /// <summary>
    ///     400: Validation failed.
    /// </summary>
    ValidationFailed = 18,

    /// <summary>
    ///     406: Invalid accept header.
    /// </summary>
    InvalidAcceptHeader = 19,

    /// <summary>
    ///     422: Invalid date range: Should be a range no longer than 14 days.
    /// </summary>
    InvalidDateRange = 20,

    /// <summary>
    ///     200: Entry not found: The item you are trying to edit cannot be found.
    /// </summary>
    EntryNotFound = 21,

    /// <summary>
    ///     400: Invalid page: Pages start at 1 and max at 1000. They are expected to be an integer.
    /// </summary>
    InvalidPage = 22,

    /// <summary>
    ///     400: Invalid date: Format needs to be YYYY-MM-DD.
    /// </summary>
    InvalidDate = 23,

    /// <summary>
    ///     400: Invalid date: Format needs to be YYYY-MM-DD.
    /// </summary>
    ServerTimeout = 24,

    /// <summary>
    ///     400: Invalid date: Format needs to be YYYY-MM-DD.
    /// </summary>
    RequestOverLimit = 25,

    /// <summary>
    ///     "400: You must provide a username and password.
    /// </summary>
    AuthenticationRequired = 26,

    /// <summary>
    ///     400: Too many append to response objects: The maximum number of remote calls is 20.
    /// </summary>
    ResponseObjectOverflow = 27,

    /// <summary>
    ///     400: Invalid timezone: Please consult the documentation for a valid timezone.
    /// </summary>
    InvalidTimezone = 28,

    /// <summary>
    ///     400: Invalid timezone: Please consult the documentation for a valid timezone.
    /// </summary>
    ActionMustBeConfirmed = 29,

    /// <summary>
    ///     401: Invalid username and/or password: You did not provide a valid login.
    /// </summary>
    InvalidAuthentication = 30,

    /// <summary>
    ///     401: Account disabled: Your account is no longer active. Contact TMDb if this is an error.
    /// </summary>
    AccountDisabled = 31,

    /// <summary>
    ///     401: Email not verified: Your email address has not been verified.
    /// </summary>
    EmailNotVerified = 32,

    /// <summary>
    ///     401: Invalid request token: The request token is either expired or invalid.
    /// </summary>
    InvalidRequestToken = 33,

    /// <summary>
    ///     401: The resource you requested could not be found.
    /// </summary>
    ResourceNotFound = 34
}