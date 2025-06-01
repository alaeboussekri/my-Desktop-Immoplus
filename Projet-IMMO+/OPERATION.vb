Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class OPERATION
    Private con As New MySqlConnection("server=localhost;userid=root;password=alae;port=3306;database=immo")
    Private dtadapter As New MySqlDataAdapter("select *from action", con)
    Private dtset As New DataSet
    Private dtadapter1 As New MySqlDataAdapter("select *from employe", con)
    Private dtset1 As New DataSet
    Private dtadapter2 As New MySqlDataAdapter("select *from client", con)
    Private dtset2 As New DataSet
    Private dtadapter3 As New MySqlDataAdapter("select *from biens", con)
    Private dtset3 As New DataSet
    Private dtadapter4 As New MySqlDataAdapter("select *from paiment", con)
    Private dtset4 As New DataSet
    Dim x As DialogResult

    Private Sub OPERATION_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
        dtadapter.Fill(dtset, "action")
        GOPETATION.DataSource = dtset.Tables("action")
        con.Close()
        con.Open()
        dtadapter4.Fill(dtset4, "paiment")
        GPAIEMENT.DataSource = dtset4.Tables("paiment")
        con.Close()
    End Sub
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

    Private Sub LDASHBOARD_Click(sender As Object, e As EventArgs) Handles LDASHBOARD.Click
        DASHBOARD.Show()
        Me.Hide()
    End Sub

    Private Sub BTN_RAZ_Click(sender As Object, e As EventArgs) Handles BTN_RAZ.Click
        x = MessageBox.Show("Voulez Vous Vraiment Effacer ", "Gestion IMMO + ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If x = MsgBoxResult.Yes Then
            CID_ACTION.Text = Nothing
            CID_BIENS.Text = Nothing
            CREF.Text = Nothing
            CCIN.Text = Nothing
            TYPE_AC.Text = Nothing
            DT_AC.Value = Date.Now
            DT_DEBUT.Value = Date.Now
            DT_FIN.Value = Date.Now
            ACTIF.Visible = False
            INACTIF.Visible = False
            CID_P.Text = Nothing
            TMONTANT.Text = Nothing
            CTYPE_P.Text = Nothing

        End If
    End Sub
End Class