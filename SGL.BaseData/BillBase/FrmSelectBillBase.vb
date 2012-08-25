

Imports SGL.BLL
Imports System.Data
Imports System.Drawing
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports C1.Win.C1FlexGrid
Imports SGL.BaseData
Imports PublicSharedResource
Imports PublicSharedResource.PublicSharedFunctions

Public Class FrmSelectBillBase
    Inherits frmBase
    Implements ISelectBill



    Dim intCurRow As Integer
    Dim i, m, n As Integer
    Dim dsdeperment As DataSet
    Public getdate As New SGL.BLL.BLuser
    Dim dd As New SGL.BLL.BLformat
    'Public strsql As String
    Public strtrantype As Integer = 0
    Public strName As String
    Public frm As Object
    Public mmmm As Integer
    Public Typesgl As String
    Public strSql1 As String
    Public strcmdok As Boolean
    Public time1 As Boolean
    Dim dsgl As Integer = 0
    Public nowFschemeID As Integer
    Public nowFschemeIDname As String
    'Public dt As DataTable
    'Public dt1 As DataTable
    Public dthj As DataTable
    Dim numberToCompute As Integer
    Public ds, dstemp As New System.Data.DataSet
    'Public constrmyh As String
    'Public listtype As String
    'Public listuseid As String
    Public sglint As Integer
    Public sglstring As String
    Public BCGD As String = ""
    Public strPX As String
    'Public PX As Integer = 0
    Public Billstring As String
    Dim billtypenew As Integer
    'Public SCrasoftid As Integer
    Public MENUID As Integer
    Private IntType As Boolean
#Region "用于处理格式grid拖动"


    Private _row As Integer '记录被拖动行的index
    Dim _src As C1FlexGrid = Nothing

    Private Sub _flex_BeforeMouseDown(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.BeforeMouseDownEventArgs) Handles C1FlexGrid4.BeforeMouseDown
        'start dragging when the user clicks the row headers
        Dim flex As C1FlexGrid = CType(sender, C1FlexGrid)
        Dim hti As HitTestInfo = flex.HitTest(e.X, e.Y)

        If hti.Type = HitTestTypeEnum.RowHeader Then
            'select the row 
            Dim index As Integer = hti.Row
            flex.Select(index, 0, index, flex.Cols.Count - 1, False)

            'save info for target
            _src = flex

            'do drag drop
            Dim dd As DragDropEffects = flex.DoDragDrop(flex.Clip, DragDropEffects.Move)

            If _row < index Then index = index + 1
            'if it worked, delete row from source (it's a move) 
            If dd = DragDropEffects.Move Then
                flex.Rows.Remove(index)
            End If

            _row = 0
            'done, reset info
            _src = Nothing
        End If
    End Sub

    Private Sub _flex_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles C1FlexGrid4.DragOver
        'check whether we can drop here:

        'we must have a source object, and it should be the other grid
        '(this sample allows dragging from one to the other grid only)
        If Not _src Is Nothing Then 'AndAlso Not _src.Equals(sender) Then
            'check that we have the type of data we want
            If e.Data.GetDataPresent(GetType(String)) Then
                e.Effect = DragDropEffects.Move
            End If
        End If

    End Sub

    Private Sub _flex_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles C1FlexGrid4.DragDrop
        'find the drop position
        Dim flex As C1FlexGrid = CType(sender, C1FlexGrid)
        Dim pt As Point = flex.PointToClient(New Point(e.X, e.Y))
        Dim hti As HitTestInfo = flex.HitTest(pt.X, pt.Y)
        Dim index As Integer = hti.Row

        If index < 0 Then index = flex.Rows.Count 'append
        If index < 1 Then index = 1 'after fixed row

        _row = index
        'insert a new row at the drop position
        flex.Rows.Insert(index)

        'copy data from source row
        flex.Select(index, 0, index, flex.Cols.Count - 1, False)
        flex.Clip = CType(e.Data.GetData(GetType(String)), String)

    End Sub

#End Region

    Public Enum AlignType
        默认 = 0
        靠左 = 1
        居中 = 2
        靠右 = 3
    End Enum
#Region "自定义方法"
    Public Sub loadlistdate(ByVal billtype As String, ByVal sqlstr As String)
        Dim sql As String
        Dim b As DataSet
        Dim b1 As DataSet
        getdate = New BLuser
        strtrantype = listtype
        Dim i, j As Integer
        Dim bb As DataSet

        getdate = New BLuser
        sql = "SELECt fname as fbillname,ftrantype as fbillid,fbilltype FROM T_SGL_ICBILL  where flistid='" + SCrasoftid.ToString + "'"
        bb = getdate.GetDataset(sql, constrmyh)
        billtype = 0
        If PublicSharedResource.PublicSharedFunctions.ChgNullToDouble(bb.Tables(0).Rows.Count) > 0 Then

            Me.cobCheckType.ValueMember = "fbillid"

            Me.cobCheckType.DisplayMember = "fbillname"
            IntType = True
            Me.cobCheckType.DataSource = bb.Tables(0)
            IntType = False
            Me.cobCheckType.SelectedIndex = 0
            strtrantype = cobCheckType.SelectedValue
            cobCheckType.Enabled = False
            billtypenew = bb.Tables(0).Rows(0)("Fbilltype")
        Else
            If strtrantype = "9001" Then
                sql = " select '9001' as fbillid,'储运单' as fbillname "
            ElseIf strtrantype = "9003" Then
                sql = " select '9003' as fbillid,'储运结算单' as fbillname "
            ElseIf strtrantype = "9009" Then
                sql = " select '9009' as fbillid,'结算单' as fbillname "
            ElseIf strtrantype = "2001" Then
                sql = " select '2001' as fbillid,'委外加工转单' as fbillname "
            ElseIf strtrantype = "801" Then
                sql = " select '801' as fbillid,'销售订单' as fbillname "
            ElseIf strtrantype = "802" Then
                sql = " select '802' as fbillid,'佣金结算单' as fbillname "
            ElseIf strtrantype = "93" Then
                sql = " select '93' as fbillid,'委外订单' as fbillname "
            ElseIf strtrantype = "94" Then
                sql = " select '94' as fbillid,'双经销订单' as fbillname "
            ElseIf strtrantype = "1001" Then
                sql = " select '1001' as fbillid,'物料需求单' as fbillname "
            ElseIf strtrantype = "1002" Then
                sql = " select '1002' as fbillid,'织品设计单' as fbillname "
            ElseIf strtrantype = "800" Then
                sql = " select '800' as fbillid,'销售合同' as fbillname "
            ElseIf strtrantype = "100075" Then
                sql = " select fbillid,fbillname from icbillno where fbillid in (75,76) "
                sql = sql & " union  select '100075' as fbillid,'采购发票' as fbillname "
            ElseIf strtrantype = "100080" Then
                sql = " select fbillid,fbillname from icbillno where fbillid in (80,86) "
                sql = sql & " union  select '100080' as fbillid,'销售发票' as fbillname "
            ElseIf strtrantype = "1000601" Then
                sql = " select fbillid,fbillname from icbillno where fbillid in (601,602) "
                sql = sql & " union  select '1000601' as fbillid,'销售发票' as fbillname "
            ElseIf strtrantype = "1000081" Then
                sql = " select '1000081' as fbillid,'佣金支付单' as fbillname "
            ElseIf strtrantype = "20110413" Then
                sql = " select '20110413' as fbillid,'赔款单' as fbillname "
            ElseIf strtrantype = "20110414" Then
                sql = " select '20110414' as fbillid,'其他费用单' as fbillname "
            ElseIf strtrantype = "20110422" Then
                sql = " select '20110422' as fbillid,'赔偿单' as fbillname "
            ElseIf strtrantype = "20110415" Then
                sql = " select '20110415' as fbillid,'应付调价单' as fbillname "
            ElseIf strtrantype = "20110416" Then
                sql = " select '20110416' as fbillid,'采购费用单' as fbillname "
            ElseIf strtrantype = "20110712" Then
                sql = " select '20110712' as fbillid,'销售调整单' as fbillname "
            ElseIf strtrantype = "20110920" Then
                sql = " select '20110920' as fbillid,'销售月任务单' as fbillname "
            ElseIf strtrantype = "20110921" Then
                sql = " select '20110921' as fbillid,'销售年任务单' as fbillname "
            ElseIf strtrantype = "20120321" Then
                sql = " select '20120321' as fbillid,'费用报销单' as fbillname "
            ElseIf strtrantype = "321" Then
                sql = " select '321' as fbillid,'质量保证书-热镀锌钢管' as fbillname "
            ElseIf strtrantype = "322" Then
                sql = " select '322' as fbillid,'质量保证书-高频焊管' as fbillname "
            ElseIf strtrantype = "323" Then
                sql = " select '323' as fbillid,'质量保证书-给水衬塑复合钢管' as fbillname "
            ElseIf strtrantype = "324" Then
                sql = " select '324' as fbillid,'质量保证书-给水涂塑复合钢管' as fbillname "
            ElseIf strtrantype = "325" Then
                sql = " select '325' as fbillid,'质量保证书-涂敷钢管' as fbillname "
            Else
                If strtrantype = 602 Or strtrantype = 601 Or strtrantype = 603 Or strtrantype = 604 Then
                    If strtrantype = 602 Then
                        sql = " select '602' as  fbillid,fbillname from icbillno where fbillid='80'"
                    ElseIf strtrantype = 603 Then
                        sql = " select '603' as  fbillid,fbillname from icbillno where fbillid='76'"
                    ElseIf strtrantype = 604 Then
                        sql = " select '604' as  fbillid,fbillname from icbillno where fbillid='75'"
                    Else
                        sql = " select '601' as fbillid,fbillname from icbillno where fbillid='86'"
                    End If
                ElseIf strtrantype = 75 Or strtrantype = 76 Or strtrantype = 100075 Then
                    sql = " select fbillid,fbillname from icbillno where fbillid in (75,76) "
                    sql = sql & " union  select '100075' as fbillid,'采购发票' as fbillname "
                ElseIf strtrantype = 80 Or strtrantype = 86 Or strtrantype = 100080 Then
                    sql = " select fbillid,fbillname from icbillno where fbillid in (80,86) "
                    sql = sql & " union  select '100080' as fbillid,'销售发票' as fbillname "
                Else
                    sql = " select fbillid,fbillname from icbillno where fbillid='" & strtrantype & "'"
                End If

            End If

            'If strtrantype = 78 Or strtrantype = 80 Or strtrantype = 86 Then
            '    sql = " select fbillid,fbillname from icbillno where fbillid in (78,80,86)"
            '    cobCheckType.Enabled = True
            'Else
            '    cobCheckType.Enabled = False
            'End If
            b = getdate.GetDataset(sql, constrmyh)

            Me.cobCheckType.ValueMember = "fbillid"

            Me.cobCheckType.DisplayMember = "fbillname"
            IntType = True
            Me.cobCheckType.DataSource = b.Tables(0)
            IntType = False
            If b.Tables(0).Rows.Count = 1 Then
                Me.cobCheckType.SelectedIndex = 0
            Else
                cobCheckType.SelectedValue = strtrantype
            End If

            strtrantype = cobCheckType.SelectedValue
            'cobCheckType.Enabled = False

            'Fchannle.Enabled = False
        End If   ' SetSumCell()


        sql = " exec P_SGL_PXList  '" & strtrantype & "'"

        b1 = getdate.GetDataset(sql, constrmyh)
        C1FlexGrid2.DataSource = b1.Tables(0)
        C1FlexGrid2.Cols("字段名称").Width = 317

        getIctemplateIndexList(0)

        C1FlexGrid2.Cols("id").Width = -1
        C1FlexGrid2.Cols("tablealias").Width = -1
        C1FlexGrid2.Cols("namenew").Width = -1
        C1FlexGrid2.Cols("bt").Width = -1
        C1FlexGrid2.AllowEditing = False
    End Sub

    Private Sub getIctemplateIndexList(ByVal _deflault As Integer)
        Try
            Dim dt As DataSet
            Dim Sql As String
            dt = Nothing
            Sql = "exec P_SGL_IctemplateIndexList '" & strtrantype.ToString() & "'," & Me.m_UserID & "," & _deflault.ToString()
            dt = getdate.GetDataset(Sql, constrmyh)
            C1FlexGrid4.Rows.Count = 1
            For index As Integer = 0 To dt.Tables(0).Rows.Count - 1
                C1FlexGrid4.Rows.Add()
                C1FlexGrid4(index + 1, 0) = index + 1
                C1FlexGrid4(index + 1, "name") = dt.Tables(0).Rows(index)("Fcaption")
                C1FlexGrid4(index + 1, "width") = dt.Tables(0).Rows(index)("width")
                If dt.Tables(0).Rows(index)("width") = "-1" Then
                    C1FlexGrid4(index + 1, "show") = 0
                    C1FlexGrid4(index + 1, "width") = 70 '不可见状态，恢复70的宽度（不实际保存到数据库）
                Else
                    C1FlexGrid4(index + 1, "show") = 1
                End If
                C1FlexGrid4(index + 1, "AlignType") = IIf(dt.Tables(0).Rows(index)("AlignType") = AlignType.居中, "居中", _
                                                        IIf(dt.Tables(0).Rows(index)("AlignType") = AlignType.靠右, "靠右", _
                                                        IIf(dt.Tables(0).Rows(index)("AlignType") = AlignType.靠左, "靠左", _
                                                                                                                    "默认")))
                C1FlexGrid4(index + 1, "format") = dt.Tables(0).Rows(index)("format")
            Next
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, "创源提示")
        End Try
    End Sub
    Private Sub GetDataBillList()
        Try
            Dim strsqlm As String
            getdate = New BLuser
            strsql = strsql + strPX
            If Typesgl = 83 Or Typesgl = 72 Or Typesgl = 701 Or Typesgl = 702 Or Typesgl = 703 Or Typesgl = 93 Or Typesgl = 94 Or Typesgl = 710 Or Typesgl = 321 Or Typesgl = 322 Or Typesgl = 323 Or Typesgl = 324 Or Typesgl = 325 Then
                strsqlm = "exec P_SGL_IClist   '" & Typesgl & "','" & strsql & "' "

            ElseIf Typesgl = 9001 Or Typesgl = 9003 Or Typesgl = 9009 Or Typesgl = 700 Or Typesgl = 800 Or Typesgl = 801 Or Typesgl = 81 Or Typesgl = 71 Or Typesgl = 70 Or Typesgl = 802 Or Typesgl = 1001 Or Typesgl = 1002 Or Typesgl = 715 Or Typesgl = 20110413 Or Typesgl = 20110414 Or Typesgl = 20110422 Or Typesgl = 20110415 Or Typesgl = 20110416 Or Typesgl = 20110712 Or Typesgl = 20110920 Or Typesgl = 20110921 Or Typesgl = 20120321 Then
                strsqlm = "exec P_SGL_IClist   '" & Typesgl & "','" & strsql & "' "
            ElseIf Typesgl = "80" Or Typesgl = "86" Or Typesgl = "75" Or Typesgl = "76" Or Typesgl = "77" Or Typesgl = "78" Or Typesgl = "602" Or Typesgl = "601" Or Typesgl = "603" Or Typesgl = "604" Or Typesgl = "100075" Or Typesgl = "100080" Or Typesgl = "1000601" Or Typesgl = "1000603" Then
                strsqlm = "exec P_SGL_IClist   '" & Typesgl & "','" & strsql & "' "
            ElseIf Typesgl = "1000005" Or Typesgl = "1000015" Or Typesgl = "1000014" Or Typesgl = "1000016" Or Typesgl = "1000017" Or Typesgl = "1000018" Or Typesgl = "1000021" Or Typesgl = "1000022" Or Typesgl = "1000081" Or Typesgl = "1000013" Or Typesgl = "1000012" Or Typesgl = "1000011" Then
                strsqlm = "exec P_SGL_IClist   '" & Typesgl & "','" & strsql & "' "
            ElseIf Typesgl = "85" Then
                strsqlm = "exec P_SGL_IClistnew85   '" & Typesgl & "','" & strsql & "' "
            ElseIf Typesgl = "1007000" Then
                strsqlm = "exec P_SGL_IClistnewPCDB  '" & Typesgl & "','" & strsql & "' "
            Else
                strsqlm = "exec P_CS_IClist   '" & Typesgl & "','" & strsql & "' "
            End If

            ds = getdate.GetDataset(strsqlm, constrmyh)
            If ComboBox4.Text = "是" Then


                If Typesgl = 9001 Then
                    dt = PublicSharedResource.PublicSharedFunctions.HollowDataTable(ds.Tables(0), 3, 10, "FInterID", "FInterID")
                Else
                    If PX > 0 Then
                        dt = ds.Tables(0)
                    Else
                        If Typesgl = "1007000" Then
                            dt = PublicSharedResource.PublicSharedFunctions.HollowDataTable(ds.Tables(0), 3, 5, "FID", "FID")
                        Else
                            dt = PublicSharedResource.PublicSharedFunctions.HollowDataTable(ds.Tables(0), 3, 5, "FInterID", "FInterID")
                        End If
                    End If
                End If
            Else
                dt = ds.Tables(0)
            End If
            dt1 = ds.Tables(1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function check() As Integer
        Dim i, t As Integer
        Try
            For i = 1 To C1FlexGrid1.Rows.Count - 1
                If IsNothing(C1FlexGrid1.Item(i, "Fisor")) = True Then
                    If i = 1 And C1FlexGrid1.Item(i, "FColCaption") = "" Then
                        Return 0
                        Exit Function
                    ElseIf i = 1 And CStr(C1FlexGrid1.Item(i, "Tnumber")) = "" Then
                        MessageBox.Show("录入不完整，请录完整后再确定", clsGlobal.M_STR_HINT, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return -1
                        Exit Function
                    End If
                    If i > 1 Then
                        t = i - 1
                        Exit For
                    End If
                Else
                    If Len(C1FlexGrid1.Item(i, "Tnumber")) = 0 Then
                        MessageBox.Show("录入不完整，请录完整后再确定", clsGlobal.M_STR_HINT, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return -1
                        Exit Function
                    End If
                End If
            Next
            Return t
        Catch ex As Exception
            Return -1
            Throw ex
        End Try
    End Function
#End Region
#Region "表体设置"
    Private Sub C1FlexGrid1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGrid1.AfterEdit
        Try
            If dsgl = 1 Then
                ' dsgl = 0
                e.Cancel = True
                Exit Sub
            End If
            If C1FlexGrid1.Cols(C1FlexGrid1.Col).Name.ToLower = "tnumber" Then
                If C1FlexGrid1.Rows(e.Row)("FColtype").ToString = "4" Then
                    C1FlexGrid1.Rows(e.Row)("FNumberDatetime") = C1FlexGrid1.Rows(e.Row)("Tnumber")
                ElseIf C1FlexGrid1.Rows(e.Row)("FColtype").ToString = "3" Then
                    C1FlexGrid1.Rows(e.Row)("FNumberString") = C1FlexGrid1.Rows(e.Row)("Tnumber")
                ElseIf C1FlexGrid1.Rows(e.Row)("FColtype").ToString = "2" Then
                    C1FlexGrid1.Rows(e.Row)("FNumberDecimal") = C1FlexGrid1.Rows(e.Row)("Tnumber")
                ElseIf C1FlexGrid1.Rows(e.Row)("FColtype").ToString = "1" Then
                    C1FlexGrid1.Rows(e.Row)("FNumberDecimal") = C1FlexGrid1.Rows(e.Row)("Tnumber")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub C1FlexGrid1_AfterRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles C1FlexGrid1.AfterRowColChange
        Try
            If dsgl = 1 Then
                ' dsgl = 0
                e.Cancel = True
                Exit Sub
            End If
            If PublicSharedResource.PublicSharedFunctions.ChgNull(C1FlexGrid1.Item(Me.C1FlexGrid1.Row, "Fisor")) = "" Then
                e.Cancel = True
                Exit Sub
            End If
            If C1FlexGrid1.Cols(C1FlexGrid1.Col).Name.ToLower = "tnumber" Then
                If C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("FColtype").ToString = "4" Then
                    C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("FNumberDatetime") = C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("Tnumber")
                ElseIf C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("FColtype").ToString = "3" Then
                    C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("FNumberString") = C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("Tnumber")
                ElseIf C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("FColtype").ToString = "2" Then
                    C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("FNumberDecimal") = C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("Tnumber")
                ElseIf C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("FColtype").ToString = "1" Then
                    C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("FNumberDecimal") = C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("Tnumber")
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub C1FlexGrid1_CellChanged(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGrid1.CellChanged

        Dim StrSql As String, ds As DataSet
        Dim i As Integer

        getdate = New BLuser
        Try


            If C1FlexGrid1.Cols(C1FlexGrid1.Col).Name = "FColCaption" Then
                If C1FlexGrid1.Rows(C1FlexGrid1.Row)("FColCaption") <> "" Then
                    StrSql = "exec P_SGL_icchatbilltitle   '" & strtrantype & "','FColCaption=^" & C1FlexGrid1.Rows(C1FlexGrid1.Row)("FColCaption") & "^'"


                    '  StrSql = StrSql + " " + "   and FColCaption='" & C1FlexGrid1.Rows(C1FlexGrid1.Row)("FColCaption") & "$'"
                    ds = getdate.GetDataset(StrSql, constrmyh)
                    '   ds1 = ds.Tables(0).Select("FColCaption='" & C1FlexGrid1.Rows(C1FlexGrid1.Row)("FColCaption") & "'")

                    If ds.Tables(0).Rows.Count > 0 Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            Me.C1FlexGrid1.Rows(C1FlexGrid1.Row)("FItemClassID") = ds.Tables(0).Rows(0)("FItemClassID")
                            Me.C1FlexGrid1.Rows(C1FlexGrid1.Row)("FTableAlias") = ds.Tables(0).Rows(0)("FTableAlias")
                            Me.C1FlexGrid1.Rows(C1FlexGrid1.Row)("Fname") = ds.Tables(0).Rows(0)("Fname")
                            Me.C1FlexGrid1.Rows(C1FlexGrid1.Row)("FColtype") = ds.Tables(0).Rows(0)("FColtype")
                            If ds.Tables(0).Rows(0)("FColtype") = 4 Then
                                Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp3")
                                cs.DataType = Type.GetType("System.DateTime")
                                cs.ForeColor = Color.Navy
                                cs.Font = New Font(Font, FontStyle.Regular)
                                Dim rg As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 5)
                                rg.Style = C1FlexGrid1.Styles("emp3")
                                C1FlexGrid1.Rows(C1FlexGrid1.Row)(5) = ""
                                Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                                cs2.DataType = Type.GetType("System.String")

                                cs2.ComboList = "|| 等于|不等于|大于|大于等于|小于|小于等于"
                                cs2.ForeColor = Color.Navy
                                cs2.Font = New Font(Font, FontStyle.Regular)
                                Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 4)
                                rg2.Style = C1FlexGrid1.Styles("emp9")

                            ElseIf ds.Tables(0).Rows(0)("FColtype") = 3 Then
                                Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp4")
                                cs.DataType = Type.GetType("System.string")
                                cs.ForeColor = Color.Navy
                                cs.Font = New Font(Font, FontStyle.Regular)
                                Dim rg As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 5)
                                rg.Style = C1FlexGrid1.Styles("emp4")
                                C1FlexGrid1.Rows(C1FlexGrid1.Row)(5) = ""

                                Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                                cs2.DataType = Type.GetType("System.String")

                                cs2.ComboList = "||包含| 等于|不包含|不等于|大于|大于等于|小于|小于等于"
                                cs2.ForeColor = Color.Navy
                                cs2.Font = New Font(Font, FontStyle.Regular)
                                Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 4)
                                rg2.Style = C1FlexGrid1.Styles("emp9")

                            ElseIf ds.Tables(0).Rows(0)("FColtype") = 2 Then
                                Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp5")
                                cs.DataType = Type.GetType("System.Decimal")
                                cs.ForeColor = Color.Navy
                                cs.Font = New Font(Font, FontStyle.Regular)
                                C1FlexGrid1.Rows(C1FlexGrid1.Row)(5) = ""
                                Dim rg As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 5)
                                rg.Style = C1FlexGrid1.Styles("emp5")
                                Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                                cs2.DataType = Type.GetType("System.String")

                                cs2.ComboList = "|| 等于|不等于|大于|大于等于|小于|小于等于"
                                cs2.ForeColor = Color.Navy
                                cs2.Font = New Font(Font, FontStyle.Regular)
                                Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 4)
                                rg2.Style = C1FlexGrid1.Styles("emp9")
                            ElseIf ds.Tables(0).Rows(0)("FColtype") = 1 Then
                                Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp5")
                                cs.DataType = Type.GetType("System.Int64")
                                cs.ForeColor = Color.Navy
                                cs.Font = New Font(Font, FontStyle.Regular)
                                Dim rg As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 5)
                                rg.Style = C1FlexGrid1.Styles("emp5")
                                C1FlexGrid1.Rows(C1FlexGrid1.Row)(5) = 0
                                Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                                cs2.DataType = Type.GetType("System.String")

                                cs2.ComboList = "|| 等于|不等于|大于|大于等于|小于|小于等于"
                                cs2.ForeColor = Color.Navy
                                cs2.Font = New Font(Font, FontStyle.Regular)
                                Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 4)
                                rg2.Style = C1FlexGrid1.Styles("emp9")
                            ElseIf ds.Tables(0).Rows(0)("FColtype") = 5 Then
                                Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp6")
                                cs.DataType = Type.GetType("System.String")
                                cs.ForeColor = Color.Navy
                                cs.Font = New Font(Font, FontStyle.Regular)
                                C1FlexGrid1.Rows(C1FlexGrid1.Row)(5) = ""
                                Dim rg As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 5)
                                rg.Style = C1FlexGrid1.Styles("emp6")

                                Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                                cs2.DataType = Type.GetType("System.String")

                                cs2.ComboList = "||已开票|未开票"
                                cs2.ForeColor = Color.Navy
                                cs2.Font = New Font(Font, FontStyle.Regular)
                                Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 4)
                                rg2.Style = C1FlexGrid1.Styles("emp9")
                            ElseIf ds.Tables(0).Rows(0)("FColtype") = 6 Then
                                Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp7")
                                cs.DataType = Type.GetType("System.String")
                                cs.ForeColor = Color.Navy
                                cs.Font = New Font(Font, FontStyle.Regular)
                                Dim rg As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 5)
                                rg.Style = C1FlexGrid1.Styles("emp7")
                                C1FlexGrid1.Rows(C1FlexGrid1.Row)(5) = ""
                                Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                                cs2.DataType = Type.GetType("System.String")

                                cs2.ComboList = "||已钩稽|未钩稽"
                                cs2.ForeColor = Color.Navy
                                cs2.Font = New Font(Font, FontStyle.Regular)
                                Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 4)
                                rg2.Style = C1FlexGrid1.Styles("emp9")
                            ElseIf ds.Tables(0).Rows(0)("FColtype") = 7 Then
                                Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp7")
                                cs.DataType = Type.GetType("System.String")
                                cs.ForeColor = Color.Navy
                                cs.Font = New Font(Font, FontStyle.Regular)
                                Dim rg As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 5)
                                rg.Style = C1FlexGrid1.Styles("emp7")
                                C1FlexGrid1.Rows(C1FlexGrid1.Row)(5) = ""
                                Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                                cs2.DataType = Type.GetType("System.String")

                                cs2.ComboList = "||已作废|未作废"
                                cs2.ForeColor = Color.Navy
                                cs2.Font = New Font(Font, FontStyle.Regular)
                                Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 4)
                                rg2.Style = C1FlexGrid1.Styles("emp9")
                            ElseIf ds.Tables(0).Rows(0)("FColtype") = 8 Then
                                Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp7")
                                cs.DataType = Type.GetType("System.String")
                                cs.ForeColor = Color.Navy
                                cs.Font = New Font(Font, FontStyle.Regular)
                                Dim rg As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 5)
                                rg.Style = C1FlexGrid1.Styles("emp7")
                                C1FlexGrid1.Rows(C1FlexGrid1.Row)(5) = ""
                                Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                                cs2.DataType = Type.GetType("System.String")

                                cs2.ComboList = "||待审批|同意"
                                cs2.ForeColor = Color.Navy
                                cs2.Font = New Font(Font, FontStyle.Regular)
                                Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 4)
                                rg2.Style = C1FlexGrid1.Styles("emp9")

                            End If
                        End If
                    End If
                Else
                    Me.C1FlexGrid1.Rows(C1FlexGrid1.Row)("FItemClassID") = -1
                    Me.C1FlexGrid1.Rows(C1FlexGrid1.Row)("FTableAlias") = ""
                    Me.C1FlexGrid1.Rows(C1FlexGrid1.Row)("Fname") = ""
                    Me.C1FlexGrid1.Rows(C1FlexGrid1.Row)("FColtype") = ""
                    Me.C1FlexGrid1.Rows(C1FlexGrid1.Row)(5) = ""
                End If
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub C1FlexGrid1_BeforeEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGrid1.BeforeEdit

        Dim sql As String

        Dim bb As DataSet
        Try
            If e.Row = 0 Then
                e.Cancel = True
                Exit Sub
            End If
            If PublicSharedResource.PublicSharedFunctions.ChgNull(C1FlexGrid1.Item(e.Row, "Fisor")) = "" And e.Row <> 1 Then
                If C1FlexGrid1.Cols(e.Col).Name = "Fisor" And PublicSharedResource.PublicSharedFunctions.ChgNull(C1FlexGrid1.Item(e.Row - 1, "FColCaption")) = "" Then

                    e.Cancel = True
                End If
            End If


            If C1FlexGrid1.Cols(e.Col).Name = "Fisor" And e.Row = 1 Then

                e.Cancel = True
            End If


            If C1FlexGrid1.Cols(e.Col).Name = "FColCaption" Then
                If PublicSharedResource.PublicSharedFunctions.ChgNull(C1FlexGrid1.Item(e.Row, "Fisor")) = "" And e.Row <> 1 Then
                    e.Cancel = True
                End If
            End If

            If C1FlexGrid1.Cols(e.Col).Name = "Flink" Then
                If PublicSharedResource.PublicSharedFunctions.ChgNull(C1FlexGrid1.Item(e.Row, "FColCaption")) = "" Then
                    e.Cancel = True
                End If
            End If
            If C1FlexGrid1.Cols(e.Col).Name.ToLower = "tnumber" Then
                If PublicSharedResource.PublicSharedFunctions.ChgNull(C1FlexGrid1.Item(e.Row, "Flink")) = "" Then
                    e.Cancel = True
                ElseIf PublicSharedResource.PublicSharedFunctions.ChgNull(C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("FColtype")).ToString = "4" Then
                    If C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("tnumber").ToString = "0001-01-01 0:00:00" Then
                        C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("tnumber") = Today
                    End If
                End If
            End If
            If C1FlexGrid1.Cols(e.Col).Name = "FKH" Or C1FlexGrid1.Cols(e.Col).Name = "Fkh2" Then
                If PublicSharedResource.PublicSharedFunctions.ChgNull(C1FlexGrid1.Item(e.Row, "FColCaption")) = "" Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub C1FlexGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1FlexGrid1.Click
        Dim hstb As New Hashtable

        getdate = New BLuser
        Dim StrSql As String, ds As DataSet
        Dim i As Integer, strcaption As String                       ' strtablname As String, strtype As String, intclassitemID As String
        Try
            If C1FlexGrid1.Cols(C1FlexGrid1.Col).Name = "FColCaption" Then
                If Me.C1FlexGrid1.Row > 1 And C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("Fisor") = "" Then
                    For i = 2 To Me.C1FlexGrid1.Row
                        If Me.C1FlexGrid1.Rows(i)("Fisor") = "" Then
                            '  cancel = True
                            Exit Sub
                        End If
                    Next
                    C1FlexGrid1.Row = i
                    C1FlexGrid1.Col = 1
                    C1FlexGrid1.Focus()
                    Exit Sub
                End If
                StrSql = "exec P_SGL_icchatbilltitle   '" & strtrantype & "',''"
                'Me.C1FlexGrid1.Cols("Tname").ComboList.Insert()
                ds = getdate.GetDataset(StrSql, constrmyh)
                If ds.Tables.Count > 0 Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        strcaption = "|"
                        For i = 0 To ds.Tables(0).Rows.Count - 1
                            strcaption = strcaption & "|" & ds.Tables(0).Rows(i)("FColCaption")

                        Next
                        Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp2")
                        cs.DataType = Type.GetType("System.String")
                        'cs.ComboList = pf.getHuaSeList(C1FlexGrid1.Rows(C1FlexGrid1.Row)("FEntryCode"), constrmyh, My.Settings.DNA_ManageMent_refBillFunction_WSBillFunction)
                        cs.ComboList = strcaption
                        cs.ForeColor = Color.Navy
                        cs.Font = New Font(Font, FontStyle.Regular)
                        Dim rg As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 3)
                        rg.Style = C1FlexGrid1.Styles("emp2")


                    End If
                End If
            ElseIf C1FlexGrid1.Cols(C1FlexGrid1.Col).Name = "Fisor" Then
                If Me.C1FlexGrid1.Row = 1 Then


                    C1FlexGrid1.Row = i
                    C1FlexGrid1.Col = 3
                    C1FlexGrid1.Focus()
                    Exit Sub
                End If
                If Me.C1FlexGrid1.Row > 1 And C1FlexGrid1.Rows(Me.C1FlexGrid1.Row - 1)("FColCaption") = "" Then
                    For i = 1 To Me.C1FlexGrid1.Row
                        If Me.C1FlexGrid1.Rows(i)("FColCaption") = "" Then
                            Exit For
                        End If
                    Next
                    C1FlexGrid1.Row = i
                    C1FlexGrid1.Col = 3
                    C1FlexGrid1.Focus()
                    Exit Sub
                End If
            ElseIf C1FlexGrid1.Cols(C1FlexGrid1.Col).Name.ToLower = "tnumber" Then
                If Me.C1FlexGrid1.Row > 0 And C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("Flink") = "" Then
                    For i = 1 To Me.C1FlexGrid1.Row
                        If Me.C1FlexGrid1.Rows(i)("Flink") = "" Then
                            Exit For
                        End If
                    Next
                    C1FlexGrid1.Row = i
                    C1FlexGrid1.Col = 1

                    C1FlexGrid1.Focus()

                    Exit Sub
                End If
            ElseIf C1FlexGrid1.Cols(C1FlexGrid1.Col).Name = "Flink" Then
                If Me.C1FlexGrid1.Row > 0 And C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("FColCaption") = "" Then
                    For i = 1 To Me.C1FlexGrid1.Row
                        If Me.C1FlexGrid1.Rows(i)("FColCaption") = "" Then
                            Exit For
                        End If
                    Next
                    C1FlexGrid1.Row = i
                    C1FlexGrid1.Col = 1
                    C1FlexGrid1.Focus()
                    Exit Sub
                End If
                If Me.C1FlexGrid1.Row > 0 And C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("FColCaption") <> "" Then
                    If Me.C1FlexGrid1.Rows(C1FlexGrid1.Row)("FColtype") > 0 Then
                        Dim coltype As Integer = Me.C1FlexGrid1.Rows(C1FlexGrid1.Row)("FColtype")
                        If coltype = 4 Then
                            Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp3")
                            cs.DataType = Type.GetType("System.DateTime")
                            cs.ForeColor = Color.Navy
                            cs.Font = New Font(Font, FontStyle.Regular)
                            Dim rg As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 5)
                            rg.Style = C1FlexGrid1.Styles("emp3")
                            If C1FlexGrid1.Rows(C1FlexGrid1.Row)("Flink") <> "" Then
                                C1FlexGrid1.Rows(C1FlexGrid1.Row)(5) = Today
                            End If

                            Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                            cs2.DataType = Type.GetType("System.String")

                            cs2.ComboList = "|| 等于|不等于|大于|大于等于|小于|小于等于"
                            cs2.ForeColor = Color.Navy
                            cs2.Font = New Font(Font, FontStyle.Regular)
                            Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 4)
                            rg2.Style = C1FlexGrid1.Styles("emp9")

                        ElseIf coltype = 3 Then
                            Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp4")
                            cs.DataType = Type.GetType("System.string")
                            cs.ForeColor = Color.Navy
                            cs.Font = New Font(Font, FontStyle.Regular)
                            Dim rg As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 5)
                            rg.Style = C1FlexGrid1.Styles("emp4")


                            Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                            cs2.DataType = Type.GetType("System.String")

                            cs2.ComboList = "||包含| 等于|不包含|不等于|大于|大于等于|小于|小于等于"
                            cs2.ForeColor = Color.Navy
                            cs2.Font = New Font(Font, FontStyle.Regular)
                            Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 4)
                            rg2.Style = C1FlexGrid1.Styles("emp9")

                        ElseIf coltype = 2 Then
                            Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp5")
                            cs.DataType = Type.GetType("System.decimal")
                            cs.ForeColor = Color.Navy
                            cs.Font = New Font(Font, FontStyle.Regular)
                            Dim rg As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 5)
                            rg.Style = C1FlexGrid1.Styles("emp5")
                            Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                            cs2.DataType = Type.GetType("System.String")

                            cs2.ComboList = "|| 等于|不等于|大于|大于等于|小于|小于等于"
                            cs2.ForeColor = Color.Navy
                            cs2.Font = New Font(Font, FontStyle.Regular)
                            Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 4)
                            rg2.Style = C1FlexGrid1.Styles("emp9")
                        ElseIf coltype = 1 Then
                            Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp5")
                            cs.DataType = Type.GetType("System.Int64")
                            cs.ForeColor = Color.Navy
                            cs.Font = New Font(Font, FontStyle.Regular)
                            Dim rg As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 5)
                            rg.Style = C1FlexGrid1.Styles("emp5")
                            Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                            cs2.DataType = Type.GetType("System.String")

                            cs2.ComboList = "|| 等于|不等于|大于|大于等于|小于|小于等于"
                            cs2.ForeColor = Color.Navy
                            cs2.Font = New Font(Font, FontStyle.Regular)
                            Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 4)
                            rg2.Style = C1FlexGrid1.Styles("emp9")
                        ElseIf coltype = 5 Then
                            Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp6")
                            cs.DataType = Type.GetType("System.String")
                            cs.ForeColor = Color.Navy
                            cs.Font = New Font(Font, FontStyle.Regular)
                            Dim rg As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 5)
                            rg.Style = C1FlexGrid1.Styles("emp6")

                            Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                            cs2.DataType = Type.GetType("System.String")

                            cs2.ComboList = "||已开票|未开票"
                            cs2.ForeColor = Color.Navy
                            cs2.Font = New Font(Font, FontStyle.Regular)
                            Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 4)
                            rg2.Style = C1FlexGrid1.Styles("emp9")
                        ElseIf coltype = 6 Then
                            Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp7")
                            cs.DataType = Type.GetType("System.String")
                            cs.ForeColor = Color.Navy
                            cs.Font = New Font(Font, FontStyle.Regular)
                            Dim rg As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 5)
                            rg.Style = C1FlexGrid1.Styles("emp7")

                            Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                            cs2.DataType = Type.GetType("System.String")

                            cs2.ComboList = "||已钩稽|未钩稽"
                            cs2.ForeColor = Color.Navy
                            cs2.Font = New Font(Font, FontStyle.Regular)
                            Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 4)
                            rg2.Style = C1FlexGrid1.Styles("emp9")
                        ElseIf coltype = 7 Then
                            Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp7")
                            cs.DataType = Type.GetType("System.String")
                            cs.ForeColor = Color.Navy
                            cs.Font = New Font(Font, FontStyle.Regular)
                            Dim rg As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 5)
                            rg.Style = C1FlexGrid1.Styles("emp7")

                            Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                            cs2.DataType = Type.GetType("System.String")

                            cs2.ComboList = "||已作废|未作废"
                            cs2.ForeColor = Color.Navy
                            cs2.Font = New Font(Font, FontStyle.Regular)
                            Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 4)
                            rg2.Style = C1FlexGrid1.Styles("emp9")
                        End If
                    End If

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub C1FlexGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1FlexGrid1.DoubleClick
        Dim i As Integer

        Try
            Me.Cursor = Cursors.WaitCursor
            If C1FlexGrid1.Cols(C1FlexGrid1.Col).Name.ToLower = "tnumber" Then
                If Me.C1FlexGrid1.Row > 0 And C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("Flink") = "" Then
                    For i = 1 To Me.C1FlexGrid1.Row
                        If Me.C1FlexGrid1.Rows(i)("Flink") = "" Then
                            dsgl = 1
                            Exit For
                        End If
                    Next

                    C1FlexGrid1.Row = i
                    C1FlexGrid1.Col = 1
                    C1FlexGrid1.Focus()
                    Exit Sub
                End If
                dsgl = 0
            ElseIf C1FlexGrid1.Cols(C1FlexGrid1.Col).Name = "FColCaption" Then

            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub C1FlexGrid1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles C1FlexGrid1.KeyDown
        Dim i As Integer
        Dim dstable As DataTable
        Dim strtemp As String
        Dim newform As New SGL.BaseData.FrmItems
        Dim newMsgForm As New SGL.BaseData.Frmmessage
        Try

            '例如： 



            If e.KeyCode = Keys.F7 Then
                If C1FlexGrid1.Cols(C1FlexGrid1.Col).Name.ToLower = "tnumber" Then
                    If Me.C1FlexGrid1.Row > 0 And C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("Flink") = "" Then
                        For i = 1 To Me.C1FlexGrid1.Row
                            If Me.C1FlexGrid1.Rows(i)("Flink") = "" Then
                                Exit For
                            End If
                        Next
                        C1FlexGrid1.Row = i
                        C1FlexGrid1.Col = 1
                        C1FlexGrid1.Focus()
                        Exit Sub
                    End If
                    If C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("FItemClassID") > 0 Then
                        newform.constr = constrmyh
                        newform.S_Classid = C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("FItemClassID")
                        newform.ShowDialog()
                        If newform.RtnDataTable.Tables.Count = 0 Then
                            Exit Sub
                        End If
                        dstable = newform.RtnDataTable.Tables(0)

                        strtemp = C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("FColCaption")
                        If dstable.Rows.Count > 0 Then
                            If strtemp.Substring(Len(strtemp) - 2, 2) = "代码" Then
                                C1FlexGrid1.Item(C1FlexGrid1.Row, "Tnumber") = dstable.Rows(0)("Fnumber")
                                C1FlexGrid1.Rows(C1FlexGrid1.Row)("FNumberString") = C1FlexGrid1.Rows(C1FlexGrid1.Row)("Tnumber")
                            Else
                                Me.Ftrantype.Focus()
                                C1FlexGrid1.Rows(C1FlexGrid1.Row)("Tnumber") = dstable.Rows(0)("FName")
                                C1FlexGrid1.Rows(C1FlexGrid1.Row)("FNumberString") = C1FlexGrid1.Rows(C1FlexGrid1.Row)("Tnumber")
                            End If
                        End If
                    ElseIf C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("FItemClassID") < 0 Then
                        newMsgForm.constr = constrmyh
                        newMsgForm.S_Classid = C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("FItemClassID") * -1
                        newMsgForm.ShowDialog()
                        dstable = newMsgForm.RtnDataTable.Tables(0)
                        If dstable.Rows.Count > 0 Then
                            Me.Ftrantype.Focus()
                            C1FlexGrid1.Rows(C1FlexGrid1.Row)("Tnumber") = dstable.Rows(0)("FName")
                            C1FlexGrid1.Rows(C1FlexGrid1.Row)("FNumberString") = C1FlexGrid1.Rows(C1FlexGrid1.Row)("Tnumber")
                        End If
                    End If
                End If
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub C1FlexGrid1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1FlexGrid1.TextChanged

        Dim StrSql As String, ds As DataSet
        Dim i As Integer
        Try

            If C1FlexGrid1.Cols(C1FlexGrid1.Col).Name = "FColCaption" Then
                If C1FlexGrid1.Rows(C1FlexGrid1.Row)("FColCaption") <> "" Then
                    StrSql = "select FColtype,FItemClassID from icchatbilltitle where fid='" & strtrantype & "'"


                    StrSql = StrSql + " " + "and FColCaption='" & C1FlexGrid1.Rows(C1FlexGrid1.Row)("FColCaption") & "'"
                    ds = getdate.GetDataset(StrSql, constrmyh)
                    If ds.Tables.Count > 0 Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            Me.C1FlexGrid1.Rows(C1FlexGrid1.Row)("FColtype") = ds.Tables(0).Rows(0)("FColtype")
                            If ds.Tables(0).Rows(0)("FColtype") = 0 Then
                                Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp2")
                                cs.DataType = Type.GetType("System.DateTime")
                                cs.ForeColor = Color.Navy
                                cs.Font = New Font(Font, FontStyle.Regular)
                                Dim rg As CellRange = C1FlexGrid1.GetCellRange(C1FlexGrid1.Row, 3)
                                rg.Style = C1FlexGrid1.Styles("emp2")

                            End If
                            Me.C1FlexGrid1.Rows(C1FlexGrid1.Row)("FItemClassID") = ds.Tables(0).Rows(0)("FItemClassID")
                        End If
                    Else

                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "控制设置"
    Private Sub ButOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButOK.Click

        Dim i As Integer
        Dim strFTableAlias, strName, strtnumber, strFlink, strFKH1, strFKH2 As String
        Dim intFColtype As Integer
        Dim datay As DataSet
        Dim strsqlm As String
        Dim y As Integer
        Dim p As Integer
        getdate = New BLuser
        'Typesgl
        strsqlm = "select * from t_SGL_MenuTree where fmenuid in ( select frootid from t_SGL_MenuTree where FMenuID='" & PublicSharedResource.PublicSharedFunctions.Crasoftid.ToString() & "') "
        datay = getdate.GetDataset(strsqlm, constrmyh)
        If Len(datay.Tables(0).Rows(0)("Target").ToString()) > 0 Then
            If datay.Tables(0).Rows(0)("Target") = "AP" Then
                strsqlm = "select fvalue from dbo.t_RP_SystemProfile where fkey in ('FAPCurYear') and fcategory ='ARP' order by fkey"
                strsqlm += " select fvalue from dbo.t_RP_SystemProfile where fkey in ('FAPCurPeriod') and fcategory ='ARP' order by fkey"
            ElseIf datay.Tables(0).Rows(0)("Target") = "AR" Then
                strsqlm = "select fvalue from dbo.t_RP_SystemProfile where fkey in ('FARCurYear') and fcategory ='ARP' order by fkey"
                strsqlm += " select fvalue from dbo.t_RP_SystemProfile where fkey in ('FARCurPeriod') and fcategory ='ARP' order by fkey"
            Else
                strsqlm = "select fvalue from dbo.t_SystemProfile where fkey in ('CurrentYear') and fcategory ='" & datay.Tables(0).Rows(0)("Target") & "' order by fkey"
                strsqlm = strsqlm & " select fvalue from dbo.t_SystemProfile where fkey in ('CurrentPeriod') and fcategory ='" & datay.Tables(0).Rows(0)("Target") & "' order by fkey"
            End If
        Else
            strsqlm = "select fvalue from dbo.t_SystemProfile where fcategory='IC' and fkey ='CurrentYear'   select fvalue from dbo.t_SystemProfile where fcategory='IC' and fkey ='CurrentPeriod'"
        End If

        datay = getdate.GetDataset(strsqlm, constrmyh)
        If datay.Tables(0).Rows.Count > 0 Then

        Else
            '没有取到期间的情况下默认取物流期间
            strsqlm = "select fvalue from dbo.t_SystemProfile where fcategory='IC' and fkey ='CurrentYear'   select fvalue from dbo.t_SystemProfile where fcategory='IC' and fkey ='CurrentPeriod'"
            datay = getdate.GetDataset(strsqlm, constrmyh)
        End If
        y = datay.Tables(0).Rows(0)(0)
        p = datay.Tables(1).Rows(0)(0)
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.FInterID.Focus()
            Me.UseWaitCursor = True

            Me.ToolStrip1.Enabled = False
            Me.C1FlexGrid1.Enabled = False
            Me.TabControl1.Enabled = False
            Me.ButOK.Enabled = False
            Me.Button1.Enabled = False
            Typesgl = cobCheckType.SelectedValue
            strsql = " and 1=1"
            For i = 1 To C1FlexGrid1.Rows.Count
                If Me.C1FlexGrid1.Rows(i)("FColCaption") = "" Then
                    Exit For
                End If
                strFTableAlias = Me.C1FlexGrid1.Rows(i)("FTableAlias")
                strName = Me.C1FlexGrid1.Rows(i)("Fname")
                strtnumber = Me.C1FlexGrid1.Rows(i)("Tnumber")
                intFColtype = Me.C1FlexGrid1.Rows(i)("FColtype")
                strFKH1 = Me.C1FlexGrid1.Rows(i)("FKH")
                strFKH2 = Me.C1FlexGrid1.Rows(i)("FKH2")
                If strName = "" Then
                    MsgBox("过滤条件输入不完整，查询失败！", MsgBoxStyle.OkOnly, "创源提示")
                    Me.Cursor = Cursors.Default
                    'Me.UseWaitCursor = True

                    Me.ToolStrip1.Enabled = True
                    Me.C1FlexGrid1.Enabled = True
                    Me.TabControl1.Enabled = True
                    Me.ButOK.Enabled = True
                    Me.Button1.Enabled = True
                    Exit Sub
                End If
                If intFColtype < 3 Then
                    If strtnumber = "" Then
                        MsgBox("过滤条件输入不完整，查询失败！", MsgBoxStyle.OkOnly, "创源提示")
                        C1FlexGrid1.Cursor = Cursors.Default
                        Me.Cursor = Cursors.Default
                        'Me.UseWaitCursor = True

                        Me.ToolStrip1.Enabled = True
                        Me.C1FlexGrid1.Enabled = True
                        Me.TabControl1.Enabled = True
                        Me.ButOK.Enabled = True
                        Me.Button1.Enabled = True
                        Exit Try
                    End If
                End If

                If intFColtype = 0 Then
                    time1 = True
                End If

                strFlink = Me.C1FlexGrid1.Rows(i)("Flink")
                If strFlink = "" Then
                    MsgBox("过滤条件输入不完整，查询失败！", MsgBoxStyle.OkOnly, "创源提示")
                    Me.Cursor = Cursors.Default
                    'Me.UseWaitCursor = True

                    Me.ToolStrip1.Enabled = True
                    Me.C1FlexGrid1.Enabled = True
                    Me.TabControl1.Enabled = True
                    Me.ButOK.Enabled = True
                    Me.Button1.Enabled = True
                    Exit Sub
                End If
                If i > 1 AndAlso Me.C1FlexGrid1.Rows(i)("FColtype") < 5 Then
                    If Me.C1FlexGrid1.Rows(i)(1) = "或者" Then
                        strsql = strsql + " " + "or " & strFKH1 & strFTableAlias & "." & strName & ""
                    Else
                        strsql = strsql + " " + "and " & strFKH1 & strFTableAlias & "." & strName & ""
                    End If
                ElseIf Me.C1FlexGrid1.Rows(i)("FColtype") < 5 Then
                    '    strsql = strsql + " " + "and " & strName & ""
                    'Else
                    strsql = strsql + " " + "and " & strFKH1 & strFTableAlias & "." & strName & ""
                End If
                'strsql = strsql + " " + "and " & strFTableAlias & "." & strName & ""
                Select Case Trim(Me.C1FlexGrid1.Rows(i)("Flink"))
                    Case "包含"
                        strsql = strsql + " " + "like  ^~" & strtnumber & "~^"

                    Case "不包含"
                        strsql = strsql + " " + " not like   "
                        strsql = strsql + " " + "^~" & strtnumber & "~^"

                    Case "等于"
                        strsql = strsql + " " + " ="
                        If intFColtype < 3 Then
                            strsql = strsql + " " + "" & strtnumber & ""
                        Else
                            strsql = strsql + " " + "^" & strtnumber & "^"
                        End If
                    Case "大于"
                        strsql = strsql + " " + " >"
                        If intFColtype < 3 Then
                            strsql = strsql + " " + "" & strtnumber & ""
                        Else
                            strsql = strsql + " " + "^" & strtnumber & "^"
                        End If
                    Case "大于等于"
                        strsql = strsql + " " + " >="
                        If intFColtype < 3 Then
                            strsql = strsql + " " + "" & strtnumber & ""
                        Else
                            strsql = strsql + " " + "^" & strtnumber & "^"
                        End If
                    Case "小于"
                        strsql = strsql + " " + " <"
                        If intFColtype < 3 Then
                            strsql = strsql + " " + "" & strtnumber & ""
                        Else
                            strsql = strsql + " " + "^" & strtnumber & "^"
                        End If
                    Case "小于等于"
                        strsql = strsql + " " + " <="
                        If intFColtype < 3 Then
                            strsql = strsql + " " + "" & strtnumber & ""
                        Else
                            strsql = strsql + " " + "^" & strtnumber & "^"
                        End If
                    Case "不等于"
                        strsql = strsql + " " + " <>"
                        If intFColtype < 3 Then
                            strsql = strsql + " " + "" & strtnumber & ""
                        Else
                            strsql = strsql + " " + "^" & strtnumber & "^"
                        End If
                    Case "大于等于"
                        strsql = strsql + " " + " >="
                        If intFColtype < 3 Then
                            strsql = strsql + " " + "" & strtnumber & ""
                        Else
                            strsql = strsql + " " + "^" & strtnumber & "^"
                        End If
                    Case "已开票"
                        strsql = strsql + " " + " and " & strFKH1 & " v1.FRelateInvoiceID > 0"
                    Case "未开票"
                        strsql = strsql + " " + " and " & strFKH1 & " v1.FRelateInvoiceID = 0"
                    Case "已作废"
                        strsql = strsql + " " + " and " & strFKH1 & " isnull(v1.FCancellation,0) > 0"
                    Case "未作废"
                        strsql = strsql + " " + " and " & strFKH1 & " isnull(v1.FCancellation,0) = 0"
                    Case "已钩稽"
                        strsql = strsql + " " + " and " & strFKH1 & " v1.FHookInterID > 0"
                    Case "未钩稽"
                        strsql = strsql + " " + " and " & strFKH1 & " v1.FHookInterID = 0"
                    Case "待审批"
                        strsql = strsql + " " + " and " & strFKH1 & " isnull(v1.FEditPriceConfirm,0) = 1"
                    Case "同意"
                        strsql = strsql + " " + " and " & strFKH1 & " isnull(v1.FEditPriceConfirm,0) = 2"
                End Select
                strsql = strsql & strFKH2
            Next

            '过滤条件 两边加上括号() modified by nbb
            If strsql.Trim <> "and 1=1" Then
                strsql = strsql.Replace("and 1=1", "").Trim
                If strsql.Length > 3 Then strsql = " and 1=1 and (" + strsql.Substring(3, strsql.Length - 3)
                'strsql = strsql.Replace("and 1=1 and", "and 1=1 and ( ")
                strsql = strsql + " ) "
            End If

            If billtypenew > 0 And Typesgl <> 700 Then
                strsql = strsql + "  and isnull(v1.Fbilltype,0)=" & billtypenew & " "
            End If
            If Typesgl = 700 Then
                strsql = strsql + "  and isnull(v1.FCurchecklevel,0)=" & billtypenew & " "
            End If
            If MENUID = 2005 Or MENUID = 2006 Then
                strsql = strsql + "  and   v1.FInvStyle = 12511 "
            ElseIf MENUID = 88 Or MENUID = 89 Then
                strsql = strsql + "  and v1.FInvStyle = 12510  "
            Else

            End If
            If BCGD = "BCGD" Then
                strsql = strsql + " " + "  AND  (isnull(v1.FCheckerID,0)>0  and isnull(v1.FHookerID,0)=0 and v1.FTranType=77 and isnull(v1.FVchInterID,0)=0 and year(v1.FDate)*12+month(v1.FDate)<" & y * 12 + p + 1 & " )  "
            Else
                Select Case Me.FCheckID.Text
                    Case "审核"
                        strsql = strsql + " " + " and v1.FcheckerID>=1"
                    Case "未审核"
                        strsql = strsql + " " + " and (v1.FcheckerID=0 or v1.FcheckerID is null)"
                End Select

                If strtrantype = 21 Then
                    Select Case Me.ComboBox1.Text
                        Case "勾兑"
                            strsql = strsql + " " + " and v1.Fisgd>=1"
                        Case "未勾兑"
                            strsql = strsql + " " + " and (v1.Fisgd=0 or v1.Fisgd is null)"
                    End Select
                    Select Case Me.ComboBox2.Text
                        Case "下推"
                            strsql = strsql + " " + " and v1.Fisxt>=1"
                        Case "未下推"
                            strsql = strsql + " " + " and (v1.Fisxt=0 or v1.Fisxt is null)"
                    End Select

                    Select Case Me.ComboBox3.Text
                        Case "是"
                            strsql = strsql + " " + " and v1.FCancellation=1"
                        Case "否"
                            strsql = strsql + " " + " and v1.FCancellation=0"
                    End Select


                End If

                If time1 = False Then
                    Select Case Me.Fdate.Text
                        Case "本期"
                            'strsql = strsql + " " + " and year(v1.Fdate)=" & Me.CYSysInfo.CurrentYear & " and month(v1.Fdate)=" & Me.CYSysInfo.CurrentMonth
                            strsql = strsql + " " + " and year(v1.Fdate)=" & y & " and month(v1.Fdate)=" & p & " "
                        Case "上期"
                            If Month(Now) = 1 Then
                                '  If Me.CYSysInfo.CurrentMonth = 1 Then
                                strsql = strsql + " " + " and year(v1.Fdate)=" & y - 1 & "  and month(v1.Fdate)=12 "
                                'strsql = strsql + " " + " and year(v1.Fdate)=" & Me.CYSysInfo.CurrentYear & "-1 and month(v1.Fdate)=12 "
                            Else
                                strsql = strsql + " " + " and year(v1.Fdate)=" & y & "  and month(v1.Fdate)=" & p - 1 & ""
                                'strsql = strsql + " " + " and year(v1.Fdate)=" & Me.CYSysInfo.CurrentYear & " and month(v1.Fdate)=" & Me.CYSysInfo.CurrentMonth & "-1"
                            End If
                        Case "昨天"
                            strsql = strsql + " " + " and v1.Fdate=cast(left(DATEADD(day,-1,getdate()),10) as datetime)  "
                        Case "今天"
                            strsql = strsql + " " + " and v1.Fdate=cast(left(getdate(),10) as datetime)  "
                    End Select
                End If
                Select Case Me.FRob.Text
                    Case "蓝字"
                        strsql = strsql + " " + " and v1.FRob=1"
                    Case "红字"
                        strsql = strsql + " " + " and (v1.FRob=-1 or v1.FRob is null)"
                End Select

                '''modify by nbb



                If strtrantype >= 1000005 Then
                    '应收应付等
                    Select Case Me.Fchannle.Text
                        Case "记帐"
                            strsql = strsql + " " + " and (v1.FVoucherID<0 OR v1.FVoucherID>0)"
                        Case "未记帐"
                            strsql = strsql + " " + " and (v1.FVoucherID=0 or v1.FVoucherID is null)"
                    End Select
                Else
                    '其他
                    Select Case Me.Fchannle.Text
                        Case "记帐"
                            strsql = strsql + " " + " and (v1.FVchInterID<0 OR v1.FVchInterID>0)"
                        Case "未记帐"
                            strsql = strsql + " " + " and (v1.FVchInterID=0 or v1.FVchInterID is null)"
                    End Select
                End If

            End If

            ''过滤条件 两边加上括号() modified by nbb
            'If strsql.Trim <> "and 1=1" Then
            '    strsql = strsql.Replace("and 1=1", "").Trim
            '    If strsql.Length > 3 Then strsql = " and 1=1 and (" + strsql.Substring(3, strsql.Length - 3)
            '    'strsql = strsql.Replace("and 1=1 and", "and 1=1 and ( ")
            '    strsql = strsql + " ) "
            'End If

            strPX = "SGLLOVEMYH  "
            Dim k, ss As Integer
            Dim sspx As String
            For k = 1 To C1FlexGrid3.Rows.Count - 1
                If C1FlexGrid3.Item(k, "bt") = "1" Then
                    PX = PX + 1
                End If
                If C1FlexGrid3.Item(k, "name") = "" Then
                    ss = k
                    Exit For
                Else
                    If C1FlexGrid3.Rows(k)("asc") = True Then
                        sspx = "  desc"
                    Else
                        sspx = "  asc"
                    End If
                    strPX = strPX + C1FlexGrid3.Rows(k)("tablealias") + "." + C1FlexGrid3.Rows(k)("namenew") + sspx + ","
                End If
            Next

            Dim tempf1 As Integer, tempf2 As Integer
            Dim tempstr As String = strsql.Replace("(", "(1")
            tempstr = strsql.Replace(")", ")1")
            tempf1 = tempstr.Split("(").Length
            tempf2 = tempstr.Split(")").Length
            If tempf1 <> tempf2 Then
                MessageBox.Show("左右括号不匹配，请检查！", clsGlobal.M_STR_HINT, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Cursor = Cursors.Default
                'Me.UseWaitCursor = True

                Me.ToolStrip1.Enabled = True
                Me.C1FlexGrid1.Enabled = True
                Me.TabControl1.Enabled = True
                Me.ButOK.Enabled = True
                Me.Button1.Enabled = True
                Exit Sub
            End If

            '   strSql = "" + Chr(39) + strSql + Chr(39) + ""
            SaveWay(True, sglstring)
            saveLocation()
            strcmdok = True
            Me.Close()
            'BgW.RunWorkerAsync(numberToCompute)

        Catch ex As Exception
            Throw ex
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BgW_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BgW.DoWork

        Dim worker As System.ComponentModel.BackgroundWorker = CType(sender, System.ComponentModel.BackgroundWorker)
        GetDataBillList()
    End Sub


    Private Sub BgW_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BgW.RunWorkerCompleted

        ' First, handle the case where an exception was thrown.
        If Not (e.Error Is Nothing) Then
            MessageBox.Show(e.Error.Message)

        End If
        Me.Close()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        strcmdok = False
        Me.Close()
    End Sub


    Private Sub Clearall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Clearall.Click
        Dim count, i As Integer
        Try
            count = C1FlexGrid1.Rows.Count - 1
            For i = 1 To count - 1
                If Len(C1FlexGrid1.Item(1, "FColCaption")) > 0 Then
                    C1FlexGrid1.Rows.Remove(1)
                Else
                    Exit For
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cobCheckType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobCheckType.SelectedIndexChanged
        Dim count, i As Integer

        If IntType = False Then
            strtrantype = cobCheckType.SelectedValue
            strName = cobCheckType.SelectedText
        End If

        count = C1FlexGrid1.Rows.Count - 1
        For i = 1 To count - 1
            If Len(C1FlexGrid1.Item(1, "FColCaption")) > 0 Then
                C1FlexGrid1.Rows.Remove(1)
            Else
                Exit For
            End If
        Next

        'Dim Sql As String = " exec P_SGL_PXList  '" & strtrantype & "'"

        'Dim b1 As DataSet = getdate.GetDataset(Sql, constrmyh)
        'C1FlexGrid2.DataSource = b1.Tables(0)
        'C1FlexGrid2.Cols("字段名称").Width = 317

        'getIctemplateIndexList(0)

    End Sub
#End Region
    Private Sub frmfilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = False '开启异步线程访问控件
        Dim hstb As New Hashtable

        Try
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle

            With C1FlexGrid4
                .DragMode = DragModeEnum.Manual
                .DropMode = DropModeEnum.Manual
            End With

            mmmm = strtrantype
            If mmmm = 9999 Then
                FCheckID.Enabled = False
            End If
            If strtrantype > 0 Then
                loadlistdate("1", " and fbillid ='" & strtrantype & "' ")
            Else
                loadlistdate("1", "")
            End If
            If strtrantype = 21 Then
            Else
                ComboBox1.Visible = False
                Label6.Visible = False
                ComboBox2.Visible = False
                Label7.Visible = False

            End If
            '采购订单 过滤 隐藏 红字标记 和 记账标记 过滤条件 （add by nbb）
            If strtrantype = 71 Or strtrantype = 1007000 Or strtrantype = 20110920 Or strtrantype = 20110921 Then
                FRob.Text = "全部"
                FRob.Enabled = False
                cobCheckType.Text = "全部"
                cobCheckType.Enabled = False
            End If
            If strtrantype = 20120321 Then
                FRob.Text = "全部"
                FRob.Enabled = False
                cobCheckType.Text = "全部"
                cobCheckType.Enabled = True
            End If
            If strtrantype = 715 Or strtrantype = 20110920 Or strtrantype = 20110921 Then
                Label3.Enabled = False
                FRob.Enabled = False
                Label4.Enabled = False
                Fchannle.Enabled = False

            End If
            ''''''''''''''''''''''''''''''''''''
            ShowBilllist()
            If BCGD = "BCGD" Then
                Fdate.Text = "本期"
                FCheckID.Text = "审核"
                FRob.Text = "全部"
                Fchannle.Text = "未记帐"
            End If
            'setBilltype()
            C1FlexGrid4.Cols("AlignType").ComboList = AlignType.默认.ToString() + "|" + AlignType.居中.ToString() + "|" + AlignType.靠右.ToString() + "|" + AlignType.靠左.ToString()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ShowBilldata()
        Dim strSql, strname As String
        Dim dtEntry, ds2 As DataSet
        Dim i, k, count As Integer
        Dim m As Integer
        m = 1
        'Dim owner As Control

        'Dim ctrl As New ControlCollection(owner)
        ''''显示最后次该用户使用的表上过滤条件
        Try
            strSql = "select * from t_cy_ISProfileEntry where FschemeID=" & nowFschemeID
            dtEntry = getdate.GetDataset(strSql, constrmyh)
            'C1FlexGrid1.Clear(ClearFlags.UserData, 1, 1, 5, C1FlexGrid1.Cols.Count - 1)
            ' 清理c1flexgrid
            count = C1FlexGrid1.Rows.Count - 1
            For i = 1 To count - 1
                If Len(C1FlexGrid1.Item(1, "FColCaption")) > 0 Then
                    C1FlexGrid1.Rows.Remove(1)
                Else
                    Exit For
                End If
            Next
            C1FlexGrid1.Rows.Count = 50
            If dtEntry.Tables(0).Rows.Count > 0 Then
                For i = 0 To dtEntry.Tables(0).Rows.Count - 1
                    For k = 0 To dtEntry.Tables(0).Columns.Count - 1
                        If dtEntry.Tables(0).Columns(k).Caption.ToLower <> "fschemeid" And dtEntry.Tables(0).Columns(k).Caption.ToLower <> "findex" Then
                            If dtEntry.Tables(0).Columns(k).DataType.Name.ToLower = "datetime" Then
                                If IsDBNull(dtEntry.Tables(0).Rows(i)(k)) = False Then
                                    If PublicSharedResource.PublicSharedFunctions.FormatDate(dtEntry.Tables(0).Rows(i)(k)) <> "" Then
                                        C1FlexGrid1.Item(i + 1, dtEntry.Tables(0).Columns(k).Caption) = dtEntry.Tables(0).Rows(i)(k)
                                    End If
                                End If
                            Else
                                C1FlexGrid1.Item(i + 1, dtEntry.Tables(0).Columns(k).Caption) = dtEntry.Tables(0).Rows(i)(k)
                            End If
                        End If
                        If dtEntry.Tables(0).Columns(k).Caption.ToLower = "FColCaption" Then
                            If C1FlexGrid1.Rows(C1FlexGrid1.Row)("FColCaption") = "凭证字" Then
                                ds2 = getdate.GetDataset("select Fname from t_vouchergroup", constrmyh)
                                If ds2.Tables(0).Rows.Count > 0 Then
                                    strname = "|"
                                    For t As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                                        strname = strname & "|" & ds2.Tables(0).Rows(t)("Fname")
                                    Next

                                    Dim zcs2 As CellStyle = C1FlexGrid1.Styles.Add("zemp9")
                                    zcs2.DataType = Type.GetType("System.String")

                                    zcs2.ComboList = strname
                                    zcs2.ForeColor = Color.Navy
                                    zcs2.Font = New Font(Font, FontStyle.Regular)
                                    Dim zrg2 As CellRange = C1FlexGrid1.GetCellRange(i + 1, 5)
                                    zrg2.Style = C1FlexGrid1.Styles("zemp9")
                                End If
                            End If
                        End If
                        If dtEntry.Tables(0).Columns(k).Caption.ToLower = "fcoltype" Then
                            If dtEntry.Tables(0).Rows(i)(k) = 4 Then

                                Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp3")
                                cs.DataType = Type.GetType("System.DateTime")
                                cs.ForeColor = Color.Navy
                                cs.Font = New Font(Font, FontStyle.Regular)
                                Dim rg As CellRange = C1FlexGrid1.GetCellRange(i + 1, 5)
                                rg.Style = C1FlexGrid1.Styles("emp3")

                                Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                                cs2.DataType = Type.GetType("System.String")
                                'cs.ComboList = pf.getHuaSeList(C1FlexGrid1.Rows(C1FlexGrid1.Row)("FEntryCode"), Me.CYSysInfo.ConnStrValue, My.Settings.DNA_ManageMent_refBillFunction_WSBillFunction)
                                cs2.ComboList = "|| 等于|不等于|大于|大于等于|小于|小于等于"
                                cs2.ForeColor = Color.Navy
                                cs2.Font = New Font(Font, FontStyle.Regular)
                                Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(i + 1, 4)
                                rg2.Style = C1FlexGrid1.Styles("emp9")

                                C1FlexGrid1.Item(i + 1, "Tnumber") = dtEntry.Tables(0).Rows(i)("FNumberDatetime")
                            ElseIf dtEntry.Tables(0).Rows(i)(k) = 3 Then
                                Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp4")
                                cs.DataType = Type.GetType("System.string")
                                cs.ForeColor = Color.Navy
                                cs.Font = New Font(Font, FontStyle.Regular)
                                Dim rg As CellRange = C1FlexGrid1.GetCellRange(i + 1, 5)
                                rg.Style = C1FlexGrid1.Styles("emp4")


                                Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                                cs2.DataType = Type.GetType("System.String")
                                'cs.ComboList = pf.getHuaSeList(C1FlexGrid1.Rows(C1FlexGrid1.Row)("FEntryCode"), Me.CYSysInfo.ConnStrValue, My.Settings.DNA_ManageMent_refBillFunction_WSBillFunction)
                                cs2.ComboList = "||包含| 等于|不包含|不等于|大于|大于等于|小于|小于等于"
                                cs2.ForeColor = Color.Navy
                                cs2.Font = New Font(Font, FontStyle.Regular)
                                Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(i + 1, 4)
                                rg2.Style = C1FlexGrid1.Styles("emp9")

                                C1FlexGrid1.Item(i + 1, "Tnumber") = dtEntry.Tables(0).Rows(i)("FNumberString")
                            ElseIf dtEntry.Tables(0).Rows(i)(k) = 2 Then
                                Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp5")
                                cs.DataType = Type.GetType("System.decimal")
                                cs.ForeColor = Color.Navy
                                cs.Font = New Font(Font, FontStyle.Regular)
                                Dim rg As CellRange = C1FlexGrid1.GetCellRange(i + 1, 5)
                                rg.Style = C1FlexGrid1.Styles("emp5")
                                Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                                cs2.DataType = Type.GetType("System.String")
                                'cs.ComboList = pf.getHuaSeList(C1FlexGrid1.Rows(C1FlexGrid1.Row)("FEntryCode"), Me.CYSysInfo.ConnStrValue, My.Settings.DNA_ManageMent_refBillFunction_WSBillFunction)
                                cs2.ComboList = "| | 等于|不等于|大于|大于等于|小于|小于等于"
                                cs2.ForeColor = Color.Navy
                                cs2.Font = New Font(Font, FontStyle.Regular)
                                Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(i + 1, 4)
                                rg2.Style = C1FlexGrid1.Styles("emp9")

                                C1FlexGrid1.Item(i + 1, "Tnumber") = dtEntry.Tables(0).Rows(i)("FNumberDecimal")
                            ElseIf dtEntry.Tables(0).Rows(i)(k) = 1 Then
                                Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp6")
                                cs.DataType = Type.GetType("System.Int64")
                                cs.ForeColor = Color.Navy
                                cs.Font = New Font(Font, FontStyle.Regular)
                                Dim rg As CellRange = C1FlexGrid1.GetCellRange(i + 1, 5)
                                rg.Style = C1FlexGrid1.Styles("emp6")
                                Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp10")
                                cs2.DataType = Type.GetType("System.String")
                                cs2.ComboList = "| | 等于|不等于|大于|大于等于|小于|小于等于"
                                cs2.ForeColor = Color.Navy
                                cs2.Font = New Font(Font, FontStyle.Regular)
                                Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(i + 1, 4)
                                rg2.Style = C1FlexGrid1.Styles("emp10")

                                C1FlexGrid1.Item(i + 1, "Tnumber") = dtEntry.Tables(0).Rows(i)("FNumberDecimal")
                            ElseIf dtEntry.Tables(0).Rows(i)(k) = 5 Then
                                Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp7")
                                cs.DataType = Type.GetType("System.String")
                                cs.ForeColor = Color.Navy
                                cs.Font = New Font(Font, FontStyle.Regular)
                                Dim rg As CellRange = C1FlexGrid1.GetCellRange(i + 1, 5)
                                rg.Style = C1FlexGrid1.Styles("emp7")

                                Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                                cs2.DataType = Type.GetType("System.String")

                                cs2.ComboList = "||已开票|未开票"
                                cs2.ForeColor = Color.Navy
                                cs2.Font = New Font(Font, FontStyle.Regular)
                                Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(i + 1, 4)
                                rg2.Style = C1FlexGrid1.Styles("emp9")
                            ElseIf dtEntry.Tables(0).Rows(i)(k) = 6 Then
                                Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp8")
                                cs.DataType = Type.GetType("System.String")
                                cs.ForeColor = Color.Navy
                                cs.Font = New Font(Font, FontStyle.Regular)
                                Dim rg As CellRange = C1FlexGrid1.GetCellRange(i + 1, 5)
                                rg.Style = C1FlexGrid1.Styles("emp8")

                                Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                                cs2.DataType = Type.GetType("System.String")

                                cs2.ComboList = "||已钩稽|未钩稽"
                                cs2.ForeColor = Color.Navy
                                cs2.Font = New Font(Font, FontStyle.Regular)
                                Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(i + 1, 4)
                                rg2.Style = C1FlexGrid1.Styles("emp9")
                            ElseIf dtEntry.Tables(0).Rows(i)(k) = 7 Then
                                Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp8")
                                cs.DataType = Type.GetType("System.String")
                                cs.ForeColor = Color.Navy
                                cs.Font = New Font(Font, FontStyle.Regular)
                                Dim rg As CellRange = C1FlexGrid1.GetCellRange(i + 1, 5)
                                rg.Style = C1FlexGrid1.Styles("emp8")

                                Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                                cs2.DataType = Type.GetType("System.String")

                                cs2.ComboList = "||已作废|未作废"
                                cs2.ForeColor = Color.Navy
                                cs2.Font = New Font(Font, FontStyle.Regular)
                                Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(i + 1, 4)
                                rg2.Style = C1FlexGrid1.Styles("emp9")
                            ElseIf dtEntry.Tables(0).Rows(i)(k) = 8 Then
                                Dim cs As CellStyle = C1FlexGrid1.Styles.Add("emp8")
                                cs.DataType = Type.GetType("System.String")
                                cs.ForeColor = Color.Navy
                                cs.Font = New Font(Font, FontStyle.Regular)
                                Dim rg As CellRange = C1FlexGrid1.GetCellRange(i + 1, 5)
                                rg.Style = C1FlexGrid1.Styles("emp8")

                                Dim cs2 As CellStyle = C1FlexGrid1.Styles.Add("emp9")
                                cs2.DataType = Type.GetType("System.String")

                                cs2.ComboList = "||待审批|同意"
                                cs2.ForeColor = Color.Navy
                                cs2.Font = New Font(Font, FontStyle.Regular)
                                Dim rg2 As CellRange = C1FlexGrid1.GetCellRange(i + 1, 4)
                                rg2.Style = C1FlexGrid1.Styles("emp9")
                            End If
                        End If
                    Next
                Next
            End If
            ''''显示最后次该用户使用的表外的过滤条件
            strSql = "select * from t_cy_ISProfileQT where FschemeID=" & nowFschemeID
            dtEntry = getdate.GetDataset(strSql, constrmyh)
            Dim ctrl1 As TabPage.TabPageControlCollection
            ctrl1 = Me.条件.Controls
            For i = 0 To dtEntry.Tables(0).Rows.Count - 1
                For k = 0 To ctrl1.Count - 1
                    If ctrl1.Item(k).Name.ToLower = dtEntry.Tables(0).Rows(i)("FKey").ToLower And ctrl1.Item(k).Visible = True Then
                        ctrl1.Item(k).Text = dtEntry.Tables(0).Rows(i)("FValue")
                    End If
                Next

                '作废标志
                If ComboBox3.Name.ToLower = dtEntry.Tables(0).Rows(i)("FKey").ToLower And ComboBox3.Visible = True Then
                    ComboBox3.Text = dtEntry.Tables(0).Rows(i)("FValue")
                End If

                '表头过滤
                If ComboBox4.Name.ToLower = dtEntry.Tables(0).Rows(i)("FKey").ToLower And ComboBox4.Visible = True Then
                    ComboBox4.Text = dtEntry.Tables(0).Rows(i)("FValue")
                End If
            Next

            Dim dddentry As DataSet
            strSql = "select * from t_cy_ISProfileQTentry where fid='" & nowFschemeID & "' order  by fentryid"
            dddentry = getdate.GetDataset(strSql, constrmyh)
            C1FlexGrid3.Rows.Count = 1
            C1FlexGrid3.Rows.Count = 50
            If PublicSharedResource.PublicSharedFunctions.ChgNullToDouble(dddentry.Tables(0).Rows.Count) > 0 Then
                For i = 0 To dddentry.Tables(0).Rows.Count - 1
                    C1FlexGrid3.Item(i + 1, "name") = dddentry.Tables(0).Rows(i)("fname")
                    C1FlexGrid3.Item(i + 1, "namenew") = dddentry.Tables(0).Rows(i)("fnamenew")
                    C1FlexGrid3.Item(i + 1, "tablealias") = dddentry.Tables(0).Rows(i)("ft")
                    C1FlexGrid3.Item(i + 1, "bt") = dddentry.Tables(0).Rows(i)("fdt")
                    C1FlexGrid3.Item(i + 1, "asc") = dddentry.Tables(0).Rows(i)("fsf")
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click
        Dim hs As New Hashtable, ds As DataSet
        Dim owner As Control
        Dim i, k As Integer
        Dim ctrl As New ControlCollection(owner)
        Dim find As New FindWinData
        Dim ctr(0) As DbType, ctr2(2) As DbType
        Dim newfrm As New FrmNameP
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Focus()
            Me.C1FlexGrid1.Focus()

            If check() = False Then
                Exit Sub
            End If
            newfrm.ShowDialog()
            If newfrm.ok1 = True Then
                nowFschemeIDname = newfrm.newname
                SaveWay(False, nowFschemeIDname)
                ShowBilllist()
                'ShowBilldata()
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception

            Throw ex
        End Try
    End Sub

    Private Function SaveWay(ByVal update As Boolean, ByVal Nname As String) As Boolean
        Dim ds As DataSet, strSql As String
        Dim i, k, c As Integer
        Dim ctrl1 As TabPage.TabPageControlCollection
        Dim fx As New C1.Win.C1FlexGrid.C1FlexGrid
        Dim dc As DataColumn, dcEntry As DataColumn
        Dim dtbEntry As New DataTable
        Dim dt As New DataSet
        Dim rowEntry As Data.DataRow
        Dim billEntryTable As String = "t_cy_ISProfileEntry"
        Dim exitfor As Boolean, dsNull As Boolean
        Dim field As String = "", value As String = ""
        'dim  retCount As Integer
        Dim fieldEntry As String = "", valueEntry As String = ""
        Dim StrSqlEntry As String = ""
        Try
            If update = False Then
                nowFschemeIDname = Nname
                strSql = "exec sp_cy_Buileway " & m_UserID & "," & Me.strtrantype & ",'" & nowFschemeIDname & "'"
                ds = getdate.GetDataset(strSql, constrmyh)
                If ds.Tables.Count > 0 Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        If ds.Tables(0).Rows(0)("zzjreturn") <> 0 Then
                            MessageBox.Show("名字不能重复,保存失败", clsGlobal.M_STR_HINT, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return False
                            Exit Function
                        End If
                        nowFschemeID = ds.Tables(0).Rows(0)("FSchemeID")
                        nowFschemeIDname = ds.Tables(0).Rows(0)("FSchemeName")
                        'nowFschemeID = ds.Tables(0).Rows(0)("Fislasted")
                    End If
                End If
            Else
                nowFschemeIDname = Nname
                strSql = "exec sp_cy_Changeway " & m_UserID & "," & Me.strtrantype & ",'" & nowFschemeIDname & "'"
                ds = getdate.GetDataset(strSql, constrmyh)
                If ds.Tables.Count > 0 Then
                    nowFschemeID = ds.Tables(0).Rows(0)("FSchemeID")
                    nowFschemeIDname = ds.Tables(0).Rows(0)("FSchemeName")
                End If
            End If
            ''''保存最后次该用户使用的表格的过滤条件
            '初始化列
            ctrl1 = Me.条件.Controls
            For i = 0 To ctrl1.Count - 1
                If ctrl1.Item(i).Name.IndexOf("FlexGrid") >= 0 Then
                    ' MessageBox.Show("ss")
                    fx = CType(ctrl1.Item(i), C1.Win.C1FlexGrid.C1FlexGrid)
                    For k = 0 To fx.Cols.Count - 1
                        If Microsoft.VisualBasic.Left(fx.Cols(k).Name, 1).ToLower = "f" Then
                            dcEntry = New DataColumn()              '新建一列
                            dcEntry.DataType = fx.Cols(k).DataType  '设置列类型
                            dcEntry.ColumnName = fx.Cols(k).Name    '设置列名                    
                            dcEntry.AllowDBNull = True              ' 允许为空
                            dtbEntry.Columns.Add(dcEntry)            '把列添加到表中
                        End If
                    Next

                    dt.Tables.Add(dtbEntry)
                    rowEntry = dtbEntry.NewRow()
                End If
            Next
            For i = 0 To ctrl1.Count - 1
                If ctrl1.Item(i).Name.IndexOf("FlexGrid") >= 0 Then            '取单据体数据
                    fx = CType(ctrl1.Item(i), C1.Win.C1FlexGrid.C1FlexGrid)
                    For k = 1 To fx.Rows.Count - 1
                        If IsDBNull(fx(k, "FColCaption")) = False Then
                            If IIf(IsNothing(fx(k, "FColCaption")), "", fx(k, "FColCaption")) <> "" Then             '关键字段不为空的记录才有效
                                For c = 0 To fx.Cols.Count - 1
                                    If Microsoft.VisualBasic.Left(fx.Cols(c).Name, 1).ToUpper = "F" Then
                                        If (fx.Cols(c).DataType.Name = "Int32" Or fx.Cols(c).DataType.Name = "UInt64" Or fx.Cols(c).DataType.Name = "Double" Or fx.Cols(c).DataType.Name = "Decimal") And (fx(k, fx.Cols(c).Name) Is Nothing Or CType(fx(k, fx.Cols(c).Name), String) = "") Then
                                            rowEntry(fx.Cols(c).Name) = 0                        '当输入框中为空时，默认为０

                                        ElseIf fx.Cols(c).DataType.Name = "DateTime" Then
                                            If PublicSharedFunctions.ChgNull(fx(k, fx.Cols(c).Name)) = "" Then
                                                rowEntry(fx.Cols(c).Name) = "1900-01-01"
                                            Else
                                                rowEntry(fx.Cols(c).Name) = PublicSharedFunctions.FormatString(IIf(fx(k, fx.Cols(c).Name) Is Nothing, "", fx(k, fx.Cols(c).Name)))
                                                ' Me.FCPMenFu.Text = StrConv(Me.FCPMenFu.Text.ToString, VbStrConv.Narrow, 0) 
                                            End If
                                        ElseIf fx.Cols(c).DataType.Name = "String" Then
                                            rowEntry(fx.Cols(c).Name) = ("'" & IIf(fx(k, fx.Cols(c).Name) Is Nothing, "", PublicSharedFunctions.FormatString(fx(k, fx.Cols(c).Name))) & "'")
                                        ElseIf fx.Cols(c).DataType.Name = "Boolean" Then
                                            If fx(k, fx.Cols(c).Name) = False Then
                                                rowEntry(fx.Cols(c).Name) = 0
                                            Else
                                                rowEntry(fx.Cols(c).Name) = 1
                                            End If
                                            ' rowEntry(fx.Cols(c).Name) = IIf(fx(k, fx.Cols(c).Name) Is Nothing, 0, fx(k, fx.Cols(c).Name))
                                        Else
                                            rowEntry(fx.Cols(c).Name) = PublicSharedFunctions.FormatString(IIf(fx(k, fx.Cols(c).Name) Is Nothing, "", fx(k, fx.Cols(c).Name)))      '给某行某列附值
                                        End If
                                    End If
                                Next
                                dtbEntry.Rows.Add(rowEntry)
                                rowEntry = dtbEntry.NewRow()
                            Else
                                k = fx.Rows.Count           '当关键字段为空，就退出循环
                            End If
                        End If
                    Next
                End If
            Next

            If billEntryTable <> "" Then                                                '当单据有单据头，单据体的时候
                For i = 0 To dt.Tables(0).Rows.Count - 1
                    For c = 0 To dt.Tables(0).Columns.Count - 1
                        If IsDBNull(dt.Tables(0).Rows(i)("FColCaption")) Then              '代表空的单据体
                            dsNull = True
                            Exit For
                        End If

                        If Trim(CType(dt.Tables(0).Rows(i)("FColCaption"), String)) = "" Then                '关键字段为空时，就退出
                            exitfor = True
                            Exit For
                        Else
                            fieldEntry = fieldEntry & CType(dt.Tables(0).Columns(c).ColumnName, String) & ","        '取出列名
                            If IsDBNull(dt.Tables(0).Rows(i)(c)) = True Then
                                If dt.Tables(0).Columns(c).DataType.Name = "Decimal" Or dt.Tables(0).Columns(c).DataType.Name = "Double" Or dt.Tables(0).Columns(c).DataType.Name = "Int32" Or dt.Tables(0).Columns(c).DataType.Name = "Int64" Then
                                    valueEntry = valueEntry & "0,"
                                ElseIf dt.Tables(0).Columns(c).DataType.Name = "String" Then
                                    valueEntry = valueEntry & "'',"
                                Else
                                    valueEntry = valueEntry & "null,"
                                End If

                            Else
                                ' ds.Tables(1).Rows(i)(c).GetType
                                If dt.Tables(0).Columns(c).DataType.Name = "DateTime" Then
                                    '  CType(ds.Tables(1).Rows(i)(c), String).Replace("'", "‘")
                                    If PublicSharedFunctions.FormatDate(CType(dt.Tables(0).Rows(i)(c), String)) = "" Then
                                        valueEntry = valueEntry & "null,"          '取出列值
                                    Else
                                        valueEntry = valueEntry & "'" & PublicSharedFunctions.FormatDate(CType(dt.Tables(0).Rows(i)(c), String)) & "',"          '取出列值
                                    End If

                                ElseIf dt.Tables(0).Columns(c).DataType.Name = "Boolean" Then
                                    If CType(dt.Tables(0).Rows(i)(c), String) = "False" Then
                                        valueEntry = valueEntry & "0,"
                                    Else
                                        valueEntry = valueEntry & "1,"
                                    End If
                                Else

                                    valueEntry = valueEntry & CType(dt.Tables(0).Rows(i)(c), String) & ","          '取出列值
                                End If

                            End If
                        End If
                    Next
                    If dsNull = True Then
                        Exit For
                    End If
                    fieldEntry = fieldEntry & "FschemeID"                                '单据内码，外键
                    valueEntry = valueEntry + CType(nowFschemeID, String)
                    ' fieldEntry = Microsoft.VisualBasic.Left(fieldEntry, Len(fieldEntry) - 1)
                    ' valueEntry = Microsoft.VisualBasic.Left(valueEntry, Len(valueEntry) - 1)
                    strSql = " insert into " & billEntryTable & "( " & fieldEntry & " ) values( " & valueEntry & ") "
                    StrSqlEntry = StrSqlEntry & strSql
                    fieldEntry = ""
                    valueEntry = ""
                    If exitfor = True Then
                        Exit For
                    End If
                Next
            End If
            If StrSqlEntry <> "" Then
                getdate.GetDataset(StrSqlEntry, constrmyh)               '保存单据体,单据头
            End If
            ''''保存最后次该用户使用的表外的过滤条件
            Dim ctrl2 As TabPage.TabPageControlCollection
            ctrl2 = Me.条件.Controls
            strSql = ""
            For i = 0 To ctrl2.Count - 1
                If Microsoft.VisualBasic.Left(ctrl2.Item(i).Name, 1).ToUpper = "F" Then
                    strSql += " insert t_cy_ISProfileQt values (" & nowFschemeID & ",'" & ctrl2.Item(i).Name & "',0,'" & ctrl2.Item(i).Text & "')"
                End If
            Next

            '作废标志
            If ComboBox3.Visible = True Then
                strSql += " insert t_cy_ISProfileQt values (" & nowFschemeID & ",'" & ComboBox3.Name & "',0,'" & ComboBox3.Text & "')"
            End If

            '表头过滤
            If ComboBox4.Visible = True Then
                strSql += " insert t_cy_ISProfileQt values (" & nowFschemeID & ",'" & ComboBox4.Name & "',0,'" & ComboBox4.Text & "')"
            End If

            strSql += " delete from t_cy_ISProfileQtentry  where fid= '" & nowFschemeID & "'"
            For i = 1 To C1FlexGrid3.Rows.Count - 1
                If C1FlexGrid3.Item(i, "name") <> "" Then
                    strSql += "  insert t_cy_ISProfileQtentry values (" & nowFschemeID & ",'" & C1FlexGrid3.Item(i, "name") & "','" & C1FlexGrid3.Item(i, "asc") & "','" & C1FlexGrid3.Item(i, "namenew") & "','" & C1FlexGrid3.Item(i, "tablealias") & "','" & C1FlexGrid3.Item(i, "bt") & "','" & i & "')"
                Else
                    Exit For
                End If
            Next
            getdate.GetDataset(strSql, constrmyh)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub saveLocation()
        Try

            Dim Sql As String, width As String = "", field As String = "", AlignType As String = "", format As String = ""
            Dim dt As DataSet
            If C1FlexGrid4.Rows.Count <= 0 Then Exit Sub
            For i As Integer = 1 To C1FlexGrid4.Rows.Count - 1
                If C1FlexGrid4(i, "show") = True Then
                    width += C1FlexGrid4(i, "width").ToString() + ","
                Else
                    width += "-1,"
                End If

                field += C1FlexGrid4(i, "name").ToString() + ","
                AlignType += IIf(C1FlexGrid4(i, "AlignType").ToString() = "靠左", CInt(Me.AlignType.靠左).ToString(), _
                                   IIf(C1FlexGrid4(i, "AlignType").ToString() = "靠右", CInt(Me.AlignType.靠右).ToString(), _
                                   IIf(C1FlexGrid4(i, "AlignType").ToString() = "居中", CInt(Me.AlignType.居中).ToString(), "0"))) _
                + ","
                format += C1FlexGrid4(i, "format").ToString() + ","
            Next

            Sql = " exec P_SGL_RPTZDYBAOBIAOFormatlist '" & width & "'," & strtrantype & "," & m_UserID
            Sql += " exec P_nbb_FormatLocationWrite '" & field & "','" & AlignType & "','" & format & "'," & strtrantype & "," & m_UserID
            getdate.GetDataset(Sql, constrmyh)
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, "创源提示")
        End Try
    End Sub

    Private Sub ShowBilllist()

        Dim k, j As Integer
        ListView.Rows.MinSize = 25
        strsql = "exec P_SGL_getway  " & m_UserID & ", " & strtrantype & ""
        ds = getdate.GetDataset(strsql, constrmyh)
        If ds.Tables(0).Rows.Count > 0 Then
            j = 0
            k = 0
            Me.ListView.Rows.Count = 0

            For i = 0 To ds.Tables(0).Rows.Count - 1
                Me.ListView.Rows.Add()

                Me.ListView(i, "FschemeID") = ds.Tables(0).Rows(i)("FschemeID")
                Me.ListView(i, "FSchemeName") = ds.Tables(0).Rows(i)("FSchemeName")
                If ds.Tables(0).Rows(i)("FSchemeName") = "默认方案" Then
                    Me.ListView.Row = i
                    sglint = ds.Tables(0).Rows(i)("FschemeID")
                    sglstring = ds.Tables(0).Rows(i)("FSchemeName")
                    nowFschemeID = ds.Tables(0).Rows(i)("FschemeID")
                    nowFschemeIDname = ds.Tables(0).Rows(i)("FSchemeName")
                    ShowBilldata()
                End If
            Next

            Dim cg As CellRange
            cg = ListView.GetCellRange(0, 1, ListView.Rows.Count - 1, 1)
            cg.Image = CType(Me.ImageList1.Images(0), Image)
            cg.StyleNew.ImageAlign = ImageAlignEnum.CenterCenter

            'For i = 0 To ds.Tables(0).Rows.Count - 1
            '    'If j Mod 3 = 1 Then
            '    '    Me.ListView1.Items.Add("j", "", "")
            '    '    Me.ListView1.Items(j).Focused = False
            '    '    j = j + 1
            '    '    k = k + 1
            '    'End If
            '    Me.ListView1.Items.Add(ds.Tables(0).Rows(i)("FschemeID"), ds.Tables(0).Rows(i)("FSchemeName"), 0)
            '    If ds.Tables(0).Rows(i)("FSchemeName") = "默认方案" Then
            '        Me.ListView1.Items(i + k).Checked = True
            '        sglint = ds.Tables(0).Rows(i)("FschemeID")
            '        sglstring = ds.Tables(0).Rows(i)("FSchemeName")
            '        nowFschemeID = ds.Tables(0).Rows(i)("FschemeID")
            '        nowFschemeIDname = ds.Tables(0).Rows(i)("FSchemeName")
            '        ShowBilldata()
            '    End If
            '    Me.ListView1.Items(i).ImageIndex = 0
            '    j = j + 1
            'Next
        End If

    End Sub


    Private Sub delect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles delect.Click

        Dim strschemename As String
        Dim strSql As String, ds As Data.DataSet
        Try
            Me.Cursor = Cursors.WaitCursor
            If ListView.Row >= 0 And ListView.Row < ListView.Rows.Count Then
                strschemename = ListView(ListView.Row, "FSchemeName")
            Else
                MessageBox.Show("请选择要删除的方案", clsGlobal.M_STR_HINT, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            If strschemename = "默认方案" Then
                MessageBox.Show("不能删除默认方案", clsGlobal.M_STR_HINT, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            strSql = "BEGIN TRANSACTION"
            strSql += " DECLARE @FSchemeID int;set @FSchemeID=0"
            strSql += " select @FSchemeID=FSchemeID from t_cy_ISProfile where FSchemename='" & strschemename & "' and FuserID=" & m_UserID & " and Ftrantype= " & Me.strtrantype
            strSql += " if @FSchemeID>0"
            strSql += " BEGIN"
            strSql += " delete t_cy_ISProfile where FSchemeID=@FSchemeID"
            strSql += " delete t_cy_ISProfileEntry where FSchemeID=@FSchemeID"
            strSql += " delete t_cy_ISProfileQt where FSchemeID=@FSchemeID"
            strSql += " delete t_cy_ISProfileQtentry where fid=@FSchemeID"
            strSql += " END"
            strSql += " IF @@ERROR = 0 COMMIT TRANSACTION ELSE ROLLBACK TRANSACTION"
            'strSql = " delete t_cy_ISProfile where FSchemename='" & strschemename & "' and FuserID=" & listuseid & " and Ftrantype= " & Me.strtrantype
            ds = getdate.GetDataset(strSql, constrmyh)
            MessageBox.Show("删除成功", clsGlobal.M_STR_HINT, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ShowBilllist()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub C1FlexGrid2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1FlexGrid2.DoubleClick
        Dim k, ss As Integer
        For k = 0 To C1FlexGrid3.Rows.Count - 1
            If C1FlexGrid3.Item(k, "name") = C1FlexGrid2.Item(C1FlexGrid2.Row, "字段名称") Then
                Exit Sub
            End If
        Next
        For k = 0 To C1FlexGrid3.Rows.Count - 1
            If C1FlexGrid3.Item(k, "name") = "" Then
                ss = k
                Exit For
            End If
        Next

        C1FlexGrid3.Item(ss, "name") = C1FlexGrid2.Item(C1FlexGrid2.Row, "字段名称")
        C1FlexGrid3.Item(ss, "namenew") = C1FlexGrid2.Item(C1FlexGrid2.Row, "namenew")
        C1FlexGrid3.Item(ss, "tablealias") = C1FlexGrid2.Item(C1FlexGrid2.Row, "tablealias")
        C1FlexGrid3.Item(ss, "bt") = C1FlexGrid2.Item(C1FlexGrid2.Row, "bt")
        '  C1FlexGrid3.Item(ss, "fasc") = 1
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If C1FlexGrid3.Row > 0 Then
            C1FlexGrid3.Rows.Remove(C1FlexGrid3.Row)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If C1FlexGrid3.Row > 1 Then
            C1FlexGrid3.Rows.Move(C1FlexGrid3.Row, C1FlexGrid3.Row - 1)
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim k, ss As Integer
        For k = 0 To C1FlexGrid3.Rows.Count - 1
            If C1FlexGrid3.Item(k, "name") = "" Then
                ss = k
                Exit For
            End If
        Next
        If C1FlexGrid3.Row < ss Then
            C1FlexGrid3.Rows.Move(C1FlexGrid3.Row, C1FlexGrid3.Row + 1)
        End If
    End Sub
    'Public Sub setBilltype()
    '    Dim i, j As Integer
    '    Dim bb As DataSet
    '    Dim sqlstr As String
    '    getdate = New BLuser
    '    sqlstr = "SELECt fname as fbillname,ftrantype as fbillid,fbilltype FROM T_SGL_ICBILL  where flistid='" + SCrasoftid.ToString + "'"
    '    bb = getdate.GetDataset(strsql, constrmyh)
    '    billtype = 0
    '    If PublicSharedResource.PublicSharedFunctions.ChgNullToDouble(bb.Tables(0).Rows.Count) > 0 Then

    '        Me.cobCheckType.ValueMember = "fbillid"

    '        Me.cobCheckType.DisplayMember = "fbillname"
    '        Me.cobCheckType.DataSource = bb.Tables(0)
    '        Me.cobCheckType.SelectedIndex = 0
    '        strtrantype = cobCheckType.SelectedValue
    '        cobCheckType.Enabled = False
    '        billtype = bb.Tables(0).Rows(0)("Fbilltype")
    '    End If   ' SetSumCell()
    'End Sub '红蓝字的转换

    ''' <summary>
    ''' 删除选中行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>add by niky 2010-11-23</remarks>
    Private Sub delRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles delRow.Click
        Try
            If C1FlexGrid1.Row > 0 And C1FlexGrid1.Row < C1FlexGrid1.Rows.Count Then
                C1FlexGrid1.Rows.Remove(C1FlexGrid1.Row)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, "创源提示")
        End Try
    End Sub

    ''' <summary>
    ''' 上移
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim rowIndex As Integer = C1FlexGrid4.Row
            If rowIndex > 1 Then
                C1FlexGrid4.Rows(rowIndex).Move(rowIndex - 1)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, "创源提示")
        End Try
    End Sub

    ''' <summary>
    ''' 下移
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Dim rowIndex As Integer = C1FlexGrid4.Row
            If rowIndex < C1FlexGrid4.Rows.Count - 1 Then
                C1FlexGrid4.Rows(rowIndex).Move(rowIndex + 1)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, "创源提示")
        End Try
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try
            Dim Sql As String, width As String = "", field As String = ""
            Dim dt As DataSet
            If C1FlexGrid4.Rows.Count <= 0 Then Exit Sub
            For i As Integer = 1 To C1FlexGrid4.Rows.Count - 1
                If C1FlexGrid4(i, "show") = True Then
                    width += C1FlexGrid4(i, "width").ToString() + ","
                Else
                    width += "-1,"
                End If

                field += C1FlexGrid4(i, "name").ToString() + ","

            Next

            Sql = " exec P_SGL_RPTZDYBAOBIAOFormatlist '" & width & "'," & strtrantype & "," & m_UserID
            Sql += " exec P_nbb_FormatLocationWrite '" & field & "'," & strtrantype & "," & m_UserID
            getdate.GetDataset(Sql, constrmyh)
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, "创源提示")
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            For i As Integer = 1 To C1FlexGrid4.Rows.Count - 1
                C1FlexGrid4(i, "show") = True
            Next
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, "创源提示")
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            For i As Integer = 1 To C1FlexGrid4.Rows.Count - 1
                C1FlexGrid4(i, "show") = False
            Next
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, "创源提示")
        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            '加载默认值
            getIctemplateIndexList(1)
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, "创源提示")
        End Try
    End Sub

    Private Sub ListView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView.Click
        Dim strSql As String
        Dim ds As DataSet
        Try
            Me.Cursor = Cursors.WaitCursor
            If ListView.Row >= 0 And ListView.Row < ListView.Rows.Count Then
                nowFschemeIDname = ListView(ListView.Row, "FSchemeName")
                strSql = "select FschemeID from t_cy_ISProfile where Fschemename='" & nowFschemeIDname & "'and FUserID=" & m_UserID & " and Ftrantype=" & strtrantype & ""
                ds = getdate.GetDataset(strSql, constrmyh)
                If ds.Tables(0).Rows.Count > 0 Then
                    nowFschemeID = ds.Tables(0).Rows(0)("FschemeId")
                    ShowBilldata()
                End If
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub C1FlexGrid1_KeyDownEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyEditEventArgs) Handles C1FlexGrid1.KeyDownEdit

    '    Try
    '        If e.Col = 5 And C1FlexGrid1.Rows(e.Row)("fcoltype") = 2 Then
    '            If e.KeyCode.ToString > "9" Or e.KeyCode.ToString < "0" Then

    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Property constrmyh As String Implements ISelectBill.constrmyh
        Get
            Return _constrmyh
        End Get
        Set(ByVal value As String)
            _constrmyh = value
        End Set
    End Property

    Public Property dt As System.Data.DataTable Implements ISelectBill.dt
        Get
            Return _dt
        End Get
        Set(ByVal value As System.Data.DataTable)
            _dt = value
        End Set
    End Property

    Public Property dt1 As System.Data.DataTable Implements ISelectBill.dt1
        Get
            Return _dt1
        End Get
        Set(ByVal value As System.Data.DataTable)
            _dt1 = value
        End Set
    End Property

    Public Property listtype As String Implements ISelectBill.listtype
        Get
            Return _listtype
        End Get
        Set(ByVal value As String)
            _listtype = value
        End Set
    End Property

    Public Property m_UserID As String Implements ISelectBill.m_UserID
        Get
            Return _UserID
        End Get
        Set(ByVal value As String)
            _UserID = value
        End Set
    End Property

    Public Property PX As Integer Implements ISelectBill.PX
        Get
            Return _PX
        End Get
        Set(ByVal value As Integer)
            _PX = value
        End Set
    End Property

    Public Property SCrasoftid As Integer Implements ISelectBill.SCrasoftid
        Get
            Return _SCrasoftid
        End Get
        Set(ByVal value As Integer)
            _SCrasoftid = value
        End Set
    End Property

    Public Property strsql As String Implements ISelectBill.strsql
        Get
            Return _strsql
        End Get
        Set(ByVal value As String)
            _strsql = value
        End Set
    End Property

    Private _constrmyh As String
    Private _listtype As String
    Private _UserID As String
    Private _SCrasoftid As Integer
    Private _dt As DataTable
    Private _dt1 As DataTable
    Private _strsql As String
    Private _PX As Integer
End Class


