﻿Imports ClasesBM
' todo María: Cambiar los nombres de los formularios a FrmQueHace
Public Class FrmEleccionDificultad
    Private Sub boton_click(sender As Object, e As EventArgs) Handles btnFacil.Click, btnMedio.Click, btnDificil.Click
        Dim boton As Button = TryCast(sender, Button)
        dificultad = New Dificultad
        Select Case boton.Text
            Case "facil"
                dificultad.PosX = 8
                dificultad.PosY = 8
            Case "medio"
                dificultad.PosX = 16
                dificultad.PosY = 16
            Case "dificil"
                dificultad.PosX = 30
                dificultad.PosY = 16
        End Select
        FrmTablero.Activate()
        FrmTablero.Show()
        Me.Hide() ' todo María: Para qué ocultarlo? Luego deberá volver o si no es así, cerrarlo
    End Sub
End Class