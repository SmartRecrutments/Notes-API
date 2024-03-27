namespace Data
{
    public interface INoteRepository
    {
        public Task<List<Note>> GetAll(int pageSize, int page);
        public Task Create(List<Note> notes);
        public Task<Note> GetById(int id);
        public Task<List<Note>> GetByIds(List<int> ids);
        public Task Update(Note updateModel);
        public Task DeleteById(int id);
    }
}