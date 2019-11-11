using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SchedulerService.Core.DTO;

namespace SchedulerService.Infrastructure.Clients
{
    //https://github.com/devmentors/Pacco.Services.Pricing/blob/master/src/Pacco.Services.Pricing.Api/Services/Clients/CustomersServiceClient.cs
    internal sealed class NoteServiceClient : INoteServiceClient
    {
        private readonly HttpClient _httpclient;
        private string _url;

        public NoteServiceClient(HttpClient httpClient)
        {
            _httpclient = httpClient;
            _url = "etwa";
        }
        public async Task<NoteDTO> GetAsync(Guid id)
        {
           return await _httpclient.GetJsonAsync<NoteDTO>($"{_url}/notes/{id}");           
        }

    }
}
