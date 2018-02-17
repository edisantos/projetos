using System;

namespace DAL
{
    public class Pesquisas
    {
        public int ProcessId { get; set; }
        public string CN { get; set; }
        public string UN { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime DataRepair { get; set; }
        public DateTime HoraRepair { get; set; }
        public string Modelo { get; set; }
        public string Produtos { get; set; }
        public string Unit { get; set; }
        public string InspProcess { get; set; }
        public string Turno { get; set; }
        public string Causa { get; set; }
        public string Location { get; set; }
        public string Defeito { get; set; }
        public string Lote { get; set; }
        public string PartNumber { get; set; }
        public string Action { get; set; }
        public string RepairMan { get; set; }
        public string Comment { get; set; }
        
    }
}
