Imports MySql.Data.MySqlClient
Public Class AUTHENTIFICATION
    Private con As New MySqlConnection("server=localhost;userid=root;password=alae;port=3306;database=immo")
    Private dtadapter As New MySqlDataAdapter("select *from employe", con)
    Private dtadapter1 As New MySqlDataAdapter("select *from droits", con)
    Private dtset1 As New DataSet
    Private dtset As New DataSet

    Private Sub BTN_LOGIN_Click(sender As Object, e As EventArgs) Handles BTN_LOGIN.Click
        ' Dim conn As New MySqlConnection("server=localhost;userid=root;password=alae;port=3306;database=immo")
        con.Open()
        Dim cmd As New MySqlCommand("Select * From employe WHERE cin_emp=@username AND code_acces=@password", con)
        cmd.Parameters.AddWithValue("username", CLOGIN.Text.Trim)
        cmd.Parameters.AddWithValue("password", TCODE.Text.Trim)
        Dim reader As MySqlDataReader = cmd.ExecuteReader
        If reader.Read Then
            DASHBOARD.Show()
            Me.Hide()

        Else
            MsgBox(" login ou mot de passe invalide")
        End If

    End Sub

    Private Sub AUTHENTIFICATION_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
        dtadapter.Fill(dtset, "employe")
        GEMP.DataSource = dtset.Tables("employe")
        con.Close()
        con.Open()
        dtadapter1.Fill(dtset1, "droits")
        GDROITS.DataSource = dtset1.Tables("droits")
        con.Close()
        For s = 0 To Me.GEMP.RowCount - 2
            CLOGIN.Items.Add(Me.GEMP.Item(1, s).Value)
        Next
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        End
    End Sub
End Class