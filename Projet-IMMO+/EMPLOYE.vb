Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Drawing.Image
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class EMPLOYE
    Private con As New MySqlConnection("server=localhost;userid=root;password=alae;port=3306;database=immo")
    Private dtadapter As New MySqlDataAdapter("select *from employe", con)
    Private dtset As New DataSet
    Private dtadapter1 As New MySqlDataAdapter("select *from droits", con)
    Private dtset1 As New DataSet
    Private dtadapter2 As New MySqlDataAdapter("select *from client", con)
    Private dtset2 As New DataSet
    Private dtadapter3 As New MySqlDataAdapter("select *from biens", con)
    Private dtset3 As New DataSet
    Dim x As DialogResult
    Dim b As DialogResult

    Private Sub EMPLOYE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
        dtadapter.Fill(dtset, "employe")
        GEMP.DataSource = dtset.Tables("employe")
        con.Close()
        con.Open()
        dtadapter1.Fill(dtset1, "droits")
        DDROITS.DataSource = dtset1.Tables("droits")
        con.Close()
        PictureBox10.Image = PictureBox10.BackgroundImage
        PictureBox10.BackgroundImageLayout = ImageLayout.Stretch
        D_EMPLOYE.Value = False
        D_CLIENT.Value = False
        D_BIENS.Value = False
        D_OPERATION.Value = False
        'Rechargement Combo : pour la Préparer à la recherche.
        For s = 0 To Me.GEMP.RowCount - 2
            CCIN.Items.Add(Me.GEMP.Item(1, s).Value)
        Next
        BTN_BL.Visible = False
        BTN_DBL.Visible = False
        BTN_A.Visible = True
    End Sub
    Private Sub BTN_RAZ_Click(sender As Object, e As EventArgs) Handles BTN_RAZ.Click
        x = MessageBox.Show("Voulez Vous Vraiment Effacer ", "Gestion IMMO + ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If x = MsgBoxResult.Yes Then
            CID.Text = Nothing
            CCIN.Text = Nothing
            TNOM.Text = Nothing
            TPRENOM.Text = Nothing
            DT_NAISSANCE.Value = Date.Now
            R_HOMME.Checked = False
            R_FEMME.Checked = False
            CVILLE.Text = Nothing
            TADRESSE.Text = Nothing
            TTELE.Text = Nothing
            TEMAIL.Text = Nothing
            DT_EMBAUCHE.Value = Date.Now
            PictureBox10.Image = PictureBox10.BackgroundImage
            ACTIF.Visible = False
            INACTIF.Visible = False
        End If
        D_BIENS.Value = False
        D_CLIENT.Value = False
        D_OPERATION.Value = False
        D_EMPLOYE.Value = False
        BTN_BL.Visible = False
        BTN_DBL.Visible = False
        BTN_A.Visible = True

    End Sub
    Private Sub BTN_AJOUT_Click(sender As Object, e As EventArgs) Handles BTN_AJOUT.Click
        'Bouton Ajout
        x = MessageBox.Show("Voulez Vous Vraiment Ajouter", "Gestion IMMO + ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If x = MsgBoxResult.Yes Then
            Dim sw As Integer = 0
            For s = 0 To Me.GEMP.RowCount - 2
                If CCIN.Text = Me.GEMP.Item(1, s).Value Then
                    sw = 1
                    s = Me.GEMP.RowCount - 2
                End If
            Next
            Dim rnd As Random
            Dim number As Integer
            rnd = New Random
            number = rnd.Next(999, 10000)
            If sw = 0 Then
                If CID.Text <> "" And CCIN.Text <> "" And TNOM.Text <> "" And TPRENOM.Text <> "" And CVILLE.Text <> "" And TADRESSE.Text <> "" And TTELE.Text <> "" And TEMAIL.Text <> "" Then
                    Dim NewLigne As DataRow
                    ' Création de la nouvelle ligne 
                    NewLigne = dtset.Tables("EMPLOYE").NewRow

                    'affectation des valeurs
                    NewLigne(0) = CID.Text
                    NewLigne(1) = CCIN.Text
                    NewLigne(2) = TNOM.Text
                    NewLigne(3) = TPRENOM.Text
                    NewLigne(4) = DT_NAISSANCE.Value
                    If R_FEMME.Checked = True Then
                        NewLigne(5) = R_FEMME.Text
                    Else
                        NewLigne(5) = R_HOMME.Text
                    End If
                    NewLigne(6) = CVILLE.Text
                    NewLigne(7) = ConvertToData(Me.PictureBox10.Image)
                    NewLigne(8) = TADRESSE.Text
                    NewLigne(9) = TTELE.Text
                    NewLigne(10) = TEMAIL.Text
                    NewLigne(11) = DT_EMBAUCHE.Value
                    NewLigne(12) = number.ToString
                    NewLigne(13) = LETAT.Text

                    Dim NewLigne1 As DataRow
                    ' Création de la nouvelle ligne 
                    NewLigne1 = dtset1.Tables("droits").NewRow
                    'affectation des valeurs
                    NewLigne1(0) = CID.Text
                    NewLigne1(1) = CCIN.Text
                    If D_EMPLOYE.Value = True Then
                        NewLigne1(2) = "1"
                    Else
                        NewLigne1(2) = "0"
                    End If
                    If D_CLIENT.Value = True Then
                        NewLigne1(3) = "1"
                    Else
                        NewLigne1(3) = "0"
                    End If
                    If D_BIENS.Value = True Then
                        NewLigne1(4) = "1"
                    Else
                        NewLigne1(4) = "0"
                    End If
                    If D_OPERATION.Value = True Then
                        NewLigne1(5) = "1"
                    Else
                        NewLigne1(5) = "0"
                    End If
                    If D_EMPLOYE.Value = True And D_BIENS.Value = True And D_CLIENT.Value = True And D_OPERATION.Value = True Then
                        NewLigne1(6) = "ACTIF"
                    Else
                        NewLigne1(6) = "INACTIF"
                    End If



                    ' Ajout de la ligne à la table
                    dtset1.Tables("droits").Rows.Add(NewLigne1)

                    ' Ajout de la ligne à la table
                    dtset.Tables("employe").Rows.Add(NewLigne)
                    ' Création CommandBuilder 
                    '(genere automatiquement l'update entre le dataSet et la base de donnée
                    Dim CmdBuild As MySqlClient.MySqlCommandBuilder
                    CmdBuild = New MySqlClient.MySqlCommandBuilder(dtadapter)
                    dtadapter.InsertCommand = CmdBuild.GetInsertCommand
                    dtadapter.Update(dtset, "employe")

                    Dim CmdBuild1 As MySqlClient.MySqlCommandBuilder
                    CmdBuild1 = New MySqlClient.MySqlCommandBuilder(dtadapter1)
                    dtadapter1.InsertCommand = CmdBuild1.GetInsertCommand
                    dtadapter1.Update(dtset1, "droits")
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
    Public Function ConvertToData(ByVal myImage As Image) As Byte()
        Dim ms As New MemoryStream()
        myImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim myBytes(ms.Length - 1) As Byte
        ms.Position = 0
        ms.Read(myBytes, 0, ms.Length)
        Return myBytes
    End Function
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

    Private Sub LDASHBOARD_Click(sender As Object, e As EventArgs) Handles LDASHBOARD.Click
        DASHBOARD.Show()
        Me.Hide()
    End Sub
    Public Function ConvertToImage(ByVal data() As Byte) As Image
        Dim stream As New MemoryStream(data)
        Return Image.FromStream(stream)
    End Function
    Private Sub GEMP_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GEMP.CellClick
        Dim ligneencours As Integer
        ligneencours = GEMP.CurrentRow.Index
        Dim ligneencours1 As Integer
        '    ligneencours1 = DDROITS.CurrentRow.Index
        CID.Text = GEMP.Item(0, ligneencours).Value
        CCIN.Text = GEMP.Item(1, ligneencours).Value
        TNOM.Text = GEMP.Item(2, ligneencours).Value
        TPRENOM.Text = GEMP.Item(3, ligneencours).Value
        DT_NAISSANCE.Value = GEMP.Item(4, ligneencours).Value
        If GEMP.Item(5, ligneencours).Value = "HOMME" Then
            R_HOMME.Checked = True
        Else
            R_FEMME.Checked = True
        End If
        CVILLE.Text = GEMP.Item(6, ligneencours).Value
        PictureBox10.Image = ConvertToImage(GEMP.Item(7, ligneencours).Value)
        TADRESSE.Text = GEMP.Item(8, ligneencours).Value
        TTELE.Text = GEMP.Item(9, ligneencours).Value
        TEMAIL.Text = GEMP.Item(10, ligneencours).Value
        DT_EMBAUCHE.Value = GEMP.Item(11, ligneencours).Value
        If GEMP.Item(13, ligneencours).Value = "ACTIF" Then
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
        If DDROITS.Item(2, ligneencours1).Value = "1" Then
            D_EMPLOYE.Value = True
        Else
            D_EMPLOYE.Value = False
        End If
        If DDROITS.Item(3, ligneencours1).Value = "1" Then
            D_CLIENT.Value = True
        Else
            D_CLIENT.Value = False
        End If
        If DDROITS.Item(4, ligneencours1).Value = "1" Then
            D_BIENS.Value = True
        Else
            D_BIENS.Value = False
        End If
        If DDROITS.Item(5, ligneencours1).Value = "1" Then
            D_OPERATION.Value = True
        Else
            D_OPERATION.Value = False
        End If


    End Sub
    Private Sub PictureBox10_Click_1(sender As Object, e As EventArgs) Handles PictureBox10.Click
        Me.OpenFileDialog1.FileName = Nothing
        Me.OpenFileDialog1.ShowDialog()
        If Not Me.OpenFileDialog1.FileName = Nothing Then
            Me.PictureBox10.ImageLocation = Me.OpenFileDialog1.FileName
        End If
    End Sub
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        End

    End Sub
    Private Sub LCLIENT_Click(sender As Object, e As EventArgs) Handles LCLIENT.Click
        CLIENT1.Show()
        Me.Hide()
    End Sub
    Private Sub CCIN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CCIN.SelectedIndexChanged
        If CCIN.Text <> "" Then
            For s = 0 To Me.GEMP.RowCount - 2
                If CCIN.Text = Me.GEMP.Item(1, s).Value Then
                    CID.Text = Me.GEMP.Item(0, s).Value
                    TNOM.Text = Me.GEMP.Item(2, s).Value
                    TPRENOM.Text = Me.GEMP.Item(3, s).Value
                    DT_NAISSANCE.Value = Me.GEMP.Item(4, s).Value
                    If GEMP.Item(5, s).Value = "HOMME" Then
                        R_HOMME.Checked = True
                    Else
                        R_FEMME.Checked = True
                    End If
                    CVILLE.Text = GEMP.Item(6, s).Value
                    PictureBox10.Image = ConvertToImage(GEMP.Item(7, s).Value)
                    TADRESSE.Text = GEMP.Item(8, s).Value
                    TTELE.Text = GEMP.Item(9, s).Value
                    TEMAIL.Text = GEMP.Item(10, s).Value
                    DT_EMBAUCHE.Value = GEMP.Item(11, s).Value
                    If GEMP.Item(13, s).Value = "ACTIF" Then
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
                End If
                For d = 0 To Me.DDROITS.RowCount - 2
                    If CCIN.Text = Me.DDROITS.Item(1, d).Value Then
                        If DDROITS.Item(2, d).Value = "1" Then
                            D_EMPLOYE.Value = True
                        Else
                            D_EMPLOYE.Value = False
                        End If
                        If DDROITS.Item(3, d).Value = "1" Then
                            D_CLIENT.Value = True
                        Else
                            D_CLIENT.Value = False
                        End If
                        If DDROITS.Item(4, d).Value = "1" Then
                            D_BIENS.Value = True
                        Else
                            D_BIENS.Value = False
                        End If
                        If DDROITS.Item(5, d).Value = "1" Then
                            D_OPERATION.Value = True
                        Else
                            D_OPERATION.Value = False
                        End If

                    End If
                Next
            Next
        End If

    End Sub
    Private Sub BTN_RE_Click(sender As Object, e As EventArgs) Handles BTN_RE.Click
        x = MessageBox.Show("Voulez Vous Vraiment Rechercher", "Gestion  IMMO +", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If x = MsgBoxResult.Yes Then
            If CCIN.Text = Nothing Then
                Dim a As String
                Dim sw As Integer = 0
                a = InputBox("Entrer CIN Demandé", "Projet IMMO+")

                For s = 0 To Me.GEMP.RowCount - 2
                    If a = Me.GEMP.Item(1, s).Value Then
                        sw = 1
                        CID.Text = Me.GEMP.Item(0, s).Value
                        TNOM.Text = Me.GEMP.Item(2, s).Value
                        TPRENOM.Text = Me.GEMP.Item(3, s).Value
                        DT_NAISSANCE.Value = Me.GEMP.Item(4, s).Value
                        If GEMP.Item(5, s).Value = "HOMME" Then
                            R_HOMME.Checked = True
                        Else
                            R_FEMME.Checked = True
                        End If
                        CVILLE.Text = GEMP.Item(6, s).Value
                        PictureBox10.Image = ConvertToImage(GEMP.Item(7, s).Value)
                        TADRESSE.Text = GEMP.Item(8, s).Value
                        TTELE.Text = GEMP.Item(9, s).Value
                        TEMAIL.Text = GEMP.Item(10, s).Value
                        DT_EMBAUCHE.Value = GEMP.Item(11, s).Value
                        If GEMP.Item(13, s).Value = "ACTIF" Then
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
                    End If
                    For d = 0 To Me.DDROITS.RowCount - 2
                        If a = Me.DDROITS.Item(1, d).Value Then
                            If DDROITS.Item(2, d).Value = "1" Then
                                D_EMPLOYE.Value = True
                            Else
                                D_EMPLOYE.Value = False
                            End If
                            If DDROITS.Item(3, d).Value = "1" Then
                                D_CLIENT.Value = True
                            Else
                                D_CLIENT.Value = False
                            End If
                            If DDROITS.Item(4, d).Value = "1" Then
                                D_BIENS.Value = True
                            Else
                                D_BIENS.Value = False
                            End If
                            If DDROITS.Item(5, d).Value = "1" Then
                                D_OPERATION.Value = True
                            Else
                                D_OPERATION.Value = False
                            End If

                        End If
                    Next
                Next

                If sw = 0 Then
                    MsgBox("CIN Introuvable", MsgBoxStyle.Critical)
                End If

            Else
                Dim sw As Integer = 0
                For s = 0 To Me.GEMP.RowCount - 2
                    If CCIN.Text = Me.GEMP.Item(1, s).Value Then
                        sw = 1
                        CID.Text = Me.GEMP.Item(0, s).Value
                        TNOM.Text = Me.GEMP.Item(2, s).Value
                        TPRENOM.Text = Me.GEMP.Item(3, s).Value
                        DT_NAISSANCE.Value = Me.GEMP.Item(4, s).Value
                        If GEMP.Item(5, s).Value = "HOMME" Then
                            R_HOMME.Checked = True
                        Else
                            R_FEMME.Checked = True
                        End If
                        CVILLE.Text = GEMP.Item(6, s).Value
                        PictureBox10.Image = ConvertToImage(GEMP.Item(7, s).Value)
                        TADRESSE.Text = GEMP.Item(8, s).Value
                        TTELE.Text = GEMP.Item(9, s).Value
                        TEMAIL.Text = GEMP.Item(10, s).Value
                        DT_EMBAUCHE.Value = GEMP.Item(11, s).Value
                        If GEMP.Item(13, s).Value = "ACTIF" Then
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

                    End If
                    For d = 0 To Me.DDROITS.RowCount - 2
                        If CCIN.Text = Me.DDROITS.Item(1, d).Value Then
                            If DDROITS.Item(2, d).Value = "1" Then
                                D_EMPLOYE.Value = True
                            Else
                                D_EMPLOYE.Value = False
                            End If
                            If DDROITS.Item(3, d).Value = "1" Then
                                D_CLIENT.Value = True
                            Else
                                D_CLIENT.Value = False
                            End If
                            If DDROITS.Item(4, d).Value = "1" Then
                                D_BIENS.Value = True
                            Else
                                D_BIENS.Value = False
                            End If
                            If DDROITS.Item(5, d).Value = "1" Then
                                D_OPERATION.Value = True
                            Else
                                D_OPERATION.Value = False
                            End If

                        End If
                    Next
                Next
                If sw = 0 Then
                    MsgBox("CIN Introuvable", MsgBoxStyle.Critical)
                End If
            End If
        End If

       
    End Sub
    Private Sub BTN_MO_Click(sender As Object, e As EventArgs) Handles BTN_MO.Click
        If MsgBox("voulez vous vraiment Modifier cet enregistrement", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim sw As Integer = 0
            Dim x As Integer
            For s = 0 To Me.GEMP.RowCount - 2
                If CID.Text = Me.GEMP.Item(0, s).Value Then
                    sw = 1
                    x = s
                    s = Me.GEMP.RowCount - 2
                End If
            Next
            If sw = 1 Then
                Dim ligneencours As Integer
                ligneencours = x
                Dim cle As String
                cle = GEMP.Item(0, ligneencours).Value
                Dim matable As DataTable
                matable = dtset.Tables("employe")
                Dim laligne As DataRow()
                laligne = matable.Select("id_emp=" & cle)
                laligne(0).Item(0) = CID.Text
                laligne(0).Item(2) = TNOM.Text
                laligne(0).Item(3) = TPRENOM.Text
                laligne(0).Item(4) = DT_NAISSANCE.Value
                If R_FEMME.Checked = True Then
                    laligne(0).Item(5) = R_FEMME.Text
                Else
                    laligne(0).Item(5) = R_HOMME.Text
                End If
                laligne(0).Item(6) = CVILLE.Text
                laligne(0).Item(7) = ConvertToData(Me.PictureBox10.Image)
                laligne(0).Item(8) = TADRESSE.Text
                laligne(0).Item(9) = TTELE.Text
                laligne(0).Item(10) = TEMAIL.Text
                laligne(0).Item(11) = DT_EMBAUCHE.Value
                base(dtadapter, "employe")

                Dim ligneencours1 As Integer
                ligneencours1 = x
                Dim cle1 As String
                cle1 = DDROITS.Item(0, ligneencours1).Value
                Dim matable1 As DataTable
                matable1 = dtset1.Tables("droits")
                Dim laligne1 As DataRow()
                laligne1 = matable1.Select("id_droits=" & cle)
                laligne1(0).Item(0) = CID.Text
                If D_EMPLOYE.Value = True Then
                    laligne1(0).Item(2) = "1"
                Else
                    laligne1(0).Item(2) = "0"

                End If
                If D_CLIENT.Value = True Then
                    laligne1(0).Item(3) = "1"
                Else
                    laligne1(0).Item(3) = "0"

                End If
                If D_BIENS.Value = True Then
                    laligne1(0).Item(4) = "1"
                Else
                    laligne1(0).Item(4) = "0"

                End If
                If D_OPERATION.Value = True Then
                    laligne1(0).Item(5) = "1"
                Else
                    laligne1(0).Item(5) = "0"

                End If
                base1(dtadapter, "droits")

                CID.Text = Nothing
                CCIN.Text = Nothing
                TNOM.Text = Nothing
                TPRENOM.Text = Nothing
                DT_NAISSANCE.Value = Date.Now
                R_HOMME.Checked = False
                R_FEMME.Checked = False
                CVILLE.Text = Nothing
                TADRESSE.Text = Nothing
                TTELE.Text = Nothing
                TEMAIL.Text = Nothing
                DT_EMBAUCHE.Value = Date.Now
                PictureBox10.Image = PictureBox10.BackgroundImage
                ACTIF.Visible = False
                INACTIF.Visible = False
            End If
            D_BIENS.Value = False
            D_CLIENT.Value = False
            D_OPERATION.Value = False
            D_EMPLOYE.Value = False
            BTN_BL.Visible = False
            BTN_DBL.Visible = False
            BTN_A.Visible = True
        Else
            MsgBox("ID N’Existe Pas", MsgBoxStyle.Critical)
        End If

    End Sub
    Private Sub base(ByVal adapter As MySqlDataAdapter, ByVal table As String)
        ' con.Open() 
        Dim cmdbuilder As MySqlCommandBuilder
        cmdbuilder = New MySqlClient.MySqlCommandBuilder(dtadapter)
        dtadapter.UpdateCommand = cmdbuilder.GetUpdateCommand
        dtadapter.Update(dtset, "employe")
    End Sub
    Private Sub base1(ByVal adapter As MySqlDataAdapter, ByVal table As String)
        ' con.Open() 
        Dim cmdbuilder1 As MySqlCommandBuilder
        cmdbuilder1 = New MySqlClient.MySqlCommandBuilder(dtadapter1)
        dtadapter1.UpdateCommand = cmdbuilder1.GetUpdateCommand
        dtadapter1.Update(dtset1, "droits")
    End Sub

    Private Sub BTN_SU_Click(sender As Object, e As EventArgs) Handles BTN_SU.Click
        b = MessageBox.Show("Voulez Vous Vraiment Supprimer     ", "Gestion IMMO + ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If b = MsgBoxResult.Yes Then
            'Bouton Suppression
            Dim x As Integer
            Dim x1 As Integer

            For s = 0 To Me.GEMP.RowCount - 2
                If CID.Text = Me.GEMP.Item(0, s).Value Then
                    x = s
                End If
            Next
            Dim ligneencours As Integer
            ligneencours = x
            Dim cle As String
            cle = GEMP.Item(0, ligneencours).Value
            Dim ligne As DataRow()
            ligne = dtset.Tables("employe").Select("id_emp=" & cle)
            ligne(0).Delete() 'Code uniquement pour la suppression dans la base de donnée locale

            Dim ligneencours1 As Integer
            ligneencours1 = x1
            Dim cle1 As String
            cle1 = DDROITS.Item(0, ligneencours1).Value
            Dim ligne1 As DataRow()
            ligne1 = dtset1.Tables("droits").Select("id_droits=" & cle1)
            ligne1(0).Delete() 'Code uniquement pour la suppression dans la base de donnée locale

            CID.Text = Nothing
            CCIN.Text = Nothing
            TNOM.Text = Nothing
            TPRENOM.Text = Nothing
            DT_NAISSANCE.Value = Date.Now
            R_HOMME.Checked = False
            R_FEMME.Checked = False
            CVILLE.Text = Nothing
            TADRESSE.Text = Nothing
            TTELE.Text = Nothing
            TEMAIL.Text = Nothing
            DT_EMBAUCHE.Value = Date.Now
            PictureBox10.Image = PictureBox10.BackgroundImage
            ACTIF.Visible = False
            INACTIF.Visible = False
            D_BIENS.Value = False
            D_CLIENT.Value = False
            D_OPERATION.Value = False
            D_EMPLOYE.Value = False
            BTN_DBL.Visible = False
            BTN_BL.Visible = False
            BTN_A.Visible = True
            MsgBox("Suppression Effectuée dans la base de données Locale", MsgBoxStyle.Information)
            ' con.Open() 
            'ici nous allons ouvrir la connexion pour accéder et utiliser la base de données distante 
            Dim cmdbuilder As MySqlCommandBuilder
            cmdbuilder = New MySqlClient.MySqlCommandBuilder(dtadapter)
            dtadapter.DeleteCommand = cmdbuilder.GetDeleteCommand
            dtadapter.Update(dtset, "employe")

            Dim cmdbuilder1 As MySqlCommandBuilder
            cmdbuilder1 = New MySqlClient.MySqlCommandBuilder(dtadapter1)
            dtadapter1.DeleteCommand = cmdbuilder1.GetDeleteCommand
            dtadapter1.Update(dtset1, "droits")
            con.Close()
        End If

    End Sub

    Private Sub Label27_Click(sender As Object, e As EventArgs) Handles Label27.Click
        Me.Hide()
        DASHBOARD.Show()
    End Sub
  
    Private Sub BTN_BL_Click(sender As Object, e As EventArgs) Handles BTN_BL.Click
        If MsgBox("voulez vous vraiment bloquer cet enregistrement", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim sw As Integer = 0
            Dim x As Integer
            For s = 0 To Me.GEMP.RowCount - 2
                If CID.Text = Me.GEMP.Item(0, s).Value Then
                    sw = 1
                    x = s
                    s = Me.GEMP.RowCount - 2
                End If
            Next
            If sw = 1 Then
                Dim ligneencours As Integer
                ligneencours = x
                Dim cle As String
                cle = GEMP.Item(0, ligneencours).Value
                Dim matable As DataTable
                matable = dtset.Tables("employe")
                Dim laligne As DataRow()
                laligne = matable.Select("id_emp=" & cle)
                laligne(0).Item(13) = "INACTIF"
                INACTIF.Visible = True
                ACTIF.Visible = False
                BTN_BL.Visible = False
                BTN_DBL.Visible = True
                BTN_A.Visible = False
                base(dtadapter, "employe")


            Else
                MsgBox("ID N’Existe Pas", MsgBoxStyle.Critical)
            End If
        End If

    End Sub

    Private Sub BTN_DBL_Click(sender As Object, e As EventArgs) Handles BTN_DBL.Click
        If MsgBox("voulez vous vraiment débloquer cet enregistrement", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim sw As Integer = 0
            Dim x As Integer
            For s = 0 To Me.GEMP.RowCount - 2
                If CID.Text = Me.GEMP.Item(0, s).Value Then
                    sw = 1
                    x = s
                    s = Me.GEMP.RowCount - 2
                End If
            Next
            If sw = 1 Then
                Dim ligneencours As Integer
                ligneencours = x
                Dim cle As String
                cle = GEMP.Item(0, ligneencours).Value
                Dim matable As DataTable
                matable = dtset.Tables("employe")
                Dim laligne As DataRow()
                laligne = matable.Select("id_emp=" & cle)
                laligne(0).Item(13) = "ACTIF"
                INACTIF.Visible = False
                ACTIF.Visible = True
                BTN_BL.Visible = True
                BTN_DBL.Visible = False
                BTN_A.Visible = False
                base(dtadapter, "employe")

            Else
                MsgBox("ID N’Existe Pas", MsgBoxStyle.Critical)
            End If
        End If
    End Sub






End Class
