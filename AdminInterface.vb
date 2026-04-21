Imports System.Data.OleDb

Public Class AdminInterface

    Public Property ReceivedAdmin As String

    Private Sub CountTotalUsers()
        Try
            Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb")
            con.Open()

            Dim cmd As New OleDbCommand("SELECT COUNT(*) FROM Register", con)
            Dim totalUsers As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            lblTotalUsers.Text = "Total Users : " & totalUsers

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CountTotalBooks()
        Try
            Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb")
            con.Open()

            Dim cmd As New OleDbCommand("SELECT COUNT(*) FROM BookDetail", con)
            Dim totalBooks As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            lblTotalBooks.Text = "Total Books : " & totalBooks

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CountTotalMembers()
        Try
            Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb")
            con.Open()

            Dim cmd As New OleDbCommand("SELECT COUNT(*) FROM Membership", con)
            Dim totalMembers As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            lblTotalMembers.Text = "Total Members : " & totalMembers

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CountTotalIssues()
        Try
            Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb")
            con.Open()

            Dim cmd As New OleDbCommand("SELECT COUNT(*) FROM IssueBook", con)
            Dim totalIssues As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            lblTotalIssues.Text = "Issued to Users : " & totalIssues

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CountTotalReturns()
        Try
            Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb")
            con.Open()

            Dim cmd As New OleDbCommand("SELECT COUNT(*) FROM ReturnBook", con)
            Dim totalReturns As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            lblTotalReturns.Text = "Returned to Staff : " & totalReturns

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CountTotalPurchases()
        Try
            Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb")
            con.Open()

            Dim cmd As New OleDbCommand("SELECT COUNT(*) FROM PurchaseBook", con)
            Dim totalPurchases As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            lblTotalPurchase.Text = "Purchased to Users : " & totalPurchases

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CountTotalFines()
        Try
            Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb")
            con.Open()

            Dim cmd As New OleDbCommand("SELECT COUNT(*) FROM [Overdue&Fine]", con)
            Dim totalFines As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            lblTotalFines.Text = "Paid Fine to Users : " & totalFines

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AdminInterface_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblGreeting.Text = "Hello, " & Admin.LoggedAdminName & "!"
        lblDate.Text = "  Date: " & Date.Now.ToString("dd-MM-yyyy") & vbCrLf & "Time: " & Date.Now.ToString("hh:mm:ss tt")

        CountTotalUsers()
        CountTotalBooks()
        CountTotalMembers()
        CountTotalIssues()
        CountTotalReturns()
        CountTotalPurchases()
        CountTotalFines()
    End Sub

    Private Sub manageUser_Click(sender As Object, e As EventArgs) Handles manageUser.Click
        ManageUserForm.Show()
        Me.Close()
    End Sub

    Private Sub managebooks_Click(sender As Object, e As EventArgs) Handles managebooks.Click
        ManageBooksForm.Show()
        Me.Close()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        ContextMenuStrip1.Show(PictureBox7, 0, PictureBox7.Height)
    End Sub

    Private Sub managemembers_Click(sender As Object, e As EventArgs) Handles managemembers.Click
        ManageMembershipDetail.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ManageIssueReturnForm.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        ManageIssueReturnForm.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ManagePurchaseForm.Show()
        Me.Close()
    End Sub

    Private Sub ProfileToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ProfileForm.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ManageFines.Show()
        Me.Close()
    End Sub
End Class