Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Drawing.Drawing2D
<DefaultEvent("CheckedChanged")> _
Public Class NSCheckBox
    Inherits Control
    Event CheckedChanged(sender As Object)
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)
        P11 = New Pen(Color.FromArgb(55, 55, 55))
        P22 = New Pen(Color.FromArgb(35, 35, 35))
        P3 = New Pen(Color.Black, 2.0F)
        P4 = New Pen(Color.White, 2.0F)
    End Sub
    Private _Checked As Boolean
    Public Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            RaiseEvent CheckedChanged(Me)
            Invalidate()
        End Set
    End Property
    Private GP1, GP2 As GraphicsPath
    Private SZ1 As SizeF
    Private PT1 As PointF
    Private P11, P22, P3, P4 As Pen
    Private PB1 As PathGradientBrush
    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias
        GP1 = CreateRound(0, 2, Height - 5, Height - 5, 5)
        GP2 = CreateRound(1, 3, Height - 7, Height - 7, 5)
        PB1 = New PathGradientBrush(GP1)
        PB1.CenterColor = Color.FromArgb(50, 50, 50)
        PB1.SurroundColors = {Color.FromArgb(45, 45, 45)}
        PB1.FocusScales = New PointF(0.3F, 0.3F)
        G.FillPath(PB1, GP1)
        G.DrawPath(P11, GP1)
        G.DrawPath(P22, GP2)
        If _Checked Then
            G.DrawLine(P3, 5, Height - 9, 8, Height - 7)
            G.DrawLine(P3, 7, Height - 7, Height - 8, 7)
            G.DrawLine(P4, 4, Height - 10, 7, Height - 8)
            G.DrawLine(P4, 6, Height - 8, Height - 9, 6)
        End If
        SZ1 = G.MeasureString(Text, Font)
        PT1 = New PointF(Height - 3, Height \ 2 - SZ1.Height / 2)
        G.DrawString(Text, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1)
        G.DrawString(Text, Font, Brushes.White, PT1)
    End Sub
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Checked = Not Checked
    End Sub
End Class