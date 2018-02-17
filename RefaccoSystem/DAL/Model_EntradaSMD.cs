using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class Model_EntradaSMD
    {
        public int EntradaSMDId { get; set; }
        public int EntradaId { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string Turno { get; set; }
        public string CN { get; set; }
        public string Model { get; set; }
        public string Line { get; set; }
        public string UserName { get; set; }
        public string Falhas { get; set; }
        public string Comentario { get; set; }
        public int CodPai { get; set; }
        public string TecnicoSMD { get; set; }
    }
}
