Imports System.Data.SqlClient
Public Class Menu
    Inherits System.Web.UI.Page

    Private cnn As String = ConfigurationManager.AppSettings("BaseConexion")
    Private conexion As New SqlConnection(cnn)
    Private Sub Conectar()
        If conexion.State = ConnectionState.Closed Then
            conexion.Open()
        End If
    End Sub
    Private Sub Desconectar()
        If conexion.State = ConnectionState.Open Then
            conexion.Close()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim cmdSQL As New SqlCommand
        Dim drConsulta As SqlDataReader
        Dim cadSQL As String = ""

        'selecciona el monto del usuario lo llena en la variable saldo para que se muestre en el label al cargar la pagina'
        cadSQL = "Select monto from cuentabanco where id_Usuario=" & Session("iduser")
        Conectar()
        cmdSQL = New SqlCommand(cadSQL, conexion)
        drConsulta = cmdSQL.ExecuteReader
        While (drConsulta.Read())
            Session("saldo") = drConsulta.GetDecimal(0)
        End While
        Desconectar()

        lblNombre.Text = Session("nombre")
        lblApellido.Text = Session("apellido")
        lblCuenta.Text = Session("numerocuenta")
        lblMonto.Text = Session("saldo")

    End Sub

    Protected Sub btn_depositar_Click(sender As Object, e As EventArgs) Handles btn_depositar.Click
        Response.Redirect("Depositar.aspx")
    End Sub

    Protected Sub btn_retirar_Click(sender As Object, e As EventArgs) Handles btn_retirar.Click
        Response.Redirect("Retirar.aspx")
    End Sub

    Protected Sub btn_transferir_Click(sender As Object, e As EventArgs) Handles btn_transferir.Click
        Response.Redirect("Transferir.aspx")
    End Sub

    Protected Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Response.Redirect("Login.aspx")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("Historial.aspx")
    End Sub

End Class