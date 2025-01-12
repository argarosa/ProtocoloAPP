using System.ComponentModel.DataAnnotations;

namespace ProtocoloApp.Models
{
    public class StatusProtocolo
    {
        public int IdStatus { get; set; }
        public string NomeStatus { get; set; }

        [StringLength(500)]
        public string Descricao { get; set; }

    }
}
