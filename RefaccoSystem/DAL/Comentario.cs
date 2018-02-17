using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Comentario
    {
        public DateTime Data { get; set; }
        public string Processo { get; set; }
        public string Comentarios { get; set; }
        public string status { get; set; }
    }
}
