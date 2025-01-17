using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ExoApp2
{
    internal class DBScolaire : DbContext
    {
        public DBScolaire():base("connexionEcole")
        {

        }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Etudiant> Etudiants { get; set;}
        
    }
}
