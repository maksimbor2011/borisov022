using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace bor_brm
{
    internal class Database
    {
        public MySqlConnection cn;
        public void Connect()
        {
            cn = new MySqlConnection("Datasource = localhost;   port = 3306; username = root; password =; database = 182_borisov");
        }
    }

}
