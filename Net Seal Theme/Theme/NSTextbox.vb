Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
<DefaultEvent("TextChanged")> _
Public Class NSTextBox
    Inherits Control
    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            If Base IsNot Nothing Then
                Base.TextAlign = value
            End If
        End Set
    End Property
    Private _MaxLength As Integer = 32767
    Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
            If Base IsNot Nothing Then
                Base.MaxLength = value
            End If
        End Set
    End Property
    Private _ReadOnly As Boolean
    Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly = value
            If Base IsNot Nothing Then
                Base.ReadOnly = value
            End If
        End Set
    End Property
    Private _UseSystemPasswordChar As Boolean
    Property UseSystemPasswordChar() As Boolean
        Get
            Return _UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            _UseSystemPasswordChar = value
            If Base IsNot Nothing Then
                Base.UseSystemPasswordChar = value
            End If
        End Set
    End Property
    Private _Multiline As Boolean
    Property Multiline() As Boolean
        Get
            Return _Multiline
        End Get
        Set(ByVal value As Boolean)
            _Multiline = value
            If Base IsNot Nothing Then
                Base.Multiline = value
                If value Then
                    Base.Height = Height - 11
                Else
                    Height = Base.Height + 11
                End If
            End If
        End Set
    End Property
    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            If Base IsNot Nothing Then
                Base.Text = value
            End If
        End Set
    End Property
    Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            If Base IsNot Nothing Then
                Base.Font = value
                Base.Location = New Point(5, 5)
                Base.Width = Width - 8
                If Not _Multiline Then
                    Height = Base.Height + 11
                End If
            End If
        End Set
    End Property
    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        If Not Controls.Contains(Base) Then
            Controls.Add(Base)
        End If
        MyBase.OnHandleCreated(e)
    End Sub
    Private Base As TextBox
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, True)
        Cursor = Cursors.IBeam
        Base = New TextBox
        Base.Font = Font
        Base.Text = Text
        Base.MaxLength = _MaxLength
        Base.Multiline = _Multiline
        Base.ReadOnly = _ReadOnly
        Base.UseSystemPasswordChar = _UseSystemPasswordChar
        Base.ForeColor = Color.White
        Base.BackColor = Color.FromArgb(50, 50, 50)
        Base.BorderStyle = BorderStyle.None
        Base.Location = New Point(5, 5)
        Base.Width = Width - 14
        If _Multiline Then
            Base.Height = Height - 11
        Else
            Height = Base.Height + 11
        End If
        AddHandler Base.TextChanged, AddressOf OnBaseTextChanged
        AddHandler Base.KeyDown, AddressOf OnBaseKeyDown
        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(55, 55, 55))
    End Sub
    Private GP1, GP2 As GraphicsPath
    Private P1, P2 As Pen
    Private PB1 As PathGradientBrush
    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias
        GP1 = CreateRound(0, 0, Width - 1, Height - 1, 7)
        GP2 = CreateRound(1, 1, Width - 3, Height - 3, 7)
        PB1 = New PathGradientBrush(GP1)
        PB1.CenterColor = Color.FromArgb(50, 50, 50)
        PB1.SurroundColors = {Color.FromArgb(45, 45, 45)}
        PB1.FocusScales = New PointF(0.9F, 0.5F)
        G.FillPath(PB1, GP1)
        G.DrawPath(P2, GP1)
        G.DrawPath(P1, GP2)
    End Sub
    Private Sub OnBaseTextChanged(ByVal s As Object, ByVal e As EventArgs)
        Text = Base.Text
    End Sub
    Private Sub OnBaseKeyDown(ByVal s As Object, ByVal e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            Base.SelectAll()
            e.SuppressKeyPress = True
        End If
    End Sub
    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        Base.Location = New Point(5, 5)
        Base.Width = Width - 10
        Base.Height = Height - 11
        MyBase.OnResize(e)
    End Sub
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Base.Focus()
        MyBase.OnMouseDown(e)
    End Sub
    Protected Overrides Sub OnEnter(e As EventArgs)
        Base.Focus()
        Invalidate()
        MyBase.OnEnter(e)
    End Sub
    Protected Overrides Sub OnLeave(e As EventArgs)
        Invalidate()
        MyBase.OnLeave(e)
    End Sub
End Class