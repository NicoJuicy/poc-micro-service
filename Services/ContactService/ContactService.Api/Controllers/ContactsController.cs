using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactService.Application.CQRS.Commands;
using ContactService.Application.CQRS.Queries;
using ContactService.Application.CQRS.Queries.GetContacts;
using ContactService.Application.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        //[ProducesResponseType(typeof(User), 201)]
        //[ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] ContactDTO resource)
        {
            var Contact = await _mediator.Send(new CreateContact() { Contact = resource });
            return Created($"/api/Contacts/{Contact.ContactId}", Contact);
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] DetailedContactDTO resource)
        {
            var Contact = await _mediator.Send(new UpdateContact() { Contact = resource });
            return Ok(Contact);
        }

        //  GET: api/Contacts
        [HttpGet]
        public async Task<List<DetailedContactDTO>> Get()
        {
            var Contacts = await _mediator.Send(new GetContactsQuery());
            return Contacts.ToList();
        }

        // GET: api/Contacts/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<DetailedContactDTO> Get(Guid id)
        {
            var Contact = await _mediator.Send(new GetContactByIdQuery() { ContactId = id });
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