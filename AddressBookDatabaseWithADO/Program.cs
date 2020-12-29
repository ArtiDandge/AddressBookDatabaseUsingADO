using System;

namespace AddressBookDatabaseWithADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Database Project with ADO.NET");
            AddressBookRepo repo = new AddressBookRepo();
            repo.CheckConnection();
        }
    }
}
