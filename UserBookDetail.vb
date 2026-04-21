Imports System.Data.OleDb
Public Class UserBookDetail
    Dim con As New OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb; Persist Security Info=False;")
    Public SelectedBookID As Integer

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        UserInterface.Show()
        Me.Close()
    End Sub

    Private Sub UserBookDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAllBooks()
        PanelBooks.AutoScroll = True
        PanelBooks.AutoScrollMargin = New Size(0, 20)
        PanelBooks.Padding = New Padding(0, 0, 10, 0)

        If SelectedBookID > 0 Then
            LoadBookDetails(SelectedBookID)
        End If
    End Sub

    Private Sub LoadAllBooks()

        PanelBooks.Controls.Clear()

        Dim cmd As New OleDbCommand("SELECT * FROM BookDetail ORDER BY BookID", con)
        con.Open()
        Dim dr As OleDbDataReader = cmd.ExecuteReader()

        Dim yPos As Integer = 10

        While dr.Read()

            GlobalVariables.SelectedBookTitle = lblTitle.Text
            GlobalVariables.SelectedBookAuthor = lblAuthor.Text

            ' Create a Panel for each book
            Dim bookPanel As New Panel With {
                .Width = 450,
                .Height = 135,
                .BorderStyle = BorderStyle.FixedSingle,
                .Location = New Point(10, yPos),
                .BackColor = Color.White
            }

            ' Picture Box
            Dim pic As New PictureBox With {
                .Width = 71,
                .Height = 106,
                .SizeMode = PictureBoxSizeMode.StretchImage,
                .Location = New Point(30, 10)
            }

            Try
                pic.Image = My.Resources.ResourceManager.GetObject(dr("ResourceName").ToString())
            Catch
                pic.Image = Nothing
            End Try

            ' Book Title Label
            Dim lbl As New Label With {
                .Text = dr("Title").ToString(),
                .Font = New Font("Times New Roman", 14, FontStyle.Bold),
                .ForeColor = Color.Navy,
                .AutoSize = True,
                .Location = New Point(125, 22)
            }

            ' Detail Button
            Dim btnDetail As New Button With
            {
                .Text = "Detail",
                .BackColor = Color.LightGreen,
                .Font = New Font("Times New Roman", 14, FontStyle.Bold),
                .Width = 80,
                .Height = 35,
                .Cursor = Cursors.Hand,
                .Location = New Point(140, 70)
            }

            btnDetail.Tag = dr("BookID")        ' IMPORTANT
            AddHandler btnDetail.Click, AddressOf btnDetail_Click

            ' Add controls inside panel
            bookPanel.Controls.Add(pic)
            bookPanel.Controls.Add(lbl)
            bookPanel.Controls.Add(btnDetail)

            ' Add panel to main panel
            PanelBooks.Controls.Add(bookPanel)

            yPos += 140
        End While

        dr.Close()
        con.Close()

    End Sub

    Private Sub LoadBookDetails(bookID As Integer)
        Try
            Dim cmd As New OleDbCommand("SELECT * FROM BookDetail WHERE BookID=@id", con)
            cmd.Parameters.AddWithValue("@id", bookID)

            con.Open()
            Dim dr As OleDbDataReader = cmd.ExecuteReader()

            If dr.Read() Then
                lblBookID.Text = dr("BookID").ToString()
                lblTitle.Text = dr("Title").ToString()
                lblAuthor.Text = dr("Author").ToString()
                lblPublisher.Text = dr("Publisher").ToString()
                lblYear.Text = dr("BookYear").ToString
                lblAvailability.Text = dr("AvailableCopies").ToString
                lblPrice.Text = dr("Price").ToString()

                btnIssue.Tag = dr("BookID")
                btnPurchase.Tag = dr("BookID")

                Try
                    pbDetail.Image = My.Resources.ResourceManager.GetObject(dr("ResourceName").ToString())
                Catch
                    pbDetail.Image = Nothing
                End Try
            End If

            dr.Close()
            con.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading book: " & ex.Message)
        End Try
    End Sub


    Private Sub btnDetail_Click(sender As Object, e As EventArgs) Handles btnDetail.Click

        Dim bookID As Integer = CType(sender, Button).Tag
        Dim cmd As New OleDbCommand("SELECT * FROM BookDetail WHERE BookID=" & bookID, con)

        con.Open()
        Dim dr As OleDbDataReader = cmd.ExecuteReader()

        If dr.Read() Then

            lblBookID.Text = dr("BookID").ToString()
            lblTitle.Text = dr("Title").ToString()
            lblAuthor.Text = dr("Author").ToString()
            lblPublisher.Text = dr("Publisher").ToString()
            lblYear.Text = dr("BookYear").ToString()
            lblAvailability.Text = dr("AvailableCopies").ToString()
            lblPrice.Text = dr("Price").ToString()

            btnIssue.Tag = dr("BookID")
            btnPurchase.Tag = dr("BookID")

            ' Load image
            Try
                pbDetail.Image = My.Resources.ResourceManager.GetObject(dr("ResourceName").ToString())
            Catch
                pbDetail.Image = Nothing
            End Try

        End If

        dr.Close()
        con.Close()

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim keyword As String = txtSearch.Text.Trim()

        If keyword = "" Then
            LoadAllBooks()   ' if empty, reload all books
        Else
            LoadSearchedBooks(keyword)
        End If
    End Sub

    Private Sub LoadSearchedBooks(keyword As String)

        PanelBooks.Controls.Clear()

    Dim cmd As New OleDbCommand("SELECT * FROM BookDetail WHERE Title LIKE @key ORDER BY BookID", con)

        cmd.Parameters.AddWithValue("@key", "%" & keyword & "%")

        con.Open()
        Dim dr As OleDbDataReader = cmd.ExecuteReader()

        Dim yPos As Integer = 10

        While dr.Read()

            ' Create panel
            Dim bookPanel As New Panel With {
                .Width = 450,
                .Height = 135,
                .BorderStyle = BorderStyle.FixedSingle,
                .Location = New Point(10, yPos),
                .BackColor = Color.White
            }

            ' Picture Box
            Dim pic As New PictureBox With {
                .Width = 71,
                .Height = 106,
                .SizeMode = PictureBoxSizeMode.StretchImage,
                .Location = New Point(30, 10)
            }

            Try
                pic.Image = My.Resources.ResourceManager.GetObject(dr("ResourceName").ToString())
            Catch
                pic.Image = Nothing
            End Try

            ' Label
            Dim lbl As New Label With {
                .Text = dr("Title").ToString(),
                .Font = New Font("Times New Roman", 14, FontStyle.Bold),
                .ForeColor = Color.Navy,
                .AutoSize = True,
                .Location = New Point(125, 22)
            }

            ' Detail Button
            Dim btnDetail As New Button With {
                .Text = "Detail",
                .BackColor = Color.LightGreen,
                .Font = New Font("Times New Roman", 14, FontStyle.Bold),
                .Width = 80,
                .Height = 35,
                .Location = New Point(160, 70)
            }

            btnDetail.Tag = dr("BookID")
            AddHandler btnDetail.Click, AddressOf btnDetail_Click

            ' Add to panel
            bookPanel.Controls.Add(pic)
            bookPanel.Controls.Add(lbl)
            bookPanel.Controls.Add(btnDetail)

            ' Add to scroll panel
            PanelBooks.Controls.Add(bookPanel)

            yPos += 140
        End While

        dr.Close()
        con.Close()

    End Sub

    Private Function AreBookDetailsComplete() As Boolean
        If lblBookID.Text = "" Then Return False
        If lblTitle.Text = "" Then Return False
        If lblAuthor.Text = "" Then Return False
        If lblPublisher.Text = "" Then Return False
        If lblYear.Text = "" Then Return False
        If lblAvailability.Text = "" Then Return False
        If lblPrice.Text = "" Then Return False

        Return True
    End Function

    Private Sub btnPurchase_Click(sender As Object, e As EventArgs) Handles btnPurchase.Click
        If Not AreBookDetailsComplete() Then
            MessageBox.Show("Book details are not fully loaded. Please select a book first.")
            Exit Sub
        End If

        Dim bookID As Integer = CInt(CType(sender, Button).Tag)

        Try
            con.Open()

            Dim cmd As New OleDbCommand("UPDATE BookDetail SET AvailableCopies = AvailableCopies - 1 WHERE BookID = @id AND AvailableCopies > 0", con)
            cmd.Parameters.AddWithValue("@id", bookID)

            Dim rows As Integer = cmd.ExecuteNonQuery()

            If rows > 0 Then
                MessageBox.Show("Book added successfully! Redirecting you to the payment section.", "Proceed to Payment", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Book is not available!")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try

        LoadBookDetails(bookID)

        Dim pf As New PaymentPurchaseBook()

        'Send user details
        pf.UserName = LoggedUserName

        'Send book details
        pf.BookTitle = lblTitle.Text
        pf.BookAuthor = lblAuthor.Text
        pf.BookPrice = lblPrice.Text
        pf.BookImage = pbDetail.Image
        pf.selectedBookID = SelectedBookID
        pf.Show()
        Me.Close()
    End Sub

    Private Sub btnIssue_Click(sender As Object, e As EventArgs) Handles btnIssue.Click
        If Not AreBookDetailsComplete() Then
            MessageBox.Show("Book details are not fully loaded. Please select a book first.")
            Exit Sub
        End If

        If Not IsMembershipValid(User.LoggedUserName) Then
            MessageBox.Show("You don't have an active membership! Please get the membership for issue and renew books.", "Membership Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Membership.Show()
            Me.Close()
            Exit Sub
        End If

        Dim bookID As Integer = CInt(CType(sender, Button).Tag)

        Try
            con.Open()

            Dim cmd As New OleDbCommand("UPDATE BookDetail SET AvailableCopies = AvailableCopies - 1 WHERE BookID = @id AND AvailableCopies > 0", con)
            cmd.Parameters.AddWithValue("@id", bookID)

            Dim rows As Integer = cmd.ExecuteNonQuery()

            If rows > 0 Then
                MessageBox.Show("Book added successfully! Redirecting you to the Issue Book section")
            Else
                MessageBox.Show("Book is not available!")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try

        LoadBookDetails(bookID)

        Dim pf As New PaymentIssueBook()

        'Send user details
        pf.UserName = LoggedUserName

        'Send book details
        pf.BookTitle = lblTitle.Text
        pf.BookAuthor = lblAuthor.Text
        pf.BookImage = pbDetail.Image
        pf.selectedBookID = SelectedBookID
        pf.Show()
        Me.Close()
    End Sub

    Private Function IsMembershipValid(userName As String) As Boolean
        Try
            Dim cmd As New OleDbCommand("SELECT ExpiryDate FROM Membership WHERE Name = @name", con)
            cmd.Parameters.AddWithValue("@name", userName)

            con.Open()
            Dim dr As OleDbDataReader = cmd.ExecuteReader()

            If dr.Read() Then
                Dim expiry As Date = Convert.ToDateTime(dr("ExpiryDate"))
                dr.Close()
                con.Close()

                ' If expiry date today or later → valid
                If expiry >= Date.Today Then
                    Return True
                Else
                    Return False
                End If
            Else
                ' No membership record found
                dr.Close()
                con.Close()
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show("Error checking membership: " & ex.Message)
            con.Close()
            Return False
        End Try
    End Function

End Class


