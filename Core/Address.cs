using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Address
    {
        public Address()
        {
        }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Floor { get; set; }

        public string Door { get; set; }

        public string PostalCode { get; set; }

        public string Town { get; set; }

        public Address(string street, string number, string floor, string door, string postalCode, string town)
        {
            Street = street;
            Number = number;
            Floor = floor;
            Door = door;
            PostalCode = postalCode;
            Town = town;
        }
    }
}
