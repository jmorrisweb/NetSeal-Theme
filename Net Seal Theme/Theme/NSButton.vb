Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Public Class NSButton
    Inherits Control
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)
        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(65, 65, 65))
    End Sub
    Private IsMouseDown As Boolean
    Private GP1, GP2 As GraphicsPath
    Private SZ1 As SizeF
    Private PT1 As PointF
    Private P1, P2 As Pen
    Private PB1 As PathGradientBrush
    Private GB1 As LinearGradientBrush
    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias
        GP1 = CreateRound(0, 0, Width - 1, Height - 1, 7)
        GP2 = CreateRound(1, 1, Width - 3, Height - 3, 7)
        If IsMouseDown Then
            PB1 = New PathGradientBrush(GP1)
            PB1.CenterColor = Color.FromArgb(60, 60, 60)
            PB1.SurroundColors = {Color.FromArgb(55, 55, 55)}
            PB1.FocusScales = New PointF(0.8F, 0.5F)
            G.FillPath(PB1, GP1)
        Else
            GB1 = New LinearGradientBrush(ClientRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0F)
            G.FillPath(GB1, GP1)
        End If
        G.DrawPath(P1, GP1)
        G.DrawPath(P2, GP2)
        SZ1 = G.MeasureString(Text, Font)
        PT1 = New PointF(5, Height \ 2 - SZ1.Height / 2)
        If IsMouseDown Then
            PT1.X += 1.0F
            PT1.Y += 1.0F
        End If
        G.DrawString(Text, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1)
        G.DrawString(Text, Font, Brushes.White, PT1)
    End Sub
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        IsMouseDown = True
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        IsMouseDown = False
        Invalidate()
    End Sub
End Class