<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBillBase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBillBase))
        Me.panelList = New System.Windows.Forms.Panel()
        Me.C2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lbrob = New C1.Win.C1Input.C1Label()
        Me.panelList.SuspendLayout()
        CType(Me.C2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbrob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelList
        '
        Me.panelList.Controls.Add(Me.C2)
        Me.panelList.Controls.Add(Me.C1FlexGrid1)
        Me.panelList.Location = New System.Drawing.Point(12, 116)
        Me.panelList.Name = "panelList"
        Me.panelList.Size = New System.Drawing.Size(761, 278)
        Me.panelList.TabIndex = 799
        '
        'C2
        '
        Me.C2.AllowEditing = False
        Me.C2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.C2.ColumnInfo = resources.GetString("C2.ColumnInfo")
        Me.C2.Location = New System.Drawing.Point(3, 234)
        Me.C2.Name = "C2"
        Me.C2.Rows.Count = 1
        Me.C2.Rows.DefaultSize = 22
        Me.C2.Rows.Fixed = 0
        Me.C2.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.C2.Size = New System.Drawing.Size(739, 40)
        Me.C2.StyleInfo = resources.GetString("C2.StyleInfo")
        Me.C2.TabIndex = 770
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1FlexGrid1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.C1FlexGrid1.ColumnInfo = resources.GetString("C1FlexGrid1.ColumnInfo")
        Me.C1FlexGrid1.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1FlexGrid1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FlexGrid1.Location = New System.Drawing.Point(3, 3)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.Rows.DefaultSize = 22
        Me.C1FlexGrid1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.C1FlexGrid1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.C1FlexGrid1.Size = New System.Drawing.Size(755, 255)
        Me.C1FlexGrid1.StyleInfo = resources.GetString("C1FlexGrid1.StyleInfo")
        Me.C1FlexGrid1.TabIndex = 769
        '
        'lbrob
        '
        Me.lbrob.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbrob.BackColor = System.Drawing.Color.Transparent
        Me.lbrob.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbrob.ForeColor = System.Drawing.Color.Transparent
        Me.lbrob.Image = Global.SGL.BaseData.My.Resources.Resources.红字
        Me.lbrob.Location = New System.Drawing.Point(713, 49)
        Me.lbrob.Name = "lbrob"
        Me.lbrob.Size = New System.Drawing.Size(60, 30)
        Me.lbrob.TabIndex = 800
        Me.lbrob.Tag = Nothing
        Me.lbrob.TextDetached = True
        Me.lbrob.Value = "1"
        Me.lbrob.Visible = False
        '
        'FrmBillBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 511)
        Me.Controls.Add(Me.panelList)
        Me.Controls.Add(Me.lbrob)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmBillBase"
        Me.Text = "单据"
        Me.Controls.SetChildIndex(Me.lbrob, 0)
        Me.Controls.SetChildIndex(Me.panelList, 0)
        Me.panelList.ResumeLayout(False)
        CType(Me.C2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbrob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panelList As System.Windows.Forms.Panel
    Friend WithEvents C2 As C1.Win.C1FlexGrid.C1FlexGrid
    Public WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lbrob As C1.Win.C1Input.C1Label
End Class
