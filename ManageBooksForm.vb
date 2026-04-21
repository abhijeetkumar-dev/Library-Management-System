Imports System.Data.OleDb

Public Class ManageBooksForm
    Dim con As New OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb")
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim dt As DataTable

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        AdminInterface.Show()
        Me.Close()
    End Sub

    Private Sub ManageBooksForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBooks()
    End Sub

    Private Sub LoadBooks()
        Try
            con.Open()
            da = New OleDbDataAdapter("SELECT * FROM BookDetail", con)
            dt = New DataTable()
            da.Fill(dt)
            dgvBooks.DataSource = dt
            dt.DefaultView.Sort = "BookID ASC"
            dgvBooks.DataSource = dt

            ' HIDE ResourceName COLUMN
            If dgvBooks.Columns.Contains("ResourceName") Then
                dgvBooks.Columns("ResourceName").Visible = False
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnAddBooks_Click(sender As Object, e As EventArgs) Handles btnAddBooks.Click
        If txtTitle.Text = "" Or txtAuthor.Text = "" Or txtCopies.Text = "" Then
            MessageBox.Show("Fill all fields!")
            Exit Sub
        End If

        Try
            con.Open()

            ' INSERT NEW BOOK
            Dim insertCmd As New OleDbCommand("INSERT INTO BookDetail (Title, Author, Publisher, BookYear, AvailableCopies, Price) VALUES (@t, @a, @p, @y, @c, @pr)", con)

            insertCmd.Parameters.AddWithValue("@t", txtTitle.Text)
            insertCmd.Parameters.AddWithValue("@a", txtAuthor.Text)
            insertCmd.Parameters.AddWithValue("@p", txtPublisher.Text)
            insertCmd.Parameters.AddWithValue("@y", txtYear.Text)
            insertCmd.Parameters.AddWithValue("@c", txtCopies.Text)
            insertCmd.Parameters.AddWithValue("@pr", txtPrice.Text)

            insertCmd.ExecuteNonQuery()

            con.Close()
            MessageBox.Show("Book Added Successfully!")
            LoadBooks()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            con.Open()

            da = New OleDbDataAdapter("SELECT * FROM BookDetail WHERE Title LIKE '%" & txtSearch.Text & "%'OR Author LIKE '%" & txtSearch.Text & "%'OR Publisher LIKE '%" & txtSearch.Text & "%'OR BookID LIKE '%" & txtSearch.Text & "%'", con)

            dt = New DataTable()
            da.Fill(dt)
            dgvBooks.DataSource = dt
            dt.DefaultView.Sort = "BookID ASC"
            dgvBooks.DataSource = dt

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
    End Sub

    Private Sub dgvBooks_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBooks.CellClick
        If e.RowIndex >= 0 Then
            txtTitle.Text = dgvBooks.Rows(e.RowIndex).Cells("Title").Value.ToString()
            txtAuthor.Text = dgvBooks.Rows(e.RowIndex).Cells("Author").Value.ToString()
            txtPublisher.Text = dgvBooks.Rows(e.RowIndex).Cells("Publisher").Value.ToString()
            txtYear.Text = dgvBooks.Rows(e.RowIndex).Cells("BookYear").Value.ToString()
            txtCopies.Text = dgvBooks.Rows(e.RowIndex).Cells("AvailableCopies").Value.ToString()
            txtPrice.Text = dgvBooks.Rows(e.RowIndex).Cells("Price").Value.ToString()
        End If
    End Sub


    Private Sub btnUpdateBooks_Click(sender As Object, e As EventArgs) Handles btnUpdateBooks.Click
        Try
            con.Open()

            cmd = New OleDbCommand("Update(BookDetail) SET Author=@a, Publisher=@p, BookYear=@y, AvailableCopies=@c, Price=@pr WHERE Title=@t", con)

            cmd.Parameters.AddWithValue("@a", txtAuthor.Text)
            cmd.Parameters.AddWithValue("@p", txtPublisher.Text)
            cmd.Parameters.AddWithValue("@y", txtYear.Text)
            cmd.Parameters.AddWithValue("@c", txtCopies.Text)
            cmd.Parameters.AddWithValue("@pr", txtPrice.Text)
            cmd.Parameters.AddWithValue("@t", txtTitle.Text)

            cmd.ExecuteNonQuery()
            con.Close()

            MessageBox.Show("Book Updated Successfully!")
            LoadBooks()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
    End Sub

    Private Sub btnDeleteBooks_Click(sender As Object, e As EventArgs) Handles btnDeleteBooks.Click
        If txtTitle.Text = "" Then
            MessageBox.Show("Select a book to delete!")
            Exit Sub
        End If

        Dim result = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then Exit Sub

        Try
            con.Open()

            Dim bookID = dgvBooks.CurrentRow.Cells("BookID").Value

            Dim delCmd As New OleDbCommand("DELETE FROM BookDetail WHERE BookID=@id", con)
            delCmd.Parameters.AddWithValue("@id", bookID)
            delCmd.ExecuteNonQuery()

            con.Close()

            MessageBox.Show("Book Deleted Successfully!")
            LoadBooks()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtAuthor.Clear()
        txtCopies.Clear()
        txtPrice.Clear()
        txtPublisher.Clear()
        txtQuantity.Clear()
        txtSearch.Clear()
        txtTitle.Clear()
        txtYear.Clear()
    End Sub

    Private Sub btnQuantityadd_Click(sender As Object, e As EventArgs) Handles btnQuantityadd.Click
        If txtTitle.Text = "" Or txtQuantity.Text = "" Then
            MessageBox.Show("Enter Title & Quantity")
            Exit Sub
        End If

        Dim qtyToAdd = Val(txtQuantity.Text)

        Try
            con.Open()

            Dim cmd = New OleDbCommand("SELECT AvailableCopies FROM BookDetail WHERE Title=@title", con)
            cmd.Parameters.AddWithValue("@title", txtTitle.Text)

            Dim currentQty = Val(cmd.ExecuteScalar())

            Dim newQty = currentQty + qtyToAdd

            cmd = New OleDbCommand("UPDATE BookDetail SET AvailableCopies=@qty WHERE Title=@title", con)
            cmd.Parameters.AddWithValue("@qty", newQty)
            cmd.Parameters.AddWithValue("@title", txtTitle.Text)
            cmd.ExecuteNonQuery()

            con.Close()

            txtCopies.Text = newQty.ToString()
            MessageBox.Show("Quantity Added!")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
    End Sub

    Private Sub btnQuantityreduce_Click(sender As Object, e As EventArgs) Handles btnQuantityreduce.Click
        If txtTitle.Text = "" Or txtQuantity.Text = "" Then
            MessageBox.Show("Enter Title & Quantity")
            Exit Sub
        End If

        Dim qtyToReduce = Val(txtQuantity.Text)

        Try
            con.Open()

            Dim cmd = New OleDbCommand("SELECT AvailableCopies FROM BookDetail WHERE Title=@title", con)
            cmd.Parameters.AddWithValue("@title", txtTitle.Text)

            Dim currentQty = Val(cmd.ExecuteScalar())

            If qtyToReduce > currentQty Then
                MessageBox.Show("Cannot reduce more than available!")
                con.Close()
                Exit Sub
            End If

            Dim newQty = currentQty - qtyToReduce

            cmd = New OleDbCommand("UPDATE BookDetail SET AvailableCopies=@qty WHERE Title=@title", con)
            cmd.Parameters.AddWithValue("@qty", newQty)
            cmd.Parameters.AddWithValue("@title", txtTitle.Text)
            cmd.ExecuteNonQuery()

            con.Close()

            txtCopies.Text = newQty.ToString()
            MessageBox.Show("Quantity Reduced!")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
    End Sub
End Class