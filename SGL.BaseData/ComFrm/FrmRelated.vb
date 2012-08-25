Imports System.Windows.Forms
Imports PublicSharedResource
Imports PublicSharedResource.PublicSharedFunctions
Imports SGL.BLL
Imports SGL
Imports C1.Win.C1FlexGrid
Public Class FrmRelated
    Inherits frmBase
    Public DS As DataTable    '包含单据内码FInterID，关联单据类型FTrantype，关联单据内码FInterIDGL，本张单据关联金额FKJAmount
    Public CustName As String
    Public IsCust As Boolean = True
    Public hx As Hashtable
    Private Trantype As Integer = 0
    Private InterID As Integer
    Private TempDT As DataTable
    Public ReturnBack As Boolean
    Public TotleKJAmount As Double
#Region "方法"
    ''' <summary>
    ''' 基础资料
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
        Try
            If itm = "" Then
                Return Nothing
            End If
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
                If clid = -99989 Then
                    newform3.IM = "1"
                End If
                newform3.ShowDialog()
                If newform3.RtnDataTable.Tables.Count > 0 Then
                    ssss = newform3.RtnDataTable.Tables(0)
                    Return ssss
                End If
            Else
                newform2.constr = Me.CYSysInfo.ConnStrValue
                newform2.S_Classid = clid
                newform2.ShowDialog()
                If newform2.RtnDataTable.Tables.Count > 0 Then
                    ssss = newform2.RtnDataTable.Tables(0)
                    Return ssss
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function Check() As Boolean
        Dim i As Integer
        Dim DataCount As Integer = 0
        Dim Row As DataRow
        Try
            Me.FCustID.Focus()
            For i = 1 To Me.C1FlexGrid1.Rows.Count - 1
                If C1FlexGrid1.Rows(i)("FSel") = True Then
                    If PublicSharedFunctions.ChgNullToDouble(C1FlexGrid1.Rows(i)("FSYKJAmount")) < PublicSharedFunctions.ChgNullToDouble(C1FlexGrid1.Rows(i)("FKJAmount")) Then
                        MsgBox("扣减金额不能超过剩余金额，请检查后再确认！", MsgBoxStyle.OkOnly, "创源提示")
                        Return False
                    ElseIf PublicSharedFunctions.ChgNullToDouble(C1FlexGrid1.Rows(i)("FKJAmount")) <= 0 Then
                        MsgBox("扣减金额必须大于0，请检查后再确认！", MsgBoxStyle.OkOnly, "创源提示")
                        Return False
                    Else
                        Row = TempDT.NewRow()
                        Row.Item("FinterID") = C1FlexGrid1.Rows(i)("FinterID")
                        Row.Item("FTrantype") = C1FlexGrid1.Rows(i)("FTrantype")
                        Row.Item("FKJAmount") = C1FlexGrid1.Rows(i)("FKJAmount")
                        TempDT.Rows.Add(Row)
                    End If
                    DataCount += 1
                End If
            Next
            If DataCount = 0 Then
                MsgBox("没有关联单据，不能确认？", MsgBoxStyle.OkOnly, "创源提示")
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region
    Private Sub FrmRelated_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim StrSql As String
        Dim TempDs As DataSet
        Dim GetDataBluse As New BLuser
        Dim j, k As Integer
        Dim Amount, KJAmount As Double
        Dim rg As CellRange
        Try

            Trantype = hx.Item("FTrantype")
            InterID = hx.Item("FInterID")
            DS = hx.Item("DSTable")

            TempDT = New DataTable

            Dim dc As DataColumn
            dc = New DataColumn
            dc.AllowDBNull = True
            dc.ColumnName = "FInterID"
            dc.DataType = System.Type.GetType("System.Int32")
            TempDT.Columns.Add(dc)

            dc = New DataColumn
            dc.AllowDBNull = True
            dc.ColumnName = "FTrantype"
            dc.DataType = System.Type.GetType("System.Int32")
            TempDT.Columns.Add(dc)

            dc = New DataColumn
            dc.AllowDBNull = True
            dc.ColumnName = "FKJAmount"
            dc.DataType = System.Type.GetType("System.Double")
            TempDT.Columns.Add(dc)

            Me.FCustID.Text = CustName
            If IsCust = False Then
                Me.Label1.Text = "供应商"
                Me.FCustID.DataField = 8
                Trantype = 20110422
                StrSql = "select v1.FinterID,v1.Ftrantype,v1.FbillNo,v1.FHtno,case Ftrantype when 20110413 then '' else t2.FName end FCustName,t1.Fname FtrantypeName,v1.FAmount-isnull(u1.FKJAmount,0) FSYKJAmount "
                StrSql = StrSql & " from t_ZZ_Repay v1 left join (select sum(FKJAmount) FKJAmount,FinterID from t_ZZ_RepayEntry "
                StrSql = StrSql & " where FinterID_next<>" & InterID & " or FTrantype_next not in (20110422,20110413) group by FInterID) u1 on v1.FInterID=u1.FinterID"
                StrSql = StrSql & " left join T_SGL_BILLTABLE t1 on t1.Fid=v1.FTrantype left join t_item t2 on t2.FitemID=v1.FCustID  and t2.FitemID>0 "
                StrSql = StrSql & " where v1.Ftrantype in (20110422,20110413) and FCheckerID>0 and v1.FStatus<3 and  t2.Fname='" & CustName & "' order by v1.FinterID"
            Else
                Me.Label1.Text = "客户"
                Me.FCustID.DataField = 1
                StrSql = "select v1.FinterID,v1.Ftrantype,v1.FbillNo,v1.FHtno,t2.FName FCustName,t1.Fname FtrantypeName,v1.FAmount-isnull(u1.FKJAmount,0) FSYKJAmount "
                StrSql = StrSql & " from t_ZZ_Repay v1 left join (select sum(FKJAmount) FKJAmount,FinterID from t_ZZ_RepayEntry "
                StrSql = StrSql & " where FinterID_next<>" & InterID & " or FTrantype_next<>" & Trantype & " group by FInterID) u1 on v1.FInterID=u1.FinterID"
                StrSql = StrSql & " left join T_SGL_BILLTABLE t1 on t1.Fid=v1.FTrantype left join t_item t2 on t2.FitemID=v1.FCustID and t2.FItemClassID=1   and t2.FitemID>0 "
                StrSql = StrSql & " where v1.Ftrantype<>20110422 and FCheckerID>0  and v1.FStatus<3 and  t2.Fname='" & CustName & "' order by v1.FinterID"
            End If
            TempDs = GetDataBluse.GetDataset(StrSql, Me.CYSysInfo.ConnStrValue)
            C1FlexGrid1.Rows.Count = TempDs.Tables(0).Rows.Count + 1
            For i As Integer = 1 To TempDs.Tables(0).Rows.Count
                Me.C1FlexGrid1.Rows(i)("FinterID") = TempDs.Tables(0).Rows(i - 1)("FinterID")
                Me.C1FlexGrid1.Rows(i)("Ftrantype") = TempDs.Tables(0).Rows(i - 1)("Ftrantype")

                If TempDs.Tables(0).Rows(i - 1)("Ftrantype") = 20110413 Then
                    For t As Integer = 1 To C1FlexGrid1.Cols.Count - 1
                        rg = C1FlexGrid1.GetCellRange(i, t)
                        rg.StyleNew.BackColor = Color.FromArgb(255, 255, 220)
                    Next
                    Amount = Amount + TempDs.Tables(0).Rows(i - 1)("FSYKJAmount")
                Else
                    Amount = Amount - TempDs.Tables(0).Rows(i - 1)("FSYKJAmount")
                End If

                Me.C1FlexGrid1.Rows(i)("FtrantypeName") = TempDs.Tables(0).Rows(i - 1)("FtrantypeName")
                Me.C1FlexGrid1.Rows(i)("FSYKJAmount") = TempDs.Tables(0).Rows(i - 1)("FSYKJAmount")
                Me.C1FlexGrid1.Rows(i)("FbillNo") = TempDs.Tables(0).Rows(i - 1)("FbillNo")
                Me.C1FlexGrid1.Rows(i)("FHtno") = TempDs.Tables(0).Rows(i - 1)("FHtno")
                Me.C1FlexGrid1.Rows(i)("FCustName") = PublicSharedFunctions.ChgNull(TempDs.Tables(0).Rows(i - 1)("FCustName"))
                If DS Is Nothing = False Then
                    For j = k To DS.Rows.Count - 1
                        If TempDs.Tables(0).Rows(i - 1)("FinterID") = DS.Rows(j)("FinterID") Then
                            C1FlexGrid1.Rows(i)("FSel") = True
                            C1FlexGrid1.Rows(i)("FKJAmount") = DS.Rows(j)("FKJAmount")
                            If TempDs.Tables(0).Rows(i - 1)("Ftrantype") = 20110413 Then
                                KJAmount = KJAmount + DS.Rows(j)("FKJAmount")
                            Else
                                KJAmount = KJAmount - DS.Rows(j)("FKJAmount")
                            End If
                            k = j
                            Exit For
                        End If
                    Next
                End If
            Next
            Me.C1FlexGrid2.Cols.Count = Me.C1FlexGrid1.Cols.Count
            For t As Integer = 0 To C1FlexGrid1.Cols.Count - 1
                C1FlexGrid2.Cols(t).Visible = C1FlexGrid1.Cols(t).Visible
                C1FlexGrid2.Cols(t).Width = C1FlexGrid1.Cols(t).Width
            Next
            C1FlexGrid2.Rows(0)(C1FlexGrid1.Cols("FKJAmount").Index) = KJAmount
            C1FlexGrid2.Rows(0)(C1FlexGrid1.Cols("FSYKJAmount").Index) = Amount
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ButOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButOK.Click

        Try
            '判断是否规范,保存数据返回DS
            If Check() = True Then
                ReturnBack = True
                TotleKJAmount = PublicSharedFunctions.ChgNullToDouble(C1FlexGrid2.Rows(0)(C1FlexGrid1.Cols("FKJAmount").Index))
                DS = TempDT
                Me.Close()
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ButSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButSearch.Click
        Dim strSql As String
        Dim TempDs As DataSet
        Dim GetDataBluse As New BLuser
        Dim j, k As Integer
        Dim rg As CellRange
        Dim Amount, KJAmount As Double
        Try

            If IsCust = False Then
                Me.Label1.Text = "供应商"
                Me.FCustID.DataField = 8
                Trantype = 20110422
                strSql = "select v1.FinterID,v1.Ftrantype,v1.FbillNo,v1.FHtno, t2.FName  FCustName,t1.Fname FtrantypeName,v1.FAmount-isnull(u1.FKJAmount,0) FSYKJAmount "
                strSql = strSql & " from t_ZZ_Repay v1 left join (select sum(FKJAmount) FKJAmount,FinterID from t_ZZ_RepayEntry "
                strSql = strSql & " where FinterID_next<>" & InterID & " or FTrantype_next not in (20110422,20110413) group by FInterID) u1 on v1.FInterID=u1.FinterID"
                strSql = strSql & " left join T_SGL_BILLTABLE t1 on t1.Fid=v1.FTrantype left join t_item t2 on t2.FitemID=v1.FCustID and t2.FitemID>0 "
                strSql = strSql & " where v1.Ftrantype in (20110422,20110413)  and FCheckerID>0 and v1.FStatus<3  and  t2.Fname='" & Me.FCustID.Text & "' order by v1.FinterID"
            Else
                Me.Label1.Text = "客户"
                Me.FCustID.DataField = 1
                strSql = "select v1.FinterID,v1.Ftrantype,v1.FbillNo,v1.FHtno,t2.FName FCustName,t1.Fname FtrantypeName,v1.FAmount-isnull(u1.FKJAmount,0) FSYKJAmount "
                strSql = strSql & " from t_ZZ_Repay v1 left join (select sum(FKJAmount) FKJAmount,FinterID from t_ZZ_RepayEntry "
                strSql = strSql & " where FinterID_next<>" & InterID & " or FTrantype_next<>" & Trantype & " group by FInterID) u1 on v1.FInterID=u1.FinterID"
                strSql = strSql & " left join T_SGL_BILLTABLE t1 on t1.Fid=v1.FTrantype left join t_item t2 on t2.FitemID=v1.FCustID and t2.FItemClassID=1 and t2.FitemID>0 "
                strSql = strSql & " where v1.Ftrantype<>20110422  and FCheckerID>0 and v1.FStatus<3  and  t2.Fname='" & Me.FCustID.Text & "' order by v1.FinterID"
            End If
            CustName = Me.FCustID.Text
            TempDs = GetDataBluse.GetDataset(strSql, Me.CYSysInfo.ConnStrValue)
            C1FlexGrid1.Rows.Count = 1
            C1FlexGrid1.Rows.Count = TempDs.Tables(0).Rows.Count + 1
            For i As Integer = 1 To TempDs.Tables(0).Rows.Count
                Me.C1FlexGrid1.Rows(i)("FinterID") = TempDs.Tables(0).Rows(i - 1)("FinterID")
                Me.C1FlexGrid1.Rows(i)("Ftrantype") = TempDs.Tables(0).Rows(i - 1)("Ftrantype")
                If TempDs.Tables(0).Rows(i - 1)("Ftrantype") = 20110413 Then
                    For t As Integer = 1 To C1FlexGrid1.Cols.Count - 1
                        rg = C1FlexGrid1.GetCellRange(i, t)
                        rg.StyleNew.BackColor = Color.FromArgb(255, 255, 220)
                    Next
                    Amount = Amount + TempDs.Tables(0).Rows(i - 1)("FSYKJAmount")
                Else
                    Amount = Amount - TempDs.Tables(0).Rows(i - 1)("FSYKJAmount")
                End If

                Me.C1FlexGrid1.Rows(i)("FtrantypeName") = TempDs.Tables(0).Rows(i - 1)("FtrantypeName")
                Me.C1FlexGrid1.Rows(i)("FSYKJAmount") = TempDs.Tables(0).Rows(i - 1)("FSYKJAmount")
                Me.C1FlexGrid1.Rows(i)("FbillNo") = TempDs.Tables(0).Rows(i - 1)("FbillNo")
                Me.C1FlexGrid1.Rows(i)("FHtno") = TempDs.Tables(0).Rows(i - 1)("FHtno")
                Me.C1FlexGrid1.Rows(i)("FCustName") = PublicSharedFunctions.ChgNull(TempDs.Tables(0).Rows(i - 1)("FCustName"))
                If DS Is Nothing = False Then

                    For j = k To DS.Rows.Count - 1
                        If TempDs.Tables(0).Rows(i - 1)("FinterID") = DS.Rows(j)("FinterID") Then
                            C1FlexGrid1.Rows(i)("FSel") = True
                            C1FlexGrid1.Rows(i)("FKJAmount") = DS.Rows(j)("FKJAmount")
                            If TempDs.Tables(0).Rows(i - 1)("Ftrantype") = 20110413 Then
                                KJAmount = KJAmount + DS.Rows(j)("FKJAmount")
                            Else
                                KJAmount = KJAmount - DS.Rows(j)("FKJAmount")
                            End If
                            k = j
                            Exit For
                        End If
                    Next
                End If
            Next
            C1FlexGrid2.Rows(0)(C1FlexGrid1.Cols("FKJAmount").Index) = KJAmount
            C1FlexGrid2.Rows(0)(C1FlexGrid1.Cols("FSYKJAmount").Index) = Amount
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ButChanle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButChanle.Click

        Try
            ReturnBack = False
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub C1FlexGrid1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGrid1.AfterEdit
        Dim j As Integer
        Dim KJAmount As Double = 0
        Try
            For j = 1 To C1FlexGrid1.Rows.Count - 1
                If C1FlexGrid1.Rows(j)("FTrantype") = 20110413 Then
                    KJAmount = KJAmount + C1FlexGrid1.Rows(j)("FKJAmount")
                Else
                    KJAmount = KJAmount - C1FlexGrid1.Rows(j)("FKJAmount")
                End If
            Next
            C1FlexGrid2.Rows(0)(C1FlexGrid1.Cols("FKJAmount").Index) = KJAmount
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FCustID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FCustID.KeyDown
        Dim dstable As DataTable
        Try
            If e.KeyCode = 118 Then
                Me.Cursor = Cursors.WaitCursor

                dstable = Loaditamdate(FCustID.DataField)

                If dstable Is Nothing = False Then
                    Me.FCustID.Text = dstable.Rows(0)("Fname")

                End If

            End If
            Me.Cursor = Cursors.Default
            If e.KeyCode = 13 Then
                System.Windows.Forms.SendKeys.Send("{Tab}")
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class