
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook {
    class AddressBook {
        
        private ContactRepository _dataBaseLink = new ContactRepository();
        private List<Contact> _dataBase; 

        public AddressBook() {
            _dataBase = _dataBaseLink.LoadContacts();
        }

    public bool AddEntry(string name, string address) {
            name = FormatContact(name.Trim());
            address = FormatContact(address.Trim());
            if (_dataBase.Any(c => c.Name == name)) {
                //Console.WriteLine($"({name}) already exists in Address Book!");
                //UpdateContact(name);
                return false;
            }
            Contact AddContact = new Contact(name, address);
            _dataBase.Add(AddContact);
            //Console.WriteLine("Address Book updated. Name: {0} -- Address: {1} has been added!", name, address);
            return true;
        }

        /// <summary>
        /// Returns true if a value is passed in by the user.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public bool UpdateContact(string response) => (response != null) ? true : false;

        //TODO: switch AddEntry to just return a bool if the name exists and use Main to print 
        //that it exists and ask to update the contact with the above UpdateContact. if the response is "y"
        //then run the below UpdateContact method
        public Contact UpdateContact(string originalName, string propertyToUpdate, string updatedProperty) {
            updatedProperty = FormatContact(updatedProperty);
            int index = GetEntryIndex(originalName);
            Console.WriteLine(index);
            if (index >= 0) {
                switch (propertyToUpdate) {
                    case "name":
                        _dataBase[index].Name = updatedProperty;
                        //Console.WriteLine($"Contact {originalName}'s {propertyToUpdate} updated to {updatedProperty}");
                        break;
                    case "address":
                        _dataBase[index].Address = updatedProperty;
                        //Console.WriteLine($"Contact {originalName}'s {propertyToUpdate} updated to {updatedProperty}");
                        break;
                }
                return _dataBase[index];
            }
            return null;
        }
        
        //public bool UpdateContact(string originalName) {
        //    Console.Write("Are you sure you would you like to update the Contact? -- Type 'Y' or 'N': ");
        //    string userResponse = Console.ReadLine().ToLower();
        //    if (userResponse == "y") {
        //        Console.Write($"Would you like to update {originalName}'s name or address? TYPE - 'Name' for name and 'Address' for address: ");
        //        string contactToUpdate = Console.ReadLine().ToLower();

        //        Console.Write($"Please enter changes to the {contactToUpdate} here: ");
        //        string updatedContact = Console.ReadLine().Trim();
        //        updatedContact = FormatContact(updatedContact);

        //        int index = GetEntryIndex(originalName);
        //        switch(contactToUpdate) {
        //            case "name":
        //                _dataBase[index].Name = updatedContact;
        //                Console.WriteLine($"Contact {originalName} updated to {updatedContact}");
        //                return true;
        //            case "address":
        //                _dataBase[index].Address = updatedContact;
        //                Console.WriteLine($"Contact {originalName}'s {contactToUpdate} updated to {updatedContact}");
        //                return true;
        //        }
        //    }
        //    return false;
        //}

        /// <summary>
        /// Formats a Contact 
        /// </summary>
        /// <param name="stringToFormat"></param>
        /// <returns>The contact to format</returns>
        private string FormatContact(string stringToFormat) {
            char[] arr = stringToFormat.ToCharArray();
            for (int i = 0; i < arr.Length; i++) {
                int num;
                if (i == 0 || arr[i - 1] == ' ' && !( int.TryParse(arr[i].ToString(), out num) ) ) { 
                    arr[i] = Convert.ToChar( arr[i].ToString().ToUpper() );
                }
                else {
                    arr[i] = Convert.ToChar(arr[i].ToString().ToLower());
                }
            }
            return String.Concat(arr);
        }

        /// <summary>
        /// Gets the index of the specified Contact in the Addressbook
        /// returns -1 if the item doesn't exist
        /// </summary>
        /// <param name="name"></param>
        /// <returns>an integer</returns>
        private int GetEntryIndex(string name) {
            //for (int i = 0; i < _dataBase.Count; i++) {
            //    if (_dataBase[i] != null && _dataBase[i].Name.ToLower() == name.ToLower())
            //        return i;
            //}
            var index = _dataBase.FindIndex(c => c.Name.ToLower().Contains(name.ToLower()));
            if (index >= 0) {
                return index;
            }
            return -1;
        }

        /// <summary>
        /// Removes a contact from the list
        /// </summary>
        /// <param name="name"></param>
        public void RemoveEntry(string name) {
            var index = GetEntryIndex(name);
            if (index != -1) {
                _dataBase.Remove(_dataBase[index]);
                Console.WriteLine("{0} removed from contacts", name);
            }
        }

        /// <summary>
        /// Creates a list of Contacts with names containing the substring supplied by the user
        /// </summary>
        /// <param name="name"></param>
        /// <returns>
        /// A list of names
        /// </returns>
        public List<Contact> Search(string name) => _dataBase.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();
        
        /// <summary>
        /// Gets the list of Contacts
        /// </summary>
        /// <returns>The list of contacts in order by Name</returns>
        public IOrderedEnumerable<Contact> ViewContactsList() => _dataBase.OrderBy(c => c.Name);



        //{
        //    string contactList = String.Empty;
        //    foreach (Contact contact in _dataBase) {
        //        contactList += String.Format("Name: {0} -- Address: {1} \n", contact.Name, contact.Address);
        //    }


        //    return (contactList != String.Empty) ? contactList : "Your Address Book is empty.";
        //}


        public void Menu() {
            Console.WriteLine("TYPE:");
            Console.WriteLine("'Add' to add a contact: ");
            Console.WriteLine("'View' to view the list of contacts: ");
            Console.WriteLine("'Remove' to select and remove a contact: ");
            Console.WriteLine("'Update' to select and update a contact: ");
            Console.WriteLine("'Quit' at anytime to exit: ");
            Console.WriteLine("'Search' to search for a name; ");
        }
    }
}



