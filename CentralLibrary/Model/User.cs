using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CentralLibrary.Model
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [AllowNull]
        public string FirstName { get; set; }

        [AllowNull]
        public string LastName { get; set; }

        [AllowNull]
        public string JMBG { get; set; }

        [AllowNull]
        public int NumberOfBooksRented { get; set; }

        public Address Address { get; set; }

        public User() { }

        public User(Guid id, string firstName, string lastName, string jMBG, int numberOfBooksRented, Address address)
        {
            Id=id;
            FirstName=firstName;
            LastName=lastName;
            JMBG=jMBG;
            NumberOfBooksRented=numberOfBooksRented;
            Address=address;
        }
    }
}
