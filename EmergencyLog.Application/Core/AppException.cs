namespace EmergencyLog.Application.Core
{
    // AppException class is for Exception information to be used in the Exception middleware
    public class AppException
    {
        public AppException(int statusCode, string message, string details = null) // dont have to supply details, default value of null. In developer mode, this will hold the stack trace of the error for debugging
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}
