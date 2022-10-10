using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Runtime.CompilerServices;

MongoDBDataAccess db = new("demo", GetConnectionString());
const string tableName = "Contacts";

ContactModel newPerson = new()
{
    FirstName = "Corbyn",
    LastName = "Altman",
};

newPerson.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "corbyn@corbynaltman.com" });
newPerson.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "2603416708" });

CreateContact(newPerson);
GetAllContacts();


Console.WriteLine("Done Processing Mongo");

Console.ReadLine();

void GetAllContacts()
{
    var contacts = db.LoadRecords<ContactModel>(tableName);

    contacts.ForEach(c =>
    {
        Console.WriteLine($"{c.FirstName} {c.LastName}");
    });
}

void CreateContact(ContactModel contact, string table = tableName)
{
    db.UpsertRecord(table, contact.Id, contact);
    Console.WriteLine($"Contact Created: {contact.FirstName} {contact.LastName}");
}

static string GetConnectionString(string connectionStringName = "Default")
{
    string output = "";

    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json");

    var config = builder.Build();

    output = config.GetConnectionString(connectionStringName);

    return output;
}