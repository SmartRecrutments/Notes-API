using System.ComponentModel.DataAnnotations;

namespace Logic.Models
{
    public record NoteModel
    {
        public required int Id { get; set; }

        [MinLength(1)]
        [MaxLength(1000)]
        public required string Content { get; set; }

        [MinLength(1)]
        [MaxLength(1000)]
        public required string Title { get; set; }
    }
}