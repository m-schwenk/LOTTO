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
            string cmdStr = "INSERT INTO `lottoschein`(`losNummer`, `laufZeit`, `samstagZiehung`, `mittwochZiehung`, `spiel77`, `super6`) VALUES (";
            cmdStr += lottoschein.Losnummer + ',';
            cmdStr += lottoschein.Laufzeit.ToString() + ',';
            cmdStr += lottoschein.Samstag.ToString() + ',';
            cmdStr += lottoschein.Mittwoch.ToString() + ',';
            cmdStr += lottoschein.spiel77.ToString() + ',';
            cmdStr += lottoschein.super6.ToString() + ");";
            _mySqlCommand.CommandText = cmdStr;
            if (_mySqlCommand.ExecuteNonQuery() > 0)
            {
                 _mySqlCommand.CommandText = "SELECT LAST_INSERT_ID();";
                MySqlDataReader reader = _mySqlCommand.ExecuteReader();
                reader.Read();
                int autoIDLottoschein = reader.GetInt32(0);
                reader.Close();
                string prefix = "INSERT INTO `ziehung`(`datum`, `istSamstag`) VALUES (";
                List<int> ziehungen = new List<int>();
                    
                foreach (DateTime date in lottoschein.Ziehungstermine)
                {
                    int id = SqlInsert(prefix + sqlDate(date) + ',' + (date.DayOfWeek == DayOfWeek.Saturday).ToString() + ");");
                    if (id > 0)
                    {
                        ziehungen.Add(id);
                    }
                }
                prefix = "INSERT INTO `gehoertzu`(`id_lottoschein`, `id_ziehung`) VALUES (" + autoIDLottoschein + ',';
                foreach (int autoIDZiehung in ziehungen)
                {
                    SqlInsert(prefix + autoIDZiehung + ");");
                }
                prefix =
                    "INSERT INTO `spiel`(`id_lottoschein`, `spielNummer`, `zahl1`, `zahl2`, `zahl3`, `zahl4`, `zahl5`, `zahl6`, `superZahl`) VALUES (" +
                    autoIDLottoschein + ',';
                foreach (KeyValuePair<int, SortedSet<int>> spiel in lottoschein.Spiele)
                {
                    string spielValues = spiel.Key.ToString() + ',';
                    foreach (int zahl in spiel.Value)
                    {
                        spielValues += zahl + ',';
                    }
                    spielValues += lottoschein.SuperZahl + ");";
                    SqlInsert(prefix + spielValues);
                }
            }
        }

        private string sqlDate(DateTime date)
        {
            return "'" + date.ToString("yyyy-MM-dd") + "'";
        }

        private int SqlInsert(string cmdStr)
        {
            int autoID = 0;
            _mySqlCommand.CommandText = cmdStr;
            if (_mySqlCommand.ExecuteNonQuery() > 0)
            {
                _mySqlCommand.CommandText = "SELECT LAST_INSERT_ID();";
                MySqlDataReader reader = _mySqlCommand.ExecuteReader();
                reader.Read();
                autoID = reader.GetInt32(0);
                reader.Close();
            }
            return autoID;
        }

        private void SqlUpdate(string cmdStr)
        {
            _mySqlCommand.CommandText = cmdStr;

            try
            {
                _mySqlCommand.ExecuteScalar();
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void SchreibeZiehungInDb(Ziehung ziehung)
        {
            //UPDATE `ziehung` SET 
            //`Zahl1`=[value-4],
            //`Zahl2`=[value-5],
            //`Zahl3`=[value-6],
            //`Zahl4`=[value-7],
            //`Zahl5`=[value-8],
            //`Zahl6`=[value-9],
            //`superZahl`=[value-10],
            //`spiel77`=[value-11],
            //`super6`=[value-12] 
            //WHERE ziehung.datum= ;

            // UPDATE ziehung SET `zahl1`=1,`zahl2`=2,`zahl3`=3,`zahl4`=4,`zahl5`=5,`zahl6`=6,`superZahl`=3 WHERE ziehung.datum='2016-10-01';
            // UPDATE ziehung SET `Zahl1`=1,`Zahl2`=2,`Zahl3`=3,`Zahl4`=4,`Zahl5`=5,`Zahl6`=6,`superZahl`=0 WHERE ziehung.datum='2016-09-30';

            string cmdStr = "UPDATE ziehung SET ";
            int i = 1;
            foreach (int zahl in ziehung.ZiehungsZahlen)
            {
                cmdStr += "`zahl" + i++ + "`=" + zahl + ',';
            }
            cmdStr += "`superZahl`=" + ziehung.Superzahl;// + ',';
//            cmdStr += "`spiel77`=" + ziehung.Spiel77 + ',';
//            cmdStr += "`super6`=" + ziehung.Super6;
            cmdStr += " WHERE ziehung.datum=" + sqlDate(ziehung.ZiehungsTag) + ';';
            SqlUpdate(cmdStr);
            return;
            _mySqlCommand.CommandText = cmdStr;
            if (_mySqlCommand.ExecuteNonQuery() > 0)
            {
                _mySqlCommand.CommandText = "SELECT LAST_INSERT_ID();";
                MySqlDataReader reader = _mySqlCommand.ExecuteReader();
                reader.Read();
                int autoID = reader.GetInt32(0);
                reader.Close();
                cmdStr ="INSERT INTO `ziehungszahlen`(`id_ziehung`, `zahl1`, `zahl2`, `zahl3`, `zahl4`, `zahl5`, `zahl6`, `superZahl`) VALUES (";
                cmdStr += autoID + ',';
                cmdStr += ziehung.Superzahl + ");";
                _mySqlCommand.CommandText = cmdStr;

            }
        }
    }
}
