using CourrierDocker_MBDS_31.modeles.account;
using System.Diagnostics.CodeAnalysis;

namespace CourrierDocker_MBDS_31.modeles.courrier
{
    public class CourrierDetails
    {
        public int Id { get; set; }
        public String Objet { get; set; }
        public DateTime DateCreation { get; set; }
        public String Contenu { get; set; }
        public MyUser? Expediteur { get; set; }
        public int ExpediteurID { get; set; }
        public MyUser Createur { get; set; }
        public int CreateurID { get; set; }
        public Priorite? Priorite { get; set; }
        public int PrioriteID { get; set; }
        [AllowNull]
        public string PrioriteVal { get; set; }
        [AllowNull]
        public string DestinatairesVal{ get; set; }
        public CourrierDetails() { }
    }
}
