Imports System
Imports PublicSharedResource
Imports SGL.BLL
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.Common
Public Class FrmMultiCheckList
    Inherits frmBase
    Private strSql As String
    Private BillType As Integer
    Private TypeName As String
    Private TypeTable As String
#Region "方法"
    Private Function DeleteMultiCheck(ByVal DBconnet As String, ByVal BillType As Integer) As Boolean
        Dim DBOpen As New BLuser
        Try
            strSql = " delete from t_ZZ_MultiCheckOption where FBillType=" & BillType
            strSql = strSql & " delete from t_ZZ_MultiLevelCheck where FBillType=" & BillType
            strSql = strSql & " delete from t_ZZ_MultiCheckMoney where FBillType=" & BillType
            strSql = strSql & " delete from t_ZZ_MultiCheckRelationTool where FBillType=" & BillType
            DBOpen.sqlexecnon(strSql, DBconnet)
            Me.C1FlexGrid1.Rows.Count = 1
            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try

    End Function
    Private Function CheckerDataBind(ByVal DBconnet As String, ByVal BillType As Integer) As Boolean
        Dim DBOpen As New BLuser
        Dim Datanew As DataSet
        Dim k, t As Integer
        Try
            strSql = "select t1.FCheckLevel,t2.Fname from t_ZZ_MultiLevelCheck t1 inner join t_user t2 "
            strSql = strSql & " on t1.FCheckerID=t2.FuserID where FBillType=" & BillType & " order By FCheckLevel"
            strSql = strSql & " select isnull(max(countN),0) countN from ( "
            strSql = strSql & " select count(*) countN,FCheckLevel  from t_ZZ_MultiLevelCheck where FBillType=" & BillType & " group By FCheckLevel) t "
            Datanew = DBOpen.GetDataset(strSql, DBconnet)
            If Datanew.Tables(1).Rows.Count > 0 Then
                If Datanew.Tables(1).Rows(0)(0) > 0 Then
                    Me.C1FlexGrid1.Rows.Count = Datanew.Tables(1).Rows(0)(0) + 1
                    k = 1
                    t = 1
                    For i As Integer = 0 To Datanew.Tables(0).Rows.Count - 1
                        If k = Datanew.Tables(0).Rows(i)("FCheckLevel") Then
                            C1FlexGrid1.Rows(t)("FChecker" & k) = Datanew.Tables(0).Rows(i)("Fname")
                            t = t + 1
                        Else
                            k = Datanew.Tables(0).Rows(i)("FCheckLevel")
                            C1FlexGrid1.Rows(1)("FChecker" & k) = Datanew.Tables(0).Rows(i)("Fname")
                            t = 2
                        End If
                    Next
                Else
                    Me.C1FlexGrid1.Rows.Count = 1
                    Return True
                End If
            Else
                Me.C1FlexGrid1.Rows.Count = 1
                Return True
            End If

        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
    Private Sub ItemsTreeBind(ByVal DBconnet As String, ByVal trvMainMenu As TreeView)
        Dim topNode As New TreeNode
        Dim drItem As DataRow
        Dim DBOpen As New BLuser
        Dim Datanew As DataSet
        Try
            '取得所有的核算项目信息
            trvMainMenu.Nodes.Clear()
            strSql = "select FID,FT1,FName from t_sgl_billtable where FID>0 and FID<100 order by Fid"
            Datanew = DBOpen.GetDataset(strSql, DBconnet)

            topNode.Text = "单据类型"
            topNode.Name = "-1000"
            topNode.Tag = ""
            topNode.ImageKey = "tree_folder_close.gif"
            topNode.SelectedImageKey = "tree_folder_open.gif"
            topNode.Expand()
            trvMainMenu.Nodes.Add(topNode)
            '添加科目第一层子接点
            If Datanew.Tables.Count > 0 Then
                For Each drItem In Datanew.Tables(0).Select("1 = 1")
                    Dim FirstLevelNode As New TreeNode
                    FirstLevelNode.Text = drItem("FName")
                    FirstLevelNode.Name = drItem("FID")
                    FirstLevelNode.Tag = drItem("FT1")
                    FirstLevelNode.ImageKey = "tree_folder_leaf.gif"
                    FirstLevelNode.SelectedImageKey = "tree_bigicon_end.gif"
                    FirstLevelNode.Expand()
                    topNode.Nodes.Add(FirstLevelNode)
                Next
            End If
            topNode.Expand()
            Datanew.Clear()

            For Each tn As TreeNode In trvMainMenu.Nodes(0).Nodes
                If tn.Name = 1 Then
                    trvMainMenu.SelectedNode = tn
                    Exit For
                End If
            Next

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub

    Public Function RightSeting(ByVal MD As String, ByVal UD As String) As Boolean
        Dim sqlstr As String
        Dim dblTemp As Double = 0
        Dim dblSum As Double = 0
        Dim DBOpen As New BLuser
        Dim RightDate As New DataSet
        DBOpen = New BLuser
        Try
            sqlstr = "exec P_SGL_Right  '" + MD + "', '" + UD + "'"
            RightDate = DBOpen.GetDataset(sqlstr, PublicSharedResource.PublicSharedFunctions.consglstr)
            If RightDate.Tables(1).Rows(0)(0) > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
            Return False
        End Try

    End Function '权限设置
    ''' <summary>
    ''' 窗体初始化
    ''' </summary>
    ''' <param name="DBconnet"></param>
    ''' <param name="trantype"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InitalFrm(ByVal DBconnet As String, ByVal trantype As String) As Boolean

        Try
            ItemsTreeBind(DBconnet, Me.TreeView1)

        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
#End Region

    Private Sub FrmMultiCheckList_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose(Disposing)
    End Sub
    Private Sub FrmMultiCheckList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub New()
        Dim DBconnet As String
        Dim trantype As String
        DBconnet = PublicSharedFunctions.consglstr
        trantype = PublicSharedFunctions.trantype
        If RightSeting(PublicSharedResource.PublicSharedFunctions.Crasoftid, PublicSharedResource.PublicSharedFunctions.useid) = False Then
            MsgBox("没有权限，请与管理员联系！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Me.Dispose()
            Exit Sub
        End If
        ' 此调用是设计器所必需的。
        InitializeComponent()
        InitalFrm(DBconnet, trantype)
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Me.Cursor = Cursors.WaitCursor
        Try
            If Me.TreeView1.SelectedNode.Name <> "" And Me.TreeView1.SelectedNode.Name <> "-1000" Then

                BillType = TreeView1.SelectedNode.Name

                TypeName = TreeView1.SelectedNode.Text
                TypeTable = TreeView1.SelectedNode.Tag

                CheckerDataBind(Me.CYSysInfo.ConnStrValue, BillType)

            End If
        Catch ex As Exception
            Throw ex
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolClose.Click

        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolDelete.Click
        Try
            If DeleteMultiCheck(Me.CYSysInfo.ConnStrValue, BillType) = True Then
                MsgBox("删除成功")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolUpdate.Click
        Dim newfrm As New FrmMultiCheckSet With {.CYSysInfo = Me.CYSysInfo, .CYUserInfo = Me.CYUserInfo, .BillType = Me.BillType}
        Try
            If BillType <> 0 And BillType <> -10000 Then
                newfrm.BillType = Me.BillType
                newfrm.CYSysInfo = Me.CYSysInfo
                newfrm.CYUserInfo = Me.CYUserInfo
                newfrm.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class