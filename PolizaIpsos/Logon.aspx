<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="PolizaIpsos.Logon" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
<meta content="text/html; charset=utf-8"/>
    <link href="Content/normalize.css" rel="stylesheet" />
    <link href="Content/IpsosIT.css" rel="stylesheet" />
    <%--<title>Polizas Ipsos</title>--%>
</head>
<body>
    
         <div id="contenido">
            <div id="top">
                <div id="logos"></div>
            </div>
         </div>
         <div id="center">
            <h1 class="title"> Sistema Nóminas Ipsos 2018</h1>

            <div id="logo_ipsos_a"></div>

            <div id="contact-area">
                <form method="post" class="error" runat="server">
                    <p class="title_form">Ingresa tu usuario y contraseña</p>
                    <asp:TextBox ID="User" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="User" ErrorMessage="Ingrese su usuario"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="Pass" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Pass" ErrorMessage="Ingrese su pasword"></asp:RequiredFieldValidator>
                    <br/>
                    <asp:Button ID="btnEntrar" runat="server" Text="Button" />
                    <p class="text">Si tienes problemas para ingresar contactar a IT Development</p>
                </form>

            <div style="clear: both;"></div>
        </div>
      </div>
          <div id="bottom">

            <div class="low_menu_2" id="disclaimer"><span><a href="aviso_privacidad.html"> Aviso de Privacidad</a>  &nbsp;&nbsp;• &nbsp;&nbsp;Todos los derechos reservados © Ipsos 2015.</div>

                <div id="social">
                    <div id="face"><a href="https://www.facebook.com/IPSOSenMexico"></a></div>
                    <div id="twitter"><a href="https://twitter.com/IPSOSenMexico"></a></div>
                </div>
           </div>
          
        
     


   
</body>
</html>
