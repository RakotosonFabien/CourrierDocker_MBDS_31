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
            new Priorite("Tres urgent", "Tres urgent"),
            new Priorite("Normal", "Normal"),
            new Priorite("Peut attendre", "Peut attendre")
        };
        public static List<Departement> departements = new List<Departement>() {
            new Departement("Informatique"),
            new Departement("Comptabilite"),
            new Departement("Finance"),
            new Departement("Communication")
        };
        public static List<Poste> postes = new List<Poste>() {
            new Poste("Directeur"),
            new Poste("Secretaire"),
            new Poste("Coursier"),
            new Poste("Receptionniste")
        };
        
        public static List<MyUser> myUsers = new List<MyUser>() {
            new MyUser("RAKOTOSON", "Fabien", new DateTime(2001, 1, 2), "rakotosonfabienmaminirina@gmail.com", "123456", departements[0], postes[0])
        };
    }
}
