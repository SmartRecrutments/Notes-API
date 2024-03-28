using Data.Models;
using Logic.Interfaces;
using Logic.Models;

namespace Logic.Mappers
{
    public class NoteModelToNoteMapper : IMapper<NoteModel, Note>
    {
        public Note Map(NoteModel model)
        {
            return new Note
            {
                Title = model.Title,
                Content = model.Content,
                CreatedByUser = model.CreatedBy
            };
        }
    }
}