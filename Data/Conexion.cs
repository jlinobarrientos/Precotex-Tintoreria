using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ws_prectoex.Data
{
    public class Conexion
    {
        protected SqlConnection cnn;

        protected SqlConnection cnn2;
        protected SqlConnection cnn3;

        protected SqlConnection cnn4;

        //private string ds = "192.168.1.37";
        //private string db = "PRECOTEX_TEXTIL_120722";


        private string ds="192.168.1.9";
        private string db = "PRECOTEX_TEXTIL";

        //private string ds2 = "192.168.1.37";
        //private string db2 = "PRECOTEX_TEXTIL_160624";

        private string ds2 = "192.168.1.37";
        private string db2 = "HUA";


        protected void Conectar4()
        {
            try
            {
               // cnn4 = new SqlConnection("Data Source=192.168.1.37;Initial Catalog=PRECOTEX_TEXTIL_120722; User ID=userWs;Password=Prec0tex2022");
                //Data Source=192.168.1.9;Initial Catalog=PRECOTEX_TEXTIL; User 
                cnn4 = new SqlConnection("Data Source=192.168.1.9;Initial Catalog=PRECOTEX_TEXTIL; User ID=userWs;Password=Prec0tex2022");

                cnn4.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                //  throw;
            }

        }



        protected void Conectar()
        {
            try
            {
                //cnn = new SqlConnection("Data Source=192.168.1.9;Initial Catalog=PRECOTEX_TEXTIL; User ID=userWs;Password=Prec0tex2022");

                cnn = new SqlConnection("Data Source="+ds+";Initial Catalog="+db+"; User ID=userWs;Password=Prec0tex2022");

                cnn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                //  throw;
            }

        }
        protected void Conectar2()
        {
            try
            {
                //cnn = new SqlConnection("Data Source=192.168.1.9;Initial Catalog=PRECOTEX_TEXTIL; User ID=userWs;Password=Prec0tex2022");

                //cnn2 = new SqlConnection("Data Source=" + ds2 + ";Initial Catalog=" + db2 + "; User ID=userWs;Password=Pr3c0t3x");
                cnn2 = new SqlConnection("Data Source=" + ds2 + ";Initial Catalog=" + db2 + ";Integrated Security=SSPI;");
                
                                

                cnn2.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                //  throw;
            }

        }

      


        // produccion
        protected void Conectar3()
        {
            try
            {
                //cnn = new SqlConnection("Data Source=192.168.1.9;Initial Catalog=PRECOTEX_TEXTIL; User ID=userWs;Password=Prec0tex2022");

                cnn3 = new SqlConnection("Data Source=" + ds + ";Initial Catalog=" + db + "; User ID=userWs;Password=Prec0tex2022");

                cnn3.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                //  throw;
            }

        }
        protected void Desconectar()
        {
            try
            {
                
                    cnn.Close();
               
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                //  throw;
            }

        }

        protected void Desconectar2()
        {
            try
            {
              
                cnn2.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                //  throw;
            }

        }

        //Produccion
        protected void Desconectar3()
        {
            try
            {

                cnn3.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                //  throw;
            }

        }


        //Produccion
        protected void Desconectar4()
        {
            try
            {

                cnn4.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                //  throw;
            }

        }
    }
}
