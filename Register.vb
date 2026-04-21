Imports System.Data.OleDb
Imports System.Text.RegularExpressions

Public Class Register
    Dim con As New OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb; Persist Security Info=False;")
    Dim showPassword As Boolean = True

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If showPassword Then
            PictureBox2.Image = My.Resources.eye
            Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Else
            PictureBox2.Image = My.Resources.HIde
            Me.txtPassword.PasswordChar = Nothing
        End If
        showPassword = Not showPassword

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        If showPassword Then
            PictureBox4.Image = My.Resources.eye
            Me.txtConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Else
            PictureBox4.Image = My.Resources.HIde
            Me.txtConfirmPassword.PasswordChar = Nothing
        End If
        showPassword = Not showPassword
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Login.Show()
        Me.Close()
    End Sub

    Public Function IsValidEmail(email As String) As Boolean
        Return Regex.IsMatch(email, "^[\w\.-]+@[\w\.-]+\.\w+$")
    End Function

    Public Function IsValidMobile(mobile As String) As Boolean
        Return Regex.IsMatch(mobile, "^[0-9]{10}$")
    End Function

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If txtUser.Text.Trim = "" Or txtPassword.Text.Trim = "" Or
        txtConfirmPassword.Text.Trim = "" Or cmbCourse.Text.Trim = "" Or
        txtEmail.Text.Trim = "" Or txtMobile.Text.Trim = "" Then

            MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        '-------------------------
        ' 2. PASSWORD MATCH CHECK
        '-------------------------
        If txtPassword.Text <> txtConfirmPassword.Text Then
            MessageBox.Show("Password & Confirm Password must be same!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        '-------------------------
        ' 3. EMAIL VALIDATION
        '-------------------------
        If Not IsValidEmail(txtEmail.Text) Then
            MessageBox.Show("Invalid Email Format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        '-------------------------
        ' 4. MOBILE VALIDATION
        '-------------------------
        If Not IsValidMobile(txtMobile.Text) Then
            MessageBox.Show("Mobile number must be 10 digits!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        '-------------------------
        ' 5. INSERT INTO DATABASE
        '-------------------------
        Try
            con.Open()

            Dim query As String = "INSERT INTO Register (Username, [Password], Course, Email, MobileNo, RegistrationDate) VALUES (@un, @pw, @cr, @em, @mo, @dt)"

            Dim cmd As New OleDbCommand(query, con)

            cmd.Parameters.AddWithValue("@un", txtUser.Text)
            cmd.Parameters.AddWithValue("@pw", txtPassword.Text)
            cmd.Parameters.AddWithValue("@cr", cmbCourse.Text)
            cmd.Parameters.AddWithValue("@em", txtEmail.Text)
            cmd.Parameters.AddWithValue("@mo", txtMobile.Text)
            cmd.Parameters.AddWithValue("@dt", dtpRegister.Value.Date)

            cmd.ExecuteNonQuery()

            MessageBox.Show("Registration Successful!" & vbCrLf &"Registration Date: " & dtpRegister.Value.ToLongDateString,"Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()
            Login.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub ClearFields()
        txtUser.Clear()
        txtPassword.Clear()
        txtConfirmPassword.Clear()
        cmbCourse.Text = ""
        txtEmail.Clear()
        txtMobile.Clear()
    End Sub

    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 900
        Me.Height = 700

        cmbCourse.Items.Clear()
        cmbCourse.Items.AddRange(New String() {"Computer Science", "Commerce", "Science", "Arts", "Digital Marketing", "Law"})
        cmbCourse.SelectedIndex = 0
        cmbCourse.Text = "  Select a Course  "

    End Sub
End Class