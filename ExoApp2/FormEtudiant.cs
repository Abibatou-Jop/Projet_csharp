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
    public partial class FormEtudiant : Form
    {
        public FormEtudiant()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormEtudiant_Load(object sender, EventArgs e)
        {
            refresh();
            using (var db= new DBScolaire())
            {
                cmbclasse.DataSource = db.Classes.ToList();
                cmbclasse.DisplayMember = "libelle";
                cmbclasse.ValueMember = "idC";
            }
        }

        private void btnaddEtudiant_Click(object sender, EventArgs e)
        {
            using (var db = new DBScolaire())
            {
                Etudiant etudiant = new Etudiant();
                etudiant.prenom = txtprenom.Text;
                etudiant.nom = txtnom.Text;
                etudiant.idClasse = (int)cmbclasse.SelectedValue;
                etudiant.classe = (Classe)cmbclasse.SelectedItem;
                db.Etudiants.Add(etudiant);
                db.SaveChanges();
                refresh();
                clearEtudiant(sender, e);
            }
        }

        public void refresh()
        {
            dataGridView1.DataSource = null;
            using (var db = new DBScolaire())
            {
                dataGridView1.DataSource = db.Etudiants.Select(e => new ViewEtudiant { idE = e.idE ,prenom=e.prenom,nom=e.nom,classe=e.classe.libelle}).ToList();
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Récupérer l'ID de l'étudiant depuis la ligne double-cliquée
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["idE"].Value);

                // Charger les informations de l'étudiant dans le formulaire
                ChargerEtudiant(id);
            }
        }

        private void ChargerEtudiant(int idE)
        {
            using (var db = new DBScolaire())
            {
                // Rechercher l'étudiant par son identifiant (idEt)
                Etudiant etudiant = db.Etudiants.Find(idE);

                if (etudiant != null)
                {
                    // Remplir les champs du formulaire avec les informations de l'étudiant
                    txtprenom.Text = etudiant.prenom;
                    txtnom.Text = etudiant.nom;
                    cmbclasse.SelectedValue = etudiant.idClasse; // Assurez-vous que cmbclasse contient une clé étrangère idClasse
                    //cmbclasse.SelectedItem = etudiant.classe; // Pour afficher l'objet complet si nécessaire
                }
                else
                {
                    MessageBox.Show("L'étudiant n'a pas été trouvé.");
                }
            }
        }

       

        private void ModifierEtudiant(int id)
        {
            using (var db = new DBScolaire())
            {
                // Rechercher l'étudiant par son identifiant
                Etudiant etudiant = db.Etudiants.Find(id);

                if (etudiant != null)
                {
                    // Mettre à jour les informations de l'étudiant avec les nouvelles valeurs des champs du formulaire
                    etudiant.prenom = txtprenom.Text;
                    etudiant.nom = txtnom.Text;
                    etudiant.idClasse = (int)cmbclasse.SelectedValue; // Assurez-vous que SelectedValue contient l'ID de la classe
                    etudiant.classe = (Classe)cmbclasse.SelectedItem;  // Si vous voulez mettre l'objet entier dans la classe

                    // Sauvegarder les modifications dans la base de données
                    db.SaveChanges();
                    MessageBox.Show("Les informations de l'étudiant ont été mises à jour.");
                }
                else
                {
                    MessageBox.Show("L'étudiant n'a pas été trouvé.");
                }
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            // Récupérer l'ID de l'étudiant (vous devez avoir une variable globale pour l'ID ou récupérer via un autre moyen)
            int idE = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idE"].Value);

            // Modifier les informations de l'étudiant
            ModifierEtudiant(idE);
            refresh();
            clearEtudiant(sender, e);
        }

        private void SupprimerEtudiant(int id)
        {
            using (var db = new DBScolaire())
            {
                // Rechercher l'étudiant par son identifiant
                Etudiant etudiant = db.Etudiants.Find(id);

                if (etudiant != null)
                {
                    // Supprimer l'étudiant
                    db.Etudiants.Remove(etudiant);
                    db.SaveChanges(); // Sauvegarder les changements dans la base de données

                    // Mettre à jour le DataGridView pour refléter la suppression
                    MessageBox.Show("L'étudiant a été supprimé avec succès.");
                }
                else
                {
                    MessageBox.Show("L'étudiant n'a pas été trouvé.");
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            // Vérifier si un étudiant est sélectionné
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Récupérer l'ID de l'étudiant sélectionné
                int idE = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idE"].Value);

                // Demander une confirmation avant de supprimer
                DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer cet étudiant ?", "Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Supprimer l'étudiant
                    SupprimerEtudiant(idE);
                    refresh();
                    clearEtudiant(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un étudiant à supprimer.");
            }
        }
        private void clearEtudiant(object sender, EventArgs e)
        {
            txtnom.Text = string.Empty;
            txtprenom.Text = string.Empty;
            cmbclasse.SelectedIndex = 0;

        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Vérifier si un clic a eu lieu sur une cellule (pas une zone vide ou un en-tête)
            if (e.RowIndex >= 0)
            {
                // Récupérer l'ID de l'étudiant depuis la cellule de la ligne cliquée
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["idE"].Value);

                // Charger les informations de l'étudiant dans le formulaire
                ChargerEtudiant(id);
            }
        }
    }
}
