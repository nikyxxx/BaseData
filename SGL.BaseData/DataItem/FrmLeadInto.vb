Imports PublicSharedResource
Imports SGL.BLL
Public Class FrmLeadInto
    Inherits frmBase
    Private GetData As BLuser
    Private strExcel As String = "从EXCEL导入"
    Private m_dsAccount As DataSet
    Private NowAccountID As Integer
    ''' <summary>
    '''绑定科目来源的方式
    ''' </summary>
    ''' <remarks></remarks>
    Private Function BindType() As Boolean
        Dim strSql As String
        Dim tempDs As New DataSet
        Try

            GetData = New BLuser
            strSql = "select 0 Ftype ,'" & strExcel & "' FTypeName union select Ftype ,FTypeName from t_accountType_back "
            tempDs = GetData.GetDataset(strSql, Me.CYSysInfo.ConnStrValue)
            For i As Integer = 0 To tempDs.Tables(0).Rows.Count - 1
                FTypeName.Items.Add(tempDs.Tables(0).Rows(i)("FTypeName"))
            Next
            If tempDs.Tables(0).Rows.Count > 1 Then
                'FTypeName.Text = FTypeName.Items.Item(1)
                FTypeName.SelectedIndex = 1
            ElseIf tempDs.Tables(0).Rows.Count = 1 Then
                FTypeName.SelectedIndex = 0
            End If
            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
    Private Sub LoadTreeView()
        Dim MainNode As TreeNode

        Try
            Me.TreeView1.Nodes.Clear()

            If m_dsAccount.Tables.Count > 0 Then
                If m_dsAccount.Tables(0).Rows.Count > 0 Then
                    For Each dr As DataRow In m_dsAccount.Tables(0).Select("Flevel = 1", "FNumber")
                        MainNode = New TreeNode
                        MainNode.Text = dr("Fnumber") & "  " & dr("FName")
                        MainNode.Name = dr("Fgroup")
                        MainNode.Tag = dr("Flevel").ToString() & "" & dr("FIsCash") & "" & dr("FIsBank") & "" & dr("FDc")

                        Me.TreeView1.Nodes.Add(MainNode)
                        LoadTreeViewLevel(MainNode, dr("Fnumber").ToString, 1)
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LoadTreeViewLevel(ByVal NodeClassType As TreeNode, ByVal ParenTNumber As String, ByVal Flevel As Int16)
        Dim MainNode As TreeNode

        Try

            If m_dsAccount.Tables(0).Rows.Count > 0 Then
                For Each dr As DataRow In m_dsAccount.Tables(0).Select("Fnumber like '" & ParenTNumber & ".%' and FLevel=" & Flevel + 1, "FNumber")
                    MainNode = New TreeNode
                    MainNode.Text = dr("Fnumber") & "  " & dr("FName")
                    MainNode.Name = dr("Fgroup")
                    MainNode.Tag = dr("Flevel").ToString() & "" & dr("FIsCash") & "" & dr("FIsBank") & "" & dr("FDc")

                    NodeClassType.Nodes.Add(MainNode)
                    LoadTreeViewLevel(MainNode, dr("Fnumber").ToString, dr("Flevel"))
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function InsertBillData() As Boolean
        Dim TempSql, TempSql1 As String
        Dim RootID As Integer = 0
        Dim ParentID As Integer = 0

        Dim TempGetdata As New BLuser
        Dim tempDs As DataSet
        Dim MainNode As TreeNode
        Dim BackLevel As Integer = 1
        Dim Detail As Integer = 1
        Try
            TempSql1 = "select FNext from  t_Identity WHERE FName = 't_account'"
            tempDs = TempGetdata.GetDataset(TempSql1, Me.CYSysInfo.ConnStrValue)
            If tempDs.Tables(0).Rows.Count > 0 Then
                NowAccountID = tempDs.Tables(0).Rows(0)(0) - 1
            Else
                NowAccountID = 999
            End If
            TempSql = ""
            For i As Integer = 0 To TreeView1.Nodes.Count - 1
                NowAccountID += 1
                MainNode = TreeView1.Nodes(i)
                If MainNode.Nodes.Count > 0 Then
                    Detail = 0
                Else
                    Detail = 1
                End If
                ParentID = 0
                RootID = NowAccountID

                TempSql = TempSql & " insert into t_account (FAccountID,FNumber,FName,FLevel,FDetail,FParentID,FRootID,FGroupID,FDC,FCurrencyID,FIsCash,FIsBank,FSystemtype)"
                TempSql = TempSql & " values( " & NowAccountID & ",'" & MainNode.Text.Substring(0, MainNode.Text.IndexOf("  ")) & "','" & MainNode.Text.Substring(MainNode.Text.IndexOf("  "), Len(MainNode.Text) - MainNode.Text.IndexOf("  ")).Trim & "'," & MainNode.Tag.ToString.Substring(0, 1) & "," & Detail & "," & ParentID & "," & RootID & "," & MainNode.Name & "," & MainNode.Tag.ToString.Substring(3, Len(MainNode.Tag) - 3) & ",1," & MainNode.Tag.ToString.Substring(1, 1) & "," & MainNode.Tag.ToString.Substring(2, 1) & ",1)"
                If MainNode.Nodes.Count > 0 Then
                    TempSql = TempSql & GetNotsData(MainNode, RootID, NowAccountID)
                End If
            Next
            If TempSql <> "" Then
                TempGetdata.sqlexecnon(TempSql, Me.CYSysInfo.ConnStrValue)
                MsgBox("科目导入成功", MsgBoxStyle.OkOnly, "创源提示")
                Return True
            Else
                MsgBox("没有科目，导入不成功", MsgBoxStyle.OkOnly, "创源提示")
                Return False
            End If

        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
    Private Function GetNotsData(ByVal NodeClassType As TreeNode, ByVal RootID As Integer, ByVal ParentID As Integer) As String

        Dim MainNode As TreeNode
        Dim TempSql As String
        Dim TempGetdata As New BLuser
        Dim tempDs As DataSet
        Dim Detail As Integer = 1
        Dim BackLevel As Integer = 1
        Try

            TempSql = ""
            For i As Integer = 0 To NodeClassType.Nodes.Count - 1
                MainNode = NodeClassType.Nodes(i)
                If MainNode.Nodes.Count > 0 Then
                    Detail = 0
                Else
                    Detail = 1
                End If
                NowAccountID += 1

                TempSql = TempSql & " insert into t_account (FAccountID,FNumber,FName,FLevel,FDetail,FParentID,FRootID,FGroupID,FDC,FCurrencyID,FIsCash,FIsBank,FSystemtype)"
                TempSql = TempSql & " values( " & NowAccountID & ",'" & MainNode.Text.Substring(0, MainNode.Text.IndexOf("  ")) & "','" & MainNode.Text.Substring(MainNode.Text.IndexOf("  "), Len(MainNode.Text) - MainNode.Text.IndexOf("  ")).Trim & "'," & MainNode.Tag.ToString.Substring(0, 1) & "," & Detail & "," & ParentID & "," & RootID & "," & MainNode.Name & "," & MainNode.Tag.ToString.Substring(3, Len(MainNode.Tag) - 3) & ",1," & MainNode.Tag.ToString.Substring(1, 1) & "," & MainNode.Tag.ToString.Substring(2, 1) & ",1)"
                If MainNode.Nodes.Count > 0 Then
                    TempSql = TempSql & GetNotsData(MainNode, RootID, NowAccountID)
                End If
            Next
            Return TempSql
        Catch ex As Exception
            Throw ex
            Return ""
        End Try
    End Function

    Private Sub FrmLeadInto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            If BindType() = False Then
                Me.Dispose()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FTypeName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FTypeName.TextChanged
        Dim TempSql As String
        Dim GetData As New BLuser

        Try


            If FTypeName.Text = strExcel Then
                Me.ButFile.Enabled = True
                Me.TextFile.Enabled = True
            Else
                Me.ButFile.Enabled = False
                Me.TextFile.Enabled = False
            End If
            TempSql = "declare @typeID int declare @Len1 int declare @Len2 int declare @Len3 int declare @Len4 int set @typeID=" & Me.FTypeName.SelectedIndex
            TempSql = TempSql + " select @Len1=Facctlen1,@Len2=Facctlen2,@Len3=Facctlen3,@Len4=Facctlen4 from t_accountType_back where Ftype=@typeID"
            TempSql = TempSql + " select case len(FacctID) when @Len1 then FacctID  when  @Len1+@Len2 then substring(FacctID,1,@Len1)+'.'+substring(FacctID,@Len1+1,@Len2)"
            TempSql = TempSql + " when  @Len1+@Len2+@Len3 then substring(FacctID,1,@Len1)+'.'+substring(FacctID,@Len1+1 ,@Len2)+'.'+substring(FacctID,@Len1+@Len2+1 ,@Len3)"
            TempSql = TempSql + " when  @Len1+@Len2+@Len3+@Len4 then substring(FacctID,1,@Len1)+'.'+substring(FacctID,@Len1+1 ,@Len2)+'.'+substring(FacctID,@Len1+@Len2+1 ,@Len3)+'.'+substring(FacctID,@Len1+@Len2+@Len3+1 ,@Len4)"
            TempSql = TempSql + " end FNumber,case len(FacctID) when @Len1 then 1  when  @Len1+@Len2 then 2 when  @Len1+@Len2+@Len3 then 3 when  @Len1+@Len2+@Len3+@Len4 then 4"
            TempSql = TempSql + " end Flevel,FacctName FName,Fgroup,convert(int,FisCash) FisCash,convert(int,FisBank) FisBank,FDC from t_account_back where  Ftype=@typeID order by FacctID"
            m_dsAccount = GetData.GetDataset(TempSql, Me.CYSysInfo.ConnStrValue)
            LoadTreeView()
        Catch ex As Exception
            Throw ex
            Me.Dispose()
        End Try
    End Sub

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Private Sub ButOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButOK.Click
        Try
            '得到数据
            If InsertBillData() = True Then
                Me.Close()
            End If
            '插入数据

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ButChane_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButChane.Click
        Me.Close()
    End Sub
End Class