using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feedback360.Models
{
    public class Melhorar
    {
        public Melhorar()
        {
            MelhorarId = Guid.NewGuid();
        }

        public Guid MelhorarId { get; set; }
        public string Observacao { get; set; }
        public Guid PessoaId { get; set; }

    }
}
