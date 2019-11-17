using System;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data;
using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using VistaDB.Provider;
using IBM.Data.DB2;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using Newtonsoft.Json;

namespace SharpSQL
{
    public interface IDatabase
    {
        Boolean Connected { get; }
        String LastError { get; }
        Int64 LastInsertId { get; }
        String ConnectionString { get; }
        StateChangeEventHandler StateChange { get; set; }

        String GetDbName();

        DataSet ReadData(String sql);

        Int32 Execute(String sql);

        Object ExecuteScalar(String sql);

        void Close();
    }


    public class SQLite : IDatabase
    {
        private String _lastError = "";
        public String LastError { get { return _lastError; } }
        public Boolean Connected { get { return co.State == ConnectionState.Open; } }
        public String ConnectionString { get { return co.ConnectionString; } }
        public ConnectionState ConnectionState { get { return co.State; } }
        public StateChangeEventHandler StateChange { get; set; }

        public Int64 LastInsertId { get { return co.LastInsertRowId; } }

        SQLiteConnection co = new SQLiteConnection();


        public SQLite(String connectionString)
        {
            co.ConnectionString = connectionString;
            try
            {
                co.Open();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }
        }


        public String GetDbName()
        {
            return co.Database;
        }

        public DataSet ReadData(String sql)
        {
            SQLiteCommand cmd = new SQLiteCommand(sql, co);
            DataSet data = new DataSet();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, co);

            try
            {
                adapter.Fill(data);
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return data;
        }


        public int Execute(String sql)
        {
            int rows = 0;
            SQLiteCommand cmd = new SQLiteCommand(sql, co);

            try
            {
                rows = cmd.ExecuteNonQuery();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return rows;
        }


        public Object ExecuteScalar(String sql)
        {
            Object o = null;
            SQLiteCommand cmd = new SQLiteCommand(sql, co);

            try
            {
                o = cmd.ExecuteScalar();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return o;
        }


        public void Close()
        {
            co.Close();
        }
    }


    public class MsSql : IDatabase
    {
        private String _lastError = "";
        public String LastError { get { return _lastError; } }
        public Boolean Connected { get { return co.State == ConnectionState.Open; } }
        public String ConnectionString { get { return co.ConnectionString; } }
        public ConnectionState ConnectionState { get { return co.State; } }
        public StateChangeEventHandler StateChange { get; set; }

        public Int64 LastInsertId { get {
                return (Int64)ExecuteScalar("SELECT SCOPE_IDENTITY()");
            } }

        SqlConnection co = new SqlConnection();


        public MsSql(String connectionString)
        {
            co.ConnectionString = connectionString;

            try
            {
                co.Open();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }
        }

        public String GetDbName()
        {
            return co.Database;
        }

        public DataSet ReadData(String sql)
        {
            SqlCommand cmd = new SqlCommand(sql, co);
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, co);

            try
            {
                adapter.Fill(data);
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return data;
        }


        public int Execute(String sql)
        {
            int rows = 0;
            SqlCommand cmd = new SqlCommand(sql, co);

            try
            {
                rows = cmd.ExecuteNonQuery();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return rows;
        }        


        public Object ExecuteScalar(String sql)
        {
            SqlCommand cmd = new SqlCommand(sql, co);
            Object o = null;

            try
            {
                o = cmd.ExecuteScalar();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return o;
        }


        public void Close()
        {
            co.Close();
        }
    }


    public class MySql : IDatabase
    {
        private String _lastError = "";
        public String LastError { get { return _lastError; } }
        public Boolean Connected { get { return co.State == ConnectionState.Open; } }
        public String ConnectionString { get { return co.ConnectionString; } }
        public ConnectionState ConnectionState { get { return co.State; } }
        public StateChangeEventHandler StateChange { get; set; }

        public Int64 LastInsertId
        {
            get
            {
                return (Int64)ExecuteScalar("SELECT LAST_INSERT_ID();");
            }
        }

        MySqlConnection co = new MySqlConnection();


        public MySql(String connectionString)
        {
            co.ConnectionString = connectionString;

            try
            {
                co.Open();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }
        }

        public String GetDbName()
        {
            return co.Database;
        }

        public DataSet ReadData(String sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, co);
            DataSet data = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, co);


            try
            {
                adapter.Fill(data);
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return data;
        }


        public int Execute(String sql)
        {
            int rows = 0;
            MySqlCommand cmd = new MySqlCommand(sql, co);

            try
            {
                rows = cmd.ExecuteNonQuery();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return rows;
        }

        public Object ExecuteScalar(String sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, co);
            Object o = null;

            try
            {
                o = cmd.ExecuteScalar();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return o;
        }


        public void Close()
        {
            co.Close();
        }
    }


    public class Postgre : IDatabase
    {
        private String _lastError = "";
        public String LastError { get { return _lastError; } }
        public Boolean Connected { get { return co.State == ConnectionState.Open; } }
        public String ConnectionString { get { return co.ConnectionString; } }
        public ConnectionState ConnectionState { get { return co.State; } }
        public StateChangeEventHandler StateChange { get; set; }

        public Int64 LastInsertId
        {
            get
            {
                return 0;
            }
        }


        NpgsqlConnection co = new NpgsqlConnection();


        public Postgre(String connectionString)
        {
            co.ConnectionString = connectionString;

            try
            {
                co.Open();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }
        }

        public String GetDbName()
        {
            return co.Database;
        }

        public DataSet ReadData(String sql)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(sql, co);
            DataSet data = new DataSet();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, co);

            try
            {
                adapter.Fill(data);
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return data;
        }


        public int Execute(String sql)
        {
            int rows = 0;
            NpgsqlCommand cmd = new NpgsqlCommand(sql, co);

            try
            {
                rows = cmd.ExecuteNonQuery();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return rows;
        }

        public Object ExecuteScalar(String sql)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(sql, co);
            Object o = null;

            try
            {
                o = cmd.ExecuteScalar();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return o;
        }



        public void Close()
        {
            co.Close();
        }
    }


    public class Oracle : IDatabase
    {
        private String _lastError = "";
        public String LastError { get { return _lastError; } }
        public Boolean Connected { get { return co.State == ConnectionState.Open; } }
        public String ConnectionString { get { return co.ConnectionString; } }
        public ConnectionState ConnectionState { get { return co.State; } }
        public StateChangeEventHandler StateChange { get; set; }

        public Int64 LastInsertId
        {
            get
            {
                return 0;
            }
        }


        OracleConnection co = new OracleConnection();


        public Oracle(String connectionString)
        {
            co.ConnectionString = connectionString;

            try
            {
                co.Open();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }
        }

        public String GetDbName()
        {
            return co.Database;
        }

        public DataSet ReadData(String sql)
        {
            OracleCommand cmd = new OracleCommand(sql, co);
            DataSet data = new DataSet();
            OracleDataAdapter adapter = new OracleDataAdapter(sql, co);

            try
            {
                adapter.Fill(data);
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return data;
        }


        public int Execute(String sql)
        {
            int rows = 0;
            OracleCommand cmd = new OracleCommand(sql, co);

            try
            {
                rows = cmd.ExecuteNonQuery();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return rows;
        }

        public Object ExecuteScalar(String sql)
        {
            OracleCommand cmd = new OracleCommand(sql, co);
            Object o = null;

            try
            {
                o = cmd.ExecuteScalar();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return o;
        }



        public void Close()
        {
            co.Close();
        }
    }


    public class OleDB : IDatabase
    {
        private String _lastError = "";
        public String LastError { get { return _lastError; } }
        public Boolean Connected { get { return co.State == ConnectionState.Open; } }
        public String ConnectionString { get { return co.ConnectionString; } }
        public ConnectionState ConnectionState { get { return co.State; } }
        public StateChangeEventHandler StateChange { get; set; }

        public Int64 LastInsertId
        {
            get
            {
                return 0;
            }
        }


        OleDbConnection co = new OleDbConnection();


        public OleDB(String connectionString)
        {
            co.ConnectionString = connectionString;

            try
            {
                co.Open();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }
        }

        public String GetDbName()
        {
            return co.Database;
        }

        public DataSet ReadData(String sql)
        {
            OleDbCommand cmd = new OleDbCommand(sql, co);
            DataSet data = new DataSet();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, co);

            try
            {
                adapter.Fill(data);
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return data;
        }


        public int Execute(String sql)
        {
            int rows = 0;
            OleDbCommand cmd = new OleDbCommand(sql, co);

            try
            {
                rows = cmd.ExecuteNonQuery();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return rows;
        }

        public Object ExecuteScalar(String sql)
        {
            OleDbCommand cmd = new OleDbCommand(sql, co);
            Object o = null;

            try
            {
                o = cmd.ExecuteScalar();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return o;
        }



        public void Close()
        {
            co.Close();
        }
    }


    public class ODBC : IDatabase
    {
        private String _lastError = "";
        public String LastError { get { return _lastError; } }
        public Boolean Connected { get { return co.State == ConnectionState.Open; } }
        public String ConnectionString { get { return co.ConnectionString; } }
        public ConnectionState ConnectionState { get { return co.State; } }
        public StateChangeEventHandler StateChange { get; set; }

        public Int64 LastInsertId
        {
            get
            {
                return 0;
            }
        }


        OdbcConnection co = new OdbcConnection();


        public ODBC(String connectionString)
        {
            co.ConnectionString = connectionString;

            try
            {
                co.Open();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }
        }

        public String GetDbName()
        {
            return co.Database;
        }

        public DataSet ReadData(String sql)
        {
            OdbcCommand cmd = new OdbcCommand(sql, co);
            DataSet data = new DataSet();
            OdbcDataAdapter adapter = new OdbcDataAdapter(sql, co);

            try
            {
                adapter.Fill(data);
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return data;
        }


        public int Execute(String sql)
        {
            int rows = 0;
            OdbcCommand cmd = new OdbcCommand(sql, co);

            try
            {
                rows = cmd.ExecuteNonQuery();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return rows;
        }

        public Object ExecuteScalar(String sql)
        {
            OdbcCommand cmd = new OdbcCommand(sql, co);
            Object o = null;

            try
            {
                o = cmd.ExecuteScalar();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return o;
        }



        public void Close()
        {
            co.Close();
        }
    }


    public class VistaDB : IDatabase
    {
        private String _lastError = "";
        public String LastError { get { return _lastError; } }
        public Boolean Connected { get { return co.State == ConnectionState.Open; } }
        public String ConnectionString { get { return co.ConnectionString; } }
        public ConnectionState ConnectionState { get { return co.State; } }
        public StateChangeEventHandler StateChange { get; set; }

        public Int64 LastInsertId
        {
            get
            {
                return 0;
            }
        }


        VistaDBConnection co = new VistaDBConnection();


        public VistaDB(String connectionString)
        {
            co.ConnectionString = connectionString;

            try
            {
                co.Open();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }
        }

        public String GetDbName()
        {
            return co.Database;
        }

        public DataSet ReadData(String sql)
        {
            VistaDBCommand cmd = new VistaDBCommand(sql, co);
            DataSet data = new DataSet();
            VistaDBDataAdapter adapter = new VistaDBDataAdapter(sql, co);

            try
            {
                adapter.Fill(data);
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return data;
        }


        public int Execute(String sql)
        {
            int rows = 0;
            VistaDBCommand cmd = new VistaDBCommand(sql, co);

            try
            {
                rows = cmd.ExecuteNonQuery();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return rows;
        }

        public Object ExecuteScalar(String sql)
        {
            VistaDBCommand cmd = new VistaDBCommand(sql, co);
            Object o = null;

            try
            {
                o = cmd.ExecuteScalar();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return o;
        }



        public void Close()
        {
            co.Close();
        }
    }


    public class DB2 : IDatabase
    {
        private String _lastError = "";
        public String LastError { get { return _lastError; } }
        public Boolean Connected { get { return co.State == ConnectionState.Open; } }
        public String ConnectionString { get { return co.ConnectionString; } }
        public ConnectionState ConnectionState { get { return co.State; } }
        public StateChangeEventHandler StateChange { get; set; }

        public Int64 LastInsertId
        {
            get
            {
                return 0;
            }
        }


        DB2Connection co = new DB2Connection();


        public DB2(String connectionString)
        {
            co.ConnectionString = connectionString;

            try
            {
                co.Open();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }
        }

        public String GetDbName()
        {
            return co.Database;
        }

        public DataSet ReadData(String sql)
        {
            DB2Command cmd = new DB2Command(sql, co);
            DataSet data = new DataSet();
            DB2DataAdapter adapter = new DB2DataAdapter(sql, co);

            try
            {
                adapter.Fill(data);
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return data;
        }


        public int Execute(String sql)
        {
            int rows = 0;
            DB2Command cmd = new DB2Command(sql, co);

            try
            {
                rows = cmd.ExecuteNonQuery();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return rows;
        }

        public Object ExecuteScalar(String sql)
        {
            DB2Command cmd = new DB2Command(sql, co);
            Object o = null;

            try
            {
                o = cmd.ExecuteScalar();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return o;
        }



        public void Close()
        {
            co.Close();
        }
    }


    public class Firebird : IDatabase
    {
        private String _lastError = "";
        public String LastError { get { return _lastError; } }
        public Boolean Connected { get { return co.State == ConnectionState.Open; } }
        public String ConnectionString { get { return co.ConnectionString; } }
        public ConnectionState ConnectionState { get { return co.State; } }
        public StateChangeEventHandler StateChange { get; set; }

        public Int64 LastInsertId
        {
            get
            {
                return 0;
            }
        }


        FbConnection co = new FbConnection();

        public Firebird(String connectionString)
        {
            co.ConnectionString = connectionString;

            try
            {
                co.Open();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }
        }

        public String GetDbName()
        {
            return co.Database;
        }

        public DataSet ReadData(String sql)
        {
            FbCommand cmd = new FbCommand(sql, co);
            DataSet data = new DataSet();
            FbDataAdapter adapter = new FbDataAdapter(sql, co);

            try
            {
                adapter.Fill(data);
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return data;
        }


        public int Execute(String sql)
        {
            int rows = 0;
            FbCommand cmd = new FbCommand(sql, co);

            try
            {
                rows = cmd.ExecuteNonQuery();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return rows;
        }

        public Object ExecuteScalar(String sql)
        {
            FbCommand cmd = new FbCommand(sql, co);
            Object o = null;

            try
            {
                o = cmd.ExecuteScalar();
                _lastError = "";
            }
            catch (Exception e)
            {
                _lastError = e.Message;
            }

            return o;
        }



        public void Close()
        {
            co.Close();
        }
    }


    public class JSON
    {
        private String _lastError = "";
        public String LastError { get { return _lastError; } }

        private String filename;

        public JSON(String filename)
        {
            if (File.Exists(filename))
            {
                this.filename = filename;
                _lastError = "";
            }
            else
            {
                _lastError = "Fichier " + filename + " non trouvé";
            }
        }

        public DataSet ReadData()
        {
            DataSet data = new DataSet();
            String json = "";

            using (StreamReader sr = new StreamReader(filename))
            {
                json = sr.ReadToEnd();
            }

            DataTable dt = data.Tables.Add();
            dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

            return data;
        }
    }

    public class XML
    {
        private String _lastError = "";
        public String LastError { get { return _lastError; } }

        private String filename;

        public XML(String filename)
        {
            if (File.Exists(filename))
            {
                this.filename = filename;
                _lastError = "";
            }
            else
            {
                _lastError = "Fichier " + filename + " non trouvé";
            }

        }

        public DataSet ReadData()
        {
            DataSet data = new DataSet();
            data.ReadXml(filename);
            return data;
        }


    }


    public class CSV
    {
        private String _lastError = "";
        public String LastError { get { return _lastError; } }

        private String filename;

        public CSV(String filename)
        {
            if (File.Exists(filename))
            {
                this.filename = filename;
                _lastError = "";
            }
            else
            {
                _lastError = "Fichier " + filename + " non trouvé";
            }
        }


        public DataSet ReadData()
        {
            DataSet data = new DataSet();
            DataTable dt = data.Tables.Add();

            using (StreamReader sr = new StreamReader(filename))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] tab = line.Split(new char[] { ';' });
                    dt.Rows.Add(tab);
                }
            }

            return data;
        }
    }
}