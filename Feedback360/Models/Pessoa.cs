using System;

namespace Feedback360.Models
{
    public class Pessoa
    {
        public Pessoa()
        {
            PessoaId = Guid.NewGuid();
        }
        public Guid PessoaId { get; set; }
        public string Nome { get; set; }
    }
}