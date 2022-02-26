<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Menu.aspx.vb" Inherits="WebV2.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <script language="javascript" type="text/javascript">
        javascript: window.history.forward(1);
    </script> 
<head runat="server">
    <script language="javascript" type="text/javascript">
        javascript: window.history.forward(1);
    </script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MENU</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-uWxY/CJNBR+1zjPWmfnSnVxwRheevXITnMqoEIeG1LJrdI0GlVs/9cVSyPYXdcSF" crossorigin="anonymous" />
    <link href="css/estilos.css" rel="stylesheet" />
   
</head>
<body>
    <form class="menu-form" runat="server">
        
        <div>
        
        
        <div ><asp:Button ID="btnCerrar" runat="server" type="submit" name="Login" value="Login" class="cerrar-submit" Text="Cerrar Sesión" Height="38px" Width="124px"/></div><br />
            <asp:Button ID="Button1" runat="server" type="submit" class="historial-submit" Text="Historial" /></div><br />
            
            
        
            <div class="auto-style1">
            
            <h1 style="color: white">BIENVENIDO</h1><br />
            <h2 style="color: white">
                <asp:Label ID="lblNombre" runat="server"></asp:Label>
                <asp:Label ID="lblApellido" runat="server"></asp:Label>
                &nbsp; Número Cuenta -
                <asp:Label ID="lblCuenta" runat="server"></asp:Label>
                &nbsp; Saldo Total - $
                <asp:Label ID="lblMonto" runat="server"></asp:Label>
                
            </h2>
               <input type='checkbox' id='mmeennuu'>
<label class='menu' for='mmeennuu'>

<div class='barry'>
	<span class='bar'></span>
	<span class='bar'></span>
	<span class='bar'></span>
	
</div>
            <ul>
            <asp:Button ID="btn_depositar" runat="server" type="submit" name="Login" value="Login" class="login-submit" Text="Depositar" Height="38px" Width="124px"/>
                <asp:Button ID="btn_retirar" runat="server" type="submit" name="Login" value="Login" class="login-submit" Text="Retirar" Height="38px" Width="124px"/>
                <asp:Button ID="btn_transferir" runat="server" type="submit" name="Login" value="Login" class="login-submit" Text="Transferir" Height="38px" Width="124px"/>
</ul>
       
             <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
       
    </div>
            </div>
            
            
        </label>
         <footer class="footer"></footer>
    </form>

    <div class="underlay-photo"></div>
    <div class="underlay-black"></div>
    
	
</body>
</html>
