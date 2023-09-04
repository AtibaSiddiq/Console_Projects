using System;
using System.Collections.Generic;

namespace Basic_Contact_List
{
    public class Menus
    {
        static IContact contact = new Contact();
        static IAdmin admin = new Admin();
        static IProfiles profile = new Profiles();
        static List<User> users = new List<User>();
        static SignInOptions options = new SignInOptions();
        public static void MainMenu()
        {
        Label:
            Console.WriteLine("1. \t Register\n" +
                              "2. \t Login\n" +
                              "0. \t Logout");
            int option;
            var isSuccesful = int.TryParse(Console.ReadLine(), out option);
            if (isSuccesful)
            {
                switch (option)
                {
                    case 1:
                        options.Register();
                        break;
                    case 2:
                    label1:
                        System.Console.WriteLine("1. \t Login as User\n" +
                                                 "2. \t Login as Admin\n" +
                                                 "3. \t Back to Main Menu");
                        int option1;
                        var isSuccesful1 = int.TryParse(Console.ReadLine(), out option1);
                        if (isSuccesful1)
                        {
                            switch (option1)
                            {
                                case 1:
                                    var loggedInUser = SignInOptions.Login();
                                    if (loggedInUser != null)
                                    {
                                        Console.WriteLine("Login successful");
                                        ContactMenu(loggedInUser);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sorry but you have not registered");
                                        goto Label;
                                    }
                                    break;
                                case 2:
                                    SignInOptions.AdminLogin();
                                    break;
                                case 3:
                                    MainMenu();
                                    break;
                                default:
                                    System.Console.WriteLine("Wrong input. Please try again");
                                    goto label1;
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Wrong input. Please try again");
                            goto label1;
                        }
                        break;
                    case 0:
                        System.Console.WriteLine("Thank you for using SBM's Basic Contact List");
                        break;
                    default:
                        System.Console.WriteLine("Wrong input .Please try again");
                        goto Label;
                }
            }
            else
            {
                System.Console.WriteLine("Wrong input .Please try again");
                goto Label;
            }
        }
        public static void ContactMenu(User loggedInUser)
        {
        label:
            System.Console.WriteLine("Kindly select the operation to perform:");
            System.Console.WriteLine("1. \t Add Contacts\n" +
                                     "2. \t View my profile\n" +
                                     "3. \t Update my profile\n" +
                                     "4. \t View Contacts\n" +
                                     "5. \t Search Contact\n" +
                                     "6. \t Update Contacts\n" +
                                     "7. \t Delete Contacts\n" +
                                     "0. \t Back to main menu");
            int choice;
            var isSuccesful = int.TryParse(Console.ReadLine(), out choice);
            if (isSuccesful)
            {
                switch (choice)
                {
                    case 1:
                        contact.AddContact(loggedInUser);
                        break;
                    case 2:
                        profile.ViewProfile(loggedInUser);
                        break;
                    case 3:
                        profile.UpdateProfile(loggedInUser);
                        profile.RefreshFile();
                        break;
                    case 4:
                        contact.DisplayContactDetails(loggedInUser);
                        break;
                    case 5:
                        contact.SearchContact(loggedInUser);
                        break;
                    case 6:
                        contact.UpdateContact(loggedInUser);
                        break;
                    case 7:
                        contact.DeleteContact(loggedInUser);
                        break;
                    case 0:
                        MainMenu();
                        break;
                    default:
                        System.Console.WriteLine("Wrong input. Please try again");
                        goto label;
                }
            }
            else
            {
                System.Console.WriteLine("Wrong input.Please try again");
                goto label;
            }
        }
        public static User GetUser(string phoneNumber)
        {
            if (users.Count > 0)
            {
                foreach (var item in users)
                {
                    if (item.PhoneNumber == phoneNumber)
                    {
                        return item;
                    }
                }
                return null;
            }
            return null;
        }

        public static void AdminMenu()
        {
        label2:
            System.Console.WriteLine("\t\t\t\tWELCOME TO THE ADMIN DASHBOARD");
            System.Console.WriteLine("Kindly select the operation to perform:");
            System.Console.WriteLine("1. \t View All Users\n" +
                                     "2. \t Delete User\n" +
                                     "3. \t Back to MainMenu");
            int option2;
            var isSuccesful = int.TryParse(Console.ReadLine(), out option2);
            if (isSuccesful)
            {
                switch (option2)
                {
                    case 1:
                        admin.ViewAllUsers();
                        break;
                    case 2:
                        admin.DeleteUser();
                        profile.RefreshFile();
                        break;
                    case 3:
                        MainMenu();
                        break;
                    default:
                        System.Console.WriteLine("Wrong input. Please try again");
                        goto label2;
                }
            }
            else
            {
                System.Console.WriteLine("Wrong input. Please try again");
                goto label2;
            }
        }
    }
}