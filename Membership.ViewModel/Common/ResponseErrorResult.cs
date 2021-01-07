namespace Membership.ViewModel.Common
{
    public class ResponseErrorResult<T> : ResponseResult<T>
    {
        public ResponseErrorResult()
        {
            IsSuccess = false;
        }

        public ResponseErrorResult(string message)
        {
            IsSuccess = false;
            Message = message;
        }

        public ResponseErrorResult(string [] validationErrors)
        {
            IsSuccess = false;
            ValidationErrors = validationErrors;
        }

        public string[] ValidationErrors { get; set; }
    }
}
