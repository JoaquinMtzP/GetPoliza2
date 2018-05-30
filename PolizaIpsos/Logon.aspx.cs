using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;

namespace PolizaIpsos
{
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
                        
            
// Valida Ldap
            if(ValidateLdap(this.User.Text,this.Pass.Text))
            {
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(User.Text, false);
                
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Verifique su usuario y/o contraseña";
            }

 //Verifica contra la base de datos
            SqlConnection con = new SqlConnection { ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbUserConnectionString"].ConnectionString };
            try
            {
                con.Open();
                lblError.Text = "Conexión a la base de datos con éxito";
            }
            catch
            {
                lblError.Text = "Error al cargar la base de datos";

            }

          
            SqlCommand cmd = new SqlCommand($"SELECT Usuario, Nombre, ApellidoPaterno, ApellidoMaterno, email, idRol, Activo FROM TblForUserSystem WHERE (Activo = 1) AND Usuario = '{User.Text}'",con);

            
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "TblForUserSystem");

            DataRow drow;

            drow = ds.Tables["TblForUserSystem"].Rows[0];

            string Valusuario = User.Text.ToLower();

            if (Valusuario == drow["Usuario"].ToString())
            {
                //Variables de sesión
                string Usuario, Nombre, Apellido;
                Usuario = User.Text;
                Nombre = ds.Tables[0].Rows[0][1].ToString();
                Apellido = ds.Tables[0].Rows[0][2].ToString();


                Session["Usuario"] = Usuario;
                Session["Nombre"] = Nombre;

                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(Usuario, false);

            }

            con.Close();


                
        }







        private static bool ValidateLdap(string loginName, string password)
        {
            using (var directoryEntry = new DirectoryEntry("LDAP://192.168.212.8", loginName, password, AuthenticationTypes.Secure))
            {
                try
                {
                    //run a search using those credentials.  
                    //If it returns anything, then you're authenticated
                    using (var directorySearcher = new DirectorySearcher(directoryEntry))
                    {
                        directorySearcher.FindOne();
                    }
                }
                catch
                {
                    //otherwise, it will crash out so return false
                    return false;
                }
            }

            return true;
        }

    }
}