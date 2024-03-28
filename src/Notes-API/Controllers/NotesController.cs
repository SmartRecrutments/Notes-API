using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Notes_API.Controllers
{
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