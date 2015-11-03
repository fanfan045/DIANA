<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lstboxCommands = New System.Windows.Forms.ListBox()
        Me.lblTimer = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblText = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstboxCommands
        '
        Me.lstboxCommands.BackColor = System.Drawing.Color.Black
        Me.lstboxCommands.Font = New System.Drawing.Font("Major Snafu", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstboxCommands.ForeColor = System.Drawing.Color.MediumTurquoise
        Me.lstboxCommands.FormattingEnabled = True
        Me.lstboxCommands.ItemHeight = 17
        Me.lstboxCommands.Location = New System.Drawing.Point(119, 77)
        Me.lstboxCommands.Name = "lstboxCommands"
        Me.lstboxCommands.Size = New System.Drawing.Size(197, 208)
        Me.lstboxCommands.TabIndex = 1
        Me.lstboxCommands.Visible = False
        '
        'lblTimer
        '
        Me.lblTimer.AutoSize = True
        Me.lblTimer.BackColor = System.Drawing.Color.Transparent
        Me.lblTimer.Font = New System.Drawing.Font("Major Snafu", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimer.ForeColor = System.Drawing.Color.MediumTurquoise
        Me.lblTimer.Location = New System.Drawing.Point(365, 292)
        Me.lblTimer.Name = "lblTimer"
        Me.lblTimer.Size = New System.Drawing.Size(67, 53)
        Me.lblTimer.TabIndex = 2
        Me.lblTimer.Text = "10"
        Me.lblTimer.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.MediumTurquoise
        Me.Label1.Location = New System.Drawing.Point(116, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.DIANA.My.Resources.Resources._5
        Me.PictureBox1.InitialImage = Global.DIANA.My.Resources.Resources.DIANA_BACKGROUND
        Me.PictureBox1.Location = New System.Drawing.Point(-9, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(467, 369)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lblText
        '
        Me.lblText.AutoSize = True
        Me.lblText.BackColor = System.Drawing.Color.Black
        Me.lblText.ForeColor = System.Drawing.Color.White
        Me.lblText.Location = New System.Drawing.Point(69, 47)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(0, 13)
        Me.lblText.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(455, 367)
        Me.Controls.Add(Me.lblText)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTimer)
        Me.Controls.Add(Me.lstboxCommands)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Text = "DIANA"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lstboxCommands As System.Windows.Forms.ListBox
    Friend WithEvents lblTimer As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblText As System.Windows.Forms.Label
End Class
