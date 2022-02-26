<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Retirar.aspx.vb" Inherits="WebV2.Retirar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>RETIRO</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-uWxY/CJNBR+1zjPWmfnSnVxwRheevXITnMqoEIeG1LJrdI0GlVs/9cVSyPYXdcSF" crossorigin="anonymous" />
    <link href="css/estilos.css" rel="stylesheet" />

    <style type="text/css">
        .auto-style1 {
            color: #FFFFFF;
            font-size: x-large;
        }
    </style>

</head>
<body>
    <form class="depositar-form" runat="server">
        <div>
            <div><asp:Button ID="btn_atrasR" runat="server" class="cerrar-submit" Text="Atras" Height="38px" Width="124px"/></div><br />/>
                <div class="body"></div>
                    <div>
                        <h4 style="color: whitesmoke">Ingresa Monto</h4>
                    </div>		                               
                        <div class="login">
                            <asp:TextBox ID="txt_retirar" runat="server" type="diner" class="login-username" autofocus="true" required="true" placeholder="Monto"></asp:TextBox>
                            <asp:Button ID="btn_guardarRetiro" runat="server" type="submit" name="Login" value="Login" class="login-submit" Text="Retirar" Height="38px" Width="124px"/>
                            <span class="auto-style1">$</span>&nbsp; 
                            <asp:TextBox ID="txt_saldoRetiro" runat="server" Height="35px" Width="136px"></asp:TextBox>
                        </div>
       </div>
   </form>
                        <div class="underlay-photo"></div>
                        <div class="underlay-black"></div>
</body>
</html>
