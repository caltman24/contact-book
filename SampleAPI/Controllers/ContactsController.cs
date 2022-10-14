using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly MongoDBDataAccess _db;
        private readonly IConfiguration _config;
        private readonly string tableName = "Contacts";

        public ContactsController(IConfiguration config)
        {
            _config = config;
            _db = new("demo", _config.GetConnectionString("Default"));
        }

        [HttpGet]
        public List<ContactModel> GetAll()
        {
           return _db.LoadRecords<ContactModel>(tableName);
        }
    }
}
