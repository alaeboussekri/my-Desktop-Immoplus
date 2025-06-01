<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AUTHENTIFICATION
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AUTHENTIFICATION))
        Me.TCODE = New System.Windows.Forms.TextBox()
        Me.CLOGIN = New System.Windows.Forms.ComboBox()
        Me.BTN_LOGIN = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Guna2CircleButton1 = New Guna.UI2.WinForms.Guna2CircleButton()
        Me.Guna2CircleButton2 = New Guna.UI2.WinForms.Guna2CircleButton()
        Me.Guna2CircleButton3 = New Guna.UI2.WinForms.Guna2CircleButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GEMP = New System.Windows.Forms.DataGridView()
        Me.GDROITS = New System.Windows.Forms.DataGridView()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GEMP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GDROITS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TCODE
        '
        Me.TCODE.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCODE.Location = New System.Drawing.Point(50, 225)
        Me.TCODE.MaxLength = 4
        Me.TCODE.Multiline = True
        Me.TCODE.Name = "TCODE"
        Me.TCODE.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TCODE.Size = New System.Drawing.Size(262, 34)
        Me.TCODE.TabIndex = 28
        Me.TCODE.Tag = ""
        '
        'CLOGIN
        '
        Me.CLOGIN.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CLOGIN.FormattingEnabled = True
        Me.CLOGIN.Location = New System.Drawing.Point(51, 164)
        Me.CLOGIN.Name = "CLOGIN"
        Me.CLOGIN.Size = New System.Drawing.Size(261, 33)
        Me.CLOGIN.TabIndex = 27
        '
        'BTN_LOGIN
        '
        Me.BTN_LOGIN.BackColor = System.Drawing.SystemColors.Desktop
        Me.BTN_LOGIN.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_LOGIN.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.BTN_LOGIN.Location = New System.Drawing.Point(39, 307)
        Me.BTN_LOGIN.Name = "BTN_LOGIN"
        Me.BTN_LOGIN.Size = New System.Drawing.Size(263, 62)
        Me.BTN_LOGIN.TabIndex = 26
        Me.BTN_LOGIN.Text = "Login"
        Me.BTN_LOGIN.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label1.Location = New System.Drawing.Point(114, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 45)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Login"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Projet_IMMO_.My.Resources.Resources.fermer_a_cle
        Me.PictureBox2.Location = New System.Drawing.Point(8, 225)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 24
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Projet_IMMO_.My.Resources.Resources.utilisateur
        Me.PictureBox1.Location = New System.Drawing.Point(8, 163)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'Guna2CircleButton1
        '
        Me.Guna2CircleButton1.CheckedState.Parent = Me.Guna2CircleButton1
        Me.Guna2CircleButton1.CustomImages.Parent = Me.Guna2CircleButton1
        Me.Guna2CircleButton1.FillColor = System.Drawing.SystemColors.Desktop
        Me.Guna2CircleButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2CircleButton1.ForeColor = System.Drawing.Color.White
        Me.Guna2CircleButton1.HoverState.Parent = Me.Guna2CircleButton1
        Me.Guna2CircleButton1.Location = New System.Drawing.Point(-67, -55)
        Me.Guna2CircleButton1.Name = "Guna2CircleButton1"
        Me.Guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CircleButton1.ShadowDecoration.Parent = Me.Guna2CircleButton1
        Me.Guna2CircleButton1.Size = New System.Drawing.Size(136, 145)
        Me.Guna2CircleButton1.TabIndex = 30
        '
        'Guna2CircleButton2
        '
        Me.Guna2CircleButton2.CheckedState.Parent = Me.Guna2CircleButton2
        Me.Guna2CircleButton2.CustomImages.Parent = Me.Guna2CircleButton2
        Me.Guna2CircleButton2.FillColor = System.Drawing.SystemColors.Desktop
        Me.Guna2CircleButton2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2CircleButton2.ForeColor = System.Drawing.Color.White
        Me.Guna2CircleButton2.HoverState.Parent = Me.Guna2CircleButton2
        Me.Guna2CircleButton2.Location = New System.Drawing.Point(-84, 375)
        Me.Guna2CircleButton2.Name = "Guna2CircleButton2"
        Me.Guna2CircleButton2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CircleButton2.ShadowDecoration.Parent = Me.Guna2CircleButton2
        Me.Guna2CircleButton2.Size = New System.Drawing.Size(132, 145)
        Me.Guna2CircleButton2.TabIndex = 31
        '
        'Guna2CircleButton3
        '
        Me.Guna2CircleButton3.CheckedState.Parent = Me.Guna2CircleButton3
        Me.Guna2CircleButton3.CustomImages.Parent = Me.Guna2CircleButton3
        Me.Guna2CircleButton3.FillColor = System.Drawing.SystemColors.Desktop
        Me.Guna2CircleButton3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2CircleButton3.ForeColor = System.Drawing.Color.White
        Me.Guna2CircleButton3.HoverState.Parent = Me.Guna2CircleButton3
        Me.Guna2CircleButton3.Location = New System.Drawing.Point(279, -55)
        Me.Guna2CircleButton3.Name = "Guna2CircleButton3"
        Me.Guna2CircleButton3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CircleButton3.ShadowDecoration.Parent = Me.Guna2CircleButton3
        Me.Guna2CircleButton3.Size = New System.Drawing.Size(136, 145)
        Me.Guna2CircleButton3.TabIndex = 32
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(314, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 37)
        Me.Label2.TabIndex = 33
        Me.Label2.Tag = "x"
        Me.Label2.Text = "X"
        '
        'GEMP
        '
        Me.GEMP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GEMP.Location = New System.Drawing.Point(12, 12)
        Me.GEMP.Name = "GEMP"
        Me.GEMP.RowTemplate.Height = 24
        Me.GEMP.Size = New System.Drawing.Size(19, 14)
        Me.GEMP.TabIndex = 34
        Me.GEMP.Visible = False
        '
        'GDROITS
        '
        Me.GDROITS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GDROITS.Location = New System.Drawing.Point(12, 42)
        Me.GDROITS.Name = "GDROITS"
        Me.GDROITS.RowTemplate.Height = 24
        Me.GDROITS.Size = New System.Drawing.Size(19, 14)
        Me.GDROITS.TabIndex = 35
        Me.GDROITS.Visible = False
        '
        'AUTHENTIFICATION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(357, 425)
        Me.Controls.Add(Me.GDROITS)
        Me.Controls.Add(Me.GEMP)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Guna2CircleButton3)
        Me.Controls.Add(Me.Guna2CircleButton2)
        Me.Controls.Add(Me.Guna2CircleButton1)
        Me.Controls.Add(Me.TCODE)
        Me.Controls.Add(Me.CLOGIN)
        Me.Controls.Add(Me.BTN_LOGIN)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AUTHENTIFICATION"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AUTHENTIFICATION"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GEMP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GDROITS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TCODE As System.Windows.Forms.TextBox
    Friend WithEvents CLOGIN As System.Windows.Forms.ComboBox
    Friend WithEvents BTN_LOGIN As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Guna2CircleButton1 As Guna.UI2.WinForms.Guna2CircleButton
    Friend WithEvents Guna2CircleButton2 As Guna.UI2.WinForms.Guna2CircleButton
    Friend WithEvents Guna2CircleButton3 As Guna.UI2.WinForms.Guna2CircleButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GEMP As System.Windows.Forms.DataGridView
    Friend WithEvents GDROITS As System.Windows.Forms.DataGridView
End Class
