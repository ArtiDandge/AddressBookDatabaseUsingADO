using System;

namespace AddressBookDatabaseWithADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Database Project with ADO.NET");
            Console.WriteLine("\n");
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
            //repo.AddressBookSizeByCityANDState();
            //repo.SortPersonNameByCity();
            //repo.GetNumberOfPersonsCountByType();

            AddressBookModel addressBookModel2 = new AddressBookModel();
            addressBookModel2.first_name = "Megha";
            addressBookModel2.last_name = "Chinchawade";
            addressBookModel2.address = "Rajmata chauk";
            addressBookModel2.city = "Indor";
            addressBookModel2.state = "Indor";
            addressBookModel2.zip = 422233;
            addressBookModel2.phone_number = "6754321095";
            addressBookModel2.email = "megha4@gmail.com";
            addressBookModel2.addressbook_name = "AddressBook3";
            addressBookModel2.addressbook_type = "Family";
            //repo.AddAPersonInTwoAddressbookTypes(addressBookModel2);

            //Adding Same Person's COntact in AddressBook Type 'Friends'
            addressBookModel2.first_name = "Megha";
            addressBookModel2.last_name = "Chinchawade";
            addressBookModel2.address = "Rajmata chauk";
            addressBookModel2.city = "Indor";
            addressBookModel2.state = "Indor";
            addressBookModel2.zip = 422233;
            addressBookModel2.phone_number = "6754321095";
            addressBookModel2.email = "megha4@gmail.com";
            addressBookModel2.addressbook_name = "AddressBook2";
            addressBookModel2.addressbook_type = "Friends";
            repo.AddAPersonInTwoAddressbookTypes(addressBookModel2);

        }
    }
}
