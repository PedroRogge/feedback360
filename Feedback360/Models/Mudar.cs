using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Feedback360.Models
{
    public class Mudar
    {
        public Mudar()
        {
            MudarId = Guid.NewGuid();
        }

        public Guid MudarId { get; set; }

        [Required(ErrorMessage = "O Observação é obrigatório")]
        [MinLength(5, ErrorMessage = "Observação deve ser maior ou igual a 5 caracteres")]
        public string Observacao { get; set; }

        [Required(ErrorMessage = "Campo pessoa é obrigatório")]
        public Guid PessoaId { get; set; }

    }
}
