using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feedback360.Models
{
    public class FeedbackCompleto
    {
        
            public Pessoa Pessoa { get; set; }
            public List<Melhorar> Melhorar { get; set; }
            public List<Mudar> Mudar { get; set; }
            public List<Manter> Manter { get; set; }
            public int MaxCount { get; set; }
        
    }
}