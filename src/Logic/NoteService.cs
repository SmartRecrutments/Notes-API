using Data.Interfaces;
using Data.Models;
using Logic.Interfaces;
using Logic.Models;

namespace Logic
{
    public class NoteService(
        INoteRepository noteRepository,
        IMapper<NoteModel, Note> noteModelToNoteMapper,
        IMapper<NoteUpdateModel, Note> noteUpdateModelToNoteMapper) : INoteService
    {
        public async Task Create(List<NoteModel> notes)
        {
            await noteRepository.Create(notes.Select(noteModelToNoteMapper.Map).ToList());
        }

        public async Task Delete(int id, int userId)
        {
            var noteToDelete = await GetById(id, userId);

            await noteRepository.DeleteById(noteToDelete.CreatedByUser);
        }

        public async Task<List<Note>> GetAllUserNotes(int pageSize, int page, int userId)
        {
            return await noteRepository.GetAllByUserId(pageSize, page, userId);
        }

        public async Task<Note> GetById(int id)
        {
            return await noteRepository.GetById(id);
        }

        public async Task<Note> GetById(int id, int userId)
        {
            return await noteRepository.GetById(id, userId);
        }

        public async Task Update(NoteUpdateModel updateModel)
        {
            await noteRepository.Update(noteUpdateModelToNoteMapper.Map(updateModel));
        }
    }
}