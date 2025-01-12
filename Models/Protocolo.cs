namespace ProtocoloApp.Models
{
    public class Protocolo
    {
        public int IdProtocolo { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public int ClienteId { get; set; }
        public int ProtocoloStatusId { get; set; }
        public Cliente Cliente { get; set; }
        public StatusProtocolo StatusProtocolo { get; set; }

    }
}
