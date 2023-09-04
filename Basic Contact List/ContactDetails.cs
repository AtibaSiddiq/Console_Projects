namespace Basic_Contact_List
{
    public class ContactDetails
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CreatedBy {get; set; }
        public ContactDetails(string name, string phoneNumber, string createdBy)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.CreatedBy = createdBy;
        }
        // public static ContactDetails Parse(string line)
        // {
        //     string[] parse = line.Split('\t');
        //     return new ContactDetails(parse[0] + '\t', parse[1]);
        // }
        // public override string ToString()
        // {
        //     return $"{Name}\t{PhoneNumber}";
        // }
    }
}