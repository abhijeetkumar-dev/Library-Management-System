<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IssueReturnInterface
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvIssue = New System.Windows.Forms.DataGridView()
        Me.dgvReturn = New System.Windows.Forms.DataGridView()
        Me.btnReturnBooks = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnRenew = New System.Windows.Forms.Button()
        CType(Me.dgvIssue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Teal
        Me.Label1.Location = New System.Drawing.Point(57, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Issued Books "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Teal
        Me.Label2.Location = New System.Drawing.Point(55, 339)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 31)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Return Books"
        '
        'dgvIssue
        '
        Me.dgvIssue.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvIssue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIssue.Location = New System.Drawing.Point(256, 26)
        Me.dgvIssue.Name = "dgvIssue"
        Me.dgvIssue.ReadOnly = True
        Me.dgvIssue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIssue.Size = New System.Drawing.Size(733, 282)
        Me.dgvIssue.TabIndex = 2
        '
        'dgvReturn
        '
        Me.dgvReturn.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReturn.Location = New System.Drawing.Point(256, 339)
        Me.dgvReturn.Name = "dgvReturn"
        Me.dgvReturn.ReadOnly = True
        Me.dgvReturn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReturn.Size = New System.Drawing.Size(733, 263)
        Me.dgvReturn.TabIndex = 3
        '
        'btnReturnBooks
        '
        Me.btnReturnBooks.BackColor = System.Drawing.Color.PaleGreen
        Me.btnReturnBooks.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReturnBooks.ForeColor = System.Drawing.Color.Crimson
        Me.btnReturnBooks.Location = New System.Drawing.Point(65, 111)
        Me.btnReturnBooks.Name = "btnReturnBooks"
        Me.btnReturnBooks.Size = New System.Drawing.Size(138, 50)
        Me.btnReturnBooks.TabIndex = 4
        Me.btnReturnBooks.Text = "Return"
        Me.btnReturnBooks.UseVisualStyleBackColor = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(153, 405)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 25)
        Me.lblStatus.TabIndex = 38
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(58, 403)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(95, 26)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Status : "
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.WindowsApplication1.My.Resources.Resources.Back
        Me.PictureBox1.Location = New System.Drawing.Point(12, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(45, 36)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        '
        'btnRenew
        '
        Me.btnRenew.BackColor = System.Drawing.Color.PaleGreen
        Me.btnRenew.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRenew.ForeColor = System.Drawing.Color.Crimson
        Me.btnRenew.Location = New System.Drawing.Point(65, 186)
        Me.btnRenew.Name = "btnRenew"
        Me.btnRenew.Size = New System.Drawing.Size(138, 50)
        Me.btnRenew.TabIndex = 40
        Me.btnRenew.Text = "Renew"
        Me.btnRenew.UseVisualStyleBackColor = False
        '
        'IssueReturnInterface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PapayaWhip
        Me.ClientSize = New System.Drawing.Size(1006, 613)
        Me.Controls.Add(Me.btnRenew)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btnReturnBooks)
        Me.Controls.Add(Me.dgvReturn)
        Me.Controls.Add(Me.dgvIssue)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "IssueReturnInterface"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IssueReturnInterface"
        CType(Me.dgvIssue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReturn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvIssue As System.Windows.Forms.DataGridView
    Friend WithEvents dgvReturn As System.Windows.Forms.DataGridView
    Friend WithEvents btnReturnBooks As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnRenew As System.Windows.Forms.Button
End Class
