Imports System.Drawing
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Drawing.Text
<DefaultEvent("CheckedChanged")> _
Public Class NSOnOffBox
    Inherits Control
    Event CheckedChanged(sender As Object)
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)
        P1 = New Pen(Color.FromArgb(55, 55, 55))
        P2 = New Pen(Color.FromArgb(35, 35, 35))
        P3 = New Pen(Color.FromArgb(65, 65, 65))
        B1 = New SolidBrush(Color.FromArgb(35, 35, 35))
        B2 = New SolidBrush(Color.FromArgb(85, 85, 85))
        B3 = New SolidBrush(Color.FromArgb(65, 65, 65))
        B4 = New SolidBrush(Color.FromArgb(205, 150, 0))
        B5 = New SolidBrush(Color.FromArgb(40, 40, 40))
        SF1 = New StringFormat()
        SF1.LineAlignment = StringAlignment.Center
        SF1.Alignment = StringAlignment.Near
        SF2 = New StringFormat()
        SF2.LineAlignment = StringAlignment.Center
        SF2.Alignment = StringAlignment.Far
        Size = New Size(56, 24)
        MinimumSize = Size
        MaximumSize = Size
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
    Private GP1, GP2, GP3, GP4 As GraphicsPath
    Private P1, P2, P3 As Pen
    Private B1, B2, B3, B4, B5 As SolidBrush
    Private PB1 As PathGradientBrush
    Private GB1 As LinearGradientBrush
    Private R1, R2, R3 As Rectangle
    Private SF1, SF2 As StringFormat
    Private Offset As Integer
    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias
        GP1 = CreateRound(0, 0, Width - 1, Height - 1, 7)
        GP2 = CreateRound(1, 1, Width - 3, Height - 3, 7)
        PB1 = New PathGradientBrush(GP1)
        PB1.CenterColor = Color.FromArgb(50, 50, 50)
        PB1.SurroundColors = {Color.FromArgb(45, 45, 45)}
        PB1.FocusScales = New PointF(0.3F, 0.3F)
        G.FillPath(PB1, GP1)
        G.DrawPath(P1, GP1)
        G.DrawPath(P2, GP2)
        R1 = New Rectangle(5, 0, Width - 10, Height + 2)
        R2 = New Rectangle(6, 1, Width - 10, Height + 2)
        R3 = New Rectangle(1, 1, (Width \ 2) - 1, Height - 3)
        If _Checked Then
            G.DrawString("On", Font, Brushes.Black, R2, SF1)
            G.DrawString("On", Font, Brushes.White, R1, SF1)
            R3.X += (Width \ 2) - 1
        Else
            G.DrawString("Off", Font, B1, R2, SF2)
            G.DrawString("Off", Font, B2, R1, SF2)
        End If
        GP3 = CreateRound(R3, 7)
        GP4 = CreateRound(R3.X + 1, R3.Y + 1, R3.Width - 2, R3.Height - 2, 7)
        GB1 = New LinearGradientBrush(ClientRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0F)
        G.FillPath(GB1, GP3)
        G.DrawPath(P2, GP3)
        G.DrawPath(P3, GP4)
        Offset = R3.X + (R3.Width \ 2) - 3
        For I As Integer = 0 To 1
            If _Checked Then
                G.FillRectangle(B1, Offset + (I * 5), 7, 2, Height - 14)
            Else
                G.FillRectangle(B3, Offset + (I * 5), 7, 2, Height - 14)
            End If
            G.SmoothingMode = SmoothingMode.None
            If _Checked Then
                G.FillRectangle(B4, Offset + (I * 5), 7, 2, Height - 14)
            Else
                G.FillRectangle(B5, Offset + (I * 5), 7, 2, Height - 14)
            End If
            G.SmoothingMode = SmoothingMode.AntiAlias
        Next
    End Sub
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Checked = Not Checked
        MyBase.OnMouseDown(e)
    End Sub
End Class