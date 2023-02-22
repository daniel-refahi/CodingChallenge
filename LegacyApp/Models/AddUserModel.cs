using System;
using System.ComponentModel.DataAnnotations;

namespace LegacyApp.Models
{
    public class AddUserModel
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ClientID { get; set; }

        public AddUserModel(string firstname, string surname, string email, DateTime dateOfBirth, int clientID)
        {
            ValidateFirstName(firstname);
            ValidateSurName(surname);
            ValidateEmail(email);
            ValidateDateOfBirth(dateOfBirth);

            Firstname = firstname;
            Surname = surname;
            Email = email;
            DateOfBirth = dateOfBirth;
            ClientID = clientID;
        }

        private static void ValidateDateOfBirth(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                throw new ValidationException("The user is not over 21 years old.");
            }
        }

        private static void ValidateEmail(string email)
        {
            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new ValidationException("Email is not in the correct format. Please provide correct email address.");
            }
        }

        private static void ValidateFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ValidationException("First name is empty. Please provider a value.");
            }
        }

        private static void ValidateSurName(string surName)
        {
            if (string.IsNullOrEmpty(surName))
            {
                throw new ValidationException("Surname is empty. Please provider a value.");
            }
        }
    }
}