using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace SharpSQL
{
    public partial class QueryLauncher : Form
    {
        // https://www.connectionstrings.com/

        //permettre le bind de paramètres
        //coloration syntaxique ?

        public static List<SGBD> sgbds = new List<SGBD>();
        public static List<Connexion> connexions = new List<Connexion>();
        public static List<Requete> requetes = new List<Requete>();

        public static IDatabase db;

        public static IDatabase dbconfig;
        public Boolean showConnectManager = false;

        public QueryLauncher()
        {
            InitializeComponent();
            dbconfig = new SQLite("URI=file:SharpSQL.sqlite");

            GetConfigurations();
            cb_quickconnect.Items.AddRange(connexions.ToArray());

            InitConnexionsString();
            GetXMLConnexionsString();

            GetRequetes();
            cb_query.Items.AddRange(requetes.ToArray());

            tb_log.AppendText("Welcome");
        }

        #region init program


        public void InitConnexionsString()
        {
            sgbds.Add(new SGBD { Nom = "DB2", DefaultConnectionString = "Server={server};Database={database};UID={login};PWD={password};", typeCS = "NET" });
            sgbds.Add(new SGBD { Nom = "Firebird", DefaultConnectionString = "User={login};Password={password};Database={database};DataSource={server};Port={port};Dialect=3;Charset=NONE;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;ServerType=0;", typeCS = "NET" });
            sgbds.Add(new SGBD { Nom = "SQLSERVER", DefaultConnectionString = "Data Source={server};Initial Catalog={database};User id={login};Password={password};", typeCS = "NET" });
            sgbds.Add(new SGBD { Nom = "MySql", DefaultConnectionString = "server={server};port={port};uid={login};database={database};pwd={password};", typeCS = "NET" });
            sgbds.Add(new SGBD { Nom = "Oracle", DefaultConnectionString = "Server={server};Port={port};User Id={login};Password={password};Database={database};", typeCS = "NET" });
            sgbds.Add(new SGBD { Nom = "PostGreSql", DefaultConnectionString = "Server={server};Port={port};User Id={login};Password={password};Database={database};", typeCS = "NET" });
            sgbds.Add(new SGBD { Nom = "SQLite", DefaultConnectionString = "URI=file:{fichier};", typeCS = "NET" });
            sgbds.Add(new SGBD { Nom = "VistaDB", DefaultConnectionString = "Data Source={fichier};Open Mode=ExclusiveReadWrite;Password={password};", typeCS = "NET" });

            sgbds.Add(new SGBD { Nom = "OleDb", DefaultConnectionString = "Server={server};Port={port};User Id={login};Password={password};Database={database};", typeCS = "OleDb" });
            sgbds.Add(new SGBD { Nom = "ODBC", DefaultConnectionString = "Server={server};Port={port};User Id={login};Password={password};Database={database};", typeCS = "ODBC" });
        }

        public void GetXMLConnexionsString()
        {
            XML xmlconfig = new XML("ConnectionStrings.xml");
            DataSet data = xmlconfig.ReadData();

            foreach (DataRow row in data.Tables[0].Rows)
            {
                sgbds.Add(new SGBD
                {
                    Nom = row["sgbd"].ToString(),
                    typeCS = row["type"].ToString(),
                    DefaultConnectionString = row["cs"].ToString()
                });

            }

        }


        private void GetRequetes()
        {
            DataSet data = QueryLauncher.dbconfig.ReadData("SELECT ROWID, * FROM requete");

            foreach (DataRow row in data.Tables[0].Rows)
            {
                Requete re = new Requete { Id = (Int64)row["ROWID"], Nom = row["nom"].ToString(), Req = row["req"].ToString() };
                requetes.Add(re);
            }
        }


        private void GetConfigurations()
        {
            DataSet data = QueryLauncher.dbconfig.ReadData("SELECT ROWID, * FROM configuration");

            foreach (DataRow row in data.Tables[0].Rows)
            {
                Connexion co = new Connexion
                {
                    Id = int.Parse(row["ROWID"].ToString()),
                    ConnectionString = row["ConnectionString"].ToString(),
                    Database = row["Database"].ToString(),
                    Fichier = row["Fichier"].ToString(),
                    Login = row["Login"].ToString(),
                    Name = row["Name"].ToString(),
                    Password = row["Password"].ToString(),
                    Port = Int16.Parse(row["Port"].ToString()),
                    Server = row["Server"].ToString(),
                    SGBD = row["SGBD"].ToString()
                };

                connexions.Add(co);
            }
        }

        #endregion

        public static int GetSGBD(String SGBD)
        {
            SGBD = SGBD.ToLower();//foolproof

            int x = -1;
            for (int i = sgbds.Count - 1; i > -1 && x == -1; i--)
                if (sgbds[i].Nom.ToLower() == SGBD) x = i;

            return x;
        }


        public void refreshQuickConnect()
        {
            cb_quickconnect.Items.Clear();
            cb_quickconnect.Items.AddRange(connexions.ToArray());
        }

        ConnectManager cm;

        private void ShowConnectManager()
        {
            if (!showConnectManager)
            {
                cm = new ConnectManager(this);
                cm.FormClosed += (sender, e) => { showConnectManager = false; };
                showConnectManager = true;
                cm.Show();
            }
            else
                cm.Activate();
        }


        public static IDatabase Connect(Connexion co)
        {
            IDatabase db;

            if (co.SGBD == "DB2") db = new DB2(co.ConnectionString);
            else if (co.SGBD == "Firebird") db = new Firebird(co.ConnectionString);
            else if (co.SGBD == "MSSQL") db = new MsSql(co.ConnectionString);
            else if (co.SGBD == "MySql") db = new MySql(co.ConnectionString);
            else if (co.SGBD == "Oracle") db = new Oracle(co.ConnectionString);
            else if (co.SGBD == "PostGreSQL") db = new Postgre(co.ConnectionString);
            else if (co.SGBD == "SQLite") db = new SQLite(co.ConnectionString);
            else if (co.SGBD == "VistaDB") db = new VistaDB(co.ConnectionString);
            else if (co.SGBD == "ODBC") db = new ODBC(co.ConnectionString);
            else db = new OleDB(co.ConnectionString);

            return db;
        }




        private void b_connect_Click(object sender, EventArgs e)
        {
            if (db != null && db.Connected)
            {
                if (DialogResult.Yes == MessageBox.Show("Déconnecter la session courante ?", "Confirmation", MessageBoxButtons.YesNo))
                {
                    db.Close();
                }
            }

            int idxCon = cb_quickconnect.SelectedIndex;
            if (idxCon > -1) db = Connect(connexions[idxCon]);

            if (db != null)
            {
                db.StateChange += StateChange;

                if (db.Connected)
                {
                    status_database.Text = (db.Connected) ? "Connecté (" + db.GetDbName() + ")" : "Pas de connexion";
                    Log("Connecté à " + connexions[idxCon].Name + " (" + connexions[idxCon].SGBD + ")");
                    b_deconnect.Enabled = true;
                }
                else
                    Log(db.LastError);
            }
        }

        private void Log(String str)
        {
            tb_log.AppendText(Environment.NewLine + "[" + DateTime.Now.ToLongTimeString()  + "] " + str);
        }

        private void b_execute_Click(object sender, EventArgs e)
        {
            if (rb_reader.Checked)
                LaunchQueryReader(db, tb_requete.Text);
            else if (rb_scalar.Checked)
                LaunchQueryScalar(db, tb_requete.Text);
            else if (rb_execute.Checked)
                LaunchQueryExecute(db, tb_requete.Text);

            lb_history.Items.Add(tb_requete.Text);
        }


        public void LaunchQueryReader(IDatabase db, String requete)
        {
            if (db == null || (db != null && !db.Connected))
                return;

            DataSet data = db.ReadData(requete);
            if (!String.IsNullOrEmpty(db.LastError)) Log(db.LastError);

            dgv_result.Columns.Clear();
            dgv_result.Rows.Clear();

            if (data.Tables.Count > 0)
            {
                foreach (DataColumn col in data.Tables[0].Columns)
                {
                    dgv_result.Columns.Add(col.ColumnName, col.ColumnName);
                }

                foreach (DataRow row in data.Tables[0].Rows)
                {
                    dgv_result.Rows.Add(row.ItemArray);
                }

                status_rows.Text = dgv_result.Rows.Count + " lignes";
                Log("Résultat : " + dgv_result.Rows.Count + " lignes");
            }


        }

        private void LaunchQueryExecute(IDatabase db, String requete)
        {
            if (db == null || (db != null && !db.Connected))
                return;

            int x = db.Execute(requete);
            if (!String.IsNullOrEmpty(db.LastError)) Log(db.LastError);

            status_rows.Text = x + " lignes affectées";
            Log(x + " lignes affectées");
        }


        private void LaunchQueryScalar(IDatabase db, String requete)
        {
            if (db == null || (db != null && !db.Connected))
                return;

            Object o = db.ExecuteScalar(requete);
            if (!String.IsNullOrEmpty(db.LastError)) Log(db.LastError);

            dgv_result.Columns.Clear();
            dgv_result.Rows.Clear();

            dgv_result.Columns.Add("result","result");
            dgv_result.Rows.Add(new object[] { o });

            status_rows.Text = " lignes affectées";
            Log(" lignes affectées");
        }

        private void ExportCSV()
        {
            String filename = DateTime.Now.ToShortDateString().Replace("/", "") + "-" + DateTime.Now.ToShortTimeString().Replace(":", "") + ".csv";

            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (DataGridViewRow row in dgv_result.Rows)
                {
                    String[] cells = new String[row.Cells.Count];
                    int i = 0;

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cells[i++] = cell.Value.ToString();
                    }
                    sw.WriteLine(String.Join(";", cells));
                }

                sw.Close();
            }
            status_message.Text = filename + " généré";
            Log(filename + " généré");
        }


        private void b_deconnect_Click(object sender, EventArgs e)
        {
            db.Close();
            b_deconnect.Enabled = false;

            status_database.Text = "Pas de connexion";
            Log("Déconnecté");
        }


        public String PromptForQueryName()
        {
            String input;

            InputDialog id = new InputDialog("Nom de la requête");
            id.ShowDialog();
            input = id.input;
            id.Dispose();

            return input;
        }

        private void cb_query_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_query.SelectedIndex > -1)
            {
                tb_requete.Text = requetes[cb_query.SelectedIndex].Req;
            }
            // coloration syntaxique de la requete
        }



        public void StateChange(object sender, StateChangeEventArgs e)
        {
            if (e.CurrentState == ConnectionState.Closed)
                status_database.Text = "Pas de connexion";
            else if (e.CurrentState == ConnectionState.Open)
                status_database.Text = "Connecté (" + db.GetDbName() + ")";
        }

        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (db != null) db.Close();
            this.Close();
        }

        private void gérerLesConnexionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowConnectManager();
        }

        private void importSqlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            DialogResult dr = ofd.ShowDialog();

            if (File.Exists(ofd.FileName))
            {
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    tb_requete.Text = sr.ReadToEnd();

                    status_message.Text = "Fichier " + Path.GetFileName(ofd.FileName) + " importé";
                    Log("Fichier " + Path.GetFileName(ofd.FileName) + " importé");
                }
            }
        }

        private void exportCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportCSV();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cb_query.SelectedIndex > -1)
            {
                if (DialogResult.Yes == MessageBox.Show("Êtes vous sûr de supprimer cette requête ?", "Confirmation", MessageBoxButtons.YesNo))
                {
                    Requete r = (Requete)cb_query.SelectedItem;
                    QueryLauncher.dbconfig.Execute("DELETE FROM requete WHERE ROWID = " + r.Id);
                    cb_query.Items.RemoveAt(cb_query.SelectedIndex);
                    requetes.Remove(r);

                    status_message.Text = "Requête " + r.Nom + " supprimée";
                    Log("Requête " + r.Nom + " supprimée");
                }
            }
        }

        private void sauvegarderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String req = tb_requete.Text;

            String nom = PromptForQueryName();
            if (nom != null)
            {
                if (String.IsNullOrWhiteSpace(nom)) nom = "Req " + DateTime.Now.Ticks;

                QueryLauncher.dbconfig.Execute("INSERT INTO requete (nom, req) VALUES ('" + nom + "','" + req.Replace("'", "''") + "')");
                Int64 id = (Int64)QueryLauncher.dbconfig.ExecuteScalar("SELECT last_insert_rowid()");

                Requete r = new Requete { Id = id, Nom = nom, Req = req };
                requetes.Add(r);

                cb_query.Items.Add(r);
                status_message.Text = "Requête " + r.Nom + " sauvegardée";
                Log("Requête " + r.Nom + " sauvegardée");

            }
        }





        private void TestColor()
        {
            //keywords (intrustions)
            //fonctions
            //texte entre guillemets
            //operateurs ?
            //commentaire

            /*
            Red 	SQL string
            Dark green 	Comment
            Black on silver background 	SQLCMD command
            Magenta 	System function
            Green 	System table, view, or table-valued function. Also, the system schemas sys and INFORMATION_SCHEMA.
            Blue 	Keyword
            Teal 	Line numbers or template parameter
            Maroon 	SQL Server stored procedure
            Dark gray 	Operators
            */

            String KEYWORDS = "(ADD|ADD CONSTRAINT|ALTER|ALTER COLUMN|ALTER TABLE|ALL|AND|ANY|AS|ASC|BACKUP DATABASE|BETWEEN|CASE|CHECK|COLUMN|CONSTRAINT|CREATE|CREATE DATABASE|CREATE INDEX|CREATE OR REPLACE VIEW|CREATE TABLE|CREATE PROCEDURE|CREATE UNIQUE INDEX|CREATE VIEW|DATABASE|DEFAULT|DELETE|DESC|DISTINCT|DROP|DROP COLUMN|DROP CONSTRAINT|DROP DATABASE|DROP DEFAULT|DROP INDEX|DROP TABLE|DROP VIEW|EXEC|EXISTS|FOREIGN KEY|FROM|FULL OUTER JOIN|GROUP BY|HAVING|IN|INDEX|INNER JOIN|INSERT INTO|INSERT INTO SELECT|IS NULL|IS NOT NULL|JOIN|LEFT JOIN|LIKE|LIMIT|NOT|NOT NULL|OR|ORDER BY|OUTER JOIN|PRIMARY KEY|PROCEDURE|RIGHT JOIN|ROWNUM|SELECT|SELECT DISTINCT|SELECT INTO|SELECT TOP|SET|TABLE|TOP|TRUNCATE TABLE|UNION|UNION ALL|UNIQUE|UPDATE|VALUES|VIEW|WHERE)";
            String FUNCTIONS = "(ASCII|CHAR_LENGTH|CHARACTER_LENGTH|CONCAT|CONCAT_WS|FIELD|FIND_IN_SET|FORMAT|INSERT|INSTR|LCASE|LEFT|LENGTH|LOCATE|LOWER|LPAD|LTRIM|MID|POSITION|REPEAT|REPLACE|REVERSE|RIGHT|RPAD|RTRIM|SPACE|STRCMP|SUBSTR|SUBSTRING|SUBSTRING_INDEX|TRIM|UCASE|UPPER|ABS|ACOS|ASIN|ATAN|ATAN2|AVG|CEIL|CEILING|COS|COT|COUNT|DEGREES|DIV|EXP|FLOOR|GREATEST|LEAST|LN|LOG|LOG10|LOG2|MAX|MIN|MOD|PI|POW|POWER|RADIANS|RAND|ROUND|SIGN|SIN|SQRT|SUM|TAN|TRUNCATE|ADDDATE|ADDTIME|CURDATE|CURRENT_DATE|CURRENT_TIME|CURRENT_TIMESTAMP|CURTIME|DATE|DATEDIFF|DATE_ADD|DATE_FORMAT|DATE_SUB|DAY|DAYNAME|DAYOFMONTH|DAYOFWEEK|DAYOFYEAR|EXTRACT|FROM_DAYS|HOUR|LAST_DAY|LOCALTIME|LOCALTIMESTAMP|MAKEDATE|MAKETIME|MICROSECOND|MINUTE|MONTH|MONTHNAME|NOW|PERIOD_ADD|PERIOD_DIFF|QUARTER|SECOND|SEC_TO_TIME|STR_TO_DATE|SUBDATE|SUBTIME|SYSDATE|TIME|TIME_FORMAT|TIME_TO_SEC|TIMEDIFF|TIMESTAMP|TO_DAYS|WEEK|WEEKDAY|WEEKOFYEAR|YEAR|YEARWEEK|BIN|BINARY|CASE|CAST|COALESCE|CONNECTION_ID|CONV|CONVERT|CURRENT_USER|DATABASE|IF|IFNULL|ISNULL|LAST_INSERT_ID|NULLIF|SESSION_USER|SYSTEM_USER|USER|VERSION)";
            String DATATYPES = "(BIGINT|BINARY|BIT|CHAR|CHARACTER|DATETIME|DEC|DECIMAL|FLOAT|IMAGE|INT|INTEGER|MONEY|NCHAR|NTEXT|NUMERIC|NVARCHAR|REAL|SMALLDATETIME|SMALLINT|SMALLMONEY|SQL_VARIANT|SYSNAME|TEXT|TIMESTAMP|TINYINT|UNIQUEIDENTIFIER|VARBINARY|VARCHAR)";
            String OPERATORS = @"(+|-|*|/|%|=|!=|<|>|<>|<=|>=)";


            Regex rex = new Regex(KEYWORDS, RegexOptions.IgnoreCase);
            MatchCollection mc = rex.Matches(richTextBox1.Text);
            int StartCursorPosition = richTextBox1.SelectionStart;
            foreach (Match m in mc)
            {
                int startIndex = m.Index;
                int StopIndex = m.Length;
                richTextBox1.Select(startIndex, StopIndex);
                richTextBox1.SelectionColor = Color.Blue;
                richTextBox1.SelectionStart = StartCursorPosition;
                richTextBox1.SelectionColor = Color.Black;
            }

            rex = new Regex(FUNCTIONS, RegexOptions.IgnoreCase);
            mc = rex.Matches(richTextBox1.Text);
            StartCursorPosition = richTextBox1.SelectionStart;
            foreach (Match m in mc)
            {
                int startIndex = m.Index;
                int StopIndex = m.Length;
                richTextBox1.Select(startIndex, StopIndex);
                richTextBox1.SelectionColor = Color.Magenta;
                richTextBox1.SelectionStart = StartCursorPosition;
                richTextBox1.SelectionColor = Color.Black;
            }

            rex = new Regex(DATATYPES, RegexOptions.IgnoreCase);
            mc = rex.Matches(richTextBox1.Text);
            StartCursorPosition = richTextBox1.SelectionStart;
            foreach (Match m in mc)
            {
                int startIndex = m.Index;
                int StopIndex = m.Length;
                richTextBox1.Select(startIndex, StopIndex);
                richTextBox1.SelectionColor = Color.DarkGreen;
                richTextBox1.SelectionStart = StartCursorPosition;
                richTextBox1.SelectionColor = Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestColor();
        }

        private void b_utiliserRequete_Click(object sender, EventArgs e)
        {
            if (lb_history.SelectedIndex > -1)
            {
                if (rb_reader.Checked)
                    LaunchQueryReader(db, lb_history.Items[lb_history.SelectedIndex].ToString());
                else if (rb_scalar.Checked)
                    LaunchQueryScalar(db, lb_history.Items[lb_history.SelectedIndex].ToString());
                else if (rb_execute.Checked)
                    LaunchQueryExecute(db, lb_history.Items[lb_history.SelectedIndex].ToString());
            }
        }

        private void b_viderHistorique_Click(object sender, EventArgs e)
        {
            lb_history.Items.Clear();
        }
    }



    public class Requete
    {
        public Int64 Id { get; set; }
        public String Nom { get; set; }
        public String Req { get; set; }

        public override string ToString()
        {
            return Nom;
        }
    }

    public class SGBD
    {
        public String Nom { get; set; }
        public String DefaultConnectionString { get; set; }
        public String typeCS{ get; set; }

        public override string ToString()
        {
            return Nom;
        }
    }
}