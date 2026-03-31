using System;

namespace StudyNotes.Models
{
    public class Note
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string Categoria { get; set; } = string.Empty;

        public string Conteudo { get; set; } = string.Empty;

        public DateTime DataCriacao { get; set; }
    }
}