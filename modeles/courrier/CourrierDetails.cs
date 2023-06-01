using CourrierDocker_MBDS_31.Data;
using CourrierDocker_MBDS_31.modeles.account;
using Microsoft.Identity.Client;
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
        public string ExpediteurVal { get; set; }
        public string DateRecepSec { get; set; } 
        public string DateRecepDr { get; set; } 
        public string DateRecepLiv { get; set; } 
        public CourrierDetails() { }
        public string[] GetStatus()
        {
            string[] destinataires = DestinatairesVal.Split(",");
            string[] dateRecepSec = DateRecepSec.Split(",");
            string[] dateRecepDr = DateRecepDr.Split(",");
            string[] dateRecepLiv = DateRecepLiv.Split(",");
            string[] tousStatus = new string[destinataires.Length];
            for (int i = 0; i < destinataires.Length; i++) {
                if (dateRecepDr[i].CompareTo("NULL") != 0)
                {
                    tousStatus[i] = destinataires[i] + " - Reçu par le directeur";
                }
                else if (dateRecepSec[i].CompareTo("NULL") != 0)
                {
                    tousStatus[i] = destinataires[i] + " - Reçu par le sécrétaire";
                }
                else if(dateRecepLiv[i].CompareTo("NULL") != 0)
                {
                    tousStatus[i] = destinataires[i] + " - Livraison conclu";
                }
                else {
                    tousStatus[i] = destinataires[i] + " - Courrier non reçu!";
                }
            }
            return tousStatus;
        }
        public string[] GetStatusColor()
        {
            string[] destinataires = DestinatairesVal.Split(",");
            string[] dateRecepSec = DateRecepSec.Split(",");
            string[] dateRecepDr = DateRecepDr.Split(",");
            string[] dateRecepLiv = DateRecepLiv.Split(",");
            string[] tousStatus = new string[destinataires.Length];
            for (int i = 0; i < destinataires.Length; i++)
            {
                if (dateRecepDr[i].CompareTo("NULL") != 0)
                {
                    tousStatus[i] = "text-success";
                }
                else if (dateRecepSec[i].CompareTo("NULL") != 0)
                {
                    tousStatus[i] = "text-primary";
                }
                else if (dateRecepLiv[i].CompareTo("NULL") != 0)
                {
                    tousStatus[i] = "text-info";
                }
                else
                {
                    tousStatus[i] = "text-danger";
                }
            }
            return tousStatus;
        }
        public bool CourrierValidable(CourrierDocker_MBDS_31Context _context, MyUser myUser)
        {
            Destinataire destinataire = _context.Destinataire.FirstOrDefault(
                d=> d.CourrierID == this.Id && d.DepDestID == myUser.UserDepartementID
            );
            if(destinataire != null)
            {
                if(myUser.UserPosteID == Donnees.DirecteurID)
                {
                    return destinataire.DateRecepDr == null;
                }
                if (myUser.UserPosteID == Donnees.SecretaireID)
                {
                    return destinataire.DateRecepSec == null;
                }
                if (myUser.UserPosteID == Donnees.ReceptionnisteID)
                {
                    return destinataire.DateRecepLiv == null;
                }
            }
            return false;
        }
    }
}
