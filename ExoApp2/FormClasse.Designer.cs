namespace ExoApp2
{
    partial class FormClasse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtlibelle = new System.Windows.Forms.TextBox();
            this.btnaddClasse = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnupdateClasse = new System.Windows.Forms.Button();
            this.btndeleteClasse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Libelle";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtlibelle
            // 
            this.txtlibelle.Location = new System.Drawing.Point(73, 72);
            this.txtlibelle.Multiline = true;
            this.txtlibelle.Name = "txtlibelle";
            this.txtlibelle.Size = new System.Drawing.Size(148, 43);
            this.txtlibelle.TabIndex = 1;
            // 
            // btnaddClasse
            // 
            this.btnaddClasse.Location = new System.Drawing.Point(73, 165);
            this.btnaddClasse.Name = "btnaddClasse";
            this.btnaddClasse.Size = new System.Drawing.Size(96, 36);
            this.btnaddClasse.TabIndex = 2;
            this.btnaddClasse.Text = "Ajouter";
            this.btnaddClasse.UseVisualStyleBackColor = true;
            this.btnaddClasse.Click += new System.EventHandler(this.btnaddClasse_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(334, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(454, 390);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // btnupdateClasse
            // 
            this.btnupdateClasse.Location = new System.Drawing.Point(186, 165);
            this.btnupdateClasse.Name = "btnupdateClasse";
            this.btnupdateClasse.Size = new System.Drawing.Size(99, 38);
            this.btnupdateClasse.TabIndex = 4;
            this.btnupdateClasse.Text = "Modifier";
            this.btnupdateClasse.UseVisualStyleBackColor = true;
            this.btnupdateClasse.Click += new System.EventHandler(this.btnupdateClasse_Click);
            // 
            // btndeleteClasse
            // 
            this.btndeleteClasse.Location = new System.Drawing.Point(108, 232);
            this.btndeleteClasse.Name = "btndeleteClasse";
            this.btndeleteClasse.Size = new System.Drawing.Size(135, 38);
            this.btndeleteClasse.TabIndex = 5;
            this.btndeleteClasse.Text = "Supprimer";
            this.btndeleteClasse.UseVisualStyleBackColor = true;
            this.btndeleteClasse.Click += new System.EventHandler(this.btndeleteClasse_Click);
            // 
            // FormClasse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btndeleteClasse);
            this.Controls.Add(this.btnupdateClasse);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnaddClasse);
            this.Controls.Add(this.txtlibelle);
            this.Controls.Add(this.label1);
            this.Name = "FormClasse";
            this.Text = "FormClasse";
            this.Load += new System.EventHandler(this.FormClasse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtlibelle;
        private System.Windows.Forms.Button btnaddClasse;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnupdateClasse;
        private System.Windows.Forms.Button btndeleteClasse;
    }
}