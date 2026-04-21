Imports System.Data.OleDb

Public Class ManageMembershipDetail
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb;Persist Security Info=False;")
    Dim da As OleDbDataAdapter
    Dim dt As New DataTable()

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        AdminInterface.Show()
        Me.Close()
        con.Close()
    End Sub

    Private Sub ManageMembershipDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMembers()
    End Sub

    Private Sub LoadMembers()
        Try
            dt.Clear()
            con.Open()
            da = New OleDbDataAdapter("SELECT * FROM Membership", con)
            da.Fill(dt)
            dgvMembers.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            dt.Clear()
            con.Open()
            da = New OleDbDataAdapter("SELECT * FROM Membership WHERE Name LIKE '%" & txtSearch.Text & "%' OR MemberID LIKE '%" & txtSearch.Text & "%'", con)
            da.Fill(dt)
            dgvMembers.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnDeletemember_Click(sender As Object, e As EventArgs) Handles btnDeletemember.Click
        If dgvMembers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a member to delete.")
            Exit Sub
        End If

        Dim id As Integer = dgvMembers.SelectedRows(0).Cells("MemberID").Value

        If MessageBox.Show("Delete this Member?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Try
                con.Open()
                Dim cmd As New OleDbCommand("DELETE FROM Membership WHERE MemberID=@id", con)
                cmd.Parameters.AddWithValue("@id", id)
                cmd.ExecuteNonQuery()

                MessageBox.Show("Member Deleted Successfully!")

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                con.Close()
            End Try
            LoadMembers()
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvMembers.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a row to update.")
            Exit Sub
        End If

        Dim id As Integer = dgvMembers.SelectedRows(0).Cells("MemberID").Value
        Dim name As String = dgvMembers.SelectedRows(0).Cells("Name").Value.ToString()
        Dim email As String = dgvMembers.SelectedRows(0).Cells("Email").Value.ToString()
        Dim mobile As String = dgvMembers.SelectedRows(0).Cells("Mobile").Value.ToString()
        Dim address As String = dgvMembers.SelectedRows(0).Cells("Address").Value.ToString()

        Try
            con.Open()
            Dim cmd As New OleDbCommand("UPDATE Membership SET [Name]=@name, [Email]=@mail, [Mobile]=@mobile, [Address]=@address WHERE MemberID=@id", con)
            cmd.Parameters.AddWithValue("@name", name)
            cmd.Parameters.AddWithValue("@mail", email)
            cmd.Parameters.AddWithValue("@mobile", mobile)
            cmd.Parameters.AddWithValue("@address", address)
            cmd.Parameters.AddWithValue("@id", id)

            cmd.ExecuteNonQuery()

            MessageBox.Show("Member Updated Successfully!")

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
        LoadMembers()
    End Sub
End Class