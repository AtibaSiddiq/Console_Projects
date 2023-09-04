using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Basic_Contact_List
{
    public class Admin : IAdmin
    {
        Profiles profile = new Profiles();
        static List<User> users = new List<User>();
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public Admin()
        {
            try
            {
                if (File.Exists("Users.txt"))
                {
                    var texts = File.ReadAllLines("Users.txt");
                    if (texts is not null)
                    {
                        foreach (var line in texts)
                        {
                            var user = JsonSerializer.Deserialize<User>(line);
                            users.Add(user);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ViewAllUsers()
        {
            System.Console.WriteLine("Below are the users of this application:");
            foreach (var item in users)
            {
                System.Console.WriteLine(item);
            }
        }
        public void DeleteUser()
        {
        label:
            System.Console.WriteLine("Please enter the phone number of the user to delete");
            var phoneNo = Console.ReadLine();
            var isSuccesful1 = long.TryParse(Console.ReadLine(), out long phoneNumber);
            if (isSuccesful1)
            {
                var check = profile.GetUserDetailsByPhoneNumber(phoneNo);
                if (phoneNo.Length != 11)
                {
                    System.Console.WriteLine("Phone number must have 11 digits");
                    goto label;
                }
                else if (check == null)
                {
                    System.Console.WriteLine("This phone number does not exist in the list of users. Please try again");
                    goto label;
                }
                else
                {
                    users.Remove(check);
                    System.Console.WriteLine("The user is deleted");
                }
            }
            else
            {
                System.Console.WriteLine("Wrong input. Please try again");
                goto label;
            }
        }
    }
}