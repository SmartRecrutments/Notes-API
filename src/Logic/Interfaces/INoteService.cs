using Data;
using Logic.Models;

namespace Logic.Interfaces
{
    public interface INoteService
    {
        public Task<List<Note>> GetAllNotes(int pageSize, int page);
        public Task Create(List<NoteModel> noteModel);
        public Task<Note> GetById(int Id);
        Task<List<Note>> GetByIds(List<int> ids);
        public Task Update(NoteModel updateModel);
        public Task Delete (int Id);
    }
}
