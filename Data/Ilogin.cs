using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ws_prectoex.Models;

namespace Ws_prectoex.Data
{
    public class Ilogin : Conexion
    {

        public Login ConsultarLogin(string usuario, string pass)
        {
            Conectar4();
            Login login = new Login();
            try
            {
                SqlCommand cmd = new SqlCommand("SG_VALIDAR_USUARIO_WebService", cnn4);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cod_Usuario", usuario);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    login.Cod_Usuario = read["Cod_Usuario"].ToString();
                    login.Password = read["Password"].ToString();
                    login.Nom_Usuario = read["Nom_Usuario"].ToString();
                    login.Cod_Rol = read["Cod_Rol"].ToString();
                    login.Des_Rol = read["Des_Rol"].ToString();
                    login.Cod_Empresa = read["Cod_Empresa"].ToString();
                    login.Empresa = read["Empresa"].ToString();
                    login.Tip_Trabajador = read["Tip_Trabajador"].ToString();
                    login.Cod_Trabajador = read["Cod_Trabajador"].ToString();
                }
                if (login.Cod_Usuario.Trim() == (usuario.ToUpper()) && login.Password == pass.ToUpper())
                {
                    return login;
                }
                else
                {
                    throw new Exception("contraseña Errada ");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
            finally
            {
                Desconectar4();
            }
            // return login;
        }

    }
}
