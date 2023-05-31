using CourrierDocker_MBDS_31.modeles.structure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BCrypt.Net;
using CourrierDocker_MBDS_31.Pages.user;
using CourrierDocker_MBDS_31.Data;
using CourrierDocker_MBDS_31.modeles.courrier;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
        public Departement? UserDepartement { get; set; }
        public int UserDepartementID { get; set; }
        public Poste? UserPoste { get; set; }
        public int UserPosteID { get; set; }
        public MyUser() { }
        public MyUser(string nom, string prenom, DateTime dateNaissance, string email, string password, Departement? userDepartement, Poste? userPoste)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Email = email;
            Password = password;
            UserDepartement = userDepartement;
            UserPoste = userPoste;
        }
        public static string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, "$2b$12$MAMYMANGIDYBETSYVANONAEEE");
            return hashedPassword;
        }
        public MyUser Login(CourrierDocker_MBDS_31Context _context) {
            String hashedPassword = MyUser.HashPassword(this.Password);
            var user =  _context.MyUser.FirstOrDefault(
                u=>u.Email == this.Email && u.Password == hashedPassword
            );
            return user;
        }
        public static List<MyUser> getDestinataires(CourrierDocker_MBDS_31Context _context, string[] emails)
        {
            return _context.MyUser.Where(user =>
                emails.Contains(user.Email)).ToList();
        }
        public static List<MyUser> getDestinataires(CourrierDocker_MBDS_31Context _context, string emails)
        {
            string[] emailsArray = emails.Substring(0, emails.Length-2).Split(';');
            return getDestinataires(_context, emailsArray);
        }
    }
}
