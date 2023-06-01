using CourrierDocker_MBDS_31.modeles.account;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourrierDocker_MBDS_31.modeles.courrier
{
    public class Commentaire
    {
        public int Id { get; set; }
        public String Contenu { get; set; }
        public DateTime DateCommentaire { get; set; }
        [ForeignKey("CourrierID")]
        public Courrier Courrier { get; set; }
        [ForeignKey("CommentateurID")]
        [Required]
        public MyUser? Commentateur { get; set; }
    }
}
