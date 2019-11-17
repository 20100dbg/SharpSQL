using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SharpSQL
{
    public partial class ConnectManager : Form
    {
        QueryLauncher parent;

        public ConnectManager(QueryLauncher parent)
        {
            InitializeComponent();
            this.parent = parent;

            cb_connexion.Items.AddRange(QueryLauncher.connexions.ToArray());

            foreach (SGBD s in QueryLauncher.sgbds) cb_database.Items.Add(s);
            cb_database.SelectedIndex = 0;

            groupBox1.Enabled = false;
        }


        private void cb_database_SelectedIndexChanged(object sender, EventArgs e)
        {
            //changer les cases à afficher

            String s = ((SGBD)cb_database.SelectedItem).Nom;
            
            if (cb_connexion.SelectedIndex > -1)
            {
                Connexion co = (Connexion)cb_connexion.SelectedItem;
                co.SGBD = s;
                tb_connectionstring.Text = co.BuildConnectionString();
            }

            /*
            if (cb_database.SelectedIndex > -1)
            {
                if (s == "Access97" || s == "Access2007" || s == "SQLite")
                {
                    tb_fichier.ReadOnly = false;
                    tb_server.ReadOnly = tb_port.ReadOnly = tb_login.ReadOnly = tb_database.ReadOnly = true;
                }
                else if (s == "DB2" || s == "Firebird" || s == "MySql"
                    || s == "Oracle" || s == "PostGreSql" || s == "VistaDB")
                {
                    tb_server.ReadOnly = tb_port.ReadOnly = tb_login.ReadOnly = tb_database.ReadOnly = false;
                    tb_fichier.ReadOnly = true;
                }
                else if (s == "ODBC" || s == "OleDb")
                {
                    tb_server.ReadOnly = tb_port.ReadOnly = tb_login.ReadOnly = tb_database.ReadOnly = tb_fichier.ReadOnly = false;
                }
            }*/
        }


        private void tb_fichier_Enter(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            //ofd.InitialDirectory = Environment.SpecialFolder.UserProfile.ToString();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            DialogResult dr = ofd.ShowDialog();

            if (dr != DialogResult.Cancel)
            {
                tb_fichier.Text = ofd.FileName;
                RefreshConnectionString();
            }
        }



        private void b_test_Click(object sender, EventArgs e)
        {
            if (cb_connexion.SelectedIndex > -1)
            {
                Connexion co = new Connexion { SGBD = ((SGBD)cb_database.SelectedItem).Nom, ConnectionString = tb_connectionstring.Text };
                IDatabase dbtest = QueryLauncher.Connect(co);
                MessageBox.Show((dbtest.Connected) ? "Connexion OK" : "Erreur de connexion : " + dbtest.LastError);
            }
        }


        private void b_save_Click(object sender, EventArgs e)
        {
            int idx_cb_connexion = cb_connexion.SelectedIndex;

            if (idx_cb_connexion > -1)
            {
                Connexion co = (Connexion)cb_connexion.SelectedItem;

                Int16 port;
                if (!Int16.TryParse(tb_port.Text, out port)) port = 0;

                co.ConnectionString = tb_connectionstring.Text;
                co.Database = tb_database.Text;
                co.Fichier = tb_fichier.Text;
                co.Login = tb_login.Text;
                co.Name = tb_name.Text;
                co.Password = tb_password.Text;
                co.Port = port;
                co.Server = tb_server.Text;
                co.SGBD = ((SGBD)cb_database.SelectedItem).Nom;

                cb_connexion.SelectedItem = co;
                QueryLauncher.connexions[idx_cb_connexion] = co;
                parent.refreshQuickConnect();

                String sql = "UPDATE configuration SET ConnectionString='" + co.ConnectionString + 
                    "', Database='" + co.Database + "',Fichier='" + co.Fichier + "',Login='" + co.Login + "'," +
                    "Name='" + co.Name + "', Port='" + co.Port + "',Server='" + co.Server + 
                    "',SGBD='" + co.SGBD + "',Password='" + co.Password + "' " +
                    "WHERE ROWID='" + co.Id + "'";
                QueryLauncher.dbconfig.Execute(sql);

                cb_connexion.Items.Clear();
                cb_connexion.Items.AddRange(QueryLauncher.connexions.ToArray());

                cb_connexion.SelectedIndex = idx_cb_connexion;

                MessageBox.Show("Connexion enregistrée");
            }
        }

        private void ResetFields()
        {
            tb_connectionstring.Text = tb_database.Text = tb_fichier.Text = "";
            tb_login.Text = tb_password.Text = tb_port.Text = tb_server.Text = "";
            tb_name.Text = tb_connectionstring.Text = "";
            cb_database.SelectedIndex = 0;
        }

        private void b_nouveau_Click(object sender, EventArgs e)
        {
            //vider les champs
            ResetFields();

            Connexion co = new Connexion { Name = "Nouveau...", SGBD = "OleDb" };
            tb_connectionstring.Text = co.ConnectionString = co.BuildConnectionString();


            String sql = "INSERT INTO configuration " +
                    "(ConnectionString, Database, Fichier, Login, Name, Password, Port, Server, SGBD) " +
                    "VALUES ('" + co.ConnectionString + "','" + co.Database + "','" + co.Fichier + "','" +
                    co.Login + "','" + co.Name + "','" + co.Password + "','" + co.Port + "','" + co.Server + "','" + co.SGBD + "')";
            QueryLauncher.dbconfig.Execute(sql);
            Object o = QueryLauncher.dbconfig.ExecuteScalar("SELECT last_insert_rowid()");
            co.Id = (Int64)o;

            cb_connexion.Items.Add(co);
            QueryLauncher.connexions.Add(co);
            cb_connexion.SelectedIndex = cb_connexion.Items.Count - 1;
        }


        private void b_updateConnectionString_Click(object sender, EventArgs e)
        {
            if (cb_database.SelectedIndex > -1)
            {
                Int16 port;
                if (!Int16.TryParse(tb_port.Text, out port)) port = 0;

                Connexion co = new Connexion { SGBD = ((SGBD)cb_database.SelectedItem).Nom, Database = tb_database.Text, Fichier = tb_fichier.Text, Login = tb_login.Text, Password = tb_password.Text, Port = port, Server = tb_server.Text };
                tb_connectionstring.Text = co.BuildConnectionString();
            }
        }

        private void b_supprimer_Click(object sender, EventArgs e)
        {
            int x = cb_connexion.SelectedIndex;

            if (x > -1)
            {
                if (DialogResult.Yes == MessageBox.Show("Supprimer la connexion ?", "Confirmation", MessageBoxButtons.YesNo))
                {

                    String sql = "DELETE FROM configuration WHERE ROWID = '" + QueryLauncher.connexions[x].Id + "'";
                    QueryLauncher.dbconfig.Execute(sql);
                    QueryLauncher.connexions.Remove((Connexion)cb_connexion.SelectedItem);
                    parent.refreshQuickConnect();
                    cb_connexion.Items.RemoveAt(x);

                    ResetFields();
                    groupBox1.Enabled = false;
                }
            }
        }

        private void cb_connexion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = cb_connexion.SelectedIndex;

            if (x >= -1)
            {
                groupBox1.Enabled = true;
                tb_name.Text = tb_connectionstring.Text = tb_database.Text = tb_fichier.Text = tb_login.Text = tb_password.Text = tb_port.Text = tb_server.Text = "";

                int y = QueryLauncher.GetSGBD(QueryLauncher.connexions[x].SGBD.ToString());
                if ( y > -1) cb_database.SelectedIndex = y;

                tb_name.Text = QueryLauncher.connexions[x].Name;
                tb_server.Text = QueryLauncher.connexions[x].Server;
                tb_port.Text = QueryLauncher.connexions[x].Port.ToString();
                tb_database.Text = QueryLauncher.connexions[x].Database;
                tb_login.Text = QueryLauncher.connexions[x].Login;
                tb_password.Text = QueryLauncher.connexions[x].Password;
                tb_fichier.Text = QueryLauncher.connexions[x].Fichier;
                tb_connectionstring.Text = QueryLauncher.connexions[x].ConnectionString;
            }
        }

        public void RefreshConnectionString()
        {
            Int16 port;
            if (!Int16.TryParse(tb_port.Text, out port)) port = 0;

            Connexion co = new Connexion
            {
                SGBD = ((SGBD)cb_database.SelectedItem).Nom,
                Database = tb_database.Text,
                Fichier = tb_fichier.Text,
                Login = tb_login.Text,
                Name = tb_name.Text,
                Password = tb_password.Text,
                Port = port,
                Server = tb_server.Text
            };

            tb_connectionstring.Text = co.BuildConnectionString();
        }


        private void tb_server_TextChanged(object sender, EventArgs e)
        {
            RefreshConnectionString();

        }

        private void tb_login_TextChanged(object sender, EventArgs e)
        {
            RefreshConnectionString();
        }

        private void tb_port_TextChanged(object sender, EventArgs e)
        {
            RefreshConnectionString();
        }

        private void tb_password_TextChanged(object sender, EventArgs e)
        {
            RefreshConnectionString();
        }

        private void tb_database_TextChanged(object sender, EventArgs e)
        {
            RefreshConnectionString();
        }

    }
}
