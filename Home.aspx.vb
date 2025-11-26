Public Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblUsuario.Text = "Bienvenido, " & Session("Usuario").ToString()
        lblEmail.Text = "Correo electrónico: " & Session("Email").ToString()
    End Sub

End Class