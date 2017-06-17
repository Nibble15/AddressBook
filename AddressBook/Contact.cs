namespace AddressBook {
    class Contact {
        public string Name { get; set; }
        public string Address { get; set; }
        //public int PhoneNumber { get; set; }

        public Contact(string name, string address) {
            Name = name;
            Address = address;
        }

        public override bool Equals(object obj) {
            var that = obj as Contact;
            if (that == null) {
                return false;
            }
            return this.Name == that.Name;
        }

        public override int GetHashCode() => Name.GetHashCode();
    }
}
