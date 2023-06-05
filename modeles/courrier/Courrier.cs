using CourrierDocker_MBDS_31.Data;
using CourrierDocker_MBDS_31.modeles.account;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourrierDocker_MBDS_31.modeles.courrier
{
    public class Courrier
    {
        public int Id { get; set; }
        public String Objet { get; set; }
        public DateTime DateCreation { get; set; }
        public String Contenu { get; set; }
        [ForeignKey("ExpediteurID")]
        public MyUser? Expediteur { get; set; }
        public int ExpediteurID { get; set; }
        [ForeignKey("CreateurID")]
        public MyUser? Createur { get; set; }
        public int CreateurID { get; set; }
        [ForeignKey("CoursierID")]
        public MyUser? Coursier { get; set; }
        public int CoursierID { get; set; }
        public Priorite? Priorite { get; set; }
        public int PrioriteID { get; set; }
        public string? CourrierRef { get; set; }
        
    }
}
