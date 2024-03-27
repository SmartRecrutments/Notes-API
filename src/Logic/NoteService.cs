using Data;
using Logic.Interfaces;
using Logic.Models;

namespace Logic
{
    public class NoteService(INoteRepository noteRepository, IMapper<NoteModel, Note> mapper) : INoteService
    {
        private readonly IMapper<NoteModel, Note> _mapper = mapper;
        private readonly INoteRepository _noteRepository = noteRepository;

        public async Task Create(List<NoteModel> notes)
        {
            await _noteRepository.Create(notes.Select(_mapper.Map).ToList());
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Note>> GetAllNotes(int pageSize, int page)
        {
            return await _noteRepository.GetAll(pageSize, page);
        }

        public async Task<Note> GetById(int id)
        {
            return await _noteRepository.GetById(id);
        }
        public async Task<List<Note>> GetByIds(List<int> ids)
        {
            return await _noteRepository.GetByIds(ids);
        }

        public async Task Update(NoteModel updateModel)
        {
            await _noteRepository.Update(_mapper.Map(updateModel));
        }
    }
}