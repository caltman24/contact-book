using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLibrary.Models;

public class ContactModel
{
    [BsonId]
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<EmailAddressModel> EmailAddresses { get; set; } = new();
    public List<PhoneNumberModel> PhoneNumbers { get; set; } = new();
}
