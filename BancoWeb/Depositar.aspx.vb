Imports System.Data.SqlClient
Imports System.Data

Public Class Depositar
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

    Protected Sub btn_guardarDeposito_Click(sender As Object, e As EventArgs) Handles btn_guardarDeposito.Click

        AgregarDeposito(txt_monto.Text)

    End Sub

    Public Sub AgregarDeposito(ByVal monto As String)
        Dim cmdSQL As New SqlCommand
        Dim drConsulta As SqlDataReader
        Dim consulta As String = ""
        Dim ID As String = ""
        Dim montoUser As Double
        Dim cadDeposito As String

        'selecciono el monto en la Bd y lo guardo en una variable'
        Conectar()
        ID = "select monto from cuentabanco where id_usuario =" & Session("iduser")
        cmdSQL = New SqlCommand(ID.ToString, conexion)
        drConsulta = cmdSQL.ExecuteReader
        While (drConsulta.Read())
            montoUser = drConsulta.GetDecimal(0)
        End While
        Desconectar()

        'actualizo el monto en la BD y le sumo el monto nuevo'
        Conectar()
        consulta = "update cuentabanco set monto = monto + " & monto & " where id_Usuario = " & Session("idUser")
        cmdSQL = New SqlCommand(consulta.ToString, conexion)
        drConsulta = cmdSQL.ExecuteReader
        Desconectar()
        txt_saldo.Text = montoUser + monto
        'inserto los datos en la tabla registros'
        Conectar()
        cadDeposito = "insert into Registros (MontoOperacion,fecha,id_UsuarioRegistro,id_OperacionRegistro) values (" & monto & ",getdate()," & Session("idUser") & ",1)"
        cmdSQL = New SqlCommand(cadDeposito.ToString, conexion)
        drConsulta = cmdSQL.ExecuteReader
        Desconectar()
    End Sub

    Protected Sub btn_atras_Click(sender As Object, e As EventArgs) Handles btn_atras.Click
        Response.Redirect("Menu.aspx")
    End Sub

End Class