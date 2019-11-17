using System;

namespace SharpSQL
{
    public class Connexion
    {
        public Int64 Id { get; set; } //attention c'est le ROWID généré par SQLite
        public String Name { get; set; }
        public String Server { get; set; }
        public Int16 Port { get; set; }
        public String Login{ get; set; }
        public String Password { get; set; }
        public String Database { get; set; }
        public String Fichier { get; set; }
        public String SGBD { get; set; }
        public String ConnectionString { get; set; }

        
        public String DumpConnexion()
        {
            return "Connexion " + Name + " - " + SGBD + "\n"+
                "Server : " + Server + " : " + Port + "\n" +
                "Login : " + Login + " - " + Password + "\n" +
                "DB : " + Database + " - " + Fichier + "\n" +
                "Connection String : " + ConnectionString;
        }

        public override String ToString()
        {
            return Name + " (" + SGBD + ")";
        }

        public String BuildConnectionString()
        {
            String connectionString = "";
            SGBD s = QueryLauncher.sgbds[QueryLauncher.GetSGBD(SGBD)];

            connectionString = s.DefaultConnectionString.Replace("{server}", Server)
                                                .Replace("{login}", Login)
                                                .Replace("{password}", Password)
                                                .Replace("{database}", Database)
                                                .Replace("{port}", Port.ToString())
                                                .Replace("{fichier}", Fichier);

            return connectionString;
        }

    }
}
