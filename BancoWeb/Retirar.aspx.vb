Imports System.Data.SqlClient
Public Class Retirar
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

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

    'METODO REALIZAR RETIRO'
    Public Sub realizarRetiro(ByVal retiro As String)

        Dim cmdSQL As New SqlCommand
        Dim drConsulta As SqlDataReader
        Dim consulta As String = ""
        Dim ID As String
        Dim montoUser As Double
        Dim cadenaSQL As String = ""
        Dim cadRetiro As String

        'selecciona el monto del usuario en la BD'
        Conectar()
        ID = "select monto FROM CuentaBanco WHERE id_Usuario =" & Session("idUser")
        cmdSQL = New SqlCommand(ID.ToString, conexion)
        drConsulta = cmdSQL.ExecuteReader
        While (drConsulta.Read())
            montoUser = drConsulta.GetDecimal(0)
        End While
        Desconectar()

        If montoUser > retiro Then
            'actualiza el monto BD y le resta el retiro'
            Conectar()
            consulta = "update cuentabanco set monto =" & montoUser & "-" & retiro & " where id_Usuario = " & Session("idUser")
            cmdSQL = New SqlCommand(consulta.ToString, conexion)
            drConsulta = cmdSQL.ExecuteReader
            Desconectar()
            txt_saldoRetiro.Text = montoUser - retiro
            'insert datos en la tabla registros'
            Conectar()
            cadRetiro = "insert into Registros (MontoOperacion,fecha,id_UsuarioRegistro,id_OperacionRegistro) values (" & retiro & ",getdate()," & Session("idUser") & ",2)"
            cmdSQL = New SqlCommand(cadRetiro.ToString, conexion)
            drConsulta = cmdSQL.ExecuteReader
            Desconectar()

        Else
            MsgBox("Saldo insuficiente para realizar el retiro.")
        End If

    End Sub

    Protected Sub btn_atrasR_Click(sender As Object, e As EventArgs) Handles btn_atrasR.Click
        Response.Redirect("Menu.aspx")
    End Sub

    Protected Sub btn_guardarRetiro_Click(sender As Object, e As EventArgs) Handles btn_guardarRetiro.Click
        realizarRetiro(txt_retirar.Text)
    End Sub
End Class