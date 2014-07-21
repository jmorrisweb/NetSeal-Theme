Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
<DefaultEvent("Scroll")> _
Public Class NSHScrollBar
    Inherits Control
    Event Scroll(ByVal sender As Object)
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
            InvalidateLayout()
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
            InvalidateLayout()
        End Set
    End Property
    Private _Value As Integer
    Property Value() As Integer
        Get
            If Not ShowThumb Then Return _Minimum
            Return _Value
        End Get
        Set(ByVal value As Integer)
            If value = _Value Then Return
            If value > _Maximum OrElse value < _Minimum Then
                Throw New Exception("Property value is not valid.")
            End If
            _Value = value
            InvalidatePosition()
            RaiseEvent Scroll(Me)
        End Set
    End Property
    Private _SmallChange As Integer = 1
    Public Property SmallChange() As Integer
        Get
            Return _SmallChange
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then
                Throw New Exception("Property value is not valid.")
            End If
            _SmallChange = value
        End Set
    End Property
    Private _LargeChange As Integer = 10
    Public Property LargeChange() As Integer
        Get
            Return _LargeChange
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then
                Throw New Exception("Property value is not valid.")
            End If
            _LargeChange = value
        End Set
    End Property
    Private ButtonSize As Integer = 16
    Private ThumbSize As Integer = 24 ' 14 minimum
    Private LSA As Rectangle
    Private RSA As Rectangle
    Private Shaft As Rectangle
    Private Thumb As Rectangle
    Private ShowThumb As Boolean
    Private ThumbDown As Boolean
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)
        Height = 18
        B1 = New SolidBrush(Color.FromArgb(55, 55, 55))
        B2 = New SolidBrush(Color.FromArgb(35, 35, 35))
        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(65, 65, 65))
        P3 = New Pen(Color.FromArgb(55, 55, 55))
        P4 = New Pen(Color.FromArgb(40, 40, 40))
    End Sub
    Private GP1, GP2, GP3, GP4 As GraphicsPath
    Private P1, P2, P3, P4 As Pen
    Private B1, B2 As SolidBrush
    Dim I1 As Integer
    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.Clear(BackColor)
        GP1 = DrawArrow(6, 4, False)
        GP2 = DrawArrow(7, 5, False)
        G.FillPath(B1, GP2)
        G.FillPath(B2, GP1)
        GP3 = DrawArrow(Width - 11, 4, True)
        GP4 = DrawArrow(Width - 10, 5, True)
        G.FillPath(B1, GP4)
        G.FillPath(B2, GP3)
        If ShowThumb Then
            G.FillRectangle(B1, Thumb)
            G.DrawRectangle(P1, Thumb)
            G.DrawRectangle(P2, Thumb.X + 1, Thumb.Y + 1, Thumb.Width - 2, Thumb.Height - 2)
            Dim X As Integer
            Dim LX As Integer = Thumb.X + (Thumb.Width \ 2) - 3
            For I As Integer = 0 To 2
                X = LX + (I * 3)
                G.DrawLine(P1, X, Thumb.Y + 5, X, Thumb.Bottom - 5)
                G.DrawLine(P2, X + 1, Thumb.Y + 5, X + 1, Thumb.Bottom - 5)
            Next
        End If
        G.DrawRectangle(P3, 0, 0, Width - 1, Height - 1)
        G.DrawRectangle(P4, 1, 1, Width - 3, Height - 3)
    End Sub
    Private Function DrawArrow(x As Integer, y As Integer, flip As Boolean) As GraphicsPath
        Dim GP As New GraphicsPath()
        Dim W As Integer = 5
        Dim H As Integer = 9
        If flip Then
            GP.AddLine(x, y + 1, x, y + H + 1)
            GP.AddLine(x, y + H, x + W - 1, y + W)
        Else
            GP.AddLine(x + W, y, x + W, y + H)
            GP.AddLine(x + W, y + H, x + 1, y + W)
        End If
        GP.CloseFigure()
        Return GP
    End Function
    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        InvalidateLayout()
    End Sub
    Private Sub InvalidateLayout()
        LSA = New Rectangle(0, 0, ButtonSize, Height)
        RSA = New Rectangle(Width - ButtonSize, 0, ButtonSize, Height)
        Shaft = New Rectangle(LSA.Right + 1, 0, Width - (ButtonSize * 2) - 1, Height)
        ShowThumb = ((_Maximum - _Minimum) > Shaft.Width)
        If ShowThumb Then
            'ThumbSize = Math.Max(0, 14) 'TODO: Implement this.
            Thumb = New Rectangle(0, 1, ThumbSize, Height - 3)
        End If
        RaiseEvent Scroll(Me)
        InvalidatePosition()
    End Sub
    Private Sub InvalidatePosition()
        Thumb.X = CInt(GetProgress() * (Shaft.Width - ThumbSize)) + LSA.Width
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso ShowThumb Then
            If LSA.Contains(e.Location) Then
                I1 = _Value - _SmallChange
            ElseIf RSA.Contains(e.Location) Then
                I1 = _Value + _SmallChange
            Else
                If Thumb.Contains(e.Location) Then
                    ThumbDown = True
                    MyBase.OnMouseDown(e)
                    Return
                Else
                    If e.X < Thumb.X Then
                        I1 = _Value - _LargeChange
                    Else
                        I1 = _Value + _LargeChange
                    End If
                End If
            End If
            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum)
            InvalidatePosition()
        End If
        MyBase.OnMouseDown(e)
    End Sub
    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If ThumbDown AndAlso ShowThumb Then
            Dim ThumbPosition As Integer = e.X - LSA.Width - (ThumbSize \ 2)
            Dim ThumbBounds As Integer = Shaft.Width - ThumbSize
            I1 = CInt((ThumbPosition / ThumbBounds) * (_Maximum - _Minimum)) + _Minimum
            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum)
            InvalidatePosition()
        End If
        MyBase.OnMouseMove(e)
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        ThumbDown = False
        MyBase.OnMouseUp(e)
    End Sub
    Private Function GetProgress() As Double
        Return (_Value - _Minimum) / (_Maximum - _Minimum)
    End Function
End Class