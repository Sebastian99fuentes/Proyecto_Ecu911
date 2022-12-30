namespace Ecu911.ResponseModels
{
    public class ChangePasswordRequest
    {
        public string UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
