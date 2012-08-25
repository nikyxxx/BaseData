Imports PublicSharedResource
Imports SGL.BLL
Imports D1Lib
Imports System.Reflection

Public Class FormViewUtility
    Private Shared getdate As New SGL.BLL.BLuser
    Private Shared myCtrls As Windows.Forms.Control.ControlCollection
    Private Shared dic As Dictionary(Of String, myPostion)
    Private Shared m_BaseDataSetting As BaseDataSetting
    Private Shared TabControlName As String = "TabControl"

    Public Shared Function CreateView(ByVal m_tranType As Integer, ByVal ConnStrValue As String, ByVal _ctrls As Windows.Forms.Control.ControlCollection) As Dictionary(Of String, myPostion)
        myCtrls = _ctrls
        dic = New Dictionary(Of String, myPostion)
        m_BaseDataSetting = New BaseDataSetting()
        Dim str As String
        str = "select * from t_sgl_ictemplate where fid=" + m_tranType.ToString() + " and FVisForBillType=1 order by FTabIndex"
        Dim dt As DataTable
        dt = getdate.GetDataset(str, ConnStrValue).Tables(0)

        str = "select * from t_sgl_ICEntry where fid=" + m_tranType.ToString()
        Dim dtEnTry As DataTable
        dtEnTry = getdate.GetDataset(str, ConnStrValue).Tables(0)

        str = "select * from t_cs_ICBillTabPage where fid=" + m_tranType.ToString()
        str += " select * from t_cs_ICBillTabPageEntry where fid=" + m_tranType.ToString()
        Dim dtTabPage As DataSet
        dtTabPage = getdate.GetDataset(str, ConnStrValue)
        LoadTab(dtTabPage)

        For i As Integer = 0 To dt.Rows.Count - 1
            CreateControl(dt.Rows(i))
        Next
        If dtEnTry.Rows.Count > 0 Then
            LoadEnTry(dtEnTry.Rows(0))
        End If

        Return dic
        'LoadEvent()
    End Function

    Private Shared Sub LoadTab(ByVal _dtTabPage As DataSet)
        Dim tabMain As TabControl
        If _dtTabPage.Tables(0).Rows.Count > 0 Then
            If myCtrls.Find(TabControlName, True).Length > 0 Then
                tabMain = myCtrls.Find(TabControlName, True)(0)
            Else
                tabMain = New TabControl
                myCtrls.Add(tabMain)
                tabMain.Name = TabControlName
                tabMain.Text = TabControlName
            End If
            tabMain.Left = _dtTabPage.Tables(0).Rows(0)("FLeft")
            tabMain.Width = _dtTabPage.Tables(0).Rows(0)("FWidth")
            tabMain.Top = _dtTabPage.Tables(0).Rows(0)("FTop")
            tabMain.Height = _dtTabPage.Tables(0).Rows(0)("FHeight")
            tabMain.BringToFront() '置前

            dic.Add(tabMain.Name, New myPostion(_dtTabPage.Tables(0).Rows(0)("FTop"), _dtTabPage.Tables(0).Rows(0)("FLeft"), _dtTabPage.Tables(0).Rows(0)("FHeight"), _dtTabPage.Tables(0).Rows(0)("FWidth")))
        End If

        For Each item As DataRow In _dtTabPage.Tables(1).Rows
            tabMain.TabPages.Add(item("FTabName").ToString(), item("FTabName").ToString())
        Next

    End Sub

    Private Shared Sub LoadEnTry(ByVal dr As DataRow)

        Dim cl As Control = myCtrls.Find("panelList", True)(0)

        cl.Top = CType(dr("FTop"), Integer)
        cl.Left = CType(dr("FLeft"), Integer)
        cl.Width = CType(dr("FWidth"), Integer)
        cl.Height = CType(dr("FHeight"), Integer)

        dic.Add(cl.Name, New myPostion(dr("FTop"), dr("FLeft"), dr("FHeight"), dr("FWidth")))
    End Sub

    Private Shared Sub CreateControl(ByVal dr As DataRow)
        Dim _Top As Integer
        Dim _Left As Integer
        Dim _Height As Integer
        Dim _Width As Integer
        Dim cl As Control


        If CType(dr("FTabIndex") = 0, Integer) Then
            cl = New Label()
            CType(cl, Label).Text = dr("FCaption").ToString()
            CType(cl, Label).Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold)
        Else
            If dr("FCtlType").ToString() = "4" Then
                cl = New D1DateTime()
                CType(cl, D1DateTime).LabelName = dr("FCaption").ToString()
                cl.TabIndex = dr("FTabIndex").ToString()
            ElseIf dr("FCtlType").ToString() = "5" Then
                cl = New CheckBox()
                CType(cl, CheckBox).Text = dr("FCaption").ToString()
                cl.TabIndex = dr("FTabIndex").ToString()
            Else
                cl = New D1TextBox()
                'CType(cl, D1TextBox).LabelName = IIf(dr("FNeedSave"), dr("FCaption").ToString() + "*", dr("FCaption").ToString())
                CType(cl, D1TextBox).LabelName = dr("FCaption").ToString()
                CType(cl, D1TextBox).ItemClassID = Integer.Parse(dr("FLookUpCls").ToString())
                cl.TabIndex = dr("FTabIndex").ToString()
                If CType(cl, D1TextBox).ItemClassID <> 0 Then
                    CType(cl, D1TextBox).Value = "0"
                    'CType(cl, D1TextBox).BackColor = Color.LightYellow
                    cl.BackColor = Color.LightYellow
                Else
                    cl.BackColor = Color.White
                End If
                'cl.BackColor = Color.White
                'AddHandler CType(cl, D1TextBox).DoubleClick, AddressOf Me.d1TextBox_DoubleClick
                'AddHandler CType(cl, D1TextBox).UserControlKeyDown, AddressOf d1TextBox_UserControlKeyDown
            End If
        End If
        cl.Enabled = dr("FEnabled")
        cl.Tag = dr("FTag").ToString()
        cl.Name = dr("FFieldName").ToString()
        cl.Top = CType(dr("FTop"), Integer)
        cl.Left = CType(dr("FLeft"), Integer)
        cl.Width = CType(dr("FWidth"), Integer)
        cl.Height = CType(dr("FHeight"), Integer)

        If dr("FTabName").ToString() <> "" Then
            CType(myCtrls.Find(dr("FTabName").ToString(), True)(0), TabPage).Controls.Add(cl)
        Else
            myCtrls.Add(cl)
        End If

        dic.Add(dr("FFieldName").ToString(), New myPostion(dr("FTop"), dr("FLeft"), dr("FHeight"), dr("FWidth")))
    End Sub

    ''' <summary>
    ''' 不可编辑的控件重新设置编辑状态
    ''' </summary>
    ''' <param name="m_tranType"></param>
    ''' <param name="ConnStrValue"></param>
    ''' <param name="_ctrls"></param>
    ''' <remarks></remarks>
    Public Shared Sub controlsUnabled(ByVal m_tranType As Integer, ByVal ConnStrValue As String, ByVal _ctrls As Windows.Forms.Control.ControlCollection)

        Dim str As String
        str = "select * from t_sgl_ictemplate where fid=" + m_tranType.ToString() + " and FVisForBillType=1 and FEnabled=0"
        Dim dt As DataTable
        dt = getdate.GetDataset(str, ConnStrValue).Tables(0)

        For i As Integer = 0 To dt.Rows.Count - 1
            _ctrls.Find(dt.Rows(i)("FFieldName").ToString(), True)(0).Enabled = False
        Next
    End Sub

    Public Shared Sub SetCommonProperty(ByVal _ctrls As Windows.Forms.Control.ControlCollection, ByVal _id As String, ByVal _value1 As Object, Optional ByVal _value2 As Object = Nothing)
        If _ctrls.Find(_id, True).Length > 0 Then
            If TypeOf _ctrls.Find(_id, True)(0) Is D1TextBox Then
                Dim dtl As D1TextBox = CType(_ctrls.Find(_id, True)(0), D1TextBox)
                dtl.Text = _value1
                If _value2 Is System.DBNull.Value Then
                    dtl.Value = Nothing
                    Return
                End If
                If _value2 = Nothing Then
                    dtl.Value = _value2
                Else
                    dtl.Value = _value2.ToString()
                End If
                'dtl.Value = IIf(_value2 = Nothing, _value2, _value2.ToString())
            ElseIf TypeOf _ctrls.Find(_id, True)(0) Is D1DateTime Then
                Dim dtl As D1DateTime = CType(_ctrls.Find(_id, True)(0), D1DateTime)
                dtl.Text = _value1
            End If
        Else
            Throw New Exception("缺少[" + _id + "]字段")
        End If
    End Sub

    Public Shared Function SetControlProperty(ByVal _ctrls As Windows.Forms.Control.ControlCollection, ByVal _id As String, ByVal _property As String, ByVal _value As Object)
        Try


            '获取控件的属性 
            If _ctrls.Find(_id, True).Length > 0 Then
                Dim ctl As Control = _ctrls.Find(_id, True)(0)
                Dim controlType As Type = ctl.GetType()
                Dim objPropertiesArray() As PropertyInfo = controlType.GetProperties()
                Dim controlProperty As PropertyInfo
                For Each controlProperty In objPropertiesArray
                    If controlProperty.Name = _property Then
                        controlProperty.SetValue(ctl, Convert.ChangeType(_value, controlProperty.PropertyType), Nothing)
                        Return True
                    End If
                Next
                Throw New Exception("控件【" + _id + "】不存在【" + _property + "】属性")
            Else
                Throw New Exception("未找到【" + _id + "】控件")
            End If
            Return False

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GetControlProperty(ByVal _ctrls As Windows.Forms.Control.ControlCollection, ByVal _id As String, ByVal _property As String) As Object
        Dim dtl As Control
        If _ctrls.Find(_id, True).Length > 0 Then
            'If TypeOf Me.Controls.Find(_id, True)(0) Is D1TextBox Then
            '    dtl = CType(Me.Controls.Find(_id, True)(0), D1TextBox)
            'ElseIf TypeOf Me.Controls.Find(_id, True)(0) Is D1DateTime Then
            '    dtl = CType(Me.Controls.Find(_id, True)(0), D1DateTime)
            'End If
            dtl = Convert.ChangeType(_ctrls.Find(_id, True)(0), _ctrls.Find(_id, True)(0).GetType())
        Else
            'Return Nothing
            Throw New Exception("未找到【" + _id + "】控件")
        End If

        Dim objType As Type = dtl.GetType()
        Dim objPropertiesArray() As PropertyInfo = objType.GetProperties()

        Dim controlProperty As PropertyInfo
        For Each controlProperty In objPropertiesArray
            If controlProperty.Name = _property Then
                Return Convert.ChangeType(controlProperty.GetValue(dtl, Nothing), controlProperty.PropertyType)
            End If
        Next
        'Return Nothing
        Throw New Exception("控件【" + _id + "】不存在【" + _property + "】属性")
    End Function

    Public Shared Function getControlByID(ByVal _ctrls As Windows.Forms.Control.ControlCollection, _id As String) As Object
        If _ctrls.Find(_id, True).Length > 0 Then
            Return _ctrls.Find(_id, True)(0)
        Else
            Throw New Exception("未找到【" + _id + "】控件")
        End If
    End Function

    Public Shared Function haveControlByID(ByVal _ctrls As Windows.Forms.Control.ControlCollection, _id As String) As Boolean
        If _ctrls.Find(_id, True).Length > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function getItemSignByItemID(ByVal _itemID As Integer, ByVal ConnStrValue As String) As String
        Dim str As String
        str = "select isnull(F_110,'') as F_110 from t_icItem where FItemID=" + _itemID.ToString()
        Dim dt As DataTable
        dt = getdate.GetDataset(str, ConnStrValue).Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)("F_110")
        End If
    End Function
End Class
