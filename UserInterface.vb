Imports System.Data.OleDb

Public Class UserInterface
    Dim con As New OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb; Persist Security Info=False;")
    Dim loopdone As Boolean = False

    Private Async Sub UserInterface_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.AutoScroll = True
        Panel1.HorizontalScroll.Enabled = True
        Panel1.HorizontalScroll.Visible = True
        Panel1.VerticalScroll.Enabled = False
        Panel1.VerticalScroll.Visible = False

        pic1Book.Tag = 10
        pic2Book.Tag = 5
        pic3Book.Tag = 7
        pic4Book.Tag = 11
        pic5Book.Tag = 4
        pic6Book.Tag = 9
        pic7Book.Tag = 12
        pic8Book.Tag = 6
        pic9Book.Tag = 8

        AddHandler pic1Book.Click, AddressOf Book_Click
        AddHandler pic2Book.Click, AddressOf Book_Click
        AddHandler pic3Book.Click, AddressOf Book_Click
        AddHandler pic4Book.Click, AddressOf Book_Click
        AddHandler pic5Book.Click, AddressOf Book_Click
        AddHandler pic6Book.Click, AddressOf Book_Click
        AddHandler pic7Book.Click, AddressOf Book_Click
        AddHandler pic8Book.Click, AddressOf Book_Click
        AddHandler pic9Book.Click, AddressOf Book_Click

        For i As Integer = Panel1.HorizontalScroll.Minimum To Panel1.HorizontalScroll.Maximum Step 1

            If Me.IsDisposed OrElse Panel1.IsDisposed Then
                Exit For
            End If
            Panel1.HorizontalScroll.Value = i
            Panel1.PerformLayout()
            Application.DoEvents()

            Await Task.Delay(70)

            lblGreeting.Text = "Hello, " & User.LoggedUserName & "!"
            lblDate.Text = "  Date: " & Date.Now.ToString("dd-MM-yyyy") & vbCrLf & "Time: " & Date.Now.ToString("hh:mm:ss tt")
        Next
    End Sub

    Private Sub Book_Click(sender As Object, e As EventArgs)
        Dim pic As PictureBox = CType(sender, PictureBox)
        Dim selectedBookID As Integer = CInt(pic.Tag)

        Dim detailForm As New UserBookDetail()
        detailForm.SelectedBookID = selectedBookID
        detailForm.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        ContextMenuStrip1.Show(PictureBox7, 0, PictureBox7.Height)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Membership.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        UserBookDetail.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Membership.Show()
        Me.Close()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        IssueReturnInterface.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        OverdueFineForm.Show()
        Me.Close()
    End Sub

    Private Sub ProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProfileToolStripMenuItem.Click
        Dim frm As New ProfileForm()

        ' Get mouse position on screen
        Dim mousePos As Point = Cursor.Position

        ' Set form position
        frm.StartPosition = FormStartPosition.Manual
        frm.Location = mousePos

        frm.Show()
    End Sub
End Class