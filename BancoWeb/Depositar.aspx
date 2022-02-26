<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Depositar.aspx.vb" Inherits="WebV2.Depositar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
            <title>DEPÓSITO</title>
            <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-uWxY/CJNBR+1zjPWmfnSnVxwRheevXITnMqoEIeG1LJrdI0GlVs/9cVSyPYXdcSF" crossorigin="anonymous" />
            <link href="css/estilos.css" rel="stylesheet" />

            <style type="text/css">
                .auto-style1 {
                    color: #FFFFCC;
                    font-size: x-large;
                }
                .auto-style2 {
                    color: #FFFFFF;
                }
            </style>

    </head>
<body>
  
    <form class="depositar-form" runat="server">
         <div>
            <div><asp:Button ID="btn_atras" runat="server" type="submit" name="Login" value="Página anterior" class="cerrar-submit" Text="Atras" Height="38px" Width="124px"/></div><br />
            
                <span class="fa-stack fa-lg">
                </span>
       
                    <div class="body"></div>
                        <div>
                             <h4 style="color: whitesmoke">Ingresa Monto</h4>

                        </div>                
                            <div class="login">
                                <asp:TextBox ID="txt_monto" runat="server" type="diner" class="login-username" autofocus="true" required="false" placeholder="Monto"></asp:TextBox>
                                <asp:Button ID="btn_guardarDeposito" runat="server" type="submit" name="Login" value="Login" class="login-submit" Text="Consignar" Height="38px" Width="124px"/>
                                
                                <span class="auto-style1"><strong>$</strong></span>
                                <asp:TextBox ID="txt_saldo" runat="server" Height="35px" Width="136px"></asp:TextBox>
                            </div>
            
        </div>
    </form>
        <div class="underlay-photo"></div>
        <div class="underlay-black"></div>
</body>
</html>
