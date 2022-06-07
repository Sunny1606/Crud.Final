using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CRUD2._0
{
    public class ConexionSql
    {      
        public static SqlConnection ObtenerConexion()
        {
            
            SqlConnection connection = new SqlConnection("Persist Security Info=False;User ID=sol;Password=sunny;Initial Catalog=DonneW;Data Source=DESKTOP-E2TI6DT\\SQLEXPRESS");
          
            connection.Open();
            return connection;
        }

    }
    
}