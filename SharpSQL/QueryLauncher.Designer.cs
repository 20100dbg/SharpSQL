namespace SharpSQL
{
    partial class QueryLauncher
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryLauncher));
            this.b_execute = new System.Windows.Forms.Button();
            this.tb_requete = new System.Windows.Forms.TextBox();
            this.dgv_result = new System.Windows.Forms.DataGridView();
            this.b_connect = new System.Windows.Forms.Button();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.cb_quickconnect = new System.Windows.Forms.ComboBox();
            this.b_deconnect = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status_database = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_rows = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_message = new System.Windows.Forms.ToolStripStatusLabel();
            this.cb_query = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sharpSqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gérerLesConnexionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fermerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requeteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sauvegarderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_history = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rb_reader = new System.Windows.Forms.RadioButton();
            this.rb_scalar = new System.Windows.Forms.RadioButton();
            this.rb_execute = new System.Windows.Forms.RadioButton();
            this.b_utiliserRequete = new System.Windows.Forms.Button();
            this.b_viderHistorique = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_execute
            // 
            this.b_execute.Location = new System.Drawing.Point(764, 166);
            this.b_execute.Name = "b_execute";
            this.b_execute.Size = new System.Drawing.Size(126, 22);
            this.b_execute.TabIndex = 0;
            this.b_execute.Text = "Executer";
            this.b_execute.UseVisualStyleBackColor = true;
            this.b_execute.Click += new System.EventHandler(this.b_execute_Click);
            // 
            // tb_requete
            // 
            this.tb_requete.Location = new System.Drawing.Point(11, 85);
            this.tb_requete.Multiline = true;
            this.tb_requete.Name = "tb_requete";
            this.tb_requete.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tb_requete.Size = new System.Drawing.Size(747, 103);
            this.tb_requete.TabIndex = 6;
            // 
            // dgv_result
            // 
            this.dgv_result.AllowUserToAddRows = false;
            this.dgv_result.AllowUserToDeleteRows = false;
            this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result.Location = new System.Drawing.Point(11, 216);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.ReadOnly = true;
            this.dgv_result.Size = new System.Drawing.Size(879, 321);
            this.dgv_result.TabIndex = 7;
            // 
            // b_connect
            // 
            this.b_connect.Location = new System.Drawing.Point(269, 31);
            this.b_connect.Name = "b_connect";
            this.b_connect.Size = new System.Drawing.Size(92, 28);
            this.b_connect.TabIndex = 12;
            this.b_connect.Text = "Connecter";
            this.b_connect.UseVisualStyleBackColor = true;
            this.b_connect.Click += new System.EventHandler(this.b_connect_Click);
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(11, 543);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_log.Size = new System.Drawing.Size(879, 81);
            this.tb_log.TabIndex = 14;
            // 
            // cb_quickconnect
            // 
            this.cb_quickconnect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_quickconnect.FormattingEnabled = true;
            this.cb_quickconnect.Location = new System.Drawing.Point(11, 34);
            this.cb_quickconnect.Name = "cb_quickconnect";
            this.cb_quickconnect.Size = new System.Drawing.Size(252, 22);
            this.cb_quickconnect.TabIndex = 32;
            // 
            // b_deconnect
            // 
            this.b_deconnect.Enabled = false;
            this.b_deconnect.Location = new System.Drawing.Point(367, 32);
            this.b_deconnect.Name = "b_deconnect";
            this.b_deconnect.Size = new System.Drawing.Size(101, 27);
            this.b_deconnect.TabIndex = 33;
            this.b_deconnect.Text = "Déconnecter";
            this.b_deconnect.UseVisualStyleBackColor = true;
            this.b_deconnect.Click += new System.EventHandler(this.b_deconnect_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_database,
            this.status_rows,
            this.status_message});
            this.statusStrip1.Location = new System.Drawing.Point(0, 630);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1085, 22);
            this.statusStrip1.TabIndex = 36;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status_database
            // 
            this.status_database.AutoSize = false;
            this.status_database.Name = "status_database";
            this.status_database.Size = new System.Drawing.Size(200, 17);
            this.status_database.Text = "Pas de connexion";
            this.status_database.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // status_rows
            // 
            this.status_rows.AutoSize = false;
            this.status_rows.Margin = new System.Windows.Forms.Padding(0, 2, -2, 2);
            this.status_rows.Name = "status_rows";
            this.status_rows.Size = new System.Drawing.Size(120, 18);
            this.status_rows.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // status_message
            // 
            this.status_message.AutoSize = false;
            this.status_message.Name = "status_message";
            this.status_message.Size = new System.Drawing.Size(300, 17);
            this.status_message.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_query
            // 
            this.cb_query.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_query.FormattingEnabled = true;
            this.cb_query.Location = new System.Drawing.Point(642, 35);
            this.cb_query.Name = "cb_query";
            this.cb_query.Size = new System.Drawing.Size(249, 22);
            this.cb_query.TabIndex = 39;
            this.cb_query.SelectedIndexChanged += new System.EventHandler(this.cb_query_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sharpSqlToolStripMenuItem,
            this.requeteToolStripMenuItem,
            this.importExportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1085, 24);
            this.menuStrip1.TabIndex = 40;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sharpSqlToolStripMenuItem
            // 
            this.sharpSqlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gérerLesConnexionsToolStripMenuItem,
            this.fermerToolStripMenuItem});
            this.sharpSqlToolStripMenuItem.Name = "sharpSqlToolStripMenuItem";
            this.sharpSqlToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.sharpSqlToolStripMenuItem.Text = "SharpSql";
            // 
            // gérerLesConnexionsToolStripMenuItem
            // 
            this.gérerLesConnexionsToolStripMenuItem.Name = "gérerLesConnexionsToolStripMenuItem";
            this.gérerLesConnexionsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.gérerLesConnexionsToolStripMenuItem.Text = "Gérer les connexions";
            this.gérerLesConnexionsToolStripMenuItem.Click += new System.EventHandler(this.gérerLesConnexionsToolStripMenuItem_Click);
            // 
            // fermerToolStripMenuItem
            // 
            this.fermerToolStripMenuItem.Name = "fermerToolStripMenuItem";
            this.fermerToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.fermerToolStripMenuItem.Text = "Fermer";
            this.fermerToolStripMenuItem.Click += new System.EventHandler(this.fermerToolStripMenuItem_Click);
            // 
            // requeteToolStripMenuItem
            // 
            this.requeteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sauvegarderToolStripMenuItem,
            this.supprimerToolStripMenuItem});
            this.requeteToolStripMenuItem.Name = "requeteToolStripMenuItem";
            this.requeteToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.requeteToolStripMenuItem.Text = "Requete";
            // 
            // sauvegarderToolStripMenuItem
            // 
            this.sauvegarderToolStripMenuItem.Name = "sauvegarderToolStripMenuItem";
            this.sauvegarderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sauvegarderToolStripMenuItem.Text = "Sauvegarder";
            this.sauvegarderToolStripMenuItem.Click += new System.EventHandler(this.sauvegarderToolStripMenuItem_Click);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.supprimerToolStripMenuItem.Text = "Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // importExportToolStripMenuItem
            // 
            this.importExportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importSqlToolStripMenuItem,
            this.exportCSVToolStripMenuItem});
            this.importExportToolStripMenuItem.Name = "importExportToolStripMenuItem";
            this.importExportToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.importExportToolStripMenuItem.Text = "Import/Export";
            // 
            // importSqlToolStripMenuItem
            // 
            this.importSqlToolStripMenuItem.Name = "importSqlToolStripMenuItem";
            this.importSqlToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.importSqlToolStripMenuItem.Text = "Import Sql";
            this.importSqlToolStripMenuItem.Click += new System.EventHandler(this.importSqlToolStripMenuItem_Click);
            // 
            // exportCSVToolStripMenuItem
            // 
            this.exportCSVToolStripMenuItem.Name = "exportCSVToolStripMenuItem";
            this.exportCSVToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.exportCSVToolStripMenuItem.Text = "Export CSV";
            this.exportCSVToolStripMenuItem.Click += new System.EventHandler(this.exportCSVToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 41;
            this.label1.Text = "Résultats";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 14);
            this.label3.TabIndex = 43;
            this.label3.Text = "Requête";
            // 
            // lb_history
            // 
            this.lb_history.FormattingEnabled = true;
            this.lb_history.ItemHeight = 14;
            this.lb_history.Location = new System.Drawing.Point(896, 59);
            this.lb_history.Name = "lb_history";
            this.lb_history.Size = new System.Drawing.Size(176, 186);
            this.lb_history.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(897, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 14);
            this.label2.TabIndex = 46;
            this.label2.Text = "Historique";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(896, 315);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(172, 109);
            this.richTextBox1.TabIndex = 47;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(900, 430);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 48;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rb_reader
            // 
            this.rb_reader.AutoSize = true;
            this.rb_reader.Checked = true;
            this.rb_reader.Location = new System.Drawing.Point(765, 85);
            this.rb_reader.Name = "rb_reader";
            this.rb_reader.Size = new System.Drawing.Size(64, 18);
            this.rb_reader.TabIndex = 49;
            this.rb_reader.TabStop = true;
            this.rb_reader.Text = "Reader";
            this.rb_reader.UseVisualStyleBackColor = true;
            // 
            // rb_scalar
            // 
            this.rb_scalar.AutoSize = true;
            this.rb_scalar.Location = new System.Drawing.Point(765, 109);
            this.rb_scalar.Name = "rb_scalar";
            this.rb_scalar.Size = new System.Drawing.Size(58, 18);
            this.rb_scalar.TabIndex = 50;
            this.rb_scalar.Text = "Scalar";
            this.rb_scalar.UseVisualStyleBackColor = true;
            // 
            // rb_execute
            // 
            this.rb_execute.AutoSize = true;
            this.rb_execute.Location = new System.Drawing.Point(765, 133);
            this.rb_execute.Name = "rb_execute";
            this.rb_execute.Size = new System.Drawing.Size(66, 18);
            this.rb_execute.TabIndex = 51;
            this.rb_execute.Text = "Execute";
            this.rb_execute.UseVisualStyleBackColor = true;
            // 
            // b_utiliserRequete
            // 
            this.b_utiliserRequete.Location = new System.Drawing.Point(896, 251);
            this.b_utiliserRequete.Name = "b_utiliserRequete";
            this.b_utiliserRequete.Size = new System.Drawing.Size(75, 23);
            this.b_utiliserRequete.TabIndex = 52;
            this.b_utiliserRequete.Text = "Lancer";
            this.b_utiliserRequete.UseVisualStyleBackColor = true;
            this.b_utiliserRequete.Click += new System.EventHandler(this.b_utiliserRequete_Click);
            // 
            // b_viderHistorique
            // 
            this.b_viderHistorique.Location = new System.Drawing.Point(997, 251);
            this.b_viderHistorique.Name = "b_viderHistorique";
            this.b_viderHistorique.Size = new System.Drawing.Size(75, 23);
            this.b_viderHistorique.TabIndex = 53;
            this.b_viderHistorique.Text = "Vider";
            this.b_viderHistorique.UseVisualStyleBackColor = true;
            this.b_viderHistorique.Click += new System.EventHandler(this.b_viderHistorique_Click);
            // 
            // QueryLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 652);
            this.Controls.Add(this.b_viderHistorique);
            this.Controls.Add(this.b_utiliserRequete);
            this.Controls.Add(this.rb_execute);
            this.Controls.Add(this.rb_scalar);
            this.Controls.Add(this.rb_reader);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_history);
            this.Controls.Add(this.b_execute);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_query);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.b_deconnect);
            this.Controls.Add(this.cb_quickconnect);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.b_connect);
            this.Controls.Add(this.dgv_result);
            this.Controls.Add(this.tb_requete);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "QueryLauncher";
            this.Text = "SharpSql";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_execute;
        private System.Windows.Forms.TextBox tb_requete;
        private System.Windows.Forms.DataGridView dgv_result;
        private System.Windows.Forms.Button b_connect;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.ComboBox cb_quickconnect;
        private System.Windows.Forms.Button b_deconnect;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status_database;
        private System.Windows.Forms.ToolStripStatusLabel status_rows;
        private System.Windows.Forms.ComboBox cb_query;
        private System.Windows.Forms.ToolStripStatusLabel status_message;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sharpSqlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fermerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSqlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requeteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sauvegarderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gérerLesConnexionsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lb_history;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rb_reader;
        private System.Windows.Forms.RadioButton rb_scalar;
        private System.Windows.Forms.RadioButton rb_execute;
        private System.Windows.Forms.Button b_utiliserRequete;
        private System.Windows.Forms.Button b_viderHistorique;
    }
}

