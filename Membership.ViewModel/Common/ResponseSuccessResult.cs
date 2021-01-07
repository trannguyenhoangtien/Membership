namespace Membership.ViewModel.Common
{
    public class ResponseSuccessResult<T> : ResponseResult<T>
    {
        public ResponseSuccessResult(T resultObj)
        {
            IsSuccess = true;
            ResultObj = resultObj;
        }

        public ResponseSuccessResult()
        {
            IsSuccess = true;
        }
    }
}
