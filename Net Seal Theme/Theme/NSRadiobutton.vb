Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
<DefaultEvent("CheckedChanged")> _
Public Class NSRadioButton
    Inherits Control
    Event CheckedChanged(sender As Object)
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        P1 = New Pen(Color.FromArgb(55, 55, 55))
        P2 = New Pen(Color.FromArgb(35, 35, 35))
    End Sub
    Private _Checked As Boolean
    Public Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value

            If _Checked Then
                InvalidateParent()
            End If

            RaiseEvent CheckedChanged(Me)
            Invalidate()
        End Set
    End Property
    Private Sub InvalidateParent()
        If Parent Is Nothing Then Return
        For Each C As Control In Parent.Controls
            If Not (C Is Me) AndAlso (TypeOf C Is NSRadioButton) Then
                DirectCast(C, NSRadioButton).Checked = False
            End If
        Next
    End Sub
    Private GP1 As GraphicsPath
    Private SZ1 As SizeF
    Private PT1 As PointF
    Private P1, P2 As Pen
    Private PB1 As PathGradientBrush
    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias
        GP1 = New GraphicsPath
        GP1.AddEllipse(0, 2, Height - 5, Height - 5)
        PB1 = New PathGradientBrush(GP1)
        PB1.CenterColor = Color.FromArgb(50, 50, 50)
        PB1.SurroundColors = {Color.FromArgb(45, 45, 45)}
        PB1.FocusScales = New PointF(0.3F, 0.3F)
        G.FillPath(PB1, GP1)
        G.DrawEllipse(P1, 0, 2, Height - 5, Height - 5)
        G.DrawEllipse(P2, 1, 3, Height - 7, Height - 7)
        If _Checked Then
            G.FillEllipse(Brushes.Black, 6, 8, Height - 15, Height - 15)
            G.FillEllipse(Brushes.White, 5, 7, Height - 15, Height - 15)
        End If
        SZ1 = G.MeasureString(Text, Font)
        PT1 = New PointF(Height - 3, Height \ 2 - SZ1.Height / 2)
        G.DrawString(Text, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1)
        G.DrawString(Text, Font, Brushes.White, PT1)
    End Sub
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Checked = True
        MyBase.OnMouseDown(e)
    End Sub
End Class