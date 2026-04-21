Imports System.Data.OleDb

Public Class User
    Public Shared LoggedUserName As String

    Public ReceivedUser As String

    Dim con As New OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = LibraryManagementDB.accdb")
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader

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

    Private Sub User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 900
        Me.Height = 700
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Admin.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Register.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Login.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("Please enter Username and Password")
            Exit Sub
        End If

        Try
            con.Open()
            Dim dr As OleDbDataReader
            cmd = New OleDbCommand("SELECT * FROM Register WHERE Username=@u AND Password=@p", con)
            cmd.Parameters.AddWithValue("@u", txtUsername.Text)
            cmd.Parameters.AddWithValue("@p", txtPassword.Text)

            dr = cmd.ExecuteReader()

            If dr.Read() Then
                User.LoggedUserName = dr("Username").ToString()
                MessageBox.Show("Login Successful ! Welcome " & User.LoggedUserName)
                dr.Close()
                con.Close()
                UserInterface.Show()
                Me.Close()
            Else
                MessageBox.Show("Invalid Username or Password", "Login Failed")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally
            If dr IsNot Nothing Then dr.Close()
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub
End Class