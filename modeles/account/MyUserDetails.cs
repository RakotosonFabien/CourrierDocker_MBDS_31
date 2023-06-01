using CourrierDocker_MBDS_31.modeles.structure;
using System.ComponentModel.DataAnnotations;

namespace CourrierDocker_MBDS_31.modeles.account
{
    public class MyUserDetails
    {
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public int UserDepartementID { get; set; }
        public int UserPosteID { get; set; }
        public string? UserPosteVal { get; set; }
        public string? UserDepartementVal { get; set; }
    }
}
