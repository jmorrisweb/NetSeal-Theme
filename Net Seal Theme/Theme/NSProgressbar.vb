Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class NSProgressBar
    Inherits Control
    Private _Minimum As Integer
    Property Minimum() As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception("Property value is not valid.")
            End If
            _Minimum = value
            If value > _Value Then _Value = value
            If value > _Maximum Then _Maximum = value
            Invalidate()
        End Set
    End Property
    Private _Maximum As Integer = 100
    Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception("Property value is not valid.")
            End If
            _Maximum = value
            If value < _Value Then _Value = value
            If value < _Minimum Then _Minimum = value
            Invalidate()
        End Set
    End Property
    Private _Value As Integer
    Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            If value > _Maximum OrElse value < _Minimum Then
                Throw New Exception("Property value is not valid.")
            End If
            _Value = value
            Invalidate()
        End Set
    End Property
    Private Sub Increment(ByVal amount As Integer)
        Value += amount
    End Sub
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)
        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(55, 55, 55))
        B1 = New SolidBrush(Color.FromArgb(200, 160, 0))
    End Sub
    Private GP1, GP2, GP3 As GraphicsPath
    Private R1, R2 As Rectangle
    Private P1, P2 As Pen
    Private B1 As SolidBrush
    Private GB1, GB2 As LinearGradientBrush
    Private I1 As Integer
    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias
        GP1 = CreateRound(0, 0, Width - 1, Height - 1, 7)
        GP2 = CreateRound(1, 1, Width - 3, Height - 3, 7)
        R1 = New Rectangle(0, 2, Width - 1, Height - 1)
        GB1 = New LinearGradientBrush(R1, Color.FromArgb(45, 45, 45), Color.FromArgb(50, 50, 50), 90.0F)
        G.SetClip(GP1)
        G.FillRectangle(GB1, R1)
        I1 = CInt((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 3))
        If I1 > 1 Then
            GP3 = CreateRound(1, 1, I1, Height - 3, 7)
            R2 = New Rectangle(1, 1, I1, Height - 3)
            GB2 = New LinearGradientBrush(R2, Color.FromArgb(205, 150, 0), Color.FromArgb(150, 110, 0), 90.0F)
            G.FillPath(GB2, GP3)
            G.DrawPath(P1, GP3)
            G.SetClip(GP3)
            G.SmoothingMode = SmoothingMode.None
            G.FillRectangle(B1, R2.X, R2.Y + 1, R2.Width, R2.Height \ 2)
            G.SmoothingMode = SmoothingMode.AntiAlias
            G.ResetClip()
        End If
        G.DrawPath(P2, GP1)
        G.DrawPath(P1, GP2)
    End Sub
End Class