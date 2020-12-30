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
            //repo.AddContact(addressBookModel);

            AddressBookModel addressBookModel1 = new AddressBookModel();
            addressBookModel1.first_name = "Neha";
            addressBookModel1.last_name = "Patil";
            addressBookModel1.city = "Pushkar";
            addressBookModel1.state = "Rajasthan";
            addressBookModel1.email = "patil123@gmail.com";
            addressBookModel1.addressbook_name = "AddressBook1";
            addressBookModel1.addressbook_type = "Professional";
            //repo.EditContactUsingPersonName(addressBookModel1);

            AddressBookModel model = new AddressBookModel();
            model.first_name = "Komal";
            //repo.DeleteContactUsingName(model);

            //repo.RetrievePersonFromPErticulatCityOrState();
            repo.AddressBookSizeByCityANDState();

        }
    }
}
