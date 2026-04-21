Imports System.Data.OleDb
Public Class Membership
    ReadOnly conString As String = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb;Persist Security Info=False;"
    Dim regConString As String = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = F:\Project (Library Management)\My Project (Library Management)\Project\bin\Debug\LibraryManagementDB.accdb"

    Private Sub Membership_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpRegister.Value = DateTime.Now
        dtpDOB.Format = DateTimePickerFormat.Short
        dtpRegister.Format = DateTimePickerFormat.Short

        cmbPlan.Items.Clear()
        cmbPlan.Items.AddRange(New String() {"Monthly", "Quarterly", "Half-Yearly", "Yearly"})
        cmbPlan.SelectedIndex = -1

        cmbGender.Items.Clear()
        cmbGender.Items.AddRange(New String() {"Male", "Female"})
        cmbGender.SelectedIndex = -1

        cmbType.Items.Clear()
        cmbType.Items.AddRange(New String() {"Student", "Teacher", "General-Public"})
        cmbType.SelectedIndex = -1

        cmbPmethod.Items.AddRange(New String() {"Cash", "UPI"})
        cmbPmethod.SelectedIndex = -1

        CalculateFeesAndExpiry()

    End Sub

    Private Sub cmbPlan_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbPlan.SelectedIndexChanged
        CalculateFeesAndExpiry()
    End Sub

    Private Sub dtpRegister_ValueChanged_1(sender As Object, e As EventArgs) Handles dtpRegister.ValueChanged
        CalculateFeesAndExpiry()
    End Sub

    Private Sub CalculateFeesAndExpiry()
        ' Determine fees and expiry based on selected plan
        Dim plan As String = If(cmbPlan.SelectedItem IsNot Nothing, cmbPlan.SelectedItem.ToString(), "")
        Dim subDate As DateTime = dtpRegister.Value.Date
        Dim expiry As DateTime = subDate
        Dim feesAmount As Decimal = 0D

        Select Case plan
            Case "Monthly"
                expiry = subDate.AddMonths(1).AddDays(-1) ' valid until same day next month -1
                feesAmount = 300
            Case "Quarterly"
                expiry = subDate.AddMonths(3).AddDays(-1)
                feesAmount = 800
            Case "Half-Yearly"
                expiry = subDate.AddYears(1).AddDays(-1)
                feesAmount = 1500
            Case "Yearly"
                expiry = subDate.AddYears(1).AddDays(-1)
                feesAmount = 3000
            Case Else
                expiry = subDate
                feesAmount = 0
        End Select

        txtExpiry.Text = expiry.ToShortDateString()
        txtFees.Text = feesAmount.ToString("F2")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtName.Text) Then
            MessageBox.Show("Please enter member name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return
        End If

        If cmbPmethod.Text = "" Then
            MessageBox.Show("Please select a payment method before purchasing!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Prepare values
        Dim idVal As String = txtID.Text.Trim()
        Dim nameVal As String = txtName.Text.Trim()
        Dim dobVal As Date = dtpDOB.Value.Date
        Dim genderVal As String = If(cmbGender.SelectedItem IsNot Nothing, cmbGender.SelectedItem.ToString(), "")
        Dim emailVal As String = txtEmail.Text.Trim()
        Dim mobileVal As String = txtMobile.Text.Trim()
        Dim addressVal As String = txtAddress.Text.Trim()
        Dim typeVal As String = If(cmbType.SelectedItem IsNot Nothing, cmbType.SelectedItem.ToString(), "")
        Dim planVal As String = If(cmbPlan.SelectedItem IsNot Nothing, cmbPlan.SelectedItem.ToString(), "")
        Dim subDateVal As Date = dtpRegister.Value.Date
        Dim payVal As String = If(cmbPmethod.SelectedItem IsNot Nothing, cmbPmethod.SelectedItem.ToString(), "")

        ' Parse fees and expiry from textboxes (we set them earlier)
        Dim feesVal As Decimal = 0
        Decimal.TryParse(txtFees.Text, feesVal)
        Dim expiryVal As Date = DateTime.Now
        Date.TryParse(txtExpiry.Text, expiryVal)

        Using conCheck As New OleDbConnection(conString)
            Dim checkSql As String = "SELECT * FROM Membership WHERE MemberID = ? AND ExpiryDate >= ?"

            Using cmdCheck As New OleDbCommand(checkSql, conCheck)
                cmdCheck.Parameters.AddWithValue("?", idVal)
                cmdCheck.Parameters.AddWithValue("?", Date.Today)

                conCheck.Open()

                Dim rdr As OleDbDataReader = cmdCheck.ExecuteReader()

                If rdr.HasRows Then
                    MessageBox.Show("You already have an active membership. You can take another membership only after this one expires.","Membership Exists",MessageBoxButtons.OK,MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End Using
        End Using

        ' Insert into Access DB using parameters - order matters for OleDb with ? placeholders
        Using con As New OleDbConnection(conString)
            Dim sql As String = "INSERT INTO Membership ([MemberID], [Name], [DOB], [Gender], [Email], [Mobile], [Address], [MembershipType], [MembershipPlan], [RegistrationDate], [ExpiryDate], [Fees], [PaymentMethod]) " &
                                "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
            Using cmd As New OleDbCommand(sql, con)
                ' Add parameters in the same order as the question marks
                cmd.Parameters.AddWithValue("?", idVal)
                cmd.Parameters.AddWithValue("?", nameVal)
                cmd.Parameters.AddWithValue("?", dobVal)
                cmd.Parameters.AddWithValue("?", genderVal)
                cmd.Parameters.AddWithValue("?", emailVal)
                cmd.Parameters.AddWithValue("?", mobileVal)
                cmd.Parameters.AddWithValue("?", addressVal)
                cmd.Parameters.AddWithValue("?", typeVal)
                cmd.Parameters.AddWithValue("?", planVal)
                cmd.Parameters.AddWithValue("?", subDateVal)
                cmd.Parameters.AddWithValue("?", expiryVal)
                cmd.Parameters.AddWithValue("?", feesVal)
                cmd.Parameters.AddWithValue("?", payVal)


                Try
                    con.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Member Registered Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Error while saving: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
        UserInterface.Show()
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearInputs(excludeId:=False)
    End Sub

    Private Sub ClearInputs(excludeId As Boolean)
        If Not excludeId Then txtID.Text = ""
        txtName.Text = ""
        dtpDOB.Value = DateTime.Now.AddYears(-20) ' default DOB
        cmbGender.SelectedIndex = 0
        txtEmail.Text = ""
        txtMobile.Text = ""
        txtAddress.Text = ""
        cmbType.SelectedIndex = -1
        cmbPlan.SelectedIndex = 0
        dtpRegister.Value = DateTime.Now
        cmbPmethod.SelectedIndex = 0
        CalculateFeesAndExpiry()
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        UserInterface.Show()
        Me.Close()
    End Sub

    Private Sub txtName_LostFocus(sender As Object, e As EventArgs) Handles txtName.LostFocus
        AutoFillMemberData()
    End Sub

    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtName.KeyDown
        If e.KeyCode = Keys.Enter Then
            AutoFillMemberData()
        End If
    End Sub

    Private Sub AutoFillMemberData()
        If txtName.Text.Trim() = "" Then Exit Sub

        Using con As New OleDbConnection(regConString)
            Dim query As String = "SELECT * FROM Register WHERE Username = @u"

            Using cmd As New OleDbCommand(query, con)
                cmd.Parameters.AddWithValue("@u", txtName.Text.Trim())
                Try
                    con.Open()
                    Dim reader As OleDbDataReader = cmd.ExecuteReader()

                    If reader.Read() Then
                        ' Auto-fill fields
                        txtEmail.Text = reader("EMail").ToString()
                        txtMobile.Text = reader("MobileNo").ToString()
                        txtID.Text = reader("MemberID").ToString()
                        dtpRegister.Value = Convert.ToDateTime(reader("RegistrationDate"))
                    Else
                        MessageBox.Show("Name Not Found In Registration!")
                    End If

                Catch ex As Exception
                    MessageBox.Show("Error loading registration data: " & ex.Message)
                End Try

            End Using
        End Using
    End Sub

    Private Sub cmbPmethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPmethod.SelectedIndexChanged
        If cmbPmethod.Text = "UPI" Then
            'Show QR
            picMQR.Visible = True
        Else
            'Hide QR for Cash / other methods
            picMQR.Visible = False
        End If
    End Sub
End Class