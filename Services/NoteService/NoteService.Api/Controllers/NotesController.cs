using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteService.Application.CQRS.Commands;
using NoteService.Application.CQRS.Commands.CreateNote;
using NoteService.Application.CQRS.Commands.DeleteNote;
using NoteService.Application.CQRS.Commands.UpdateNote;
using NoteService.Application.CQRS.Queries;
using NoteService.Application.CQRS.Queries.GetNoteById;
using NoteService.Application.CQRS.Queries.GetNotes;

namespace NoteService.Api.Controllers
{
    [Route("api/notes")]
    [Produces("application/json")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotesController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        //[ProducesResponseType(typeof(User), 201)]
        //[ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] CreateNoteDto resource)
        {
            var note = await _mediator.Send(new CreateNoteCommand() { Note = resource });
            return Created($"/api/notes/{note.NoteId}", note);
        }

        // PUT: api/Notes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] UpdateNoteDto resource)
        {
            var note = await _mediator.Send(new UpdateNoteCommand() { Note = resource });
            return Ok(note);
        }

        //  GET: api/Notes
        [HttpGet]
        public async Task<List<Application.CQRS.Queries.Dtos.NoteDto>> Get()
        {
            var notes = await _mediator.Send(new GetNotesQuery());
            return notes.ToList();
        }

        // GET: api/Notes/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Application.CQRS.Queries.Dtos.NoteDto> Get(Guid id)
        {
            var note = await _mediator.Send(new GetNoteByIdQuery() { NoteId = id });
            return note;
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var note = await _mediator.Send(new DeleteNoteCommand() { NoteId = id });
            return Ok();
        }
    }
}
