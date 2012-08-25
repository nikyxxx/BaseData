Imports SGL.BLL

Public Class FrmItems
#Region "成员变量声明"

    Private m_dsItemsInfo As New DataSet
    Private m_dsItemsInfo2 As New DataSet
    Private m_strItemClassName As String
    Public S_Classid As Integer = 0
    Public constr As String
    Private DBOpen As SGL.BLL.BLuser
    Public RtnDataTable As New DataSet
    Private Sglstr As String
    Public ZzjGetStr As String    '取数过滤条件
    Public Pnumber As String
    Public Pzt As String
#End Region
    Private Sub InitPage()
        Try
            Me.cobSearchType.Items.Add("核算项目代码")
            Me.cobSearchType.Items.Add("核算项目名称")
            If S_Classid = "4" Or S_Classid = "-4" Then
                Me.cobSearchType.Items.Add("规格")
                TP.Visible = True
            Else
                TP.Visible = False
            End If

            Me.txtTypeName.Text = Me.m_strItemClassName
            Me.cobMatchingType.SelectedIndex = 0
            If S_Classid = "4" Or S_Classid = "-4" Then
                Me.cobSearchType.SelectedIndex = 2
            Else
                Me.cobSearchType.SelectedIndex = 1
            End If


            grdItemsBind("")
            Me.C1FlexGrid1.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FrmItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If S_Classid <> 0 Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            InitPage()
            ItemsTreeBind()
            'C1FlexGrid1.Focus()
            txtSearchText.Focus()
        Else
            Me.Close()
        End If
    End Sub
    Private Sub ItemsTreeBind()
        Dim topNode As New TreeNode
        Dim drItem As DataRow
        Try
            '取得所有的核算项目信息

            Me.trvItems.Nodes.Clear()
            If S_Classid = 5 Then
                Sglstr = "select * from T_item where  FDetail=0  AND FDeleteD=0  and fitemclassid =5 and fitemid not in (select fitemid from T_stock where ftypeid in(501,502,503)) and fitemid not in (select fparentid from T_stock where ftypeid=503 and fparentid>0)    order by fnumber "
            ElseIf S_Classid = 9000 Then '代管仓
                Sglstr = "select * from T_item where  FDetail=0  AND FDeleteD=0  and fitemclassid =5 and fitemid in (select fitemid from T_stock where ftypeid=503) and fitemid not in (select fparentid from T_stock where ftypeid=500 and fparentid>0) order by fnumber "
            ElseIf S_Classid = 9001 Then '赠品仓
                Sglstr = "select * from T_item where  FDetail=0  AND FDeleteD=0  and fitemclassid =5 and fitemid in (select fitemid from T_stock where ftypeid=502) and fitemid not in (select fparentid from T_stock where ftypeid=500 and fparentid>0) order by fnumber "
            ElseIf S_Classid = 9002 Then '虚仓
                Sglstr = "select * from T_item where  FDetail=0  AND FDeleteD=0  and fitemclassid =5 and fitemid in (select fitemid from T_stock where ftypeid in (502,503)) and fitemid not in (select fparentid from T_stock where ftypeid=500 and fparentid>0) order by fnumber "
            ElseIf S_Classid < 0 Then
                Sglstr = "select * from " + Pzt + ".dbo.T_item where  FDetail=0  AND FDeleteD=0  and fitemclassid =" + (0 - S_Classid).ToString + " order by fnumber "
            Else
                Sglstr = "select * from T_item where  FDetail=0  AND FDeleteD=0  and fitemclassid =" + S_Classid.ToString + "  order by fnumber "
            End If


            DBOpen = New BLuser
            m_dsItemsInfo2 = DBOpen.GetDataset(Sglstr, constr)
            '添加根节点
            topNode.Text = "核算项目－" & txtTypeName.Text
            topNode.Name = "-1000"
            topNode.Tag = "-1000"
            topNode.ImageKey = "tree_folder_close.gif"
            topNode.SelectedImageKey = "tree_folder_open.gif"
            topNode.Expand()
            Me.trvItems.Nodes.Add(topNode)
            '添加科目第一层子接点
            If m_dsItemsInfo2.Tables.Count > 0 Then
                For Each drItem In m_dsItemsInfo2.Tables(0).Select("FLevel = 1")
                    Dim FirstLevelNode As New TreeNode

                    FirstLevelNode.Text = drItem("FNumber").ToString & "-" & drItem("FName")
                    FirstLevelNode.Name = drItem("FNumber")
                    FirstLevelNode.Tag = drItem("FItemID").ToString() & "%" & drItem("FLevel").ToString() & "%" & drItem("FDetail").ToString() & "%" & drItem("FParentID").ToString() & "%" & drItem("FItemClassID").ToString()
                    If drItem("FDetail") = 0 Then
                        FirstLevelNode.ImageKey = "tree_folder_close.gif"
                        FirstLevelNode.SelectedImageKey = "tree_folder_open.gif"
                    Else
                        FirstLevelNode.ImageKey = "tree_folder_leaf.gif"
                        FirstLevelNode.SelectedImageKey = "tree_bigicon_end.gif"
                    End If
                    FirstLevelNode.Expand()
                    topNode.Nodes.Add(FirstLevelNode)
                    TreeSonNodeBind(FirstLevelNode, m_dsItemsInfo2, drItem("FItemID").ToString)
                Next
            End If
            topNode.Expand()
        Catch ex As Exception
            Throw ex
        Finally
            m_dsItemsInfo2.Dispose()
        End Try
    End Sub

    Private Sub TreeSonNodeBind(ByVal tNode As TreeNode, ByVal dsItemsInfo2 As DataSet, ByVal strItemID As String)
        Dim ChildNode As TreeNode

        Try
            'strItemID = PublicSharedResource.PublicSharedFunctions.GetSubString(tNode.Tag.ToString(), 1)
            For Each drItem As DataRow In m_dsItemsInfo2.Tables(0).Select(" FParentID = " & strItemID)
                ChildNode = New TreeNode
                ChildNode.Text = drItem("FNumber").ToString & "-" & drItem("FName")
                ChildNode.Name = drItem("FNumber")
                ChildNode.Tag = drItem("FItemID").ToString() & "%" & drItem("FLevel").ToString() & "%" & drItem("FDetail").ToString() & "%" & drItem("FParentID").ToString() & "%" & drItem("FItemClassID").ToString()
                If drItem("FDetail") = 0 Then
                    ChildNode.ImageKey = "tree_folder_close.gif"
                    ChildNode.SelectedImageKey = "tree_folder_open.gif"
                Else
                    ChildNode.ImageKey = "tree_folder_leaf.gif"
                    ChildNode.SelectedImageKey = "tree_bigicon_end.gif"
                End If
                tNode.Nodes.Add(ChildNode)
                TreeSonNodeBind(ChildNode, dsItemsInfo2, drItem("FItemID").ToString)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

   

    Private Sub grdItemsBind(ByVal SelNode As String)
        Try
            If m_dsItemsInfo.Tables.Count > 0 Then
                m_dsItemsInfo.Tables(0).Clear()
            End If
            If SelNode = "" Then
                If S_Classid < 0 Then
                    If Pnumber <> "" Then
                        Sglstr = "exec P_SGL_Icitemsglnew2012  " + S_Classid.ToString + ",'" + Pnumber + "','" + Pzt + "'"
                    Else
                        Sglstr = "exec P_SGL_Icitem2012  " + S_Classid.ToString + ",'" + Pzt + "'"
                    End If
                    If ZzjGetStr <> "" Then
                        Sglstr = "exec P_SGL_Icitem2012  " + S_Classid.ToString + ",'" + Pzt + "'" + ",'" + ZzjGetStr + "'"
                    End If
                Else
                    If Pnumber <> "" Then
                        Sglstr = "exec P_SGL_Icitemsglnew  " + S_Classid.ToString + ",'" + Pnumber + "'"
                    Else
                        Sglstr = "exec P_SGL_Icitem  " + S_Classid.ToString
                    End If
                    If ZzjGetStr <> "" Then
                        Sglstr = "exec P_SGL_Icitem  " + S_Classid.ToString + ",'" + ZzjGetStr + "'"
                    End If
                End If
            ElseIf SelNode = "-1000" Then
                Sglstr = "exec P_SGL_Icitem  " + S_Classid.ToString
                'ElseIf ZzjGetStr <> "" Then
                '    Sglstr = "exec P_SGL_IcitemmxNew  " + S_Classid.ToString + ",'" + SelNode + "','" + ZzjGetStr + "'"
            Else
                If S_Classid < 0 Then
                    Sglstr = "exec P_SGL_Icitemmx2012  " + S_Classid.ToString + ",'" + SelNode + "'" + ",'" + Pzt + "'"
                Else
                    Sglstr = "exec P_SGL_Icitemmx  " + S_Classid.ToString + ",'" + SelNode + "'"
                End If

            End If
            DBOpen = New BLuser
            m_dsItemsInfo = DBOpen.GetDataset(Sglstr, constr)

            If m_dsItemsInfo.Tables.Count > 0 Then
                Me.C1FlexGrid1.DataSource = m_dsItemsInfo.Tables(0)
                Me.C1FlexGrid1.Cols("fitemid").Width = -1
                Me.C1FlexGrid1.Cols(1).Width = 30
                If S_Classid <> 4 Then
                    Me.C1FlexGrid1.Cols("规格").Width = -1
                    Me.C1FlexGrid1.Cols(3).Width = 150
                    Me.C1FlexGrid1.Cols(4).Width = 210
                Else
                    Me.C1FlexGrid1.Cols(3).Width = 100
                    'Me.C1FlexGrid1.Cols(4).Width = 120
                    Me.C1FlexGrid1.Cols(4).Width = 200
                    Me.C1FlexGrid1.Cols(5).Width = 200
                End If

                If SelNode = "" Then
                    txtTypeName.Text = m_dsItemsInfo.Tables(1).Rows(0)(0)
                End If
                txtTypeName.Enabled = False
                Me.C1FlexGrid1.Cols(1).Style.BackColor = Color.FromArgb(108, 155, 200)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub trvItems_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvItems.AfterSelect
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not (Me.trvItems.SelectedNode Is Nothing) Then
                If Me.trvItems.SelectedNode.Tag.ToString() <> "" And Me.trvItems.SelectedNode.Name <> "" Then
                    'grdItemsBind(Me.trvItems.SelectedNode.Name)
                    'grdItemsBindNew(Me.trvItems.SelectedNode)
                    grdItemsBind(Me.trvItems.SelectedNode.Name)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Me.Cursor = Cursors.Default
    End Sub
   

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Me.Cursor = Cursors.WaitCursor
        Dim sglmyh As String
        Try
            If m_dsItemsInfo.Tables.Count > 0 Then
                m_dsItemsInfo.Tables(0).Clear()
            End If
            If txtSearchText.Text <> "" Then
                Select Case cobSearchType.SelectedIndex
                    Case 0
                        sglmyh = "fnumber "
                    Case 1
                        sglmyh = "fname "
                    Case 2
                        sglmyh = "fmodel "
                End Select
                Select Case cobMatchingType.SelectedIndex
                    Case 0

                        sglmyh = sglmyh + " like ~%" + txtSearchText.Text + "%~"
                    Case 1
                        sglmyh = sglmyh + " =~" + txtSearchText.Text + "~"
                End Select


                If S_Classid < 0 Then
                    Sglstr = "exec P_SGL_Icitemsel2012  " + S_Classid.ToString + ",'" + sglmyh + "'" + "," + Pzt
                Else
                    Sglstr = "exec P_SGL_Icitemsel  " + S_Classid.ToString + ",'" + sglmyh + "'"
                End If
                DBOpen = New BLuser
                m_dsItemsInfo = DBOpen.GetDataset(Sglstr, constr)

                If m_dsItemsInfo.Tables.Count > 0 Then
                    Me.C1FlexGrid1.DataSource = m_dsItemsInfo.Tables(0)
                    Me.C1FlexGrid1.Cols("fitemid").Width = -1
                    Me.C1FlexGrid1.Cols(1).Width = 30
                    If S_Classid <> 4 Then
                        Me.C1FlexGrid1.Cols("规格").Width = -1
                        Me.C1FlexGrid1.Cols(3).Width = 150
                        Me.C1FlexGrid1.Cols(4).Width = 210
                    Else
                        Me.C1FlexGrid1.Cols(3).Width = 100
                        Me.C1FlexGrid1.Cols(4).Width = 200
                        'Me.C1FlexGrid1.Cols(4).Width = 120
                        Me.C1FlexGrid1.Cols(5).Width = 200
                    End If


                    txtTypeName.Enabled = False
                    Me.C1FlexGrid1.Cols(1).Style.BackColor = Color.FromArgb(108, 155, 200)
                End If
            Else
                grdItemsBind("")

            End If
        Catch ex As Exception
            Throw ex
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub C1FlexGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1FlexGrid1.DoubleClick

        Me.Cursor = Cursors.WaitCursor
        Dim intRow As Integer
        Dim dt As New DataTable
        Dim item As Integer
        Try
            intRow = Me.C1FlexGrid1.Row
            If intRow > 0 Then
                item = C1FlexGrid1.Item(intRow, "fitemid")
                If S_Classid < 0 Then
                    Sglstr = "exec P_SGL_Icitemresel2012  " + S_Classid.ToString + "," + item.ToString + "," + Pzt
                Else
                    Sglstr = "exec P_SGL_Icitemresel  " + S_Classid.ToString + "," + item.ToString
                End If

                DBOpen = New BLuser
                RtnDataTable = DBOpen.GetDataset(Sglstr, constr)
                If Me.RtnDataTable.Tables(0).Rows.Count > 0 Then
                    m_dsItemsInfo.Tables(0).Clear()
                    m_dsItemsInfo2.Tables(0).Clear()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Cursor = Cursors.Default
                    Me.Close()
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Me.Cursor = Cursors.Default
    End Sub
   
    Private Sub C1FlexGrid1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles C1FlexGrid1.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Dim intRow As Integer
        Dim dt As New DataTable
        Dim item As Integer
        Try
            If e.KeyCode = Keys.Enter Then
                intRow = Me.C1FlexGrid1.Row
                If intRow > 0 Then
                    item = C1FlexGrid1.Item(intRow, "fitemid")
                    Sglstr = "exec P_SGL_Icitemresel  " + S_Classid.ToString + "," + item.ToString
                    DBOpen = New BLuser
                    RtnDataTable = DBOpen.GetDataset(Sglstr, constr)
                    If Me.RtnDataTable.Tables(0).Rows.Count > 0 Then
                        m_dsItemsInfo.Tables(0).Clear()
                        m_dsItemsInfo2.Tables(0).Clear()
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Cursor = Cursors.Default
                        Me.Close()
                    End If
                End If
            End If
            

        Catch ex As Exception
            Throw ex
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TP.Click
        'Me.Cursor = Cursors.WaitCursor

        'Try

        '    Dim FrmnewTP As New FrmTpShow
        '    FrmnewTP.CYSysInfo = Me.CYSysInfo
        '    FrmnewTP.CYUserInfo = Me.CYUserInfo
        '    FrmnewTP.ItemSgl = C1FlexGrid1.Rows(Me.C1FlexGrid1.Row)("fitemid")
        '    FrmnewTP.ShowDialog()


        'Catch ex As Exception
        '    Throw ex
        'End Try

        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        'Dim frm As New FrmItemDaseList
        'frm.classitemid = S_Classid
        'frm.Show()

    End Sub

    ''' <summary>
    ''' 查询框按回车查询
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtSearchText_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchText.KeyDown
        If e.KeyCode = 13 Then
            btnSearch_Click(sender, e)
            C1FlexGrid1.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            C1FlexGrid1.Focus()
            If C1FlexGrid1.Rows.Count - 1 > C1FlexGrid1.Row Then
                C1FlexGrid1.Row += 1
            End If
        End If
    End Sub

End Class