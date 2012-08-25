Imports SGL.BLL
Imports SGL.BaseData
Imports PublicSharedResource
Imports PublicSharedResource.PublicSharedFunctions
Public Class FrmTH
    Inherits frmBase

#Region "参数"
    Public InterID As Integer
    Public EntryID As Integer
    Private GetDataSet As New BLuser
    Private HBBool As Boolean
#End Region
#Region "函数"
    ''' <summary>
    ''' 基础资料窗体的使用
    ''' </summary>
    ''' <param name="itm"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Loaditamdate(ByVal itm As String) As System.Data.DataTable
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
            newform3.S_Classid = clid * -1
            newform3.ShowDialog()
            If newform3.RtnDataTable.Tables.Count > 0 Then
                ssss = newform3.RtnDataTable.Tables(0)
                Return ssss
            End If
        Else
            newform2.constr = Me.CYSysInfo.ConnStrValue
            newform2.S_Classid = clid
            'If clid = 3004 And PublicSharedFunctions.ChgNullToDouble(FCustID.Value) > 0 Then
            '    newform2.ZzjGetStr = FCustID.Value.ToString
            'End If
            newform2.ShowDialog()
            If newform2.RtnDataTable.Tables.Count > 0 Then
                ssss = newform2.RtnDataTable.Tables(0)
                Return ssss
            End If
        End If
        Return Nothing
    End Function

#End Region
    Private Sub FrmTH_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim StrSql As String
        Dim Ds As New DataSet
        Dim strWAPItemID As String
        Try
            StrSql = "select t2.FItemID,t2.FName,t2.FNumber,t2.FModel,isnull(t1.FSwapItemID,'') FSwapItemID,isnull(FHBWay,0) FHBWay,isnull(FNeedSwape,0) FNeedSwape "
            StrSql = StrSql & " from seoutstockentry t1 inner join t_icitem t2 on t1.FitemID=t2.FitemID "
            StrSql = StrSql & "  where FInterID=" & InterID & " and FEntryID=" & EntryID
            Ds = GetDataSet.GetDataset(StrSql, Me.CYSysInfo.ConnStrValue)
            Me.C1FlexGrid1.Rows.Count = Ds.Tables(0).Rows.Count + 1
            If Ds.Tables(0).Rows.Count > 0 Then

                C1FlexGrid1.Rows(1)(1) = PublicSharedFunctions.ChgNullToDouble(Ds.Tables(0).Rows(0)(0))
                C1FlexGrid1.Rows(1)(2) = PublicSharedFunctions.ChgNull(Ds.Tables(0).Rows(0)(1))
                C1FlexGrid1.Rows(1)(3) = PublicSharedFunctions.ChgNull(Ds.Tables(0).Rows(0)(2))
                C1FlexGrid1.Rows(1)(4) = PublicSharedFunctions.ChgNull(Ds.Tables(0).Rows(0)(3))

                If PublicSharedFunctions.ChgNullToDouble(Ds.Tables(0).Rows(0)("FHBWay")) = 0 Then
                    RadioButHB.Checked = False
                    RadioButJJ.Checked = True
                Else
                    RadioButJJ.Checked = False
                    RadioButHB.Checked = True
                End If
                RadioButHB.Checked = IIf(PublicSharedFunctions.ChgNullToDouble(Ds.Tables(0).Rows(0)("FHBWay")) = 0, False, True)
                cb_NeedSwape.Checked = IIf(PublicSharedFunctions.ChgNullToDouble(Ds.Tables(0).Rows(0)("FNeedSwape")) = 0, False, True)
                strWAPItemID = PublicSharedFunctions.ChgNull(Ds.Tables(0).Rows(0)("FSwapItemID"))
                If strWAPItemID <> "" Then
                    StrSql = "select FItemID,FName,FNumber,FModel from t_icitem where FItemID in (" & strWAPItemID & ")"
                    Ds = GetDataSet.GetDataset(StrSql, Me.CYSysInfo.ConnStrValue)

                    If Ds.Tables(0).Rows.Count > 0 Then
                        Me.C1FlexGrid2.Rows.Count = Ds.Tables(0).Rows.Count + 1
                        For i As Integer = 0 To Ds.Tables(0).Rows.Count - 1
                            C1FlexGrid2.Rows(i + 1)(1) = PublicSharedFunctions.ChgNullToDouble(Ds.Tables(0).Rows(i)(0))
                            C1FlexGrid2.Rows(i + 1)(2) = PublicSharedFunctions.ChgNull(Ds.Tables(0).Rows(i)(1))
                            C1FlexGrid2.Rows(i + 1)(3) = PublicSharedFunctions.ChgNull(Ds.Tables(0).Rows(i)(2))
                            C1FlexGrid2.Rows(i + 1)(4) = PublicSharedFunctions.ChgNull(Ds.Tables(0).Rows(i)(3))
                        Next
                    End If

                End If

            End If




        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ButTH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButTH.Click
        Dim DsTable As New DataTable
        Try
            If Me.C1FlexGrid1.Row > 0 Then
                DsTable = Loaditamdate(4)
                If DsTable.Rows.Count > 0 Then
                    C1FlexGrid2.Rows(C1FlexGrid1.Row)(1) = DsTable.Rows(0)(0)
                    C1FlexGrid2.Rows(C1FlexGrid1.Row)(2) = DsTable.Rows(0)("FName")
                    C1FlexGrid2.Rows(C1FlexGrid1.Row)(3) = DsTable.Rows(0)("FNumber")
                    C1FlexGrid2.Rows(C1FlexGrid1.Row)(4) = DsTable.Rows(0)("FModel")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ButChanle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButChanle.Click

        Me.Close()
    End Sub

    Private Sub ButTHChinal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButTHChinal.Click

        Try
            C1FlexGrid2.Rows(C1FlexGrid1.Row)(1) = 0
            C1FlexGrid2.Rows(C1FlexGrid1.Row)(2) = ""
            C1FlexGrid2.Rows(C1FlexGrid1.Row)(3) = ""
            C1FlexGrid2.Rows(C1FlexGrid1.Row)(4) = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub C1FlexGrid2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles C1FlexGrid2.KeyDown
        Dim dsTable As DataTable
        Dim i As Integer = 0
        Try

            If C1FlexGrid2.Row > 1 Then
                If PublicSharedFunctions.ChgNullToDouble(C1FlexGrid2.Item(C1FlexGrid2.Row - 1, "fitemid")) = 0 Then
                    Exit Sub
                End If
            End If

            Me.Cursor = Cursors.WaitCursor

            If e.KeyCode = Keys.F7 Then

                If C1FlexGrid2.Cols(C1FlexGrid2.Col).Name = "FNumber" Then      '物料
                    dsTable = Loaditamdate(4)
                    If dsTable.Rows.Count > 0 Then
                        C1FlexGrid2.Rows(C1FlexGrid2.Row)(1) = dsTable.Rows(0)(0)
                        C1FlexGrid2.Rows(C1FlexGrid2.Row)(2) = dsTable.Rows(0)("FName")
                        C1FlexGrid2.Rows(C1FlexGrid2.Row)(3) = dsTable.Rows(0)("FNumber")
                        C1FlexGrid2.Rows(C1FlexGrid2.Row)(4) = dsTable.Rows(0)("FModel")
                    End If
                End If

            End If
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            'BillDisposed()
            Throw ex
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ButOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButOk.Click
        Dim StrSql As String
        Dim Ds As New DataSet
        Dim _hbWay As Integer
        Dim _needSwape As Integer
        Dim strItems As String = ""
        Try
            If RadioButJJ.Checked Then
                _hbWay = 0
            Else
                _hbWay = 1
            End If
            If cb_NeedSwape.Checked Then
                _needSwape = 1
            Else
                _needSwape = 0
            End If
            For i As Integer = 1 To C1FlexGrid2.Rows.Count - 1
                If PublicSharedFunctions.ChgNullToDouble(C1FlexGrid2.Item(i, "fitemid")) > 0 Then
                    strItems = strItems & C1FlexGrid2.Item(i, "fitemid") & ","
                End If
            Next
            If strItems <> "" Then
                strItems = strItems.Substring(0, strItems.Length - 1)
                StrSql = "update SEOutStockentry set FSwapItemID='" & strItems & "' where FInterID=" & InterID & " and FEntryID=" & EntryID
                StrSql += " update SEOutStockentry set FHBWay=" & _hbWay.ToString() & ",FNeedSwape=" & _needSwape.ToString() & "where FInterID=" & InterID
                GetDataSet.sqlexecnon(StrSql, Me.CYSysInfo.ConnStrValue)
                MsgBox("物料替换成功", MsgBoxStyle.OkOnly, "创源提示")
                Me.Close()
            Else
                If MsgBox("是否确定取消物料替换并退出？", MsgBoxStyle.OkCancel, "创源提示") = MsgBoxResult.Ok Then
                    StrSql = "update SEOutStockentry set FSwapItemID='' where FInterID=" & InterID & " and FEntryID=" & EntryID
                    GetDataSet.sqlexecnon(StrSql, Me.CYSysInfo.ConnStrValue)
                    Me.Close()
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub RadioButHB_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButHB.CheckedChanged

    '    Try
    '        If HBBool = False Then
    '            HBBool = True
    '            If RadioButHB.Checked = True Then
    '                RadioButJJ.Checked = False
    '            Else
    '                RadioButHB.Checked = True
    '            End If
    '            HBBool = False
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub RadioButJJ_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButJJ.CheckedChanged

    '    Try
    '        If HBBool = False Then
    '            HBBool = True
    '            If RadioButHB.Checked = True Then
    '                RadioButJJ.Checked = False
    '            Else
    '                RadioButHB.Checked = True
    '            End If
    '            HBBool = True
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub ButAddRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButAddRow.Click
        C1FlexGrid2.Rows.Count = C1FlexGrid2.Rows.Count + 1
    End Sub

    Private Sub ButDelRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButDelRow.Click
        C1FlexGrid2.Rows.Remove(C1FlexGrid2.Row)
    End Sub
End Class