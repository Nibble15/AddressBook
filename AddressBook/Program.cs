using System;

namespace AddressBook {
    class Program {
        static void Main(string[] args) {

            AddressBook addressBook = new AddressBook();

            PromptUser();

            void PromptUser()
            {
                addressBook.Menu();
                string userInput = "";
                while (userInput != "quit") {
                    Console.WriteLine("What would you like to do?");
                    userInput = Console.ReadLine().ToLower().Trim();
                    UpdateAddressBook(userInput);
                }
            }

            void UpdateAddressBook(string userInput) {
                string name = string.Empty;
                string address = string.Empty;
                while (name.ToLower().Trim() != "quit" || address.ToLower().Trim() != "quit") {
                    if (userInput == "add") {
                        Console.Write("Enter a name: ");
                        name = Console.ReadLine();
                        if(name == "quit") {
                            break;
                        }
                        Console.Write("Enter an address: ");
                        address = Console.ReadLine();
                        if(address == "quit") {
                            break;
                        }
                        bool contactEntered = addressBook.AddEntry(name, address);
                        if (contactEntered) {
                            Console.WriteLine("Your AddressBook has been updated with the following:");
                            Console.WriteLine($"Name: {name} \nAddress: {address}");
                            break;
                        }
                        if(!contactEntered) {
                            Console.Write($"Would you like to update {name}? ");
                            if(Console.ReadLine().ToLower().Trim() == "yes") {
                                userInput = "update";
                                continue;
                            }
                        }
                    }

                    if (userInput == "remove") {
                        Console.Write("Enter a name to remove: ");
                        name = Console.ReadLine();
                        addressBook.RemoveEntry(name);
                        break;
                    }

                    if (userInput == "update") {
                        while (true) {
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
                                    break;
                                }
                            }
                            else {
                                Console.WriteLine("You have several contacts matching your search");
                                foreach (var contact in search) {
                                    Console.WriteLine($"Name: {contact.Name}");
                                    Console.WriteLine($"Address: {contact.Address}");
                                }
                                Console.Write("Would you like to update one of these Contacts or add a new one? ");
                                var response = Console.ReadLine();
                                if (response == "update") {
                                    Console.Write("Use the above list to be a little more specific with your update. Hit enter to continue");
                                    continue;
                                }
                            }
                        }
                    }

                    if (userInput == "search") {
                        Console.WriteLine("Please enter the name of the Contact you wish to search");
                        name = Console.ReadLine();
                        var contacts = addressBook.Search(name);
                        foreach (var contact in contacts) {
                            Console.WriteLine(contact.Name);
                        }
                        break;
                    }
                    if(userInput == "view") {
                        var contactsList = addressBook.ViewContactsList();
                        foreach (var contact in contactsList) {
                            Console.WriteLine($"Name: {contact.Name}");
                            Console.WriteLine($"Address: {contact.Address}");
                        }
                        break;
                    }
                    break;
                }
            }
               
        }
    }
}
