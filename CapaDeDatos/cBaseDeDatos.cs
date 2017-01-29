using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CapaDeDatos
{

    public class cBaseDeDatos
    {
       MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder(); 
        
        public void Conectar()
        {
            builder.Server = "192.168.1.60";
            builder.UserID = "root";
            builder.Password = "root";
            builder.Database = "bdpersonal";
        }
        
    }
}
