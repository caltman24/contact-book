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
GetContactById("8c87e8b8-e69e-4b34-9529-e5582770b239");
UpdateContactsFirstName("Corbraino", "8c87e8b8-e69e-4b34-9529-e5582770b239");
GetAllContacts();


Console.WriteLine("Done Processing Mongo");

Console.ReadLine();

// Timestamp: 38:45
void UpdateContactsFirstName(string firstName, string id)
{
    Guid guid = new(id);
    var contact = db.LoadRecordById<ContactModel>(tableName, guid);
    contact.FirstName = firstName;
    contact.Id = guid;

    db.UpsertRecord(tableName, guid, contact);
}

void GetAllContacts()
{
    var contacts = db.LoadRecords<ContactModel>(tableName);

    contacts.ForEach(c =>
    {
        Console.WriteLine($"{c.FirstName} {c.LastName}");
    });
}

void GetContactById(string id)
{
    Guid guid = new(id);
    var contact = db.LoadRecordById<ContactModel>(tableName, guid);
    if (contact is not null)
    {
        Console.WriteLine($"Contact {contact.Id}: {contact.FirstName} {contact.LastName}");
    } else
    {
        Console.WriteLine($"No contact found with id of {id}");
    }
    

}

void CreateContact(ContactModel contact, string table = tableName)
{
    db.UpsertRecord(table, contact.Id, contact);
    Console.WriteLine($"Contact Created {contact.Id}: {contact.FirstName} {contact.LastName}");
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