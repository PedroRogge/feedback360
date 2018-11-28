using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feedback360.Models
{
    public class Manter
    {
        public Manter()
        {
            ManterId = Guid.NewGuid();
        }

        public Guid ManterId { get; set; }
        public string Observacao { get; set; }
        public Guid PessoaId { get; set; }

    }
}
