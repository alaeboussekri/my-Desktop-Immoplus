Public Class SPLASHSCREEN

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        PB1.Increment(10)
        If PB1.Value = 100 Then
            Timer2.Stop()
            Me.Hide()
            AUTHENTIFICATION.Show()
        End If
    End Sub
    Private Sub SPLASHSCREEN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer2.Start()
    End Sub
End Class
