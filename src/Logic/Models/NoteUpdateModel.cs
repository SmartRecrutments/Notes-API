using System.Text.Json.Serialization;

namespace Logic.Models
{
    public record NoteUpdateModel : NoteModel
    {
        public required int Id { get; set; }

        [JsonIgnore]
        public int UpdatedByUser { get; set; }
    }
}