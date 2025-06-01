<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SPLASHSCREEN
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SPLASHSCREEN))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PB1 = New System.Windows.Forms.ProgressBar()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(459, 26)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Une histoire immobilière  à écrire ensemble"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(313, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 19)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "VERSION Avril 2023"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Projet_IMMO_.My.Resources.Resources.White___Red
        Me.PictureBox1.Location = New System.Drawing.Point(119, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(272, 214)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'PB1
        '
        Me.PB1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.PB1.Location = New System.Drawing.Point(52, 236)
        Me.PB1.Name = "PB1"
        Me.PB1.Size = New System.Drawing.Size(412, 12)
        Me.PB1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PB1.TabIndex = 8
        '
        'Timer2
        '
        '
        'SPLASHSCREEN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(525, 261)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PB1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SPLASHSCREEN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PB1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Timer2 As System.Windows.Forms.Timer

End Class
