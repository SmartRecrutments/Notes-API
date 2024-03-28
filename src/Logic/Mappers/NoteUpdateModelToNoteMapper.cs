using Data;
using Logic.Interfaces;
using Logic.Models;

namespace Logic.Mappers
{
    public class NoteUpdateModelToNoteMapper : IMapper<NoteUpdateModel, Note>
    {
        public Note Map(NoteUpdateModel model)
        {
            return new Note
            {
                Title = model.Title,
                Content = model.Content,
                CreatedByUser = model.CreatedBy,
                Id = model.Id
            };
        }
    }
}