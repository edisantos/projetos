using System;

namespace DAL
{
    public class ProcessRepair
    {
        public int ProcessId { get; set; }
        public int EntradaId { get; set; }
        public DateTime DataRepair { get; set; }
        public DateTime HoraRepair { get; set; }
        public string CN { get; set; }
        public int ProductId { get; set; }
        public int Unitid { get; set; }
        public string UN { get; set; }
        public int InsProcessID { get; set; }
        public string Turno { get; set; }
        public int DefectCauseId { get; set; }
        public int LocationId { get; set; }
        public string LocationSmd { get; set; }
        public int DefectImputId { get; set; }
        public string lote { get; set; }
        public string PartNumber { get; set; }
        public int ActionId { get; set; }
        public string ActionRepainMan { get; set; }
        public int StatusId { get; set; }
        public string RepairMan { get; set; }
        public string Comment { get; set; }
        public string TecnicoResponsavel { get; set; }
        public string statusRepair { get; set; }
        public int EntradaSMDId { get; set; }
    }
    public class SeacherRepair
    {
        public int RepairMainId { get;set; }
        public DateTime data { get; set; }
        public string hora { get; set; }
        public DateTime DateRepair { get; set; }
        public string Modelo { get; set; }
        public string Model { get; set; }
        public string CodFirebird { get; set; }
        public int EntradaId { get; set; }
        public string Simtomas { get; set; }
        public string Sintomas { get; set; }
        public string Block { get; set; }
        public string Line { get; set; }
        public string Planta { get; set; }
        public string UN { get; set; }
        public string CN { get; set; }
        public string UserName { get; set; }
        public string ActionRepair { get; set; }
        public string StatusFinal { get; set; }
        public string StatusRepair { get; set; }
        public string StatusTerminate{get;set;}
        public string Descricao { get; set; }
    }
}
