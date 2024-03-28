using Data.Models;

namespace Data.Interfaces
{
    public interface INoteRepository
    {
        public Task<List<Note>> GetAllByUserId(int pageSize, int page, int userId);
        public Task Create(List<Note> notes);
        public Task<Note> GetById(int id);
        public Task<Note> GetById(int id, int userId);
        public Task Update(Note updateModel);
        public Task DeleteById(int id);
    }
}