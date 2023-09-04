using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Basic_Contact_List
{
    public class Profiles : IProfiles
    {
        static List<User> users = new List<User>();

        public Profiles()
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
                            var profile = JsonSerializer.Deserialize<User>(line);
                            users.Add(profile);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ViewProfile(User loggedInUser)
        {
            System.Console.WriteLine("Below is your profile: ");
            System.Console.WriteLine(loggedInUser.Name + " " + loggedInUser.PhoneNumber);
            Menus.ContactMenu(loggedInUser);
        }
        public void UpdateProfile(User loggedInUser)
        {
        label1:
            System.Console.WriteLine("Do you want to update:\n" +
                                     "1. the name in your profile\n" +
                                     "2. the phone number in your profile");
            int choice6;
            var isSuccessful9 = int.TryParse(Console.ReadLine(), out choice6);
            if (isSuccessful9)
            {
                if (choice6 == 1)
                {
                    System.Console.Write("Enter the name to change to: ");
                    string newName = Console.ReadLine();
                    loggedInUser.Name = newName;
                    RefreshFile();
                    System.Console.WriteLine("Profile updated");
                    Menus.ContactMenu(loggedInUser);
                }
                else if (choice6 == 2)
                {
                label2:
                    System.Console.Write("Enter your phone number: ");
                    var phoneNo = Console.ReadLine();
                    var isSuccesful1 = long.TryParse(phoneNo, out long phoneNumber);
                    if (isSuccesful1)
                    {
                        if (phoneNo.Length != 11)
                        {
                            System.Console.WriteLine("Phone number must have 11 digits");
                            goto label2;
                        }
                        else
                        {
                            var contact = GetUserDetailsByPhoneNumber(phoneNo);
                            if (contact == null)
                            {
                                System.Console.WriteLine($"The phone number {phoneNo} does not exist");
                            }
                            else
                            {
                            label3:
                                System.Console.Write("Enter the phone number to change to: ");
                                var newPhoneNo = Console.ReadLine();
                                var isSuccesful2 = long.TryParse(phoneNo, out long PhoneNumber);
                                if (isSuccesful2)
                                {
                                    contact.PhoneNumber = newPhoneNo;
                                    RefreshFile();
                                    System.Console.WriteLine("Profile updated");
                                    Menus.ContactMenu(loggedInUser);
                                }
                                else
                                {
                                    System.Console.WriteLine("Wrong Input. Please try again");
                                    goto label3;
                                }
                            }
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Wrong input. Please try again");
                        goto label2;
                    }
                }
            }
            else
            {
                System.Console.WriteLine("Wrong input. Please try again");
                goto label1;
            }
        }
        public void RefreshFile()
        {
            TextWriter writer = new StreamWriter("Users.txt");
            foreach (var user in users)
            {
                writer.WriteLine(JsonSerializer.Serialize(user));
                // writer.WriteLine(profile.ToString());
            }
            writer.Flush();
            writer.Close();
        }
        public User GetUserDetailsByPhoneNumber(string phoneNumber)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].PhoneNumber == phoneNumber)
                {
                    return users[i];
                }
            }
            return null;
        }
        public User GetUserDetailsByName(string name)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Name.ToLower() == name.ToLower())
                {
                    return users[i];
                }
            }
            return null;
        }
    }
}