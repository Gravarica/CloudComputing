namespace CentralLibrary.Dto
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Jmbg { get; set; }

        public AddressDTO Address { get; set; }
    }
}
