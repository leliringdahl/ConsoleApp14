using ConsoleApp14.Models;
using ConsoleApp14.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14.Services
{
    public class Menu
    {
        private List<Contact> contacts = new List<Contact>();
        private FileService file = new FileService();

        public string FilePath { get; set; } = string.Empty;

      

 
/*

       public PopulateContactList()
        {
            var items = JsonConvert.DeserializeObject<List<Contact>>(fileService.Read());
            if (items != null)
            {
                items = contacts;
            }
            else
            {

            }
        } 

        public PopulateContactList();          // funkar inte??
        */
        public void MainMenu() 
        {

            JsonConvert.DeserializeObject<List<Contact>>(file.Read(FilePath));
            Console.Clear();
            Console.WriteLine("Välkommen till Adressboken! vänligen välj ett av följande alternativ:");
            Console.WriteLine("1. Lägg till kontakt.");
            Console.WriteLine("2. Visa specifik kontakt.");
            Console.WriteLine("3. Visa alla kontakter.");
            Console.WriteLine("4. Ta bort en kontakt.");

            int option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                AddContact();
            }
            else if (option == 2)
            {
                ShowSpecificContact();
                
            }
            else if (option == 3)
            {
                ListContacts();
            }
            else if (option == 4)
            {
                RemoveContact();
            }
            else
            {
                Console.WriteLine("något gick fel, vänligen försök igen. tryck på valfri knapp för att återgå till menyn.");
                Console.ReadKey();
                return;
            }
        }
        private void AddContact()
        {
            Console.Clear();
            Console.WriteLine("Lägg till ny kontakt.");
            var contact = new Contact();

            Console.Write("Förnamn: ");
            contact.FirstName = Console.ReadLine();

            Console.WriteLine("Efternamn: ");
            contact.LastName = Console.ReadLine();

            Console.WriteLine("Email: ");
            contact.Email = Console.ReadLine();

            Console.WriteLine("Telefonnummer: ");
            contact.PhoneNumber = Console.ReadLine();

            Console.WriteLine("Gatuadress: ");
            contact.StreetName = Console.ReadLine();

            Console.WriteLine("Postnummer: ");
            contact.PostalCode = Console.ReadLine();

            Console.WriteLine("Stad: ");
            contact.City = Console.ReadLine();

            contacts.Add(contact);

            file.Save(FilePath, JsonConvert.SerializeObject(new Contact()));
            Console.Clear();
            Console.WriteLine("Kontakt tillagd!");
            Console.ReadKey();

        }

        private void ShowSpecificContact()
        {
            Console.Clear();
            Console.WriteLine("skriv efternamnet på kontakten du vill visa.");
            string lastName = Console.ReadLine();
            Contact contact = contacts.FirstOrDefault(x => x.FirstName.ToLower() == lastName.ToLower() && x.LastName.ToLower() == lastName.ToLower());

            if (contact != null)
            {
                Console.Clear();
                Console.WriteLine("Förnamn: " + contact.FirstName);
                Console.WriteLine("Efternamn: " + contact.LastName);
                Console.WriteLine("Email: " + contact.Email);
                Console.WriteLine("Telefonnummer: " + contact.PhoneNumber);
                Console.WriteLine("Gatuadress: " + contact.StreetName);
                Console.WriteLine("Postnummer: " + contact.PostalCode);
                Console.WriteLine("Stad: " + contact.City);

                Console.WriteLine("\nTryck på valfri knapp för att återgå till menyn.");
                Console.ReadKey();
                return;


            }

            else
            {
                Console.WriteLine("Kontakten existerar inte. tryck på valfri knapp för att återgå till menyn.");
                Console.ReadKey();
                return;
            }



        }

        private void ShowContact(Contact contact)
        {
            Console.WriteLine("Förnamn: " + contact.FirstName);
            Console.WriteLine("Efternamn: " + contact.LastName);
            Console.WriteLine("Email: " + contact.Email);
            Console.WriteLine("---------------------");

        }
        

        private void ListContacts()
        {
            Console.Clear();

            try
            {
                var ppl = JsonConvert.DeserializeObject<List<Contact>>(file.Read(FilePath));
                if (ppl != null)
                {
                    contacts = ppl;
                }
            }
            catch { }

            Console.WriteLine("Här är alla kontakter i Adressboken: ");

            foreach (Contact contact in contacts)
            {
                ShowContact(contact);
            }

            Console.ReadKey();
            return;
        }


        private void RemoveContact()
        {
            Console.Clear();
            Console.WriteLine("skriv förnamn på kontakten du vill ta bort:");
            string firstName = Console.ReadLine();
            Console.WriteLine("skriv efternamn på kontakten du vill ta bort:");
            string lastName = Console.ReadLine();
            Contact contact = contacts.FirstOrDefault(x => x.FirstName.ToLower() == firstName.ToLower() && x.LastName.ToLower() == lastName.ToLower());

            if (contact != null)
            {
                Console.Clear();
                Console.WriteLine("Är du säker på att du vill ta bort den här kontakten från din adressbok? (Y/N)");
                ShowContact(contact);
            }


            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                contacts.Remove(contact);
                Console.Clear();
                Console.WriteLine("Kontakt borttagen. Tryck på valfri knapp för att återgå till menyn.");
                Console.ReadKey();
                return;
            }

            if (Console.ReadKey().Key == ConsoleKey.N)
            {
                contacts.Remove(contact);
                Console.Clear();
                Console.WriteLine("Kontakt ej borttagen. Tryck på valfri knapp för att återgå till menyn.");
                Console.ReadKey();
                return;
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Kontakt inte hittad");
            }
        }




    }
}
