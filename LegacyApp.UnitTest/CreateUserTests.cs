using LegacyApp.Models;
using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;

namespace LegacyApp.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FirstNameValidation()
        {
            try
            {
                var model = new AddUserModel(string.Empty, "lastName", "test@test.com", DateTime.Now, 10);
            }
            catch (ValidationException ex)
            {
                if (ex.Message.Contains("First name"))
                    Assert.Pass();
                else
                    Assert.Fail($"First name validation failed on {nameof(Tests)} - {nameof(FirstNameValidation)}");
            }
            Assert.Fail();
        }

        [Test]
        public void LastNameValidation()
        {
            try
            {
                var model = new AddUserModel("first name", string.Empty, "test@test.com", DateTime.Now, 10);
            }
            catch (ValidationException ex)
            {
                if (ex.Message.Contains("Surname"))
                    Assert.Pass();
                else
                    Assert.Fail($"Surname validation failed on {nameof(Tests)} - {nameof(LastNameValidation)}");
            }
            Assert.Fail();
        }

        [Test]
        public void EmailValidation_MissingATSign()
        {
            try
            {
                var model = new AddUserModel("first name", "last name", "testtest.com", DateTime.Now, 10);
            }
            catch (ValidationException ex)
            {
                if (ex.Message.Contains("Email"))
                    Assert.Pass();
                else
                    Assert.Fail($"Email validation failed on {nameof(Tests)} - {nameof(EmailValidation_MissingATSign)}");
            }
            Assert.Fail();
        }

        [Test]
        public void EmailValidation_MissingDotSign()
        {
            try
            {
                var model = new AddUserModel("first name", "last name", "test@testcom", DateTime.Now, 10);
            }
            catch (ValidationException ex)
            {
                if (ex.Message.Contains("Email"))
                    Assert.Pass();
                else
                    Assert.Fail($"Email validation failed on {nameof(Tests)} - {nameof(EmailValidation_MissingDotSign)}");
            }
            Assert.Fail();
        }

        [Test]
        public void EmailValidation_MissingDotSign_MissingATSign()
        {
            try
            {
                var model = new AddUserModel("first name", "last name", "testtestcom", DateTime.Now, 10);
            }
            catch (ValidationException ex)
            {
                if (ex.Message.Contains("Email"))
                    Assert.Pass();
                else
                    Assert.Fail($"Email validation failed on {nameof(Tests)} - {nameof(EmailValidation_MissingDotSign_MissingATSign)}");
            }
            Assert.Fail();
        }

        [Test]
        public void EmailValidation_EmptyEmail()
        {
            try
            {
                var model = new AddUserModel("first name", "last name", string.Empty, DateTime.Now, 10);
            }
            catch (ValidationException ex)
            {
                if (ex.Message.Contains("Email"))
                    Assert.Pass();
                else
                    Assert.Fail($"Email validation failed on {nameof(Tests)} - {nameof(EmailValidation_EmptyEmail)}");
            }
            Assert.Fail();
        }

        [Test]
        public void DOBValidation_LessThan21()
        {
            try
            {
                var model = new AddUserModel("first name", "last name", "test@test.com", DateTime.Now.AddYears(-15), 10);
            }
            catch (ValidationException ex)
            {
                if (ex.Message.Contains("years old"))
                    Assert.Pass();
                else
                    Assert.Fail($"Age validation failed on {nameof(Tests)} - {nameof(DOBValidation_LessThan21)}");
            }
            Assert.Fail();
        }

        [Test]
        public void DOBValidation_MoreThan21()
        {
            try
            {
                var model = new AddUserModel("first name", "last name", "test@test.com", DateTime.Now.AddYears(-22), 10);
            }
            catch
            {
                Assert.Fail($"Age validation failed on {nameof(Tests)} - {nameof(DOBValidation_MoreThan21)}");
            }
            Assert.Pass();
        }
    }
}