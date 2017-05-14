using System;

namespace AddressBook {
    class Program {
        static void Main(string[] args) {

            AddressBook addressBook = new AddressBook();

            PromptUser();

            void Menu() {
                Console.WriteLine("TYPE:");
                Console.WriteLine("'Add' to add a contact: ");
                Console.WriteLine("'View' to view the list of contacts: ");
                Console.WriteLine("'Remove' to select and remove a contact: ");
                Console.WriteLine("'Update' to select and update a contact: ");
                Console.WriteLine("'Quit' at anytime to exit: ");
            }

            void UpdateAddressBook(string userInput) {
                string name = "";
                string address = "";
                switch ( userInput.ToLower() ) {
                    case "add":
                        Console.Write("Enter a name: ");
                        name = Console.ReadLine().Trim();
                        switch(name) {
                            case "quit":
                                break;
                            default:
                                Console.Write("Enter an address: ");
                                address = Console.ReadLine().Trim();
                                switch (address) {
                                    case "quit":
                                        break;
                                    default:
                                        addressBook.AddEntry(name, address);
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
                        Console.WriteLine(addressBook.ViewContactsList());
                        break;
                    case "update":
                        Console.WriteLine("Please enter the name of the Contact you wish to update");
                        name = Console.ReadLine();
                        addressBook.UpdateContact(name);
                        break;
                }
            }

            void PromptUser() {
                Menu();
                string userInput = "";
                while (userInput != "quit") {
                    Console.WriteLine("What would you like to do?");
                    userInput = Console.ReadLine().Trim();
                    UpdateAddressBook(userInput);
                }
            }
        }
    }
}
