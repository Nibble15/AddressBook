using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook {
    class ContactRepository {
        //NOTE: workaround for not having a database to pull items from

        public List<Contact> LoadContacts() {
                return new List<Contact> {
                    new Contact("Robert Paulson", "34 Elm Street California MD 20619"),
                    new Contact("Blake Lively", "1234 Main Street Boston MA 12345"),
                    new Contact("Steve Johnson", "67895 Doodle Street Berkely CA 12345"),
                    new Contact("Bob Robertson", "98465 Stiff Neck Road Witchita KS 12345"),
                    new Contact("Harley Davidson", "12 Main Street Holdem TX 12345"),
                    new Contact("Anna Wells", "1 Two Street ThreeTown UK 12345-0987"),
                    new Contact("Dave Johnson", "1010 Binary Way ComputerTown AR 65147"),
                    new Contact("Christine Abernathy", "1 Simple Street Seattle WA 12345"),
                    new Contact("Dave Carpenter", "54276 Dolphin Ave Miami FLA 25894"),
                    new Contact("Sock Puppet", "1234 Sesame Street WhereEverYouAre Planet Earth 1"),
                    new Contact("Zoe Saldana", "1 My Street Lexington Park MD 20653"),
                    new Contact("Mr Ripley", "75 Tricky Street London UK 01359"),
                    new Contact("Doc Holiday", "45 Sunshine Road Vagas NV 12345"),
                    new Contact("Santa Claus", "1 North Pole North Pole North Pole 0"),
                    new Contact("Lightening McQueen", "1 Super Fast Way MyKidsHeart MD 20653"),
                    new Contact("Kyle Jensen", "20605 Hollywood Blvd Anywhere MD 26058"),
                    new Contact("Dave Doolittle", "1234 Main Street SomeTown MA 65895"),
                    new Contact("Zoe Johnson", "345 Main Street Boston MN 98564")
            };
        } 

        
    }
}
