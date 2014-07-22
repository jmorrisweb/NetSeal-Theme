Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Public Class NSComboBox
    Inherits ComboBox
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)
        DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        DropDownStyle = ComboBoxStyle.DropDownList
        BackColor = Color.FromArgb(50, 50, 50)
        ForeColor = Color.White
        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.White, 2.0F)
        P3 = New Pen(Brushes.Black, 2.0F)
        P4 = New Pen(Color.FromArgb(65, 65, 65))
        B1 = New SolidBrush(Color.FromArgb(65, 65, 65))
        B2 = New SolidBrush(Color.FromArgb(55, 55, 55))
    End Sub
    Private GP1, GP2 As GraphicsPath
    Private SZ1 As SizeF
    Private PT1 As PointF
    Private P1, P2, P3, P4 As Pen
    Private B1, B2 As SolidBrush
    Private GB1 As LinearGradientBrush
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias
        GP1 = CreateRound(0, 0, Width - 1, Height - 1, 7)
        GP2 = CreateRound(1, 1, Width - 3, Height - 3, 7)
        GB1 = New LinearGradientBrush(ClientRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0F)
        G.SetClip(GP1)
        G.FillRectangle(GB1, ClientRectangle)
        G.ResetClip()
        G.DrawPath(P1, GP1)
        G.DrawPath(P4, GP2)
        SZ1 = G.MeasureString(Text, Font)
        PT1 = New PointF(5, Height \ 2 - SZ1.Height / 2)
        G.DrawString(Text, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1)
        G.DrawString(Text, Font, Brushes.White, PT1)
        G.DrawLine(P3, Width - 15, 10, Width - 11, 13)
        G.DrawLine(P3, Width - 7, 10, Width - 11, 13)
        G.DrawLine(Pens.Black, Width - 11, 13, Width - 11, 14)
        G.DrawLine(P2, Width - 16, 9, Width - 12, 12)
        G.DrawLine(P2, Width - 8, 9, Width - 12, 12)
        G.DrawLine(Pens.White, Width - 12, 12, Width - 12, 13)
        G.DrawLine(P1, Width - 22, 0, Width - 22, Height)
        G.DrawLine(P4, Width - 23, 1, Width - 23, Height - 2)
        G.DrawLine(P4, Width - 21, 1, Width - 21, Height - 2)
    End Sub
    Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            e.Graphics.FillRectangle(B1, e.Bounds)
        Else
            e.Graphics.FillRectangle(B2, e.Bounds)
        End If
        If Not e.Index = -1 Then
            e.Graphics.DrawString(GetItemText(Items(e.Index)), e.Font, Brushes.White, e.Bounds)
        End If
    End Sub
End Class