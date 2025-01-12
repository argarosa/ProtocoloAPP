namespace ProtocoloApp.Models
{
    public class ProtocoloFollow
    {
        public int IdFollow { get; set; }
        public int ProtocoloId { get; set; }
        public DateTime DataAcao { get; set; }
        public string DescricaoAcao { get; set; }
        public Protocolo Protocolo { get; set; }

    }
}
