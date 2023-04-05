<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnFacil = New System.Windows.Forms.Button()
        Me.btnMedio = New System.Windows.Forms.Button()
        Me.btnDificil = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnFacil
        '
        Me.btnFacil.Location = New System.Drawing.Point(66, 200)
        Me.btnFacil.Name = "btnFacil"
        Me.btnFacil.Size = New System.Drawing.Size(113, 55)
        Me.btnFacil.TabIndex = 0
        Me.btnFacil.Text = "facil"
        Me.btnFacil.UseVisualStyleBackColor = True
        '
        'btnMedio
        '
        Me.btnMedio.Location = New System.Drawing.Point(236, 201)
        Me.btnMedio.Name = "btnMedio"
        Me.btnMedio.Size = New System.Drawing.Size(110, 53)
        Me.btnMedio.TabIndex = 1
        Me.btnMedio.Text = "medio"
        Me.btnMedio.UseVisualStyleBackColor = True
        '
        'btnDificil
        '
        Me.btnDificil.Location = New System.Drawing.Point(402, 197)
        Me.btnDificil.Name = "btnDificil"
        Me.btnDificil.Size = New System.Drawing.Size(90, 56)
        Me.btnDificil.TabIndex = 2
        Me.btnDificil.Text = "dificil"
        Me.btnDificil.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnDificil)
        Me.Controls.Add(Me.btnMedio)
        Me.Controls.Add(Me.btnFacil)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnFacil As Button
    Friend WithEvents btnMedio As Button
    Friend WithEvents btnDificil As Button
End Class
