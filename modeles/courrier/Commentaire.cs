using CourrierDocker_MBDS_31.modeles.account;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourrierDocker_MBDS_31.modeles.courrier
{
    public class Commentaire
    {
        public int Id { get; set; }
        public String? contenu { get; set; }
        public DateTime? dateCommentaire { get; set; }
        public int IdCourrier { get; set; }
        [Column("id_courrier")]
        public Courrier? courrier { get; set; }
        [Column("id_commentateur")]
        public MyUser? commentateur { get; set; }
    }
}
