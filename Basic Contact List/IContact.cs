namespace Basic_Contact_List
{
    public interface IContact
    {
        void AddContact(User loggedInUser);
        void SearchContact(User loggedInUser);
        void UpdateContact(User loggedInUser);
        void DeleteContact(User loggedInUser);
        void DisplayContactDetails(User loggedInUser);
        void RefreshFile();
        ContactDetails GetContactDetailsByPhoneNumber(string phoneNumber);
        ContactDetails GetContactDetailsByName(string name);
    }
}
