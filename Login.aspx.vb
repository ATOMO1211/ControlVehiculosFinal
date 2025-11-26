Imports ControlVehiculos.Utils
Public Class Login

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnIniciarSesion_Click(sender As Object, e As EventArgs)
        Dim Usuario = txtUsuario.Text
        Dim Password = txtPassword.Text
        Dim encrypter As New Simple3Des("MiClaveSecreta123") ' Clave secreta para la encriptación
        Dim pass As String = encrypter.EncryptData(Password)
        Dim dbHelper As New dbLogin()
        Dim isValid As Boolean = dbHelper.ValidateLogin(Usuario, pass)
        If isValid Then
            ' Inicio de sesión exitoso
            Session("Usuario") = Usuario

            Response.Redirect("Home.aspx") ' Redirige a la página principal u otra página segura
        Else
            ' Credenciales incorrectas
            SwalUtils.ShowSwalError(Me, "Credenciales incorrectas. Por favor, inténtalo de nuevo.")
        End If

    End Sub
End Class