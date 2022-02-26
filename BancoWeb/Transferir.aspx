<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Transferir.aspx.vb" Inherits="WebV2.Transferir" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>TRANSFERENCIA</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-uWxY/CJNBR+1zjPWmfnSnVxwRheevXITnMqoEIeG1LJrdI0GlVs/9cVSyPYXdcSF" crossorigin="anonymous" />
    <link href="css/estilos.css" rel="stylesheet" />
    
</head>
<body>
    <form class="depositar-form" runat="server">
         <div>
           <div><asp:Button ID="btn_atrasR" runat="server" type="submit" name="Login" value="Página anterior" class="cerrar-submit" Text="Atras" Height="38px" Width="124px"/></div><br />
                <div class="body"></div>
                    <div>
                        <h4 style="color: whitesmoke">Realizar Transferencia</h4>
                    </div>                        
        <div class="login">
            <asp:TextBox ID="txt_numCuenta" runat="server" class="login-username" autofocus="true" required="true" placeholder="Número de cuenta"></asp:TextBox>
            <asp:TextBox ID="txt_montoTransferir" runat="server" class="login-username" autofocus="true" required="true" placeholder="Monto"></asp:TextBox>
            <asp:Button ID="btn_guardarTransferencia" runat="server" type="submit" name="Login" value="Login" class="login-submit" Text="Tranferir" Height="38px" Width="124px"/><br />
        </div>
         </div>
   </form>
        <div class="underlay-photo"></div>
        <div class="underlay-black"></div>
</body>
</html>
