Imports PublicSharedResource
Imports SGL.BLL
Public Class fbasetemp

    Public frmact As New FrmAccT
    Public frmactlist As New Faccountlist
    Public dsd As New System.Data.DataSet
    Public sql, tablename, rtname, finterid As String
    Public i As Integer
    Private DBOpen As SGL.BLL.BLuser
    Public constr As String
    Private Sub fbasetemp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If tablename = "计量单位组" Then
            sql = " select FUnitGroupID as '序号',FName as 名称 from t_UnitGroup  where FUnitGroupID>0"
            Me.Text = "计量单位组"

        ElseIf tablename = "计量单位" Then
            sql = "select FmeasureunitID as '序号',Fname as '名称' from t_MeasureUnit where fUnitGroupID=" & rtname & " and FmeasureunitID>0"
            Me.Text = "计量单位"

        ElseIf tablename = "核算项目" Then
            sql = "select FItemClassID as '内码',FNumber  as '核算类别代码',FName  as '名称 'from t_itemclass where FItemClassID <> 0  AND FType=1 "
            Me.Text = "核算项目"

        ElseIf tablename = "科目类别" Then
            sql = "select FGroupid as '科目类别码', FName as '科目类别名称' from t_acctgroup where fgroupid <>0  order by fgroupid"
            Me.Text = "科目类别"

        ElseIf tablename = "现金流量项目-主表项目" Then
            sql = "select FItemID as '内码' , FFullNumber as '编码', FName as '名称'  from t_item where fitemclassid=9 and FItemID>0"
            Me.Text = "现金流量项目-主表项目"

        ElseIf tablename = "现金流量项目-附表项目" Then
            sql = "select FItemID as '内码' , FFullNumber as '编码', FName as '名称'  from t_item where fitemclassid=9 and and FItemID>0 "
            Me.Text = "现金流量项目-附表项目"

        ElseIf tablename = "管理科目禁用" Then
            sql = "Select  105 FTypeID,FAccountID as '内码' ,FNumber as '代码',FName as '名称' FROM t_Account Where  FDelete=1 and FAccountID>0"
            dsd.Clear()
            DBOpen = New BLuser
            dsd = DBOpen.GetDataset(sql, frmactlist.CYSysInfo.ConnStrValue)
            C1FlexGrid.DataSource = dsd.Tables(0)
            C1FlexGrid.Cols("Ftypeid").Width = -1
            C1FlexGrid.Cols("内码").Width = -1

            Me.Button1.Text = "取消禁用"
            Me.Text = "管理科目禁用"
            Exit Sub
        End If


        dsd.Clear()
        DBOpen = New BLuser
        dsd = DBOpen.GetDataset(sql, frmact.CYSysInfo.ConnStrValue)
        C1FlexGrid.DataSource = dsd.Tables(0)
        If tablename = "核算项目" Or tablename = "现金流量项目-主表项目" Or tablename = "现金流量项目-附表项目" Then
            C1FlexGrid.Cols("内码").Width = -1
        End If
       
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If tablename = "计量单位组" Then
            frmact.C1TextBox2.Text = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("名称").ToString
            frmact.C1TextBox2.Value = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("序号").ToString
            Me.Close()

        ElseIf tablename = "计量单位" Then
            frmact.fname.Text = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("名称").ToString
            frmact.fname.Value = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("序号").ToString
            Me.Close()

        ElseIf tablename = "核算项目" Then
            For i = 0 To 15
                If frmact.C1FlexGrid2.Item(i + 1, "FItemClassID") = Me.C1FlexGrid.Rows(Me.C1FlexGrid.Row)("内码") Then
                    Exit For
                Else
                    If frmact.C1FlexGrid2.Item(i + 1, "FItemClassNumber") Is Nothing Then
                        frmact.C1FlexGrid2.Item(i + 1, "FItemClassID") = Me.C1FlexGrid.Rows(Me.C1FlexGrid.Row)("内码")
                        frmact.C1FlexGrid2.Item(i + 1, "FItemClassNumber") = Me.C1FlexGrid.Rows(Me.C1FlexGrid.Row)("核算类别代码")
                        frmact.C1FlexGrid2.Item(i + 1, "FItemClassName") = Me.C1FlexGrid.Rows(Me.C1FlexGrid.Row)(2)
                        frmact.C1FlexGrid2.Item(i + 1, "序号") = (i + 1).ToString
                        Exit For
                    End If
                End If
            Next
            Me.Close()

        ElseIf tablename = "科目类别" Then
            frmact.C1TextBox7.Text = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("科目类别名称").ToString
            frmact.C1TextBox7.Value = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("科目类别码").ToString
            Me.Close()

        ElseIf tablename = "现金流量项目-主表项目" Then
            frmact.C1TextBox3.Text = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("名称").ToString
            frmact.C1TextBox3.Value = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("内码").ToString
            Me.Close()

        ElseIf tablename = "现金流量项目-附表项目" Then
            frmact.C1TextBox4.Text = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("名称").ToString
            frmact.C1TextBox4.Value = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("内码").ToString
            Me.Close()
        ElseIf tablename = "管理科目禁用" Then
            If dsd.Tables(0).Rows.Count = 0 Then
                MsgBox("已经没有可取消禁用的科目了", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Else
                sql = ""
                sql = "Update t_Account Set  FDelete=0 Where FAccountID=" & Me.C1FlexGrid.Rows(Me.C1FlexGrid.Row)("内码").ToString
                DBOpen = New BLuser
                DBOpen.sqlexecnon(sql, frmactlist.CYSysInfo.ConnStrValue)
                Me.C1FlexGrid.Rows.Remove(Me.C1FlexGrid.Row)
                Me.frmactlist.refesh()

                If Me.C1FlexGrid.Rows.Count = 1 Then
                    Me.Button1.Enabled = False
                End If

            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'frmact.C1TextBox2.Text = ""
        'frmact.C1FlexGrid2.Tag = ""
        Me.Close()

    End Sub

    Private Sub C1FlexGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1FlexGrid.Click     
    End Sub

    Private Sub C1FlexGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1FlexGrid.DoubleClick
        Call Button1_Click(sender, e)
    End Sub

    Private Sub C1FlexGrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles C1FlexGrid.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If tablename = "计量单位组" Then
                frmact.C1TextBox2.Text = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("名称").ToString
                frmact.C1TextBox2.Value = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("序号").ToString
                Me.Close()

            ElseIf tablename = "计量单位" Then
                frmact.fname.Text = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("名称").ToString
                frmact.fname.Value = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("序号").ToString
                Me.Close()

            ElseIf tablename = "核算项目" Then
                For i = 0 To 15
                    If frmact.C1FlexGrid2.Item(i + 1, "FItemClassID") = Me.C1FlexGrid.Rows(Me.C1FlexGrid.Row)("内码") Then
                        Exit For
                    Else
                        If frmact.C1FlexGrid2.Item(i + 1, "FItemClassNumber") Is Nothing Then
                            frmact.C1FlexGrid2.Item(i + 1, "FItemClassID") = Me.C1FlexGrid.Rows(Me.C1FlexGrid.Row)("内码")
                            frmact.C1FlexGrid2.Item(i + 1, "FItemClassNumber") = Me.C1FlexGrid.Rows(Me.C1FlexGrid.Row)("核算类别代码")
                            frmact.C1FlexGrid2.Item(i + 1, "FItemClassName") = Me.C1FlexGrid.Rows(Me.C1FlexGrid.Row)(2)
                            frmact.C1FlexGrid2.Item(i + 1, "序号") = (i + 1).ToString
                            Exit For
                        End If
                    End If
                Next
                Me.Close()

            ElseIf tablename = "科目类别" Then
                frmact.C1TextBox7.Text = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("科目类别名称").ToString
                frmact.C1TextBox7.Value = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("科目类别码").ToString
                Me.Close()

            ElseIf tablename = "现金流量项目-主表项目" Then
                frmact.C1TextBox3.Text = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("名称").ToString
                frmact.C1TextBox3.Value = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("内码").ToString
                Me.Close()

            ElseIf tablename = "现金流量项目-附表项目" Then
                frmact.C1TextBox4.Text = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("名称").ToString
                frmact.C1TextBox4.Value = C1FlexGrid.Rows(Me.C1FlexGrid.Row)("内码").ToString
                Me.Close()
            ElseIf tablename = "管理科目禁用" Then
                If dsd.Tables(0).Rows.Count = 0 Then
                    MsgBox("已经没有可取消禁用的科目了", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                Else
                    sql = ""
                    sql = "Update t_Account Set  FDelete=0 Where FAccountID=" & Me.C1FlexGrid.Rows(Me.C1FlexGrid.Row)("内码").ToString
                    DBOpen = New BLuser
                    DBOpen.sqlexecnon(sql, frmactlist.CYSysInfo.ConnStrValue)
                    Me.C1FlexGrid.Rows.Remove(Me.C1FlexGrid.Row)
                    Me.frmactlist.refesh()

                    If Me.C1FlexGrid.Rows.Count = 1 Then
                        Me.Button1.Enabled = False
                    End If

                End If
            End If
        End If
    End Sub
End Class