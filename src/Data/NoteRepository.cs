using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class NoteRepository : INoteRepository
    {
        public async Task Create(List<Note> notes)
        {
            using var context = new NotesContext();
            await context.Notes.AddRangeAsync(
            notes.Select(note =>
            {
                note.CreationDate = DateTime.Now;
                return note;
            }).ToList());
            await context.SaveChangesAsync();
        }
        public async Task<Note> GetById(int id)
        {
            using var context = new NotesContext();
            return await context.Notes.FirstAsync(n => n.Id == id);
        }

        public async Task<List<Note>> GetByIds(List<int> ids)
        {
            using var context = new NotesContext();
            return await context.Notes.Where(n => ids.Contains(n.Id)).ToListAsync();
        }

        public async Task DeleteById(int id)
        {
            using var context = new NotesContext();
            var note = await GetById(id);
            context.Notes.Attach(note);
            context.Notes.Remove(note);
            await context.SaveChangesAsync();
        }

        public async Task<List<Note>> GetAll(int pageSize, int page)
        {
            using var context = new NotesContext();
            return await context.Notes.Skip(page * pageSize).Take(pageSize).ToListAsync(); //TODO: spradzic lepsze rozwiazanie
        }

        public async Task Update(Note updateModel)
        {
            using var context = new NotesContext();
            var noteToUpdate = await context.Notes.FirstAsync(n => n.Id == updateModel.Id);

            noteToUpdate.Title = updateModel.Title;
            noteToUpdate.Content = updateModel.Content;
            noteToUpdate.UpdateTime = DateTime.Now;

            await context.SaveChangesAsync();
        }
    }
}