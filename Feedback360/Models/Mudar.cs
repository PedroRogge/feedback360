using System;
using System.Collections.Generic;
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
        public string Observacao { get; set; }
        public Guid PessoaId { get; set; }

    }
}
