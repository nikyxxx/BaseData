<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLeadInto
    Inherits PublicSharedResource.frmBase

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLeadInto))
        Me.FTypeName = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextFile = New System.Windows.Forms.TextBox
        Me.ButFile = New System.Windows.Forms.Button
        Me.ButOK = New System.Windows.Forms.Button
        Me.ButChane = New System.Windows.Forms.Button
        Me.ButAccount = New System.Windows.Forms.Button
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.SuspendLayout()
        '
        'FTypeName
        '
        Me.FTypeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FTypeName.FormattingEnabled = True
        Me.FTypeName.Location = New System.Drawing.Point(107, 14)
        Me.FTypeName.Name = "FTypeName"
        Me.FTypeName.Size = New System.Drawing.Size(272, 20)
        Me.FTypeName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "科目导入方式："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "数据来源目录："
        '
        'TextFile
        '
        Me.TextFile.Location = New System.Drawing.Point(107, 49)
        Me.TextFile.Name = "TextFile"
        Me.TextFile.Size = New System.Drawing.Size(253, 21)
        Me.TextFile.TabIndex = 3
        '
        'ButFile
        '
        Me.ButFile.Image = Global.SGL.BaseData.My.Resources.Resources.打开
        Me.ButFile.Location = New System.Drawing.Point(358, 49)
        Me.ButFile.Name = "ButFile"
        Me.ButFile.Size = New System.Drawing.Size(18, 22)
        Me.ButFile.TabIndex = 4
        Me.ButFile.UseVisualStyleBackColor = True
        '
        'ButOK
        '
        Me.ButOK.Location = New System.Drawing.Point(290, 90)
        Me.ButOK.Name = "ButOK"
        Me.ButOK.Size = New System.Drawing.Size(70, 22)
        Me.ButOK.TabIndex = 5
        Me.ButOK.Text = "确定"
        Me.ButOK.UseVisualStyleBackColor = True
        '
        'ButChane
        '
        Me.ButChane.Location = New System.Drawing.Point(188, 90)
        Me.ButChane.Name = "ButChane"
        Me.ButChane.Size = New System.Drawing.Size(70, 22)
        Me.ButChane.TabIndex = 6
        Me.ButChane.Text = "取消"
        Me.ButChane.UseVisualStyleBackColor = True
        '
        'ButAccount
        '
        Me.ButAccount.Location = New System.Drawing.Point(14, 90)
        Me.ButAccount.Name = "ButAccount"
        Me.ButAccount.Size = New System.Drawing.Size(70, 22)
        Me.ButAccount.TabIndex = 7
        Me.ButAccount.Text = "科目明细"
        Me.ButAccount.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(2, 118)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(374, 251)
        Me.TreeView1.TabIndex = 8
        '
        'FrmLeadInto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 369)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.ButAccount)
        Me.Controls.Add(Me.ButChane)
        Me.Controls.Add(Me.ButOK)
        Me.Controls.Add(Me.ButFile)
        Me.Controls.Add(Me.TextFile)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FTypeName)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmLeadInto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "导入科目"
        Me.Controls.SetChildIndex(Me.FTypeName, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TextFile, 0)
        Me.Controls.SetChildIndex(Me.ButFile, 0)
        Me.Controls.SetChildIndex(Me.ButOK, 0)
        Me.Controls.SetChildIndex(Me.ButChane, 0)
        Me.Controls.SetChildIndex(Me.ButAccount, 0)
        Me.Controls.SetChildIndex(Me.TreeView1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FTypeName As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextFile As System.Windows.Forms.TextBox
    Friend WithEvents ButFile As System.Windows.Forms.Button
    Friend WithEvents ButOK As System.Windows.Forms.Button
    Friend WithEvents ButChane As System.Windows.Forms.Button
    Friend WithEvents ButAccount As System.Windows.Forms.Button
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
End Class
