Imports System.CodeDom

Public Class FrmTablero
    Public matriz(dificultad.PosX, dificultad.PosY) As Button
    Private posicionDeBombas(dificultad.Bombas - 1) As String
    Private posicionesDeZonaSegura(9) As String
    Dim x As Integer = 0
    Dim y As Integer = 0
    Private BombasGeneradas As Boolean = False

    Private Sub Form1_Show(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearTablero()
    End Sub
    Private Sub Boton_Click(sender As Object, e As EventArgs)
        Dim boton As Button = TryCast(sender, Button)
        Dim rnd As New Random
        Dim posicionX, posicionY, posicionMenosX, posicionMenosY As Integer

        If TypeOf boton Is Button And BombasGeneradas = False Then
            ZonaSegura(boton)
            For i = 0 To dificultad.Bombas - 1
                posicionX = rnd.Next(dificultad.PosX)
                posicionY = rnd.Next(dificultad.PosY)
                If Not posicionDeBombas.Contains(posicionX & posicionY) AndAlso Not posicionesDeZonaSegura.Contains(posicionX & posicionY) AndAlso Not $"btn{posicionX}_{posicionY}".Equals(boton.Name) Then
                    matriz(posicionX, posicionY).Text = "x"
                    posicionDeBombas(i) = posicionX & posicionY
                    matriz(posicionMenosX, posicionMenosY).Tag = "bomba"
                Else
                    i -= 1
                End If
            Next

        End If

        BombasGeneradas = True

        If boton.Text = "x" Then
            Dim imagePath As String = "../../imagenes/bus.png" ' todo María: Esto queda pendiente, ya os contaré más tarde donde deben ir las imágenes....
            Dim Image As Image = Image.FromFile(imagePath)
            boton.Image = Image

            For i = 0 To dificultad.PosX - 1
                For j = 0 To dificultad.PosY - 1
                    If matriz(i, j).Text = "x" Then
                        matriz(i, j).Image = Image
                    End If
                Next
            Next
        End If



    End Sub

    Function SacarPosicion(boton As Button, quieresY As Boolean) As Integer
        If quieresY Then Return boton.Text.Substring(6)
        Return boton.Text.Substring(3, 4)
    End Function

    Sub ZonaSegura(boton As Button)
        Dim posicionParaLaPosicionX As Integer = boton.Name.LastIndexOf("n") + 1
        Dim posicionParaLaPosicionY As Integer = 6
        Dim posicionX, posicionY As Integer
        Dim comprobador As Boolean = True
        Dim cambiarOrden As String


        Do Until comprobador = False

            If Not boton.Name.ElementAt(posicionParaLaPosicionX).ToString = "_" Then
                posicionX = posicionX & boton.Name.ElementAt(posicionParaLaPosicionX).ToString
                posicionParaLaPosicionX += 1
            ElseIf posicionParaLaPosicionY <> 8 Then
                posicionY = posicionY & boton.Name.ElementAt(posicionParaLaPosicionY).ToString
                posicionParaLaPosicionY += 1
            Else
                comprobador = False
            End If

        Loop


        posicionParaLaPosicionX = 0

        For x As Integer = posicionX - 1 To posicionX + 1
            For y As Integer = posicionY - 1 To posicionY + 1
                If Not (x = -1 OrElse y = -1) Then
                    matriz(x, y).Visible = False
                    posicionesDeZonaSegura(posicionParaLaPosicionX) = x & y
                    posicionParaLaPosicionX += 1
                End If
            Next
        Next

    End Sub

    Sub CrearTablero()
        For i = 0 To dificultad.PosX - 1 'Recorre las filas

            For j = 0 To dificultad.PosY - 1 'Recorre las columnas
                Dim btn As New Button
                matriz(i, j) = btn
                If i > 10 And j > 10 Then btn.Name = $"btn{i}_{j}"
                If i < 10 Then btn.Name = $"btn0{i}_{j}"
                If j < 10 Then btn.Name = $"btn{i}_0{j}"
                If i < 10 And j < 10 Then btn.Name = $"btn0{i}_0{j}"
                matriz(i, j).Size = New Size(30, 30)
                matriz(i, j).Location = New Point(x, y)
                y += matriz(i, j).Size.Height
                Controls.Add(matriz(i, j))
                AddHandler matriz(i, j).Click, AddressOf Boton_Click
            Next j
            x += 30
            y = 0
        Next i
    End Sub
End Class
