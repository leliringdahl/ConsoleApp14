using ConsoleApp14.Helpers;
using ConsoleApp14.Models;
using ConsoleApp14.Services;
using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Schema;


namespace ConsoleApp14
{

    
    
    internal class Program
    {

        

        static void Main()
        {
            var menu = new Menu();

            menu.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";



            while (true)
            {
                Console.Clear();
                menu.MainMenu();
            }

            /*    switch (option)
                {
                    case 1: AddContact(contactServices); break;
                    case 2: ShowSpecificContact(contactServices); break;
                    case 3: ListAllContacts(contactServices); break;
                    case 4: RemoveContact(contactServices); break;
                    default: Console.WriteLine("något gick fel, vänligen försök igen."); break; 
                } */

        }
    }
}
