<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmItems
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmItems))
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtSearchText = New System.Windows.Forms.TextBox()
        Me.cobMatchingType = New System.Windows.Forms.ComboBox()
        Me.cobSearchType = New System.Windows.Forms.ComboBox()
        Me.txtTypeName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.TP = New System.Windows.Forms.ToolStripButton()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.trvItems = New System.Windows.Forms.TreeView()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlRight = New System.Windows.Forms.Panel()
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.pnlTop.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.pnlRight.SuspendLayout()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLeft.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnSearch.Image = Global.SGL.BaseData.My.Resources.Resources.查询2
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(427, 34)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(90, 23)
        Me.btnSearch.TabIndex = 9
        Me.btnSearch.Text = "快速查询"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtSearchText)
        Me.Panel1.Controls.Add(Me.cobMatchingType)
        Me.Panel1.Controls.Add(Me.cobSearchType)
        Me.Panel1.Controls.Add(Me.txtTypeName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(639, 62)
        Me.Panel1.TabIndex = 1
        '
        'txtSearchText
        '
        Me.txtSearchText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchText.Location = New System.Drawing.Point(270, 35)
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Size = New System.Drawing.Size(151, 21)
        Me.txtSearchText.TabIndex = 6
        '
        'cobMatchingType
        '
        Me.cobMatchingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobMatchingType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cobMatchingType.FormattingEnabled = True
        Me.cobMatchingType.Items.AddRange(New Object() {"包含", "等于"})
        Me.cobMatchingType.Location = New System.Drawing.Point(142, 36)
        Me.cobMatchingType.Name = "cobMatchingType"
        Me.cobMatchingType.Size = New System.Drawing.Size(121, 20)
        Me.cobMatchingType.TabIndex = 5
        '
        'cobSearchType
        '
        Me.cobSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobSearchType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cobSearchType.FormattingEnabled = True
        Me.cobSearchType.Location = New System.Drawing.Point(14, 36)
        Me.cobSearchType.Name = "cobSearchType"
        Me.cobSearchType.Size = New System.Drawing.Size(121, 20)
        Me.cobSearchType.TabIndex = 4
        '
        'txtTypeName
        '
        Me.txtTypeName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTypeName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTypeName.Location = New System.Drawing.Point(96, 12)
        Me.txtTypeName.Name = "txtTypeName"
        Me.txtTypeName.ReadOnly = True
        Me.txtTypeName.Size = New System.Drawing.Size(158, 14)
        Me.txtTypeName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Image = Global.SGL.BaseData.My.Resources.Resources.line1
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "查询类别"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImage = CType(resources.GetObject("ToolStrip1.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.TP})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(639, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.SystemColors.Window
        Me.ToolStripButton1.Image = Global.SGL.BaseData.My.Resources.Resources.tbtn_refresh
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripButton1.Text = "刷新"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.ForeColor = System.Drawing.SystemColors.Window
        Me.ToolStripButton2.Image = Global.SGL.BaseData.My.Resources.Resources.维护
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripButton2.Text = "维护"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.ForeColor = System.Drawing.SystemColors.Window
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripButton3.Text = "帮助"
        '
        'TP
        '
        Me.TP.ForeColor = System.Drawing.SystemColors.Window
        Me.TP.Image = Global.SGL.BaseData.My.Resources.Resources.打印预览
        Me.TP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TP.Name = "TP"
        Me.TP.Size = New System.Drawing.Size(52, 22)
        Me.TP.Text = "图片"
        '
        'pnlTop
        '
        Me.pnlTop.Controls.Add(Me.Panel1)
        Me.pnlTop.Controls.Add(Me.ToolStrip1)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(639, 87)
        Me.pnlTop.TabIndex = 4
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Splitter1.Location = New System.Drawing.Point(200, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(5, 336)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "tree_bigfolder_close.gif")
        Me.ImageList1.Images.SetKeyName(1, "tree_bigfolder_open.gif")
        Me.ImageList1.Images.SetKeyName(2, "tree_bigicon_end.gif")
        Me.ImageList1.Images.SetKeyName(3, "tree_dustbin.gif")
        Me.ImageList1.Images.SetKeyName(4, "tree_folder_close.gif")
        Me.ImageList1.Images.SetKeyName(5, "tree_folder_leaf.gif")
        Me.ImageList1.Images.SetKeyName(6, "tree_folder_open.gif")
        Me.ImageList1.Images.SetKeyName(7, "tree_inbox.gif")
        Me.ImageList1.Images.SetKeyName(8, "tree_outbox.gif")
        Me.ImageList1.Images.SetKeyName(9, "tree_position.gif")
        Me.ImageList1.Images.SetKeyName(10, "tree_positioncategory.gif")
        Me.ImageList1.Images.SetKeyName(11, "tree_sharedustbin.gif")
        Me.ImageList1.Images.SetKeyName(12, "tree_symbol_close.gif")
        Me.ImageList1.Images.SetKeyName(13, "tree_symbol_open.gif")
        Me.ImageList1.Images.SetKeyName(14, "tree_workplace.gif")
        Me.ImageList1.Images.SetKeyName(15, "tree_workflow.gif")
        Me.ImageList1.Images.SetKeyName(16, "tree_obhistory.gif")
        Me.ImageList1.Images.SetKeyName(17, "tree_job.gif")
        Me.ImageList1.Images.SetKeyName(18, "tree_jobcategory.gif")
        Me.ImageList1.Images.SetKeyName(19, "tree_businessgroup.gif")
        Me.ImageList1.Images.SetKeyName(20, "tree_broup.gif")
        Me.ImageList1.Images.SetKeyName(21, "kong.gif")
        Me.ImageList1.Images.SetKeyName(22, "tree_department.gif")
        Me.ImageList1.Images.SetKeyName(23, "tree_company.gif")
        Me.ImageList1.Images.SetKeyName(24, "cb.gif")
        '
        'trvItems
        '
        Me.trvItems.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.trvItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvItems.ImageIndex = 4
        Me.trvItems.ImageList = Me.ImageList1
        Me.trvItems.Location = New System.Drawing.Point(0, 0)
        Me.trvItems.Name = "trvItems"
        Me.trvItems.SelectedImageKey = "tree_folder_open.gif"
        Me.trvItems.Size = New System.Drawing.Size(200, 336)
        Me.trvItems.TabIndex = 0
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.pnlRight)
        Me.pnlMain.Controls.Add(Me.Splitter1)
        Me.pnlMain.Controls.Add(Me.pnlLeft)
        Me.pnlMain.Location = New System.Drawing.Point(0, 88)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(639, 336)
        Me.pnlMain.TabIndex = 5
        '
        'pnlRight
        '
        Me.pnlRight.Controls.Add(Me.C1FlexGrid1)
        Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRight.Location = New System.Drawing.Point(205, 0)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Size = New System.Drawing.Size(434, 336)
        Me.pnlRight.TabIndex = 1
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.AllowEditing = False
        Me.C1FlexGrid1.ColumnInfo = "10,1,0,0,0,0,Columns:"
        Me.C1FlexGrid1.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FlexGrid1.Location = New System.Drawing.Point(0, 0)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.Rows.DefaultSize = 18
        Me.C1FlexGrid1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FlexGrid1.Size = New System.Drawing.Size(434, 336)
        Me.C1FlexGrid1.StyleInfo = resources.GetString("C1FlexGrid1.StyleInfo")
        Me.C1FlexGrid1.TabIndex = 0
        '
        'pnlLeft
        '
        Me.pnlLeft.Controls.Add(Me.trvItems)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(200, 336)
        Me.pnlLeft.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 423)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(639, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'FrmItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 445)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.pnlMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmItems"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "核算项目"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlRight.ResumeLayout(False)
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLeft.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtSearchText As System.Windows.Forms.TextBox
    Friend WithEvents cobMatchingType As System.Windows.Forms.ComboBox
    Friend WithEvents cobSearchType As System.Windows.Forms.ComboBox
    Friend WithEvents txtTypeName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents trvItems As System.Windows.Forms.TreeView
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents pnlRight As System.Windows.Forms.Panel
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TP As System.Windows.Forms.ToolStripButton
End Class
