using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Notes_API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [Route("notes")]
        [HttpGet]
        public async Task<IActionResult> GetNotes(int pageSize, int page)
        {
            if (pageSize < 0 || pageSize < 0)
                return BadRequest("Page or page numer can't be negative");

            var notes = await _noteService.GetAllNotes(pageSize, page);

            return Ok(notes);
        }

        [Route("note")]
        [HttpGet]
        public async Task<IActionResult> GetNoteById(int id)
        {
            var note = await _noteService.GetById(id);

            return Ok(note);
        }

        [Route("notes")]
        [HttpPost]
        public async Task<IActionResult> CreateNotes(List<NoteModel> notes)
        {
            await _noteService.Create(notes);

            return Ok();   
        }

        [Route("note")]
        [HttpPut]
        public async Task<IActionResult> Update(NoteModel updateModel)
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