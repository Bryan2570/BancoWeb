Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.SqlClient

Public Class Historial
    Inherits System.Web.UI.Page

    Public Property SQLAdapter As Object
    Private cnn As String = ConfigurationManager.AppSettings("BaseConexion")
    Private conexion As New SqlConnection(cnn)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'select para mostrar los datos en la tabla registros'
        Dim SQLAdapter = New SqlDataAdapter("SELECT fecha As Fecha,MontoOperacion As Monto,O.operacion As Operación FROM [dbo].[Registros] R JOIN Tipo_Operacion O ON O.id_Operacion = R.id_OperacionRegistro where R.id_UsuarioRegistro = " & Session("idUser"), conexion)
        Dim DT = New DataTable()

        SQLAdapter.Fill(DT)

        GridView1.DataSource = DT
        GridView1.DataBind()
    End Sub


    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub btn_atrasR_Click(sender As Object, e As EventArgs) Handles btn_atrasR.Click
        Response.Redirect("Menu.aspx")
    End Sub
End Class