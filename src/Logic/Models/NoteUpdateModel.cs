namespace Logic.Models
{
    public record NoteUpdateModel : NoteModel
    {
        public required int Id { get; set; }
    }
}