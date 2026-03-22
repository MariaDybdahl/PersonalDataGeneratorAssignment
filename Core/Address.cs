using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace Core
{
    public class Address
    {
        public Address()
        { 
 
        }

        private readonly string connectionString = "server=localhost;port=3308;database=addresses;user=root;password=root";
        private static int _townCount = 0;
        private readonly Random _random = new();

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



        public Address GetRandomTownAndPostalCode()
        {

            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                if (_townCount == 0)
                {
                    _townCount = db.ExecuteScalar<int>("SELECT COUNT(*) FROM postal_code");
                }

                if (_townCount == 0)
                    return null;

                var randomTown = _random.Next(0, _townCount);

                var sql = @"
                SELECT 
                cPostalCode AS PostalCode,
                cTownName AS Town
                FROM postal_code
                LIMIT @offset, 1;
                ";

                return db.QueryFirstOrDefault<Address>(sql, new { offset = randomTown });
            }
        }


        public Address GetRandomAddress()
        {
            var townData = GetRandomTownAndPostalCode();

            if (townData == null)
                return null;

            return new Address
            {
                Street = GetRandomText(40),
                Number = GenerateNumber(),
                Floor = GenerateFloor(),
                Door = GenerateDoor(),
                PostalCode = townData.PostalCode,
                Town = townData.Town
            };
        }

        private string GenerateNumber()
        {
            var number = _random.Next(1, 1000).ToString();

            if (_random.Next(1, 11) < 3)
            {
                number += GetRandomText(1, false).ToUpper();
            }

            return number;
        }

        private string GenerateFloor()
        {
            if (_random.Next(1, 11) < 4)
            {
                return "st";
            }

            return _random.Next(1, 100).ToString();
        }

        private string GenerateDoor()
        {

            int doorType = _random.Next(1, 21);

            if (doorType < 8)
            {
                return "th";
            }
            else if (doorType < 15)
            {
                return "tv";
            }
            else if (doorType < 17)
            {
                return "mf";
            }
            else if (doorType < 19)
            {
                return _random.Next(1, 51).ToString();
            }
            else
            {
                string[] lowerCaseLetters =
                {
                    "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
                    "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                    "ø", "æ", "å"
                };

                string door = lowerCaseLetters[_random.Next(0, lowerCaseLetters.Length)];

                if (doorType == 20)
                {
                    door += "-";
                }

                door += _random.Next(1, 1000).ToString();

                return door;
            }
        }

        private string GetRandomText(int length, bool includeDanishLetters = true)
        {
            string[] chars = includeDanishLetters
                ? new[] {
                    "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q",
                    "r","s","t","u","v","w","x","y","z","æ","ø","å"
                  }
                : new[] {
                    "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q",
                    "r","s","t","u","v","w","x","y","z"
                  };

            var sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                sb.Append(chars[_random.Next(0, chars.Length)]);
            }

            return sb.ToString();
        }
    }
}
