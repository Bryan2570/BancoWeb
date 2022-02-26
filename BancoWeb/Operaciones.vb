Imports System.Data.SqlClient
Imports System.Data
Imports WebV2.Session.ParameterUser
'Imports WebV2.up.user


Public Class Operaciones

    Inherits System.Web.UI.Page



    '
    'varibales de reisttro 
    Dim usuario As String = ""
        Dim nombre As String = ""
        Dim apellido As String = ""
        Dim correo As String = ""
        Dim password As String = ""

        'variables para realizar un deposito 
        Dim monto As Double


        Public Sub Operaciones(ByVal usuario As String, ByVal nombre As String, ByVal apellido As String, ByVal correo As String, ByVal password As String)

            Me.usuario = usuario
            Me.nombre = nombre
            Me.apellido = apellido
            Me.correo = correo
            Me.password = password

            GuardarUsuario()

        End Sub
        Public Sub Operaciones()

        End Sub


        Public Sub montoUsuario(ByRef monto As Double)
            Me.monto = monto

        End Sub




        Dim Usu As Usuario = New Usuario

        Private mensaje As String = ""
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



        Public Sub GuardarUsuario()

            Dim cmdSQL As New SqlCommand  'VARIABLES PARA GUARDAR EL COMANDO DE SQL'
            Dim drConsulta As SqlDataReader  'VARIABLE PARA MIRAR LOS DATOS OBTENIDOS DE LA CONSULTA'
            Dim cadSQL As String = ""  'VARIABLE QUE CONTIENE LA CADENA DE SQL'


            cadSQL = "insert into Usuario values('" & usuario & "','" & nombre & "','" & apellido & "','" & correo & "','" & password & "')" 'VARIABLE NUEVO USUARIO'
            Conectar()
            cmdSQL = New SqlCommand(cadSQL, conexion)
            cmdSQL.ExecuteNonQuery()
            Desconectar()
            crearCuenta(correo)

        End Sub
        Public Sub crearCuenta(ByRef correo As String)
            Dim cmdSQL As New SqlCommand
            Dim drConsulta As SqlDataReader
            Dim consulta As String = ""
            Dim Num_Cuenta As String = ""
            Dim NumeroCuenta As Integer = 0
            Dim idUsuario As Integer = 0
            Dim id_usuario As String = ""
            Dim monto As Double = 1000000

            Dim cadenaSQL As String = ""

            NumeroCuenta = numAleatorioEntre(1, 999999999)


            Conectar()
            id_usuario = "select id_usuario from Usuario where correoUsuario = '" & correo & "'"
            cmdSQL = New SqlCommand(id_usuario.ToString, conexion)
            drConsulta = cmdSQL.ExecuteReader


            While (drConsulta.Read())
                idUsuario = drConsulta.GetInt32(0)
            End While
            Desconectar()



            Conectar()
            consulta = "insert into CuentaBanco values('" & NumeroCuenta & "',getdate(),'" & monto & "','" & idUsuario & "',getdate())"
            cmdSQL = New SqlCommand(consulta.ToString, conexion)
            drConsulta = cmdSQL.ExecuteReader
            Desconectar()


            mensaje = "DEPOSITO REALIZADO"



        End Sub


    Public Function AgregarNuevoMonto()

            Dim cmdSQL As New SqlCommand
            Dim drConsulta As SqlDataReader

            Dim actualizaMonto As String = ""
            Dim valor As Double

            Conectar()

            actualizaMonto = "update cuentabanco set monto =" & valor & "+" & actualizaMonto & " where monto =" & valor
            cmdSQL = New SqlCommand(actualizaMonto.ToString, conexion)

            drConsulta = cmdSQL.ExecuteReader

            Desconectar()

            Return actualizaMonto

        End Function




    'Public Function Acceder(ByVal correo As String, ByVal password As String) As String
    '    Dim cmdSQL As New SqlCommand
    '    Dim drConsulta As SqlDataReader
    '    Dim cadSQL As String = ""
    '    Dim retVAL As Boolean
    '    Dim passw As String
    '    cadSQL = "select contraseUsuario,id_Usuario from Usuario where correoUsuario='" & correo & "'"

    '    Conectar()
    '    cmdSQL = New SqlCommand(cadSQL, conexion)
    '    drConsulta = cmdSQL.ExecuteReader


    '    While (drConsulta.Read())
    '        passw = drConsulta.GetString(0)
    '    loadParameter.idUser = drConsulta.GetInt32(1)
    '    Session("SessionParameteruser") = loadParameter
    'End While

    '    If (passw = password) Then

    '        retVAL = True
    '    Else
    '        mensaje = "CONTRASEÑA INCORRECTA"
    '        retVAL = False
    '    End If



    '    Desconectar()

    '    Return retVAL
    'End Function

    Function numAleatorioEntre(ByVal minimo As Integer, ByVal maximo As Integer) As Integer
        Randomize()
        Return CLng((minimo - maximo) * Rnd() + maximo)
    End Function

End Class







