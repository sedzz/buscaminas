Public Class Form1
    Public matriz(8, 8) As Button
    Private posicionDeBombas(9) As Integer
    Dim x As Integer = 0
    Dim y As Integer = 0
    Private BombasGeneradas As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For i = 0 To 8 'Recorre las filas

            For j = 0 To 8 'Recorre las columnas
                Dim btn As New Button
                matriz(i, j) = btn
                btn.Name = $"btn_{i}{j}"
                matriz(i, j).Size = New Size(50, 50)
                matriz(i, j).Location = New Point(x, y)
                y += matriz(i, j).Size.Height
                Controls.Add(matriz(i, j))
                AddHandler matriz(i, j).Click, AddressOf Boton_Click
            Next j
            x += 50
            y = 0
        Next i

    End Sub

    Private Sub Boton_Click(sender As Object, e As EventArgs)
        Dim boton As Button = TryCast(sender, Button)
        Dim rnd As New Random
        Dim posicionX, posicionY, posicionMenosX, posicionMenosY As Integer

        If TypeOf boton Is Button And BombasGeneradas = False Then

            For i = 0 To 9
                posicionX = rnd.Next(9)
                posicionY = rnd.Next(9)
                If Not posicionDeBombas.Contains(posicionX & posicionY) AndAlso Not $"btn_{posicionX}{posicionY}".Equals(boton.Name) Then
                    matriz(posicionX, posicionY).Text = "x"
                    posicionDeBombas(i) = posicionX & posicionY
                Else
                    i -= 1

                End If
            Next

        End If

        BombasGeneradas = True
    End Sub
End Class
