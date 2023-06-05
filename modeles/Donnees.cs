using CourrierDocker_MBDS_31.Data;
using CourrierDocker_MBDS_31.modeles.account;
using CourrierDocker_MBDS_31.modeles.courrier;
using CourrierDocker_MBDS_31.modeles.structure;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections;

namespace CourrierDocker_MBDS_31.modeles
{
    public class Donnees
    {
        public static List<Priorite> priorites = new List<Priorite>(){
            new Priorite(1, "Tres urgent", "Tres urgent"),
            new Priorite(2, "Normal", "Normal"),
            new Priorite(3, "Peut attendre", "Peut attendre")
        };
        public static List<Departement> departements = new List<Departement>() {
            new Departement(1, "Informatique"),
            new Departement(2, "Comptabilite"),
            new Departement(3, "Finance"),
            new Departement(4, "Communication")
        };
        public static List<Poste> postes = new List<Poste>() {
            new Poste(1, "Directeur"),
            new Poste(2, "Secretaire"),
            new Poste(3, "Coursier"),
            new Poste(4, "Receptionniste")
        };
        
        public static List<MyUser> myUsers = new List<MyUser>() {
            new MyUser("RAKOTOSON", "Fabien", new DateTime(2001, 1, 2), "rakotosonfabienmaminirina@gmail.com", MyUser.HashPassword("123456"), departements[0], postes[0])
        };
        public readonly static int DirecteurID = 1;
        public readonly static int SecretaireID = 2;
        public readonly static int CoursierID = 3;
        public readonly static int ReceptionnisteID = 4;
    }
}
