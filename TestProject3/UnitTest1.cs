using NUnit.Framework;
using ConsoleApp14.Services;


// jag har byggt testet utefter f�rel�sningen men jag har inte kunnat testa min kod d� jag fortfarande har problem med att
// projektet inte dyker upp i min solution och n�r jag f�rs�ker l�gga till det ("add" -> "existing project") f�r jag upp errormeddelande om att SDK saknas
// aka samma problem jag st�tte p� (och fortfarande har) i .NET 6.

namespace TestProject3
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_Add_Contact_To_List()
        {
            ContactServices contactServices = new ContactServices();
            Contact contact = new Contact();

            contactServices.Contacts.Add(contact);

            Assert.AreEqual(1, contactServices.Contacts.Count);
        }

    }
}