<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OverdueFineForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OverdueFineForm))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dgvIssue = New System.Windows.Forms.DataGridView()
        Me.dgvPurchase = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFine = New System.Windows.Forms.TextBox()
        Me.btnPay = New System.Windows.Forms.Button()
        Me.txtOverdueDays = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvMembership = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.picQR = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rbCash = New System.Windows.Forms.RadioButton()
        Me.rbUpi = New System.Windows.Forms.RadioButton()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvIssue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMembership, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picQR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.WindowsApplication1.My.Resources.Resources.Back
        Me.PictureBox1.Location = New System.Drawing.Point(14, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(45, 36)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'dgvIssue
        '
        Me.dgvIssue.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvIssue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIssue.Location = New System.Drawing.Point(238, 12)
        Me.dgvIssue.Name = "dgvIssue"
        Me.dgvIssue.ReadOnly = True
        Me.dgvIssue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIssue.Size = New System.Drawing.Size(754, 191)
        Me.dgvIssue.TabIndex = 43
        '
        'dgvPurchase
        '
        Me.dgvPurchase.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPurchase.Location = New System.Drawing.Point(131, 478)
        Me.dgvPurchase.Name = "dgvPurchase"
        Me.dgvPurchase.ReadOnly = True
        Me.dgvPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPurchase.Size = New System.Drawing.Size(861, 120)
        Me.dgvPurchase.TabIndex = 42
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(98, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 62)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = " Issued " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Books"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(12, 478)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 52)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Purchase " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  Books "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(52, 222)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(316, 26)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Overdue and Fine on Books : "
        '
        'txtFine
        '
        Me.txtFine.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFine.Location = New System.Drawing.Point(363, 222)
        Me.txtFine.Name = "txtFine"
        Me.txtFine.ReadOnly = True
        Me.txtFine.Size = New System.Drawing.Size(88, 26)
        Me.txtFine.TabIndex = 49
        Me.txtFine.Text = "    "
        Me.txtFine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnPay
        '
        Me.btnPay.BackColor = System.Drawing.Color.PaleGreen
        Me.btnPay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPay.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPay.ForeColor = System.Drawing.Color.Navy
        Me.btnPay.Location = New System.Drawing.Point(672, 268)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(111, 29)
        Me.btnPay.TabIndex = 50
        Me.btnPay.Text = "Pay"
        Me.btnPay.UseVisualStyleBackColor = False
        '
        'txtOverdueDays
        '
        Me.txtOverdueDays.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOverdueDays.Location = New System.Drawing.Point(104, 161)
        Me.txtOverdueDays.Name = "txtOverdueDays"
        Me.txtOverdueDays.ReadOnly = True
        Me.txtOverdueDays.Size = New System.Drawing.Size(77, 29)
        Me.txtOverdueDays.TabIndex = 52
        Me.txtOverdueDays.Text = "     "
        Me.txtOverdueDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(52, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(180, 31)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Overdue Days"
        '
        'dgvMembership
        '
        Me.dgvMembership.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvMembership.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMembership.Location = New System.Drawing.Point(17, 368)
        Me.dgvMembership.Name = "dgvMembership"
        Me.dgvMembership.ReadOnly = True
        Me.dgvMembership.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMembership.Size = New System.Drawing.Size(980, 85)
        Me.dgvMembership.TabIndex = 54
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(12, 327)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(210, 26)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Membership Detail"
        '
        'picQR
        '
        Me.picQR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picQR.Image = Global.WindowsApplication1.My.Resources.Resources.QR
        Me.picQR.Location = New System.Drawing.Point(824, 222)
        Me.picQR.Name = "picQR"
        Me.picQR.Size = New System.Drawing.Size(125, 126)
        Me.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picQR.TabIndex = 55
        Me.picQR.TabStop = False
        Me.picQR.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(466, 222)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 26)
        Me.Label6.TabIndex = 56
        Me.Label6.Text = "Pay Fine : "
        '
        'rbCash
        '
        Me.rbCash.AutoSize = True
        Me.rbCash.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCash.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.rbCash.Location = New System.Drawing.Point(613, 225)
        Me.rbCash.Name = "rbCash"
        Me.rbCash.Size = New System.Drawing.Size(74, 27)
        Me.rbCash.TabIndex = 57
        Me.rbCash.TabStop = True
        Me.rbCash.Text = "Cash"
        Me.rbCash.UseVisualStyleBackColor = True
        '
        'rbUpi
        '
        Me.rbUpi.AutoSize = True
        Me.rbUpi.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbUpi.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.rbUpi.Location = New System.Drawing.Point(720, 224)
        Me.rbUpi.Name = "rbUpi"
        Me.rbUpi.Size = New System.Drawing.Size(63, 27)
        Me.rbUpi.TabIndex = 58
        Me.rbUpi.TabStop = True
        Me.rbUpi.Text = "UPI"
        Me.rbUpi.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.PaleGreen
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Navy
        Me.btnCancel.Location = New System.Drawing.Point(672, 313)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(118, 29)
        Me.btnCancel.TabIndex = 59
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.PaleGreen
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.Enabled = False
        Me.btnPrint.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.Navy
        Me.btnPrint.Location = New System.Drawing.Point(471, 277)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(176, 51)
        Me.btnPrint.TabIndex = 60
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'OverdueFineForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PapayaWhip
        Me.ClientSize = New System.Drawing.Size(1004, 610)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.rbUpi)
        Me.Controls.Add(Me.rbCash)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.picQR)
        Me.Controls.Add(Me.dgvMembership)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtOverdueDays)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnPay)
        Me.Controls.Add(Me.txtFine)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.dgvIssue)
        Me.Controls.Add(Me.dgvPurchase)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "OverdueFineForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OverdueFineForm"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvIssue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMembership, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picQR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents dgvIssue As System.Windows.Forms.DataGridView
    Friend WithEvents dgvPurchase As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFine As System.Windows.Forms.TextBox
    Friend WithEvents btnPay As System.Windows.Forms.Button
    Friend WithEvents txtOverdueDays As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvMembership As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents picQR As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rbCash As System.Windows.Forms.RadioButton
    Friend WithEvents rbUpi As System.Windows.Forms.RadioButton
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
End Class
