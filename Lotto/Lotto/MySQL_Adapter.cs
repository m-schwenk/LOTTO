using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Lotto
{
    // ReSharper disable InconsistentNaming
    class MySQL_Adapter : IDatabaseAdapter
    {

        private MySqlConnection _dbConnection;
        
        private string _server = "127.0.0.1";
        private string _user = "root";
        private string _password = "";
        private string _database;

        public string Server
        {
            get { return "Server=" + _server + ";"; }
            set { _server = value; }
        }

        public string User
        {
            get { return "Uid=" + _user + ";"; }
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
            _dbConnection = new MySqlConnection();
        }
        
        // http://dev.mysql.com/doc/connector-net/en/connector-net-tutorials.html
        public Lottoschein LeseLottoscheinAusDb()
        {
            throw new NotImplementedException();
        }

        public void SchreibeLottoscheinInDb(Lottoschein lottoschein)
        {
            throw new NotImplementedException();
        }

        public void SchreibeZiehungInDb(Ziehung ziehung)
        {
            throw new NotImplementedException();
        }
    }
}
