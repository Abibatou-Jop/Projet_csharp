using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoApp2
{
    internal class Classe
    {
        [Key] public int idC { get; set; }
        public string libelle { get; set; }
        ICollection<Etudiant> etudiants { get; set; }

        
    }
}
