using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleCRM.Web.Services
{
    /// <summary>
    /// Simple code for connecting to the gateway, please don't adopt this :p
    /// </summary>
    public interface IService
    {
        Task<List<NoteModel>> GetNotes();
        Task<List<ContactModel>> GetContacts();

        Task AddNote(NoteModel item);
        Task AddContact(ContactModel item);
    }

    public class Service : IService
    {
        protected static HttpClient client;
        static Service()
        {
            client = new HttpClient();
        }

        private string domain;



        public Service(string domain)
        {
            this.domain = domain;

        }

        public Task AddContact(ContactModel item)
        {
            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(item));
            client.PostAsync(domain + "/api/v1/contact", content);

            return Task.CompletedTask;
        }

        public Task AddNote(NoteModel item)
        {
            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(item));
            client.PostAsync(domain + "/api/v1/notes", content);

            return Task.CompletedTask;
        }

        public async Task<List<ContactModel>> GetContacts()
        {
            var response = await client.GetAsync(domain + "/api/v1/contacts");
            return await ToJsonHelper<List<ContactModel>>(response);

        }

        public async Task<List<NoteModel>> GetNotes()
        {
            var response = await client.GetAsync(domain + "/api/v1/notes");
            return await ToJsonHelper<List<NoteModel>>(response);
        }

        public static async Task<T> ToJsonHelper<T>(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
    }


    public class NoteModel
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public DateTimeOffset On { get; set; }
    }

    public class ContactModel
    {
        public Guid ContactId { get; }

        public string FirstName { get; }
        public string LastName { get; }

        public string Phone { get; }

        public string Email { get; }

        public IEnumerable<Guid> Tags { get; }
        public IEnumerable<Guid> Notes { get; }
    }
}
