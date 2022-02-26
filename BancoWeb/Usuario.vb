Imports System.Data.SqlClient
Imports System.Data

Public Class Usuario

    Private usuario As String
    Private nombre As String
    Private apellido As String
    Private correo As String
    Private password As String
    Public NuevoId As String = ""
    Private NumeroCuenta As Integer
    Private FechaApertura As Date
    Private montoCuenta As String



    Function GetNuevoId() As String
        Return NuevoId
    End Function

    Sub SetNuevoId(ByVal usuario As String)
        Me.NuevoId = NuevoId
    End Sub

    Function GetUsuario() As String
        Return Me.usuario
    End Function

    Function GetNombre() As String
        Return Me.nombre
    End Function

    Function GetApellido() As String
        Return Me.apellido
    End Function

    Function GetCorreo() As String
        Return Me.correo
    End Function

    Function GetPassword() As String
        Return Me.password
    End Function



    Sub SetUsuario(ByVal usuario As String)
        Me.usuario = usuario
    End Sub

    Sub SetNombre(ByVal nombre As String)
        Me.nombre = nombre
    End Sub

    Sub SetApellido(ByVal apellido As String)
        Me.apellido = apellido
    End Sub

    Sub SetCorreo(ByVal correo As String)
        Me.correo = correo
    End Sub

    Sub SetPassword(ByVal password As String)
        Me.password = password
    End Sub

    Function GetNumeroCuenta() As Integer
        Return Me.NumeroCuenta
    End Function

    Function GetFecha() As Date
        Return Me.FechaApertura
    End Function

    Function GetMonto() As Double
        Return Me.montoCuenta
    End Function


    Sub SetNumeroCuenta(ByVal NumeroCuenta As Integer)
        Me.NumeroCuenta = NumeroCuenta
    End Sub

    Sub SetFecha(ByVal FechaApertura As Date)
        Me.FechaApertura = FechaApertura
    End Sub
End Class
