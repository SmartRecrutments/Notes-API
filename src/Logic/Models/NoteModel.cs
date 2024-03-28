using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Logic.Models
{
    public record NoteModel
    {
        [MinLength(1)]
        [MaxLength(1000)]
        public required string Content { get; set; }

        [MinLength(1)]
        [MaxLength(1000)]
        public required string Title { get; set; }

        [JsonIgnore]
        public int CreatedBy { get; set; }
    }
}