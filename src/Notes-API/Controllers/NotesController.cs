using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Notes_API.Session;
using AuthorizeAttribute = Notes_API.Attributes.AuthorizeAttribute;

namespace Notes_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/")]
    public class NotesController(INoteService noteService, IUserSession userSession) : ControllerBase
    {
        private readonly User _currentUser = userSession.GetLoggedUser() ?? throw new NullReferenceException();

        [Route("notes")]
        [HttpGet]
        public async Task<IActionResult> GetNotes(int pageSize, int page)
        {
            if (pageSize is < 1 or < 1)
                return BadRequest("Page size or page number can't be less than zero");

            var notes = await noteService.GetAllUserNotes(pageSize, page, _currentUser.Id);

            return Ok(notes);
        }

        [Route("note")]
        [HttpGet]
        public async Task<IActionResult> GetNoteById(int id)
        {
            var note = await noteService.GetById(id, _currentUser.Id);

            return Ok(note);
        }

        [Route("notes")]
        [HttpPost]
        public async Task<IActionResult> CreateNotes(List<NoteModel> notes)
        {
            notes = notes.Select(note =>
            {
                note.CreatedBy = _currentUser.Id;
                return note;
            }).ToList();

            await noteService.Create(notes);

            return Ok();
        }

        [Route("note")]
        [HttpPut]
        public async Task<IActionResult> Update(NoteUpdateModel updateModel)
        {
            updateModel.UpdatedByUser = _currentUser.Id;
            await noteService.Update(updateModel);

            return Ok(await noteService.GetById(updateModel.Id));
        }

        [Route("note")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await noteService.Delete(Id);

            return NoContent();
        }
    }
}