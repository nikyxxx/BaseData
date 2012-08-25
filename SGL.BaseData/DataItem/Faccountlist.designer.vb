<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Faccountlist
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Faccountlist))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Delete = New System.Windows.Forms.ToolStripButton()
        Me.Update = New System.Windows.Forms.ToolStripButton()
        Me.copy = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Audit = New System.Windows.Forms.ToolStripButton()
        Me.Reject = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AddRow = New System.Windows.Forms.ToolStripButton()
        Me.Review = New System.Windows.Forms.ToolStripButton()
        Me.Print = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.senddown = New System.Windows.Forms.ToolStripButton()
        Me.合并 = New System.Windows.Forms.ToolStripButton()
        Me.SendDownww = New System.Windows.Forms.ToolStripButton()
        Me.Recall = New System.Windows.Forms.ToolStripButton()
        Me.refresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolLeadInto = New System.Windows.Forms.ToolStripButton()
        Me.AdvSearch = New System.Windows.Forms.ToolStripButton()
        Me.DelRow = New System.Windows.Forms.ToolStripButton()
        Me.Format = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.Gouji = New System.Windows.Forms.ToolStripButton()
        Me.FanGouji = New System.Windows.Forms.ToolStripButton()
        Me.拆单 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.Out = New System.Windows.Forms.ToolStripButton()
        Me.FItemClassID = New C1.Win.C1List.C1Combo()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.C1FlexGrid = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.FItemClassID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.C1FlexGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CheckBox1.Location = New System.Drawing.Point(394, 8)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(94, 16)
        Me.CheckBox1.TabIndex = 360
        Me.CheckBox1.Text = "展开所有明细"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.Delete, Me.Update, Me.copy, Me.ToolStripSeparator3, Me.Audit, Me.Reject, Me.ToolStripSeparator1, Me.AddRow, Me.Review, Me.Print, Me.ToolStripSeparator2, Me.senddown, Me.合并, Me.SendDownww, Me.Recall, Me.refresh, Me.ToolStripSeparator4, Me.ToExcel, Me.ToolLeadInto, Me.AdvSearch, Me.DelRow, Me.Format, Me.ToolStripSeparator5, Me.Gouji, Me.FanGouji, Me.拆单, Me.ToolStripSeparator6, Me.Out})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(960, 35)
        Me.ToolStrip1.TabIndex = 361
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ToolStripButton1.Image = Global.SGL.BaseData.My.Resources.Resources.新增
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(33, 32)
        Me.ToolStripButton1.Text = "新增"
        Me.ToolStripButton1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Delete
        '
        Me.Delete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Delete.Image = Global.SGL.BaseData.My.Resources.Resources.删除
        Me.Delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(33, 32)
        Me.Delete.Text = "删除"
        Me.Delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Update
        '
        Me.Update.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Update.Image = Global.SGL.BaseData.My.Resources.Resources.修改
        Me.Update.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Update.Name = "Update"
        Me.Update.Size = New System.Drawing.Size(33, 32)
        Me.Update.Text = "修改"
        Me.Update.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'copy
        '
        Me.copy.ForeColor = System.Drawing.SystemColors.ControlText
        Me.copy.Image = CType(resources.GetObject("copy.Image"), System.Drawing.Image)
        Me.copy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.copy.Name = "copy"
        Me.copy.Size = New System.Drawing.Size(33, 32)
        Me.copy.Text = "复制"
        Me.copy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 35)
        '
        'Audit
        '
        Me.Audit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Audit.Image = Global.SGL.BaseData.My.Resources.Resources.审核
        Me.Audit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Audit.Name = "Audit"
        Me.Audit.Size = New System.Drawing.Size(33, 32)
        Me.Audit.Text = "审批"
        Me.Audit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Reject
        '
        Me.Reject.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Reject.Image = Global.SGL.BaseData.My.Resources.Resources.驳回
        Me.Reject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Reject.Name = "Reject"
        Me.Reject.Size = New System.Drawing.Size(33, 32)
        Me.Reject.Text = "驳回"
        Me.Reject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 35)
        '
        'AddRow
        '
        Me.AddRow.Image = Global.SGL.BaseData.My.Resources.Resources.打印设置
        Me.AddRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddRow.Name = "AddRow"
        Me.AddRow.Size = New System.Drawing.Size(33, 32)
        Me.AddRow.Text = "设置"
        Me.AddRow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Review
        '
        Me.Review.Image = Global.SGL.BaseData.My.Resources.Resources.打印预览
        Me.Review.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Review.Name = "Review"
        Me.Review.Size = New System.Drawing.Size(33, 32)
        Me.Review.Text = "预览"
        Me.Review.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Print
        '
        Me.Print.Image = Global.SGL.BaseData.My.Resources.Resources.打印
        Me.Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Print.Name = "Print"
        Me.Print.Size = New System.Drawing.Size(33, 32)
        Me.Print.Text = "打印"
        Me.Print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 35)
        '
        'senddown
        '
        Me.senddown.Image = Global.SGL.BaseData.My.Resources.Resources.批量修改
        Me.senddown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.senddown.Name = "senddown"
        Me.senddown.Size = New System.Drawing.Size(33, 32)
        Me.senddown.Text = "批改"
        Me.senddown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        '合并
        '
        Me.合并.Image = Global.SGL.BaseData.My.Resources.Resources.库存盘点
        Me.合并.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.合并.Name = "合并"
        Me.合并.Size = New System.Drawing.Size(33, 32)
        Me.合并.Text = "检测"
        Me.合并.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'SendDownww
        '
        Me.SendDownww.Image = Global.SGL.BaseData.My.Resources.Resources.禁用
        Me.SendDownww.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SendDownww.Name = "SendDownww"
        Me.SendDownww.Size = New System.Drawing.Size(33, 32)
        Me.SendDownww.Text = "禁用"
        Me.SendDownww.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Recall
        '
        Me.Recall.Image = Global.SGL.BaseData.My.Resources.Resources.启用
        Me.Recall.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Recall.Name = "Recall"
        Me.Recall.Size = New System.Drawing.Size(33, 32)
        Me.Recall.Text = "启用"
        Me.Recall.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'refresh
        '
        Me.refresh.Image = Global.SGL.BaseData.My.Resources.Resources.tbtn_refresh
        Me.refresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.refresh.Name = "refresh"
        Me.refresh.Size = New System.Drawing.Size(33, 32)
        Me.refresh.Text = "刷新"
        Me.refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 35)
        '
        'ToExcel
        '
        Me.ToExcel.Image = Global.SGL.BaseData.My.Resources.Resources.导出excel
        Me.ToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(33, 32)
        Me.ToExcel.Text = "导出"
        Me.ToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolLeadInto
        '
        Me.ToolLeadInto.Image = CType(resources.GetObject("ToolLeadInto.Image"), System.Drawing.Image)
        Me.ToolLeadInto.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolLeadInto.Name = "ToolLeadInto"
        Me.ToolLeadInto.Size = New System.Drawing.Size(33, 32)
        Me.ToolLeadInto.Text = "导入"
        Me.ToolLeadInto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'AdvSearch
        '
        Me.AdvSearch.Image = CType(resources.GetObject("AdvSearch.Image"), System.Drawing.Image)
        Me.AdvSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AdvSearch.Name = "AdvSearch"
        Me.AdvSearch.Size = New System.Drawing.Size(33, 32)
        Me.AdvSearch.Text = "查找"
        Me.AdvSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'DelRow
        '
        Me.DelRow.Image = CType(resources.GetObject("DelRow.Image"), System.Drawing.Image)
        Me.DelRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DelRow.Name = "DelRow"
        Me.DelRow.Size = New System.Drawing.Size(33, 32)
        Me.DelRow.Text = "选项"
        Me.DelRow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Format
        '
        Me.Format.Image = Global.SGL.BaseData.My.Resources.Resources.格式
        Me.Format.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Format.Name = "Format"
        Me.Format.Size = New System.Drawing.Size(33, 32)
        Me.Format.Text = "格式"
        Me.Format.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 35)
        '
        'Gouji
        '
        Me.Gouji.Image = Global.SGL.BaseData.My.Resources.Resources.图片
        Me.Gouji.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Gouji.Name = "Gouji"
        Me.Gouji.Size = New System.Drawing.Size(33, 32)
        Me.Gouji.Text = "图片"
        Me.Gouji.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'FanGouji
        '
        Me.FanGouji.Image = CType(resources.GetObject("FanGouji.Image"), System.Drawing.Image)
        Me.FanGouji.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FanGouji.Name = "FanGouji"
        Me.FanGouji.Size = New System.Drawing.Size(33, 32)
        Me.FanGouji.Text = "附件"
        Me.FanGouji.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        '拆单
        '
        Me.拆单.Image = CType(resources.GetObject("拆单.Image"), System.Drawing.Image)
        Me.拆单.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.拆单.Name = "拆单"
        Me.拆单.Size = New System.Drawing.Size(33, 32)
        Me.拆单.Text = "条码"
        Me.拆单.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 35)
        '
        'Out
        '
        Me.Out.Image = Global.SGL.BaseData.My.Resources.Resources.退出
        Me.Out.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Out.Name = "Out"
        Me.Out.Size = New System.Drawing.Size(33, 32)
        Me.Out.Text = "退出"
        Me.Out.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'FItemClassID
        '
        Me.FItemClassID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.FItemClassID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FItemClassID.Caption = ""
        Me.FItemClassID.CaptionHeight = 17
        Me.FItemClassID.CaptionStyle = Style1
        Me.FItemClassID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.FItemClassID.ColumnCaptionHeight = 18
        Me.FItemClassID.ColumnFooterHeight = 18
        Me.FItemClassID.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.FItemClassID.ContentHeight = 16
        Me.FItemClassID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.FItemClassID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.FItemClassID.EditorFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FItemClassID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.FItemClassID.EditorHeight = 16
        Me.FItemClassID.EvenRowStyle = Style2
        Me.FItemClassID.FooterStyle = Style3
        Me.FItemClassID.HeadingStyle = Style4
        Me.FItemClassID.HighLightRowStyle = Style5
        Me.FItemClassID.Images.Add(CType(resources.GetObject("FItemClassID.Images"), System.Drawing.Image))
        Me.FItemClassID.ItemHeight = 15
        Me.FItemClassID.Location = New System.Drawing.Point(102, 10)
        Me.FItemClassID.MatchEntryTimeout = CType(2000, Long)
        Me.FItemClassID.MaxDropDownItems = CType(30, Short)
        Me.FItemClassID.MaxLength = 32767
        Me.FItemClassID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.FItemClassID.Name = "FItemClassID"
        Me.FItemClassID.OddRowStyle = Style6
        Me.FItemClassID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.FItemClassID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.FItemClassID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.FItemClassID.SelectedStyle = Style7
        Me.FItemClassID.Size = New System.Drawing.Size(141, 16)
        Me.FItemClassID.Style = Style8
        Me.FItemClassID.TabIndex = 366
        Me.FItemClassID.Text = "企业会计科目"
        Me.FItemClassID.PropBag = resources.GetString("FItemClassID.PropBag")
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 540)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(960, 22)
        Me.StatusStrip1.TabIndex = 367
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(200, 17)
        Me.ToolStripStatusLabel1.Text = "科目管理"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.AutoSize = False
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(250, 17)
        '
        'Label8
        '
        Me.Label8.Image = CType(resources.GetObject("Label8.Image"), System.Drawing.Image)
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label8.Location = New System.Drawing.Point(249, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 23)
        Me.Label8.TabIndex = 365
        Me.Label8.Text = "科目内容"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Image = Global.SGL.BaseData.My.Resources.Resources.line1
        Me.Label1.Location = New System.Drawing.Point(10, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 16)
        Me.Label1.TabIndex = 363
        Me.Label1.Text = "会计科目表"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(772, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(5, 12)
        Me.Label2.TabIndex = 368
        Me.Label2.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.FItemClassID)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(960, 35)
        Me.Panel1.TabIndex = 371
        '
        'TreeView1
        '
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeView1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.LineColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TreeView1.Location = New System.Drawing.Point(0, 70)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(254, 470)
        Me.TreeView1.TabIndex = 372
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Splitter1.Location = New System.Drawing.Point(254, 70)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(10, 470)
        Me.Splitter1.TabIndex = 373
        Me.Splitter1.TabStop = False
        '
        'C1FlexGrid
        '
        Me.C1FlexGrid.AllowEditing = False
        Me.C1FlexGrid.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.C1FlexGrid.ColumnInfo = resources.GetString("C1FlexGrid.ColumnInfo")
        Me.C1FlexGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FlexGrid.Location = New System.Drawing.Point(264, 70)
        Me.C1FlexGrid.Name = "C1FlexGrid"
        Me.C1FlexGrid.Rows.DefaultSize = 18
        Me.C1FlexGrid.Size = New System.Drawing.Size(696, 470)
        Me.C1FlexGrid.StyleInfo = resources.GetString("C1FlexGrid.StyleInfo")
        Me.C1FlexGrid.TabIndex = 374
        '
        'Faccountlist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(960, 562)
        Me.Controls.Add(Me.C1FlexGrid)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Faccountlist"
        Me.Text = "科目管理"
        Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
        Me.Controls.SetChildIndex(Me.StatusStrip1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.TreeView1, 0)
        Me.Controls.SetChildIndex(Me.Splitter1, 0)
        Me.Controls.SetChildIndex(Me.C1FlexGrid, 0)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.FItemClassID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.C1FlexGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Update As System.Windows.Forms.ToolStripButton
    Friend WithEvents Delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents AddRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents DelRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Audit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Reject As System.Windows.Forms.ToolStripButton
    Friend WithEvents copy As System.Windows.Forms.ToolStripButton
    Friend WithEvents Review As System.Windows.Forms.ToolStripButton
    Friend WithEvents Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents refresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents senddown As System.Windows.Forms.ToolStripButton
    Friend WithEvents 合并 As System.Windows.Forms.ToolStripButton
    Friend WithEvents SendDownww As System.Windows.Forms.ToolStripButton
    Friend WithEvents Recall As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents AdvSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents Format As System.Windows.Forms.ToolStripButton
    Friend WithEvents Gouji As System.Windows.Forms.ToolStripButton
    Friend WithEvents FanGouji As System.Windows.Forms.ToolStripButton
    Friend WithEvents 拆单 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Out As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolLeadInto As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents FItemClassID As C1.Win.C1List.C1Combo
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents C1FlexGrid As C1.Win.C1FlexGrid.C1FlexGrid
End Class
