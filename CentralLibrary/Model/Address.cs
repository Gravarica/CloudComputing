using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CentralLibrary.Model
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }

        [AllowNull]
        public string Country { get; set; }

        [AllowNull]
        public string City { get; set; }

        [AllowNull]
        public string Street { get; set; }
        
        [AllowNull]
        public string Number { get; set; }

        public Address() { }

        public Address(Guid id)
        {
            Id = id;
        }

        public Address(Guid id, string country, string city, string street, string number)
        {
            Id=id;
            Country=country;
            City=city;
            Street=street;
            Number=number;
        }
    }
}
