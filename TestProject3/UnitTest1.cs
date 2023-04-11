using NUnit.Framework;
using ConsoleApp14.Services;


// jag har byggt testet utefter föreläsningen men jag har inte kunnat testa min kod då jag fortfarande har problem med att
// projektet inte dyker upp i min solution och när jag försöker lägga till det ("add" -> "existing project") får jag upp errormeddelande om att SDK saknas
// aka samma problem jag stötte på (och fortfarande har) i .NET 6.

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