Imports PublicSharedResource
Imports SGL.BLL.BLuser
Public Class FrmMultiCheckSet
    Inherits frmBase
    Public BillType As Integer
    Private _MultiCheckSet As New MultiCheckSet
    Private CanntSave As Boolean

    Private Function GetMultiLevelRelationTool(ByVal TableName As String) As DataTable
        Dim Dtb As New DataTable
        Dim DtbRow As Data.DataColumn
        Dim row As DataRow
        Try

            Dtb.TableName = TableName
            DtbRow = New DataColumn()              '新建一列
            DtbRow.DataType = GetType(System.Int32)  '设置列类型
            DtbRow.ColumnName = "FBillType"      '设置列名                    
            DtbRow.AllowDBNull = False               ' 不允许为空
            Dtb.Columns.Add(DtbRow)            '把列添加到表中

            DtbRow = New DataColumn()              '新建一列
            DtbRow.DataType = GetType(System.String)  '设置列类型
            DtbRow.ColumnName = "FRelationTool"      '设置列名                    
            DtbRow.AllowDBNull = False               ' 不允许为空
            Dtb.Columns.Add(DtbRow)            '把列添加到表中

            DtbRow = New DataColumn()              '新建一列
            DtbRow.DataType = GetType(System.Int32)  '设置列类型
            DtbRow.ColumnName = "FMaxCheckLevel"      '设置列名                    
            DtbRow.AllowDBNull = False               ' 不允许为空
            Dtb.Columns.Add(DtbRow)            '把列添加到表中

            DtbRow = New DataColumn()              '新建一列
            DtbRow.DataType = GetType(System.Int32)  '设置列类型
            DtbRow.ColumnName = "FIsBillEntry"      '设置列名                    
            DtbRow.AllowDBNull = False               ' 不允许为空
            Dtb.Columns.Add(DtbRow)            '把列添加到表中

            For i As Integer = 1 To Me.C1FlexGrid8.Rows.Count - 1
                row = Dtb.NewRow
                row("FBillType") = BillType
                row("FRelationTool") = C1FlexGrid8.Rows(i)("FRelationTool")
                row("FMaxCheckLevel") = C1FlexGrid8.Rows(i)("FMaxCheckLevel")
                row("FIsBillEntry") = 0
                Dtb.Rows.Add(row)
            Next
            For i As Integer = 1 To Me.C1FlexGrid9.Rows.Count - 1
                row = Dtb.NewRow
                row("FBillType") = BillType
                row("FRelationTool") = C1FlexGrid9.Rows(i)("FRelationTool")
                row("FMaxCheckLevel") = C1FlexGrid9.Rows(i)("FMaxCheckLevel")
                row("FIsBillEntry") = 1
                Dtb.Rows.Add(row)
            Next
            Return Dtb
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 提取审核人界面数据
    ''' </summary>
    ''' <param name="TableName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMultiLevelCheck(ByVal TableName As String) As DataTable
        Dim Dtb As New DataTable
        Dim DtbRow As Data.DataColumn
        Dim row As DataRow
        Dim fx As C1.Win.C1FlexGrid.C1FlexGrid
        Dim IsBool As Boolean
        Try
            Dtb.TableName = TableName
            DtbRow = New DataColumn()              '新建一列
            DtbRow.DataType = GetType(System.Int32)  '设置列类型
            DtbRow.ColumnName = "FBillType"      '设置列名                    
            DtbRow.AllowDBNull = False               ' 不允许为空
            Dtb.Columns.Add(DtbRow)            '把列添加到表中

            DtbRow = New DataColumn()              '新建一列
            DtbRow.DataType = GetType(System.Int32)  '设置列类型
            DtbRow.ColumnName = "FCheckLevel"      '设置列名                    
            DtbRow.AllowDBNull = False               ' 不允许为空
            Dtb.Columns.Add(DtbRow)            '把列添加到表中

            DtbRow = New DataColumn()              '新建一列
            DtbRow.DataType = GetType(System.Int32)  '设置列类型
            DtbRow.ColumnName = "FCheckerID"      '设置列名                    
            DtbRow.AllowDBNull = False               ' 不允许为空
            Dtb.Columns.Add(DtbRow)            '把列添加到表中

            For i As Integer = 1 To Me.FCheckLevel.Value
                Select Case i
                    Case 1
                        fx = C1FlexGrid2
                    Case 2
                        fx = C1FlexGrid3
                    Case 3
                        fx = C1FlexGrid4
                    Case 4
                        fx = C1FlexGrid5
                    Case 5
                        fx = C1FlexGrid6
                    Case 6
                        fx = C1FlexGrid7
                End Select
                IsBool = False
                For j As Integer = 1 To fx.Rows.Count - 1
                    row = Dtb.NewRow
                    row("FBillType") = Me.BillType
                    row("FCheckLevel") = i
                    row("FCheckerID") = fx.Rows(j)("FCheckerID")
                    Dtb.Rows.Add(row)
                    IsBool = True
                Next
                If IsBool = False Then
                    CanntSave = True
                    Return Dtb
                End If
            Next
            Return Dtb
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 提取基本设置界面数据
    ''' </summary>
    ''' <param name="TableName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMultiCheckOption(ByVal TableName As String) As DataTable
        Dim Dtb As New DataTable
        Dim DtbRow As Data.DataColumn
        Dim row As DataRow
        Try
            'Dtb.TableName = "t_ZZ_MultiCheckOption"
            Dtb.TableName = TableName

            DtbRow = New DataColumn()              '新建一列
            DtbRow.DataType = GetType(System.Int32)  '设置列类型
            DtbRow.ColumnName = "FBillType"      '设置列名                    
            DtbRow.AllowDBNull = False               ' 不允许为空
            Dtb.Columns.Add(DtbRow)            '把列添加到表中

            DtbRow = New DataColumn()              '新建一列
            DtbRow.DataType = GetType(System.String)  '设置列类型
            DtbRow.ColumnName = "FOptionValue"      '设置列名                    
            DtbRow.AllowDBNull = False               ' 不允许为空
            Dtb.Columns.Add(DtbRow)            '把列添加到表中

            DtbRow = New DataColumn()              '新建一列
            DtbRow.DataType = GetType(System.Decimal)  '设置列类型
            DtbRow.ColumnName = "FMultiCheckAmount"      '设置列名                    
            DtbRow.AllowDBNull = False               ' 不允许为空
            Dtb.Columns.Add(DtbRow)            '把列添加到表中

            DtbRow = New DataColumn()              '新建一列
            DtbRow.DataType = GetType(System.Int32)  '设置列类型
            DtbRow.ColumnName = "FCurrencyID"      '设置列名                    
            DtbRow.AllowDBNull = False               ' 不允许为空
            Dtb.Columns.Add(DtbRow)            '把列添加到表中

            DtbRow = New DataColumn()              '新建一列
            DtbRow.DataType = GetType(System.Int32)  '设置列类型
            DtbRow.ColumnName = "FCheckLevel"      '设置列名                    
            DtbRow.AllowDBNull = False               ' 不允许为空
            Dtb.Columns.Add(DtbRow)            '把列添加到表中

            DtbRow = New DataColumn()              '新建一列
            DtbRow.DataType = GetType(System.Int32)  '设置列类型
            DtbRow.ColumnName = "FMaxCheckLevel"      '设置列名                    
            DtbRow.AllowDBNull = False               ' 不允许为空
            Dtb.Columns.Add(DtbRow)            '把列添加到表中

            row = Dtb.NewRow()          '给表新增一行，并取得行对象

            row("FBillType") = BillType
            row("FOptionValue") = IIf(CheFCurrency.Checked, "1", "0") & "," & IIf(CheMultiCheckAmount.Checked, "1", "0")
            row("FMultiCheckAmount") = 20000
            row("FCurrencyID") = 1
            row("FCheckLevel") = FCheckLevel.Value
            row("FMaxCheckLevel") = FMaxCheckLevel.Value
            Dtb.Rows.Add(row)
            Return Dtb
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 窗体初始化
    ''' </summary>
    ''' <param name="trantype"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InitalFrm(ByVal trantype As String) As Boolean
        Dim DataChecker As New DataSet
        Dim n, m As Integer
        Try
            _MultiCheckSet.ConnStrValue = Me.CYSysInfo.ConnStrValue
            _MultiCheckSet.Trantype = BillType
            '审核人员名单
            DataChecker = _MultiCheckSet.GetUserData
            C1FlexGrid1.Rows.Count = DataChecker.Tables(0).Rows.Count + 1
            For i As Integer = 0 To DataChecker.Tables(0).Rows.Count - 1
                Me.C1FlexGrid1.Rows(i + 1)("FUserID") = DataChecker.Tables(0).Rows(i)("FUserID")
                Me.C1FlexGrid1.Rows(i + 1)("FName") = DataChecker.Tables(0).Rows(i)("FName")
            Next

            '加载界面数据
            DataChecker = _MultiCheckSet.GetMultiData
            If DataChecker.Tables(0).Rows.Count > 0 Then
                CheIsUse.Checked = True
                FCheckLevel.Value = DataChecker.Tables(0).Rows(0)("FCheckLevel")
                FMaxCheckLevel.Value = DataChecker.Tables(0).Rows(0)("FMaxCheckLevel")
            End If
            n = 0 : m = 0
            If DataChecker.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To DataChecker.Tables(1).Rows.Count - 1
                    If n <> DataChecker.Tables(1).Rows(i)("FCheckLevel") Then
                        n = DataChecker.Tables(1).Rows(i)("FCheckLevel")
                        m = 1
                    Else
                        m += m
                    End If
                    If n = 1 Then
                        Me.C1FlexGrid2.Rows.Add()
                        Me.C1FlexGrid2.Rows(m)("FCheckerID") = DataChecker.Tables(1).Rows(i)("FCheckerID")
                        Me.C1FlexGrid2.Rows(m)("CCheckerName") = DataChecker.Tables(1).Rows(i)("CCheckerName")
                    ElseIf n = 2 Then
                        Me.C1FlexGrid3.Rows.Add()
                        Me.C1FlexGrid3.Rows(m)("FCheckerID") = DataChecker.Tables(1).Rows(i)("FCheckerID")
                        Me.C1FlexGrid3.Rows(m)("CCheckerName") = DataChecker.Tables(1).Rows(i)("CCheckerName")
                    ElseIf n = 3 Then
                        Me.C1FlexGrid4.Rows.Add()
                        Me.C1FlexGrid4.Rows(m)("FCheckerID") = DataChecker.Tables(1).Rows(i)("FCheckerID")
                        Me.C1FlexGrid4.Rows(m)("CCheckerName") = DataChecker.Tables(1).Rows(i)("CCheckerName")
                    ElseIf n = 4 Then
                        Me.C1FlexGrid5.Rows.Add()
                        Me.C1FlexGrid5.Rows(m)("FCheckerID") = DataChecker.Tables(1).Rows(i)("FCheckerID")
                        Me.C1FlexGrid5.Rows(m)("CCheckerName") = DataChecker.Tables(1).Rows(i)("CCheckerName")
                    ElseIf n = 5 Then
                        Me.C1FlexGrid6.Rows.Add()
                        Me.C1FlexGrid6.Rows(m)("FCheckerID") = DataChecker.Tables(1).Rows(i)("FCheckerID")
                        Me.C1FlexGrid6.Rows(m)("CCheckerName") = DataChecker.Tables(1).Rows(i)("CCheckerName")
                    ElseIf n = 6 Then
                        Me.C1FlexGrid7.Rows.Add()
                        Me.C1FlexGrid7.Rows(m)("FCheckerID") = DataChecker.Tables(1).Rows(i)("FCheckerID")
                        Me.C1FlexGrid7.Rows(m)("CCheckerName") = DataChecker.Tables(1).Rows(i)("CCheckerName")
                    End If
                Next
            End If
            n = 0 : m = 0
            C1FlexGrid8.Rows.Count = 1
            C1FlexGrid9.Rows.Count = 1
            If DataChecker.Tables(2).Rows.Count > 0 Then
                For i As Integer = 0 To DataChecker.Tables(2).Rows.Count - 1
                    If DataChecker.Tables(2).Rows(i)("FRight") > 0 Then
                        n = n + 1
                        C1FlexGrid8.Rows.Count = n + 1
                        Me.C1FlexGrid8.Rows(n)("FrelationTool") = DataChecker.Tables(2).Rows(i)("FrelationTool")
                        Me.C1FlexGrid8.Rows(n)("FToolName") = DataChecker.Tables(2).Rows(i)("FToolName")
                        Me.C1FlexGrid8.Rows(n)("FMaxCheckLevel") = DataChecker.Tables(2).Rows(i)("FMaxCheckLevel")
                    Else
                        m = m + 1
                        C1FlexGrid9.Rows.Count = m + 1
                        Me.C1FlexGrid9.Rows(m)("FrelationTool") = DataChecker.Tables(2).Rows(i)("FrelationTool")
                        Me.C1FlexGrid9.Rows(m)("FToolName") = DataChecker.Tables(2).Rows(i)("FToolName")
                        Me.C1FlexGrid9.Rows(m)("FMaxCheckLevel") = DataChecker.Tables(2).Rows(i)("FMaxCheckLevel")
                    End If
                Next
            End If
            Return True

        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
    Public Sub New()
        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Private Sub ButSel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButSel.Click
        Dim ctrl As New Control.ControlCollection(Owner)
        Dim fx As New C1.Win.C1FlexGrid.C1FlexGrid
        Dim IsHave As Boolean = False
        Dim IntAddUserID As Integer
        Dim StrAddUserName As String
        Try
            If Me.CheIsUse.Checked = False Then
                Exit Sub
            End If
            ctrl = Me.TabControl2.SelectedTab.Controls
            For i As Integer = 0 To ctrl.Count - 1
                If ctrl.Item(i).Name.IndexOf("FlexGrid") >= 0 Then
                    fx = CType(ctrl.Item(i), C1.Win.C1FlexGrid.C1FlexGrid)
                End If
            Next

            If Me.C1FlexGrid1.Row > 0 Then
                IntAddUserID = C1FlexGrid1.Rows(C1FlexGrid1.Row)("FUserID")
                StrAddUserName = C1FlexGrid1.Rows(C1FlexGrid1.Row)("FName")
                For i As Integer = 1 To fx.Rows.Count - 1
                    If fx.Rows(i)("FCheckerID") = IntAddUserID Then
                        IsHave = True
                        Exit For
                    End If
                Next
                If IsHave = False Then
                    fx.Rows.Add()
                    fx.Rows(fx.Rows.Count - 1)("FCheckerID") = IntAddUserID
                    fx.Rows(fx.Rows.Count - 1)("CCheckerName") = StrAddUserName
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ButDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButDel.Click
        Dim ctrl As New Control.ControlCollection(Owner)
        Dim fx As New C1.Win.C1FlexGrid.C1FlexGrid
        Dim IsHave As Boolean = False
        Try
            If Me.CheIsUse.Checked = False Then
                Exit Sub
            End If
            ctrl = Me.TabControl2.SelectedTab.Controls
            For i As Integer = 0 To ctrl.Count - 1
                If ctrl.Item(i).Name.IndexOf("FlexGrid") >= 0 Then
                    fx = CType(ctrl.Item(i), C1.Win.C1FlexGrid.C1FlexGrid)
                End If
            Next

            If fx.Row > 0 Then
                fx.Rows.Remove(1)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ButChale_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButChale.Click

        Me.Close()

    End Sub

    Private Sub ButOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButOK.Click

        Dim DataSource As New DataSet

        Try
            DataSource.Tables.Add(GetMultiCheckOption("t_ZZ_MultiCheckOption"))
            DataSource.Tables.Add(GetMultiLevelCheck("t_ZZ_MultiLevelCheck"))
            DataSource.Tables.Add(GetMultiLevelRelationTool("t_ZZ_MultiCheckRelationTool"))
            If CanntSave Then
                MsgBox("审核人没有添完整，保存失败", vbOKOnly, "创源提示")
            Else
                If _MultiCheckSet.SaveData(DataSource) = True Then
                    MsgBox("保存成功", MsgBoxStyle.OkOnly, "创源提示")
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FrmMultiCheckSet_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Me.Dispose(Disposing)

    End Sub

    Private Sub FrmMultiCheckSet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If InitalFrm(BillType) = False Then
            Me.Dispose()
        End If
    End Sub

    Private Sub FCheckLevel_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FCheckLevel.ValueChanged

        Try
            If Me.CheIsUse.Checked = False Then
                Exit Sub
            End If
            Select Case FCheckLevel.Value
                Case 6
                    Panel1.Location = New Point(482, 32)
                    Panel1.Width = 0
                Case 5
                    Panel1.Location = New Point(434, 32)
                    Panel1.Width = 51
                Case 4
                    Panel1.Location = New Point(388, 32)
                    Panel1.Width = 95
                Case 3
                    Panel1.Location = New Point(337, 32)
                    Panel1.Width = 146
                Case 2
                    Panel1.Location = New Point(288, 32)
                    Panel1.Width = 195
                Case 1
                    Panel1.Location = New Point(241, 32)
                    Panel1.Width = 242
            End Select

            Me.FMaxCheckLevel.Maximum = FCheckLevel.Value

            For i As Integer = 1 To C1FlexGrid8.Rows.Count - 1
                If C1FlexGrid8.Rows(i)("FMaxCheckLevel") > FCheckLevel.Value Then
                    C1FlexGrid8.Rows(i)("FMaxCheckLevel") = FCheckLevel.Value
                End If
            Next
            For i As Integer = 1 To C1FlexGrid9.Rows.Count - 1
                If C1FlexGrid9.Rows(i)("FMaxCheckLevel") > FCheckLevel.Value Then
                    C1FlexGrid9.Rows(i)("FMaxCheckLevel") = FCheckLevel.Value
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
Public Class MultiCheckSet
    Public ConnStrValue As String
    Public Trantype As String
    Public Function GetUserData() As DataSet
        Dim strSql As String
        Dim Data As New DataSet
        Dim OpenDB As New BLL.BLuser

        Try
            strSql = "select FUserID,FName from t_user "
            Data = OpenDB.GetDataset(strSql, ConnStrValue)

            Return Data
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetMultiData() As DataSet
        Dim strSql As String = ""
        Dim Data As New DataSet
        Dim OpenDB As New BLL.BLuser
        Try

            strSql = "select FOptionValue,FMultiCheckAmount,FCheckLevel,FMaxCheckLevel from t_ZZ_MultiCheckOption where  FBillType=" & Trantype

            strSql = strSql & " select t1.FCheckLevel,t1.FCheckerID,t2.FName CCheckerName from t_ZZ_MultiLevelCheck t1 "
            strSql = strSql & " inner join t_user t2 on t1.FCheckerID=t2.FUserID where FBillType=" & Trantype


            strSql = strSql & " select distinct  t2.FNumber FrelationTool,t2.FName FToolName,isnull(t1.FMaxCheckLevel,6) FMaxCheckLevel,t3.FRight "
            strSql = strSql & " from t_SGL_MenuTooL t2 inner join t_sgl_menutree t3 on t3.Fright=t2.Fright "
            strSql = strSql & " left join t_ZZ_MultiCheckRelationTool t1  on t1.FRelationTool=t2.FNumber and t3.FBillID=t1.FBillType and  FBillType=" & Trantype
            strSql = strSql & " where FRelatCheck=1  order by t3.FRight desc "
            Data = OpenDB.GetDataset(strSql, ConnStrValue)

            Return Data

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function SaveData(ByVal DataSoure As DataSet) As Boolean
        Dim StrSqlHead As String = ""
        Dim StrSqlEntry As String = ""
        Dim strSql As String = ""
        Dim Data As New DataSet
        Dim OpenDB As New BLL.BLuser
        Try
            For i As Integer = 0 To DataSoure.Tables.Count - 1
                If DataSoure.Tables(i).Rows.Count > 0 Then
                    StrSqlHead = ""
                    StrSqlEntry = ""
                    StrSqlHead = StrSqlHead & " insert into " & DataSoure.Tables(i).TableName & " ("
                    For j As Integer = 0 To DataSoure.Tables(i).Columns.Count - 1
                        StrSqlHead = StrSqlHead & DataSoure.Tables(i).Columns(j).ColumnName & ","
                    Next
                    StrSqlHead = StrSqlHead.Substring(0, Len(StrSqlHead) - 1) & ")"
                    For j As Integer = 0 To DataSoure.Tables(i).Rows.Count - 1
                        StrSqlEntry = " values("
                        For k As Integer = 0 To DataSoure.Tables(i).Columns.Count - 1
                            If IsDBNull(DataSoure.Tables(i).Rows(j)(k)) = True Then
                                If DataSoure.Tables(i).Columns(k).DataType.Name = "Decimal" Or DataSoure.Tables(i).Columns(k).DataType.Name = "Double" Or DataSoure.Tables(i).Columns(k).DataType.Name = "Int32" Or DataSoure.Tables(i).Columns(k).DataType.Name = "Int64" Then
                                    StrSqlEntry = StrSqlEntry & "0,"
                                ElseIf DataSoure.Tables(i).Columns(k).DataType.Name = "String" Then
                                    StrSqlEntry = StrSqlEntry & "'',"
                                Else
                                    StrSqlEntry = StrSqlEntry & "null,"
                                End If
                            Else
                                If DataSoure.Tables(i).Columns(k).DataType.Name = "Decimal" Or DataSoure.Tables(i).Columns(k).DataType.Name = "Double" Or DataSoure.Tables(i).Columns(k).DataType.Name = "Int32" Or DataSoure.Tables(i).Columns(k).DataType.Name = "Int64" Then
                                    StrSqlEntry = StrSqlEntry & DataSoure.Tables(i).Rows(j)(k) & ","
                                ElseIf DataSoure.Tables(i).Columns(k).DataType.Name = "String" Then
                                    StrSqlEntry = StrSqlEntry & "'" & DataSoure.Tables(i).Rows(j)(k) & "',"
                                End If
                            End If
                        Next
                        StrSqlEntry = StrSqlEntry.Substring(0, StrSqlEntry.Length - 1) & ")"
                        strSql = strSql & StrSqlHead & StrSqlEntry
                    Next

                End If
            Next
            If strSql <> "" Then
                strSql = "delete from t_ZZ_MultiCheckOption where FbillType=" & Trantype & " delete from t_ZZ_MultiLevelCheck where FbillType=" & Trantype & " delete from t_ZZ_MultiCheckRelationTool where FbillType=" & Trantype & " " & strSql
                OpenDB.sqlexecnon(strSql, ConnStrValue)
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class