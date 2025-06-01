Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Drawing.Image
Imports System.IO

Public Class DASHBOARD
    Private con As New MySqlConnection("server=localhost;userid=root;password=alae;port=3306;database=immo")
    Private dtadapter As New MySqlDataAdapter("select *from employe", con)
    Private dtset As New DataSet

    Private Sub LEMPLOYE_Click(sender As Object, e As EventArgs) Handles LEMPLOYE.Click
        EMPLOYE.Show()
        Me.Hide()
    End Sub

    Private Sub LCIENT_Click(sender As Object, e As EventArgs) Handles LCIENT.Click
        CLIENT1.Show()
        Me.Hide()
    End Sub

    Private Sub LPROP_Click(sender As Object, e As EventArgs) Handles LPROP.Click
        PROPRIETAIRE.Show()
        Me.Hide()
    End Sub

    Private Sub LBINES_Click(sender As Object, e As EventArgs) Handles LBINES.Click
        BIENS.Show()
        Me.Hide()

    End Sub

    Private Sub Q_Click(sender As Object, e As EventArgs) Handles Q.Click
        OPERATION.Show()
        Me.Hide()
    End Sub

    Private Sub DASHBOARD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
        dtadapter.Fill(dtset, "employe")
        GDASH.DataSource = dtset.Tables("employe")
        con.Close()
        Timer1.Enabled = True
        Guna2CirclePictureBox1.Image = PictureBox1.BackgroundImage
        Guna2CirclePictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        GDASH.Visible = False
        Dim sw As Integer = 0
        For s = 0 To Me.GDASH.RowCount - 2
            If Me.GDASH.Item(0, s).Value Then
                Label18.Text = Me.GDASH.Item(3, s).Value
                Guna2CirclePictureBox1.Image = ConvertToImage(GDASH.Item(7, s).Value)
            End If
        Next

    End Sub
  Public Function ConvertToImage(ByVal data() As Byte) As Image
        Dim stream As New MemoryStream(data)
        Return Image.FromStream(stream)
    End Function


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        End
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        con.Close()
        Me.Hide()
        AUTHENTIFICATION.Show()
    End Sub
End Class