namespace CampanhaVacinacao.Models
{
    public class Relatorio
    {
        public int Id { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAplicacao { get; set; }
        public int QuantidadeTotalVacinados { get; set; }
        public Solicitante Solicitante { get; set; }
    }
}
