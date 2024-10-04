namespace Letstalk.Areas.LoggerMicroServices.Constants
{
    public static class MessageConstants
    {
        public const string GeneriLargeDataErrorMsg = "Please narrow down your filter criteria as this search retrieves too many records to be displayed.";
        public const string InvalidCredentialsErrorMsg = "Login failed: Invalid UserId / Password";
        public const string RecordCreatedSuccessfully = "Record Created Successfully.";
        public const string RecordUpdatedSuccessfully = "Record Updated Successfully.";
        public const string RecordUploadedSuccessfully = "Record uploaded Successfully.";
        public const string InsertUpdateCompleted = "Record Saved Successfully.";
        public const string RecordDeletedSuccessfully = "Record Deleted Successfully.";
        public const string TokenExpire = "Your Token is expired! Please relogin.";
        public const string Somethingwrong = "Something went wrong, please contact application support team";
        public const string InvalidToken = "Invalid Token / Token not found / Unable to Parse Token";
        public const string NoRecordFound = "No Record(s) Found.";
        public const string Login = "Login Successful";
    }
    public static class ActionFlags
    {
        public const int Add = 1;
        public const int Edit = 2;
        public const int Delete = 3;
        public const int ReActivate = 3;
        public const int Search = 5;
    }
}