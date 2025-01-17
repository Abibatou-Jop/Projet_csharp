using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExoApp2
{
    public partial class FormClasse : Form
    {
        public FormClasse()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnaddClasse_Click(object sender, EventArgs e)
        {
            using (var db =new DBScolaire())
            {
                Classe classe = new Classe();
                classe.libelle = txtlibelle.Text;
                db.Classes.Add(classe);
                db.SaveChanges();// Sauvegarder les infos dans la base de données 
                refresh();
                MessageBox.Show("La classe " + classe.libelle + " a été ajoutée");
            }
        }
        public void refresh()
        {
            dataGridView1.DataSource = null;
            using (var db =new DBScolaire())
            {
                dataGridView1.DataSource =db.Classes.ToList();
            }
        }

        private void FormClasse_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Récupérer l'ID de l'étudiant depuis la ligne double-cliquée
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["idC"].Value);

                // Charger les informations de l'étudiant dans le formulaire
                ChargerClasse(id);
            }
        }

        private void ChargerClasse(int idC)
        {
            using (var db = new DBScolaire())
            {
                // Rechercher la classe par son id
                Classe classe = db.Classes.Find(idC);

                if (classe != null)
                {
                    // Remplir le champ libellé du formulaire avec le libellé de la classe selectioné
                    txtlibelle.Text = classe.libelle;
                }
                else
                {
                    MessageBox.Show("La classe n'a pas été trouvée.");
                }
            }
        }

        private void ModifierClasse(int id)
        {
            using (var db = new DBScolaire())
            {
                // Rechercher la classe par son id
                Classe classe = db.Classes.Find(id);

                if (classe != null)
                {
                    // Mettre à jour le libellé avec le nouveau libelle du formulaire
                    classe.libelle = txtlibelle.Text;
                    // Sauvegarder les modifications dans la base de données
                    db.SaveChanges();
                    MessageBox.Show("Le libellé de le classe a été mise à jour.");
                }
                else
                {
                    MessageBox.Show("La classe n'a pas été trouvé.");
                }
            }
        }

        private void clearClasse(object sender, EventArgs e)
        {
            txtlibelle.Text = string.Empty;
        }
        private void btnupdateClasse_Click(object sender, EventArgs e)
        {
            // Récupérer l'ID de l'étudiant (vous devez avoir une variable globale pour l'ID ou récupérer via un autre moyen)
            int idC = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idC"].Value);

            // Modifier les informations de l'étudiant
            ModifierClasse(idC);
            refresh();
            clearClasse(sender, e);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Vérifier si un clic a eu lieu sur une cellule (pas une zone vide ou un en-tête)
            if (e.RowIndex >= 0)
            {
                // Récupérer l'ID de la classe depuis la cellule de la ligne cliquée
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["idC"].Value);

                // Charger le libellé de la classe dans le formulaire
                ChargerClasse(id);
            }
        }

        

        private void SupprimerClasse(int id)
        {
            using (var db = new DBScolaire())
            {
                // Récupérer tous les étudiants associés à la classe
                var etudiants = db.Etudiants.Where(e => e.idClasse == id).ToList();

                // Supprimer tous les étudiants associés à la classe
                foreach (var etudiant in etudiants)
                {
                    db.Etudiants.Remove(etudiant);
                }

                // Supprimer la classe
                var classe = db.Classes.FirstOrDefault(c => c.idC == id);
                if (classe != null)
                {
                    db.Classes.Remove(classe);
                    db.SaveChanges();
                }
            }
        }

        private void btndeleteClasse_Click(object sender, EventArgs e)
        {
            // Vérifier si un étudiant est sélectionné
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Récupérer l'ID de l'étudiant sélectionné
                int idC = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idC"].Value);

                // Demander une confirmation avant de supprimer
                DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer cette classe ?", "Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Supprimer l'étudiant
                    SupprimerClasse(idC);
                    refresh();
                    clearClasse(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un étudiant à supprimer.");
            }
        }
    }
}
