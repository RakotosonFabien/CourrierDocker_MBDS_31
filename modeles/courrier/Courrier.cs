using CourrierDocker_MBDS_31.modeles.account;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourrierDocker_MBDS_31.modeles.courrier
{
    public class Courrier
    {
        public int Id { get; set; }
        public String Objet { get; set; }
        public DateTime DateCreation { get; set; }
        public String Contenu { get; set; }
        [Column("id_expediteur")]
        public MyUser? Expediteur { get; set; }
        [Column("id_createur")]
        public MyUser Createur { get; set; }
        [Column("id_priorite")]
        public Priorite? Priorite { get; set; }
    }
}
