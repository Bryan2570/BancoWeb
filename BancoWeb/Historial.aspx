<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Historial.aspx.vb" Inherits="WebV2.Historial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-uWxY/CJNBR+1zjPWmfnSnVxwRheevXITnMqoEIeG1LJrdI0GlVs/9cVSyPYXdcSF" crossorigin="anonymous" />
    <link href="css/estilos.css" rel="stylesheet" />

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
</head>
<body>
    

    <form class="registros-form" style="background:white" runat="server">
        
       <div><asp:Button ID="btn_atrasR" runat="server" type="submit" name="Login" value="Página anterior" class="cerrar-submit" Text="Atras" Height="38px" Width="124px"/></div><br />
       <div class="body"></div>
        <div>
            <h2 style="color: black">Registros de transacciones</h2>

        </div><br />
        
		                             
        <div class="">
             
           <asp:GridView ID="GridView1" runat="server" PageSize="2" BackColor="Black" BorderColor="Black" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
               <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
               <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
               <PagerSettings Mode="NextPrevious" />
               <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
               <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
               <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
               <SortedAscendingCellStyle BackColor="#F1F1F1" />
               <SortedAscendingHeaderStyle BackColor="#594B9C" />
               <SortedDescendingCellStyle BackColor="#CAC9C9" />
               <SortedDescendingHeaderStyle BackColor="#33276A" />
            </asp:GridView>
        </div>
                    
    </form>
        

    <div class="underlay-photo"></div>
    <div class="underlay-black"></div>












    
    

</body>
</html>
