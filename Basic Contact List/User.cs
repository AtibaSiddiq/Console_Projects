namespace Basic_Contact_List
{
    public class User
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }        
        public User(string name, string phoneNumber)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }
    }
}