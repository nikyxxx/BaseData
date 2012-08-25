<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelectBillBase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelectBillBase))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.C1Command2 = New C1.Win.C1Command.C1Command()
        Me.C1CommandHolder1 = New C1.Win.C1Command.C1CommandHolder()
        Me.C1Command3 = New C1.Win.C1Command.C1Command()
        Me.C1Command1 = New C1.Win.C1Command.C1Command()
        Me.FDate2 = New C1.Win.C1Input.C1DateEdit()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FWayname = New C1.Win.C1Input.C1TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Save = New System.Windows.Forms.ToolStripButton()
        Me.cobCheckType = New System.Windows.Forms.ComboBox()
        Me.delect = New System.Windows.Forms.ToolStripButton()
        Me.Clearall = New System.Windows.Forms.ToolStripButton()
        Me.list = New System.Windows.Forms.ToolStripButton()
        Me.FInterID = New C1.Win.C1Input.C1TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.delRow = New System.Windows.Forms.ToolStripButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FBillerID = New C1.Win.C1Input.C1TextBox()
        Me.LFdate = New System.Windows.Forms.Label()
        Me.Fchannle = New System.Windows.Forms.ComboBox()
        Me.FCheckID = New System.Windows.Forms.ComboBox()
        Me.条件 = New System.Windows.Forms.TabPage()
        Me.FRob = New System.Windows.Forms.ComboBox()
        Me.Fdate = New System.Windows.Forms.ComboBox()
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.排序 = New System.Windows.Forms.TabPage()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.C1FlexGrid3 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FlexGrid2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.格式 = New System.Windows.Forms.TabPage()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.C1FlexGrid4 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Ftrantype = New C1.Win.C1Input.C1TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BgW = New System.ComponentModel.BackgroundWorker()
        Me.ButOK = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ListView = New C1.Win.C1FlexGrid.C1FlexGrid()
        CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FWayname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FInterID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.FBillerID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.条件.SuspendLayout()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.排序.SuspendLayout()
        CType(Me.C1FlexGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.格式.SuspendLayout()
        CType(Me.C1FlexGrid4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ftrantype, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 200
        Me.Label1.Text = "方案"
        '
        'C1Command2
        '
        Me.C1Command2.Name = "C1Command2"
        Me.C1Command2.Text = "New Command"
        '
        'C1CommandHolder1
        '
        Me.C1CommandHolder1.Commands.Add(Me.C1Command2)
        Me.C1CommandHolder1.Commands.Add(Me.C1Command3)
        Me.C1CommandHolder1.Commands.Add(Me.C1Command1)
        Me.C1CommandHolder1.Owner = Me
        '
        'C1Command3
        '
        Me.C1Command3.Name = "C1Command3"
        Me.C1Command3.Text = "New Command"
        '
        'C1Command1
        '
        Me.C1Command1.Name = "C1Command1"
        Me.C1Command1.Text = "保存"
        '
        'FDate2
        '
        Me.FDate2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FDate2.Location = New System.Drawing.Point(221, 8)
        Me.FDate2.Name = "FDate2"
        Me.FDate2.Size = New System.Drawing.Size(145, 16)
        Me.FDate2.TabIndex = 199
        Me.FDate2.Tag = "datetime"
        Me.FDate2.Visible = False
        Me.FDate2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'FWayname
        '
        Me.FWayname.AccessibleDescription = "text"
        Me.FWayname.Location = New System.Drawing.Point(400, 5)
        Me.FWayname.Name = "FWayname"
        Me.FWayname.Size = New System.Drawing.Size(84, 21)
        Me.FWayname.TabIndex = 198
        Me.FWayname.Tag = "string"
        Me.FWayname.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(221, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 19)
        Me.Label5.TabIndex = 202
        Me.Label5.Text = "事务类型"
        '
        'Save
        '
        Me.Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Save.Image = Global.SGL.BaseData.My.Resources.Resources.保存
        Me.Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(23, 22)
        Me.Save.Text = "保存"
        Me.Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cobCheckType
        '
        Me.cobCheckType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobCheckType.FormattingEnabled = True
        Me.cobCheckType.Items.AddRange(New Object() {"未审核", "审核未确认", "已确认", "已推普通单", "全部"})
        Me.cobCheckType.Location = New System.Drawing.Point(282, 37)
        Me.cobCheckType.Name = "cobCheckType"
        Me.cobCheckType.Size = New System.Drawing.Size(170, 20)
        Me.cobCheckType.TabIndex = 201
        '
        'delect
        '
        Me.delect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.delect.Image = Global.SGL.BaseData.My.Resources.Resources.删除
        Me.delect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.delect.Name = "delect"
        Me.delect.Size = New System.Drawing.Size(23, 22)
        Me.delect.Text = "删除"
        Me.delect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Clearall
        '
        Me.Clearall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Clearall.Image = Global.SGL.BaseData.My.Resources.Resources.新增
        Me.Clearall.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Clearall.Name = "Clearall"
        Me.Clearall.Size = New System.Drawing.Size(23, 22)
        Me.Clearall.Text = "清空"
        '
        'list
        '
        Me.list.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.list.Image = Global.SGL.BaseData.My.Resources.Resources.拆单
        Me.list.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.list.Name = "list"
        Me.list.Size = New System.Drawing.Size(23, 22)
        Me.list.Text = "列表"
        '
        'FInterID
        '
        Me.FInterID.AccessibleDescription = "text"
        Me.FInterID.Location = New System.Drawing.Point(497, 5)
        Me.FInterID.Name = "FInterID"
        Me.FInterID.Size = New System.Drawing.Size(84, 21)
        Me.FInterID.TabIndex = 197
        Me.FInterID.Tag = "int"
        Me.FInterID.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Save, Me.ToolStripSeparator1, Me.delect, Me.Clearall, Me.list, Me.delRow})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(7, 35)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(205, 25)
        Me.ToolStrip1.TabIndex = 196
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'delRow
        '
        Me.delRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.delRow.Image = Global.SGL.BaseData.My.Resources.Resources.删行
        Me.delRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.delRow.Name = "delRow"
        Me.delRow.Size = New System.Drawing.Size(23, 22)
        Me.delRow.Text = "删行"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "blue_BILL.gif")
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(21, 240)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 14)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "红字标志"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(219, 238)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "记帐标志"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(219, 211)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 14)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "审核标志"
        '
        'FBillerID
        '
        Me.FBillerID.AccessibleDescription = ""
        Me.FBillerID.Location = New System.Drawing.Point(125, 5)
        Me.FBillerID.Name = "FBillerID"
        Me.FBillerID.Size = New System.Drawing.Size(84, 21)
        Me.FBillerID.TabIndex = 195
        Me.FBillerID.Tag = "int"
        Me.FBillerID.Visible = False
        '
        'LFdate
        '
        Me.LFdate.Location = New System.Drawing.Point(21, 213)
        Me.LFdate.Name = "LFdate"
        Me.LFdate.Size = New System.Drawing.Size(70, 14)
        Me.LFdate.TabIndex = 19
        Me.LFdate.Text = "单据期间"
        '
        'Fchannle
        '
        Me.Fchannle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Fchannle.FormattingEnabled = True
        Me.Fchannle.Items.AddRange(New Object() {"全部", "记帐", "未记帐"})
        Me.Fchannle.Location = New System.Drawing.Point(290, 231)
        Me.Fchannle.Name = "Fchannle"
        Me.Fchannle.Size = New System.Drawing.Size(96, 20)
        Me.Fchannle.TabIndex = 18
        Me.Fchannle.Tag = "string"
        Me.Fchannle.Text = "全部"
        '
        'FCheckID
        '
        Me.FCheckID.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.FCheckID.FormattingEnabled = True
        Me.FCheckID.Items.AddRange(New Object() {"全部", "审核", "未审核"})
        Me.FCheckID.Location = New System.Drawing.Point(290, 204)
        Me.FCheckID.Name = "FCheckID"
        Me.FCheckID.Size = New System.Drawing.Size(96, 20)
        Me.FCheckID.TabIndex = 17
        Me.FCheckID.Tag = "string"
        Me.FCheckID.Text = "审核"
        '
        '条件
        '
        Me.条件.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.条件.Controls.Add(Me.Label3)
        Me.条件.Controls.Add(Me.Label4)
        Me.条件.Controls.Add(Me.Label2)
        Me.条件.Controls.Add(Me.LFdate)
        Me.条件.Controls.Add(Me.Fchannle)
        Me.条件.Controls.Add(Me.FCheckID)
        Me.条件.Controls.Add(Me.FRob)
        Me.条件.Controls.Add(Me.Fdate)
        Me.条件.Controls.Add(Me.C1FlexGrid1)
        Me.条件.Location = New System.Drawing.Point(4, 21)
        Me.条件.Name = "条件"
        Me.条件.Padding = New System.Windows.Forms.Padding(3)
        Me.条件.Size = New System.Drawing.Size(406, 258)
        Me.条件.TabIndex = 0
        Me.条件.Text = "条件"
        '
        'FRob
        '
        Me.FRob.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.FRob.FormattingEnabled = True
        Me.FRob.Items.AddRange(New Object() {"全部", "蓝字", "红字"})
        Me.FRob.Location = New System.Drawing.Point(91, 233)
        Me.FRob.Name = "FRob"
        Me.FRob.Size = New System.Drawing.Size(96, 20)
        Me.FRob.TabIndex = 16
        Me.FRob.Tag = "string"
        Me.FRob.Text = "全部"
        '
        'Fdate
        '
        Me.Fdate.AccessibleDescription = ""
        Me.Fdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Fdate.FormattingEnabled = True
        Me.Fdate.Items.AddRange(New Object() {"本期", "上期", "今天", "昨天", "全部"})
        Me.Fdate.Location = New System.Drawing.Point(91, 205)
        Me.Fdate.Name = "Fdate"
        Me.Fdate.Size = New System.Drawing.Size(96, 20)
        Me.Fdate.TabIndex = 15
        Me.Fdate.Tag = "string"
        Me.Fdate.Text = "本期"
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FlexGrid1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.C1FlexGrid1.ColumnInfo = resources.GetString("C1FlexGrid1.ColumnInfo")
        Me.C1FlexGrid1.Location = New System.Drawing.Point(5, 6)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.Rows.DefaultSize = 18
        Me.C1FlexGrid1.Size = New System.Drawing.Size(398, 187)
        Me.C1FlexGrid1.StyleInfo = resources.GetString("C1FlexGrid1.StyleInfo")
        Me.C1FlexGrid1.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.条件)
        Me.TabControl1.Controls.Add(Me.排序)
        Me.TabControl1.Controls.Add(Me.格式)
        Me.TabControl1.Location = New System.Drawing.Point(218, 63)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(414, 283)
        Me.TabControl1.TabIndex = 191
        '
        '排序
        '
        Me.排序.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.排序.Controls.Add(Me.Button5)
        Me.排序.Controls.Add(Me.Button4)
        Me.排序.Controls.Add(Me.Button3)
        Me.排序.Controls.Add(Me.C1FlexGrid3)
        Me.排序.Controls.Add(Me.C1FlexGrid2)
        Me.排序.Location = New System.Drawing.Point(4, 21)
        Me.排序.Name = "排序"
        Me.排序.Padding = New System.Windows.Forms.Padding(3)
        Me.排序.Size = New System.Drawing.Size(406, 258)
        Me.排序.TabIndex = 1
        Me.排序.Text = "排序"
        Me.排序.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(321, 231)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(68, 24)
        Me.Button5.TabIndex = 194
        Me.Button5.Text = "删除"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(321, 157)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(68, 24)
        Me.Button4.TabIndex = 193
        Me.Button4.Text = "下移"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(322, 127)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(68, 24)
        Me.Button3.TabIndex = 192
        Me.Button3.Text = "上移"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'C1FlexGrid3
        '
        Me.C1FlexGrid3.ColumnInfo = resources.GetString("C1FlexGrid3.ColumnInfo")
        Me.C1FlexGrid3.Location = New System.Drawing.Point(0, 127)
        Me.C1FlexGrid3.Name = "C1FlexGrid3"
        Me.C1FlexGrid3.Rows.DefaultSize = 18
        Me.C1FlexGrid3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.C1FlexGrid3.Size = New System.Drawing.Size(315, 130)
        Me.C1FlexGrid3.StyleInfo = resources.GetString("C1FlexGrid3.StyleInfo")
        Me.C1FlexGrid3.TabIndex = 1
        '
        'C1FlexGrid2
        '
        Me.C1FlexGrid2.ColumnInfo = "10,1,0,0,0,0,Columns:"
        Me.C1FlexGrid2.Location = New System.Drawing.Point(-1, 3)
        Me.C1FlexGrid2.Name = "C1FlexGrid2"
        Me.C1FlexGrid2.Rows.DefaultSize = 18
        Me.C1FlexGrid2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.C1FlexGrid2.Size = New System.Drawing.Size(317, 125)
        Me.C1FlexGrid2.StyleInfo = resources.GetString("C1FlexGrid2.StyleInfo")
        Me.C1FlexGrid2.TabIndex = 0
        '
        '格式
        '
        Me.格式.Controls.Add(Me.Button10)
        Me.格式.Controls.Add(Me.Button9)
        Me.格式.Controls.Add(Me.Button8)
        Me.格式.Controls.Add(Me.Button7)
        Me.格式.Controls.Add(Me.Button6)
        Me.格式.Controls.Add(Me.Button2)
        Me.格式.Controls.Add(Me.C1FlexGrid4)
        Me.格式.Location = New System.Drawing.Point(4, 21)
        Me.格式.Name = "格式"
        Me.格式.Size = New System.Drawing.Size(406, 258)
        Me.格式.TabIndex = 2
        Me.格式.Text = "格式"
        Me.格式.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(322, 174)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 23)
        Me.Button10.TabIndex = 8
        Me.Button10.Text = "保存格式"
        Me.Button10.UseVisualStyleBackColor = True
        Me.Button10.Visible = False
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(322, 145)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 7
        Me.Button9.Text = "默认值"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(322, 114)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 6
        Me.Button8.Text = "全清"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(322, 88)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 5
        Me.Button7.Text = "全选"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(322, 56)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 4
        Me.Button6.Text = "下移"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(322, 30)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "上移"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'C1FlexGrid4
        '
        Me.C1FlexGrid4.ColumnInfo = resources.GetString("C1FlexGrid4.ColumnInfo")
        Me.C1FlexGrid4.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1FlexGrid4.Dock = System.Windows.Forms.DockStyle.Left
        Me.C1FlexGrid4.Location = New System.Drawing.Point(0, 0)
        Me.C1FlexGrid4.Name = "C1FlexGrid4"
        Me.C1FlexGrid4.Rows.DefaultSize = 18
        Me.C1FlexGrid4.Size = New System.Drawing.Size(316, 258)
        Me.C1FlexGrid4.StyleInfo = resources.GetString("C1FlexGrid4.StyleInfo")
        Me.C1FlexGrid4.TabIndex = 2
        '
        'Ftrantype
        '
        Me.Ftrantype.Location = New System.Drawing.Point(258, 163)
        Me.Ftrantype.Name = "Ftrantype"
        Me.Ftrantype.Size = New System.Drawing.Size(84, 21)
        Me.Ftrantype.TabIndex = 194
        Me.Ftrantype.Tag = "int"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Location = New System.Drawing.Point(3, 352)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(629, 3)
        Me.GroupBox1.TabIndex = 192
        Me.GroupBox1.TabStop = False
        '
        'BgW
        '
        Me.BgW.WorkerReportsProgress = True
        Me.BgW.WorkerSupportsCancellation = True
        '
        'ButOK
        '
        Me.ButOK.Image = CType(resources.GetObject("ButOK.Image"), System.Drawing.Image)
        Me.ButOK.Location = New System.Drawing.Point(482, 364)
        Me.ButOK.Name = "ButOK"
        Me.ButOK.Size = New System.Drawing.Size(68, 24)
        Me.ButOK.TabIndex = 190
        Me.ButOK.Text = "确定"
        Me.ButOK.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(564, 364)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 24)
        Me.Button1.TabIndex = 189
        Me.Button1.Text = "取消"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(313, 369)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 14)
        Me.Label6.TabIndex = 204
        Me.Label6.Text = "勾兑标志"
        '
        'ComboBox1
        '
        Me.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"全部", "勾兑", "未勾兑"})
        Me.ComboBox1.Location = New System.Drawing.Point(372, 365)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(96, 20)
        Me.ComboBox1.TabIndex = 203
        Me.ComboBox1.Tag = "string"
        Me.ComboBox1.Text = "全部"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(26, 388)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 14)
        Me.Label7.TabIndex = 206
        Me.Label7.Text = "下推储运"
        Me.Label7.Visible = False
        '
        'ComboBox2
        '
        Me.ComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"全部", "下推", "未下推"})
        Me.ComboBox2.Location = New System.Drawing.Point(102, 385)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(96, 20)
        Me.ComboBox2.TabIndex = 205
        Me.ComboBox2.Tag = "string"
        Me.ComboBox2.Text = "全部"
        Me.ComboBox2.Visible = False
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(15, 368)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 14)
        Me.Label10.TabIndex = 212
        Me.Label10.Text = "表头过滤"
        '
        'ComboBox4
        '
        Me.ComboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Items.AddRange(New Object() {"是", "否"})
        Me.ComboBox4.Location = New System.Drawing.Point(73, 366)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(62, 20)
        Me.ComboBox4.TabIndex = 211
        Me.ComboBox4.Tag = "string"
        Me.ComboBox4.Text = "是"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(160, 370)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 14)
        Me.Label8.TabIndex = 214
        Me.Label8.Text = "作废标志"
        '
        'ComboBox3
        '
        Me.ComboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"否", "是"})
        Me.ComboBox3.Location = New System.Drawing.Point(218, 368)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(62, 20)
        Me.ComboBox3.TabIndex = 213
        Me.ComboBox3.Tag = "string"
        Me.ComboBox3.Text = "否"
        '
        'ListView
        '
        Me.ListView.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.ListView.AllowEditing = False
        Me.ListView.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.ListView.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.ListView.ColumnInfo = "10,1,0,0,0,0,Columns:0{Name:""FschemeID"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:40;Name:""image"";Style:""DataType" & _
            ":System.Byte;TextAlign:RightCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:165;Name:""FSchemeName"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.ListView.Location = New System.Drawing.Point(9, 63)
        Me.ListView.Name = "ListView"
        Me.ListView.Rows.Count = 0
        Me.ListView.Rows.DefaultSize = 18
        Me.ListView.Rows.Fixed = 0
        Me.ListView.Rows.MinSize = 18
        Me.ListView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ListView.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.ListView.Size = New System.Drawing.Size(207, 283)
        Me.ListView.StyleInfo = resources.GetString("ListView.StyleInfo")
        Me.ListView.TabIndex = 215
        '
        'FrmSelectBill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 394)
        Me.Controls.Add(Me.ListView)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FDate2)
        Me.Controls.Add(Me.FWayname)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cobCheckType)
        Me.Controls.Add(Me.FInterID)
        Me.Controls.Add(Me.ButOK)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.FBillerID)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Ftrantype)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelectBill"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "过滤窗体"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Ftrantype, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.FBillerID, 0)
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.Controls.SetChildIndex(Me.ButOK, 0)
        Me.Controls.SetChildIndex(Me.FInterID, 0)
        Me.Controls.SetChildIndex(Me.cobCheckType, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.FWayname, 0)
        Me.Controls.SetChildIndex(Me.FDate2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.ComboBox1, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.ComboBox2, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.ComboBox4, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.ComboBox3, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
        Me.Controls.SetChildIndex(Me.ListView, 0)
        CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FDate2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FWayname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FInterID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.FBillerID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.条件.ResumeLayout(False)
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.排序.ResumeLayout(False)
        CType(Me.C1FlexGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.格式.ResumeLayout(False)
        CType(Me.C1FlexGrid4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ftrantype, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents C1CommandHolder1 As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents C1Command3 As C1.Win.C1Command.C1Command
    Friend WithEvents C1Command1 As C1.Win.C1Command.C1Command
    Friend WithEvents FDate2 As C1.Win.C1Input.C1DateEdit
    Public WithEvents FWayname As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents cobCheckType As System.Windows.Forms.ComboBox
    Public WithEvents FInterID As C1.Win.C1Input.C1TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents delect As System.Windows.Forms.ToolStripButton
    Friend WithEvents Clearall As System.Windows.Forms.ToolStripButton
    Friend WithEvents list As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButOK As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents FBillerID As C1.Win.C1Input.C1TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents 条件 As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LFdate As System.Windows.Forms.Label
    Friend WithEvents Fchannle As System.Windows.Forms.ComboBox
    Friend WithEvents FCheckID As System.Windows.Forms.ComboBox
    Friend WithEvents FRob As System.Windows.Forms.ComboBox
    Friend WithEvents Fdate As System.Windows.Forms.ComboBox
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
    Protected Friend WithEvents 排序 As System.Windows.Forms.TabPage
    Friend WithEvents 格式 As System.Windows.Forms.TabPage
    Public WithEvents Ftrantype As C1.Win.C1Input.C1TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BgW As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents C1FlexGrid3 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGrid2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents delRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents C1FlexGrid4 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Private WithEvents ListView As C1.Win.C1FlexGrid.C1FlexGrid
    Private WithEvents C1Command2 As C1.Win.C1Command.C1Command
End Class
