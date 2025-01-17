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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void classeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClasse formClasse = new FormClasse();
            formClasse.Show();
            formClasse.MdiParent = this;
        }

        private void etudiantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEtudiant formEtudiant = new FormEtudiant();
            formEtudiant.Show();
            formEtudiant.MdiParent = this;
        }
    }
}
