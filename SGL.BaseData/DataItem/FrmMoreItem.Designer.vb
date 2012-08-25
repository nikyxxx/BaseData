<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMoreItem
    Inherits PublicSharedResource.frmBase

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMoreItem))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearchText = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.TP = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Button1.Location = New System.Drawing.Point(557, 37)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(54, 23)
        Me.Button1.TabIndex = 838
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 465)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(683, 22)
        Me.StatusStrip1.TabIndex = 837
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(0, 68)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(639, 356)
        Me.CheckedListBox1.TabIndex = 836
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnSearch.Image = Global.SGL.BaseData.My.Resources.Resources.查询2
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(175, 38)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(90, 23)
        Me.btnSearch.TabIndex = 835
        Me.btnSearch.Text = "快速查询"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtSearchText
        '
        Me.txtSearchText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchText.Location = New System.Drawing.Point(18, 39)
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Size = New System.Drawing.Size(151, 21)
        Me.txtSearchText.TabIndex = 834
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImage = CType(resources.GetObject("ToolStrip1.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.TP})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(683, 25)
        Me.ToolStrip1.TabIndex = 833
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.SystemColors.Window
        Me.ToolStripButton1.Image = Global.SGL.BaseData.My.Resources.Resources.tbtn_refresh
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(49, 22)
        Me.ToolStripButton1.Text = "刷新"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.ForeColor = System.Drawing.SystemColors.Window
        Me.ToolStripButton2.Image = Global.SGL.BaseData.My.Resources.Resources.维护
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(49, 22)
        Me.ToolStripButton2.Text = "维护"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.ForeColor = System.Drawing.SystemColors.Window
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(49, 22)
        Me.ToolStripButton3.Text = "帮助"
        '
        'TP
        '
        Me.TP.ForeColor = System.Drawing.SystemColors.Window
        Me.TP.Image = Global.SGL.BaseData.My.Resources.Resources.打印预览
        Me.TP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TP.Name = "TP"
        Me.TP.Size = New System.Drawing.Size(49, 22)
        Me.TP.Text = "图片"
        '
        'FrmMoreItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 446)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearchText)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmMoreItem"
        Me.Text = "多核算项目"
        Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
        Me.Controls.SetChildIndex(Me.txtSearchText, 0)
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.CheckedListBox1, 0)
        Me.Controls.SetChildIndex(Me.StatusStrip1, 0)
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearchText As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TP As System.Windows.Forms.ToolStripButton
End Class
