Public Class Form1

    Dim bgImages() As Image = {My.Resources.bg1, My.Resources.bg2, My.Resources.bg6, My.Resources.bg4}
    Dim index As Integer = 0

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Contact.Show()
        Me.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        About.Show()
        Me.Close()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Login.Show()
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Register.Show()
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 900
        Me.Height = 700

        Timer1.Interval = 2000
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.BackgroundImage = bgImages(index)
        Me.BackgroundImageLayout = ImageLayout.Stretch

        index = index + 1

        If index >= bgImages.Length Then
            index = 0
        End If
    End Sub

End Class
