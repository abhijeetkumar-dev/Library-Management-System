Imports System.Data.OleDb

Public Class ManagePurchaseForm
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb")
    Dim da As OleDbDataAdapter
    Dim dt As DataTable

    Private Sub ManagePurchaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPurchaseData()
    End Sub

    ' ========================= LOAD DATA ===========================
    Private Sub LoadPurchaseData()
        Try
            da = New OleDbDataAdapter("SELECT * FROM PurchaseBook", con)
            dt = New DataTable
            da.Fill(dt)
            dgvPurchase.DataSource = dt

            ' Allow editing directly in DataGridView
            dgvPurchase.ReadOnly = False
            dgvPurchase.Columns("PurchaseID").ReadOnly = True ' Primary key cannot be changed

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Dim query As String = "SELECT * FROM PurchaseBook WHERE UserName LIKE @s OR BookTitle LIKE @s OR PurchaseID LIKE @s"

            da = New OleDbDataAdapter(query, con)
            da.SelectCommand.Parameters.AddWithValue("@s", "%" & txtSearch.Text & "%")

            dt = New DataTable
            da.Fill(dt)

            dgvPurchase.DataSource = dt

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnDeleteuser_Click(sender As Object, e As EventArgs) Handles btnDeleteuser.Click
        If dgvPurchase.SelectedRows.Count = 0 Then
            MsgBox("Select a row to delete.")
            Exit Sub
        End If

        Dim id As Integer = dgvPurchase.SelectedRows(0).Cells("PurchaseID").Value

        If MsgBox("Delete this record?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Try
            con.Open()
            Dim cmd As New OleDbCommand("DELETE FROM PurchaseBook WHERE PurchaseID=@id", con)
            cmd.Parameters.AddWithValue("@id", id)
            cmd.ExecuteNonQuery()

            MsgBox("Record deleted successfully.")
            LoadPurchaseData()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim builder As New OleDbCommandBuilder(da)
            da.Update(dt)
            MsgBox("All changes saved successfully.")

        Catch ex As Exception
            MsgBox("Error while saving: " & ex.Message)
        End Try

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        AdminInterface.Show()
        Me.Close()
    End Sub
End Class