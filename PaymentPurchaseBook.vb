Imports System.Data.OleDb

Public Class PaymentPurchaseBook
    Dim con As New OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb; Persist Security Info=False;")
    Public Property UserName As String
    Public Property BookTitle As String
    Public Property BookAuthor As String
    Public Property BookPrice As String
    Public Property BookImage As Image
    Public selectedBookID As Integer

    Public FromMembership As Boolean = False
    Public FromBookDetail As Boolean = False

    Private Sub PaymentInterface_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        picQR.Visible = False
        picBook.Image = BookImage
        btnPrint.Enabled = False
        PrintPreviewDialog1.Document = PrintDocument1
        btnCancel.Enabled = True

        txtName.Text = User.LoggedUserName
        txtTitle.Text = BookTitle
        txtAuthor.Text = BookAuthor
        txtPrice.Text = BookPrice
        lblStatus.Text = "Purchase"

        dtpPurchaseDate.Value = Date.Now
        cmbPaymentMethod.Items.AddRange(New String() {"Cash", "UPI"})
        cmbPaymentMethod.SelectedIndex = -1
    End Sub

    Private Function GenerateInvoiceNo() As String
        Dim newInvoice As String = ""
        Dim yearPart As String = DateTime.Now.Year.ToString()
        Dim lastNumber As Integer = 0

        Try
            Dim cmd As New OleDbCommand("SELECT InvoiceNo FROM PurchaseBook WHERE InvoiceNo LIKE 'INV-" & yearPart & "-%' ORDER BY InvoiceNo DESC", con)

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

            'Validation
            If cmbPaymentMethod.Text = "" Then
                MessageBox.Show("Please select a payment method before purchasing!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim invoiceNo As String = GenerateInvoiceNo()
            lblInvoiceNumber.Text = invoiceNo

            'Open connection
            con.Open()

            'Insert query
            Dim query As String = "INSERT INTO PurchaseBook (InvoiceNo, UserName, BookTitle, BookAuthor, PurchaseDate, BookPrice, PaymentMethod, Status) " &
                                  "VALUES (@InvoiceNo, @UserName, @BookTitle, @BookAuthor, @PurchaseDate, @BookPrice, @PaymentMethod, @Status)"

            Dim cmd As New OleDbCommand(query, con)

            'Send parameters
            cmd.Parameters.AddWithValue("@InvoiceNo", lblInvoiceNumber.Text)
            cmd.Parameters.AddWithValue("@UserName", txtName.Text)
            cmd.Parameters.AddWithValue("@BookTitle", txtTitle.Text)
            cmd.Parameters.AddWithValue("@BookAuthor", txtAuthor.Text)
            cmd.Parameters.AddWithValue("@PurchaseDate", dtpPurchaseDate.Value.Date)
            cmd.Parameters.AddWithValue("@BookPrice", txtPrice.Text)
            cmd.Parameters.AddWithValue("@PaymentMethod", cmbPaymentMethod.Text)
            cmd.Parameters.AddWithValue("@Status", lblStatus.Text)

            cmd.ExecuteNonQuery()

            Dim idCmd As New OleDbCommand("SELECT @@IDENTITY", con)
            Dim newPurchaseID As Integer = CInt(idCmd.ExecuteScalar())

            MessageBox.Show("Purchase Successful!" & vbCrLf & "Your Purchase ID: " & newPurchaseID.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnPrint.Enabled = True

            con.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
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

            MessageBox.Show("Purchase cancelled. Book stock restored.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
    End Sub

    Private Sub cmbPaymentMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPaymentMethod.SelectedIndexChanged

        If cmbPaymentMethod.Text = "UPI" Then
            'Show QR
            picQR.Visible = True
        Else
            'Hide QR for Cash / other methods
            picQR.Visible = False
        End If

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
        g.DrawString("LIBRARY PURCHASE BOOK INVOICE", titleFont, Brushes.Black, x + 150, y)
        y += 40
        y += 40

        ' Invoice Info
        g.DrawString("Invoice No : " & lblInvoiceNumber.Text, bodyFont, Brushes.Black, x, y)
        y += 20
        g.DrawString("Date : " & Date.Now.ToString("dd-MMM-yyyy hh:mm tt"), bodyFont, Brushes.Black, x, y)
        y += 30

        g.DrawLine(Pens.Black, x, y, 750, y)
        y += 20

        ' ===== Customer Info =====
        g.DrawString("Customer Information", headFont, Brushes.Black, x, y)
        y += 25

        g.DrawString("Name : " & txtName.Text, bodyFont, Brushes.Black, x, y)
        y += 20

        ' ===== Book Details =====
        g.DrawLine(Pens.Black, x, y, 750, y)
        y += 15

        g.DrawString("Book Details", headFont, Brushes.Black, x, y)
        y += 25

        g.DrawString("Title : " & txtTitle.Text, bodyFont, Brushes.Black, x, y)
        y += 20
        g.DrawString("Author : " & txtAuthor.Text, bodyFont, Brushes.Black, x, y)
        y += 20

        ' ===== Pricing =====
        g.DrawLine(Pens.Black, x, y, 750, y)
        y += 15

        g.DrawString("Pricing", headFont, Brushes.Black, x, y)
        y += 25

        g.DrawString("Book Price : Rs. " & txtPrice.Text, bodyFont, Brushes.Black, x, y)
        y += 20

        g.DrawLine(Pens.Black, x, y, 750, y)
        y += 25

        g.DrawString("TOTAL AMOUNT : Rs. " & txtPrice.Text, headFont, Brushes.Black, x, y)

        ' Footer
        y += 40
        g.DrawString("Thank you for your purchase!", bodyFont, Brushes.Black, x + 220, y)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        UserBookDetail.Show()
        Me.Close()
    End Sub
End Class