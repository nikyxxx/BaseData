Imports PublicSharedResource
Imports System.Reflection
Imports C1.Win.C1FlexGrid

Public Class FrmListBase
    Inherits frmBase

    Public SCrasoftid As Integer
    Public m_TranType As Integer
    Protected m_attrBarList As Dictionary(Of String, Hashtable)
    Protected m_dic As Dictionary(Of String, String)
    Protected GetDataSet As New SGL.BLL.BLuser
    Private RightDate As DataSet
    Public typelist As String
    Private listdt As DataTable
    Private listdt1 As DataTable
    Private selectStr As String
    Private PX As Integer
    Private nnnew As DataTable
    Private nnnew1 As DataTable
    Private intCurRow As Integer
    Public is_SeletetBill_ReturnOK As Boolean
    Private BgW As System.ComponentModel.BackgroundWorker
    Private isReadOnly As Boolean = False

    Private Sub FrmListBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If GetService(GetType(System.ComponentModel.Design.IDesignerHost)) Is Nothing = False OrElse System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then
            Exit Sub
        End If
        Me.C1FlexGrid1.Rows(0).Height = 40
        'Me.BgW.WorkerSupportsCancellation = True
        'Me.BW_cellformat.WorkerSupportsCancellation = True '申明该后台支持取消

        initToolStrip()
        '下推按钮初始化
        GetPushDownList()

        LoadData()

        'If RightDate.Tables(0).Rows(0)(0) <> -1 Then
        '    For i As Integer = 0 To RightDate.Tables(0).Rows.Count - 1
        '        If RightDate.Tables(0).Rows(i)("fshow") = 0 Then
        '            m_ToolStrip.Items(RightDate.Tables(0).Rows(i)("fnumber")).Enabled = False
        '        Else
        '            m_ToolStrip.Items(RightDate.Tables(0).Rows(i)("fnumber")).Enabled = True
        '        End If

        '    Next
        'Else
        'End If

    End Sub

    Private Sub GetPushDownList()
        Dim PushDown As ToolStripDropDownButton

        If m_ToolStrip.Items.Find("mn_PushDown", True).Length <= 0 Then Exit Sub
        PushDown = m_ToolStrip.Items.Find("mn_PushDown", True)(0)
        Dim Sql As String
        Dim dt As DataSet
        Sql = "select * from T_SGL_IClistDown where FMid='" & SCrasoftid.ToString & "'"
        dt = GetDataSet.GetDataset(Sql, Me.CYSysInfo.ConnStrValue)

        Dim mi As Windows.Forms.ToolStripMenuItem
        For i As Integer = 0 To dt.Tables(0).Rows.Count - 1
            mi = New ToolStripMenuItem()
            mi.Tag = dt.Tables(0).Rows(i)("fdf")
            mi.Text = dt.Tables(0).Rows(i)("fname")
            AddHandler mi.Click, AddressOf PD_Click
            CType(PushDown, ToolStripDropDownButton).DropDownItems.Add(mi)
        Next

    End Sub

    Private Sub PD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strSgl As String
        If Me.C1FlexGrid1.Row = -1 Then
            Exit Sub
        End If
        Dim ctlPD As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        strSgl = ""
        download(Me.C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)(m_dic(FieldsEnum.内码)).ToString, Me.C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)(m_dic(FieldsEnum.单据类型)).ToString, ctlPD.Tag.ToString)

    End Sub

    Protected Overridable Sub download(ByVal _interid As String, ByVal _fromBillType As String, ByVal _toBillType As String)

    End Sub '下推

    Private Sub initToolStrip()
        'm_ToolStrip = New ToolStrip()
        'Me.Controls.Add(m_ToolStrip)
        'm_ToolStrip.Location = New System.Drawing.Point(0, 0)
        'm_ToolStrip.Name = "m_ToolStrip"
        'm_ToolStrip.Size = New System.Drawing.Size(948, 35)
        m_ToolStrip.BackgroundImage = My.Resources.MenuBarImage
        m_ToolStrip.BackgroundImageLayout = ImageLayout.Stretch
        Dim item As ToolStripItem
        Dim ItemSeparator As ToolStripSeparator
        Dim Sql As String
        Dim dt As DataSet
        Dim SeparatorGroupID As Integer = 1
        Sql = "select * from t_sgl_MenuBarList where isnull(FParentMenuID,'')='' and fid=" + m_TranType.ToString() + " order by FSeparatorID,FIndex"
        Sql += " select * from t_sgl_MenuBarList where isnull(FParentMenuID,'')<>'' and fid=" + m_TranType.ToString() + " order by FSeparatorID,FIndex"
        dt = GetDataSet.GetDataset(Sql, Me.CYSysInfo.ConnStrValue)
        For i As Integer = 0 To dt.Tables(0).Rows.Count - 1
            If SeparatorGroupID <> dt.Tables(0).Rows(i)("FSeparatorID") Then
                SeparatorGroupID = dt.Tables(0).Rows(i)("FSeparatorID")
                ItemSeparator = New ToolStripSeparator()
                m_ToolStrip.Items.AddRange(New ToolStripItem() {ItemSeparator})
            End If

            '下拉按钮
            If dt.Tables(0).Rows(i)("FCanDropDown") = 1 Then
                item = New ToolStripDropDownButton
            Else
                item = New ToolStripButton
            End If

            m_ToolStrip.Items.AddRange(New ToolStripItem() {item})
            item.Name = dt.Tables(0).Rows(i)("FMenuID").ToString()
            item.Text = dt.Tables(0).Rows(i)("FMenuName").ToString()
            item.ToolTipText = dt.Tables(0).Rows(i)("FNote").ToString()
            item.ImageTransparentColor = System.Drawing.Color.Magenta
            item.Size = New System.Drawing.Size(33, 32)
            item.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            item.Image = My.Resources.Resources.ResourceManager.GetObject(dt.Tables(0).Rows(i)("FImageName").ToString())
            item.AutoSize = False
            item.Height = 32
            item.Width = 32
            item.AutoSize = True

            Dim drows() As DataRow = dt.Tables(1).Select(" isnull(FParentMenuID,'')='" + item.Name + "'")
            For Each dr As DataRow In drows
                Dim item_sun As ToolStripItem
                item_sun = New ToolStripMenuItem()
                item_sun.Name = dr("FMenuID").ToString()
                item_sun.Text = dr("FMenuName").ToString()
                CType(item, ToolStripDropDownButton).DropDownItems.Add(item_sun)
                AddHandler item_sun.Click, AddressOf DropDownItems_ItemClicked
            Next
        Next


        AddHandler m_ToolStrip.ItemClicked, AddressOf ToolStrip_ItemClicked

        m_attrBarList = New Dictionary(Of String, Hashtable)
        Dim has_OnToolMenuClick As Hashtable = New Hashtable()
        Dim has_BeforeToolMenuClick As Hashtable = New Hashtable()
        Dim has_AfterToolMenuClick As Hashtable = New Hashtable()
        Dim t As Type = Me.GetType()
        Dim ms() As MethodInfo = t.GetMethods()

        For Each m As MethodInfo In ms
            Dim obj_OnToolMenuClick() As Object = m.GetCustomAttributes(GetType(OnToolMenuClickAttribute), False)
            Dim obj_BeforeToolMenuClick() As Object = m.GetCustomAttributes(GetType(BeforeToolMenuClickAttribute), False)
            Dim obj_AfterToolMenuClick() As Object = m.GetCustomAttributes(GetType(AfterToolMenuClickAttribute), False)
            If obj_OnToolMenuClick.Length > 0 Then
                has_OnToolMenuClick.Add(CType(obj_OnToolMenuClick(0), OnToolMenuClickAttribute).MenuName, m.Name)
            End If
            If obj_BeforeToolMenuClick.Length > 0 Then
                has_BeforeToolMenuClick.Add(CType(obj_BeforeToolMenuClick(0), BeforeToolMenuClickAttribute).MenuName, m.Name)
            End If
            If obj_AfterToolMenuClick.Length > 0 Then
                has_AfterToolMenuClick.Add(CType(obj_AfterToolMenuClick(0), AfterToolMenuClickAttribute).MenuName, m.Name)
            End If
        Next
        m_attrBarList.Add("OnToolMenuClick", has_OnToolMenuClick)
        m_attrBarList.Add("BeforeToolMenuClick", has_BeforeToolMenuClick)
        m_attrBarList.Add("AfterToolMenuClick", has_AfterToolMenuClick)

        If Me.CYUserInfo.FIsAdmin <> 1 Then
            For Each dr As DataRow In MenuListNoRights.Rows
                BillInstance.MenuBar_SetEnable_False(m_ToolStrip, dr("FMenuID").ToString())
            Next
        End If
    End Sub

    Private Sub DropDownItems_ItemClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ItemClicked(CType(sender, ToolStripMenuItem).Name)
    End Sub

    Private Sub ItemClicked(ByVal _MenuName As String)
        Dim _value As Boolean = False
        _value = BeforeItemClickExecute(_MenuName)
        If _value = False Then
            Exit Sub
        End If
        _value = False
        _value = OnItemClickExecute(_MenuName)
        If _value = False Then
            Exit Sub
        End If
        AfterItemClickExecute(_MenuName)
    End Sub

    Protected Function MenuListNoRights() As DataTable
        Try
            Dim Sql As String
            Dim dt As DataSet
            Sql = " select FMenuID from t_sgl_MenuBarList where isnull(FShowInRights,0)=1 and FID=" + m_TranType.ToString()
            Sql += " and FMenuID not in ( select t1.FMenuID from t_sgl_MenuBarList t1"
            Sql += " inner join T_CY_SGL_Riht t2 on t1.FIdentity=t2.fid and t2.FUserID=" + Me.CYUserInfo.UserID.ToString()
            Sql += " where isnull(t1.FShowInRights,0)=1 and t1.FID=" + m_TranType.ToString() + ")"
            dt = GetDataSet.GetDataset(Sql, Me.CYSysInfo.ConnStrValue)
            Return dt.Tables(0)
        Catch ex As Exception
            BillInstance.myShowMsg(ex.Message.ToString())
            Return Nothing
        End Try
    End Function

    Private Sub ToolStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
        ItemClicked(e.ClickedItem.Name)
    End Sub

    Private Function BeforeItemClickExecute(ByVal _itemName As String) As Boolean

        If m_attrBarList("BeforeToolMenuClick")(_itemName) Is Nothing = False Then
            Dim t As Type = Me.GetType()
            Dim ms() As MethodInfo = t.GetMethods()
            For Each m As MethodInfo In ms
                If m.Name = m_attrBarList("BeforeToolMenuClick")(_itemName) Then
                    Dim _value As Boolean = CType(m.Invoke(Me, New Object() {}), Boolean)
                    Return _value
                End If
            Next
        End If

        Select Case _itemName
            Case "mn_Audit"
                Return AuditStatusCheck()
            Case "mn_Reject"
                Return RejectStatusCheck()
            Case "mn_Delete"
                Return DeleteCheck()
            Case "mn_Exit"
                'Me.Close()
                'Return True
        End Select

        Return True
    End Function

    Private Function OnItemClickExecute(ByVal _itemName As String) As Boolean
        Try

            If m_attrBarList("OnToolMenuClick")(_itemName) Is Nothing = False Then
                Dim t As Type = Me.GetType()
                Dim ms() As MethodInfo = t.GetMethods()
                For Each m As MethodInfo In ms
                    If m.Name = m_attrBarList("OnToolMenuClick")(_itemName) Then
                        Dim _value As Boolean = CType(m.Invoke(Me, New Object() {}), Boolean)
                        Return _value
                    End If
                Next
            End If

            Select Case _itemName
                Case "mn_Refresh"
                    RefreshData()
                    Return True
                Case "mn_Search"
                    ShowSelectDialog(True)
                    LoadData()
                Case "mn_Audit"
                    Return AuditBill()
                Case "mn_Reject"
                    Return RejectBill()
                Case "mn_Delete"
                    Return DeleteBill()
                Case "mn_UpSelect"
                    Return OnUpSelect()
                Case "mn_DownSelect"
                    Return OnDownSelect()
                Case "mn_Review"
                    GridReportFuntion.Instance.CustomReport(Me.CYUserInfo.UserID.ToString(), Me.CYSysInfo.ConnStrValue, C1FlexGrid1, m_TranType, Nothing).PrintPreview(True)
                    Return True
                Case "mn_Print"
                    GridReportFuntion.Instance.CustomReport(Me.CYUserInfo.UserID.ToString(), Me.CYSysInfo.ConnStrValue, C1FlexGrid1, m_TranType, Nothing).Print(True)
                    Return True
                Case "mn_ToExcel"
                    Me.Cursor = Cursors.WaitCursor
                    GridReportFuntion.Instance.ToExcel(Me.CYUserInfo.UserID, Me.CYSysInfo.ConnStrValue, Me.C1FlexGrid1, Nothing, m_TranType, Nothing, Me.Text)
                    Me.Cursor = Cursors.Default
                Case "mn_PrintSet"
                    Dim pageSetting As New FrmPageSetting(m_TranType)
                    pageSetting.CYUserInfo = Me.CYUserInfo
                    pageSetting.CYSysInfo = Me.CYSysInfo
                    If pageSetting.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    End If
                    Return True
                Case MenuEnum.恢复宽度
                    Return ResumeDefaultColWidth()
                Case "mn_Exit"
                    Me.Close()
                    Return True
            End Select

            Return True

        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Return False
        End Try
    End Function

    Protected Function ResumeDefaultColWidth()
        For i As Integer = 1 To C1FlexGrid1.Cols.Count - 1
            If C1FlexGrid1.Cols(i).Name.ToUpper.Substring(0, 1) = "F" And C1FlexGrid1.Cols(i).Name.ToUpper <> "FKEY" Then
                C1FlexGrid1.Cols(i).Width = -1
            Else
                C1FlexGrid1.Cols(i).Width = 70
            End If
        Next
        SumSet()

        Return True
    End Function

    Protected Sub RefreshData()
        GetDataBillList()
        LoadData()
    End Sub

    Private Sub AfterItemClickExecute(ByVal _itemName As String)
        If m_attrBarList("AfterToolMenuClick")(_itemName) Is Nothing = False Then
            Dim t As Type = Me.GetType()
            Dim ms() As MethodInfo = t.GetMethods()
            For Each m As MethodInfo In ms
                If m.Name = m_attrBarList("AfterToolMenuClick")(_itemName) Then
                    m.Invoke(Me, New Object() {})
                    Return
                End If
            Next
        End If

        Select Case _itemName
            Case "mn_Add"
                RefreshData()
            Case "mn_Audit"
                RefreshData()
            Case "mn_Reject"
                RefreshData()
            Case "mn_Delete"
                RefreshData()
        End Select
    End Sub

    Public Overridable Function AuditStatusCheck() As Boolean
        Dim _row As Integer = C1FlexGrid1.Row
        If _row <= 0 Or _row > C1FlexGrid1.Rows.Count - 1 Then Return False
        Dim _FInterIDName As String = m_dic(FieldsEnum.内码)
        Dim _interID As Integer = C1FlexGrid1(_row, _FInterIDName)
        'If _interID <= 0 Then
        '    MsgBox("请先保存单据！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
        '    Me.Cursor = Cursors.Default
        '    Return False
        'End If
        Try

            Dim _tableName As String = m_dic("MainTable")
            Return BillInstance.AuditStatusCheck(_FInterIDName, _tableName, _interID, Me.CYSysInfo.ConnStrValue)
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Return False
        End Try
    End Function

    Public Overridable Function AuditBill() As Boolean
        Try
            Dim _value As Boolean
            Dim _row As Integer = C1FlexGrid1.Row
            Dim _FInterIDName As String = m_dic(FieldsEnum.内码)
            Dim _tableName As String = m_dic("MainTable")
            Dim _FCheckerName As String = m_dic("FCheckerName")
            Dim _FCheckDate As String = m_dic("FCheckDateName")
            Dim _interID As Integer = C1FlexGrid1(_row, _FInterIDName)
            _value = BillInstance.AuditBill(_FInterIDName, _FCheckerName, _FCheckDate, _tableName, _interID, Me.CYSysInfo.ConnStrValue, Me.CYUserInfo.UserID)
            If _value Then
                MsgBox("操作成功！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Else
                MsgBox("操作失败！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            End If
            Return _value
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Return False
        End Try
    End Function

    Public Overridable Function RejectStatusCheck() As Boolean
        Dim _row As Integer = C1FlexGrid1.Row
        If _row <= 0 Or _row > C1FlexGrid1.Rows.Count - 1 Then Return False
        Dim _FInterIDName As String = m_dic(FieldsEnum.内码)
        Dim _interID As Integer = C1FlexGrid1(_row, _FInterIDName)
        Try
            Dim _tableName As String = m_dic("MainTable")
            Return BillInstance.RejectStatusCheck(_FInterIDName, _tableName, _interID, Me.CYSysInfo.ConnStrValue)
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Return False
        End Try
    End Function

    Public Overridable Function RejectBill() As Boolean
        Try
            Dim _value As Boolean
            Dim _row As Integer = C1FlexGrid1.Row
            Dim _FInterIDName As String = m_dic(FieldsEnum.内码)
            Dim _tableName As String = m_dic("MainTable")
            Dim _FCheckerName As String = m_dic("FCheckerName")
            Dim _FCheckDate As String = m_dic("FCheckDateName")
            Dim _interID As Integer = C1FlexGrid1(_row, _FInterIDName)
            _value = BillInstance.RejectBill(_FInterIDName, _FCheckerName, _FCheckDate, _tableName, _interID, Me.CYSysInfo.ConnStrValue)
            If _value Then
                MsgBox("操作成功！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Else
                MsgBox("操作失败！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            End If
            Return _value
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Return False
        End Try
    End Function

    Public Overridable Function DeleteCheck() As Boolean
        Dim _row As Integer = C1FlexGrid1.Row
        If _row <= 0 Or _row > C1FlexGrid1.Rows.Count - 1 Then Return False
        Dim _FInterIDName As String = m_dic(FieldsEnum.内码)
        Dim _interID As Integer = C1FlexGrid1(_row, _FInterIDName)
        'If _interID <= 0 Then
        '    MsgBox("请先保存单据！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
        '    Me.Cursor = Cursors.Default
        '    Return False
        'End If
        
        Try
            Dim _tableName As String = m_dic("MainTable")
            Dim _value As Boolean
            _value = BillInstance.DeleteCheck(_FInterIDName, _tableName, _interID, Me.CYSysInfo.ConnStrValue)
            If _value = False Then Return False
            If MsgBox("确定删除所选单据？", MsgBoxStyle.OkCancel, clsGlobal.M_STR_HINT) <> vbOK Then
                Return False
            End If
            Return _value
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Return False
        End Try
    End Function

    Public Overridable Function DeleteBill() As Boolean
        Try
            Dim _value As Boolean
            Dim _row As Integer = C1FlexGrid1.Row
            Dim _FInterIDName As String = m_dic(FieldsEnum.内码)
            Dim _tableName As String = m_dic("MainTable")
            Dim _EntryTable As String = m_dic("EntryTable")
            Dim _interID As Integer = C1FlexGrid1(_row, _FInterIDName)
            _value = BillInstance.DeleteBill(_FInterIDName, _tableName, _EntryTable, _interID, Me.CYSysInfo.ConnStrValue)
            If _value Then
                MsgBox("操作成功！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Else
                MsgBox("操作失败！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            End If
            Return _value
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Return False
        End Try
    End Function

    Public Function OnUpSelect() As Boolean
        Dim Sql As String
        Dim dt As DataSet
        Try
            Dim _row As Integer = C1FlexGrid1.Row
            If _row <= 0 Or _row > C1FlexGrid1.Rows.Count - 1 Then Return False
            Dim _interid As Integer = Me.C1FlexGrid1.Rows(_row)(m_dic(FieldsEnum.内码))
            Dim _trantype As Integer = Me.C1FlexGrid1.Rows(_row)(m_dic(FieldsEnum.单据类型))
            If _interid > 0 Then
                Sql = "exec P_SGL_GLBillSC   '" & _trantype.ToString() & "', '" & _interid.ToString() & "'"
                dt = GetDataSet.GetDataset(Sql, Me.CYSysInfo.ConnStrValue)
                If dt.Tables(0).Rows.Count = 0 Then
                    MsgBox("无关联单据！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                    Return False
                End If
                Dim _has As Hashtable = New Hashtable
                _has.Add("nnnew", dt)
                _has.Add("Way", "1")
                BillInstance.CallFom(Me.CYUserInfo, Me.CYSysInfo, "SGL.ZIC.FrmGlBillList", _has)
                Return True
            End If
            Return False
        Catch ex As Exception
            BillInstance.myShowMsg(ex.Message.ToString())
            Return False
        End Try
    End Function

    Public Function OnDownSelect() As Boolean
        Try
            Dim Sql As String
            Dim dt As DataSet
            Dim _row As Integer = C1FlexGrid1.Row
            If _row <= 0 Or _row > C1FlexGrid1.Rows.Count - 1 Then Return False
            Dim _interid As Integer = Me.C1FlexGrid1.Rows(_row)(m_dic(FieldsEnum.内码))
            Dim _trantype As Integer = Me.C1FlexGrid1.Rows(_row)(m_dic(FieldsEnum.单据类型))
            If _interid > 0 Then
                Sql = "exec P_SGL_GLBill   '" & _trantype.ToString() & "', '" & _interid.ToString() & "'"
                dt = GetDataSet.GetDataset(Sql, Me.CYSysInfo.ConnStrValue)
                If dt.Tables(0).Rows.Count = 0 Then
                    MsgBox("无关联单据！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                    Return False
                End If
                Dim _has As Hashtable = New Hashtable
                _has.Add("nnnew", dt)
                _has.Add("Way", "")
                BillInstance.CallFom(Me.CYUserInfo, Me.CYSysInfo, "SGL.ZIC.FrmGlBillList", _has)
                Return True
            End If
            Return False
        Catch ex As Exception
            BillInstance.myShowMsg(ex.Message.ToString())
            Return False
        End Try
    End Function

    Public Sub New()
        If GetService(GetType(System.ComponentModel.Design.IDesignerHost)) Is Nothing = False OrElse System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then
        Else
            m_TranType = PublicSharedResource.PublicSharedFunctions.trantype
            InitView()

            Dim hs As Hashtable = CType(Me.objFormPara, Hashtable)
            If hs Is Nothing Then
                selectStr = ""
                isReadOnly = False
            Else
                selectStr = hs.Item("selectStr")
                isReadOnly = hs.Item("isReadOnly")
            End If

            If RightSeting(PublicSharedResource.PublicSharedFunctions.Crasoftid, PublicSharedResource.PublicSharedFunctions.useid) = False Then
                MsgBox("没有权限，请与管理员联系！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                Me.Dispose()
                Exit Sub
            End If
            'BgW = New System.ComponentModel.BackgroundWorker()
            'AddHandler BgW.DoWork, AddressOf BgW_DoWork

            If isReadOnly Then '查看模式不需要过滤窗口
                GetDataBillList()
            Else
                If ShowSelectDialog(True) = False Then
                    Me.Dispose()
                    Exit Sub
                End If
            End If

        End If
        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        AddHandler Me.Load, AddressOf FrmListBase_Load
        AddHandler Me.FormClosed, AddressOf FrmListBase_FormClosed
        AddHandler Me.Disposed, AddressOf FrmListBase_Disposed
        'AddHandler BgW.RunWorkerCompleted, AddressOf BgW_RunWorkerCompleted
    End Sub

    Public Sub InitView()
        m_dic = New Dictionary(Of String, String)
        m_dic = BillInstance.BilledDictionary(m_TranType, PublicSharedResource.PublicSharedFunctions.consglstr)
    End Sub

    Public Function RightSeting(ByVal _MenuID As String, ByVal _UserID As String) As Boolean
        Dim Sql As String
        Dim dblTemp As Double = 0
        Dim dblSum As Double = 0
        Sql = "select case isnull(FPrimaryGroup,0) when 1 then 1 else 0 end as FIsAdmin from t_User where FUserID=" + _UserID.ToString()
        Sql += " select 1 from T_CY_SGL_Riht where FMenuID=" + _MenuID.ToString() + " and FUserID=" + _UserID.ToString()
        RightDate = GetDataSet.GetDataset(Sql, PublicSharedResource.PublicSharedFunctions.consglstr)
        If RightDate.Tables(0).Rows.Count > 0 Then
            If RightDate.Tables(0).Rows(0)("FIsAdmin") = 1 Then
                Return True
            End If
            If RightDate.Tables(1).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function '权限设置

    Private Function ShowSelectDialog(ByVal blnIsFirst As Boolean) As Boolean
        Try

            Dim frmSelect As New FrmSelectBillBase
            frmSelect.constrmyh = PublicSharedResource.PublicSharedFunctions.consglstr
            If typelist > 0 Then
                frmSelect.listtype = typelist
                frmSelect.m_UserID = Me.CYUserInfo.UserID
            Else
                frmSelect.listtype = PublicSharedResource.PublicSharedFunctions.trantype
                frmSelect.m_UserID = PublicSharedResource.PublicSharedFunctions.useid
                typelist = PublicSharedResource.PublicSharedFunctions.trantype
                SCrasoftid = PublicSharedResource.PublicSharedFunctions.Crasoftid
            End If
            frmSelect.SCrasoftid = SCrasoftid
            frmSelect.ShowDialog()
            is_SeletetBill_ReturnOK = frmSelect.strcmdok
            If is_SeletetBill_ReturnOK = True Then
                'listdt = frmSelect.dt
                'listdt1 = frmSelect.dt1
                selectStr = frmSelect.strsql
                PX = frmSelect.PX
                frmSelect.Dispose()

                'm_ToolStrip.Enabled = False
                'C1FlexGrid1.Enabled = False
                'C2.Enabled = False
                'BgW.RunWorkerAsync(1)
                GetDataBillList()
            End If

            Return is_SeletetBill_ReturnOK
        Catch ex As Exception
            'Throw ex
        End Try
    End Function

    Private Sub BgW_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        'Dim worker As System.ComponentModel.BackgroundWorker = CType(sender, System.ComponentModel.BackgroundWorker)
        GetDataBillList()
    End Sub

    Private Sub GetDataBillList()
        Try
            Dim Sql As String
            Dim dt As DataSet
            Sql = "exec P_CS_ICList   '" & typelist & "','" & selectStr + "SGLLOVEMYH  " + "' "
            dt = GetDataSet.GetDataset(Sql, PublicSharedFunctions.consglstr)
            If PX > 0 Then
                listdt = dt.Tables(0)
            Else
                listdt = PublicSharedResource.PublicSharedFunctions.HollowDataTable(dt.Tables(0), 3, 5, m_dic(FieldsEnum.内码), m_dic(FieldsEnum.内码))
            End If
            listdt1 = dt.Tables(1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LoadData()
        If is_SeletetBill_ReturnOK = True Then
            C1FlexGrid1.DataSource = listdt
            C1FlexGrid1.Cols(m_dic(FieldsEnum.内码)).Width = -1
            C1FlexGrid1.Cols("fentryid").Width = -1 '增加多表体功能后该字段需要根据数据库读取
            C1FlexGrid1.Cols(m_dic(FieldsEnum.单据类型)).Width = -1
            C1FlexGrid1.AllowEditing = False
            C2.DataSource = listdt1
        End If
        DU_FormatLocation()
        DU_FormatAlignType()
        DU_Format()
        SumSet()
        SetRowNo()
    End Sub

    Private Sub BgW_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)

        ' First, handle the case where an exception was thrown.
        If Not (e.Error Is Nothing) Then
            MessageBox.Show(e.Error.Message)
        End If
        m_ToolStrip.Enabled = True
        C1FlexGrid1.Enabled = True
        C2.Enabled = True
        Me.Cursor = Cursors.WaitCursor
        C1FlexGrid1.DataSource = listdt

        C1FlexGrid1.Cols("finterid").Width = -1
        C1FlexGrid1.Cols("fentryid").Width = -1
        C1FlexGrid1.Cols("FTranType").Width = -1
        If typelist <> 802 And typelist <> 9003 And typelist <> 9004 Then
            C1FlexGrid1.Cols("FQtyDecimal").Width = -1
            C1FlexGrid1.Cols("FPriceDecimal").Width = -1
        End If
        C1FlexGrid1.AllowEditing = False
        C2.DataSource = listdt1

        DU_FormatLocation()
        DU_FormatAlignType()
        'cellformat()
        DU_Format()
        SetRowNo()
        SumSet()


        Me.Cursor = Cursors.Default
    End Sub

    Protected Sub SetRowNo()
        '行号
        Dim i As Integer

        Try
            For i = 1 To Me.C1FlexGrid1.Rows.Count - 1
                Me.C1FlexGrid1(i, 0) = i
            Next

        Catch ex As Exception
            ' BillDisposed()
            Throw ex
        End Try
    End Sub

    Public Sub SumSet()
        Dim i As Integer
        Dim dblTemp As Double = 0
        Dim dblSum As Double = 0
        Dim dblTemp1 As Double = 0
        Dim dblSum1 As Double = 0
        Dim dblTemp2 As Double = 0
        Dim dblSum2 As Double = 0
        Dim dblSum3 As Double = 0
        Dim dblTemp3 As Double = 0
        C2.Cols.Count = C1FlexGrid1.Cols.Count
        For i = 0 To C1FlexGrid1.Cols.Count - 1
            C2.Cols(i).DataType = C1FlexGrid1.Cols(i).DataType
            C2.Cols(i).Format = C1FlexGrid1.Cols(i).Format
            C2.Cols(i).Visible = C1FlexGrid1.Cols(i).Visible
            C2.Cols(i).Width = C1FlexGrid1.Cols(i).Width
            C2.Cols(i).TextAlign = C1FlexGrid1.Cols(i).TextAlign
            C2.BackColor = Color.FromArgb(255, 255, 220)
            C2.Item(0, 0) = "合计"

            C2.Cols(i).AllowEditing = False

        Next
        PublicSharedFunctions.FlexGridFormatNoSum(Me.C1FlexGrid1)

    End Sub

#Region "列设置相关"
    Public Sub DU_Format()
        Dim bb As DataSet
        Dim sqlstr As String
        Dim i As Integer
        sqlstr = "exec P_SGL_RPTZDYBAOBIAOFormatoutlist " + Me.CYUserInfo.UserID.ToString + "," + typelist.ToString
        bb = GetDataSet.GetDataset(sqlstr, Me.CYSysInfo.ConnStrValue)
        If bb.Tables(0).Rows.Count > 1 Then
            For i = 1 To C1FlexGrid1.Cols.Count - 1
                If i >= bb.Tables(0).Rows.Count Then
                    '  C1FlexGrid1.Cols(i).Width = 70
                    If C1FlexGrid1.Cols(i).Name.ToString.Substring(0, 1).ToUpper = "F" Then
                        C1FlexGrid1.Cols(i).Width = -1
                    Else
                        C1FlexGrid1.Cols(i).Width = 70
                    End If
                Else
                    If C1FlexGrid1.Cols(i).Name.ToString.Substring(0, 1).ToUpper = "F" And C1FlexGrid1.Cols(i).Name.ToString <> "FKey" Then
                        C1FlexGrid1.Cols(i).Width = -1
                    Else
                        If bb.Tables(0).Rows(i - 1)("FValue") > 10 Then
                            C1FlexGrid1.Cols(i).Width = bb.Tables(0).Rows(i - 1)("FValue")
                        Else
                            C1FlexGrid1.Cols(i).Width = -1
                        End If

                    End If

                End If
            Next
        End If
    End Sub '读取宽度

    Public Sub CUN_Format()
        Dim sql As String
        Dim sqlstr As String
        Dim bb As DataSet
        Dim i As Integer = 0
        Dim dblTemp As Integer = 0

        sql = ""
        For i = 1 To C1FlexGrid1.Cols.Count - 1
            sql = sql + C1FlexGrid1.Cols(i).Width.ToString + ","
        Next


        sqlstr = "exec P_SGL_RPTZDYBAOBIAOFormatlist   '" + sql + "'," + typelist + "," + Me.CYUserInfo.UserID.ToString

        bb = GetDataSet.GetDataset(sqlstr, Me.CYSysInfo.ConnStrValue)
    End Sub '保存宽度

    Public Sub DU_FormatLocation()
        Dim bb As DataSet
        Dim sqlstr As String

        Dim colIndex As Integer = 1, c2Index As Integer = 0

        sqlstr = "exec P_nbb_FormatLocationRead " + Me.CYUserInfo.UserID.ToString + "," + typelist.ToString
        bb = GetDataSet.GetDataset(sqlstr, Me.CYSysInfo.ConnStrValue)

        If bb.Tables(0).Rows.Count > 1 Then

            If C1FlexGrid1.Cols.Contains("FKey") Then
                C1FlexGrid1.Cols("FKey").Width = 40
                C1FlexGrid1.Cols("FKey").TextAlign = TextAlignEnum.CenterCenter
                C1FlexGrid1.Cols("FKey").TextAlignFixed = TextAlignEnum.CenterCenter
            End If

            For i As Integer = 0 To bb.Tables(0).Rows.Count - 1

                If C1FlexGrid1.Cols.Contains(bb.Tables(0).Rows(i)("FValue")) Then
                    c2Index = C1FlexGrid1.Cols(bb.Tables(0).Rows(i)("FValue").ToString).Index
                    C1FlexGrid1.Cols(bb.Tables(0).Rows(i)("FValue").ToString).Move(colIndex)
                    C2.Cols(c2Index).Move(colIndex)
                    colIndex = colIndex + 1
                Else
                    C1FlexGrid1.Cols(i).Width = -1
                    'c2Index = C1FlexGrid1.Cols(bb.Tables(0).Rows(i)("FValue").ToString).Index
                    'C2.Cols(c2Index).Width = -1
                End If

            Next

        End If
    End Sub '读取位置

    Public Sub DU_FormatAlignType()
        Dim bb As DataSet
        Dim sqlstr As String
        'Dim _align As C1.Win.C1FlexGrid.CellStyle
        Dim _align As TextAlignEnum
        Dim colIndex As Integer = 1, c2Index As Integer = 0
        Dim rg As C1.Win.C1FlexGrid.CellRange
        Dim csLeft As C1.Win.C1FlexGrid.CellStyle, csCenter As C1.Win.C1FlexGrid.CellStyle, csRight As C1.Win.C1FlexGrid.CellStyle
        csLeft = C1FlexGrid1.Styles.Add("csLeft")
        csLeft.TextAlign = TextAlignEnum.LeftCenter

        csCenter = C1FlexGrid1.Styles.Add("csCenter")
        csCenter.TextAlign = TextAlignEnum.CenterCenter

        csRight = C1FlexGrid1.Styles.Add("csRight")
        csRight.TextAlign = TextAlignEnum.RightCenter

        sqlstr = "exec P_nbb_FormatAlignTypeRead " + Me.CYUserInfo.UserID.ToString + "," + typelist.ToString
        bb = GetDataSet.GetDataset(sqlstr, Me.CYSysInfo.ConnStrValue)

        If bb.Tables(0).Rows.Count > 1 Then

            For i As Integer = 1 To C1FlexGrid1.Cols.Count - 1

                If i > bb.Tables(0).Rows.Count Then Exit For
                '_align = csLeft
                _align = TextAlignEnum.LeftCenter
                If bb.Tables(0).Rows(i - 1)("FValue") = 1 Then '靠左
                    '_align = csLeft
                    _align = TextAlignEnum.LeftCenter
                ElseIf bb.Tables(0).Rows(i - 1)("FValue") = 2 Then '居中
                    '_align = csCenter
                    _align = TextAlignEnum.CenterCenter
                ElseIf bb.Tables(0).Rows(i - 1)("FValue") = 3 Then '靠右
                    '_align = csRight
                    _align = TextAlignEnum.RightCenter
                End If

                If C1FlexGrid1.Cols(i).Name.ToString.Substring(0, 1).ToUpper = "F" And C1FlexGrid1.Cols(i).Name.ToString <> "FKey" Then

                Else
                    If C1FlexGrid1.Rows.Count > 1 Then
                        C1FlexGrid1.Cols(i).TextAlign = _align
                        'rg = C1FlexGrid1.GetCellRange(1, i, C1FlexGrid1.Rows.Count - 1, i)
                        'rg.Style = _align  
                    End If
                    'C1FlexGrid1.Cols(i).TextAlign = _align
                End If

            Next

        End If

        If bb.Tables(1).Rows.Count > 1 Then
            For i As Integer = 1 To C1FlexGrid1.Cols.Count - 1
                If i > bb.Tables(1).Rows.Count Then Exit For
                If C1FlexGrid1.Cols(i).Name.ToString.Substring(0, 1).ToUpper = "F" And C1FlexGrid1.Cols(i).Name.ToString <> "FKey" Then
                Else
                    If bb.Tables(1).Rows(i - 1)("FValue") = 1 Then
                        C1FlexGrid1.Cols(i).DataType = System.Type.GetType("System.Decimal")
                        C1FlexGrid1.Cols(i).Format = "#,##0.0000;;#"
                    End If
                    'C1FlexGrid1.Cols(i).Format = IIf(bb.Tables(1).Rows(i - 1)("FValue") = 0, "", "#,##0.00;;#")
                End If
            Next
        End If
    End Sub '读取列布局及格式串

    Public Sub CUN_FormatLocation()
        Dim sql As String
        Dim sqlstr As String
        Dim bb As DataSet
        Dim i As Integer = 0
        Dim dblTemp As Integer = 0

        sql = ""
        For i = 1 To C1FlexGrid1.Cols.Count - 1
            sql = sql + C1FlexGrid1.Cols(i).Name.ToString + ","
        Next


        sqlstr = "exec P_nbb_FormatLocationWrite   '" + sql + "','',''," + typelist + "," + Me.CYUserInfo.UserID.ToString

        bb = GetDataSet.GetDataset(sqlstr, Me.CYSysInfo.ConnStrValue)
    End Sub '保存位置
#End Region

#Region "表体设置"
    Private Sub C1FlexGrid1_AfterResizeColumn(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGrid1.AfterResizeColumn
        Me.Cursor = Cursors.WaitCursor

        Try
            Dim j As Integer = 0
            C2.Cols.Count = Me.C1FlexGrid1.Cols.Count
            For k As Integer = 0 To C1FlexGrid1.Cols.Count - 1
                If Me.C1FlexGrid1.Cols(k).Visible = True Then
                    C2.Cols(k).Visible = True
                    C2.Cols(j).Width = C1FlexGrid1.Cols(k).Width
                    C2.BackColor = Color.FromArgb(255, 255, 220)
                    C2.Item(0, 0) = "合计"
                    j = j + 1
                Else
                    C2.Cols(k).Visible = False
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Me.Cursor = Cursors.Default

    End Sub


    Private Sub C1FlexGrid1_AfterScroll(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles C1FlexGrid1.AfterScroll
        C2.ScrollPosition = C1FlexGrid1.ScrollPosition
    End Sub

    Private Sub C2_BeforeScroll(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles C2.BeforeScroll
        intCurRow = C1FlexGrid1.TopRow
    End Sub



    Private Sub C2_AfterScroll(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles C2.AfterScroll
        '处理上下表体滚动条一致
        Try
            'C1FlexGrid1.StartEditing()
            C1FlexGrid1.ScrollPosition = C2.ScrollPosition
            C1FlexGrid1.TopRow = intCurRow
        Catch ex As Exception
            '  BillDisposed()
            Throw ex
        End Try
    End Sub


    Private Sub C1FlexGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1FlexGrid1.DoubleClick
        Dim _row As Integer = C1FlexGrid1.Row
        If _row <= 0 Or _row > C1FlexGrid1.Rows.Count Then Exit Sub
        Dim _interID As Integer = C1FlexGrid1(_row, m_dic(FieldsEnum.内码))
        Dim hastable As Hashtable = New Hashtable
        hastable.Add("FuncStatus", "")
        hastable.Add("FInterID", _interID)
        hastable.Add("ReadOnly", isReadOnly)
        CallBill(hastable)
    End Sub

    Protected Overridable Sub CallBill(ByVal _hastable As Hashtable)

    End Sub
#End Region


    Private Sub FrmListBase_Disposed(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Me.Dispose(True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FrmListBase_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        CUN_Format()
        CUN_FormatLocation()
        Me.Dispose(True)
    End Sub
End Class