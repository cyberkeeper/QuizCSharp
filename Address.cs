namespace Useful
{
    /// <summary>
    /// Simple class to hold address details.
    /// 
    /// </summary>
    public class Address
    {
        private int _houseNumber;
        private string _street = string.Empty;
        private string _town = string.Empty;
        private string _county = string.Empty;
        private string _postcode = string.Empty;

        /// <summary>
        /// Empty constructor. Created to prevent null objects being used.
        /// </summary>
        public Address() { }

        /// <summary>
        /// Create a new instance of address. Assumes that every house has a number. No checks are made on postcode to check
        /// for length, and good formatting.
        /// </summary>
        /// <param name="houseNumber">house number</param>
        /// <param name="street">street name</param>
        /// <param name="town">town</param>
        /// <param name="county">district or county</param>
        /// <param name="postcode">postcode or zip code. No checks are carried out on the format of supplied String. </param>
        public Address(int houseNumber, string street, string town, string county, string postcode)
        {
            HouseNumber = houseNumber;
            Street = street;
            Town = town;
            County = county;
            Postcode = postcode;
        }

        /// <summary>
        /// Gets or sets the house number
        /// </summary>
        public int HouseNumber { get => _houseNumber; set => _houseNumber = value; }

        /// <summary>
        /// Gets or sets the street name
        /// </summary>
        public string Street { get => _street; set => _street = value; }

        /// <summary>
        /// Gets or sets the town
        /// </summary>
        public string Town { get => _town; set => _town = value; }

        /// <summary>
        /// Gets or sets the county
        /// </summary>
        public string County { get => _county; set => _county = value; }

        /// <summary>
        /// Gets or sets the postcode
        /// </summary>
        public string Postcode { get => _postcode; set => _postcode = value; }

        /// <summary>
        /// Return a single string showing the address properly formatted.
        /// </summary>
        /// <returns>Formatted String showing full address.</returns>
        public override string? ToString()
        {
            return HouseNumber + " " + Street + ",\n" + Town + ",\n" + County + ",\n" + Postcode + ".";
        }


    }
}
