using LegacyApp.Enums;
using LegacyApp.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string surName, string email, DateTime dateTime, int clientId)
        {
            try
            {
                var model = new AddUserModel(firstName, surName, email, dateTime, clientId);
                return CreateUser(model);
            }
            catch (ValidationException)
            {
                return false;
            }
            catch (Exception ex)
            {
                // log the exception
                return false;
            }
        }

        private static bool CreateUser(AddUserModel model)
        {
            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(model.ClientID);

            var user = new User(model, client);

            if (client.GetClientImportance() == ClientImportance.VeryImportantClient)
            {
                user.SkipCreditCheck();
            }
            else if (client.GetClientImportance() == ClientImportance.ImportantClient)
            {
                user.ApplyCreditCheck();
                ApplyDoubleCreditLimit(user);
            }
            else
            {
                user.ApplyCreditCheck();
                ApplyNormalCreditLimit(user);
            }

            UserDataAccess.AddUser(user);
            return true;
        }

        private static void ApplyNormalCreditLimit(User user)
        {
            using (var userCreditService = new UserCreditServiceClient())
            {
                var creditLimit = userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
                user.ApplyCreditLimit(creditLimit);
            }
        }

        private static void ApplyDoubleCreditLimit(User user)
        {
            using (var userCreditService = new UserCreditServiceClient())
            {
                var creditLimit = userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
                user.ApplyCreditLimit(creditLimit * 2);
            }
        }
    }
}