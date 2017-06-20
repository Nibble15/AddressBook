
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
                return false;
            }
            Contact AddContact = new Contact(name, address);
            _dataBase.Add(AddContact);
            return true;
        }

        /// <summary>
        /// Returns true if a value is passed in by the user. If null false is returned.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public bool UpdateContact(string response) => (response != null) ? true : false;
        public Contact UpdateContact(string originalName, string propertyToUpdate, string updatedProperty) {
            updatedProperty = FormatContact(updatedProperty);
            int index = GetEntryIndex(originalName);
           // Console.WriteLine(index);
            if (index >= 0) {
                switch (propertyToUpdate) {
                    case "name":
                        _dataBase[index].Name = updatedProperty;
                        break;
                    case "address":
                        _dataBase[index].Address = updatedProperty;
                        break;
                }
                return _dataBase[index];
            }
            return null;
        }

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



