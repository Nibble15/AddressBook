using System;

namespace AddressBook {
    class Program {
        static void Main(string[] args) {

            AddressBook addressBook = new AddressBook();

            PromptUser();

            void PromptUser() {
                addressBook.Menu();
                string userInput = "";
                while (userInput != "quit") {
                    Console.WriteLine("What would you like to do?");
                    userInput = Console.ReadLine().Trim();
                    UpdateAddressBook(userInput);
                }
            }

            void UpdateAddressBook(string userInput) {
                string name = "";
                string address = "";
                switch ( userInput.ToLower() ) {
                    case "add":
                        Console.Write("Enter a name: ");
                        name = Console.ReadLine();
                        switch(name) {
                            case "quit":
                                break;
                            default:
                                Console.Write("Enter an address: ");
                                address = Console.ReadLine();
                                switch (address) {
                                    case "quit":
                                        break;
                                    default:
                                        bool contactEntered = addressBook.AddEntry(name, address);
                                        if(contactEntered) {
                                            Console.WriteLine("Your AddressBook has been updated with the following:");
                                            Console.WriteLine($"Name: {name} \nAddress: {address}");
                                        }
                                        Console.Write("The contact seems to be a duplicate. ");
                                        break;
                                }
                                break;
                        }
                        break;
                    case "remove":
                        Console.Write("Enter a name to remove: ");
                        name = Console.ReadLine();
                        switch (name) {
                            case "quit":
                                break;
                            default:
                                addressBook.RemoveEntry(name);
                                break;
                        }
                        break;
                    case "view":
                        var contactsList = addressBook.ViewContactsList();
                        foreach(var contact in contactsList) {
                            Console.WriteLine($"Name: {contact.Name}");
                            Console.WriteLine($"Address: {contact.Address}");
                        }
                        break;
                    case "update":
                        Console.Write("To ensure you're updating the correct contact, please enter the \nfull name of the Contact you wish to update: ");
                        name = Console.ReadLine();
                        var search = addressBook.Search(name);
                        if (search != null && search.Count == 1) {
                            Console.Write($"Would you like to update {name}'s name or address?: ");
                            var propertyToUpdate = Console.ReadLine();
                            Console.Write($"Enter the {propertyToUpdate}: ");
                            var updatedProperty = Console.ReadLine();
                            var newEntry = addressBook.UpdateContact(name, propertyToUpdate, updatedProperty);
                            if (newEntry != null) {
                                Console.WriteLine($"{name} has been updated to: \nName: {newEntry.Name} \nAddress: {newEntry.Address}");
                            }
                        }
                        else {
                            Console.WriteLine("You have several contacts matching your search");
                            foreach(var contact in search) {
                                Console.WriteLine($"Name: {contact.Name}");
                                Console.WriteLine($"Address: {contact.Address}");
                                }
                            }
                            Console.Write("Would you like to update one of these Contacts or add a new one? ");
                            var response = Console.ReadLine();
                            if (response == "update") {
                                //TODO: implement logic here and turn update switch case into a while loop
                        }
                        break;
                    case "search":
                        Console.WriteLine("Please enter the name of the Contact you wish to search");
                        name = Console.ReadLine();
                        var contacts = addressBook.Search(name);
                        foreach (var contact in contacts) {
                            Console.WriteLine(contact.Name);
                        }
                        break;
                }
            }

        }
    }
}
