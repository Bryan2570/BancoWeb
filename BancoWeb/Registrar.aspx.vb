Imports System.Data.SqlClient

Public Class Registrar
    Inherits System.Web.UI.Page

    'VARIABLES DE REGISTRO'
    Dim usuario As String = ""
    Dim nombre As String = ""
    Dim apellido As String = ""
    Dim correo As String = ""
    Dim password As String = ""

    'llamado a la variable creada en web config para conectarme en la BD'
    Private cnn As String = ConfigurationManager.AppSettings("BaseConexion")
    Private conexion As New SqlConnection(cnn)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    'metodo conecta baseDatos'
    Private Sub Conectar()
        If conexion.State = ConnectionState.Closed Then
            conexion.Open()
        End If
    End Sub

    'metodo desconectar BD'
    Private Sub Desconectar()
        If conexion.State = ConnectionState.Open Then
            conexion.Close()
        End If
    End Sub

    Protected Sub btn_registrar_Click(sender As Object, e As EventArgs) Handles btn_registrar.Click

        GuardarUsuario(txt_usuario.Text, txt_nombre.Text, txt_apellido.Text, txt_correo.Text, txt_password.Text)

        txt_usuario.Text = ""
        txt_nombre.Text = ""
        txt_apellido.Text = ""
        txt_correo.Text = ""
        txt_password.Text = ""

    End Sub

    Public Sub GuardarUsuario(ByVal usuario As String, ByVal nombre As String, ByVal apellido As String, ByVal correo As String, ByVal password As String)
        Me.usuario = usuario
        Me.nombre = nombre
        Me.apellido = apellido
        Me.correo = correo
        Me.password = password

        Dim cmdSQL As New SqlCommand  'VARIABLES PARA GUARDAR EL COMANDO DE SQL'
        Dim drConsulta As SqlDataReader  'VARIABLE PARA MIRAR LOS DATOS OBTENIDOS DE LA CONSULTA'
        Dim cadSQL As String = ""  'VARIABLE QUE CONTIENE LA CADENA DE SQL'


        'CADENA INSERCION DE REGISTRO A LA BD' 
        cadSQL = "insert into Usuario values('" & usuario & "','" & nombre & "','" & apellido & "','" & correo & "','" & password & "')"
        Conectar()
        cmdSQL = New SqlCommand(cadSQL, conexion)
        cmdSQL.ExecuteNonQuery()
        Desconectar()
        crearCuenta(correo)

    End Sub

    'metodo que me crea una cuenta,monto apenas me registre'
    Public Sub crearCuenta(ByRef correo As String)
        Dim cmdSQL As New SqlCommand
        Dim drConsulta As SqlDataReader
        Dim consulta As String = ""
     
        Dim NumeroCuenta As Integer = 0
        Dim idUsuario As Integer = 0
        Dim id_usuario As String = ""
        Dim monto As Double = 1000000
        Dim cadenaSQL As String = ""

        NumeroCuenta = numAleatorioEntre(1, 999999999)

        'seleciona el id_usuario en la base de datos lo guarda en una variable para hacer la insercion CuentaBanco'
        Conectar()
        id_usuario = "select id_usuario from Usuario where correoUsuario = '" & correo & "'"
        cmdSQL = New SqlCommand(id_usuario.ToString, conexion)
        drConsulta = cmdSQL.ExecuteReader
        While (drConsulta.Read())
            idUsuario = drConsulta.GetInt32(0)
        End While
        Desconectar()

        'insercion en la tabla CuentaBanco de la BD'
        Conectar()
        consulta = "insert into CuentaBanco values('" & NumeroCuenta & "','" & monto & "','" & idUsuario & "')"
        cmdSQL = New SqlCommand(consulta.ToString, conexion)
        drConsulta = cmdSQL.ExecuteReader
        Desconectar()
    End Sub

    'funcion que me genera numeros aleatorios'
    Function numAleatorioEntre(ByVal minimo As Integer, ByVal maximo As Integer) As Integer
        Randomize()
        Return CLng((minimo - maximo) * Rnd() + maximo)
    End Function

End Class