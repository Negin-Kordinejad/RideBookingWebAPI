using System.Text;

namespace RideBooking.Infrastructure.Models
{
    public class Response
    {
        /// <summary>
        /// Response constructor
        /// </summary>
        public Response()
        {
            ErrorMessages = new List<ResponseError>();
        }

        /// <summary>
        /// If successful
        /// </summary>
        public bool IsSuccessful => ErrorMessages.Any() == false;

        /// <summary>
        /// List of errors
        /// </summary>
        public IList<ResponseError> ErrorMessages { get; set; }

        /// <summary>
        /// Add a new error
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorMessage"></param>
        public void AddError(string errorCode, string errorMessage)
        {
            ErrorMessages.Add(new ResponseError(errorCode, errorMessage));
        }

        /// <summary>
        /// Add a new error
        /// </summary>
        /// <param name="error"></param>
        public void AddError(ResponseError error)
        {
            ErrorMessages.Add(error);
        }

        /// <summary>
        /// Add a list of error message to the current list
        /// </summary>
        /// <param name="errorMessages"></param>
        public void AddErrors(IList<ResponseError> errorMessages)
        {
            ErrorMessages = ErrorMessages.Concat(errorMessages).ToList();
        }

        /// <summary>
        /// Converts the value of this instance to its string representation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("ErrorMessages = {0}, ", ConvertListToString(ErrorMessages.ToList()));
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Converts List to the string value
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string ConvertListToString<T>(IReadOnlyCollection<T> list)
        {
            if (list == null || !list.Any())
                return "{}";

            var tmpStringList = list.Select(x => "{" + x + "}");
            return "[ " + string.Join(",", tmpStringList) + " ]";
        }
    }
}
