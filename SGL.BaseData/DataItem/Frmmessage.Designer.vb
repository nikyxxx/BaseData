<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmmessage
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frmmessage))
        Me.cobMatchingType = New System.Windows.Forms.ComboBox()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearchText = New System.Windows.Forms.TextBox()
        Me.cobSearchType = New System.Windows.Forms.ComboBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.pnlTop.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'cobMatchingType
        '
        Me.cobMatchingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobMatchingType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cobMatchingType.FormattingEnabled = True
        Me.cobMatchingType.Items.AddRange(New Object() {"包含", "等于", "左匹配", "右匹配"})
        Me.cobMatchingType.Location = New System.Drawing.Point(132, 29)
        Me.cobMatchingType.Name = "cobMatchingType"
        Me.cobMatchingType.Size = New System.Drawing.Size(121, 20)
        Me.cobMatchingType.TabIndex = 13
        '
        'pnlTop
        '
        Me.pnlTop.Controls.Add(Me.btnSearch)
        Me.pnlTop.Controls.Add(Me.cobMatchingType)
        Me.pnlTop.Controls.Add(Me.txtSearchText)
        Me.pnlTop.Controls.Add(Me.cobSearchType)
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(540, 55)
        Me.pnlTop.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnSearch.Image = Global.SGL.BaseData.My.Resources.Resources.查询2
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(426, 26)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(90, 23)
        Me.btnSearch.TabIndex = 14
        Me.btnSearch.Text = "快速查询"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtSearchText
        '
        Me.txtSearchText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchText.Location = New System.Drawing.Point(259, 29)
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Size = New System.Drawing.Size(151, 21)
        Me.txtSearchText.TabIndex = 11
        '
        'cobSearchType
        '
        Me.cobSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobSearchType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cobSearchType.FormattingEnabled = True
        Me.cobSearchType.Items.AddRange(New Object() {"辅助资料代码", "辅助资料名称"})
        Me.cobSearchType.Location = New System.Drawing.Point(5, 29)
        Me.cobSearchType.Name = "cobSearchType"
        Me.cobSearchType.Size = New System.Drawing.Size(121, 20)
        Me.cobSearchType.TabIndex = 10
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(3, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(53, 12)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "辅助资料"
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.C1FlexGrid1)
        Me.pnlBottom.Location = New System.Drawing.Point(0, 55)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(540, 322)
        Me.pnlBottom.TabIndex = 1
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.AllowEditing = False
        Me.C1FlexGrid1.ColumnInfo = "10,1,0,0,0,0,Columns:"
        Me.C1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FlexGrid1.Location = New System.Drawing.Point(0, 0)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.Rows.DefaultSize = 18
        Me.C1FlexGrid1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FlexGrid1.Size = New System.Drawing.Size(540, 322)
        Me.C1FlexGrid1.TabIndex = 1
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.StatusStrip1)
        Me.pnlMain.Controls.Add(Me.pnlBottom)
        Me.pnlMain.Controls.Add(Me.pnlTop)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(540, 402)
        Me.pnlMain.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 380)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(540, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Frmmessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 402)
        Me.Controls.Add(Me.pnlMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frmmessage"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "辅助资料"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cobMatchingType As System.Windows.Forms.ComboBox
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents txtSearchText As System.Windows.Forms.TextBox
    Friend WithEvents cobSearchType As System.Windows.Forms.ComboBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip

End Class
