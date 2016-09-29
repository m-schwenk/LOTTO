using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Lotto
{
    // ReSharper disable InconsistentNaming
    class MySQL_Adapter : IDatabaseAdapter
    {

        private MySqlConnection _dbConnection;
        
        private string _server = "localhost";
        private string _user = "root";
        private string _password = ""; //f4XArGwnryQRSm55
        private string _database = "lotto";
        private MySqlCommand _mySqlCommand;

        public string Server
        {
            get { return "Server=" + _server + ";"; }
            set { _server = value; }
        }

        public string User
        {
            get { return "user=" + _user + ";"; }
            set { _user = value; }
        }

        public string Password
        {
            get { return "Pwd=" + _password + ";"; }
            set { _password = value; }
        }

        public string Database
        {
            get { return "Database=" + _database + ";"; }
            set { _database = value; }
        }

        public MySQL_Adapter()
        {
            _dbConnection = new MySqlConnection(Server + User + Password + Database);
            try
            {
                _dbConnection.Open();
                _mySqlCommand = new MySqlCommand() { Connection = _dbConnection };

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ~MySQL_Adapter()
        {
            _dbConnection.Close();
        }
        
        // http://dev.mysql.com/doc/connector-net/en/connector-net-tutorials.html
        public Lottoschein LeseLottoscheinAusDb()
        {
            MySqlCommand cmd = new MySqlCommand("");
            throw new NotImplementedException();
        }

        public void SchreibeLottoscheinInDb(Lottoschein lottoschein)
        {
            throw new NotImplementedException();
        }

        public void SchreibeZiehungInDb(Ziehung ziehung)
        {
            string cmdStr = "INSERT INTO `ziehung`(`datum`, `istSamstag`, `spiel77`, `super6`) VALUES (";
            // 2016-09-28,true,1234567,123456)"
            cmdStr += "'" + ziehung.ZiehungsTag.ToString("yyyy-MM-dd") + "',";
            cmdStr += (ziehung.ZiehungsTag.DayOfWeek == DayOfWeek.Saturday).ToString().ToLower() +',';
            cmdStr += ziehung.Spiel77 +',';
            cmdStr += ziehung.Super6 + ");";
            // 		CommandText	"INSERT INTO `ziehung`(`datum`, `istSamstag`, `spiel77`, `super6`) VALUES (2016-09-29,false,,"	string
            _mySqlCommand.CommandText = cmdStr;
            if (_mySqlCommand.ExecuteNonQuery() > 0)
            {
                _mySqlCommand.CommandText = "SELECT LAST_INSERT_ID();";
                MySqlDataReader reader = _mySqlCommand.ExecuteReader();
                reader.Read();
                int autoID = reader.GetInt32(0);
                MessageBox.Show(autoID.ToString());
                reader.Close();
            }
        }
    }
}
