using System;

namespace UPServiceApiClientLib.Services.UserProfile
{
    public class UserProfileData
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string OtherEmails { get; set; }
        public string BusinessPhones { get; set; }
        public string MobilePhone { get; set; }
        public string JobTitle { get; set; }
        public string FacultyName { get; set; }
        public string PersonCode { get; set; }
        public string PersonType { get; set; }
        public int FacultyId { get; set; }
        public string CitizenId { get; set; }
        public string PictureUrl { get; set; }
        public DateTime? StaffCardExpire { get; set; }
    }
}
