Imports System.Data.OleDb

Public Class ProfileForm
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb;Persist Security Info=False;")

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        UserInterface.Show()
        Me.Close()
    End Sub

    Private Sub ProfileForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProfileData()
    End Sub

    Private Sub LoadProfileData()

        Try
            con.Open()

            Dim query As String = "SELECT * FROM Register WHERE Username = @u"
            Dim cmd As New OleDbCommand(query, con)
            cmd.Parameters.AddWithValue("@u", User.LoggedUserName)

            Dim dr As OleDbDataReader = cmd.ExecuteReader()

            If dr.Read() Then
                lblName.Text = dr("Username").ToString()
                lblEmail.Text = dr("Email").ToString()
                lblMobile.Text = dr("MobileNo").ToString()
                lblSubject.Text = dr("Course").ToString()
            Else
                MessageBox.Show("User details not found!")
            End If

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class