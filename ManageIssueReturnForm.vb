Imports System.Data.OleDb

Public Class ManageIssueReturnForm
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb")

    Dim daIssue As OleDbDataAdapter
    Dim dtIssue As DataTable

    Dim daReturn As OleDbDataAdapter
    Dim dtReturn As DataTable

    Private Sub ManageIssueReturnForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadIssueData()
        LoadReturnData()
    End Sub

    ' ============================ LOAD ISSUE DATA =========================
    Private Sub LoadIssueData()
        Try
            daIssue = New OleDbDataAdapter("SELECT * FROM IssueBook", con)
            dtIssue = New DataTable
            daIssue.Fill(dtIssue)

            dgvIssue.DataSource = dtIssue
            dgvIssue.ReadOnly = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ' ============================ LOAD RETURN DATA ========================
    Private Sub LoadReturnData()
        Try
            daReturn = New OleDbDataAdapter("SELECT * FROM ReturnBook", con)
            dtReturn = New DataTable
            daReturn.Fill(dtReturn)

            dgvReturn.DataSource = dtReturn
            dgvReturn.ReadOnly = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnISearch_Click(sender As Object, e As EventArgs) Handles btnISearch.Click
        Try
            Dim sql As String =
                "SELECT * FROM IssueBook WHERE " &
                "UserName LIKE @s OR BookTitle LIKE @s OR Status LIKE @s"

            daIssue = New OleDbDataAdapter(sql, con)
            daIssue.SelectCommand.Parameters.AddWithValue("@s", "%" & txtISearch.Text & "%")

            dtIssue = New DataTable
            daIssue.Fill(dtIssue)

            dgvIssue.DataSource = dtIssue

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRSearch_Click(sender As Object, e As EventArgs) Handles btnRSearch.Click
        Try
            Dim sql As String =
                "SELECT * FROM ReturnBook WHERE " &
                "UserName LIKE @s OR BookTitle LIKE @s OR Status LIKE @s"

            daReturn = New OleDbDataAdapter(sql, con)
            daReturn.SelectCommand.Parameters.AddWithValue("@s", "%" & txtRSearch.Text & "%")

            dtReturn = New DataTable
            daReturn.Fill(dtReturn)

            dgvReturn.DataSource = dtReturn

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnIDeleteuser_Click(sender As Object, e As EventArgs) Handles btnIDeleteuser.Click
        If dgvIssue.SelectedRows.Count = 0 Then
            MsgBox("Select a row to delete.")
            Exit Sub
        End If

        If MsgBox("Delete selected issued record?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Try
            Dim userName As String = dgvIssue.SelectedRows(0).Cells("UserName").Value

            con.Open()
            Dim cmd As New OleDbCommand("DELETE FROM IssueBook WHERE UserName=@u", con)
            cmd.Parameters.AddWithValue("@u", userName)
            cmd.ExecuteNonQuery()

            MsgBox("Issued record deleted successfully.")
            LoadIssueData()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnRDeleteUser_Click(sender As Object, e As EventArgs) Handles btnRDeleteUser.Click
        If dgvReturn.SelectedRows.Count = 0 Then
            MsgBox("Select a row to delete.")
            Exit Sub
        End If

        If MsgBox("Delete selected returned record?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Try
            Dim userName As String = dgvReturn.SelectedRows(0).Cells("UserName").Value

            con.Open()
            Dim cmd As New OleDbCommand("DELETE FROM ReturnBook WHERE UserName=@u", con)
            cmd.Parameters.AddWithValue("@u", userName)
            cmd.ExecuteNonQuery()

            MsgBox("Returned record deleted successfully.")
            LoadReturnData()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnIUpdate_Click(sender As Object, e As EventArgs) Handles btnIUpdate.Click
        Try
            Dim builder As New OleDbCommandBuilder(daIssue)
            daIssue.Update(dtIssue)
            MsgBox("Issued records updated successfully.")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRUpdate_Click(sender As Object, e As EventArgs) Handles btnRUpdate.Click
        Try
            Dim builder As New OleDbCommandBuilder(daReturn)
            daReturn.Update(dtReturn)
            MsgBox("Returned records updated successfully.")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        AdminInterface.Show()
        Me.Close()
    End Sub
End Class