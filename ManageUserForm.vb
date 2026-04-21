Imports System.Data.OleDb

Public Class ManageUserForm

    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb")
    Dim da As OleDbDataAdapter
    Dim dt As DataTable

    '===============================
    ' LOAD ALL USERS IN GRID
    '===============================
    Private Sub ManageUserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()
    End Sub

    Private Sub LoadUsers()
        Try
            con.Open()
            da = New OleDbDataAdapter("SELECT * FROM Register ORDER BY MemberID", con)
            dt = New DataTable
            da.Fill(dt)
            dgvUsers.DataSource = dt
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        AdminInterface.Show()
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If txtSearch.Text.Trim() = "" Then
            MessageBox.Show("Enter username or MemberID to search.")
            Exit Sub
        End If

        Try
            con.Open()
            da = New OleDbDataAdapter("SELECT * FROM Register WHERE Username LIKE '%" & txtSearch.Text & "%' OR MemberID Like '%" & txtSearch.Text & "%'", con)
            dt = New DataTable
            da.Fill(dt)
            dgvUsers.DataSource = dt
            con.Close()

            If dt.Rows.Count = 0 Then
                MessageBox.Show("No user found.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
    End Sub

    Private Sub btnDeleteuser_Click(sender As Object, e As EventArgs) Handles btnDeleteuser.Click
        If dgvUsers.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a user to delete.")
            Exit Sub
        End If

        Dim MemberID As Integer = dgvUsers.SelectedRows(0).Cells("MemberID").Value

        If MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        End If

        Try
            con.Open()
            Dim cmd As New OleDbCommand("DELETE FROM Register WHERE MemberID=" & MemberID, con)
            cmd.ExecuteNonQuery()
            con.Close()

            MessageBox.Show("User deleted successfully!")
            LoadUsers()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvUsers.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a user to update.")
            Exit Sub
        End If

        Dim row As DataGridViewRow = dgvUsers.SelectedRows(0)
        Dim MemberID As Integer = row.Cells("MemberID").Value
        Dim Username As String = row.Cells("Username").Value
        Dim Password As String = row.Cells("Password").Value
        Dim Course As String = row.Cells("Course").Value
        Dim Email As String = row.Cells("EMail").Value
        Dim Mobile As String = row.Cells("MobileNo").Value

        Try
            con.Open()
            Dim updateQuery As String =
                "UPDATE Register SET [Username]=@u, [Password]=@p, [Course]=@c, [EMail]=@e, [MobileNo]=@m WHERE [MemberID]=@id"

            Dim cmd As New OleDbCommand(updateQuery, con)
            cmd.Parameters.AddWithValue("@u", Username)
            cmd.Parameters.AddWithValue("@p", Password)
            cmd.Parameters.AddWithValue("@c", Course)
            cmd.Parameters.AddWithValue("@e", Email)
            cmd.Parameters.AddWithValue("@m", Mobile)
            cmd.Parameters.AddWithValue("@id", MemberID)

            cmd.ExecuteNonQuery()
            con.Close()

            MessageBox.Show("User information updated!")
            LoadUsers()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
    End Sub
End Class