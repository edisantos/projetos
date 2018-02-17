using System;

namespace DAL
{
    public class Entrada
    {
        public int EntradaId { get; set; }

        public DateTime DataEntrada { get; set; }
        public DateTime HoraEntrada { get; set; }
        public string Usuario { get; set; }
        public string Serial { get; set; }
        public int ModeloId { get; set; }
        public int SintomasId { get; set; }
        public string Sintomas { get; set; }
        public int BlockId { get; set; }
        public int PlantaId { get; set; }
    }
}
