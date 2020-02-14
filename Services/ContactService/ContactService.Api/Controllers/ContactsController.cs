using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactService.Application.CQRS.Commands;
using ContactService.Application.CQRS.Queries;
using ContactService.Application.CQRS;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ContactService.Api.Controllers
{
    [Route("api/contacts")]
    [Produces("application/json")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactsController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        [HttpPost]
        [ProducesResponseType(typeof(CreateContactResult), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] Application.CQRS.Commands.CreateContact resource)
        {
            var Contact = await _mediator.Send(new Application.CQRS.Commands.CreateContact(resource.ContactId, resource.FirstName, resource.LastName, resource.Phone, resource.Email));
            return Created($"/api/Contacts/{Contact.ContactId}", Contact);
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] Application.CQRS.Commands.UpdateContact resource)
        {
            var Contact = await _mediator.Send(new Application.CQRS.Commands.UpdateContact(resource.ContactId, resource.FirstName, resource.LastName, resource.Phone, resource.Email));
            return Ok(Contact);
        }

        //  GET: api/Contacts
        [HttpGet]
        [ProducesResponseType(typeof(List<ContactResult>), 200)]

        public async Task<List<Application.CQRS.Queries.ContactResult>> Get()
        {
            var Contacts = await _mediator.Send(new GetContacts());
            return Contacts.ToList();
        }

        // GET: api/Contacts/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ContactResult> Get(Guid id)
        {
            var Contact = await _mediator.Send(new GetContactById() { ContactId = id });
            return Contact;
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var Contact = await _mediator.Send(new DeleteContact() { ContactId = id });
            return Ok();
        }

    }
}