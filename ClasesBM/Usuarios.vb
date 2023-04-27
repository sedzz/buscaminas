Imports System.IO

Public Class Usuarios
    Public Property UsuariosTotales As List(Of Usuario)

    Sub New()
        Me.UsuariosTotales = New List(Of Usuario)
    End Sub

    Public Function AñadirUsuario(nombre As String, contraseña As String) As Boolean
        Dim ruta As String = "../../"




        Dim usuario As New Usuario(nombre, contraseña)
        Dim posicionUsuario = UsuariosTotales.IndexOf(usuario)
        If posicionUsuario = -1 Then
            UsuariosTotales.Add(usuario)
            Return True
        End If
        Return False
    End Function

    Public Function ConectarUsuario(nombre As String, contraseña As String) As Boolean
        Dim usuario As New Usuario(nombre, contraseña)
        Dim posicionUsuario = UsuariosTotales.IndexOf(usuario)
        If posicionUsuario <> -1 Then
            If usuario.Equals(UsuariosTotales(posicionUsuario)) Then
                Return True
            End If
        End If
        Return False
    End Function
End Class
