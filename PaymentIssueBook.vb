Imports System.Data.OleDb

Public Class PaymentIssueBook
    Dim con As New OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb; Persist Security Info=False;")
    Public Property UserName As String
    Public Property BookTitle As String
    Public Property BookAuthor As String
    Public Property BookImage As Image
    Public selectedBookID As Integer

    Public FromMembership As Boolean = False
    Public FromBookDetail As Boolean = False

    Private Sub PaymentInterface1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnPrint.Enabled = False
        PrintPreviewDialog1.Document = PrintDocument1
        btnCancel.Enabled = True
        picBook.Image = BookImage
        txtName.Text = User.LoggedUserName
        txtTitle.Text = BookTitle
        txtAuthor.Text = BookAuthor
        ' Optional
        lblStatus.Text = "Issue"

        Try
            Using con As New OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb; Persist Security Info=False;")
                Dim query As String = "SELECT MembershipType, MembershipPlan FROM Membership WHERE Name = @u"

                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("@u", txtName.Text.Trim())

                    con.Open()
                    Dim dr As OleDbDataReader = cmd.ExecuteReader()

                    If dr.Read() Then
                        txtType.Text = dr("MembershipType").ToString()
                        txtPlan.Text = dr("MembershipPlan").ToString()
                    Else
                        MessageBox.Show("Membership details not found for this user!", "Warning")
                    End If

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading membership details: " & ex.Message)
        End Try
    End Sub

    Private Function GenerateInvoiceNo() As String
        Dim newInvoice As String = ""
        Dim yearPart As String = DateTime.Now.Year.ToString()
        Dim lastNumber As Integer = 0

        Try
            Dim cmd As New OleDbCommand("SELECT InvoiceNo FROM IssueBook WHERE InvoiceNo LIKE 'INV-" & yearPart & "-%' ORDER BY InvoiceNo DESC", con)

            con.Open()
            Dim dr As OleDbDataReader = cmd.ExecuteReader()

            If dr.Read() Then
                ' Example last invoice → INV-2025-004
                Dim lastInv As String = dr("InvoiceNo").ToString()
                Dim numberPart As String = lastInv.Substring(lastInv.LastIndexOf("-") + 1)
                lastNumber = CInt(numberPart)
            End If
            con.Close()

            lastNumber += 1
            newInvoice = "INV-" & yearPart & "-" & lastNumber.ToString("000")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try

        Return newInvoice
    End Function

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Try
            ' ===== CHECK ALREADY ISSUED =====
            Dim checkCmd As New OleDbCommand("SELECT COUNT(*) FROM IssueBook WHERE UserName = @UserName AND BookTitle = @BookTitle  AND Status = 'Issue'", con)

            checkCmd.Parameters.AddWithValue("@UserName", txtName.Text)
            checkCmd.Parameters.AddWithValue("@BookTitle", txtTitle.Text)

            con.Open()
            Dim alreadyIssued As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
            con.Close()

            If alreadyIssued > 0 Then
                MessageBox.Show("You have already issued this book.","Already Issued",MessageBoxButtons.OK,MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim invoiceNo As String = GenerateInvoiceNo()
            lblInvoiceNumber.Text = invoiceNo

            con.Open()

            Dim cmd As New OleDbCommand("INSERT INTO IssueBook (InvoiceNo, UserName, BookTitle, BookAuthor, IssueDate, UserType, UserMembership, Status) VALUES (@InvoiceNo, @UserName, @BookTitle, @BookAuthor, @IssueDate, @UserType, @UserMembership, @Status)", con)
            cmd.Parameters.AddWithValue("@InvoiceNo", lblInvoiceNumber.Text)
            cmd.Parameters.AddWithValue("@UserName", txtName.Text)
            cmd.Parameters.AddWithValue("@BookTitle", txtTitle.Text)
            cmd.Parameters.AddWithValue("@BookAuthor", txtAuthor.Text)
            cmd.Parameters.AddWithValue("@IssueDate", dtpIssueDate.Value.Date)
            cmd.Parameters.AddWithValue("@UserType", txtType.Text)
            cmd.Parameters.AddWithValue("@UserMembership", txtPlan.Text)
            cmd.Parameters.AddWithValue("@Status", lblStatus.Text)

            cmd.ExecuteNonQuery()

            MessageBox.Show("Book Issued Successfully!", "Success")
            btnPrint.Enabled = True

            con.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Dim query As String = "UPDATE BookDetail SET AvailableCopies = AvailableCopies + 1 WHERE BookID = ?"

            Using cmd As New OleDbCommand(query, con)
                cmd.Parameters.AddWithValue("?", selectedBookID)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using

            MessageBox.Show("Issued cancelled. Book stock restored.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        PrintPreviewDialog1.Width = 900
        PrintPreviewDialog1.Height = 600
        PrintPreviewDialog1.StartPosition = FormStartPosition.CenterScreen
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.ShowDialog()
        btnCancel.Enabled = False
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim g As Graphics = e.Graphics

        ' Fonts
        Dim titleFont As New Font("Times New Roman", 18, FontStyle.Bold)
        Dim headFont As New Font("Times New Roman", 14, FontStyle.Bold)
        Dim bodyFont As New Font("Times New Roman", 12)

        Dim x As Integer = 50
        Dim y As Integer = 40

       ' ===== Title =====
        g.DrawString("LIBRARY ISSUE BOOK INVOICE", titleFont, Brushes.Black, x + 150, y)
        y += 40
        y += 40

        ' Invoice info
        g.DrawString("Invoice No : " & lblInvoiceNumber.Text, bodyFont, Brushes.Black, x, y)
        y += 20
        g.DrawString("Issue Date : " & dtpIssueDate.Value.ToString("dd-MMM-yyyy"), bodyFont, Brushes.Black, x, y)
        y += 30

        g.DrawLine(Pens.Black, x, y, 750, y)
        y += 20

        ' ===== User Info =====
        g.DrawString("User Information", headFont, Brushes.Black, x, y)
        y += 25

        g.DrawString("Name : " & txtName.Text, bodyFont, Brushes.Black, x, y)
        y += 20
        g.DrawString("User Type : " & txtType.Text, bodyFont, Brushes.Black, x, y)
        y += 20
        g.DrawString("Membership Plan : " & txtPlan.Text, bodyFont, Brushes.Black, x, y)
        y += 25

        g.DrawLine(Pens.Black, x, y, 750, y)
        y += 20

        ' ===== Book Info =====
        g.DrawString("Book Details", headFont, Brushes.Black, x, y)
        y += 25

        g.DrawString("Title : " & txtTitle.Text, bodyFont, Brushes.Black, x, y)
        y += 20
        g.DrawString("Author : " & txtAuthor.Text, bodyFont, Brushes.Black, x, y)
        y += 30

        g.DrawLine(Pens.Black, x, y, 750, y)
        y += 30

        ' Footer
        g.DrawString("Issued Successfully", headFont, Brushes.Black, x + 263, y)
        y += 25
        g.DrawString("Please return the book on time.", bodyFont, Brushes.Black, x + 240, y)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        UserBookDetail.Show()
        Me.Close()
    End Sub
End Class