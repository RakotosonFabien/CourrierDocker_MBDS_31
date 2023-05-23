using System.ComponentModel.DataAnnotations.Schema;

namespace CourrierDocker_MBDS_31.modeles.courrier
{
    public class FichierJoint
    {
        public int Id { get; set; }
        public String Path { get; set; }
        [Column("id_courrier")]
        public Courrier? Courrier { get; set; }
    }
}
