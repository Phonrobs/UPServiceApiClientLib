namespace UPServiceApiClientLib.Services.AzureAD
{
    public class SignInCallbackResult
    {
        public bool Success { get; private set; }
        public string ErrorMessage { get; private set; }

        public static SignInCallbackResult SuccessResult()
        {
            return new SignInCallbackResult { Success = true };
        }

        public static SignInCallbackResult ErrorResult(string message)
        {
            return new SignInCallbackResult { ErrorMessage = message };
        }
    }
}
