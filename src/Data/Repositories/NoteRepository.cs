using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class NoteRepository : INoteRepository
    {
        public async Task Create(List<Note> notes)
        {
            await using var context = new NotesContext();
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
            await using var context = new NotesContext();
            return await context.Notes.FirstAsync(n => n.Id == id);
        }

        public async Task<List<Note>> GetByIds(List<int> ids)
        {
            await using var context = new NotesContext();
            return await context.Notes.Where(n => ids.Contains(n.Id)).ToListAsync();
        }

        public async Task DeleteById(int id)
        {
            await using var context = new NotesContext();
            var note = await GetById(id);
            context.Notes.Attach(note);
            context.Notes.Remove(note);
            await context.SaveChangesAsync();
        }

        public async Task<List<Note>> GetAll(int pageSize, int page)
        {
            await using var context = new NotesContext();
            return await context.Notes.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<List<Note>> GetAllByUserId(int pageSize, int page, int id)
        {
            await using var context = new NotesContext();
            return await context.Notes.Where(n => n.CreatedByUser == id)
                .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task Update(Note updateModel)
        {
            await using var context = new NotesContext();
            var noteToUpdate = await context.Notes.FirstAsync(n => n.Id == updateModel.Id);

            noteToUpdate.Title = updateModel.Title;
            noteToUpdate.Content = updateModel.Content;
            noteToUpdate.UpdateTime = DateTime.Now;

            await context.SaveChangesAsync();
        }

        public async Task<Note> GetById(int id, int userId)
        {
            await using var context = new NotesContext();
            return await context.Notes.FirstAsync(n => n.Id == id && n.CreatedByUser == userId);
        }
    }
}