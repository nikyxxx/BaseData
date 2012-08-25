Imports grproLib
Imports D1Lib
Imports System.Reflection
Imports SGL.BLL
Imports System.Data
Imports System.Drawing
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports C1.Win.C1FlexGrid
Imports PublicSharedResource
Imports PublicSharedResource.PublicSharedFunctions
Imports SGL.BaseData


Public Class FrmBillBase
    Inherits frmBase
    Dim intCurRow As Integer
    Protected load_flag As Boolean = False 'true 表示正在加载
    Protected hs As Hashtable
    Protected GetData As DataSet
    Protected GetDataSet As New SGL.BLL.BLuser
    Protected BillDate As New SGL.BLL.BLManagerOldBillData
    Public SCrasoftid As Integer
    Protected DLinterstr As String
    Public sglinterid As String
    Public VchData As DataTable
    Public VchCruNo As Integer = -1
    Protected data As String '记录编辑前的cell值
    Private strsql As String
    Private _billstatus As Integer '不允许直接调用 使用 m_BillStatus
    Public m_InterID As Integer
    Public billid As String
    Protected billno As String
    Protected Griddatanew As DataSet
    Protected Griddatanewbill As DataSet
    Protected dstable As DataTable
    Protected RightDate As DataSet
   
    Protected isDownBill As Boolean = False
    Protected m_canEditFields As Hashtable '在一些特殊情况下启用一些单元格的可编辑功能
    Public isReadOnly As Boolean = False

    Public Property m_BillStatus() As Integer
        Get
            Return _billstatus
        End Get
        Set(ByVal value As Integer)
            _billstatus = value
            BillStatus_Changed()
        End Set
    End Property

#Region "枚举"
    'Protected menuEnum As MenuEnum = New MenuEnum
    'Protected FieldsEnum As FieldsEnum = New FieldsEnum
    'Protected TableEnum As TableEnum = New TableEnum
#End Region

#Region "自定义窗体使用"
    Protected m_intCurRow As Integer
    Protected m_TranType As Integer = 0
    Protected m_ToolStrip As ToolStrip
    Protected m_isRob As Integer = 0
    Protected m_attrBarList As Dictionary(Of String, Hashtable)
    Protected m_dic As Dictionary(Of String, String)
    Protected saveStr As String
    Protected connection As String

    Const _HEIGHT As Integer = 600
    Const _WIDTH As Integer = 800
    Protected scaleHeight As Double
    Protected scaleWidth As Double

    Protected dic As Dictionary(Of String, myPostion)
    Protected defalut_Field As List(Of String)
#End Region

    Private Sub FrmBillBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If GetService(GetType(System.ComponentModel.Design.IDesignerHost)) Is Nothing = False OrElse System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        load_flag = True '表示正在加载

        initForm()

        LoadData()

        load_flag = False '表示加载结束
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub initForm()
        initToolStrip()
        hs = CType(Me.objFormPara, Hashtable)
        CreateView()
        FormViewUtility.SetCommonProperty(Me.Controls, m_dic(FieldsEnum.单据类型), m_TranType, m_TranType)
        reSizeControl()
        flexSetting(Me.C1FlexGrid1, Me.C2)
        formSetting()
    End Sub

    Private Sub initToolStrip()
        m_ToolStrip = New ToolStrip()
        Me.Controls.Add(m_ToolStrip)
        m_ToolStrip.BackgroundImage = My.Resources.MenuBarImage
        m_ToolStrip.BackgroundImageLayout = ImageLayout.Stretch
        m_ToolStrip.Location = New System.Drawing.Point(0, 0)
        m_ToolStrip.Name = "m_ToolStrip"
        m_ToolStrip.Size = New System.Drawing.Size(948, 35)
        Dim item As ToolStripItem
        Dim ItemSeparator As ToolStripSeparator
        Dim Sql As String
        Dim dt As DataSet
        Dim SeparatorGroupID As Integer = 1
        Sql = "select * from t_sgl_MenuBar where isnull(FParentMenuID,'')='' and fid=" + m_TranType.ToString() + " order by FSeparatorID,FIndex"
        Sql += " select * from t_sgl_MenuBar where isnull(FParentMenuID,'')<>'' and fid=" + m_TranType.ToString() + " order by FSeparatorID,FIndex"
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
                Dim item_sun As Windows.Forms.ToolStripMenuItem
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

    Protected Function MenuListNoRights() As DataTable
        Try
            Dim Sql As String
            Dim dt As DataSet
            Sql = " select FMenuID from t_sgl_MenuBar where isnull(FShowInRights,0)=1 and FID=" + m_TranType.ToString()
            Sql += " and FMenuID not in ( select t1.FMenuID from t_sgl_MenuBar t1"
            Sql += " inner join T_CY_SGL_Riht t2 on t1.FIdentity=t2.fid and t2.FUserID=" + Me.CYUserInfo.UserID.ToString()
            Sql += " where isnull(t1.FShowInRights,0)=1 and t1.FID=" + m_TranType.ToString() + ")"
            dt = GetDataSet.GetDataset(Sql, Me.CYSysInfo.ConnStrValue)
            Return dt.Tables(0)
        Catch ex As Exception
            BillInstance.myShowMsg(ex.Message.ToString())
            Return Nothing
        End Try
    End Function

    Private Sub DropDownItems_ItemClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ItemClicked(CType(sender, ToolStripMenuItem).Name)
    End Sub

    Private Sub ToolStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
        ItemClicked(e.ClickedItem.Name)
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
            Case "mn_Save"
                'Return SaveData()
            Case "mn_Audit"
                Return AuditStatusCheck()
            Case "mn_Reject"
                Return RejectStatusCheck()
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
                Case MenuEnum.新增
                    Return AddNewBill()
                Case MenuEnum.保存
                    Return SaveData()
                Case MenuEnum.审核
                    Return AuditBill()
                Case MenuEnum.驳回
                    Return RejectBill()
                Case MenuEnum.添行

                Case MenuEnum.删行
                    Return OnDelRow()
                Case MenuEnum.打印设置
                    Return OnPrintSet()
                Case MenuEnum.预览
                    Return OnReview()
                Case MenuEnum.恢复宽度
                    Return ResumeDefaultColWidth()
                Case MenuEnum.打印
                    Return OnPrinter()
                Case MenuEnum.退出
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
        If Griddatanew.Tables(0).Rows.Count > 0 Then
            For i As Integer = 1 To C1FlexGrid1.Cols.Count - 1
                If i >= Griddatanew.Tables(0).Rows.Count Then
                    '  C1FlexGrid1.Cols(i).Width = 70
                Else
                    C1FlexGrid1.Cols(i).Width = Griddatanew.Tables(0).Rows(i)("fwidth")
                End If
            Next
        End If
        SumSet()

        Return True
    End Function

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
    End Sub

    Public Overridable Function AddNewBill() As Boolean
        Dim count As Integer
        Dim funcWd As New FindWinData
        Dim ctrl As New ControlCollection(Owner)
        ctrl = Me.Controls
        BillDate = New BLManagerOldBillData
        Dim drMenuList() As DataRow
        Dim sglbool As Boolean

        drMenuList = Griddatanewbill.Tables(0).Select("len(fdecname)>0")

        If m_InterID <= 0 Then
            BillInstance.myShowMsg("请先保存单据！")
            Return False
        End If

        isDownBill = False
        isReadOnly = False
        DelAllCanReadFields()
        For i As Integer = 0 To ctrl.Count - 1
            If ctrl.Item(i).Name.IndexOf("FlexGrid") >= 0 Then
            Else
                If Microsoft.VisualBasic.Left(ctrl.Item(i).Name, 1).ToUpper = "F" And ctrl.Item(i).Name <> "FTranType" Then
                    sglbool = False
                    For Each dr As DataRow In drMenuList
                        If ctrl.Item(i).Name = dr("FFieldName").ToString() Then
                            sglbool = True
                            Exit For
                        End If
                    Next
                    If sglbool = False Then
                        If ctrl.Item(i).Tag = "int" Then
                            CType(ctrl.Item(i), D1TextBox).Value = 0
                            If CType(ctrl.Item(i), D1TextBox).Text = "0" Then
                            Else
                                CType(ctrl.Item(i), D1TextBox).Text = ""
                            End If

                        ElseIf ctrl.Item(i).Tag = "datetime" Then
                            CType(ctrl.Item(i), D1DateTime).Text = System.DBNull.Value
                        ElseIf ctrl.Item(i).Tag = "string" Then
                            CType(ctrl.Item(i), D1TextBox).Value = ""
                            CType(ctrl.Item(i), D1TextBox).Text = ""
                        End If
                    End If
                End If
            End If
        Next

        m_InterID = 0
        FormViewUtility.SetCommonProperty(Me.Controls, "FInterID", 0, 0)
        funcWd.ravelBill(ctrl)
        C1FlexGrid1.Enabled = True
        m_BillStatus = BillInstance.BillStatusEnum.新增

        count = C1FlexGrid1.Rows.Count
        For i As Integer = 1 To count - 1
            If C1FlexGrid1.Item(1, "FKey") = "Y" Then
                C1FlexGrid1.Rows.Remove(1)
            Else
                Exit For
            End If
        Next

        SetRowNo()
        SumSet()

        billno = BillDate.getBillNo(m_TranType, Me.CYSysInfo.ConnStrValue)
        FormViewUtility.SetCommonProperty(Me.Controls, m_dic(FieldsEnum.单据编号), billno, billno)

        If OwnerProperty("FDateName") Then
            FormViewUtility.SetCommonProperty(Me.Controls, m_dic(FieldsEnum.单据日期), GetServerDate(Me.CYSysInfo.ConnStrValue).ToShortDateString())
        End If
        If OwnerProperty("FBillDateName") Then
            FormViewUtility.SetCommonProperty(Me.Controls, m_dic(FieldsEnum.制单日期), GetServerDate(Me.CYSysInfo.ConnStrValue).ToShortDateString())
        End If
        If OwnerProperty("FBillerName") Then
            FormViewUtility.SetCommonProperty(Me.Controls, m_dic(FieldsEnum.制单人), Me.CYUserInfo.UserName, Me.CYUserInfo.UserID)
        End If
        If m_isRob = 1 Then
            FormViewUtility.SetControlProperty(Me.Controls, "lbrob", "Visible", "False")
            FormViewUtility.SetCommonProperty(Me.Controls, "FRob", 1, 1)
        End If
        If OwnerProperty("FCheckerName") Then
            FormViewUtility.SetCommonProperty(Me.Controls, m_dic(FieldsEnum.审核人), "")
        End If
        If OwnerProperty("FCheckDateName") Then
            FormViewUtility.SetCommonProperty(Me.Controls, m_dic(FieldsEnum.审核日期), System.DBNull.Value)
        End If
        FormViewUtility.SetCommonProperty(Me.Controls, "FCheckDate", System.DBNull.Value)
        FormViewUtility.SetCommonProperty(Me.Controls, "FCheckerID", "")

        FormViewUtility.SetCommonProperty(Me.Controls, "FStatus", 0, 0)
        FormViewUtility.controlsUnabled(m_TranType, Me.CYSysInfo.ConnStrValue, Me.Controls)

        Return True
    End Function

    Public Overridable Function SaveCheck() As Boolean
        Dim savetj As DataSet
        Dim bentry As DataSet
        Dim ctrl As New ControlCollection(Owner)
        ctrl = Me.Controls
        Dim i As Integer, j As Integer, k As Integer

        savetj = GetDataSet.GetDataset("select * from  T_SGL_ictemplate where FID = '" & FormViewUtility.GetControlProperty(Me.Controls, "FTranType", "Text") & "'  and FNeedSave='true'", Me.CYSysInfo.ConnStrValue)

        Try
            If savetj.Tables(0).Rows.Count > 0 Then

                For j = 0 To savetj.Tables(0).Rows.Count - 1
                    For i = 0 To ctrl.Count - 1
                        If ctrl.Item(i).Name.IndexOf("FlexGrid") >= 0 Then
                        Else
                            If ctrl.Item(i).Name = savetj.Tables(0).Rows(j)("FFieldName") Then
                                If ctrl.Item(i).Tag = "int" Then
                                    If PublicSharedResource.PublicSharedFunctions.ChgNull(CType(ctrl.Item(i), D1TextBox).Value) = "" Or PublicSharedResource.PublicSharedFunctions.ChgNull(CType(ctrl.Item(i), D1TextBox).Value) = "0" Then
                                        MessageBox.Show(savetj.Tables(0).Rows(j)("FCaption") + "不能为空！", "创源提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                        Return False
                                        Exit Function

                                    End If
                                ElseIf ctrl.Item(i).Tag = "datetime" Then
                                    If PublicSharedResource.PublicSharedFunctions.ChgNull(CType(ctrl.Item(i), D1DateTime).Text) = "" Then
                                        MessageBox.Show(savetj.Tables(0).Rows(j)("FCaption") + "不能为空！", "创源提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                        Return False
                                        Exit Function
                                    End If
                                ElseIf ctrl.Item(i).Tag = "string" Or ctrl.Item(i).Tag = "int" Then
                                    If PublicSharedResource.PublicSharedFunctions.ChgNull(CType(ctrl.Item(i), D1TextBox).Text) = "" Then
                                        MessageBox.Show(savetj.Tables(0).Rows(j)("FCaption") + "不能为空！", "创源提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                        Return False
                                        Exit Function
                                    End If
                                End If

                            End If

                        End If
                    Next
                Next
            End If

            '检查没有物料的行
            Dim nullRow As Integer = 0
            For i = 1 To C1FlexGrid1.Rows.Count - 1
                If C1FlexGrid1.Item(i, "fkey") = "Y" Then
                    If nullRow > 0 Then
                        MessageBox.Show("第" & nullRow & "数据不能为空！", "创源提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        Return False
                    End If
                Else
                    nullRow = i
                End If
            Next

            bentry = GetDataSet.GetDataset("select * from  T_SGL_ictemplateentry where FID = '" & FormViewUtility.GetControlProperty(Me.Controls, "FTranType", "Text") & "'  and FCtlType=0", Me.CYSysInfo.ConnStrValue)

            If bentry.Tables(0).Rows.Count > 0 Then
                For i = 0 To bentry.Tables(0).Rows.Count - 1
                    For k = 1 To C1FlexGrid1.Rows.Count - 1
                        If k = 1 Then
                            If C1FlexGrid1.Item(1, "FKey") = "" Then
                                MessageBox.Show("表体数据不能为空！", "创源提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                Return False
                            End If
                        End If
                        If C1FlexGrid1.Item(k, "FKey") <> "" And C1FlexGrid1.Item(k, "fkey") = "Y" Then
                            For j = 1 To C1FlexGrid1.Cols.Count - 1

                                If C1FlexGrid1.Cols(j).Name = bentry.Tables(0).Rows(i)("FFieldName") Then

                                    If PublicSharedResource.PublicSharedFunctions.ChgNull(C1FlexGrid1.Item(k, bentry.Tables(0).Rows(i)("FFieldName"))) = "" Then
                                        MessageBox.Show(bentry.Tables(0).Rows(i)("FHeadCaption") + "不能为空！", "创源提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                        Return False
                                    Else
                                        If bentry.Tables(0).Rows(i)("FValuetype") = 2 Then
                                            If C1FlexGrid1.Item(k, bentry.Tables(0).Rows(i)("FFieldName")) = 0 Then
                                                MessageBox.Show(bentry.Tables(0).Rows(i)("FHeadCaption") + "不能为空！", "创源提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                                Return False
                                            End If
                                        End If
                                    End If


                                End If
                            Next
                        Else
                            Exit For
                        End If
                    Next
                Next
            End If

            For k = 1 To C1FlexGrid1.Rows.Count - 1
                If C1FlexGrid1.Item(k, "FKey") <> "" And C1FlexGrid1.Item(k, "fkey") = "Y" Then
                    For j = 1 To C1FlexGrid1.Cols.Count - 1
                        If C1FlexGrid1.Cols(j).Name = "FBatchNo" Then
                            If C1FlexGrid1.GetCellStyle(k, j).BackColor = m_BaseDataSetting.ListEditColor Then
                                If PublicSharedResource.PublicSharedFunctions.ChgNull(C1FlexGrid1.Item(k, j)) = "" Then
                                    MessageBox.Show(C1FlexGrid1.Cols(j).Caption + "不能为空！", "创源提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                    Return False
                                Else

                                End If
                            End If
                        End If
                    Next
                End If
            Next

            Return True
        Catch ex As Exception
            Throw ex
        End Try
        Return True
    End Function

    Protected Overridable Function SaveData() As Boolean
        Dim hs As New Hashtable, ds As DataSet
        Dim owner As Control
        Dim ctrl As New ControlCollection(owner)
        Dim find As New FindWinData
        'Dim splitEntry, sql, strValue2, strValue, newBillNo As String
        Dim ctr(0) As DbType, ctr2(2) As DbType
        hs = CType(Me.objFormPara, Hashtable)
        C1FlexGrid1.FinishEditing()
        panelList.Focus()

        If SaveCheck() = False Then Return False

        ctrl = Me.Controls
        ds = find.FindBillDataNew(ctrl, dic, defalut_Field)

        Return SaveBill(ds, m_TranType, FormViewUtility.GetControlProperty(Me.Controls, m_dic(FieldsEnum.单据编号), "Text"))
    End Function

    Public Function SaveBill(ByVal ds As DataSet, ByVal trantype_temp As String, ByVal billno1 As String) As Boolean
        Dim newBillno As String, haveBillNo As String, i As Integer
        Dim y As String, m As Integer, dateStr As String
        Dim hs As New Hashtable
        Dim ctr(4) As DbType
        hs = CType(Me.objFormPara, Hashtable)
        y = CType(Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Year(FormViewUtility.GetControlProperty(Me.Controls, m_dic(FieldsEnum.单据日期), "Text")), 2), String)
        m = Microsoft.VisualBasic.Month(FormViewUtility.GetControlProperty(Me.Controls, m_dic(FieldsEnum.单据日期), "Text"))
        If m < 10 Then
            dateStr = y & "0" & CType(m, String)
        Else
            dateStr = CType(y, String) & CType(m, String)
        End If
        Try
            BillDate = New BLManagerOldBillData
            If CType(FormViewUtility.GetControlProperty(Me.Controls, m_dic(FieldsEnum.内码), "Text"), Long) > 0 And Trim(billno1) = Trim(billno) Then    '当单据是修改时，单据编号被修改过，就要去判断单据编号是否已存在,否则不用判断就可保存
                '传入, 表头, 表体, 数据集, 单据类型, 单据日期(YYMM, 以做编号之用), 数据连接字符
                i = BillDate.UpdateBillData(m_dic(TableEnum.主表), m_dic(TableEnum.子表1), CType(FormViewUtility.GetControlProperty(Me.Controls, m_dic(FieldsEnum.内码), "Text"), Long), ds, Me.CYSysInfo.ConnStrValue)
                If i > 0 Then
                    m_InterID = i
                    GetDataSet.GetDataset(" exec P_SGL_Savelog  '" & CType(Me.CYUserInfo.UserID, String) & "','" & Me.FormID + FormViewUtility.GetControlProperty(Me.Controls, m_dic(FieldsEnum.单据编号), "Text") & "单据修改成功','" & System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName).AddressList(0).ToString & "'", Me.CYSysInfo.ConnStrValue)
                    MessageBox.Show("单据保存成功", "创源提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Return True
                Else
                    MessageBox.Show("单据保存失败", "创源提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Return False
                End If
            Else
                If BillInstance.isHaveSameBillNumber(m_dic(TableEnum.主表), m_dic(FieldsEnum.单据类型), m_dic(FieldsEnum.单据编号), billno1, trantype_temp, Me.CYSysInfo.ConnStrValue) Then
                    If MessageBox.Show("单据编号重复，是否自动产生新的单据编号保存单据？", clsGlobal.M_STR_HINT, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                        'newBillno = mgData.getBillNo(trantype, Me.CYSysInfo.ConnStrValue)
                        newBillno = BillDate.getNewBillNo(m_dic(TableEnum.主表), m_dic(FieldsEnum.单据编号), trantype_temp, Me.CYSysInfo.ConnStrValue)
                        FormViewUtility.SetCommonProperty(Me.Controls, m_dic(FieldsEnum.单据编号), newBillno, newBillno)      '付最新的单据编号
                        Me.billno = newBillno                   'add by nbb 缺少该行会导致再次保存会不断提示编号重复问题
                        SaveData()                 '再执行保存
                    Else
                        Return False
                    End If
                Else

                    If CType(FormViewUtility.GetControlProperty(Me.Controls, m_dic(FieldsEnum.内码), "Text"), Long) > 0 Then    '修改
                        i = BillDate.UpdateBillData(m_dic(TableEnum.主表), m_dic(TableEnum.子表1), CType(FormViewUtility.GetControlProperty(Me.Controls, m_dic(FieldsEnum.内码), "Text"), Long), ds, Me.CYSysInfo.ConnStrValue)
                        Me.billno = FormViewUtility.GetControlProperty(Me.Controls, m_dic(FieldsEnum.单据编号), "Text")
                    Else
                        '传入，表头，表体，数据集，单据类型，单据日期（YYMM，以做编号之用），数据连接字符
                        i = BillDate.InsertBillData(m_dic(TableEnum.主表), m_dic(TableEnum.子表1), ds, trantype_temp, Me.CYSysInfo.ConnStrValue)
                        FormViewUtility.SetCommonProperty(Me.Controls, m_dic(FieldsEnum.内码), i, i)
                        Me.billno = FormViewUtility.GetControlProperty(Me.Controls, m_dic(FieldsEnum.单据编号), "Text")
                    End If

                    If i > 0 Then
                        m_InterID = i
                        GetDataSet.GetDataset(" exec P_SGL_Savelog  '" & CType(Me.CYUserInfo.UserID, String) & "','" & Me.FormID + FormViewUtility.GetControlProperty(Me.Controls, m_dic(FieldsEnum.单据编号), "Text") & "单据保存成功','" & System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName).AddressList(0).ToString & "'", Me.CYSysInfo.ConnStrValue)
                        MessageBox.Show("单据保存成功", "创源提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        Return True
                    Else
                        MessageBox.Show("单据保存失败", "创源提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        Return False
                    End If
                End If
            End If

        Catch ex As Exception

            Throw ex
        End Try
    End Function '保存

    Public Overridable Function AuditStatusCheck() As Boolean
        If m_InterID <= 0 Then
            MsgBox("请先保存单据！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Me.Cursor = Cursors.Default
            Return False
        End If
        Try
            Dim _FInterIDName As String = m_dic(FieldsEnum.内码)
            Dim _tableName As String = m_dic(TableEnum.主表)
            Return BillInstance.AuditStatusCheck(_FInterIDName, _tableName, m_InterID, Me.CYSysInfo.ConnStrValue)
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Return False
        End Try
    End Function

    Public Overridable Function AuditBill() As Boolean
        Try
            Dim _value As Boolean
            Dim _FInterIDName As String = m_dic(FieldsEnum.内码)
            Dim _tableName As String = m_dic(TableEnum.主表)
            Dim _FCheckerName As String = m_dic(FieldsEnum.审核人)
            Dim _FCheckDate As String = m_dic(FieldsEnum.审核日期)
            Dim _interID As Integer = m_InterID
            _value = BillInstance.AuditBill(_FInterIDName, _FCheckerName, _FCheckDate, _tableName, _interID, Me.CYSysInfo.ConnStrValue, Me.CYUserInfo.UserID)
            If _value Then
                MsgBox("操作成功！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Else
                MsgBox("审核失败！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            End If
            Return _value
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Return False
        End Try
    End Function

    Public Overridable Function RejectStatusCheck() As Boolean
        If m_InterID <= 0 Then
            MsgBox("请先保存单据！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Me.Cursor = Cursors.Default
            Return False
        End If
        Try
            Dim _FInterIDName As String = m_dic(FieldsEnum.内码)
            Dim _tableName As String = m_dic(TableEnum.主表)
            Return BillInstance.RejectStatusCheck(_FInterIDName, _tableName, m_InterID, Me.CYSysInfo.ConnStrValue)
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Return False
        End Try
    End Function

    Public Overridable Function RejectBill() As Boolean
        Try
            Dim _value As Boolean
            Dim _FInterIDName As String = m_dic(FieldsEnum.内码)
            Dim _tableName As String = m_dic(TableEnum.主表)
            Dim _FCheckerName As String = m_dic(FieldsEnum.审核人)
            Dim _FCheckDate As String = m_dic(FieldsEnum.审核日期)
            Dim _interID As Integer = m_InterID
            _value = BillInstance.RejectBill(_FInterIDName, _FCheckerName, _FCheckDate, _tableName, _interID, Me.CYSysInfo.ConnStrValue)
            If _value Then
                MsgBox("操作成功！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Else
                MsgBox("审核失败！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            End If
            Return _value
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Return False
        End Try
    End Function

    Public Function OnDelRow() As Boolean
        Return True
    End Function

    Private Sub LoadData()

        VchCruNo = -1
        Dim billstr As String
        BillDate = New BLManagerOldBillData
        NameGirD()
        DU_Format()
        SetRowNo()
        SumSet()
        LoadContr()

        hs = CType(Me.objFormPara, Hashtable)
        If hs Is Nothing Then
            m_InterID = 0
            billstr = ""
            isReadOnly = False
        Else
            If hs.Contains("isReadOnly") Then
                isReadOnly = hs.Item("isReadOnly")
            Else
                isReadOnly = False
            End If

            If hs.Contains("DownMark") Then
                billstr = hs.Item("DownMark")
            Else
                billstr = ""
            End If

            If billstr <> "" Then
                DLinterstr = hs.Item("FInterID")
                m_InterID = -1
            Else
                DLinterstr = hs.Item("FInterID")
                m_InterID = hs.Item("FInterID")
            End If
        End If

        BeforeLoadBillData()

        If m_InterID = 0 Then   ' 新增
            billno = BillDate.getBillNo(m_TranType, Me.CYSysInfo.ConnStrValue)
            FormViewUtility.SetCommonProperty(Me.Controls, m_dic(FieldsEnum.单据编号), billno, billno)

            If OwnerProperty("FDateName") Then
                FormViewUtility.SetCommonProperty(Me.Controls, m_dic(FieldsEnum.单据日期), GetServerDate(Me.CYSysInfo.ConnStrValue).ToShortDateString())
            End If
            If OwnerProperty("FBillDateName") Then
                FormViewUtility.SetCommonProperty(Me.Controls, m_dic(FieldsEnum.制单日期), GetServerDate(Me.CYSysInfo.ConnStrValue).ToShortDateString())
            End If
            If OwnerProperty("FBillerName") Then
                FormViewUtility.SetCommonProperty(Me.Controls, m_dic(FieldsEnum.制单人), Me.CYUserInfo.UserName, Me.CYUserInfo.UserID)
            End If
            If m_isRob = 1 Then
                FormViewUtility.SetControlProperty(Me.Controls, "lbrob", "Visible", "False")
                FormViewUtility.SetCommonProperty(Me.Controls, "FRob", 1, 1)
            End If
        Else

            VchData = hs.Item("Data")
            VchCruNo = hs.Item("VchCruNo")

            If billstr <> "" Then
                ShowBillData(DLinterstr, billstr, hs.Item("type"), hs.Item("Btype"))
                billno = BillDate.getBillNo(m_TranType, Me.CYSysInfo.ConnStrValue)
                FormViewUtility.SetCommonProperty(Me.Controls, m_dic(FieldsEnum.单据编号), billno, billno)

                If OwnerProperty("FDateName") Then
                    FormViewUtility.SetCommonProperty(Me.Controls, m_dic(FieldsEnum.单据日期), GetServerDate(Me.CYSysInfo.ConnStrValue).ToShortDateString())
                End If
                If OwnerProperty("FBillDateName") Then
                    FormViewUtility.SetCommonProperty(Me.Controls, m_dic(FieldsEnum.制单日期), GetServerDate(Me.CYSysInfo.ConnStrValue).ToShortDateString())
                End If
                If OwnerProperty("FBillerName") Then
                    FormViewUtility.SetCommonProperty(Me.Controls, m_dic(FieldsEnum.制单人), Me.CYUserInfo.UserName, Me.CYUserInfo.UserID)
                End If
                If m_isRob = 1 Then
                    'FormViewUtility.SetCommonProperty(Me.Controls, "FRob", 1, 1)
                    If FormViewUtility.GetControlProperty(Me.Controls, "FRob", "Value") = 1 Then
                        FormViewUtility.SetControlProperty(Me.Controls, "lbrob", "Visible", "True")
                    Else
                        FormViewUtility.SetControlProperty(Me.Controls, "lbrob", "Visible", "False")
                    End If

                End If
            Else
                ShowBillData(m_InterID, "", "", "")
                billno = FormViewUtility.GetControlProperty(Me.Controls, m_dic(FieldsEnum.单据编号), "Text")

            End If
            If m_isRob Then
                If FormViewUtility.GetControlProperty(Me.Controls, "FRob", "Text") = -1 Then
                    FormViewUtility.SetControlProperty(Me.Controls, "lbrob", "Visible", "True")
                Else
                    FormViewUtility.SetControlProperty(Me.Controls, "lbrob", "Visible", "False")
                End If
            End If

            'If FormViewUtility.GetControlProperty(Me.Controls, "Fcancellation", "Text") = "1" Then
            '    FormViewUtility.SetControlProperty(Me.Controls, "lbcancel", "Visible", "True")
            'Else
            '    FormViewUtility.SetControlProperty(Me.Controls, "lbcancel", "Visible", "False")
            'End If

            SetRobCell()
            SetSumCell()
        End If

        '查看 修改
        BillLX(billstr)

        'setBilltype()
        'SetRowNo()
        If m_InterID = 0 Or DLinterstr <> "" Then '是新增单据或者下推单据，FEntryID重新赋值
            SetRowNo()
        End If
        Me.Text = FormViewUtility.GetControlProperty(Me.Controls, "BillName", "Text")

        ContrackBillNoSet()

        AfterLoadBillData()

    End Sub

    Public Function OnPrintSet() As Boolean
        Dim frm As FrmTemplateList = New FrmTemplateList()
        frm.CYSysInfo = Me.CYSysInfo
        frm.CYUserInfo = Me.CYUserInfo
        frm.m_TranType = m_TranType
        'frm.m_report = Report
        frm.ShowDialog()
        Return True
    End Function

    Public Function OnReview() As Boolean
        GridTemplateReportFuntion.Instance.CustomReport(Me.CYUserInfo, Me.CYSysInfo.ConnStrValue, Me.getReportData(), m_TranType, Nothing, Nothing).PrintPreview(True)
        Return True
    End Function

    Public Function OnPrinter() As Boolean
        GridTemplateReportFuntion.Instance.CustomReport(Me.CYUserInfo, Me.CYSysInfo.ConnStrValue, Me.getReportData(), m_TranType, Nothing, Nothing).Print(True)
        Return True
    End Function

    Protected Overridable Function getReportData() As DataTable
        Try

            Dim Sql As String
            Sql = "exec P_CS_IClist  '" & m_TranType.ToString() & "',' and 1=1 and u1.FInterID=" & m_InterID.ToString() & "SGLLOVEMYH  ' "
            Dim dt As New DataTable
            dt = GetDataSet.GetDataset(Sql, Me.CYSysInfo.ConnStrValue).Tables(0)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Overridable Sub BeforeLoadBillData()

    End Sub

    Protected Overridable Sub AfterLoadBillData()

    End Sub

    ''' <summary>
    ''' 窗体初始化后进行单据的特殊设置
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub ContrackBillNoSet()

    End Sub

    Public Sub ShowBillData(ByVal _interID As String, ByVal trpe As String, ByVal _ToBillType As String, ByVal _FromBillType As String)
        Dim i, j, k As Integer
        Dim bb As DataSet
        Dim bbbill As DataSet
        Dim Sql As String
        Dim dblTemp As Double = 0
        Dim dblSum As Double = 0
        Dim owner As Control
        Dim ctrl As New ControlCollection(owner)
        Dim find As New FindWinData
        Dim ctr(0) As DbType, ctr2(2) As DbType
        ctrl = Me.Controls
        GetDataSet = New BLuser
        GetDataSet = New BLuser

        For k = C1FlexGrid1.Rows.Fixed To C1FlexGrid1.Rows.Count - 1
            If PublicSharedFunctions.ChgNull(C1FlexGrid1.Rows(C1FlexGrid1.Rows.Fixed)("FKey")) = "" Then
                Exit For
            Else
                C1FlexGrid1.Rows.Remove(C1FlexGrid1.Rows.Fixed)
            End If
        Next
        C1FlexGrid1.Rows.Count = C1FlexGrid1.Rows.Count + k
        SetRowNo()

        bb = Nothing
        bbbill = Nothing

        If trpe = "" Then
            getBillData(_interID, trpe, _ToBillType, _FromBillType, bb, bbbill)
        Else
            GetDownBillData(_interID, trpe, _ToBillType, _FromBillType, bb, bbbill)
        End If



        If bb.Tables(0).Rows.Count > 0 Then

            If m_isRob Then
                FormViewUtility.SetCommonProperty(Me.Controls, "FRob", bb.Tables(0).Rows(0)("frob"), bb.Tables(0).Rows(0)("frob"))
                If FormViewUtility.GetControlProperty(Me.Controls, "FRob", "Value") = -1 Then
                    lbrob.Visible = True
                Else
                    lbrob.Visible = False
                End If
            End If

            If bb.Tables(0).Rows.Count > 48 Then
                C1FlexGrid1.Rows.Count = bb.Tables(0).Rows.Count + 2
            End If

            For i = 0 To bb.Tables(0).Rows.Count - 1
                For k = 0 To bb.Tables(0).Columns.Count - 1
                    For j = 0 To C1FlexGrid1.Cols.Count - 1
                        If C1FlexGrid1.Cols(j).Name.ToUpper() = bb.Tables(0).Columns(k).Caption.ToUpper() Then
                            If C1FlexGrid1.Cols(j).Name.ToUpper() = "FITEMID" Then
                                LoadGirdCellFormat(i + 1, bb.Tables(0).Rows(i)(k))
                            End If
                            C1FlexGrid1.Item(i + 1, bb.Tables(0).Columns(k).Caption) = bb.Tables(0).Rows(i)(k)
                            ' ''表头表体具有相同字段名
                            'If C1FlexGrid1.Cols(j).Name = "Fnote" And trpe = 1 Then
                            '    C1FlexGrid1.Item(i + 1, bb.Tables(0).Columns(k).Caption) = bb.Tables(0).Rows(i)("Fnote1")
                            'Else
                            '    C1FlexGrid1.Item(i + 1, bb.Tables(0).Columns(k).Caption) = bb.Tables(0).Rows(i)(k)
                            'End If
                            Exit For
                        End If
                    Next
                Next
                ''保质期日期会被覆盖，最后再加载一遍
                'If bb.Tables(0).Columns.Contains("FKFDate") Then
                '    C1FlexGrid1.Item(i + 1, "FKFDate") = bb.Tables(0).Rows(i)("FKFDate")
                'End If
                'If bb.Tables(0).Columns.Contains("FPeriodDate") Then
                '    C1FlexGrid1.Item(i + 1, "FPeriodDate") = bb.Tables(0).Rows(i)("FPeriodDate")
                'End If
                ' '''''''''''
            Next
        End If
        'If trpe = 3 Then
        '    Sql = "declare @FMeasureType int,@FDeliveryStyle int,@FIsFL int ;"
        '    Sql += " select @FMeasureType=FMeasureType,@FDeliveryStyle=isnull(FDeliveryStyle,0),@FIsFL=isnull(FIsFL,0) "
        '    Sql += " from t_wfl_seorder where finterid in (select ForderID from seoutstock where finterid='" & _interID & "')"
        '    Sql += "select FSalType as FSaleStyle,Fdeptid,FEmpID,FManagerID,FCustID as FSupplyID,FCustID as FOrderCustID,'21' as FTranType,FFetchAdd as  FPurposeID,FOrderID,@FDeliveryStyle as FDeliveryStyle,@FIsFL as FIsFL,FCurrencyID,FExchangeRate from SEOutStock where finterid='" & _interID & "'"
        'ElseIf trpe = 41 Then
        '    Sql = "select Fdeptid,FEmpID,FManagerID,'41' as FTranType from SEOutStock where finterid='" & _interID & "'"
        'ElseIf trpe = 4 Then
        '    Sql = "select 1 FTranType,* from POOrder where finterid= left('" & _interID & "',CHARINDEX('/','" & _interID & "',0)-1) "
        'ElseIf trpe = 72 Then
        '    Sql = "select FSalType as FSaleStyle,Fdeptid,FEmpID,FManagerID,FCustID as FSupplyID,'1' as FTranType from SEOutStock where finterid='" & _interID & "'"
        'ElseIf trpe = 5 Then
        '    Sql = "select fscdeptid Fdeptid,fempid,'21' as FTranType,fcustid as FSupplyID,fcustid as FOrderCustID,FSaleStyle ,FCurrencyID,FExchangeRate,FCustMesID as FPurposeID  from t_wfl_SEorder where finterid= left('" & _interID & "',CHARINDEX('/','" & _interID & "',0)-1) "
        'ElseIf trpe = 9 Then
        '    Sql = "select FWorkShop Fdeptid,'2' as FTranType from t_cy_ICMO where finterid='" & _interID & "'"
        'ElseIf trpe = 10 Then
        '    Sql = "select 1 as FCurrencyID,1 as FExchangeRate,fempid,'21' as FTranType,fcustid as FSupplyID from T_SGL_CYBILL where finterid='" & _interID & "'"
        'ElseIf trpe = 11 Then
        '    Sql = "select 1 as FCurrencyID,1 as FExchangeRate,101 as FSaleStyle,fempid,Fdeptid,'21' as FTranType,FCUSTOMERID as FSupplyID from t_nzy_Contract where finterid='" & _interID & "'"
        'ElseIf trpe = 93 Then
        '    Sql = "select '2001' as FTranType "
        'ElseIf trpe = 94 Then
        '    Sql = "select '1' as FTranType "
        'ElseIf trpe = 302 Or trpe = 301 Then '生产领料扫描
        '    Sql = " select FAdmin as FFmanagerid,case FTranType when 301 then 2 when 302 then 24 end as FTranType,1 as FRob from T_WB_Outlibrary where FInterID='" & _interID & "'"
        'Else
        '    Sql = "select * from icstockbill where finterid='" & _interID & "'"
        'End If


        Dim control As Control
        If bb.Tables(0).Rows.Count > 0 Then
            For i = 0 To bb.Tables(0).Columns.Count - 1
                If Microsoft.VisualBasic.Left(bb.Tables(0).Columns(i).Caption.ToUpper(), 1) <> "F" Then Continue For
                If Me.Controls.Find(bb.Tables(0).Columns(i).Caption, True).Length > 0 Then
                    control = Me.Controls.Find(bb.Tables(0).Columns(i).Caption, True)(0)
                    If control.Tag = "int" Then
                        'FormViewUtility.SetCommonProperty(Me.Controls,ctrl.Item(i).Name, PublicSharedResource.PublicSharedFunctions.ChgNull(bb.Tables(0).Rows(0)(bb.Tables(0).Columns(j).Caption)), bbbill.Tables(0).Rows(0)(bb.Tables(0).Columns(j).Caption))
                        CType(control, D1TextBox).Text = PublicSharedResource.PublicSharedFunctions.ChgNull(bb.Tables(0).Rows(0)(bb.Tables(0).Columns(i).Caption))
                        CType(control, D1TextBox).Value = PublicSharedResource.PublicSharedFunctions.ChgNullToDouble(bbbill.Tables(0).Rows(0)(bb.Tables(0).Columns(i).Caption))
                        'CType(ctrl.Item(i), D1TextBox).Value = bbbill.Tables(0).Rows(0)(bb.Tables(0).Columns(j).Caption)
                    ElseIf control.Tag = "string" Or control.Tag = "double" Then
                        CType(control, D1TextBox).Text = PublicSharedResource.PublicSharedFunctions.ChgNull(bb.Tables(0).Rows(0)(bb.Tables(0).Columns(i).Caption))
                    ElseIf control.Tag = "datetime" Then
                        CType(control, D1DateTime).Text = PublicSharedResource.PublicSharedFunctions.ChgNull(bb.Tables(0).Rows(0)(bb.Tables(0).Columns(i).Caption))
                    ElseIf control.Tag = "boolean" Then
                        CType(control, CheckBox).Checked = PublicSharedResource.PublicSharedFunctions.ChgNullToDouble(bb.Tables(0).Rows(0)(bb.Tables(0).Columns(i).Caption))
                    End If
                End If
            Next
        End If

        If OwnerProperty(m_dic(FieldsEnum.审核人)) Then
            If FormViewUtility.GetControlProperty(Me.Controls, m_dic(FieldsEnum.审核人), "Value") Is Nothing = False AndAlso FormViewUtility.GetControlProperty(Me.Controls, m_dic(FieldsEnum.审核人), "Value").ToString() = "0" Then
                FormViewUtility.SetControlProperty(Me.Controls, m_dic(FieldsEnum.审核人), "Value", Nothing)
            End If
        End If

    End Sub '单据数据加载

    Private Sub getBillData(ByVal _interID As String, ByVal trpe As String, ByVal _ToBillType As String, ByVal _FromBillType As String, ByRef _dt1 As DataSet, ByRef _dt2 As DataSet)
        Dim Sql As String

        Sql = "exec P_CS_ICBill '" & m_TranType & "','" & _interID & "'"
        _dt1 = GetDataSet.GetDataset(Sql, Me.CYSysInfo.ConnStrValue)
        Sql = " SELECT * FROM " + m_dic(TableEnum.主表) + " WHERE " + m_dic(FieldsEnum.内码) + "='" & _interID & "'"
        _dt2 = GetDataSet.GetDataset(Sql, Me.CYSysInfo.ConnStrValue)

    End Sub

    Protected Overridable Sub GetDownBillData(ByVal _interID As String, ByVal trpe As String, ByVal _ToBillType As String, ByVal _FromBillType As String, ByRef _dt1 As DataSet, ByRef _dt2 As DataSet)

    End Sub

    ''' <summary>
    ''' 增加可操作的单元格（其他单元格不可编辑）
    ''' </summary>
    ''' <param name="_fields">单元格Name(可以传递多个字段名并以逗号分隔)</param>
    ''' <remarks></remarks>
    Public Sub AddCanReadFields(ByVal _fields As String)
        Try
            If m_canEditFields Is Nothing Then
                m_canEditFields = New Hashtable()
            End If

            Dim _filesArrary() As String = _fields.Split(",")
            For Each _s As String In _filesArrary
                Dim _s_new = _s.Trim().ToUpper()
                If _s_new = "" Then Continue For
                If m_canEditFields.ContainsKey(_s_new) Then Continue For
                m_canEditFields.Add(_s_new, "true")
            Next

        Catch ex As Exception
            BillInstance.myShowMsg(ex.Message.ToString())
        End Try
    End Sub

    ''' <summary>
    ''' 删除可操作的单元格（单元格的可编辑信息交由单据其他信息来判断）
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DelAllCanReadFields()
        m_canEditFields = Nothing
    End Sub

#Region "通用设置函数"

    Public Sub NameGirD()

        GetDataSet = New BLuser
        Griddatanew = GetDataSet.GetDataset("select * from  T_SGL_ictemplateentry where FID = '" & m_TranType.ToString() & "' and FVisForBillType>0 and ffieldname<>'finterid' order by FCtlIndex", Me.CYSysInfo.ConnStrValue)
        C1FlexGrid1.Cols.Count = Griddatanew.Tables(0).Rows.Count
        Dim i As Integer
        For i = 1 To C1FlexGrid1.Cols.Count - 1

            Select Case Griddatanew.Tables(0).Rows(i)("fvaluetype")
                Case 1
                    C1FlexGrid1.Cols(i).DataType = GetType(System.Int64)
                Case 2
                    C1FlexGrid1.Cols(i).DataType = GetType(System.Decimal)
                    C1FlexGrid1.Cols(i).TextAlign = TextAlignEnum.RightCenter
                    C1FlexGrid1.Cols(i).TextAlignFixed = TextAlignEnum.CenterCenter
                    C1FlexGrid1.Cols(i).Format = "N2"
                    ' C1FlexGrid1.StartEditing(1, i)
                    C1FlexGrid1.Cols(i).Format = ""
                Case 3
                    C1FlexGrid1.Cols(i).DataType = GetType(System.String)
                    C1FlexGrid1.Cols(i).TextAlign = TextAlignEnum.LeftCenter
                    C1FlexGrid1.Cols(i).TextAlignFixed = TextAlignEnum.CenterCenter

                Case 4
                    C1FlexGrid1.Cols(i).DataType = GetType(System.DateTime)
                    C1FlexGrid1.Cols(i).TextAlign = TextAlignEnum.RightCenter
                    C1FlexGrid1.Cols(i).TextAlignFixed = TextAlignEnum.CenterCenter
                    C1FlexGrid1.Cols(i).Format = "d"
                Case 5
                    C1FlexGrid1.Cols(i).DataType = GetType(System.Boolean)
                    C1FlexGrid1.Cols(i).TextAlign = TextAlignEnum.CenterCenter
                    C1FlexGrid1.Cols(i).Format = ""
            End Select
            If Griddatanew.Tables(0).Rows(i)("fenable") = 0 Then
                Me.C1FlexGrid1.Cols(i).Style.BackColor = m_BaseDataSetting.ListNoEditColor
                ' C1FlexGrid1.Cols(i).AllowEditing = False
            Else
                Me.C1FlexGrid1.Cols(i).Style.BackColor = m_BaseDataSetting.ListEditColor
                'C1FlexGrid1.Cols(i).AllowEditing = True
            End If
            If Griddatanew.Tables(0).Rows(i)("fwidth") = -1 Then
                C1FlexGrid1.Cols(i).Width = -1
                C1FlexGrid1.Cols(i).Visible = False
            Else
                C1FlexGrid1.Cols(i).Width = Griddatanew.Tables(0).Rows(i)("fwidth")
                C1FlexGrid1.Cols(i).Visible = True
            End If
            If Griddatanew.Tables(0).Rows(i)("FLookUpCls") <> 0 Then
                Me.C1FlexGrid1.Cols(i).Style.BackColor = m_BaseDataSetting.ListCallColor
            End If
            C1FlexGrid1.Cols(i).AllowEditing = True
            C1FlexGrid1.Cols(i).Caption = Griddatanew.Tables(0).Rows(i)("fheadcaption")
            C1FlexGrid1.Cols(i).AllowSorting = False
            C1FlexGrid1.Cols(i).Name = Griddatanew.Tables(0).Rows(i)("ffieldname")
            C1FlexGrid1.AutoSizeCols()
        Next
        C1FlexGrid1.Rows(0).Height = 40
    End Sub '表体初始化

    Public Sub CUN_Format()
        Dim sql As String
        Dim sqlstr As String
        Dim bb As DataSet
        Dim i As Integer = 0
        Dim dblTemp As Integer = 0
        GetDataSet = New BLuser
        sql = ""
        For i = 0 To C1FlexGrid1.Cols.Count - 1
            Dim _colWidth As Integer = C1FlexGrid1.Cols(i).Width
            If _colWidth <= 5 Then
                _colWidth = -1
            End If
            sql = sql + _colWidth.ToString + ","
        Next


        sqlstr = "exec P_SGL_RPTZDYBAOBIAOFormat   '" + sql + "'," + m_TranType.ToString() + "," + Me.CYUserInfo.UserID.ToString

        bb = GetDataSet.GetDataset(sqlstr, Me.CYSysInfo.ConnStrValue)
    End Sub '保存宽度

    Public Sub DU_Format()
        Dim bb As DataSet
        Dim sqlstr As String
        Dim i As Integer
        GetDataSet = New BLuser
        sqlstr = "exec P_SGL_RPTZDYBAOBIAOFormatout " + Me.CYUserInfo.UserID.ToString + "," + m_TranType.ToString()
        bb = GetDataSet.GetDataset(sqlstr, Me.CYSysInfo.ConnStrValue)
        If bb.Tables(0).Rows.Count <= 0 Then Exit Sub
        If bb.Tables(0).Rows.Count > 1 Then
            For i = 0 To C1FlexGrid1.Cols.Count - 1
                If i >= bb.Tables(0).Rows.Count Then
                    '  C1FlexGrid1.Cols(i).Width = 70
                Else
                    If bb.Tables(0).Rows(i)("FValue") > 10 Then
                        C1FlexGrid1.Cols(i).Width = bb.Tables(0).Rows(i)("FValue")
                    Else
                        C1FlexGrid1.Cols(i).Width = -1
                    End If
                End If
            Next
        End If
        C1FlexGrid1.Cols(0).Width = 35
    End Sub '读取宽度

    '施国良以前的老的设置红蓝字方式
    Public Sub SetRobCell()
        If m_isRob = 0 Then Exit Sub
        Dim i, j As Integer
        Dim bb As DataSet
        Dim sqlstr As String
        GetDataSet = New BLuser
        sqlstr = "SELECt * FROM T_SGL_ictemFormula  where fid='" + m_TranType.ToString() + "'  and fisrob=1 "
        bb = GetDataSet.GetDataset(sqlstr, Me.CYSysInfo.ConnStrValue)
        If bb.Tables(0).Rows.Count > 0 Then
            For j = 0 To bb.Tables(0).Rows.Count - 1
                For i = 1 To C1FlexGrid1.Rows.Count - 1
                    If CType((C1FlexGrid1.Item(i, "fitemid")), Double) > 0 Then
                        If CType((C1FlexGrid1.Item(i, bb.Tables(0).Rows(j)("fname"))), Double) > 0 Then
                            If FormViewUtility.GetControlProperty(Me.Controls, "FRob", "Value") = -1 Then
                                C1FlexGrid1.Item(i, bb.Tables(0).Rows(j)("fname")) = -1 * Math.Abs(CType((C1FlexGrid1.Item(i, bb.Tables(0).Rows(j)("fname"))), Double))
                            End If
                        Else
                            If FormViewUtility.GetControlProperty(Me.Controls, "FRob", "Value") = 1 Then
                                C1FlexGrid1.Item(i, bb.Tables(0).Rows(j)("fname")) = Math.Abs(CType((C1FlexGrid1.Item(i, bb.Tables(0).Rows(j)("fname"))), Double))
                            End If
                        End If
                    Else
                        Exit For
                    End If
                Next
            Next
        End If   ' SetSumCell()
    End Sub '红蓝字的转换

    Public Sub SetSumCell()
        Dim i, j As Integer
        Dim bb As DataSet
        Dim sqlstr As String
        Dim dblTemp As Double = 0
        Dim dblSum As Double = 0

        GetDataSet = New BLuser
        sqlstr = "SELECt distinct fname FROM T_SGL_ictemFormula  where fid='" + m_TranType.ToString() + "' and fissum=1"
        bb = GetDataSet.GetDataset(sqlstr, Me.CYSysInfo.ConnStrValue)
        If bb.Tables(0).Rows.Count > 0 Then
            For j = 0 To bb.Tables(0).Rows.Count - 1
                dblSum = 0
                dblTemp = 0
                For i = 1 To C1FlexGrid1.Rows.Count - 1
                    If CType((C1FlexGrid1.Item(i, "fitemid")), Double) > 0 Then

                        dblTemp = C1FlexGrid1.Item(i, C1FlexGrid1.Cols(bb.Tables(0).Rows(j)("fname")).Index)

                        dblSum = dblSum + dblTemp


                    Else
                        Exit For
                    End If
                Next
                C2.Item(0, C1FlexGrid1.Cols(bb.Tables(0).Rows(j)("fname")).Index) = CType(dblSum, Double)
            Next
        End If   ' SetSumCell()
    End Sub '汇总

    Private Sub SetRowNo()
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
    End Sub '设置行号

    Public Sub SumSet()
        Dim i As Integer
        C2.Rows.Count = 0
        C2.Rows.Count = 1
        C2.Cols.Count = C1FlexGrid1.Cols.Count
        For i = 0 To C1FlexGrid1.Cols.Count - 1
            C2.Cols(i).DataType = C1FlexGrid1.Cols(i).DataType
            C2.Cols(i).Format = C1FlexGrid1.Cols(i).Format
            C2.Cols(i).Visible = C1FlexGrid1.Cols(i).Visible
            C2.Cols(i).Width = C1FlexGrid1.Cols(i).Width
            C2.BackColor = m_BaseDataSetting.ListTotalColor
            C2.Styles.Highlight.BackColor = m_BaseDataSetting.ListTotalColor
            C2.Item(0, 0) = "合计"
            C2.Cols(i).AllowEditing = False
        Next
    End Sub '合计行设置

    Public Sub LoadContr()
        Dim owner As Control
        Dim ctrl As New ControlCollection(owner)
        Dim find As New FindWinData
        Dim ctr(0) As DbType, ctr2(2) As DbType
        Dim i, j, z As Integer
        ctrl = Me.Controls
        GetDataSet = New BLuser
        Griddatanewbill = GetDataSet.GetDataset("select * from  T_SGL_ictemplate where FID = '" & m_TranType.ToString() & "'  and len(FContrName)>0", Me.CYSysInfo.ConnStrValue)

        Try
            If Griddatanewbill.Tables(0).Rows.Count > 0 Then

                For j = 0 To Griddatanewbill.Tables(0).Rows.Count - 1
                    For i = 0 To ctrl.Count - 1
                        If ctrl.Item(i).Name.IndexOf("FlexGrid") >= 0 Then
                        Else
                            If ctrl.Item(i).Name = Griddatanewbill.Tables(0).Rows(j)("FFieldName") Then
                                If Griddatanewbill.Tables(0).Rows(j)("fdec") > 0 And ctrl.Item(i).Tag = "int" Then
                                    CType(ctrl.Item(i), D1TextBox).Value = Griddatanewbill.Tables(0).Rows(j)("fdec")
                                    CType(ctrl.Item(i), D1TextBox).Text = Griddatanewbill.Tables(0).Rows(j)("fdecname")
                                End If
                                If Griddatanewbill.Tables(0).Rows(j)("fdec") > 0 And ctrl.Item(i).Tag = "string" Then
                                    CType(ctrl.Item(i), D1TextBox).Text = Griddatanewbill.Tables(0).Rows(j)("fdecname")
                                End If
                                If ctrl.Item(i).Tag = "int" Or ctrl.Item(i).Name = "FFetchAdd" Then
                                    CType(ctrl.Item(i), D1TextBox).ItemClassID = Griddatanewbill.Tables(0).Rows(j)("flookupcls")
                                End If
                            End If
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub '初始化表头

    Public Sub BillLX(ByVal modle As String) '单据类型
        Dim ctrl As New ControlCollection(Owner)
        Dim funcWd As New FindWinData
        If modle = "find" Then
            ControlStatus(1)
            ctrl = Me.Controls
            funcWd.LockBill(ctrl)
            ' C1FlexGrid1.Cols("FSplitsecQty").Width = 0
        ElseIf modle = "edit" Or modle = "" Then
            ControlStatus(0)
        Else
            ControlStatus(0)
        End If
    End Sub '单据类型

    '需要子类中重写
    Protected Overridable Sub ControlStatus(ByVal type As Integer)
        Try
            'If StrMYH <> "SGLLOVE" Then
            '    If RightDate.Tables(0).Rows(0)(0) <> -1 Then
            '        For i As Integer = 0 To RightDate.Tables(0).Rows.Count - 1
            '            If RightDate.Tables(0).Rows(i)("fshow") = 0 Then
            '                m_ToolStrip.Items.Find(RightDate.Tables(0).Rows(i)("fnumber"), True)(0).Enabled = False
            '                'm_ToolStrip.Items(RightDate.Tables(0).Rows(i)("fnumber")).Enabled = False
            '                'Else
            '                '    m_ToolStrip.Items(RightDate.Tables(0).Rows(i)("fnumber")).Enabled = True
            '            End If

            '        Next
            '    Else
            '    End If
            'Else
            '    For i As Integer = 0 To m_ToolStrip.Items.Count - 1
            '        m_ToolStrip.Items(i).Enabled = False
            '    Next
            'End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub LoadGirdCellFormat(ByVal row As Integer, ByVal itemd As Integer)
        Dim rg As CellRange
        Dim Girddata As DataSet
        GetDataSet = New BLuser
        Dim decmname As String
        Dim colname As String
        Dim strsql As String
        Dim i As Integer
        Dim Girddatatb() As DataRow
        Dim myhsgl As DataSet
        For i = 1 To C1FlexGrid1.Cols.Count - 1
            rg = C1FlexGrid1.GetCellRange(row, C1FlexGrid1.Cols(Griddatanew.Tables(0).Rows(i)("ffieldname")).Index)
            If Griddatanew.Tables(0).Rows(i)("fenable") = 0 Then
                rg.StyleNew.BackColor = m_BaseDataSetting.ListNoEditColor
            Else
                rg.StyleNew.BackColor = m_BaseDataSetting.ListEditColor
            End If
            If Griddatanew.Tables(0).Rows(i)("FLookUpCls") <> 0 Then
                rg.StyleNew.BackColor = m_BaseDataSetting.ListCallColor
            End If
        Next
        strsql = "exec P_SGL_Icitemresel  4," + itemd.ToString
        myhsgl = GetDataSet.GetDataset(strsql, Me.CYSysInfo.ConnStrValue)
        Girddata = GetDataSet.GetDataset("exec P_SGL_GirdFormat '" & m_TranType.ToString() & "'", Me.CYSysInfo.ConnStrValue)
        For i = 0 To Girddata.Tables(1).Rows.Count - 1
            decmname = Girddata.Tables(1).Rows(i)(0)

            Girddatatb = Girddata.Tables(0).Select("FFORMAT='" & decmname & "'")
            If decmname = "FAmountDecimal" Then
                decmname = "FPriceDecimal"
            End If
            For Each dr As DataRow In Girddatatb
                colname = dr("FFieldName").ToString()
                If C1FlexGrid1.Cols(colname) Is Nothing Then
                Else

                    rg = C1FlexGrid1.GetCellRange(row, C1FlexGrid1.Cols(colname).Index)
                    rg.Style = C1FlexGrid1.Styles("System.Decimal")
                    If Len(Girddata.Tables(1).Rows(i)(0)) < 3 Then
                        rg.StyleNew.Format = "N" + Girddata.Tables(1).Rows(i)(0).ToString
                    Else
                        If IsDBNull(myhsgl.Tables(0).Rows(0)(decmname)) = True Then
                            rg.StyleNew.Format = "N0"
                        Else
                            Select Case myhsgl.Tables(0).Rows(0)(decmname)
                                Case 0
                                    rg.StyleNew.Format = "N0"
                                Case 1
                                    rg.StyleNew.Format = "N1"
                                Case 2
                                    rg.StyleNew.Format = "N2"
                                Case 3
                                    rg.StyleNew.Format = "N3"
                                Case 4
                                    rg.StyleNew.Format = "N4"
                                Case 5
                                    rg.StyleNew.Format = "N5"
                                Case 6
                                    rg.StyleNew.Format = "N6"
                            End Select
                        End If
                    End If
                End If
            Next
        Next
    End Sub

    Protected Overridable Function OnEntryCall(ByVal _row As Integer, ByVal _col As Integer, ByRef dsTable As DataTable) As Boolean
        'Dim dsTable As DataTable
        Dim hs As New Hashtable
        Dim i As Integer = 0, Sql As Integer
        Dim entryid As String
        Dim newform As New SGL.BaseData.FrmItems
        Dim newform3 As New SGL.BaseData.Frmmessage
        Dim Girddatatb() As DataRow

        If _row <= 0 Or _col <= 0 Then Exit Function
        If FormViewUtility.GetControlProperty(Me.Controls, "FStatus", "Value") > 0 Then
            Return False
        End If

        If C1FlexGrid1.Item(_row - 1, "fitemid") Is Nothing = True And _row <> 0 Then ' 上一行需要已经填写物料
            Return False
        Else
            If C1FlexGrid1.Item(_row, "fitemid") Is Nothing = True And C1FlexGrid1.Cols(_col).Name <> "CItemNumber" Then '必须先填写物料信息
                Return False
            End If
        End If

        If C1FlexGrid1.Cols(_col).Name = "CItemNumber" Then      '物料
            newform.S_Classid = 4
            newform.constr = Me.CYSysInfo.ConnStrValue
            newform.ShowDialog()
            If newform.RtnDataTable.Tables.Count > 0 Then
                dsTable = newform.RtnDataTable.Tables(0)
                entryid = PublicSharedFunctions.ChgNull(C1FlexGrid1.Item(C1FlexGrid1.Row, "FEntryID"))
                C1FlexGrid1.Rows(C1FlexGrid1.Row).Clear(ClearFlags.All)
                C1FlexGrid1.Item(C1FlexGrid1.Row, "FEntryID") = entryid
                C1FlexGrid1.Item(C1FlexGrid1.Row, "FKey") = "Y"
                GirdCellFormat(C1FlexGrid1.Row, dsTable)
                Girddate(C1FlexGrid1.Row, dsTable, C1FlexGrid1.Cols(C1FlexGrid1.Col).Name)
                '建议增加特性事件

                Return True
            Else
                Return False
            End If

        End If

        If C1FlexGrid1.GetCellStyle(_row, _col).BackColor = m_BaseDataSetting.ListNoEditColor Then Return False '不可编辑状态

        Girddatatb = Griddatanew.Tables(0).Select("ffieldname='" & C1FlexGrid1.Cols(_col).Name & "'")
        For Each dr As DataRow In Girddatatb
            Sql = dr("FLookUpCls")
        Next
        If Sql > 0 Then
            newform.S_Classid = Sql
            newform.constr = Me.CYSysInfo.ConnStrValue
            newform.ShowDialog()
            If newform.RtnDataTable.Tables.Count > 0 Then
                dsTable = newform.RtnDataTable.Tables(0)
                Girddatenew(_row, dsTable, C1FlexGrid1.Cols(_col).Name)
                Return True
            End If
        End If
        If Sql < 0 Then
            newform3.S_Classid = Sql * -1
            'newform3.IM = C1FlexGrid1.Item(C1FlexGrid1.Row, "fitemid")
            newform3.constr = Me.CYSysInfo.ConnStrValue
            newform3.ShowDialog()
            If newform3.RtnDataTable.Tables.Count > 0 Then
                dsTable = newform3.RtnDataTable.Tables(0)
                Girddatenew(C1FlexGrid1.Row, dsTable, C1FlexGrid1.Cols(C1FlexGrid1.Col).Name)
                Return True
            End If
        End If

        Return False
    End Function

    Protected Overridable Function BeforeEntryCall(ByVal _row As Integer, ByVal _col As Integer) As Boolean
        If CanFieldEdit(_col) = False Then Return False
        Return True
    End Function

    Protected Sub AfterEntryCall(ByVal _row As Integer, ByVal _col As Integer, ByVal dsTable As DataTable)

    End Sub

    Public Sub Girddatenew(ByVal row As Integer, ByVal dasgl As DataTable, ByVal name As String)
        Dim colname As String
        Dim Girddatatb() As DataRow
        Girddatatb = Griddatanew.Tables(0).Select("frelationname='" & name & "'")
        For Each dr As DataRow In Girddatatb
            colname = dr("freturnname").ToString()
            C1FlexGrid1.Item(row, dr("FFieldName")) = dasgl.Rows(0)(colname)
        Next
    End Sub '表体核算项目返回除物料其他

    Public Sub GirdCellFormat(ByVal row As Integer, ByVal dasgl As DataTable) '表体数字字段的精度控制 入录单据时的控制
        Dim rg As CellRange
        Dim Girddata As DataSet
        GetDataSet = New BLuser
        Dim decmname As String
        Dim colname As String
        Dim i As Integer
        Dim Girddatatb() As DataRow
        For i = 1 To C1FlexGrid1.Cols.Count - 1
            rg = C1FlexGrid1.GetCellRange(row, C1FlexGrid1.Cols(Griddatanew.Tables(0).Rows(i)("ffieldname")).Index)
            If Griddatanew.Tables(0).Rows(i)("fenable") = 0 Then
                rg.StyleNew.BackColor = m_BaseDataSetting.ListNoEditColor
            Else
                rg.StyleNew.BackColor = m_BaseDataSetting.ListEditColor
            End If
            If Griddatanew.Tables(0).Rows(i)("FLookUpCls") <> 0 Then
                rg.StyleNew.BackColor = m_BaseDataSetting.ListCallColor
            End If
        Next
        Girddata = GetDataSet.GetDataset("exec P_SGL_GirdFormat '" & m_TranType.ToString() & "'", Me.CYSysInfo.ConnStrValue)
        For i = 0 To Girddata.Tables(1).Rows.Count - 1
            decmname = Girddata.Tables(1).Rows(i)(0)

            Girddatatb = Girddata.Tables(0).Select("FFORMAT='" & decmname & "'")
            If decmname = "FAmountDecimal" Then
                decmname = "FPriceDecimal"
            End If
            For Each dr As DataRow In Girddatatb
                colname = dr("FFieldName").ToString()
                If C1FlexGrid1.Cols(colname) Is Nothing Then
                Else

                    rg = C1FlexGrid1.GetCellRange(row, C1FlexGrid1.Cols(colname).Index)
                    rg.Style = C1FlexGrid1.Styles("System.Decimal")
                    If Len(Girddata.Tables(1).Rows(i)(0)) < 3 Then
                        rg.StyleNew.Format = "N" + Girddata.Tables(1).Rows(i)(0).ToString
                    Else
                        If IsDBNull(dasgl.Rows(0)(decmname)) = True Then
                            rg.StyleNew.Format = "N0"
                        Else
                            Select Case dasgl.Rows(0)(decmname)
                                Case 0
                                    rg.StyleNew.Format = "N0"
                                Case 1
                                    rg.StyleNew.Format = "N1"
                                Case 2
                                    rg.StyleNew.Format = "N2"
                                Case 3
                                    rg.StyleNew.Format = "N3"
                                Case 4
                                    rg.StyleNew.Format = "N4"
                                Case 5
                                    rg.StyleNew.Format = "N5"
                                Case 6
                                    rg.StyleNew.Format = "N6"
                            End Select
                        End If
                    End If
                End If
            Next
        Next

    End Sub '表体数字字段的精度控制 入录单据时的控制

    Public Sub Girddate(ByVal row As Integer, ByVal dasgl As DataTable, ByVal name As String) '核算项目返回物料
        Dim colname As String
        Dim Girddatatb() As DataRow
        Girddatatb = Griddatanew.Tables(0).Select("FRelationID='" & name & "'")
        For Each dr As DataRow In Girddatatb
            colname = dr("FAction").ToString()
            C1FlexGrid1.Item(row, dr("FFieldName")) = dasgl.Rows(0)(colname)
        Next
    End Sub '表体核算项目返回物料
#End Region

#Region "自定义窗体事件"
    'FInterIDName, FNumberName, FTranTypeName, FDateName, FCheckerName, FCheckDateName, FBillerName, FBillDateName, FIsRob

    Public Sub InitView()
        m_dic = New Dictionary(Of String, String)
        m_dic = BillInstance.BilledDictionary(m_TranType, PublicSharedResource.PublicSharedFunctions.consglstr)
        '红蓝字
        If m_dic(FieldsEnum.红蓝字) = "1" Then
            m_isRob = True
        Else
            m_isRob = False
        End If


    End Sub

    Private Sub CreateView()
        dic = New Dictionary(Of String, myPostion)

        '创建默认控件
        createDefault()

        '创建数据库定义控件
        dic = FormViewUtility.CreateView(Me.m_TranType, Me.CYSysInfo.ConnStrValue, Me.Controls)

        '默认事件统一绑定
        For Each cm As KeyValuePair(Of String, myPostion) In dic
            If Me.Controls.Find(cm.Key.ToString(), True).Length > 0 Then
                If TypeOf Me.Controls.Find(cm.Key.ToString(), True)(0) Is D1TextBox Then
                    Dim dtl As D1TextBox = CType(Me.Controls.Find(cm.Key.ToString(), True)(0), D1TextBox)
                    AddHandler CType(dtl, D1TextBox).DoubleClick, AddressOf Me.d1TextBox_DoubleClick
                    AddHandler CType(dtl, D1TextBox).UserControlKeyDown, AddressOf d1TextBox_UserControlKeyDown
                    AddHandler CType(dtl, D1TextBox).myValidated, AddressOf d1TextBox_myValidated
                    AddHandler CType(dtl, D1TextBox).D1TextChanged, AddressOf d1TextBox_TextChanged
                End If
            End If '
        Next

        '增加特殊事件绑定
        AddSpecialEvent()

        '触发控件自动调整
        reSizeControl()
    End Sub

    '增加特殊事件绑定
    Protected Overridable Sub AddSpecialEvent()

    End Sub

    '创建默认的字段
    Protected Overridable Sub createDefault()
        defalut_Field = New List(Of String)

        Dim cl As D1TextBox

        cl = New D1TextBox
        cl.Name = "FInterID"
        cl.Text = "0"
        cl.Value = "0"
        cl.Tag = "int"
        Me.Controls.Add(cl)
        defalut_Field.Add(cl.Name)

        cl = New D1TextBox
        cl.Name = "FTranType"
        cl.Text = "0"
        cl.Value = "0"
        cl.Tag = "int"
        Me.Controls.Add(cl)
        defalut_Field.Add(cl.Name)

        cl = New D1TextBox
        cl.Name = "FStatus"
        cl.Text = "0"
        cl.Value = "0"
        cl.Tag = "int"
        Me.Controls.Add(cl)
        defalut_Field.Add(cl.Name)

        If m_isRob = 1 Then
            cl = New D1TextBox
            cl.Name = "FRob"
            cl.Text = "1"
            cl.Value = "1"
            cl.Tag = "int"
            Me.Controls.Add(cl)
            defalut_Field.Add(cl.Name)
        End If

    End Sub

    Private Sub reSizeControl()
        scaleHeight = CType(Me.Size.Height / CType(_HEIGHT, Double), Double)
        scaleWidth = CType(Me.Size.Width / CType(_WIDTH, Double), Double)
        Dim ctl As Control

        If dic Is Nothing Then Exit Sub
        For Each cm As KeyValuePair(Of String, myPostion) In dic
            ctl = Me.Controls.Find(cm.Key.ToString(), True)(0)
            ctl.Left = CType(((CType(cm.Value, myPostion)).Left * scaleWidth), Integer)
            ctl.Top = CType(((CType(cm.Value, myPostion)).Top * scaleHeight), Integer)
            ctl.Height = CType(((CType(cm.Value, myPostion)).Height * scaleHeight), Integer)
            ctl.Width = CType(((CType(cm.Value, myPostion)).Width * scaleWidth), Integer)
        Next

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

#Region "单据头双击事件"
    Private Sub d1TextBox_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim dtb As D1TextBox = CType(sender, D1TextBox)
        call_Items(dtb)
    End Sub
#End Region

#Region "单据头F7事件"
    Private Sub d1TextBox_UserControlKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F7 Then
            Dim dtb As D1TextBox = CType(sender, D1TextBox)
            call_Items(dtb)
        ElseIf e.KeyCode = 13 Then
            System.Windows.Forms.SendKeys.Send("{Tab}")
        End If
    End Sub
#End Region

#Region "TextBox的change事件"
    Public Overridable Sub d1TextBox_TextChanged(ByVal sender As Object, ByVal e As TextChangeEventArgs)

    End Sub
#End Region

    Private Sub d1TextBox_myValidated(ByVal sender As Object, ByVal e As EventArgs)
        Dim dtb As D1TextBox = CType(sender, D1TextBox)
        If dtb.ItemClassID > 0 Then
            If dtb.Text <> "" Then
                GetData = GetDataSet.GetDataset("select * from T_Item where (fnumber='" & dtb.Text & "' or fname='" & dtb.Text & "') and FItemClassID= " & dtb.ItemClassID.ToString(), Me.CYSysInfo.ConnStrValue)
                If GetData.Tables(0).Rows.Count > 0 Then
                    dtb.Text = GetData.Tables(0).Rows(0)("Fname")
                    dtb.Value = GetData.Tables(0).Rows(0)("fitemid")
                Else
                    MessageBox.Show("无此基础资料！", "SGL提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    dtb.Text = ""
                    dtb.Focus()
                End If
            Else
                dtb.Value = "0"
            End If
        ElseIf dtb.ItemClassID < 0 Then
            If dtb.Text <> "" Then
                Dim S_Classid As String = (-1 * dtb.ItemClassID).ToString()
                Dim Sglstr As String
                If S_Classid = "99999" Then
                    Sglstr = "select fid as fitemid,* from  icbilltype where FNumber='" & dtb.Text & "' or fname='" & dtb.Text & "'"
                ElseIf S_Classid = "88888" Then
                    Sglstr = "select  * from  t_Settle where FNumber='" & dtb.Text & "' or fname='" & dtb.Text & "'"
                ElseIf S_Classid = "66666" Then   '币别
                    Sglstr = " select fcurrencyid as FItemID, FName ,FExchangeRate from  t_currency where fcurrencyid>0 and FNumber='" & dtb.Text & "' or fname='" & dtb.Text & "'"
                ElseIf S_Classid = "77777" Then
                    Sglstr = "Select FItemID,FName From t_rp_systemenum Where FNumber='" & dtb.Text & "' or fname='" & dtb.Text & "'"
                ElseIf S_Classid = "10016" Then  '付款单
                    Sglstr = "Select FItemID ,FName  From t_rp_systemenum Where FType=14 and FNumber='" & dtb.Text & "' or fname='" & dtb.Text & "'"
                ElseIf S_Classid = "10022" Then  '其他应付单单据类型
                    Sglstr = "Select FItemID ,FName  From t_rp_systemenum Where FType=12 and FNumber='" & dtb.Text & "' or fname='" & dtb.Text & "'"
                ElseIf S_Classid = "10021" Then  '其他应shou单单据类型
                    Sglstr = "Select FItemID as FItemID,FName  From t_rp_systemenum Where FType=11 and FNumber='" & dtb.Text & "' or fname='" & dtb.Text & "'"
                ElseIf S_Classid = "1" Then '科目
                    Sglstr = "select FAccountID as FItemID,FName,FDetail from t_account where (FNumber='" & dtb.Text & "' or fname='" & dtb.Text & "') and FDelete=0"
                ElseIf S_Classid = "88889" Then
                    Sglstr = "select FInterID as FItemID,FBillNo as FName from seoutstock where fstatus>0 and isnull(fclosed,0)=0 and FBillNo ='" & dtb.Text & "'"
                ElseIf S_Classid > 1000000 Then
                    Dim tempDt As DataSet
                    Sglstr = " select FSQL from t_CS_LookUpSQL where FLookUpID=" + S_Classid.ToString()
                    tempDt = GetDataSet.GetDataset(Sglstr, Me.CYSysInfo.ConnStrValue)
                    Sglstr = "select * into #dsub_" + S_Classid.ToString() + " from " + tempDt.Tables(0).Rows(0)("FSQL").ToString().Replace("^", "'")
                    Sglstr += " select fitemid ,fname from #dsub_" + S_Classid.ToString() + "  where FNumber='" & dtb.Text & "' or fname='" & dtb.Text & "'"
                    Sglstr += "   drop table #dsub_" + S_Classid.ToString()
                Else
                    Sglstr = "select FInterID as FItemID,FName from t_submessage where (fid='" & dtb.Text & "' or fname='" & dtb.Text & "') and FTypeID=" & S_Classid
                End If
                GetData = GetDataSet.GetDataset(Sglstr, Me.CYSysInfo.ConnStrValue)
                If GetData.Tables(0).Rows.Count > 0 Then
                    If S_Classid = "1" Then
                        If GetData.Tables(0).Rows(0)("FDetail") = True Then
                            dtb.Text = GetData.Tables(0).Rows(0)("FName")
                            dtb.Value = GetData.Tables(0).Rows(0)("FItemID")
                        Else
                            MessageBox.Show("此科目不是明细科目！", "创源提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                            dtb.Text = ""
                            dtb.Value = 0
                            dtb.Focus()
                        End If
                    Else
                        dtb.Text = GetData.Tables(0).Rows(0)("FName")
                        dtb.Value = GetData.Tables(0).Rows(0)("FItemID")
                    End If
                Else
                    MessageBox.Show("无此基础资料！", "创源提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    dtb.Text = ""
                    dtb.Focus()
                End If
            Else
                dtb.Value = "0"
            End If
        End If
    End Sub

    Protected Function OwnerProperty(ByVal _id As String) As Boolean
        If m_dic Is Nothing = True Then Return False

        If m_dic.ContainsKey(_id) = False Then Return False

        If m_dic(_id) Is Nothing = True Then Return False

        If m_dic(_id) = "" Then Return False

        Return True
    End Function


    '锁定单据
    Protected Sub LockBill()
        Dim ctrl As New ControlCollection(Owner)
        Dim funcWd As New FindWinData
        ctrl = Me.Controls
        funcWd.LockBill(ctrl)
        'C1FlexGrid1.Enabled = False
        AddCanReadFields("") '增加空的可编辑单元格的效果等同于锁定所有单元格
    End Sub

    '解锁单据
    Protected Sub UnLockBill()
        Dim ctrl As New ControlCollection(Owner)
        Dim funcWd As New FindWinData
        ctrl = Me.Controls
        funcWd.ravelBill(ctrl)
        'C1FlexGrid1.Enabled = True
        DelAllCanReadFields()
    End Sub

#Region "单据头F7或者双击调用处理"

    Protected Sub call_Items(ByVal d1tb As D1TextBox)
        Dim dstable As DataTable
        If d1tb.ItemClassID = 0 Then Me.Cursor = Cursors.Default : Exit Sub
        Dim _sqlWhere As String = ""
        _sqlWhere = init_SqlWhere_byFieldName(d1tb.Name, d1tb.ItemClassID)
        dstable = Loaditamdate(d1tb.ItemClassID.ToString(), _sqlWhere)

        If dstable Is Nothing = False Then
            d1tb.Text = dstable.Rows(0)("Fname")
            d1tb.Value = dstable.Rows(0)("fitemid")
            relationFieldsCall(d1tb.Name, dstable)
            AddSpecialCall(d1tb, dstable)
        End If
    End Sub

    ''' <summary>
    ''' F7调用前的前置条件
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function init_SqlWhere_byFieldName(ByVal _fieldName As String, ByVal _itemClassID As Integer) As String
        Return ""
    End Function

    '关联字段自动赋值
    Private Sub relationFieldsCall(ByVal _relaionsName As String, ByVal _dtable As DataTable)
        Try
            Dim Sql As String, Sql2 As String, Sql3 As String
            Dim dt As DataSet, dt2 As DataSet, dt3 As DataSet
            Sql = "select FID,FFieldName,FNameNew,isnull(ftablealias,'') as ftablealias,FLookUpCls,FRelationName, FReturnName from t_sgl_ictemplate where FVisForBillType=1 and fid=" + m_TranType.ToString() + " and FRelationName='" + _relaionsName + "'" + vbCrLf
            'Sql += " select t1.FID,FFieldName,FReturnName,isnull(t2.ftablename11,'') as ftablename11,isnull(ffieldname11,'') as ffieldname11 from #t1 t1" + vbCrLf
            'Sql += "left join T_SGL_ictablerelation t2 on ftablealias<>'' and t1.FID=t2.FID and t1.FFieldName=t2.ffieldname and t1.ftablealias=ftablenamealias11"
            dt = GetDataSet.GetDataset(Sql, Me.CYSysInfo.ConnStrValue)
            For Each _drow As DataRow In dt.Tables(0).Rows
                Dim _FieldName As String = _drow("FFieldName").ToString()
                Dim _ReturnName As String = _drow("FReturnName").ToString()
                Dim _tablealias As String = _drow("ftablealias").ToString()
                Dim _NameNew As String = _drow("FNameNew").ToString()
                Dim _FLookUpCls As Integer = _drow("FLookUpCls")
                If FormViewUtility.haveControlByID(Me.Controls, _FieldName) = False Then Continue For
                If _tablealias <> "" And _tablealias.ToLower() <> "v1" And _tablealias.ToLower() <> "u1" And _FLookUpCls > 0 Then
                    Sql2 = "select * from T_SGL_ictablerelation where FID=" + m_TranType.ToString() + " and FFieldName='" + _FieldName + "' and ftablenamealias11='" + _tablealias + "'"
                    dt2 = GetDataSet.GetDataset(Sql2, Me.CYSysInfo.ConnStrValue)
                    If dt2.Tables(0).Rows.Count > 0 Then
                        Dim _realTableName As String = dt2.Tables(0).Rows(0)("ftablename11").ToString()
                        Dim _relationName As String = dt2.Tables(0).Rows(0)("ffieldname11").ToString()
                        Sql3 = "select " + _NameNew + " as FName from " + _realTableName + " where " + _relationName + "=" + _dtable.Rows(0)(_ReturnName).ToString()
                        dt3 = GetDataSet.GetDataset(Sql3, Me.CYSysInfo.ConnStrValue)
                        If dt3.Tables(0).Rows.Count > 0 Then
                            FormViewUtility.SetCommonProperty(Me.Controls, _FieldName, dt3.Tables(0).Rows(0)("FName"), _dtable.Rows(0)(_ReturnName))
                        End If
                    End If
                Else '没有关联表，直接Text赋值
                    If _dtable.Columns.Contains(_ReturnName) Then
                        FormViewUtility.SetCommonProperty(Me.Controls, _FieldName, _dtable.Rows(0)(_ReturnName))
                    End If
                End If
            Next
        Catch ex As Exception
            BillInstance.myShowMsg(ex.Message.ToString())
        End Try
    End Sub

    '特殊字段的调用处理
    Protected Overridable Sub AddSpecialCall(ByVal d1tb As D1TextBox, ByVal dstable As DataTable)

    End Sub

    Public Function Loaditamdate(ByVal itm As String, ByVal _sqlWhere As String) As System.Data.DataTable
        Dim newform As New SGL.BaseData.Frmaccount
        Dim newform2 As New SGL.BaseData.FrmItems
        Dim newform3 As New SGL.BaseData.Frmmessage
        Dim clid As Integer
        Dim ssss As DataTable
        clid = itm
        If clid = -1 Then
            newform.constr = Me.CYSysInfo.ConnStrValue
            newform.ShowDialog()
            If newform.RtnDataTable.Tables.Count > 0 Then
                ssss = newform.RtnDataTable.Tables(0)
                Return ssss
            End If
        ElseIf clid < -1 Then
            newform3.constr = Me.CYSysInfo.ConnStrValue
            newform3.m_sqlWhere = _sqlWhere
            newform3.S_Classid = clid * -1
            newform3.ShowDialog()
            If newform3.RtnDataTable.Tables.Count > 0 Then
                ssss = newform3.RtnDataTable.Tables(0)
                Return ssss
            End If
        Else
            newform2.constr = Me.CYSysInfo.ConnStrValue
            newform2.S_Classid = clid
            'If clid = 3004 AndAlso PublicSharedFunctions.ChgNullToDouble(FormViewUtility.GetControlProperty(Me.Controls, "FSupplyID", "Value")) > 0 Then
            '    newform2.ZzjGetStr = FormViewUtility.GetControlProperty(Me.Controls, "FSupplyID", "Value").ToString
            'End If
            newform2.ShowDialog()
            If newform2.RtnDataTable.Tables.Count > 0 Then
                ssss = newform2.RtnDataTable.Tables(0)
                Return ssss
            End If
        End If
    End Function '基础资料窗体的使用
#End Region

#End Region

    Public Sub New()
        If GetService(GetType(System.ComponentModel.Design.IDesignerHost)) Is Nothing = False OrElse System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then
        Else
            SCrasoftid = PublicSharedResource.PublicSharedFunctions.Crasoftid
            m_TranType = PublicSharedResource.PublicSharedFunctions.trantype
            InitView()
            If PublicSharedResource.PublicSharedFunctions.icrpt <> "OK" Then

                If RightSeting(PublicSharedResource.PublicSharedFunctions.Crasoftid, PublicSharedResource.PublicSharedFunctions.useid) = False Then
                    MsgBox("没有权限，请与管理员联系！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                    Me.Dispose()
                    Exit Sub
                End If
            End If
        End If

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        AddHandler Me.Load, AddressOf FrmBillBase_Load
        AddHandler Me.Disposed, AddressOf FrmWgBill_Disposed
        AddHandler Me.FormClosed, AddressOf FrmWgBill_FormClosed
        AddHandler Me.Resize, AddressOf FrmWgBill_Resize
    End Sub

    Private Sub FrmWgBill_Disposed(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Me.Dispose(True)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub FrmWgBill_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        CUN_Format()
        Me.Dispose(True)
    End Sub

    Private Sub FrmWgBill_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
        reSizeControl()
    End Sub

#Region "C1"

    Private Sub C1FlexGrid1_AfterResizeColumn(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGrid1.AfterResizeColumn
        Me.Cursor = Cursors.WaitCursor

        Try
            Dim j As Integer = 0
            C2.Cols.Count = Me.C1FlexGrid1.Cols.Count
            For k As Integer = 0 To C1FlexGrid1.Cols.Count - 1
                If Me.C1FlexGrid1.Cols(k).Visible = True Then
                    C2.Cols(k).Visible = True
                    C2.Cols(k).Width = C1FlexGrid1.Cols(k).Width
                    C2.BackColor = m_BaseDataSetting.ListTotalColor
                    C2.Styles.Highlight.BackColor = m_BaseDataSetting.ListTotalColor
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

    Private Sub C1FlexGrid1_BeforeEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGrid1.BeforeEdit
        If e.Row <= 0 Then Exit Sub
        If e.Col <= 0 Then Exit Sub

        Dim _value As Boolean
        _value = OnC1BeforeEdit(sender, e)
        If _value = False Then
            e.Cancel = True
            Exit Sub
        End If

        _value = Nothing
        _value = _C1FlexGrid1_BeforeEdit(sender, e)
        If _value = False Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Public Overridable Function OnC1BeforeEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) As Boolean
        Return True
    End Function

    Private Function _C1FlexGrid1_BeforeEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) As Boolean
        Return True
    End Function


    Private Sub C1FlexGrid1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGrid1.AfterEdit
        If data = C1FlexGrid1(e.Row, e.Col).ToString Then
            Exit Sub
        End If

        Dim _value As Boolean
        _value = OnC1AfterEdit(sender, e)
        If _value = False Then Exit Sub

        _C1FlexGrid1_AfterEdit(sender, e)
    End Sub

    Public Overridable Function OnC1AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) As Boolean
        Return True
    End Function

    Private Sub _C1FlexGrid1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs)
        Me.Autonomic(e.Row, e.Col, C1FlexGrid1.Cols(e.Col).Name)
        SetSumCell()
    End Sub

    Private Sub Autonomic(ByVal _row As Integer, ByVal _col As Integer, ByVal _fieldName As String, Optional ByVal _first As Boolean = True)
        Try
            Dim dblTemp As Double = 0
            Dim dblTemp1 As Double = 0
            Dim i, j As Integer
            Dim Sql As String
            Dim SqlEntry As String
            Dim dt As DataSet
            Dim dtEntry As DataSet
            GetDataSet = New BLuser

            'existName.Add(_fieldName.ToUpper)

            Sql = "exec P_CS_getFormulaData '" & _fieldName & "'," & m_TranType.ToString()
            'Sql = "select * from  T_SGL_ictemFormula where fid='" & Me.FTranType.Text & "' and fRelationsname like '%" & _fieldName & ",%'"
            ''非用户级触发
            'If _first = False Then
            '    Sql = Sql & " and FType<>1"
            'End If
            'Sql = Sql & " order by findex"
            dt = GetDataSet.GetDataset(Sql, Me.CYSysInfo.ConnStrValue)
            If dt.Tables(0).Rows.Count > 0 Then
                For i = 0 To dt.Tables(0).Rows.Count - 1
                    'If existName.Contains(dt.Tables(0).Rows(i)("fname").ToString().ToUpper) Then Continue For
                    SqlEntry = "exec P_SGL_GirdGongshi  '" & m_TranType.ToString() & "', '" & dt.Tables(0).Rows(i)("fname") & "', '" & dt.Tables(0).Rows(i)("fRelationsname") & "'"
                    dtEntry = GetDataSet.GetDataset(SqlEntry, Me.CYSysInfo.ConnStrValue)
                    If dtEntry.Tables(0).Rows.Count = 1 Then
                        dblTemp1 = 0
                        dblTemp1 = CType(C1FlexGrid1.Item(_row, dtEntry.Tables(0).Rows(0)("FValue")), Double)
                        C1FlexGrid1.Item(_row, dt.Tables(0).Rows(i)("fname")) = Math.Abs(dblTemp1)
                    Else
                        dblTemp1 = 0
                        dblTemp = 0
                        For j = 0 To dtEntry.Tables(0).Rows.Count - 1
                            If dtEntry.Tables(0).Rows(j)("FValue") = "100" Then
                                dblTemp = CType(100, Double)
                            ElseIf dtEntry.Tables(0).Rows(j)("FValue") = "1000" Then
                                dblTemp = CType(1000, Double)
                            ElseIf dtEntry.Tables(0).Rows(j)("FValue") = "Rate" Then
                                dblTemp = (CType(100, Double) + CType(C1FlexGrid1.Item(_row, "FTaxRate"), Double)) / 100
                            ElseIf dtEntry.Tables(0).Rows(j)("FValue") = "RRate" Then
                                dblTemp = (CType(100, Double) - CType(C1FlexGrid1.Item(_row, "FTaxRate"), Double)) / 100
                                'ElseIf mm.Tables(0).Rows(j)("FValue") = "FDiscountRate" Then
                                '    dblTemp = (100 - CType(C1FlexGrid1.Item(e.Row, mm.Tables(0).Rows(j)("FValue")), Double)) / 100
                            ElseIf dtEntry.Tables(0).Rows(j)("FValue") = "RERate" Then
                                dblTemp = CType(FormViewUtility.GetControlProperty(Me.Controls, "FExchangeRate", "Text"), Double)
                            Else
                                dblTemp = CType(C1FlexGrid1.Item(_row, dtEntry.Tables(0).Rows(j)("FValue")), Double)
                            End If
                            If j > 0 Then
                                Select Case dtEntry.Tables(1).Rows(j - 1)("FValue")
                                    Case "+"
                                        dblTemp1 = dblTemp + dblTemp1
                                    Case "-"
                                        dblTemp1 = dblTemp1 - dblTemp
                                    Case "*"
                                        dblTemp1 = dblTemp1 * dblTemp
                                    Case "/"
                                        If dblTemp <> 0 Then
                                            dblTemp1 = dblTemp1 / dblTemp
                                        Else
                                            dblTemp1 = 0
                                        End If
                                    Case "#"
                                        If FormViewUtility.getItemSignByItemID(C1FlexGrid1(_row, "FItemID"), Me.CYSysInfo.ConnStrValue) = "/" Then
                                            If dblTemp <> 0 Then
                                                dblTemp1 = dblTemp1 / dblTemp
                                            Else
                                                dblTemp1 = 0
                                            End If
                                        Else
                                            dblTemp1 = dblTemp1 * dblTemp
                                        End If
                                    Case "-#"
                                        If FormViewUtility.getItemSignByItemID(C1FlexGrid1(_row, "FItemID"), Me.CYSysInfo.ConnStrValue) = "/" Then
                                            If dblTemp <> 0 Then
                                                dblTemp1 = dblTemp1 / dblTemp
                                            Else
                                                dblTemp1 = 0
                                            End If
                                        Else
                                            If dblTemp1 <> 0 Then
                                                dblTemp1 = dblTemp / dblTemp1
                                            Else
                                                dblTemp1 = 0
                                            End If
                                        End If
                                End Select
                            Else
                                dblTemp1 = dblTemp
                            End If
                        Next

                        '根据物料精度位数（已经保存在每一个单元格的Format中N0~N6），截取准确数据 add by nbb
                        Dim rg = C1FlexGrid1.GetCellRange(_row, C1FlexGrid1.Cols(dt.Tables(0).Rows(i)("fname")).Index)
                        'If rg.Style Is Nothing Then
                        '    Continue For
                        'End If
                        Dim tempValue As Double = Math.Abs(dblTemp1)
                        Select Case rg.Style.Format
                            Case "N0"
                                tempValue = tempValue.ToString("f0")
                            Case "N1"
                                tempValue = tempValue.ToString("f1")
                            Case "N2"
                                tempValue = tempValue.ToString("f2")
                            Case "N3"
                                tempValue = tempValue.ToString("f3")
                            Case "N4"
                                tempValue = tempValue.ToString("f4")
                            Case "N5"
                                tempValue = tempValue.ToString("f5")
                            Case "N6"
                                tempValue = tempValue.ToString("f6")
                        End Select
                        C1FlexGrid1.Item(_row, dt.Tables(0).Rows(i)("fname")) = Math.Abs(tempValue)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                Next

                SetRobCell()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

    Private Sub C1FlexGrid1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles C1FlexGrid1.KeyDown
        If e.KeyCode = Keys.F7 Then
            Dim _value As Boolean = True
            Dim dsTable As DataTable
            _value = BeforeEntryCall(C1FlexGrid1.Row, C1FlexGrid1.Col)
            If _value = False Then Exit Sub
            _value = True

            _value = OnEntryCall(C1FlexGrid1.Row, C1FlexGrid1.Col, dsTable)
            If _value = False Then Exit Sub

            AfterEntryCall(C1FlexGrid1.Row, C1FlexGrid1.Col, dsTable)
        End If
    End Sub

    Private Sub C1FlexGrid1_KeyDownEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyEditEventArgs) Handles C1FlexGrid1.KeyDownEdit
        If e.KeyCode = Keys.F7 Then
            C1FlexGrid1.FinishEditing() '先跳出编辑模式(编辑状态的单元格赋值是无效的)
            Dim _value As Boolean = True
            Dim dsTable As DataTable
            _value = BeforeEntryCall(C1FlexGrid1.Row, C1FlexGrid1.Col)
            If _value = False Then Exit Sub
            _value = True

            _value = OnEntryCall(C1FlexGrid1.Row, C1FlexGrid1.Col, dsTable)
            If _value = False Then Exit Sub

            AfterEntryCall(C1FlexGrid1.Row, C1FlexGrid1.Col, dsTable)
        End If
    End Sub


    Private Sub C1FlexGrid1_AfterRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles C1FlexGrid1.AfterRowColChange
        If C1FlexGrid1.Row <= 0 Or C1FlexGrid1.Col <= 0 Then
            Exit Sub
        End If

        If C1FlexGrid1.Item(C1FlexGrid1.Row, "fitemid") Is Nothing Then
            Exit Sub
        End If

        If C1FlexGrid1.GetCellStyle(C1FlexGrid1.Row, C1FlexGrid1.Col).BackColor = m_BaseDataSetting.ListNoEditColor Then
            Exit Sub
        End If

        If CanFieldEdit(C1FlexGrid1.Col) = False Then Exit Sub

        Dim Girddatatb() As DataRow
        Dim LookUplcs As Integer = 0
        Girddatatb = Griddatanew.Tables(0).Select("ffieldname='" & C1FlexGrid1.Cols(C1FlexGrid1.Col).Name & "'")
        For Each dr As DataRow In Girddatatb
            LookUplcs = dr("FLookUpCls")
        Next
        If LookUplcs <> 0 Then Exit Sub

        C1FlexGrid1.StartEditing()
    End Sub

    Private Function CanFieldEdit(ByVal _col As Integer) As Boolean
        If m_canEditFields Is Nothing = False Then
            Dim _canedit As Boolean = False
            For Each item As DictionaryEntry In m_canEditFields
                Dim _key As String = item.Key.ToString().ToUpper()
                If _key = C1FlexGrid1.Cols(_col).Name.ToUpper() Then
                    _canedit = True
                End If
            Next
            If _canedit = False Then Exit Function
        End If
        Return True
    End Function

    Private Sub C1FlexGrid1_StartEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGrid1.StartEdit
        Dim Girddatatb() As DataRow
        Dim LookUplcs As Integer = 0
        Girddatatb = Griddatanew.Tables(0).Select("ffieldname='" & C1FlexGrid1.Cols(C1FlexGrid1.Col).Name & "'")
        For Each dr As DataRow In Girddatatb
            LookUplcs = dr("FLookUpCls")
        Next
        If LookUplcs <> 0 And C1FlexGrid1.Cols(C1FlexGrid1.Col).Name <> "CItemNumber" And C1FlexGrid1.Cols(C1FlexGrid1.Col).Name <> "FBatchNo" Then e.Cancel = True
    End Sub

    Protected Overridable Sub BillStatus_Changed()

    End Sub
End Class