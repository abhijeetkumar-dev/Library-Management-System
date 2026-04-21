Imports System.Data.OleDb

Public Class IssueReturnInterface
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb;Persist Security Info=False;")

    Private Sub IssueReturnInterface_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblStatus.Text = "Return"
        LoadUserIssueData()
        LoadUserReturnData()
    End Sub

    '===========================================
    '   LOAD ONLY LOGGED-IN USER ISSUE RECORDS
    '===========================================
    Private Sub LoadUserIssueData()
        Try
            con.Open()
            Dim dt As New DataTable

            Dim query As String = "SELECT * FROM IssueBook WHERE UserName = @uname"
            Dim cmd As New OleDbCommand(query, con)
            cmd.Parameters.AddWithValue("@uname", User.LoggedUserName)

            Dim da As New OleDbDataAdapter(cmd)
            da.Fill(dt)

            dgvIssue.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Error loading issue data: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    '===========================================
    '   LOAD ONLY LOGGED-IN USER RETURN RECORDS
    '===========================================
    Private Sub LoadUserReturnData()
        Try
            con.Open()
            Dim dt As New DataTable

            Dim query As String = "SELECT * FROM ReturnBook WHERE UserName = @uname"
            Dim cmd As New OleDbCommand(query, con)
            cmd.Parameters.AddWithValue("@uname", User.LoggedUserName)

            Dim da As New OleDbDataAdapter(cmd)
            da.Fill(dt)

            dgvReturn.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Error loading return data: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        UserInterface.Show()
        Me.Close()
    End Sub

    Private Sub btnReturnBooks_Click(sender As Object, e As EventArgs) Handles btnReturnBooks.Click
        'Check if a row is selected
        If dgvIssue.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a book to return.")
            Exit Sub
        End If

        'Confirmation message
        Dim ask As DialogResult = MessageBox.Show("Do you want to return this book?", "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If ask = DialogResult.No Then Exit Sub

        'Get selected row data
        Dim uname As String = dgvIssue.SelectedRows(0).Cells("UserName").Value.ToString()
        Dim btitle As String = dgvIssue.SelectedRows(0).Cells("BookTitle").Value.ToString()
        Dim bauthor As String = dgvIssue.SelectedRows(0).Cells("BookAuthor").Value.ToString()
        Dim utype As String = dgvIssue.SelectedRows(0).Cells("Usertype").Value.ToString()
        Dim umember As String = dgvIssue.SelectedRows(0).Cells("UserMembership").Value.ToString()

        Dim returndate As String = Date.Now.ToShortDateString()

        Try
            con.Open()

            '===============================================
            ' 1️⃣ INSERT INTO ReturnBook TABLE
            '===============================================
            Dim insertQuery As String = "INSERT INTO ReturnBook (UserName, BookTitle, BookAuthor, ReturnDate, Usertype, UserMembership, Status)VALUES (@uname, @btitle, @bauthor, @rdate, @utype, @umember, 'Return')"

            Dim cmdInsert As New OleDbCommand(insertQuery, con)
            cmdInsert.Parameters.AddWithValue("@uname", uname)
            cmdInsert.Parameters.AddWithValue("@btitle", btitle)
            cmdInsert.Parameters.AddWithValue("@bauthor", bauthor)
            cmdInsert.Parameters.AddWithValue("@rdate", returndate)
            cmdInsert.Parameters.AddWithValue("@utype", utype)
            cmdInsert.Parameters.AddWithValue("@umember", umember)

            cmdInsert.ExecuteNonQuery()

            '===============================================
            ' 2️⃣ DELETE FROM IssueBook TABLE
            '===============================================
            Dim deleteQuery As String = "DELETE FROM IssueBook WHERE UserName=@uname AND BookTitle=@btitle AND BookAuthor=@bauthor"

            Dim cmdDelete As New OleDbCommand(deleteQuery, con)
            cmdDelete.Parameters.AddWithValue("@uname", uname)
            cmdDelete.Parameters.AddWithValue("@btitle", btitle)
            cmdDelete.Parameters.AddWithValue("@bauthor", bauthor)

            cmdDelete.ExecuteNonQuery()

            '===========================================
            ' 3️⃣ INCREASE BOOK QUANTITY (AvailableCopies + 1)
            '===========================================
            Dim updateQuantityQuery As String = "UPDATE BookDetail SET AvailableCopies = AvailableCopies + 1 WHERE Title=@btitle AND Author=@bauthor"

            Dim cmdQty As New OleDbCommand(updateQuantityQuery, con)
            cmdQty.Parameters.AddWithValue("@btitle", btitle)
            cmdQty.Parameters.AddWithValue("@bauthor", bauthor)

            cmdQty.ExecuteNonQuery()

            MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error while returning book: " & ex.Message)
        Finally
            con.Close()
        End Try

        'Refresh both grids
        LoadUserIssueData()
        LoadUserReturnData()
    End Sub

    Private Sub btnRenew_Click(sender As Object, e As EventArgs) Handles btnRenew.Click
        ' 1️⃣ Check if a row is selected
        If dgvIssue.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a book to renew!", "Warning")
            Exit Sub
        End If

        ' 2️⃣ Get selected row data
        Dim uname As String = dgvIssue.SelectedRows(0).Cells("UserName").Value.ToString()
        Dim btitle As String = dgvIssue.SelectedRows(0).Cells("BookTitle").Value.ToString()
        Dim bauthor As String = dgvIssue.SelectedRows(0).Cells("BookAuthor").Value.ToString()
        Dim issueDate As Date = Convert.ToDateTime(dgvIssue.SelectedRows(0).Cells("IssueDate").Value)

        ' 3️⃣ Calculate days passed
        Dim daysPassed As Integer = (Date.Today - issueDate).Days

        ' 4️⃣ Renew rule based on exact days
        If daysPassed < 14 Then
            Dim remainingDays As Integer = 14 - daysPassed
            MessageBox.Show("Your issue book date is not more than 14 days." &vbCrLf & "You still have " & remainingDays & " day(s).","Renew Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf daysPassed > 14 Then
            MessageBox.Show("Renewal period exceeded." & vbCrLf & "Please first pay the fine to continue.", "Fine Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            OverdueFineForm.Show()
            Me.Close()
            Exit Sub
        Else
            MessageBox.Show("Book Renewed Successfully")
            Exit Sub
        End If

        ' 5️⃣ Update IssueDate to today (RENEW)
        Try
            con.Open()

            Dim query As String = "UPDATE IssueBook SET IssueDate = @today WHERE UserName=@uname AND BookTitle=@btitle AND BookAuthor=@bauthor"

            Dim cmd As New OleDbCommand(query, con)
            cmd.Parameters.AddWithValue("@today", Date.Today)
            cmd.Parameters.AddWithValue("@uname", uname)
            cmd.Parameters.AddWithValue("@btitle", btitle)
            cmd.Parameters.AddWithValue("@bauthor", bauthor)

            cmd.ExecuteNonQuery()

            MessageBox.Show("Book renewed successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error while renewing book: " & ex.Message)
        Finally
            con.Close()
        End Try

        ' 6️⃣ Reload dgvIssue directly (NO extra function)
        Try
            con.Open()
            Dim dt As New DataTable
            Dim da As New OleDbDataAdapter(
                "SELECT * FROM IssueBook WHERE UserName='" & User.LoggedUserName & "'", con)
            da.Fill(dt)
            dgvIssue.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error refreshing issue data: " & ex.Message)
        Finally
            con.Close()
        End Try


    End Sub
End Class