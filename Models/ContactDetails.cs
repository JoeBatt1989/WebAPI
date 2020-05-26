using static WebAPI.Enums.Enums;

namespace WebAPI.Models
{
    public class ContactDetails
    {
        public PhoneType PhoneType { get; set; }

        public string PhoneNumber { get; set; }
    }
}
