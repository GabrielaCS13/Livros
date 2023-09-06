using System.ComponentModel.DataAnnotations;

namespace Livro.Models
{
    public class livro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o campo do Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o campo do Autor")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Digite o campo da descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Digite o Genero")]
        public string Genero { get; set; }

    }
}

