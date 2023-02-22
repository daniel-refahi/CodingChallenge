using System;

namespace LegacyApp.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            ProveAddUser(args);
        }

        public static void ProveAddUser(string[] args)
        {
            /*
			 *	DO NOT CHANGE THIS FILE AT ALL
        	*/

            var userService = new UserService();
            var addResult = userService.AddUser("Alvin", "Patrimonio", "alvin.patrimonio@example.com", new DateTime(1966, 11, 17), 4);
            Console.WriteLine("Adding Alvin Patrimonio was " + (addResult ? "successful" : "unsuccessful"));
        }
    }
}
