using LegacyApp.Enums;

namespace LegacyApp
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ClientStatus ClientStatus { get; set; }

        public ClientImportance GetClientImportance()
        {
            if (Name == "VeryImportantClient")
            {
                return ClientImportance.VeryImportantClient;
            }
            else if (Name == "ImportantClient")
            {
                return ClientImportance.ImportantClient;
            }
            else
            {
                return ClientImportance.Normal;
            }
        }
    }
}