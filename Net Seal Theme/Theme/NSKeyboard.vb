Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Drawing.Text

Public Class NSKeyboard
    Inherits Control
    Private TextBitmap As Bitmap
    Private TextGraphics As Graphics
    Const LowerKeys As String = "1234567890-=qwertyuiop[]asdfghjkl\;'zxcvbnm,./`"
    Const UpperKeys As String = "!@#$%^&*()_+QWERTYUIOP{}ASDFGHJKL|:""ZXCVBNM<>?~"
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)
        Font = New Font("Verdana", 8.25F)
        TextBitmap = New Bitmap(1, 1)
        TextGraphics = Graphics.FromImage(TextBitmap)
        MinimumSize = New Size(386, 162)
        MaximumSize = New Size(386, 162)
        Lower = LowerKeys.ToCharArray()
        Upper = UpperKeys.ToCharArray()
        PrepareCache()
        P1 = New Pen(Color.FromArgb(45, 45, 45))
        P2 = New Pen(Color.FromArgb(65, 65, 65))
        P3 = New Pen(Color.FromArgb(35, 35, 35))
        B1 = New SolidBrush(Color.FromArgb(100, 100, 100))
    End Sub
    Private _Target As Control
    Public Property Target() As Control
        Get
            Return _Target
        End Get
        Set(ByVal value As Control)
            _Target = value
        End Set
    End Property
    Private Shift As Boolean
    Private Pressed As Integer = -1
    Private Buttons As Rectangle()
    Private Lower As Char()
    Private Upper As Char()
    Private Other As String() = {"Shift", "Space", "Back"}
    Private UpperCache As PointF()
    Private LowerCache As PointF()
    Private Sub PrepareCache()
        Buttons = New Rectangle(50) {}
        UpperCache = New PointF(Upper.Length - 1) {}
        LowerCache = New PointF(Lower.Length - 1) {}
        Dim I As Integer
        Dim S As SizeF
        Dim R As Rectangle
        For Y As Integer = 0 To 3
            For X As Integer = 0 To 11
                I = (Y * 12) + X
                R = New Rectangle(X * 32, Y * 32, 32, 32)
                Buttons(I) = R
                If Not I = 47 AndAlso Not Char.IsLetter(Upper(I)) Then
                    S = TextGraphics.MeasureString(Upper(I), Font)
                    UpperCache(I) = New PointF(R.X + (R.Width \ 2 - S.Width / 2), R.Y + R.Height - S.Height - 2)
                    S = TextGraphics.MeasureString(Lower(I), Font)
                    LowerCache(I) = New PointF(R.X + (R.Width \ 2 - S.Width / 2), R.Y + R.Height - S.Height - 2)
                End If
            Next
        Next
        Buttons(48) = New Rectangle(0, 4 * 32, 2 * 32, 32)
        Buttons(49) = New Rectangle(Buttons(48).Right, 4 * 32, 8 * 32, 32)
        Buttons(50) = New Rectangle(Buttons(49).Right, 4 * 32, 2 * 32, 32)
    End Sub
    Private GP1 As GraphicsPath
    Private SZ1 As SizeF
    Private PT1 As PointF
    Private P1, P2, P3 As Pen
    Private B1 As SolidBrush
    Private PB1 As PathGradientBrush
    Private GB1 As LinearGradientBrush
    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        G.Clear(BackColor)
        Dim R As Rectangle
        Dim Offset As Integer
        G.DrawRectangle(P1, 0, 0, (12 * 32) + 1, (5 * 32) + 1)
        For I As Integer = 0 To Buttons.Length - 1
            R = Buttons(I)
            Offset = 0
            If I = Pressed Then
                Offset = 1
                GP1 = New GraphicsPath()
                GP1.AddRectangle(R)
                PB1 = New PathGradientBrush(GP1)
                PB1.CenterColor = Color.FromArgb(60, 60, 60)
                PB1.SurroundColors = {Color.FromArgb(55, 55, 55)}
                PB1.FocusScales = New PointF(0.8F, 0.5F)
                G.FillPath(PB1, GP1)
            Else
                GB1 = New LinearGradientBrush(R, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0F)
                G.FillRectangle(GB1, R)
            End If
            Select Case I
                Case 48, 49, 50
                    SZ1 = G.MeasureString(Other(I - 48), Font)
                    G.DrawString(Other(I - 48), Font, Brushes.Black, R.X + (R.Width \ 2 - SZ1.Width / 2) + Offset + 1, R.Y + (R.Height \ 2 - SZ1.Height / 2) + Offset + 1)
                    G.DrawString(Other(I - 48), Font, Brushes.White, R.X + (R.Width \ 2 - SZ1.Width / 2) + Offset, R.Y + (R.Height \ 2 - SZ1.Height / 2) + Offset)
                Case 47
                    DrawArrow(Color.Black, R.X + Offset + 1, R.Y + Offset + 1)
                    DrawArrow(Color.White, R.X + Offset, R.Y + Offset)
                Case Else
                    If Shift Then
                        G.DrawString(Upper(I), Font, Brushes.Black, R.X + 3 + Offset + 1, R.Y + 2 + Offset + 1)
                        G.DrawString(Upper(I), Font, Brushes.White, R.X + 3 + Offset, R.Y + 2 + Offset)
                        If Not Char.IsLetter(Lower(I)) Then
                            PT1 = LowerCache(I)
                            G.DrawString(Lower(I), Font, B1, PT1.X + Offset, PT1.Y + Offset)
                        End If
                    Else
                        G.DrawString(Lower(I), Font, Brushes.Black, R.X + 3 + Offset + 1, R.Y + 2 + Offset + 1)
                        G.DrawString(Lower(I), Font, Brushes.White, R.X + 3 + Offset, R.Y + 2 + Offset)
                        If Not Char.IsLetter(Upper(I)) Then
                            PT1 = UpperCache(I)
                            G.DrawString(Upper(I), Font, B1, PT1.X + Offset, PT1.Y + Offset)
                        End If
                    End If
            End Select
            G.DrawRectangle(P2, R.X + 1 + Offset, R.Y + 1 + Offset, R.Width - 2, R.Height - 2)
            G.DrawRectangle(P3, R.X + Offset, R.Y + Offset, R.Width, R.Height)
            If I = Pressed Then
                G.DrawLine(P1, R.X, R.Y, R.Right, R.Y)
                G.DrawLine(P1, R.X, R.Y, R.X, R.Bottom)
            End If
        Next
    End Sub
    Private Sub DrawArrow(color As Color, rx As Integer, ry As Integer)
        Dim R As New Rectangle(rx + 8, ry + 8, 16, 16)
        G.SmoothingMode = SmoothingMode.AntiAlias
        Dim P As New Pen(color, 1)
        Dim C As New AdjustableArrowCap(3, 2)
        P.CustomEndCap = C
        G.DrawArc(P, R, 0.0F, 290.0F)
        P.Dispose()
        C.Dispose()
        G.SmoothingMode = SmoothingMode.None
    End Sub
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Dim Index As Integer = ((e.Y \ 32) * 12) + (e.X \ 32)
        If Index > 47 Then
            For I As Integer = 48 To Buttons.Length - 1
                If Buttons(I).Contains(e.X, e.Y) Then
                    Pressed = I
                    Exit For
                End If
            Next
        Else
            Pressed = Index
        End If
        HandleKey()
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        Pressed = -1
        Invalidate()
    End Sub
    Private Sub HandleKey()
        If _Target Is Nothing Then Return
        If Pressed = -1 Then Return
        Select Case Pressed
            Case 47
                _Target.Text = String.Empty
            Case 48
                Shift = Not Shift
            Case 49
                _Target.Text &= " "
            Case 50
                If Not _Target.Text.Length = 0 Then
                    _Target.Text = _Target.Text.Remove(_Target.Text.Length - 1)
                End If
            Case Else
                If Shift Then
                    _Target.Text &= Upper(Pressed)
                Else
                    _Target.Text &= Lower(Pressed)
                End If
        End Select
    End Sub
End Class