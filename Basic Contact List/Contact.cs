using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

namespace Basic_Contact_List
{
    public class Contact : IContact
    {
        static List<ContactDetails> contacts = new List<ContactDetails>();
        public Contact()
        {
            try
            {
                if (File.Exists("Phonebook.txt"))
                {
                    List<string> texts = File.ReadAllLines("Phonebook.txt").ToList();
                    if (texts is not null)
                    {
                        foreach (var line in texts)
                        {
                            // var contact = ContactDetails.Parse(line);
                            var contact = JsonSerializer.Deserialize<ContactDetails>(line);
                            contacts.Add(contact);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void AddContact(User loggedInUser)
        {
        label3:
            System.Console.Write("Enter the contacts' name: ");
            string name = Console.ReadLine();
            var search = GetContactDetailsByName(name);
            if (search != null)
            {
                System.Console.WriteLine("The name already exists. Please try again");
                goto label3;
            }
            else
            {
            label4:
                System.Console.Write("Enter the contacts' phone number: ");
                var phoneNo = Console.ReadLine();
                var isSuccesful2 = long.TryParse(phoneNo, out long phoneNumber);
                if (isSuccesful2)
                {
                    if (phoneNo.Length != 11)
                    {
                        System.Console.WriteLine("Phone number must have 11 digits");
                        goto label4;
                    }
                    else
                    {
                        foreach (var item in contacts)
                        {
                            if (phoneNo == item.PhoneNumber)
                            {
                                System.Console.WriteLine("Phone number already exists. Please try again");
                                goto label4;
                            }
                        }
                        ContactDetails detatils = new ContactDetails(name, phoneNo, loggedInUser.PhoneNumber);
                        contacts.Add(detatils);
                        TextWriter writer = new StreamWriter("Phonebook.txt", true);
                        writer.WriteLine(JsonSerializer.Serialize(detatils));
                        writer.Close();
                        System.Console.WriteLine("Contact added succesfully");
                    label5:
                        System.Console.WriteLine("Do you want to add another contact\n1. \t Yes\n2. \t No");
                        int choice1;
                        var isSuccesful3 = int.TryParse(Console.ReadLine(), out choice1);
                        if (isSuccesful3)
                        {
                            if (choice1 == 2)
                            {
                                Menus.ContactMenu(loggedInUser);
                            }
                            else if (choice1 == 1)
                            {
                                goto label3;
                            }
                            else
                            {
                                System.Console.WriteLine("Wrong input. Please try again");
                                goto label5;
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Wrong input. Please try again");
                            goto label5;
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("Wrong input. Please try again");
                    goto label4;
                }
            }
        }
        public void SearchContact(User loggedInUser)
        {
            if (contacts.Count == 0)
            {
            label7:
                System.Console.WriteLine("You have no contacts to search. Do you wish to add contacts?\n1. Yes \n2. No");
                int choice3;
                var isSuccessful5 = int.TryParse(Console.ReadLine(), out choice3);
                if (isSuccessful5)
                {
                    if (choice3 == 2)
                    {
                        Menus.ContactMenu(loggedInUser);
                    }
                    else if (choice3 == 1)
                    {
                        AddContact(loggedInUser);
                    }
                    else
                    {
                        System.Console.WriteLine("Wrong input. Please try again");
                        goto label7;
                    }
                }
                else
                {
                    System.Console.WriteLine("Wrong input. Please try again");
                    goto label7;
                }
            }
            else
            {
            labelling:
                System.Console.WriteLine("Do you want to search by:\n" +
                                         "1. name or\n" +
                                         "2. phone number");
                int choice4;
                var isSuccessful = int.TryParse(Console.ReadLine(), out choice4);
                if (isSuccessful)
                {
                    if (choice4 == 1)
                    {
                        System.Console.WriteLine("Please select the name to search");
                        var name = Console.ReadLine();
                        var search = GetContactDetailsByName(name);
                        if (search == null)
                        {
                        label10:
                            System.Console.WriteLine("Contact not found. Do you want to:\n" +
                                                    "1. Search for another contact\n" +
                                                    "2. Add that contact\n" +
                                                    "0. Back to Menu");
                            int choice5;
                            var isSuccesful8 = int.TryParse(Console.ReadLine(), out choice5);
                            if (isSuccesful8)
                            {
                                if (choice5 == 0)
                                {
                                    Menus.ContactMenu(loggedInUser);
                                }
                                else if (choice5 == 2)
                                {
                                label4:
                                    System.Console.Write("Enter the contacts' phone number: ");
                                    var phoneNo = Console.ReadLine();
                                    var isSuccesful2 = long.TryParse(phoneNo, out long phoneNumber);
                                    if (isSuccesful2)
                                    {
                                        if (phoneNo.Length != 11)
                                        {
                                            System.Console.WriteLine("Phone number must have 11 digits");
                                            goto label4;
                                        }
                                        else
                                        {
                                            ContactDetails details = new ContactDetails(name, phoneNo, loggedInUser.PhoneNumber);
                                            contacts.Add(details);
                                            System.Console.WriteLine("Contact added succesfully");
                                            RefreshFile();
                                            Menus.ContactMenu(loggedInUser);
                                        }
                                    }
                                }
                                else if (choice5 == 1)
                                {
                                    goto labelling;
                                }
                                else
                                {
                                    System.Console.WriteLine("Wrong input. Please try again");
                                    goto label10;
                                }
                            }
                            else
                            {
                                System.Console.WriteLine("Wrong input. Please try again");
                                goto label10;
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Contact found");
                            System.Console.WriteLine(search);
                        labels:
                            System.Console.WriteLine("Select what to do with the contact\n " +
                                                        "1. \t Update contact\n" +
                                                        "2. \t Delete contact\n" +
                                                        "0. \t Back to Menu");
                            int choices;
                            var isSuccessful7 = int.TryParse(Console.ReadLine(), out choices);
                            if (isSuccessful7)
                            {
                                if (choices == 1)
                                {
                                    UpdateContact(loggedInUser);
                                }
                                else if (choices == 2)
                                {
                                    DeleteContact(loggedInUser);
                                }
                                else if (choices == 0)
                                {
                                    Menus.ContactMenu(loggedInUser);
                                }
                                else
                                {
                                    System.Console.WriteLine("Wrong input. Please try again");
                                    goto labels;
                                }
                            }
                            else
                            {
                                System.Console.WriteLine("Wrong input. Please try again");
                                goto labels;
                            }
                        }
                    }
                    else if (choice4 == 2)
                    {
                    label8:
                        System.Console.WriteLine("Please select the phone number to search");
                        var phoneNo = Console.ReadLine();
                        var isSuccesful7 = long.TryParse(phoneNo, out long phoneNumber);
                        if (isSuccesful7)
                        {
                            var search2 = GetContactDetailsByPhoneNumber(phoneNo);
                            if (search2 == null)
                            {
                            label10:
                                System.Console.WriteLine("Contact not found. Do you want to:\n" +
                                                        "1. Search for another contact\n" +
                                                        "2. Add that contact\n" +
                                                        "0. Back to Menu");
                                int choice;
                                var isSuccesful8 = int.TryParse(Console.ReadLine(), out choice);
                                if (isSuccesful8)
                                {
                                    if (choice == 0)
                                    {
                                        Menus.ContactMenu(loggedInUser);
                                    }
                                    else if (choice == 2)
                                    {
                                        System.Console.WriteLine("Please enter the name");
                                        string name = Console.ReadLine();
                                        ContactDetails details = new ContactDetails(name, phoneNo, loggedInUser.PhoneNumber);
                                        contacts.Add(details);
                                        RefreshFile();
                                        System.Console.WriteLine("Contact added succesfully");
                                        Menus.ContactMenu(loggedInUser);
                                    }
                                    else if (choice == 1)
                                    {
                                        goto labelling;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Wrong input. Please try again");
                                        goto label10;
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine("Wrong input. Please try again");
                                    goto label10;
                                }
                            }
                            else
                            {
                                System.Console.WriteLine("Contact found");
                                System.Console.WriteLine(search2);
                            label9:
                                System.Console.WriteLine("Select what to do with the contact\n " +
                                                        "1. \t Update contact\n" +
                                                        "2. \t Delete contact\n" +
                                                        "0. \t Back to Menu");
                                int choice5;
                                var isSuccessful7 = int.TryParse(Console.ReadLine(), out choice5);
                                if (isSuccessful7)
                                {
                                    if (choice5 == 1)
                                    {
                                        UpdateContact(loggedInUser);
                                    }
                                    else if (choice5 == 2)
                                    {
                                        DeleteContact(loggedInUser);
                                    }
                                    else if (choice5 == 0)
                                    {
                                        Menus.ContactMenu(loggedInUser);
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Wrong input. Please try again");
                                        goto label9;
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine("Wrong input. Please try again");
                                    goto label9;
                                }
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Wrong input. Please try again");
                            goto label8;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Wrong input. Please try again");
                        goto labelling;
                    }
                }
            }
        }
        public void UpdateContact(User loggedInUser)
        {
        label11:
            System.Console.WriteLine("Do you want to update:\n" +
                                     "1. the name in your contact\n" +
                                     "2. the phone number in your contact");
            int choice6;
            var isSuccessful9 = int.TryParse(Console.ReadLine(), out choice6);
            if (isSuccessful9)
            {
                if (choice6 == 1)
                {
                label12:
                    System.Console.Write("Enter the name to update: ");
                    string name = Console.ReadLine();
                    var contact = GetContactDetailsByName(name);
                    if (contact == null)
                    {
                        System.Console.WriteLine($"The name {name} does not exist in your contact. Please try again");
                        goto label12;
                    }
                    else
                    {
                        System.Console.Write("Enter the name to change to: ");
                        string newName = Console.ReadLine();
                        contact.Name = newName;
                        RefreshFile();
                    label13:
                        System.Console.WriteLine("Contact updated\nDo you want to update another contact by name\n1. Yes\n2. No");
                        int choice7;
                        var isSuccesful13 = int.TryParse(Console.ReadLine(), out choice7);
                        if (isSuccesful13)
                        {
                            if (choice7 == 1)
                            {
                                goto label12;
                            }
                            else if (choice7 == 2)
                            {
                                Menus.ContactMenu(loggedInUser);
                            }
                            else
                            {
                                System.Console.WriteLine("Wrong input. Please try again");
                                goto label13;
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Wrong input. Please try again");
                            goto label13;
                        }
                    }
                }
                else if (choice6 == 2)
                {
                label12:
                    System.Console.Write("Enter the phone number to update: ");
                    var phoneNo = Console.ReadLine();
                    var isSuccesful10 = long.TryParse(phoneNo, out long phoneNumber);
                    if (isSuccesful10)
                    {
                        var contact = GetContactDetailsByPhoneNumber(phoneNo);
                        if (contact == null)
                        {
                            System.Console.WriteLine($"The phone number {phoneNo} does not exist.Please try again");
                            goto label12;
                        }
                        else
                        {
                        label13:
                            System.Console.Write("Enter the phone number to change to: ");
                            var newPhoneNo = Console.ReadLine();
                            var isSuccesful11 = long.TryParse(newPhoneNo, out long phone);
                            if (isSuccesful11)
                            {
                                contact.PhoneNumber = newPhoneNo;
                                RefreshFile();
                            label14:
                                System.Console.WriteLine("Contact updated\nDo you want to update another contact by phone number\n1. Yes\n2. No");
                                int choice8;
                                var isSuccesful13 = int.TryParse(Console.ReadLine(), out choice8);
                                if (isSuccesful13)
                                {
                                    if (choice8 == 1)
                                    {
                                        goto label12;
                                    }
                                    else if (choice8 == 2)
                                    {
                                        Menus.ContactMenu(loggedInUser);
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Wrong input. Please try again");
                                        goto label14;
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine("Wrong input. Please try again");
                                    goto label14;
                                }
                            }
                            else
                            {
                                System.Console.WriteLine("Wrong input. Please try again.");
                                goto label13;
                            }
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Wrong input. Please try again");
                        goto label12;
                    }
                }
                else
                {
                    System.Console.WriteLine("Wrong input. Please try again");
                    goto label11;
                }
            }
            else
            {
                System.Console.WriteLine("Wrong input. Please try again");
                goto label11;
            }
        }
        public void DeleteContact(User loggedInUser)
        {
            if (contacts.Count == 0)
            {
            label10:
                System.Console.WriteLine("You have no contacts to delete. Do you wish to add contacts?\n1. Yes \n2. No");
                int choice;
                var isSuccessful = int.TryParse(Console.ReadLine(), out choice);
                if (isSuccessful)
                {
                    if (choice == 2)
                    {
                        Menus.ContactMenu(loggedInUser);
                    }
                    else if (choice == 1)
                    {
                        AddContact(loggedInUser);
                    }
                    else
                    {
                        System.Console.WriteLine("Wrong input. Please try again");
                        goto label10;
                    }
                }
                else
                {
                    System.Console.WriteLine("Wrong input. Please try again");
                    goto label10;
                }
            }
            else
            {
            label11:
                System.Console.WriteLine("Please select the phone number to delete");
                var phoneNo = Console.ReadLine();
                var isSuccesful1 = long.TryParse(phoneNo, out long phoneNumber);
                if (isSuccesful1)
                {
                    var delete = GetContactDetailsByPhoneNumber(phoneNo);
                    if (delete == null)
                    {
                        System.Console.WriteLine("Sorry, contact not found. Please try again");
                        goto label11;
                    }
                    else
                    {
                        contacts.Remove(delete);
                        RefreshFile();
                        System.Console.WriteLine("Contact deleted");
                    label12:
                        System.Console.WriteLine("Do you want delete another contact\n1. \t Yes\n2. \t No");
                        int choice;
                        var isSuccesful2 = int.TryParse(Console.ReadLine(), out choice);
                        if (isSuccesful2)
                        {
                            if (choice == 2)
                            {
                                Menus.ContactMenu(loggedInUser);
                            }
                            else if (choice == 1)
                            {
                                goto label11;
                            }
                            else
                            {
                                System.Console.WriteLine("Wrong input. Please try again");
                                goto label12;
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Wrong input. Please try again");
                            goto label12;
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("Wrong input. Please try again");
                    goto label11;
                }
            }
        }
        public void DisplayContactDetails(User loggedInUser)
        {
            if (contacts.Count == 0)
            {
            label6:
                System.Console.WriteLine("You have no contacts. Do you wish to add contacts?\n1. Yes 2. No");
                int choice2;
                var isSuccessful4 = int.TryParse(Console.ReadLine(), out choice2);
                if (isSuccessful4)
                {
                    if (choice2 == 2)
                    {
                        Menus.ContactMenu(loggedInUser);
                    }
                    else if (choice2 == 1)
                    {
                        AddContact(loggedInUser);
                    }
                    else
                    {
                        System.Console.WriteLine("Wrong input. Please try again");
                        goto label6;
                    }
                }
                else
                {
                    System.Console.WriteLine("Wrong input. Please try again");
                    goto label6;
                }
            }
            else
            {
                System.Console.WriteLine("Your contacts are: ");
                foreach (var item in contacts)
                {
                    if (item.CreatedBy == item.PhoneNumber)
                    {
                        System.Console.WriteLine(item.Name + item.PhoneNumber);
                    }
                }
                Menus.ContactMenu(loggedInUser);
            }
        }
        public void RefreshFile()
        {
            TextWriter write = new StreamWriter("Phonebook.txt", true);
            foreach (var contact in contacts)
            {
                write.WriteLine(JsonSerializer.Serialize(contact));
                // write.WriteLine(contact.ToString());
            }
            write.Flush();
            write.Close();
        }
        public ContactDetails GetContactDetailsByPhoneNumber(string phoneNumber)
        {
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].PhoneNumber == phoneNumber)
                {
                    return contacts[i];
                }
            }
            return null;
        }
        public ContactDetails GetContactDetailsByName(string name)
        {
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Name.ToLower() == name.ToLower())
                {
                    return contacts[i];
                }
            }
            return null;
        }
    }
}