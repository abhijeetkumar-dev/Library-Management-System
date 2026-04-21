Imports System.Data.OleDb

Public Class OverdueFineForm
    Dim con As New OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb; Persist Security Info=False;")
    Dim lastFinePaidDate As Date = Date.MinValue

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        UserInterface.Show()
        Me.Close()
    End Sub

    Private Sub DeleteExpiredMemberships()

        Dim query As String = "DELETE FROM Membership WHERE ExpiryDate < @today"
        Dim cmd As New OleDbCommand(query, con)

        cmd.Parameters.AddWithValue("@today", Date.Today)

        con.Open()
        Dim rows As Integer = cmd.ExecuteNonQuery()
        con.Close()

        If rows > 0 Then
            MessageBox.Show("Expired membership data removed automatically!")
        End If

    End Sub

    Private Sub OverdueFineForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMembership()
        LoadPurchasedBooks()
        LoadIssuedBooks()
        LoadOverdueAndFine()
        DeleteExpiredMemberships()
        GetLastInvoiceNo()

        btnPay.Enabled = False
        btnCancel.Enabled = False
        btnPrint.Enabled = False
        picQR.Visible = False
    End Sub

    Private Sub LoadMembership()
        Dim query As String = "SELECT * FROM Membership WHERE Name = @user"
        Dim cmd As New OleDbCommand(query, con)
        cmd.Parameters.AddWithValue("@user", User.LoggedUserName)

        Dim da As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable()
        da.Fill(dt)

        dgvMembership.DataSource = dt
    End Sub

    Private Sub LoadPurchasedBooks()
        Dim query As String = "SELECT * FROM PurchaseBook WHERE UserName = @user"
        Dim cmd As New OleDbCommand(query, con)
        cmd.Parameters.AddWithValue("@user", User.LoggedUserName)

        Dim da As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable()
        da.Fill(dt)

        dgvPurchase.DataSource = dt
    End Sub

    Private Sub LoadIssuedBooks()
        Dim query As String = "SELECT * FROM IssueBook WHERE UserName = @user"
        Dim cmd As New OleDbCommand(query, con)
        cmd.Parameters.AddWithValue("@user", User.LoggedUserName)

        Dim da As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable()
        da.Fill(dt)

        dgvIssue.DataSource = dt
    End Sub

    Private Sub LoadOverdueAndFine()

        Dim totalOverdueDays As Integer = 0
        Dim finePerDay As Integer = 10   ' Rs 10 per day

        ' If no issued books
        If dgvIssue.Rows.Count = 0 Or dgvIssue.Rows(0).IsNewRow Then
            rbCash.Enabled = False
            rbUpi.Enabled = False
            btnPay.Enabled = False
            btnCancel.Enabled = False
            picQR.Visible = False
            Exit Sub
        End If

        ' Loop through issued books
        For Each row As DataGridViewRow In dgvIssue.Rows

            If row.IsNewRow Then Continue For

            Dim issueDate As Date = Convert.ToDateTime(row.Cells("IssueDate").Value)
            Dim daysPassed As Integer = (Date.Today - issueDate).Days

            If daysPassed > 14 Then
                totalOverdueDays += (daysPassed - 14)
            End If

        Next

        txtOverdueDays.Text = totalOverdueDays.ToString()
        txtFine.Text = "Rs " & (totalOverdueDays * finePerDay).ToString()

        ' Enable payment only if fine exists
        If totalOverdueDays > 0 Then
            rbCash.Enabled = True
            rbUpi.Enabled = True
        Else
            rbCash.Enabled = False
            rbUpi.Enabled = False
            btnPay.Enabled = False
            btnCancel.Enabled = False
            picQR.Visible = False
        End If

    End Sub

    Private Sub rbCash_CheckedChanged(sender As Object, e As EventArgs) Handles rbCash.CheckedChanged
        If rbCash.Checked = True Then
            btnPay.Enabled = True
            btnCancel.Enabled = True
            picQR.Visible = False   'Hide QR when cash selected
        End If
    End Sub

    Private Sub rbUpi_CheckedChanged(sender As Object, e As EventArgs) Handles rbUpi.CheckedChanged
        If rbUpi.Checked = True Then
            btnPay.Enabled = True
            btnCancel.Enabled = True
            picQR.Visible = True   'Show QR when UPI selected
        End If
    End Sub

    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        If rbCash.Checked = False AndAlso rbUpi.Checked = False Then
            MessageBox.Show("Select payment method!")
            Exit Sub
        End If

        Dim paymentMethod As String = If(rbCash.Checked, "Cash", "UPI")

        Dim overdueDays As Integer = Val(txtOverdueDays.Text)
        Dim fineAmount As Integer = overdueDays * 10

        ' Save fine payment
        Dim query As String = "INSERT INTO [Overdue&Fine](InvoiceNo, Username, OverdueDays, FineAmount, PaymentMethod, PaidDate) VALUES (@InvoiceNo, @user, @days, @amount, @method, @date)"

        Dim cmd As New OleDbCommand(query, con)
        cmd.Parameters.AddWithValue("@InvoiceNo", GetLastInvoiceNo.ToString())
        cmd.Parameters.AddWithValue("@user", User.LoggedUserName)
        cmd.Parameters.AddWithValue("@days", overdueDays.ToString())
        cmd.Parameters.AddWithValue("@amount", fineAmount.ToString())
        cmd.Parameters.AddWithValue("@method", paymentMethod)
        cmd.Parameters.AddWithValue("@date", Date.Today)

        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        rbCash.Checked = False
        rbUpi.Checked = False
        btnPay.Enabled = False
        btnCancel.Enabled = False
        picQR.Visible = False

        MessageBox.Show("Fine Paid Successfully & Issue Date Reset!", "Success")
        btnPrint.Enabled = True

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        rbCash.Checked = False
        rbUpi.Checked = False
        picQR.Visible = False
        btnPay.Enabled = False
        btnCancel.Enabled = False

        MessageBox.Show("Payment has been cancelled.", "Cancelled")
    End Sub

    Private Function GetLastInvoiceNo() As String
        Dim newInvoice As String = ""
        Dim yearPart As String = DateTime.Now.Year.ToString()
        Dim lastNumber As Integer = 0

        Try
            Dim cmd As New OleDbCommand("SELECT InvoiceNo FROM [Overdue&Fine] WHERE InvoiceNo LIKE 'INV-" & yearPart & "-%' ORDER BY InvoiceNo DESC", con)

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

    Private Sub ResetIssueDateAfterFine()

        Dim query As String = "UPDATE IssueBook SET IssueDate = @today WHERE UserName = @user AND DateDiff('d', IssueDate, @today) > 14"

        Dim cmd As New OleDbCommand(query, con)
        cmd.Parameters.AddWithValue("@today", Date.Today)
        cmd.Parameters.AddWithValue("@user", User.LoggedUserName)

        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

    End Sub


    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.StartPosition = FormStartPosition.CenterScreen
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.ShowDialog()

        txtOverdueDays.Text = "0"
        txtFine.Text = "Rs 0"

        ResetIssueDateAfterFine()
        LoadIssuedBooks()
        LoadOverdueAndFine()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim fontTitle As New Font("Times New Roman", 28, FontStyle.Bold, ContentAlignment.TopCenter)
        Dim fontBody As New Font("Times New Roman", 14)

        Dim invoiceNo As String = GetLastInvoiceNo()
        Dim y As Integer = 50

        e.Graphics.DrawString("     Library Fine Invoice", fontTitle, Brushes.Black, 200, y)

        y += 40
        y += 40
        e.Graphics.DrawString("      Invoice No: " & invoiceNo, fontBody, Brushes.Black, 50, y)
        y += 25
        e.Graphics.DrawString("      Username: " & User.LoggedUserName, fontBody, Brushes.Black, 50, y)
        y += 25
        e.Graphics.DrawString("      Overdue Days: " & txtOverdueDays.Text, fontBody, Brushes.Black, 50, y)
        y += 25
        e.Graphics.DrawString("      Fine Amount: " & txtFine.Text, fontBody, Brushes.Black, 50, y)
        y += 25
        e.Graphics.DrawString("      Payment Mode: " & If(rbCash.Checked, "Cash", "UPI"), fontBody, Brushes.Black, 50, y)
        y += 25
        e.Graphics.DrawString("      Paid Date: " & Date.Today.ToShortDateString(), fontBody, Brushes.Black, 50, y)
        y += 40
        e.Graphics.DrawString("     Thank You!", fontBody, Brushes.Black, 250, y)
    End Sub
End Class