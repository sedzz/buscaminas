Public Class FrmTablero
    Public matriz(dificultad.PosX - 1, dificultad.PosY - 1) As Button
    Private posicionDeBombas(dificultad.Bombas - 1) As String
    Private posicionesDeZonaSegura(9) As String
    Dim x As Integer = 0
    Dim y As Integer = 0
    Private BombasGeneradas As Boolean = False
    Dim totalBombas As List(Of Button) = New List(Of Button)
    Dim zonaSeguraCreada As Boolean = False


    Private Sub Form1_Show(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearTablero()
    End Sub
    Private Sub Boton_Click(sender As Object, e As EventArgs)

        Dim boton As Button = TryCast(sender, Button)
        Dim rnd As New Random
        Dim posicionX, posicionY As Integer

        If TypeOf boton Is Button And BombasGeneradas = False Then
            ZonaSegura(boton)
            For i = 0 To dificultad.Bombas - 1
                posicionX = rnd.Next(dificultad.PosX)
                posicionY = rnd.Next(dificultad.PosY)
                If Not posicionDeBombas.Contains(posicionX & posicionY) AndAlso Not posicionesDeZonaSegura.Contains(posicionX & posicionY) AndAlso Not $"btn{posicionX}_{posicionY}".Equals(boton.Name) Then
                    totalBombas.Add(matriz(posicionX, posicionY))
                    posicionDeBombas(i) = posicionX & posicionY
                    matriz(posicionX, posicionY).Tag = -1

                Else
                    i -= 1
                End If

            Next
            Numeros()
        End If

        BombasGeneradas = True
        If boton.BackColor <> Color.Black Then
            boton.Enabled = False



            Select Case boton.Tag
                Case -1
                    Dim imagePath As String = "../../imagenes/bus.png" ' todo María: Esto queda pendiente, ya os contaré más tarde donde deben ir las imágenes....
                    Dim Image As Image = Image.FromFile(imagePath)
                    boton.Image = Image

                    For i = 0 To dificultad.PosX - 1
                        For j = 0 To dificultad.PosY - 1
                            If matriz(i, j).Tag = -1 Then
                                matriz(i, j).Image = Image
                            End If
                        Next
                    Next
                    MessageBox.Show("la cagaste")
                    Close()
                    FrmEleccionDificultad.Show()
                Case 1
                    boton.BackColor = Color.Blue
                Case 2
                    boton.BackColor = Color.Green
                Case 3
                    boton.BackColor = Color.Red
                Case 4
                    boton.BackColor = Color.DarkBlue

            End Select
        Else
            boton.Text = ""
        End If
        boton.Text = boton.Tag


    End Sub

    Function SacarPosicion(boton As Button, quieresX As Boolean) As Integer
        If quieresX Then Return boton.Name.Substring(3, 2)
        Return boton.Name.Substring(6)
    End Function

    Sub Numeros()
        For Each bom In totalBombas
            For xP = SacarPosicion(bom, True) - 1 To SacarPosicion(bom, True) + 1
                For yP = SacarPosicion(bom, False) - 1 To SacarPosicion(bom, False) + 1
                    If Not (xP = -1 OrElse yP = -1) AndAlso Not (xP = dificultad.PosX OrElse yP = dificultad.PosY) Then
                        If matriz(xP, yP).Tag <> -1 Then
                            matriz(xP, yP).Tag += 1


                        End If
                        ' matriz(xP, yP).Text = matriz(xP, yP).Tag
                    End If
                Next

            Next
        Next

    End Sub


    Private Sub MarcarBandera(sender As Object, e As MouseEventArgs)
        Dim boton As Button = TryCast(sender, Button)
        If boton.BackColor = Color.Black And e.Button = Windows.Forms.MouseButtons.Right Then
            boton.BackColor = Color.Transparent
            Exit Sub
        End If

        If e.Button = Windows.Forms.MouseButtons.Right AndAlso zonaSeguraCreada Then
            boton.BackColor = Color.Black
        End If


    End Sub
    Sub ZonaSegura(boton As Button)
        Dim posicionParaLaPosicionX As Integer = boton.Name.LastIndexOf("n") + 1
        Dim posicionParaLaPosicionY As Integer = 6
        Dim posicionX, posicionY As Integer
        Dim comprobador As Boolean = True


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
                If Not (x = -1 OrElse y = -1) And Not (x = dificultad.PosX OrElse y = dificultad.PosY) Then
                    'matriz(x, y).Enabled = False


                    posicionesDeZonaSegura(posicionParaLaPosicionX) = x & y
                    posicionParaLaPosicionX += 1
                    '  Boton_Click(matriz(x, y), EventArgs.Empty)

                End If
                matriz(x, y).Text = matriz(x, y).Tag
            Next
        Next

    End Sub

    Sub CrearTablero()
        For i = 0 To dificultad.PosX - 1 'Recorre las filas

            For j = 0 To dificultad.PosY - 1 'Recorre las columnas
                Dim btn As New Button
                matriz(i, j) = btn
                If i >= 10 And j >= 10 Then matriz(i, j).Name = $"btn{i}_{j}"
                If i < 10 Then matriz(i, j).Name = $"btn0{i}_{j}"
                If j < 10 Then matriz(i, j).Name = $"btn{i}_0{j}"
                If i < 10 And j < 10 Then matriz(i, j).Name = $"btn0{i}_0{j}"
                matriz(i, j).Tag = 0
                matriz(i, j).Size = New Size(50, 30)
                matriz(i, j).Location = New Point(x, y)
                y += matriz(i, j).Size.Height
                Controls.Add(matriz(i, j))
                AddHandler matriz(i, j).Click, AddressOf Boton_Click
                AddHandler matriz(i, j).MouseDown, AddressOf MarcarBandera
            Next j
            x += 50
            y = 0
        Next i
        zonaSeguraCreada = True
    End Sub
End Class
