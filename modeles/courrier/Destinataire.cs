
using CourrierDocker_MBDS_31.modeles.structure;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourrierDocker_MBDS_31.modeles.courrier
{
    public class Destinataire
    {
        public int Id { get; set; }
        public DateTime DateTransmission { get; set; }
        public DateTime DateRecepSec { get; set; }
        public DateTime DateRecepDr { get; set; }
        [Column("id_dep_dest")]
        public Departement? DepDest { get; set;}
        [Column("id_courrier")]
        public Courrier? Courrier { get; set;}

    }
}
