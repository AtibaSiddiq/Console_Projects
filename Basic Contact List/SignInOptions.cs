using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Basic_Contact_List
{
    public class SignInOptions
    {
        static User user;
        static IProfiles profile = new Profiles();
        static Admin admin = new Admin();
        static List<User> users = new List<User>();

        public void Register()
        {
        label1:
            System.Console.WriteLine("Please register your name and phone number");
            System.Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            var search = profile.GetUserDetailsByName(name);
            if (search != null)
            {
                System.Console.WriteLine("The name already exists. Please try again");
                goto label1;
            }
            else
            {
            label2:
                System.Console.Write("Enter your phone number: ");
                var phoneNo = Console.ReadLine();
                var isSuccesful1 = long.TryParse(phoneNo, out long phoneNumber);
                if (isSuccesful1)
                {
                    var search2 = profile.GetUserDetailsByPhoneNumber(phoneNo);
                    if (phoneNo.Length != 11)
                    {
                        System.Console.WriteLine("Phone number must have 11 digits");
                        goto label2;
                    }
                    else if (search2 != null)
                    {
                        System.Console.WriteLine("The phone number already exists. Please try again");
                        goto label2;
                    }
                    else
                    {
                        user = new User(name, phoneNo);
                        users.Add(user);
                        TextWriter writer = new StreamWriter("Users.txt", true);
                        writer.WriteLine(JsonSerializer.Serialize(user));
                        writer.Close();
                        System.Console.WriteLine("Registration is successful");
                        Menus.ContactMenu(user);
                    }
                }
                else
                {
                    System.Console.WriteLine("Wrong input. Please try again");
                    goto label2;
                }
            }
        }
        
        public static User Login()
        {
        label4:
            System.Console.WriteLine("Enter your phone number");
            var phoneNo = Console.ReadLine();
            var isSuccesful14 = long.TryParse(phoneNo, out long phoneNumber);
            if (isSuccesful14)
            {
                var success = GetUser(phoneNo);
                return success;
            }
            else
            {
                System.Console.WriteLine("Wrong input. Please try again");
                goto label4;
            }
        }
        public static User GetUser(string phoneNumber)
        {
            if (users.Count > 0)
            {
                foreach (var item in users)
                {
                    if (item.PhoneNumber.Contains(phoneNumber))
                    {
                        return item;
                    }
                }
                return null;
            }
            return null;
        }
        public static void AdminLogin()
        {
        labe5l:
            System.Console.WriteLine("Enter your phone number");
            var phoneNo = Console.ReadLine();
            var isSuccesful14 = long.TryParse(phoneNo, out long phoneNumber);
            if (isSuccesful14)
            {
                if (phoneNo.Length != 11)
                {
                    System.Console.WriteLine("Phone number must have 11 digits");
                    goto labe5l;
                }
                else if (!admin.PhoneNumber.Contains(phoneNo))
                {
                    System.Console.WriteLine("Wrong phone number. Please try again");
                    goto labe5l;
                }
                else
                {
                label5:
                    System.Console.WriteLine("Enter your password");
                    string password = Console.ReadLine();
                    if (!admin.Password.Contains(password))
                    {
                        System.Console.WriteLine("Wrong password. Please try again");
                        goto label5;
                    }
                    else
                    {
                        System.Console.WriteLine("Login successful");
                        Menus.AdminMenu();
                    }
                }
            }
            else
            {
                System.Console.WriteLine("Wrong input. Please try again");

            }
        }
    }
}