<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageIssueReturnForm
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
        Me.btnIUpdate = New System.Windows.Forms.Button()
        Me.btnIDeleteuser = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnISearch = New System.Windows.Forms.Button()
        Me.txtISearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvIssue = New System.Windows.Forms.DataGridView()
        Me.dgvReturn = New System.Windows.Forms.DataGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnRUpdate = New System.Windows.Forms.Button()
        Me.btnRDeleteUser = New System.Windows.Forms.Button()
        Me.btnRSearch = New System.Windows.Forms.Button()
        Me.txtRSearch = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.dgvIssue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnIUpdate
        '
        Me.btnIUpdate.BackColor = System.Drawing.Color.LightGray
        Me.btnIUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIUpdate.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIUpdate.Location = New System.Drawing.Point(49, 261)
        Me.btnIUpdate.Name = "btnIUpdate"
        Me.btnIUpdate.Size = New System.Drawing.Size(142, 40)
        Me.btnIUpdate.TabIndex = 20
        Me.btnIUpdate.Text = "Update Info"
        Me.btnIUpdate.UseVisualStyleBackColor = False
        '
        'btnIDeleteuser
        '
        Me.btnIDeleteuser.BackColor = System.Drawing.Color.LightGray
        Me.btnIDeleteuser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIDeleteuser.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIDeleteuser.Location = New System.Drawing.Point(49, 190)
        Me.btnIDeleteuser.Name = "btnIDeleteuser"
        Me.btnIDeleteuser.Size = New System.Drawing.Size(142, 43)
        Me.btnIDeleteuser.TabIndex = 19
        Me.btnIDeleteuser.Text = "Delete User"
        Me.btnIDeleteuser.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Teal
        Me.Label2.Location = New System.Drawing.Point(323, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(507, 36)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Manage Issue and Return Book List"
        '
        'btnISearch
        '
        Me.btnISearch.BackColor = System.Drawing.Color.LightGray
        Me.btnISearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnISearch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnISearch.Location = New System.Drawing.Point(746, 72)
        Me.btnISearch.Name = "btnISearch"
        Me.btnISearch.Size = New System.Drawing.Size(84, 30)
        Me.btnISearch.TabIndex = 15
        Me.btnISearch.Text = "Search"
        Me.btnISearch.UseVisualStyleBackColor = False
        '
        'txtISearch
        '
        Me.txtISearch.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtISearch.Location = New System.Drawing.Point(438, 74)
        Me.txtISearch.Name = "txtISearch"
        Me.txtISearch.Size = New System.Drawing.Size(302, 27)
        Me.txtISearch.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(329, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 26)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Search : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Teal
        Me.Label4.Location = New System.Drawing.Point(39, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(174, 31)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Issued Books "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Teal
        Me.Label3.Location = New System.Drawing.Point(37, 407)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(176, 31)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Return Books"
        '
        'dgvIssue
        '
        Me.dgvIssue.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvIssue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIssue.Location = New System.Drawing.Point(231, 114)
        Me.dgvIssue.Name = "dgvIssue"
        Me.dgvIssue.Size = New System.Drawing.Size(729, 230)
        Me.dgvIssue.TabIndex = 23
        '
        'dgvReturn
        '
        Me.dgvReturn.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReturn.Location = New System.Drawing.Point(231, 407)
        Me.dgvReturn.Name = "dgvReturn"
        Me.dgvReturn.Size = New System.Drawing.Size(729, 194)
        Me.dgvReturn.TabIndex = 24
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.WindowsApplication1.My.Resources.Resources.Back
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 33)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'btnRUpdate
        '
        Me.btnRUpdate.BackColor = System.Drawing.Color.LightGray
        Me.btnRUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRUpdate.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold)
        Me.btnRUpdate.Location = New System.Drawing.Point(49, 544)
        Me.btnRUpdate.Name = "btnRUpdate"
        Me.btnRUpdate.Size = New System.Drawing.Size(142, 40)
        Me.btnRUpdate.TabIndex = 29
        Me.btnRUpdate.Text = "Update Info"
        Me.btnRUpdate.UseVisualStyleBackColor = False
        '
        'btnRDeleteUser
        '
        Me.btnRDeleteUser.BackColor = System.Drawing.Color.LightGray
        Me.btnRDeleteUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRDeleteUser.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold)
        Me.btnRDeleteUser.Location = New System.Drawing.Point(49, 477)
        Me.btnRDeleteUser.Name = "btnRDeleteUser"
        Me.btnRDeleteUser.Size = New System.Drawing.Size(142, 41)
        Me.btnRDeleteUser.TabIndex = 28
        Me.btnRDeleteUser.Text = "Delete User"
        Me.btnRDeleteUser.UseVisualStyleBackColor = False
        '
        'btnRSearch
        '
        Me.btnRSearch.BackColor = System.Drawing.Color.LightGray
        Me.btnRSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRSearch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRSearch.Location = New System.Drawing.Point(746, 360)
        Me.btnRSearch.Name = "btnRSearch"
        Me.btnRSearch.Size = New System.Drawing.Size(84, 30)
        Me.btnRSearch.TabIndex = 27
        Me.btnRSearch.Text = "Search"
        Me.btnRSearch.UseVisualStyleBackColor = False
        '
        'txtRSearch
        '
        Me.txtRSearch.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRSearch.Location = New System.Drawing.Point(438, 363)
        Me.txtRSearch.Name = "txtRSearch"
        Me.txtRSearch.Size = New System.Drawing.Size(302, 27)
        Me.txtRSearch.TabIndex = 26
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(329, 363)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 26)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Search : "
        '
        'ManageIssueReturnForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PapayaWhip
        Me.ClientSize = New System.Drawing.Size(1006, 613)
        Me.Controls.Add(Me.btnRUpdate)
        Me.Controls.Add(Me.btnRDeleteUser)
        Me.Controls.Add(Me.btnRSearch)
        Me.Controls.Add(Me.txtRSearch)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgvReturn)
        Me.Controls.Add(Me.dgvIssue)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnIUpdate)
        Me.Controls.Add(Me.btnIDeleteuser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnISearch)
        Me.Controls.Add(Me.txtISearch)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ManageIssueReturnForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ManageIssueForm"
        CType(Me.dgvIssue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReturn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnIUpdate As System.Windows.Forms.Button
    Friend WithEvents btnIDeleteuser As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnISearch As System.Windows.Forms.Button
    Friend WithEvents txtISearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvIssue As System.Windows.Forms.DataGridView
    Friend WithEvents dgvReturn As System.Windows.Forms.DataGridView
    Friend WithEvents btnRUpdate As System.Windows.Forms.Button
    Friend WithEvents btnRDeleteUser As System.Windows.Forms.Button
    Friend WithEvents btnRSearch As System.Windows.Forms.Button
    Friend WithEvents txtRSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
