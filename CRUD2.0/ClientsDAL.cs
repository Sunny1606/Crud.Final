using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CRUD2._0
{
    public class ClientsDAL
    {
        public static int Agregar(Clients pClients)
        {
            int retorno = 0;
            using (SqlConnection connection = ConexionSql.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(string.Format(@"INSERT INTO ContactsDONNE (Name, LastName, Treatment , Phone) Values ('{0}' ,'{1}' , '{2}' , '{3}')",
                    pClients.Name, pClients.LastName, pClients.Treatment, pClients.Phone), connection);

                retorno = command.ExecuteNonQuery();
                connection.Close();
            }
            return retorno;

        }
        public static List<Clients> BuscaClientes(string pName, string pLastName)
        {
            List<Clients> Lista = new List<Clients>();
            using (SqlConnection connection = ConexionSql.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(string.Format("Select Id, Name, LastName , Treatment , Phone from ContactsDONNE where Name like '%{0}%' and LastName like '%{1}%'", pName, pLastName), connection);

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    {
                        Clients pClients = new Clients();
                        pClients.Id = dataReader.GetInt32(0);
                        pClients.Name = dataReader.GetString(1);
                        pClients.LastName = dataReader.GetString(2);
                        pClients.Treatment = dataReader.GetString(3);
                        pClients.Phone = Convert.ToString(dataReader.GetString(4));

                        Lista.Add(pClients);
                    }
                }
                connection.Close();
                return Lista;
            }
        }
        public static Clients ObtenerCliente(Int64 pId)
        {
            using (SqlConnection connection = ConexionSql.ObtenerConexion())
            {
                Clients pClients = new Clients();
                SqlCommand command = new SqlCommand(string.Format("Select Id, Name, LastName , Treatment , Phone from ContactsDONNE where Id = {0} ", pId), connection);

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    {
                        pClients.Id = dataReader.GetInt32(0);
                        pClients.Name = dataReader.GetString(1);
                        pClients.LastName = dataReader.GetString(2);
                        pClients.Treatment = dataReader.GetString(3);
                        pClients.Phone = Convert.ToString(dataReader.GetString(4));

                    }
                }
                connection.Close();
                return pClients;
            }
        }
        public static int Modificar(Clients pClient)
        {
            int retorno = 0;
            using (SqlConnection connection = ConexionSql.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(string.Format("Update ContactsDONNE set Name='{0}', LastName='{1}', Treatment='{2}', Phone='{3}' where Id= '{4}'",
                    pClient.Name, pClient.LastName, pClient.Treatment, pClient.Phone, pClient.Id), connection);

                retorno = command.ExecuteNonQuery();
                connection.Close();
            }
            return retorno;
        }
        public static Clients Obtenercliente(Int64 pId)
        {
            Clients pClients = new Clients();
            using (SqlConnection connection = ConexionSql.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(string.Format("Select Id, Name, LastName , Treatment , Phone from ContactsDONNE where Id= {0}", pId), connection);

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    {
                        pClients.Id = dataReader.GetInt32(0);
                        pClients.Name = dataReader.GetString(1);
                        pClients.LastName = dataReader.GetString(2);
                        pClients.Treatment = dataReader.GetString(3);
                        pClients.Phone = Convert.ToString(dataReader.GetString(4));
                    }
                }
                connection.Close();
                return pClients;
            }
        }
        public static int Delete(Int64 pId)
        {
            int retorno = 0;
            using (SqlConnection connection = ConexionSql.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(string.Format("Delete from ContactsDONNE where Id = {0}", pId), connection);

                retorno = command.ExecuteNonQuery();
                connection.Close();
            }
            return retorno;

        }
    }
}