namespace Useful
{
    /// <summary>
    /// Class to hold generic person information. Uses a TimeDate type variable to hold the date of birth.
    /// </summary>
    public class Person
    {
        private string _firstName = string.Empty;
        private string _surname = string.Empty;
        public DateTime _dateOfBirth;
        private Address _address = new Address();

        /// <summary>
        /// Basic constructor allows creation of a person using name only. Assumption is that the other 
        /// information required by the program will have it added using setter methods.
        /// </summary>
        /// <param name="firstName">first name</param>
        /// <param name="surname">surname</param>
        public Person(string firstName, string surname)
        {
            _firstName = firstName;
            _surname = surname;
        }

        /// <summary>
        /// Gets or sets the firstname
        /// </summary>
        public string FirstName { get => _firstName; set => _firstName = value; }

        /// <summary>
        /// Gets or sets the surname
        /// </summary>
        public string Surname { get => _surname; set => _surname = value; }

        /// <summary>
        /// Gets the date of birth
        /// </summary>
        public DateTime DateOfBirth { get => _dateOfBirth; }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        public Address Address { get => _address; set => _address = value; }

        /// <summary>
        /// Sets the date of birth. Performs simple validation to check supplied parameter is in the
        /// correct format. If nothing supplied set date of birth to today.
        /// </summary>
        /// <param name="value">Date should be in yyyy-mm-dd format</param>
        /// <exception cref="Exception">If the supplied data can not be converted to DateTime throw Exception.</exception>
        public void SetDateOfBirth(string value)
        {
            if (!(value.Length < 1))
            {
                try
                {
                    DateTime newDate = DateTime.Parse(value);
                    _dateOfBirth = newDate;
                }
                catch (Exception e)
                {
                    throw new Exception("Err: Unable to parse String to date.\n" + e.Message, e);
                }
            }
            else
            {
                _dateOfBirth = DateTime.Now;
            }
        }

        /// <summary>
        /// Get the first name and the surname of the person
        /// </summary>
        /// <returns>firstname surname</returns>
        public string GetFullName()
        {
            return FirstName + " " + Surname;
        }

        /// <summary>
        /// Returns the age in years of the person
        /// </summary>
        /// <returns>Nunmber of years</returns>
        public int GetAge()
        {
            int days = (DateTime.Today - _dateOfBirth).Days;
            return days / 365;
        }

        /// <summary>
        /// Set the address, this is alternative to supplying an existing Address instance object 
        /// </summary>
        /// <param name="houseNumber">house number</param>
        /// <param name="street">street name</param>
        /// <param name="town">town</param>
        /// <param name="county">county or district</param>
        /// <param name="postcode">postocde</param>
        public void SetAddress(int houseNumber, String street, String town, String county, String postcode)
        {
            Address = new Address(houseNumber, street, town, county, postcode);
        }

        /// <summary>
        /// Return the name of the persons
        /// </summary>
        /// <returns>fullname</returns>
        public override string? ToString()
        {
            return GetFullName();
        }
    }
}
