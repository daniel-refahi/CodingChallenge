using LegacyApp.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LegacyApp
{
    public class User
    {
        public int Id { get; private set; }

        public string Firstname { get; private set; }

        public string Surname { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public string EmailAddress { get; private set; }

        public bool HasCreditLimit { get; private set; }

        public int CreditLimit { get; private set; }

        public Client Client { get; private set; }

        public User(AddUserModel model, Client client)
        {
            Client = client;
            DateOfBirth = model.DateOfBirth;
            EmailAddress = model.Email;
            Firstname = model.Firstname;
            Surname = model.Surname;
        }

        public void SkipCreditCheck()
        {
            HasCreditLimit = false;
        }

        public void ApplyCreditCheck()
        {
            HasCreditLimit = true;
        }

        public void ApplyCreditLimit(int creditLimit)
        {
            CreditLimit = creditLimit;
            ValidateCreditLimit();
        }

        private void ValidateCreditLimit()
        {
            if (HasCreditLimit && CreditLimit < 500)
            {
                throw new ValidationException("User with credit limitation cannot have less than 500 credit limit.");
            }
        }
    }
}