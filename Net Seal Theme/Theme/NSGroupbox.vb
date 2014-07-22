Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Public Class NSGroupBox
    Inherits ContainerControl
    Private _DrawSeperator As Boolean
    Public Property DrawSeperator() As Boolean
        Get
            Return _DrawSeperator
        End Get
        Set(ByVal value As Boolean)
            _DrawSeperator = value
            Invalidate()
        End Set
    End Property
    Private _Title As String = "GroupBox"
    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal value As String)
            _Title = value
            Invalidate()
        End Set
    End Property
    Private _SubTitle As String = "Details"
    Public Property SubTitle() As String
        Get
            Return _SubTitle
        End Get
        Set(ByVal value As String)
            _SubTitle = value
            Invalidate()
        End Set
    End Property
    Private _TitleFont As Font
    Private _SubTitleFont As Font
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)
        _TitleFont = New Font("Verdana", 10.0F)
        _SubTitleFont = New Font("Verdana", 6.5F)
        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(55, 55, 55))
        B1 = New SolidBrush(Color.FromArgb(205, 150, 0))
    End Sub
    Private GP1, GP2 As GraphicsPath
    Private PT1 As PointF
    Private SZ1, SZ2 As SizeF
    Private P1, P2 As Pen
    Private B1 As SolidBrush
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias
        GP1 = CreateRound(0, 0, Width - 1, Height - 1, 7)
        GP2 = CreateRound(1, 1, Width - 3, Height - 3, 7)
        G.DrawPath(P1, GP1)
        G.DrawPath(P2, GP2)
        SZ1 = G.MeasureString(_Title, _TitleFont, Width, StringFormat.GenericTypographic)
        SZ2 = G.MeasureString(_SubTitle, _SubTitleFont, Width, StringFormat.GenericTypographic)
        G.DrawString(_Title, _TitleFont, Brushes.Black, 6, 6)
        G.DrawString(_Title, _TitleFont, B1, 5, 5)
        PT1 = New PointF(6.0F, SZ1.Height + 4.0F)
        G.DrawString(_SubTitle, _SubTitleFont, Brushes.Black, PT1.X + 1, PT1.Y + 1)
        G.DrawString(_SubTitle, _SubTitleFont, Brushes.White, PT1.X, PT1.Y)
        If _DrawSeperator Then
            Dim Y As Integer = CInt(PT1.Y + SZ2.Height) + 8
            G.DrawLine(P1, 4, Y, Width - 5, Y)
            G.DrawLine(P2, 4, Y + 1, Width - 5, Y + 1)
        End If
    End Sub
End Class