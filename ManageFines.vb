Imports System.Data.OleDb
Public Class ManageFines

    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb")

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        AdminInterface.Show()
        Me.Close()
    End Sub

    Private Sub ManageFines_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvOverdueFine.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvOverdueFine.MultiSelect = False

        LoadOverdueFineData()
    End Sub

    Private Sub LoadOverdueFineData()
        Try
            Dim da As New OleDbDataAdapter("SELECT * FROM [Overdue&Fine]", con)
            Dim dt As New DataTable
            da.Fill(dt)
            dgvOverdueFine.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
        Dim da As New OleDbDataAdapter("SELECT * FROM [Overdue&Fine] WHERE Username LIKE @search OR InvoiceNo LIKE @search", con)
            da.SelectCommand.Parameters.AddWithValue("@search", "%" & txtSearch.Text & "%")

            Dim dt As New DataTable
            da.Fill(dt)
            dgvOverdueFine.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnDeletemember_Click(sender As Object, e As EventArgs) Handles btnDeletemember.Click
        If dgvOverdueFine.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a record to delete.")
            Exit Sub
        End If

        Dim invoiceNo As Integer = dgvOverdueFine.SelectedRows(0).Cells("InvoiceNo").Value

        If MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Try
                con.Open()
                Dim cmd As New OleDbCommand("DELETE FROM [Overdue&Fine] WHERE InvoiceNo=@InvoiceNo", con)
                cmd.Parameters.AddWithValue("@InvoiceNo", invoiceNo)
                cmd.ExecuteNonQuery()
                con.Close()

                MessageBox.Show("Record deleted successfully.")
                LoadOverdueFineData()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                con.Close()
            End Try
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvOverdueFine.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a record to update.")
            Exit Sub
        End If

        Dim row As DataGridViewRow = dgvOverdueFine.SelectedRows(0)

        Try
            con.Open()
        Dim cmd As New OleDbCommand("UPDATE [Overdue&Fine] SET Username=@Username,OverdueDays=@OverdueDays,FineAmount=@FineAmount,PaymentMethod=@PaymentMethod,PaidDate=@PaidDateWHERE InvoiceNo=@InvoiceNo", con)

            cmd.Parameters.AddWithValue("@Username", row.Cells("Username").Value)
            cmd.Parameters.AddWithValue("@OverdueDays", row.Cells("OverdueDays").Value)
            cmd.Parameters.AddWithValue("@FineAmount", row.Cells("FineAmount").Value)
            cmd.Parameters.AddWithValue("@PaymentMethod", row.Cells("PaymentMethod").Value)
            cmd.Parameters.AddWithValue("@PaidDate", row.Cells("PaidDate").Value)
            cmd.Parameters.AddWithValue("@InvoiceNo", row.Cells("InvoiceNo").Value)

            cmd.ExecuteNonQuery()
            con.Close()

            MessageBox.Show("Record updated successfully.")
            LoadOverdueFineData()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
    End Sub
End Class