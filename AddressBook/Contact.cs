﻿namespace AddressBook {
    class Contact {
        public string Name { get; set; }
        public string Address { get; set; }

        public Contact(string name, string address) {
            Name = name;
            Address = address;
        }
        public override string ToString() {
            return $"Name: {Name}\nAddress: {Address}\n";
        }
    }
}
