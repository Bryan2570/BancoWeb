Imports System.Data.SqlClient
Public Class Transferir
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub
    Protected Sub btn_guardarTransferencia_Click(sender As Object, e As EventArgs) Handles btn_guardarTransferencia.Click
        realizarTransferencia(txt_numCuenta.Text, txt_montoTransferir.Text)
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

    Protected Sub btn_atrasR_Click(sender As Object, e As EventArgs) Handles btn_atrasR.Click
        Response.Redirect("Menu.aspx")
    End Sub

    Public Sub realizarTransferencia(ByVal NumeroCuenta As Integer, ByVal Monto As String)
        Dim cmdSQL As New SqlCommand
        Dim drConsulta As SqlDataReader
        Dim consulta As String = ""
        Dim idCuenta As String
        Dim montoUser As Double
        Dim numCuenta As String

        Dim cadSQL As String
        Dim montoBase As Double
        Dim cadTransferencia As String


        'selecciona el numero de cuenta para realizar tranferecnia'
        Conectar()
        idCuenta = "select numeroCuenta from CuentaBanco where  numeroCuenta =" & NumeroCuenta
        cmdSQL = New SqlCommand(idCuenta.ToString, conexion)
        drConsulta = cmdSQL.ExecuteReader
        If drConsulta.Read() Then
            Desconectar()
            'selecciona el monto que esta en la BD cuando el numeroCuenta = NumeroCuenta que le paso'
            Conectar()
            numCuenta = "select monto FROM CuentaBanco WHERE numeroCuenta =" & NumeroCuenta
            cmdSQL = New SqlCommand(numCuenta.ToString, conexion)
            drConsulta = cmdSQL.ExecuteReader
            While (drConsulta.Read())
                montoUser = drConsulta.GetDecimal(0)
            End While
            Desconectar()
            'seleciono el monto del usuario que realiza la transferencia'
            cadSQL = "Select monto from cuentabanco where id_Usuario=" & Session("iduser")
            Conectar()
            cmdSQL = New SqlCommand(cadSQL, conexion)
            drConsulta = cmdSQL.ExecuteReader
            While (drConsulta.Read())
                montoBase = drConsulta.GetDecimal(0)
            End While
            Desconectar()

            'actualizacion del monto BD sumandole el Monto a transferir'
            If montoBase > Monto Then
                Conectar()
                consulta = "update cuentabanco set monto =" & montoUser & "+" & Monto & " where numeroCuenta =" & NumeroCuenta
                cmdSQL = New SqlCommand(consulta.ToString, conexion)
                drConsulta = cmdSQL.ExecuteReader
                Desconectar()

                'inserto datos en la tabla registros'
                Conectar()
                cadTransferencia = "insert into Registros (MontoOperacion,fecha,id_UsuarioRegistro,id_OperacionRegistro) values (" & Monto & ",getdate()," & Session("idUser") & ",3)"
                cmdSQL = New SqlCommand(cadTransferencia.ToString, conexion)
                drConsulta = cmdSQL.ExecuteReader
                Desconectar()

                'actualizacion del monto BD del usuario que hizo la transferencia restandole el monto que transfirio'
                Conectar()
                consulta = "update cuentabanco set monto =" & montoBase & "-" & Monto & " where id_Usuario = " & Session("idUser")
                cmdSQL = New SqlCommand(consulta.ToString, conexion)
                drConsulta = cmdSQL.ExecuteReader
                Desconectar()
                MsgBox("Transferencia exitosa.")
            Else
                MsgBox("Saldo insuficiente para realizar la transferencia.")
            End If
        Else
            MsgBox("Numero de cuenta no exite")
            Desconectar()
        End If
    End Sub
End Class