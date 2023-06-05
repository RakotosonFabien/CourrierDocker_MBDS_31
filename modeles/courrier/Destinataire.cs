
using CourrierDocker_MBDS_31.modeles.account;
using CourrierDocker_MBDS_31.modeles.structure;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

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
        [AllowNull]
        [ForeignKey("DestInterneID")]
        public Poste? DestInterne { get; set; }
        public int? DestInterneID { get; set; }
        public Destinataire() { }

        public Destinataire(DateTime? dateTransmission, int depDestID, int courrierID)
        {
            DateTransmission = dateTransmission;
            DepDestID = depDestID;
            CourrierID = courrierID;
        }
    }
}
