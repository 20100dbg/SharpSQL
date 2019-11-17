namespace SharpSQL
{
    partial class ConnectManager
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
            this.label10 = new System.Windows.Forms.Label();
            this.cb_connexion = new System.Windows.Forms.ComboBox();
            this.b_nouveau = new System.Windows.Forms.Button();
            this.b_supprimer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_server = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_login = new System.Windows.Forms.TextBox();
            this.tb_connectionstring = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_database = new System.Windows.Forms.TextBox();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.b_save = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.b_test = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_fichier = new System.Windows.Forms.TextBox();
            this.cb_database = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(65, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 14);
            this.label10.TabIndex = 47;
            this.label10.Text = "Configuration";
            // 
            // cb_connexion
            // 
            this.cb_connexion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_connexion.FormattingEnabled = true;
            this.cb_connexion.Location = new System.Drawing.Point(171, 12);
            this.cb_connexion.Name = "cb_connexion";
            this.cb_connexion.Size = new System.Drawing.Size(237, 22);
            this.cb_connexion.TabIndex = 1;
            this.cb_connexion.SelectedIndexChanged += new System.EventHandler(this.cb_connexion_SelectedIndexChanged);
            // 
            // b_nouveau
            // 
            this.b_nouveau.Location = new System.Drawing.Point(414, 12);
            this.b_nouveau.Name = "b_nouveau";
            this.b_nouveau.Size = new System.Drawing.Size(83, 22);
            this.b_nouveau.TabIndex = 2;
            this.b_nouveau.Text = "Nouveau";
            this.b_nouveau.UseVisualStyleBackColor = true;
            this.b_nouveau.Click += new System.EventHandler(this.b_nouveau_Click);
            // 
            // b_supprimer
            // 
            this.b_supprimer.Location = new System.Drawing.Point(503, 12);
            this.b_supprimer.Name = "b_supprimer";
            this.b_supprimer.Size = new System.Drawing.Size(84, 22);
            this.b_supprimer.TabIndex = 3;
            this.b_supprimer.Text = "Supprimer";
            this.b_supprimer.UseVisualStyleBackColor = true;
            this.b_supprimer.Click += new System.EventHandler(this.b_supprimer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_server);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tb_login);
            this.groupBox1.Controls.Add(this.tb_connectionstring);
            this.groupBox1.Controls.Add(this.tb_password);
            this.groupBox1.Controls.Add(this.tb_database);
            this.groupBox1.Controls.Add(this.tb_port);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.b_save);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.b_test);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tb_name);
            this.groupBox1.Controls.Add(this.tb_fichier);
            this.groupBox1.Controls.Add(this.cb_database);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 366);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            // 
            // tb_server
            // 
            this.tb_server.Location = new System.Drawing.Point(117, 135);
            this.tb_server.Name = "tb_server";
            this.tb_server.Size = new System.Drawing.Size(228, 22);
            this.tb_server.TabIndex = 77;
            this.tb_server.TextChanged += new System.EventHandler(this.tb_server_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 14);
            this.label5.TabIndex = 92;
            this.label5.Text = "Connection String";
            // 
            // tb_login
            // 
            this.tb_login.Location = new System.Drawing.Point(449, 136);
            this.tb_login.Name = "tb_login";
            this.tb_login.Size = new System.Drawing.Size(192, 22);
            this.tb_login.TabIndex = 80;
            this.tb_login.TextChanged += new System.EventHandler(this.tb_login_TextChanged);
            // 
            // tb_connectionstring
            // 
            this.tb_connectionstring.Location = new System.Drawing.Point(117, 268);
            this.tb_connectionstring.Multiline = true;
            this.tb_connectionstring.Name = "tb_connectionstring";
            this.tb_connectionstring.Size = new System.Drawing.Size(524, 61);
            this.tb_connectionstring.TabIndex = 83;
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(449, 164);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(192, 22);
            this.tb_password.TabIndex = 81;
            this.tb_password.TextChanged += new System.EventHandler(this.tb_password_TextChanged);
            // 
            // tb_database
            // 
            this.tb_database.Location = new System.Drawing.Point(117, 191);
            this.tb_database.Name = "tb_database";
            this.tb_database.Size = new System.Drawing.Size(228, 22);
            this.tb_database.TabIndex = 79;
            this.tb_database.TextChanged += new System.EventHandler(this.tb_database_TextChanged);
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(117, 163);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(61, 22);
            this.tb_port.TabIndex = 78;
            this.tb_port.TextChanged += new System.EventHandler(this.tb_port_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 14);
            this.label1.TabIndex = 86;
            this.label1.Text = "Serveur";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 14);
            this.label6.TabIndex = 90;
            this.label6.Text = "Fichier";
            // 
            // b_save
            // 
            this.b_save.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_save.Location = new System.Drawing.Point(572, 335);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(75, 25);
            this.b_save.TabIndex = 76;
            this.b_save.Text = "Enregistrer";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(375, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 14);
            this.label7.TabIndex = 91;
            this.label7.Text = "Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(74, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 14);
            this.label9.TabIndex = 85;
            this.label9.Text = "SGBD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 14);
            this.label2.TabIndex = 87;
            this.label2.Text = "Port";
            // 
            // b_test
            // 
            this.b_test.Location = new System.Drawing.Point(491, 335);
            this.b_test.Name = "b_test";
            this.b_test.Size = new System.Drawing.Size(75, 25);
            this.b_test.TabIndex = 75;
            this.b_test.Text = "Tester";
            this.b_test.UseVisualStyleBackColor = true;
            this.b_test.Click += new System.EventHandler(this.b_test_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 14);
            this.label3.TabIndex = 88;
            this.label3.Text = "Nom base";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(74, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 14);
            this.label8.TabIndex = 84;
            this.label8.Text = "Nom";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 14);
            this.label4.TabIndex = 89;
            this.label4.Text = "Login";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(159, 60);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(186, 22);
            this.tb_name.TabIndex = 74;
            // 
            // tb_fichier
            // 
            this.tb_fichier.Location = new System.Drawing.Point(117, 236);
            this.tb_fichier.Name = "tb_fichier";
            this.tb_fichier.Size = new System.Drawing.Size(524, 22);
            this.tb_fichier.TabIndex = 82;
            this.tb_fichier.Click += new System.EventHandler(this.tb_fichier_Enter);
            // 
            // cb_database
            // 
            this.cb_database.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_database.FormattingEnabled = true;
            this.cb_database.Location = new System.Drawing.Point(159, 31);
            this.cb_database.Name = "cb_database";
            this.cb_database.Size = new System.Drawing.Size(157, 22);
            this.cb_database.TabIndex = 73;
            // 
            // ConnectManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 447);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.b_supprimer);
            this.Controls.Add(this.b_nouveau);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cb_connexion);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ConnectManager";
            this.Text = "ConnectManager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cb_connexion;
        private System.Windows.Forms.Button b_nouveau;
        private System.Windows.Forms.Button b_supprimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_server;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_login;
        private System.Windows.Forms.TextBox tb_connectionstring;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.TextBox tb_database;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button b_test;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_fichier;
        private System.Windows.Forms.ComboBox cb_database;
    }
}