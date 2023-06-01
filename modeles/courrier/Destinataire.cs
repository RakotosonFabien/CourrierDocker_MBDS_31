
using CourrierDocker_MBDS_31.modeles.structure;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourrierDocker_MBDS_31.modeles.courrier
{
    public class Destinataire
    {
        public int Id { get; set; }
        public DateTime? DateTransmission { get; set; }
        public DateTime? DateRecepSec { get; set; }
        public DateTime? DateRecepDr { get; set; }
        public DateTime? DateRecepLiv { get; set; }
        [ForeignKey("DepDestID")]
        public Departement DepDest { get; set;}
        public int DepDestID { get; set; }
        [ForeignKey("CourrierID")]
        public Courrier Courrier { get; set;}
        public int CourrierID { get; set; }
        public Destinataire() { }

        public Destinataire(DateTime? dateTransmission, int depDestID, int courrierID)
        {
            DateTransmission = dateTransmission;
            DepDestID = depDestID;
            CourrierID = courrierID;
        }
    }
}
