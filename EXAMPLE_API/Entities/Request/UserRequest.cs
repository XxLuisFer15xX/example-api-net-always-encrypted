namespace EXAMPLE_API.Entities.Request
{
    public class UserRequest
    {
        public string PcFirstName { get; set; }
        public string PcLastName { get; set; }
        public string PcEmail { get; set; }
        public DateTime? PdBirthdate { get; set; }
        public int? PnIdRole { get; set; }
        public int? PnStatus { get; set; }
    }
}
