using Shared;

namespace Services
{
    /// <summary>
    /// Mock data for this application.
    /// </summary>
    internal class MockData
    {
        public static readonly MockData  Instance = new MockData();

        private MockData() { }

        static MockData() { }

        /// <summary>
        /// All users
        /// </summary>
        public IEnumerable<User> Users { get; } =
        [
            new()
            {
                UserId = "CD1CCD6E-7297-4EC1-9966-A3325B1756DB",
                FirstName = "Bob",
                LastName = "Ross",
                Email = "b.ross@example.com"
            }
        ];

        /// <summary>
        /// All vehicles
        /// </summary>
        public IEnumerable<Vehicle> Vehicles { get; } =
        [
            new() {
                VehicleId = 1,
                Make = "Toyota",
                Model = "Camry",
                Year = 2020,
                Colour = "Blue",
                VIN = "1HGCM82633A123456",
                EngineNumber = "ENG123456"
            },
            new()
            {
                VehicleId = 2,
                Make = "Honda",
                Model = "Civic",
                Year = 2019,
                Colour = "Red",
                VIN = "2HGCM82633A654321",
                EngineNumber = "ENG654321"
            },
                        new ()
            {
                VehicleId = 3,
                Make = "Toyota",
                Model = "Corolla",
                Year = 2018,
                Colour = "White",
                VIN = "3TACR82633A000001",
                EngineNumber = "ENG000001"
            },
            new ()
            {
                VehicleId = 4,
                Make = "Honda",
                Model = "Accord",
                Year = 2021,
                Colour = "Black",
                VIN = "4HGAC82633A000002",
                EngineNumber = "ENG000002"
            },
            new ()
            {
                VehicleId = 5,
                Make = "Hyundai",
                Model = "Elantra",
                Year = 2017,
                Colour = "Silver",
                VIN = "5NPEB82633A000003",
                EngineNumber = "ENG000003"
            },
            new ()
            {
                VehicleId = 6,
                Make = "Toyota",
                Model = "RAV4",
                Year = 2022,
                Colour = "Green",
                VIN = "6T3BF82633A000004",
                EngineNumber = "ENG000004"
            },
            new ()
            {
                VehicleId = 7,
                Make = "Honda",
                Model = "CR-V",
                Year = 2020,
                Colour = "Blue",
                VIN = "7HGRV82633A000005",
                EngineNumber = "ENG000005"
            },
            new ()
            {
                VehicleId = 8,
                Make = "Hyundai",
                Model = "Sonata",
                Year = 2019,
                Colour = "Red",
                VIN = "8KMHS82633A000006",
                EngineNumber = "ENG000006"
            },
            new ()
            {
                VehicleId = 9,
                Make = "Toyota",
                Model = "Prius",
                Year = 2016,
                Colour = "Yellow",
                VIN = "9JTCG82633A000007",
                EngineNumber = "ENG000007"
            },
            new ()
            {
                VehicleId = 10,
                Make = "Honda",
                Model = "Pilot",
                Year = 2015,
                Colour = "Gray",
                VIN = "1HGPX82633A000008",
                EngineNumber = "ENG000008"
            },
            new ()
            {
                VehicleId = 11,
                Make = "Hyundai",
                Model = "Tucson",
                Year = 2021,
                Colour = "White",
                VIN = "2HMMT82633A000009",
                EngineNumber = "ENG000009"
            },
            new ()
            {
                VehicleId = 12,
                Make = "Toyota",
                Model = "Highlander",
                Year = 2023,
                Colour = "Black",
                VIN = "3TLBR82633A000010",
                EngineNumber = "ENG000010"
            },
            new ()
            {
                VehicleId = 13,
                Make = "Honda",
                Model = "Civic",
                Year = 2022,
                Colour = "Blue",
                VIN = "4HGCV82633A000011",
                EngineNumber = "ENG000011"
            },
            new ()
            {
                VehicleId = 14,
                Make = "Hyundai",
                Model = "Santa Fe",
                Year = 2020,
                Colour = "Silver",
                VIN = "5XNMN82633A000012",
                EngineNumber = "ENG000012"
            },
            new ()
            {
                VehicleId = 15,
                Make = "Toyota",
                Model = "Corolla",
                Year = 2019,
                Colour = "Red",
                VIN = "6TDED82633A000013",
                EngineNumber = "ENG000013"
            },
            new ()
            {
                VehicleId = 16,
                Make = "Honda",
                Model = "Fit",
                Year = 2016,
                Colour = "Green",
                VIN = "7HGFY82633A000014",
                EngineNumber = "ENG000014"
            },
            new ()
            {
                VehicleId = 17,
                Make = "Hyundai",
                Model = "Kona",
                Year = 2018,
                Colour = "Orange",
                VIN = "8KNDX82633A000015",
                EngineNumber = "ENG000015"
            },
            new ()
            {
                VehicleId = 18,
                Make = "Toyota",
                Model = "Camry",
                Year = 2024,
                Colour = "Pearl",
                VIN = "9TABC82633A000016",
                EngineNumber = "ENG000016"
            },
            new ()
            {
                VehicleId = 19,
                Make = "Honda",
                Model = "Accord",
                Year = 2023,
                Colour = "White",
                VIN = "1HABC82633A000017",
                EngineNumber = "ENG000017"
            },
            new ()
            {
                VehicleId = 20,
                Make = "Hyundai",
                Model = "Elantra",
                Year = 2022,
                Colour = "Blue",
                VIN = "2HNEL82633A000018",
                EngineNumber = "ENG000018"
            },
            new ()
            {
                VehicleId = 21,
                Make = "Toyota",
                Model = "RAV4",
                Year = 2017,
                Colour = "Gray",
                VIN = "3TRAV82633A000019",
                EngineNumber = "ENG000019"
            },
            new ()
            {
                VehicleId = 22,
                Make = "Honda",
                Model = "CR-V",
                Year = 2018,
                Colour = "Black",
                VIN = "4HCRV82633A000020",
                EngineNumber = "ENG000020"
            },
            new ()
            {
                VehicleId = 23,
                Make = "Hyundai",
                Model = "Tucson",
                Year = 2015,
                Colour = "Red",
                VIN = "5HTUC82633A000021",
                EngineNumber = "ENG000021"
            },
            new ()
            {
                VehicleId = 24,
                Make = "Toyota",
                Model = "Prius",
                Year = 2015,
                Colour = "Green",
                VIN = "6TPRS82633A000022",
                EngineNumber = "ENG000022"
            },
            new ()
            {
                VehicleId = 25,
                Make = "Honda",
                Model = "Pilot",
                Year = 2024,
                Colour = "Blue",
                VIN = "7HPIL82633A000023",
                EngineNumber = "ENG000023"
            },
            new ()
            {
                VehicleId = 26,
                Make = "Hyundai",
                Model = "Santa Fe",
                Year = 2023,
                Colour = "White",
                VIN = "8HSNF82633A000024",
                EngineNumber = "ENG000024"
            },
            new ()
            {
                VehicleId = 27,
                Make = "Toyota",
                Model = "Corolla",
                Year = 2021,
                Colour = "Silver",
                VIN = "9TCOR82633A000025",
                EngineNumber = "ENG000025"
            },
            new ()
            {
                VehicleId = 28,
                Make = "Honda",
                Model = "Civic",
                Year = 2017,
                Colour = "Yellow",
                VIN = "1HCIV82633A000026",
                EngineNumber = "ENG000026"
            },
            new ()
            {
                VehicleId = 29,
                Make = "Hyundai",
                Model = "Kona",
                Year = 2024,
                Colour = "Black",
                VIN = "2HKON82633A000027",
                EngineNumber = "ENG000027"
            },
            new ()
            {
                VehicleId = 30,
                Make = "Toyota",
                Model = "Highlander",
                Year = 2019,
                Colour = "Brown",
                VIN = "3THIG82633A000028",
                EngineNumber = "ENG000028"
            },
            new ()
            {
                VehicleId = 31,
                Make = "Honda",
                Model = "Fit",
                Year = 2020,
                Colour = "Orange",
                VIN = "4HFIT82633A000029",
                EngineNumber = "ENG000029"
            },
            new ()
            {
                VehicleId = 32,
                Make = "Hyundai",
                Model = "Sonata",
                Year = 2016,
                Colour = "Maroon",
                VIN = "5HSON82633A000030",
                EngineNumber = "ENG000030"
            },
        ];

        /// <summary>
        /// All vehicle registrations
        /// </summary>
        public IEnumerable<Registration> Registrations
        {
            get
            {
                field ??= BuildRegistrations();
                return field;
            }
        }

        private List<Registration> BuildRegistrations()
        {
            var registrations = new List<Registration>();
            var vehicleList = Vehicles.ToList();
            var user = Users.First().UserId;
            var today = DateTime.Today;
            var random = new Random();

            for (int i = 0; i < vehicleList.Count; i++, i++)
            {
                var vehicle = vehicleList[i];

                // 1 in 5 registrations should be expired (in the past).
                bool expired = ((i + 1) % 5) == 0;

                DateTime expiry;
                if (expired)
                {
                    // expired sometime in the past within the last year
                    expiry = today.AddDays(-1 -random.Next(0,364));
                }
                else
                {
                    // future expiry between 0 and 365 days from today
                    expiry = today.AddDays(random.Next(0, 365));
                }

                registrations.Add(new Registration
                {
                    RegistrationId = i+1,
                    RegistrationNumber = $"REG{i:D5}",
                    ExpiryDateUtc = expiry,
                    VehicleId = vehicle.VehicleId,
                    UserId = user
                });
            }

            return registrations;
        }

    }
}
