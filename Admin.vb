Imports System.Data.OleDb
Public Class Admin
    Public Shared LoggedAdminName As String
    Dim con As New OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb; Persist Security Info=False;")
    Dim showPassword As Boolean = True

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If showPassword Then
            PictureBox2.Image = My.Resources.eye
            Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Else
            PictureBox2.Image = My.Resources.HIde
            Me.txtPassword.PasswordChar = Nothing
        End If
        showPassword = Not showPassword

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        User.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Register.Show()
        Me.Close()
    End Sub

    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 900
        Me.Height = 700
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Login.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnLogin_Click.Click
        LoggedAdminName = txtUsername.Text
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text

        If username = "Abhijeet" And password = "Abhi-123" Then
            MessageBox.Show("Login Successful !", "Success")

            AdminInterface.ReceivedAdmin = txtUsername.Text
            AdminInterface.Show()
            Me.Close()
        Else
            MessageBox.Show("Invalid Username and Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class