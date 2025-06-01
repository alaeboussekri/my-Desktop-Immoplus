Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class CLIENT1
    Private con As New MySqlConnection("server=localhost;userid=root;password=alae;port=3306;database=immo")
    Private dtadapter As New MySqlDataAdapter("select *from client", con)
    Private dtset As New DataSet
    Dim x As DialogResult
    Private Sub LDASHBOARD_Click(sender As Object, e As EventArgs) Handles LDASHBOARD.Click
        Me.Hide()
        DASHBOARD.Show()
    End Sub
    Private Sub LEMPLOYE_Click(sender As Object, e As EventArgs) Handles LEMPLOYE.Click
        Me.Hide()
        EMPLOYE.Show()
    End Sub
    Private Sub LPROP_Click(sender As Object, e As EventArgs) Handles LPROP.Click
        Me.Hide()
        PROPRIETAIRE.Show()
    End Sub

    Private Sub LBINES_Click(sender As Object, e As EventArgs) Handles LBINES.Click
        Me.Hide()
        BIENS.Show()

    End Sub

    Private Sub Q_Click(sender As Object, e As EventArgs) Handles Q.Click
        Me.Hide()
        OPERATION.Show()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        End
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Hide()
        DASHBOARD.Show()
    End Sub

    Private Sub CLIENT1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
        dtadapter.Fill(dtset, "client")
        GCLIENT.DataSource = dtset.Tables("client")
        con.Close()
        'Rechargement Combo : pour la Préparer à la recherche.
        For s = 0 To Me.GCLIENT.RowCount - 2
            CREF.Items.Add(Me.GCLIENT.Item(0, s).Value)
            CCIN.Items.Add(Me.GCLIENT.Item(9, s).Value)
        Next

    End Sub

    Private Sub BTN_RAZ_Click(sender As Object, e As EventArgs) Handles BTN_RAZ.Click
        x = MessageBox.Show("Voulez Vous Vraiment Effacer ", "Gestion IMMO + ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If x = MsgBoxResult.Yes Then
            CREF.Text = Nothing
            CCIN.Text = Nothing
            TNOM.Text = Nothing
            TPRENOM.Text = Nothing
            DT_NAISSANCE.Value = Date.Now
            R_HOMME.Checked = False
            R_FEMME.Checked = False
            CSIT.Text = Nothing
            CPROF.Text = Nothing
            TTELE.Text = Nothing
            TEMAIL.Text = Nothing
        End If

    End Sub

    Private Sub BTN_AJOUT_Click(sender As Object, e As EventArgs) Handles BTN_AJOUT.Click
        'Bouton Ajout
        x = MessageBox.Show("Voulez Vous Vraiment Ajouter", "Gestion IMMO + ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If x = MsgBoxResult.Yes Then
            Dim sw As Integer = 0
            For s = 0 To Me.GCLIENT.RowCount - 2
                If CREF.Text = Me.GCLIENT.Item(0, s).Value Then
                    sw = 1
                    s = Me.GCLIENT.RowCount - 2
                End If
            Next
            If sw = 0 Then
                If CREF.Text And CCIN.Text <> "" And TNOM.Text <> "" And TPRENOM.Text <> "" And CSIT.Text <> "" And CPROF.Text <> "" And TTELE.Text <> "" And TEMAIL.Text <> "" Then
                    Dim NewLigne As DataRow
                    NewLigne = dtset.Tables("client").NewRow
                    'affectation des valeurs
                    NewLigne(0) = CREF.Text
                    NewLigne(1) = TNOM.Text
                    NewLigne(2) = TPRENOM.Text
                    NewLigne(3) = DT_NAISSANCE.Value
                    If R_FEMME.Checked = True Then
                        NewLigne(4) = R_FEMME.Text
                    Else
                        NewLigne(4) = R_HOMME.Text
                    End If
                    NewLigne(5) = CSIT.Text
                    NewLigne(6) = CPROF.Text
                    NewLigne(7) = TTELE.Text
                    NewLigne(8) = TEMAIL.Text
                    NewLigne(9) = CCIN.Text

                    CREF.Text = Nothing
                    CCIN.Text = Nothing
                    TNOM.Text = Nothing
                    TPRENOM.Text = Nothing
                    DT_NAISSANCE.Value = Date.Now
                    R_HOMME.Checked = False
                    R_FEMME.Checked = False
                    CSIT.Text = Nothing
                    CPROF.Text = Nothing
                    TTELE.Text = Nothing
                    TEMAIL.Text = Nothing
                    ' Ajout de la ligne à la table
                    dtset.Tables("client").Rows.Add(NewLigne)
                    ' Création CommandBuilder 
                    '(genere automatiquement l'update entre le dataSet et la base de donnée
                    Dim CmdBuild As MySqlClient.MySqlCommandBuilder
                    CmdBuild = New MySqlClient.MySqlCommandBuilder(dtadapter)
                    dtadapter.InsertCommand = CmdBuild.GetInsertCommand
                    dtadapter.Update(dtset, "client")
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

    Private Sub GCLIENT_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GCLIENT.CellClick
        Dim ligneencours As Integer
        ligneencours = GCLIENT.CurrentRow.Index
        CREF.Text = GCLIENT.Item(0, ligneencours).Value
        TNOM.Text = GCLIENT.Item(1, ligneencours).Value
        TPRENOM.Text = GCLIENT.Item(2, ligneencours).Value
        DT_NAISSANCE.Value = GCLIENT.Item(3, ligneencours).Value
        If GCLIENT.Item(4, ligneencours).Value = "HOMME" Then
            R_HOMME.Checked = True
        Else
            R_FEMME.Checked = True
        End If
        CSIT.Text = GCLIENT.Item(5, ligneencours).Value
        CPROF.Text = GCLIENT.Item(6, ligneencours).Value
        TTELE.Text = GCLIENT.Item(7, ligneencours).Value
        TEMAIL.Text = GCLIENT.Item(8, ligneencours).Value
        CCIN.Text = GCLIENT.Item(9, ligneencours).Value
    End Sub

    Private Sub CREF_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CREF.SelectedIndexChanged
        If CREF.Text <> "" Then
            For s = 0 To Me.GCLIENT.RowCount - 2
                If CREF.Text = Me.GCLIENT.Item(0, s).Value Then
                    CREF.Text = GCLIENT.Item(0, s).Value
                    TNOM.Text = GCLIENT.Item(1, s).Value
                    TPRENOM.Text = GCLIENT.Item(2, s).Value
                    DT_NAISSANCE.Value = GCLIENT.Item(3, s).Value
                    If GCLIENT.Item(4, s).Value = "HOMME" Then
                        R_HOMME.Checked = True
                    Else
                        R_FEMME.Checked = True
                    End If
                    CSIT.Text = GCLIENT.Item(5, s).Value
                    CPROF.Text = GCLIENT.Item(6, s).Value
                    TTELE.Text = GCLIENT.Item(7, s).Value
                    TEMAIL.Text = GCLIENT.Item(8, s).Value
                    CCIN.Text = GCLIENT.Item(9, s).Value
                End If
            Next
        End If

    End Sub

    Private Sub BTN_RE_Click(sender As Object, e As EventArgs) Handles BTN_RE.Click
        x = MessageBox.Show("Voulez Vous Vraiment Rechercher", "Gestion  IMMO +", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If x = MsgBoxResult.Yes Then
            If CREF.Text = Nothing Then
                Dim a As Integer
                Dim sw As Integer = 0
                a = InputBox("Entrer Referance Demandé", "Projet IMMO+")

                For s = 0 To Me.GCLIENT.RowCount - 2
                    If a = Me.GCLIENT.Item(0, s).Value Then
                        sw = 1
                        CREF.Text = GCLIENT.Item(0, s).Value
                        TNOM.Text = GCLIENT.Item(1, s).Value
                        TPRENOM.Text = GCLIENT.Item(2, s).Value
                        DT_NAISSANCE.Value = GCLIENT.Item(3, s).Value
                        If GCLIENT.Item(4, s).Value = "HOMME" Then
                            R_HOMME.Checked = True
                        Else
                            R_FEMME.Checked = True
                        End If
                        CSIT.Text = GCLIENT.Item(5, s).Value
                        CPROF.Text = GCLIENT.Item(6, s).Value
                        TTELE.Text = GCLIENT.Item(7, s).Value
                        TEMAIL.Text = GCLIENT.Item(8, s).Value
                        CCIN.Text = GCLIENT.Item(9, s).Value
                    End If
                Next

                If sw = 0 Then
                    MsgBox("Referance Introuvable", MsgBoxStyle.Critical)
                End If

            Else
                Dim sw As Integer = 0
                For s = 0 To Me.GCLIENT.RowCount - 2
                    If CREF.Text = Me.GCLIENT.Item(0, s).Value Then
                        sw = 1
                        CREF.Text = GCLIENT.Item(0, s).Value
                        TNOM.Text = GCLIENT.Item(1, s).Value
                        TPRENOM.Text = GCLIENT.Item(2, s).Value
                        DT_NAISSANCE.Value = GCLIENT.Item(3, s).Value
                        If GCLIENT.Item(4, s).Value = "HOMME" Then
                            R_HOMME.Checked = True
                        Else
                            R_FEMME.Checked = True
                        End If
                        CSIT.Text = GCLIENT.Item(5, s).Value
                        CPROF.Text = GCLIENT.Item(6, s).Value
                        TTELE.Text = GCLIENT.Item(7, s).Value
                        TEMAIL.Text = GCLIENT.Item(8, s).Value
                        CCIN.Text = GCLIENT.Item(9, s).Value
                    End If
                Next

                If sw = 0 Then
                    MsgBox("Referance Introuvable", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub

    Private Sub BTN_MO_Click(sender As Object, e As EventArgs) Handles BTN_MO.Click
        If MsgBox("voulez vous vraiment Modifier cet enregistrement", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim sw As Integer = 0
            Dim x As Integer
            For s = 0 To Me.GCLIENT.RowCount - 2
                If CREF.Text = Me.GCLIENT.Item(0, s).Value Then
                    sw = 1
                    x = s
                    s = Me.GCLIENT.RowCount - 2
                End If
            Next
            If sw = 1 Then
                Dim ligneencours As Integer
                ligneencours = x
                Dim cle As String
                cle = GCLIENT.Item(0, ligneencours).Value
                Dim matable As DataTable
                matable = dtset.Tables("client")
                Dim laligne As DataRow()
                laligne = matable.Select("ref_client=" & cle)
                laligne(0).Item(1) = TNOM.Text
                laligne(0).Item(2) = TPRENOM.Text
                laligne(0).Item(3) = DT_NAISSANCE.Value
                If R_FEMME.Checked = True Then
                    laligne(0).Item(4) = R_FEMME.Text
                Else
                    laligne(0).Item(4) = R_HOMME.Text
                End If
                laligne(0).Item(5) = CSIT.Text
                laligne(0).Item(6) = CPROF.Text
                laligne(0).Item(7) = TTELE.Text
                laligne(0).Item(8) = TEMAIL.Text
                laligne(0).Item(9) = CCIN.Text
                CREF.Text = Nothing
                CCIN.Text = Nothing
                TNOM.Text = Nothing
                TPRENOM.Text = Nothing
                DT_NAISSANCE.Value = Date.Now
                R_HOMME.Checked = False
                R_FEMME.Checked = False
                CSIT.Text = Nothing
                CPROF.Text = Nothing
                TTELE.Text = Nothing
                TEMAIL.Text = Nothing
                base(dtadapter, "client")
            Else
                MsgBox("Referance N’Existe Pas", MsgBoxStyle.Critical)
            End If
        End If


    End Sub
    Private Sub base(ByVal adapter As MySqlDataAdapter, ByVal table As String)
        ' con.Open() 
        Dim cmdbuilder As MySqlCommandBuilder
        cmdbuilder = New MySqlClient.MySqlCommandBuilder(adapter)
        adapter.UpdateCommand = cmdbuilder.GetUpdateCommand
        adapter.Update(dtset, "client")
    End Sub

    Private Sub BTN_SU_Click(sender As Object, e As EventArgs) Handles BTN_SU.Click
        'Bouton Suppression
        x = MessageBox.Show("Voulez Vous Vraiment Supprimer Cet Enregistrement", "Gestion BIBNET", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If x = MsgBoxResult.Yes Then
            Dim x As Integer
            For s = 0 To Me.GCLIENT.RowCount - 2
                If CREF.Text = Me.GCLIENT.Item(0, s).Value Then
                    x = s
                End If
            Next

            Dim ligneencours As Integer
            ligneencours = x
            Dim cle As String
            cle = GCLIENT.Item(0, ligneencours).Value
            Dim ligne As DataRow()
            ligne = dtset.Tables("client").Select("ref_client=" & cle)
            ligne(0).Delete() 'Code uniquement pour la suppression dans la base de donnée locale
            CREF.Text = Nothing
            CCIN.Text = Nothing
            TNOM.Text = Nothing
            TPRENOM.Text = Nothing
            DT_NAISSANCE.Value = Date.Now
            R_HOMME.Checked = False
            R_FEMME.Checked = False
            CSIT.Text = Nothing
            CPROF.Text = Nothing
            TTELE.Text = Nothing
            TEMAIL.Text = Nothing
            MsgBox("Suppression Effectuée dans la base de données Locale", MsgBoxStyle.Information)
            ' con.Open() 
            'ici nous allons ouvrir la connexion pour accéder et utiliser la base de données distante 
            Dim CmdBuild As MySqlClient.MySqlCommandBuilder
            CmdBuild = New MySqlClient.MySqlCommandBuilder(dtadapter)
            dtadapter.InsertCommand = CmdBuild.GetInsertCommand
            dtadapter.Update(dtset, "client")
        End If
        con.Close()

    End Sub
End Class