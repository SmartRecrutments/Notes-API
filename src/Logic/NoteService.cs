using Data;
using Logic.Interfaces;
using Logic.Models;

namespace Logic
{
    public class NoteService(
        INoteRepository noteRepository,
        IMapper<NoteModel, Note> noteModelToNoteMapper) : INoteService
    {
        private readonly IMapper<NoteModel, Note> _noteModelToNoteMapper = noteModelToNoteMapper;
        private readonly INoteRepository _noteRepository = noteRepository;

        public async Task Create(List<NoteModel> notes)
        {
            await _noteRepository.Create(notes.Select(_noteModelToNoteMapper.Map).ToList());
        }

        public async Task Delete(int id)
        {
            await _noteRepository.DeleteById(id);
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

        public async Task Update(NoteUpdateModel updateModel)
        {
            var noteToUpdate = await _noteRepository.GetById(updateModel.Id);
            await _noteRepository.Update(noteToUpdate);
        }
    }
}