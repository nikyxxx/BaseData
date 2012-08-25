Imports PublicSharedResource
Imports C1.Win.C1FlexGrid
Imports SGL.BLL
Public Class frmAddAcountGroup
    Inherits frmBase
    Public sql, fgrouid, style As String
    Public ds As New System.Data.DataSet
    Private DBOpen As SGL.BLL.BLuser
    Public constr As String
    Public frm As New Faccountlist

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = Cursors.WaitCursor
        If Me.Text = "科目组-新增" Then
            Try
                If IsNumeric(Me.C1TextBox1.Text.Trim.ToString) = True Then
                    If Integer.Parse(Me.C1TextBox1.Text.Trim.ToString) > 100 And Integer.Parse(Me.C1TextBox1.Text.Trim.ToString) < 700 Then
                        sql = ""
                        sql = "select FClassID,FGroupID,FName,FName_cht,FName_en from t_AcctGroup where FGroupID=" & Me.C1TextBox1.Text.Trim.ToString
                        ds.Clear()
                        DBOpen = New BLuser
                        ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
                        If ds.Tables(0).Rows.Count = 0 Then
                            sql = ""
                            sql = "INSERT INTO t_AcctGroup(FClassID,FGroupID,FName,FName_cht,FName_en) values (" & Microsoft.VisualBasic.Left(Me.C1TextBox1.Text.Trim.ToString, 1) & "," & Me.C1TextBox1.Text.Trim.ToString
                            sql += ",'" & Me.C1TextBox2.Text.Trim.ToString & "','" & Me.C1TextBox2.Text.Trim.ToString & "','" & Me.C1TextBox2.Text.Trim.Trim & "')"
                            DBOpen = New BLuser
                            DBOpen.sqlexecnon(sql, Me.CYSysInfo.ConnStrValue)
                            MsgBox("添加成功！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                        Else
                            MsgBox("必已经存在相同的编码了！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                        End If
                    Else
                        MsgBox("数字必须大于100且小于700的数字！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                    End If
                Else
                    MsgBox("必须是数字", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        Else
            sql = ""
            sql = "update t_acctgroup set FName='" & Me.C1TextBox2.Text.Trim.ToString & "',FName_cht='" & Me.C1TextBox2.Text.Trim.ToString & "',FName_en='" & Me.C1TextBox2.Text.Trim.ToString & " ' where FGroupID=" & Me.C1TextBox1.Text.Trim.ToString
            DBOpen = New BLuser
            DBOpen.sqlexecnon(sql, Me.CYSysInfo.ConnStrValue)
            MsgBox("更新成功", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
        End If
        Me.frm.refesh()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmAddAcountGroup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.style = "科目组-新增" Then
            Me.Text = "科目组-新增"
        Else
            Me.Text = "科目组-修改"
            Me.C1TextBox1.Text = Me.fgrouid
            Me.C1TextBox1.Enabled = False
        End If
    End Sub
End Class