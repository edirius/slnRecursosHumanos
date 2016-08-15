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
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "root";
            builder.Database = "bdpersonal";
        }
        
    }
}
