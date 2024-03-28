using Data.Models;
using Logic.Models;

namespace Logic.Interfaces
{
    public interface INoteService
    {
        public Task<List<Note>> GetAllUserNotes(int pageSize, int page, int userId);
        public Task Create(List<NoteModel> noteModel);
        public Task<Note> GetById(int id, int userId);
        public Task<Note> GetById(int id);
        public Task Update(NoteUpdateModel updateModel);
        public Task Delete(int id);
    }
}