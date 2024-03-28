using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using AuthorizeAttribute = Notes_API.Attributes.AuthorizeAttribute;

namespace Notes_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/")]
    public class NotesController(INoteService noteService) : ControllerBase
    {
        private readonly INoteService _noteService = noteService;

        [Route("notes")]
        [HttpGet]
        public async Task<IActionResult> GetNotes(int pageSize, int page)
        {
            if (pageSize < 1 || pageSize < 1)
                return BadRequest("Page size or page numer can't be less than zero");

            User? user = HttpContext.Items["User"] as User;

            var notes = await _noteService.GetAllUserNotes(pageSize, page, user.Id);

            return Ok(notes);
        }

        [Route("note")]
        [HttpGet]
        public async Task<IActionResult> GetNoteById(int id)
        {
            User? user = HttpContext.Items["User"] as User;

            var note = await _noteService.GetById(id, user.Id);

            return Ok(note);
        }

        [Route("notes")]
        [HttpPost]
        public async Task<IActionResult> CreateNotes(List<NoteModel> notes)
        {
            User? user = HttpContext.Items["User"] as User;

            notes = notes.Select(note =>
            {
                note.CreatedBy = user.Id;
                return note;
            }).ToList();

            await _noteService.Create(notes);

            return Ok();   //zwrocic stworzony objekt
        }

        [Route("note")]
        [HttpPut]
        public async Task<IActionResult> Update(NoteUpdateModel updateModel)
        {
            await _noteService.Update(updateModel);

            return Ok(await _noteService.GetById(updateModel.Id));    
        }

        [Route("note")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _noteService.Delete(Id);

            return NoContent();
        }
    }
}