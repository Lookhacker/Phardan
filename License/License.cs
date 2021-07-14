using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace License
{
    public class ServerConfig
    {
        private static string UserID;
        private static string UserPassword;
        private static string DataBaseName;
        private static string _ConnectionString;
        public string ConnectionString
        {
            get { return _ConnectionString; }
            set
            {
                ConnectionString = _ConnectionString;
            }
        }

        public string ServerName { get; set; } 
        
        public string ServerTest(string Address)
        {
            Address= Address.ToLower();
            if (Address == "local" || Address == "(local)" || Address == ".")
            {
                return "Data Source=(local);Initial Catalog=" + DataBaseName + ";Integrated Security=True";
            }
            else
            {
                ServerName = Address;
                return "Data Source=" + ServerName + ";Initial Catalog=" + DataBaseName + ";User ID=" + UserID + ";Password=" + UserPassword + ";";
            }

        }
        public void FirstRun()
        {
            UserID = "1";
            UserPassword = "1";
            DataBaseName = "PDB";
            string T = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string Text = File.ReadAllText(T + "\\Setting.mmp").ToLower();
            if (Text == "local" || Text == "(local)" || Text == ".")
            {
                _ConnectionString = "Data Source=(local);Initial Catalog=" + DataBaseName + ";Integrated Security=True";
            }
            else
            {
                ServerName = Text;
                _ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + DataBaseName + ";User ID=" + UserID + ";Password=" + UserPassword + ";";
            }
        }


    }
}
