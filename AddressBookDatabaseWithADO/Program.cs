using System;

namespace AddressBookDatabaseWithADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Database Project with ADO.NET");
            AddressBookRepo repo = new AddressBookRepo();
            //repo.CheckConnection();
            AddressBookModel addressBookModel = new AddressBookModel();

            addressBookModel.first_name = "Mamta";
            addressBookModel.last_name = "Chaudhary";
            addressBookModel.address = "Rajmata chauk";
            addressBookModel.city = "Jaipur";
            addressBookModel.state = "Rajasthan";
            addressBookModel.zip = 423233;
            addressBookModel.phone_number = "7654321095";
            addressBookModel.email = "mamta1234@gmail.com";
            addressBookModel.addressbook_name = "AddressBook2";
            addressBookModel.addressbook_type = "Friends";

            repo.AddContact(addressBookModel);
        }
    }
}
