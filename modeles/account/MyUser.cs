using CourrierDocker_MBDS_31.modeles.structure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourrierDocker_MBDS_31.modeles.account
{
    public class MyUser
    {
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        [Column("id_departement")]
        public Departement? UserDepartement { get; set; }
        [Column("id_poste")]
        public Poste? UserPoste { get; set; }
    }
}
