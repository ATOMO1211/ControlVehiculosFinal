Imports ControlVehiculos.Utils
Public Class Login

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnIniciarSesion_Click(sender As Object, e As EventArgs)
        Dim Usuario As String = txtUsuario.Text
        Dim Password As String = txtPassword.Text
        Dim encrypter As New Simple3Des("MiClaveSecreta123") ' Clave secreta para la encriptación
        Dim pass As String = encrypter.EncryptData(Password)
        Dim dbHelper As New dbLogin()
        Dim isValid As Boolean = dbHelper.ValidateLogin(Usuario, pass)
        If isValid Then
            ' Inicio de sesión exitoso
            Dim User As Usuario = dbHelper.GetUser(Usuario) ' Obtener el usuario 
            Session("Usuario") = User ' Almacenar el usuario en la sesión
            If User.Rol = "2" Then
                Response.Redirect("Admin.aspx") ' Redirige a la página de administración si es admin
                Return
            End If
            Response.Redirect("Home.aspx") ' Redirige a la página principal u otra página segura
        Else
            ' Credenciales incorrectas
            SwalUtils.ShowSwalError(Me, "Credenciales incorrectas. Por favor, inténtalo de nuevo.")
        End If

    End Sub
End Class