namespace RideBooking.Infrastructure.Models
{
    public class ResponseError
    {
        /// <summary>
        /// Initializes a new instance of the Error class.
        /// </summary>
        public ResponseError() { }

        /// <summary>
        /// Initializes a new instance of the Error class.
        /// </summary>
        /// <param name="errorCode">The error code</param>
        /// <param name="errorMessage">The error message</param>
        public ResponseError(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// The error code
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// The error message
        /// </summary>
        public string ErrorMessage { get; set; }

        public static IList<ResponseError> UnexpectedError()
        {
            return new List<ResponseError>
            {
                new()
                {
                    ErrorCode = ResponseErrorCodeConstants.UnexpectedError,
                    ErrorMessage = "An unexpected error occurred."
                }
            };

        }
    }
}
