Imports System.Data.SqlClient
Public Class Login
    Inherits System.Web.UI.Page

    Private cnn As String = ConfigurationManager.AppSettings("BaseConexion")
    Private conexion As New SqlConnection(cnn)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub
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

    Protected Sub btn_iniciar_Click(sender As Object, e As EventArgs) Handles btn_iniciar.Click

        Acceder(txt_usuario1.Text, txt_password.Text)

    End Sub

    'metodo para acceder al login donde se realiza una subconsulta en la BD'
    Public Function Acceder(ByVal correo As String, ByVal password As String) As String

        Dim cmdSQL As New SqlCommand
        Dim drConsulta As SqlDataReader
        Dim cadSQL As String = ""
        Dim retVAL As Boolean
        Dim passw As String

        'subconsulta donde se aplica inner join para seleccionar los atributos que se van a cargar en los lbls del menu'
        cadSQL = "select u.[contraseUsuario],u.[id_Usuario],u.[nombreUsuario], u.[apellidoUsuario], [numeroCuenta],[monto]from Usuario u
                  inner join CuentaBanco cb on cb.id_Usuario = u.id_Usuario
                  where u.id_Usuario = (select id_Usuario from Usuario where correoUsuario='" & correo & "')"
        Conectar()
        cmdSQL = New SqlCommand(cadSQL, conexion)
        drConsulta = cmdSQL.ExecuteReader
        While (drConsulta.Read())
            passw = drConsulta.GetString(0)
            Session("idUser") = drConsulta.GetInt32(1)
            Session("nombre") = drConsulta.GetString(2)
            Session("apellido") = drConsulta.GetString(3)
            Session("numerocuenta") = drConsulta.GetInt32(4)
            Session("saldo") = drConsulta.GetDecimal(5)
        End While

        If (passw = password) Then
            Response.Redirect("Menu.aspx")
            retVAL = True
        Else
            retVAL = False
            MsgBox("Contraseña incorrecta.")
        End If
        Desconectar()
        Return retVAL
    End Function

End Class