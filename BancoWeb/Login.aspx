<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="WebV2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>LOGIN</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-uWxY/CJNBR+1zjPWmfnSnVxwRheevXITnMqoEIeG1LJrdI0GlVs/9cVSyPYXdcSF" crossorigin="anonymous" />
    <link href="css/estilos.css" rel="stylesheet" />

</head>
<body>

    <form class="login-form" runat="server">
        <span style="color: aliceblue"></span>
        <span class="fa-stack fa-lg">
        </span>
       
       <div class="body"></div>
        <div>
            <h2 style="color: whitesmoke">Inicio de Sesión</h2>

        </div><br />
        
		                                 
        <div class="login">
          
            <asp:TextBox ID="txt_usuario1" runat="server" type="email" class="login-username" autofocus="true" required="true" placeholder="Email"></asp:TextBox><br />
            <asp:TextBox ID="txt_password" runat="server" type="password" class="login-password" required="true" placeholder="Password"></asp:TextBox>
            <br />
            <asp:Button ID="btn_iniciar" runat="server" type="submit" name="Login" value="Login" class="login-submit" Text="Login" Height="38px" Width="124px"/><br />
            <a href="Registrar.aspx">
                <p style="text-align: center">Registrar</p>
            </a>
        </div>
                    
    </form>

    <div class="underlay-photo"></div>
    <div class="underlay-black"></div>
</body>
</html>




