Public Class Contact

    Dim showPassword As Boolean = True

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If showPassword Then
            PictureBox2.Image = My.Resources.eye
            Me.TextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Else
            PictureBox2.Image = My.Resources.HIde
            Me.TextBox2.PasswordChar = Nothing
        End If
        showPassword = Not showPassword
    End Sub

End Class