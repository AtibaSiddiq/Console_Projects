namespace Basic_Contact_List
{
    public interface IProfiles
    {
        void ViewProfile(User loggedInUser); 
        void UpdateProfile(User loggedInUser);
        void RefreshFile();
        User GetUserDetailsByPhoneNumber(string phoneNumber);
        public User GetUserDetailsByName(string name);
    }
}