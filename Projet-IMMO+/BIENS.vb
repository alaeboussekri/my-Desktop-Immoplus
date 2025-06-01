Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class BIENS
    Private con As New MySqlConnection("server=localhost;userid=root;password=alae;port=3306;database=immo")
    Private dtadapter As New MySqlDataAdapter("select *from biens", con)
    Private dtset As New DataSet
    Private dtadapter1 As New MySqlDataAdapter("select *from type_biens", con)
    Private dtset1 As New DataSet
    Private dtadapter2 As New MySqlDataAdapter("select *from proprietaire", con)
    Private dtset2 As New DataSet
    Dim x As DialogResult
    Dim b As DialogResult

    Private Sub BIENS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
        dtadapter.Fill(dtset, "biens")
        GBIENS.DataSource = dtset.Tables("biens")
        con.Close()
        con.Open()
        dtadapter1.Fill(dtset1, "type_biens")
        GTYPE.DataSource = dtset1.Tables("type_biens")
        con.Close()
        con.Open()
        dtadapter2.Fill(dtset2, "proprietaire")
        GPROP.DataSource = dtset2.Tables("proprietaire")
        con.Close()
        For s = 0 To Me.GPROP.RowCount - 2
            CID_PROP.Items.Add(Me.GPROP.Item(0, s).Value)
            CID_BIENS.Items.Add(Me.GBIENS.Item(0, s).Value)
            CID_T.Items.Add(Me.GTYPE.Item(0, s).Value)

        Next
        BTN_BL.Visible = False
        BTN_DBL.Visible = False
        BTN_A.Visible = True
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

    Private Sub Q_Click(sender As Object, e As EventArgs) Handles Q.Click
        OPERATION.Show()
        Me.Hide()
    End Sub

    Private Sub LDASHBOARD_Click(sender As Object, e As EventArgs) Handles LDASHBOARD.Click
        DASHBOARD.Show()
        Me.Hide()

    End Sub
    Private Sub BTN_RAZ_Click(sender As Object, e As EventArgs) Handles BTN_RAZ.Click
        x = MessageBox.Show("Voulez Vous Vraiment Effacer ", "Gestion IMMO + ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If x = MsgBoxResult.Yes Then
            CID_BIENS.Text = Nothing
            CID_T.Text = Nothing
            CID_PROP.Text = Nothing
            CPAYS.Text = Nothing
            CVILLE.Text = Nothing
            CQUART.Text = Nothing
            CCOM.Text = Nothing
            CVILLE.Text = Nothing
            TNB.Text = Nothing
            TSUP.Text = Nothing
            COP.Text = Nothing
            TPRIX.Text = Nothing
            ACTIF.Visible = False
            INACTIF.Visible = False
            CINTI.Text = Nothing
            R_DISP.Checked = False
            R_PDISP.Checked = False
            BTN_BL.Visible = False
            BTN_DBL.Visible = False
            BTN_A.Visible = True
        End If

    End Sub
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        End
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        DASHBOARD.Show()
        Me.Hide()
    End Sub

    Private Sub BTN_AJOUT_Click(sender As Object, e As EventArgs) Handles BTN_AJOUT.Click
        'Bouton Ajout
        x = MessageBox.Show("Voulez Vous Vraiment Ajouter", "Gestion IMMO + ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If x = MsgBoxResult.Yes Then
            Dim sw As Integer = 0
            For s = 0 To Me.GBIENS.RowCount - 2
                If CID_BIENS.Text = Me.GBIENS.Item(0, s).Value Then
                    sw = 1
                    s = Me.GBIENS.RowCount - 2
                End If
            Next
            If sw = 0 Then
                If CID_BIENS.Text <> "" And CID_T.Text <> "" And CID_PROP.Text <> "" And CPAYS.Text <> "" And CVILLE.Text <> "" And CQUART.Text <> "" And CCOM.Text <> "" And TNB.Text <> "" And TSUP.Text <> "" And COP.Text <> "" And TPRIX.Text <> "" And CINTI.Text <> "" Then
                    Dim NewLigne As DataRow
                    ' Création de la nouvelle ligne 
                    NewLigne = dtset.Tables("biens").NewRow

                    'affectation des valeurs
                    NewLigne(0) = CID_BIENS.Text
                    NewLigne(1) = CID_T.Text
                    NewLigne(2) = CID_PROP.Text
                    NewLigne(3) = CPAYS.Text
                    NewLigne(4) = CVILLE.Text
                    NewLigne(5) = CQUART.Text
                    NewLigne(6) = CCOM.Text
                    NewLigne(7) = TNB.Text
                    NewLigne(8) = COP.Text
                    NewLigne(9) = TPRIX.Text
                    NewLigne(10) = "ACTIF"
                    NewLigne(11) = TSUP.Text
          




                    Dim NewLigne1 As DataRow
                    ' Ajout de la ligne à la table
                    NewLigne1 = dtset1.Tables("type_biens").NewRow

                    NewLigne1(0) = CID_T.Text
                    NewLigne1(1) = CINTI.Text
                    If R_DISP.Checked = True Then
                        NewLigne1(2) = R_DISP.Text
                    Else
                        NewLigne1(2) = R_PDISP
                    End If


                    ' Ajout de la ligne à la table
                    dtset.Tables("biens").Rows.Add(NewLigne)
                    dtset1.Tables("type_biens").Rows.Add(NewLigne1)

                    ' Création CommandBuilder 
                    '(genere automatiquement l'update entre le dataSet et la base de donnée
                    Dim CmdBuild As MySqlClient.MySqlCommandBuilder
                    CmdBuild = New MySqlClient.MySqlCommandBuilder(dtadapter)
                    dtadapter.InsertCommand = CmdBuild.GetInsertCommand
                    dtadapter.Update(dtset, "biens")

                    Dim CmdBuild1 As MySqlClient.MySqlCommandBuilder
                    CmdBuild1 = New MySqlClient.MySqlCommandBuilder(dtadapter1)
                    dtadapter1.InsertCommand = CmdBuild1.GetInsertCommand
                    dtadapter1.Update(dtset1, "type_biens")
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

    Private Sub GBIENS_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GBIENS.CellClick
        Dim ligneencours As Integer
        ligneencours = GBIENS.CurrentRow.Index
        Dim ligneencours1 As Integer


        CID_BIENS.Text = GBIENS.Item(0, ligneencours).Value
        CID_T.Text = GBIENS.Item(1, ligneencours).Value
        CID_PROP.Text = GBIENS.Item(2, ligneencours).Value
        CPAYS.Text = GBIENS.Item(3, ligneencours).Value
        CVILLE.Text = GBIENS.Item(4, ligneencours).Value
        CQUART.Text = GBIENS.Item(5, ligneencours).Value
        CCOM.Text = GBIENS.Item(6, ligneencours).Value
        TNB.Text = GBIENS.Item(7, ligneencours).Value
        COP.Text = GBIENS.Item(8, ligneencours).Value
        TPRIX.Text = GBIENS.Item(9, ligneencours).Value
        If GBIENS.Item(10, ligneencours).Value = "ACTIF" Then
            ACTIF.Visible = True
            INACTIF.Visible = False
            BTN_BL.Visible = True
            BTN_DBL.Visible = False
            BTN_A.Visible = False
        Else
            ACTIF.Visible = False
            INACTIF.Visible = True
            BTN_BL.Visible = False
            BTN_DBL.Visible = True
            BTN_A.Visible = False
        End If
        TSUP.Text = GBIENS.Item(11, ligneencours).Value

        CINTI.Text = GTYPE.Item(1, ligneencours1).value
        If GTYPE.Item(2, ligneencours1).Value = "Disponible" Then
            R_DISP.Checked = True
        Else
            R_PDISP.Checked = True
        End If
    End Sub


    Private Sub CID_BIENS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CID_BIENS.SelectedIndexChanged
        If CID_BIENS.Text <> "" Then
            For s = 0 To Me.GBIENS.RowCount - 2
                If CID_BIENS.Text = Me.GBIENS.Item(0, s).Value Then
                    CID_T.Text = GBIENS.Item(1, s).Value
                    CID_PROP.Text = GBIENS.Item(2, s).Value
                    CPAYS.Text = GBIENS.Item(3, s).Value
                    CVILLE.Text = GBIENS.Item(4, s).Value
                    CQUART.Text = GBIENS.Item(5, s).Value
                    CCOM.Text = GBIENS.Item(6, s).Value
                    TNB.Text = GBIENS.Item(7, s).Value
                    COP.Text = GBIENS.Item(8, s).Value
                    TPRIX.Text = GBIENS.Item(9, s).Value
                    If GBIENS.Item(10, s).Value = "ACTIF" Then
                        ACTIF.Visible = True
                        INACTIF.Visible = False
                        BTN_BL.Visible = True
                        BTN_DBL.Visible = False
                        BTN_A.Visible = False
                    Else
                        ACTIF.Visible = False
                        INACTIF.Visible = True
                        BTN_BL.Visible = False
                        BTN_DBL.Visible = True
                        BTN_A.Visible = False
                    End If
                    TSUP.Text = GBIENS.Item(11, s).Value
                End If
                For d = 0 To Me.GTYPE.RowCount - 2
                    If CID_T.Text = Me.GTYPE.Item(0, d).Value Then
                        CINTI.Text = GTYPE.Item(1, d).Value
                        If GTYPE.Item(2, d).Value = "Disponible" Then
                            R_DISP.Checked = True
                        Else
                            R_PDISP.Checked = True
                        End If

                    End If
                Next
            Next
        End If

    End Sub

    Private Sub BTN_RE_Click(sender As Object, e As EventArgs) Handles BTN_RE.Click
        x = MessageBox.Show("Voulez Vous Vraiment Rechercher", "Gestion  IMMO +", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If x = MsgBoxResult.Yes Then
            If CID_BIENS.Text = Nothing Then
                Dim a As String
                Dim sw As Integer = 0
                a = InputBox("Entrer ID Demandé", "Projet IMMO+")

                For s = 0 To Me.GBIENS.RowCount - 2
                    If a = Me.GBIENS.Item(0, s).Value Then
                        CID_T.Text = GBIENS.Item(1, s).Value
                        CID_PROP.Text = GBIENS.Item(2, s).Value
                        CPAYS.Text = GBIENS.Item(3, s).Value
                        CVILLE.Text = GBIENS.Item(4, s).Value
                        CQUART.Text = GBIENS.Item(5, s).Value
                        CCOM.Text = GBIENS.Item(6, s).Value
                        TNB.Text = GBIENS.Item(7, s).Value
                        COP.Text = GBIENS.Item(8, s).Value
                        TPRIX.Text = GBIENS.Item(9, s).Value
                        If GBIENS.Item(10, s).Value = "ACTIF" Then
                            ACTIF.Visible = True
                            INACTIF.Visible = False
                            BTN_BL.Visible = True
                            BTN_DBL.Visible = False
                            BTN_A.Visible = False
                        Else
                            ACTIF.Visible = False
                            INACTIF.Visible = True
                            BTN_BL.Visible = False
                            BTN_DBL.Visible = True
                            BTN_A.Visible = False
                        End If
                        TSUP.Text = GBIENS.Item(11, s).Value
                    End If
                    For d = 0 To Me.GTYPE.RowCount - 2
                        If a <> Me.GTYPE.Item(0, d).Value Then
                            CINTI.Text = GTYPE.Item(1, d).Value
                            If GTYPE.Item(2, d).Value = "Disponible" Then
                                R_DISP.Checked = True
                            Else
                                R_PDISP.Checked = True
                            End If

                        End If
                        sw = 1

                    Next

                Next

                If sw = 0 Then
                    MsgBox("ID Introuvable", MsgBoxStyle.Critical)
                End If

            Else
                Dim sw As Integer = 0
                For s = 0 To Me.GBIENS.RowCount - 2
                    If CID_BIENS.Text = Me.GBIENS.Item(0, s).Value Then
                        CID_T.Text = GBIENS.Item(1, s).Value
                        CID_PROP.Text = GBIENS.Item(2, s).Value
                        CPAYS.Text = GBIENS.Item(3, s).Value
                        CVILLE.Text = GBIENS.Item(4, s).Value
                        CQUART.Text = GBIENS.Item(5, s).Value
                        CCOM.Text = GBIENS.Item(6, s).Value
                        TNB.Text = GBIENS.Item(7, s).Value
                        COP.Text = GBIENS.Item(8, s).Value
                        TPRIX.Text = GBIENS.Item(9, s).Value
                        If GBIENS.Item(10, s).Value = "ACTIF" Then
                            ACTIF.Visible = True
                            INACTIF.Visible = False
                            BTN_BL.Visible = True
                            BTN_DBL.Visible = False
                            BTN_A.Visible = False
                        Else
                            ACTIF.Visible = False
                            INACTIF.Visible = True
                            BTN_BL.Visible = False
                            BTN_DBL.Visible = True
                            BTN_A.Visible = False
                        End If
                        TSUP.Text = GBIENS.Item(11, s).Value
                    End If
                    For d = 0 To Me.GTYPE.RowCount - 2
                        If CID_T.Text = Me.GTYPE.Item(0, d).Value Then
                            CINTI.Text = GTYPE.Item(1, d).Value
                            If GTYPE.Item(2, d).Value = "Disponible" Then
                                R_DISP.Checked = True
                            Else
                                R_PDISP.Checked = True
                            End If

                        End If
                    Next
                    sw = 1
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
            For s = 0 To Me.GBIENS.RowCount - 2
                If CID_BIENS.Text = Me.GBIENS.Item(0, s).Value Then
                    sw = 1
                    x = s
                    s = Me.GBIENS.RowCount - 2
                End If
            Next
            If sw = 1 Then
                Dim ligneencours As Integer
                ligneencours = x
                Dim cle As String
                cle = GBIENS.Item(0, ligneencours).Value
                Dim matable As DataTable
                matable = dtset.Tables("biens")
                Dim laligne As DataRow()
                laligne = matable.Select("id_biens=" & cle)
                laligne(0).Item(3) = CPAYS.Text
                laligne(0).Item(4) = CVILLE.Text
                laligne(0).Item(5) = CQUART.Text
                laligne(0).Item(6) = CCOM.Text
                laligne(0).Item(7) = TNB.Text
                laligne(0).Item(8) = COP.Text
                laligne(0).Item(9) = TPRIX.Text
                laligne(0).Item(11) = TSUP.Text

                Dim sw1 As Integer = 0
                Dim x1 As Integer
                For s = 0 To Me.GBIENS.RowCount - 2
                    If CID_T.Text = Me.GTYPE.Item(0, s).Value Then
                        sw1 = 1
                        x1 = s
                        s = Me.GTYPE.RowCount - 2
                    End If
                Next
                base(dtadapter, "biens")
                Dim ligneencours1 As Integer
                ligneencours1 = x1
                Dim cle1 As String
                cle1 = GTYPE.Item(0, ligneencours1).Value
                Dim matable1 As DataTable
                matable1 = dtset1.Tables("type_biens")
                Dim laligne1 As DataRow()
                laligne1 = matable1.Select("id_type=" & cle1)
                laligne1(0).Item(1) = CINTI.Text
                If R_DISP.Checked = True Then
                    laligne1(0).Item(2) = R_DISP.Text
                Else
                    laligne1(0).Item(2) = R_PDISP.Text
                End If
                base1(dtadapter, "type_biens")
            End If


        Else
            MsgBox("ID N’Existe Pas", MsgBoxStyle.Critical)
        End If

    End Sub
    Private Sub base1(ByVal adapter As MySqlDataAdapter, ByVal table As String)
        ' con.Open() 
        Dim cmdbuilder1 As MySqlCommandBuilder
        cmdbuilder1 = New MySqlClient.MySqlCommandBuilder(dtadapter1)
        dtadapter1.UpdateCommand = cmdbuilder1.GetUpdateCommand
        dtadapter1.Update(dtset1, "type_biens")
    End Sub
    Private Sub base(ByVal adapter As MySqlDataAdapter, ByVal table As String)
        ' con.Open() 
        Dim cmdbuilder As MySqlCommandBuilder
        cmdbuilder = New MySqlClient.MySqlCommandBuilder(adapter)
        adapter.UpdateCommand = cmdbuilder.GetUpdateCommand
        adapter.Update(dtset, "biens")
    End Sub

    Private Sub BTN_SU_Click(sender As Object, e As EventArgs) Handles BTN_SU.Click
        b = MessageBox.Show("Voulez Vous Vraiment Supprimer     ", "Gestion IMMO + ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If b = MsgBoxResult.Yes Then
            'Bouton Suppression
            Dim x As Integer
            Dim x1 As Integer

            For s = 0 To Me.GBIENS.RowCount - 2
                If CID_BIENS.Text = Me.GBIENS.Item(0, s).Value Then
                    x = s
                End If
            Next
            For d = 0 To Me.GTYPE.RowCount - 2
                If CID_T.Text = Me.GBIENS.Item(0, d).Value Then
                    x1 = d
                End If
            Next
            Dim ligneencours As Integer
            ligneencours = x
            Dim cle As String
            cle = GBIENS.Item(0, ligneencours).Value
            Dim ligne As DataRow()
            ligne = dtset.Tables("biens").Select("id_biens=" & cle)
            ligne(0).Delete() 'Code uniquement pour la suppression dans la base de donnée locale

            Dim ligneencours1 As Integer
            ligneencours1 = x1
            Dim cle1 As String
            cle1 = GTYPE.Item(0, ligneencours1).Value
            Dim ligne1 As DataRow()
            ligne1 = dtset1.Tables("type_biens").Select("id_type=" & cle1)
            ligne1(0).Delete() 'Code uniquement pour la suppression dans la base de donnée locale
            CID_BIENS.Text = Nothing
            CID_T.Text = Nothing
            CID_PROP.Text = Nothing
            CPAYS.Text = Nothing
            CVILLE.Text = Nothing
            CQUART.Text = Nothing
            CCOM.Text = Nothing
            CVILLE.Text = Nothing
            TNB.Text = Nothing
            TSUP.Text = Nothing
            COP.Text = Nothing
            TPRIX.Text = Nothing
            ACTIF.Visible = False
            INACTIF.Visible = False
            CINTI.Text = Nothing
            R_DISP.Checked = False
            R_PDISP.Checked = False
            BTN_BL.Visible = False
            BTN_DBL.Visible = False
            BTN_A.Visible = True
       
            MsgBox("Suppression Effectuée dans la base de données Locale", MsgBoxStyle.Information)
            ' con.Open() 
            'ici nous allons ouvrir la connexion pour accéder et utiliser la base de données distante 
            Dim cmdbuilder As MySqlCommandBuilder
            cmdbuilder = New MySqlClient.MySqlCommandBuilder(dtadapter)
            dtadapter.DeleteCommand = cmdbuilder.GetDeleteCommand
            dtadapter.Update(dtset, "biens")

            Dim cmdbuilder1 As MySqlCommandBuilder
            cmdbuilder1 = New MySqlClient.MySqlCommandBuilder(dtadapter1)
            dtadapter1.DeleteCommand = cmdbuilder1.GetDeleteCommand
            dtadapter1.Update(dtset1, "type_biens")
            con.Close()
        End If
    End Sub

    Private Sub BTN_BL_Click(sender As Object, e As EventArgs) Handles BTN_BL.Click
        If MsgBox("voulez vous vraiment bloquer cet enregistrement", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim sw As Integer = 0
            Dim x As Integer
            For s = 0 To Me.GBIENS.RowCount - 2
                If CID_BIENS.Text = Me.GBIENS.Item(0, s).Value Then
                    sw = 1
                    x = s
                    s = Me.GBIENS.RowCount - 2
                End If
            Next
            If sw = 1 Then
                Dim ligneencours As Integer
                ligneencours = x
                Dim cle As String
                cle = GBIENS.Item(0, ligneencours).Value
                Dim matable As DataTable
                matable = dtset.Tables("biens")
                Dim laligne As DataRow()
                laligne = matable.Select("id_biens=" & cle)
                laligne(0).Item(10) = "INACTIF"
                INACTIF.Visible = True
                ACTIF.Visible = False
                BTN_BL.Visible = False
                BTN_DBL.Visible = True
                BTN_A.Visible = False
                base(dtadapter, "biens")


            Else
                MsgBox("ID N’Existe Pas", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub BTN_DBL_Click(sender As Object, e As EventArgs) Handles BTN_DBL.Click
        If MsgBox("voulez vous vraiment débloquer cet enregistrement", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim sw As Integer = 0
            Dim x As Integer
            For s = 0 To Me.GBIENS.RowCount - 2
                If CID_BIENS.Text = Me.GBIENS.Item(0, s).Value Then
                    sw = 1
                    x = s
                    s = Me.GBIENS.RowCount - 2
                End If
            Next
            If sw = 1 Then
                Dim ligneencours As Integer
                ligneencours = x
                Dim cle As String
                cle = GBIENS.Item(0, ligneencours).Value
                Dim matable As DataTable
                matable = dtset.Tables("biens")
                Dim laligne As DataRow()
                laligne = matable.Select("id_biens=" & cle)
                laligne(0).Item(10) = "ACTIF"
                INACTIF.Visible = False
                ACTIF.Visible = True
                BTN_BL.Visible = True
                BTN_DBL.Visible = False
                BTN_A.Visible = False
                base(dtadapter, "biens")

            Else
                MsgBox("ID N’Existe Pas", MsgBoxStyle.Critical)
            End If
        End If
    End Sub
End Class