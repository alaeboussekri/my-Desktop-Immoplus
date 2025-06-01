Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class PROPRIETAIRE
    Private con As New MySqlConnection("server=localhost;userid=root;password=alae;port=3306;database=immo")
    Private dtadapter As New MySqlDataAdapter("select *from proprietaire", con)
    Private dtset As New DataSet
    Dim x As DialogResult
    Private Sub PROPRIETAIRE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
        dtadapter.Fill(dtset, "proprietaire")
        GPROP.DataSource = dtset.Tables("proprietaire")
        con.Close()
        For s = 0 To Me.GPROP.RowCount - 2
            CID.Items.Add(Me.GPROP.Item(0, s).Value)
            CCIN.Items.Add(Me.GPROP.Item(1, s).Value)

        Next

    End Sub
    Private Sub LEMPLOYE_Click(sender As Object, e As EventArgs) Handles LEMPLOYE.Click
        EMPLOYE.Show()
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

    Private Sub LDASHBOARD_Click(sender As Object, e As EventArgs) Handles LDASHBOARD.Click
        DASHBOARD.Show()
        Me.Hide()
    End Sub

    Private Sub LCIENT_Click(sender As Object, e As EventArgs) Handles LCIENT.Click
        CLIENT1.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        End
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        DASHBOARD.Show()
        Me.Hide()
    End Sub

    Private Sub BTN_RAZ_Click(sender As Object, e As EventArgs) Handles BTN_RAZ.Click
        X = MessageBox.Show("Voulez Vous Vraiment Effacer ", "Gestion IMMO + ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If X = MsgBoxResult.Yes Then
            CID.Text = Nothing
            CCIN.Text = Nothing
            TNOM.Text = Nothing
            TPRENOM.Text = Nothing
            R_HOMME.Checked = False
            R_FEMME.Checked = False
            TTELE.Text = Nothing
        End If
    End Sub

    Private Sub BTN_AJOUT_Click(sender As Object, e As EventArgs) Handles BTN_AJOUT.Click
        'Bouton Ajout
        x = MessageBox.Show("Voulez Vous Vraiment Ajouter", "Gestion IMMO + ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If x = MsgBoxResult.Yes Then
            'Bouton Ajout
            Dim sw As Integer = 0
            For s = 0 To Me.GPROP.RowCount - 2
                If CID.Text = Me.GPROP.Item(0, s).Value Then
                    sw = 1
                    s = Me.GPROP.RowCount - 2
                End If
            Next
            If sw = 0 Then
                If CID.Text <> "" And CCIN.Text <> "" And TNOM.Text <> "" And TPRENOM.Text <> "" And TTELE.Text <> "" Then
                    Dim NewLigne As DataRow
                    ' Création de la nouvelle ligne 
                    NewLigne = dtset.Tables("proprietaire").NewRow
                    'affectation des valeurs
                    NewLigne(0) = CID.Text
                    NewLigne(1) = CCIN.Text
                    NewLigne(2) = TNOM.Text
                    NewLigne(3) = TPRENOM.Text
                    If R_FEMME.Checked = True Then
                        NewLigne(4) = R_FEMME.Text
                    Else
                        NewLigne(4) = R_HOMME.Text
                    End If
                    NewLigne(5) = TTELE.Text

                    ' Ajout de la ligne à la table
                    dtset.Tables("proprietaire").Rows.Add(NewLigne)
                    ' Création CommandBuilder 
                    '(genere automatiquement l'update entre le dataSet et la base de donnée

                    Dim CmdBuild As MySqlClient.MySqlCommandBuilder
                    CmdBuild = New MySqlClient.MySqlCommandBuilder(dtadapter)
                    dtadapter.InsertCommand = CmdBuild.GetInsertCommand
                    dtadapter.Update(dtset, "proprietaire")
                    MsgBox("Ajout Avec Succes", MsgBoxStyle.Information)
                    con.Close()
                Else
                    MsgBox("Vous Devez Remplir Tous Les Champs SVP", MsgBoxStyle.Exclamation)
                End If
            Else
                MsgBox("ID Existe Déjà", MsgBoxStyle.Critical)
            End If

        End If

    End Sub

    Private Sub CID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CID.SelectedIndexChanged
        If CID.Text <> "" Then
            For s = 0 To Me.GPROP.RowCount - 2
                If CID.Text = Me.GPROP.Item(0, s).Value Then
                    CCIN.Text = Me.GPROP.Item(1, s).Value
                    TNOM.Text = Me.GPROP.Item(2, s).Value
                    TPRENOM.Text = Me.GPROP.Item(3, s).Value
                    If GPROP.Item(4, s).Value = "HOMME" Then
                        R_HOMME.Checked = True
                    Else
                        R_FEMME.Checked = True
                    End If
                    TTELE.Text = Me.GPROP.Item(5, s).Value
                End If
            Next
        End If

    End Sub

    Private Sub GPROP_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GPROP.CellClick
        Dim ligneencours As Integer
        ligneencours = GPROP.CurrentRow.Index
        CID.Text = GPROP.Item(0, ligneencours).Value
        CCIN.Text = GPROP.Item(1, ligneencours).Value
        TNOM.Text = GPROP.Item(2, ligneencours).Value
        TPRENOM.Text = GPROP.Item(3, ligneencours).Value
        If GPROP.Item(4, ligneencours).Value = "HOMME" Then
            R_HOMME.Checked = True
        Else
            R_FEMME.Checked = True
        End If
        TTELE.Text = GPROP.Item(5, ligneencours).Value

    End Sub


    Private Sub BTN_RE_Click(sender As Object, e As EventArgs) Handles BTN_RE.Click
        x = MessageBox.Show("Voulez Vous Vraiment Rechercher", "Gestion  IMMO +", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If x = MsgBoxResult.Yes Then
            If CID.Text = Nothing Then
                Dim a As Integer
                Dim sw As Integer = 0
                a = InputBox("Entrer ID Demandé", "Projet BIBnet")

                For s = 0 To Me.GPROP.RowCount - 2
                    If a = Me.GPROP.Item(0, s).Value Then
                        sw = 1
                        CID.Text = Me.GPROP.Item(0, s).Value
                        CCIN.Text = Me.GPROP.Item(1, s).Value
                        TNOM.Text = Me.GPROP.Item(2, s).Value
                        TPRENOM.Text = Me.GPROP.Item(3, s).Value
                        If GPROP.Item(4, s).Value = "HOMME" Then
                            R_HOMME.Checked = True
                        Else
                            R_FEMME.Checked = True
                        End If
                        TTELE.Text = Me.GPROP.Item(5, s).Value
                    End If
                Next

                If sw = 0 Then
                    MsgBox("ID Introuvable", MsgBoxStyle.Critical)
                End If

            Else
                Dim sw As Integer = 0
                For s = 0 To Me.GPROP.RowCount - 2
                    If CID.Text = Me.GPROP.Item(0, s).Value Then
                        sw = 1
                        CCIN.Text = Me.GPROP.Item(1, s).Value
                        TNOM.Text = Me.GPROP.Item(2, s).Value
                        TPRENOM.Text = Me.GPROP.Item(3, s).Value
                        If GPROP.Item(4, s).Value = "HOMME" Then
                            R_HOMME.Checked = True
                        Else
                            R_FEMME.Checked = True
                        End If
                        TTELE.Text = Me.GPROP.Item(5, s).Value
                    End If
                Next

                If sw = 0 Then
                    MsgBox("ID Introuvable", MsgBoxStyle.Critical)
                End If

            End If
        End If
    End Sub

    Private Sub BTN_MO_Click(sender As Object, e As EventArgs) Handles BTN_MO.Click
        If MsgBox("voulez vous vraiment Modifier cet enregistrement", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim sw As Integer = 0
            Dim x As Integer
            For s = 0 To Me.GPROP.RowCount - 2
                If CID.Text = Me.GPROP.Item(0, s).Value Then
                    sw = 1
                    x = s
                    s = Me.GPROP.RowCount - 2
                End If
            Next
            If sw = 1 Then
                Dim ligneencours As Integer
                ligneencours = x
                Dim cle As String
                cle = GPROP.Item(0, ligneencours).Value
                Dim matable As DataTable
                matable = dtset.Tables("proprietaire")
                Dim laligne As DataRow()
                laligne = matable.Select("id_prop=" & cle)
                laligne(0).Item(1) = CCIN.Text
                laligne(0).Item(2) = TNOM.Text
                laligne(0).Item(3) = TPRENOM.Text
                If R_FEMME.Checked = True Then
                    laligne(0).Item(4) = R_FEMME.Text
                Else
                    laligne(0).Item(4) = R_HOMME.Text
                End If
                laligne(0).Item(5) = TTELE.Text
                base(dtadapter, "proprietaire")
            Else
                MsgBox("ID N’Existe Pas", MsgBoxStyle.Critical)
            End If
        End If


    End Sub
    Private Sub base(ByVal adapter As MySqlDataAdapter, ByVal table As String)
        ' con.Open() 
        Dim cmdbuilder As MySqlCommandBuilder
        cmdbuilder = New MySqlClient.MySqlCommandBuilder(adapter)
        adapter.UpdateCommand = cmdbuilder.GetUpdateCommand
        adapter.Update(dtset, "proprietaire")
    End Sub

    Private Sub BTN_SU_Click(sender As Object, e As EventArgs) Handles BTN_SU.Click
        'Bouton Suppression
        x = MessageBox.Show("Voulez Vous Vraiment Supprimer Cet Enregistrement", "Gestion BIBNET", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If x = MsgBoxResult.Yes Then
            Dim x As Integer
            For s = 0 To Me.GPROP.RowCount - 2
                If CID.Text = Me.GPROP.Item(0, s).Value Then
                    x = s
                End If
            Next

            Dim ligneencours As Integer
            ligneencours = x
            Dim cle As String
            cle = GPROP.Item(0, ligneencours).Value
            Dim ligne As DataRow()
            ligne = dtset.Tables("proprietaire").Select("id_prop=" & cle)
            ligne(0).Delete() 'Code uniquement pour la suppression dans la base de donnée locale
            CID.Text = Nothing
            CCIN.Text = Nothing
            TNOM.Text = Nothing
            TPRENOM.Text = Nothing
            R_HOMME.Checked = False
            R_FEMME.Checked = False
            TTELE.Text = Nothing
            MsgBox("Suppression Effectuée dans la base de données ", MsgBoxStyle.Information)
            ' con.Open() 
            'ici nous allons ouvrir la connexion pour accéder et utiliser la base de données distante 
            Dim cmdbuilder As MySqlCommandBuilder
            cmdbuilder = New MySqlClient.MySqlCommandBuilder(dtadapter)
            dtadapter.DeleteCommand = cmdbuilder.GetDeleteCommand
            dtadapter.Update(dtset, "proprietaire")
        End If
        con.Close()

    End Sub
End Class