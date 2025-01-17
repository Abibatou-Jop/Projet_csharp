using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoApp2
{
    internal class Etudiant
    {
        [Key] public int idE { get; set; }
        public string prenom { get; set; }
        public string nom {  get; set; }
        public int idClasse { get; set; }
        public Classe classe { get; set; }

       
    }
    internal class ViewEtudiant
    {
        public int idE { get; set; }
        public string prenom { get; set; }
        public string nom { get; set; }
        public string classe { get; set; }
    }
}
