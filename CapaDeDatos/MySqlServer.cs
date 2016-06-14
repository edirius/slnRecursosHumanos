using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CapaDeDatos
{
    public class MySqlServer:GDatos 
    {
        static readonly System.Collections.Hashtable ColComandos = new System.Collections.Hashtable();


        public override sealed string CadenaConexion
        {
            get
            {
                if (MCadenaConexion.Length == 0)
                {
                    if (MBase.Length != 0 && MServidor.Length != 0)
                    {
                        var sCadena = new System.Text.StringBuilder("");
                        sCadena.Append("Server=<SERVIDOR>;");
                        sCadena.Append("Database=<BASE>;");
                        sCadena.Append("Uid=<USER>;");
                        sCadena.Append("Pwd=<PASSWORD>;");
                       
                        sCadena.Replace("<SERVIDOR>", Servidor);
                        sCadena.Replace("<BASE>", Base);
                        sCadena.Replace("<USER>", Usuario);
                        sCadena.Replace("<PASSWORD>", Password);

                        return sCadena.ToString();
                    }
                    throw new Exception("No se puede establecer la cadena de conexión en la clase DatosSQLServer");
                }
                return MCadenaConexion = CadenaConexion;

            }// end get
            set
            { MCadenaConexion = value; } // end set
        }// end CadenaConexion

         /*	
         * Agregue ahora la definición del procedimiento CargarParametros, el cual deberá asignar cada valor 
         * al parámetro que corresponda (considerando que, en el caso de SQLServer©, el parameter 0 
         * siempre corresponde al “return Value” del Procedimiento Almacenado). Por otra parte, en algunos casos,
         * como la ejecución de procedimientos almacenados que devuelven un valor como parámetro de salida, 
         * la cantidad de elementos en el vector de argumentos, puede no corresponder con la cantidad de parámetros. 
         * Por ello, se decide comparar el indicador con la cantidad de argumentos recibidos, antes de asignar el valor.
         * protected override void CargarParametros(System.Data.IDbCommand Com, System.Object[] Args)
         */
        protected override void CargarParametros(System.Data.IDbCommand com, Object[] args)
        {
            for (int i = 1; i <= com.Parameters.Count; i++)
            {
                var p = (MySql.Data.MySqlClient.MySqlParameter)com.Parameters[i-1];
                p.Value = i <= args.Length ? args[i - 1] ?? DBNull.Value  : null;
            } // end for
        } // end CargarParametros
 
 
        /*
         * En el procedimiento Comando, se buscará primero si ya existe el comando en dicha Hashtable para retornarla 
         * (convertida en el tipo correcto). Caso contrario, se procederá a la creación del mismo, 
         * y su agregado en el repositorio. Dado que cabe la posibilidad de que ya estemos dentro de una transacción,
         * es necesario abrir una segunda conexión a la base de datos, para obtener la definición de los parámetros 
         * del procedimiento Almacenado (caso contrario da error, por intentar leer sin tener asignado el
         * objeto Transaction correspondiente). Además, el comando, obtenido por cualquiera de los mecanismos 
         * debe recibir la conexión y la transacción correspondientes (si no hay Transacción, la variable es null, 
         * y ese es el valor que se le pasa al objeto Command)
         */
        protected override System.Data.IDbCommand Comando(string procedimientoAlmacenado)
        {
            MySql.Data.MySqlClient.MySqlCommand com;
            if (ColComandos.Contains(procedimientoAlmacenado))
                com = (MySql.Data.MySqlClient.MySqlCommand)ColComandos[procedimientoAlmacenado];
            else
            {
                var con2 = new MySql.Data.MySqlClient.MySqlConnection(CadenaConexion);
                con2.Open();
                com = new MySql.Data.MySqlClient.MySqlCommand(procedimientoAlmacenado, con2) { CommandType = System.Data.CommandType.StoredProcedure };
                MySql.Data.MySqlClient.MySqlCommandBuilder.DeriveParameters(com);
                con2.Close();
                con2.Dispose();
                ColComandos.Add(procedimientoAlmacenado, com);
            }//end else
            com.Connection = (MySql.Data.MySqlClient.MySqlConnection)Conexion;
            com.Transaction = (MySql.Data.MySqlClient.MySqlTransaction)MTransaccion;
            return com;
        }// end Comando
 
        protected override System.Data.IDbCommand ComandoSql(string comandoSql)
        {
            var com = new MySql.Data.MySqlClient.MySqlCommand(comandoSql, (MySql.Data.MySqlClient.MySqlConnection)Conexion, (MySql.Data.MySqlClient.MySqlTransaction)MTransaccion);
            return com;
        }// end Comando
 
 
        /* 
         * Luego implementaremos CrearConexion, donde simplemente se devuelve una nueva instancia del 
         * objeto Conexión de SqlClient, utilizando la cadena de conexión del objeto.
         */
        protected override System.Data.IDbConnection CrearConexion(string cadenaConexion)
        { return new MySql.Data.MySqlClient.MySqlConnection(cadenaConexion); }
 
 
        //Finalmente, es el turno de definir CrearDataAdapter, el cual aprovecha el método Comando para crear el comando necesario.
        protected override System.Data.IDataAdapter CrearDataAdapter(string procedimientoAlmacenado, params Object[] args)
        {
            var da = new MySql.Data.MySqlClient.MySqlDataAdapter((MySql.Data.MySqlClient.MySqlCommand)Comando(procedimientoAlmacenado));
            if (args.Length != 0)
                CargarParametros(da.SelectCommand, args);
            return da;
        } // end CrearDataAdapter
 
        //Finalmente, es el turno de definir CrearDataAdapter, el cual aprovecha el método Comando para crear el comando necesario.
        protected override System.Data.IDataAdapter CrearDataAdapterSql(string comandoSql)
        {
            var da = new MySql.Data.MySqlClient.MySqlDataAdapter((MySql.Data.MySqlClient.MySqlCommand)ComandoSql(comandoSql));
            return da;
        } // end CrearDataAdapterSql
 
        /*
         * Definiremos dos constructores especializados, uno que reciba como argumentos los valores de Nombre del Servidor 
         * y de base de datos que son necesarios para acceder a datos, y otro que admita directamente la cadena de conexión completa.
         * Los constructores se definen como procedimientos públicos de nombre New.
         */
        public MySqlServer()
        {
            Base = "";
            Servidor = "";
            Usuario = "";
            Password = "";
        }// end DatosSQLServer
 
 
        public MySqlServer(string cadenaConexion)
        { CadenaConexion = cadenaConexion; }// end DatosSQLServer
 
 
        public MySqlServer(string servidor, string @base)
        {
            Base = @base;
            Servidor = servidor;
        }// end DatosSQLServer
 
 
        public MySqlServer(string servidor, string @base, string usuario, string password)
        {
            Base = @base;
            Servidor = servidor;
            Usuario = usuario;
            Password = password;
        }// end DatosSQLServer
    }// end class DatosSQLServer
}
 
