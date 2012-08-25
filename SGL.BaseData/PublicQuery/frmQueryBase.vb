Public Class frmQueryBase
    Inherits System.Windows.Forms.Form

#Region "成员变量声明"

    Private m_intUserID As Integer

    Private m_strConnValue As String

    Private m_strRtnDataTable As New DataTable

    Private m_blnAllowMultiLine As Boolean

    Private m_strClassType As String

    Private m_blnChooseDetailOnly As Boolean

    Private m_strQuerySql As String

    Private m_strQueryText As String

    Private m_hasTable As Hashtable

    ''' <summary>
    ''' 用户ID,与金蝶的t_User表中的ItemID对应
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UserID() As Integer
        Get
            Return m_intUserID
        End Get
        Set(ByVal value As Integer)
            m_intUserID = value
        End Set
    End Property

    ''' <summary>
    ''' 账套信息的键值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DBConnValue() As String
         Get
            Return m_strConnValue
        End Get
        Set(ByVal value As String)
            m_strConnValue = value
        End Set
    End Property

    ''' <summary>
    ''' 查询框的返回值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RtnDataTable() As DataTable
        Get
            Return m_strRtnDataTable
        End Get
        Set(ByVal value As DataTable)
            m_strRtnDataTable = value
        End Set
    End Property

    ''' <summary>
    ''' 是否允许多行选择
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AllowMultiLine() As Boolean
        Get
            Return m_blnAllowMultiLine
        End Get
        Set(ByVal value As Boolean)
            m_blnAllowMultiLine = value
        End Set
    End Property

    ''' <summary>
    ''' 核算项目类别ID（只有当查询核算项目是才有用，其它查询默认输入0）
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ClassType() As String
        Get
            Return m_strClassType
        End Get
        Set(ByVal value As String)
            m_strClassType = value
        End Set
    End Property

    Public Property ChooseDetailOnly() As Boolean
        Get
            Return m_blnChooseDetailOnly
        End Get
        Set(ByVal value As Boolean)
            m_blnChooseDetailOnly = value
        End Set
    End Property

    Public Property QuerySql() As String
        Get
            Return m_strQuerySql
        End Get
        Set(ByVal value As String)
            m_strQuerySql = value
        End Set
    End Property

    Public Property QueryText() As String
        Get
            Return m_strQueryText
        End Get
        Set(ByVal value As String)
            m_strQueryText = value
        End Set
    End Property

    Public Property hasTable() As Hashtable
        Get
            Return m_hasTable
        End Get
        Set(ByVal value As Hashtable)
            m_hasTable = value
        End Set
    End Property
#End Region

    Private Sub frmQueryBase_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'm_strRtnDataTable = Nothing
    End Sub
End Class