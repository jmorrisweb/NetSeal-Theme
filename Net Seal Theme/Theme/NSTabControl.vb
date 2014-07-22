Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Public Class NSTabControl
    Inherits TabControl
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)
        SizeMode = TabSizeMode.Fixed
        Alignment = TabAlignment.Left
        ItemSize = New Size(28, 115)
        DrawMode = TabDrawMode.OwnerDrawFixed
        P1 = New Pen(Color.FromArgb(55, 55, 55))
        P2 = New Pen(Color.FromArgb(35, 35, 35))
        P3 = New Pen(Color.FromArgb(45, 45, 45), 2)
        B1 = New SolidBrush(Color.FromArgb(50, 50, 50))
        B2 = New SolidBrush(Color.FromArgb(35, 35, 35))
        B3 = New SolidBrush(Color.FromArgb(205, 150, 0))
        B4 = New SolidBrush(Color.FromArgb(65, 65, 65))
        SF1 = New StringFormat()
        SF1.LineAlignment = StringAlignment.Center
    End Sub
    Protected Overrides Sub OnControlAdded(e As ControlEventArgs)
        If TypeOf e.Control Is TabPage Then
            e.Control.BackColor = Color.FromArgb(50, 50, 50)
        End If
        MyBase.OnControlAdded(e)
    End Sub
    Private GP1, GP2, GP3, GP4 As GraphicsPath
    Private R1, R2 As Rectangle
    Private P1, P2, P3 As Pen
    Private B1, B2, B3, B4 As SolidBrush
    Private PB1 As PathGradientBrush
    Private TP1 As TabPage
    Private SF1 As StringFormat
    Private Offset As Integer
    Private ItemHeight As Integer
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        G.Clear(Color.FromArgb(50, 50, 50))
        G.SmoothingMode = SmoothingMode.AntiAlias
        ItemHeight = ItemSize.Height + 2
        GP1 = CreateRound(0, 0, ItemHeight + 3, Height - 1, 7)
        GP2 = CreateRound(1, 1, ItemHeight + 3, Height - 3, 7)
        PB1 = New PathGradientBrush(GP1)
        PB1.CenterColor = Color.FromArgb(50, 50, 50)
        PB1.SurroundColors = {Color.FromArgb(45, 45, 45)}
        PB1.FocusScales = New PointF(0.8F, 0.95F)
        G.FillPath(PB1, GP1)
        G.DrawPath(P1, GP1)
        G.DrawPath(P2, GP2)
        For I As Integer = 0 To TabCount - 1
            R1 = GetTabRect(I)
            R1.Y += 2
            R1.Height -= 3
            R1.Width += 1
            R1.X -= 1
            TP1 = TabPages(I)
            Offset = 0
            If SelectedIndex = I Then
                G.FillRectangle(B1, R1)
                For J As Integer = 0 To 1
                    G.FillRectangle(B2, R1.X + 5 + (J * 5), R1.Y + 6, 2, R1.Height - 9)
                    G.SmoothingMode = SmoothingMode.None
                    G.FillRectangle(B3, R1.X + 5 + (J * 5), R1.Y + 5, 2, R1.Height - 9)
                    G.SmoothingMode = SmoothingMode.AntiAlias
                    Offset += 5
                Next
                G.DrawRectangle(P3, R1.X + 1, R1.Y - 1, R1.Width, R1.Height + 2)
                G.DrawRectangle(P1, R1.X + 1, R1.Y + 1, R1.Width - 2, R1.Height - 2)
                G.DrawRectangle(P2, R1)
            Else
                For J As Integer = 0 To 1
                    G.FillRectangle(B2, R1.X + 5 + (J * 5), R1.Y + 6, 2, R1.Height - 9)
                    G.SmoothingMode = SmoothingMode.None
                    G.FillRectangle(B4, R1.X + 5 + (J * 5), R1.Y + 5, 2, R1.Height - 9)
                    G.SmoothingMode = SmoothingMode.AntiAlias
                    Offset += 5
                Next
            End If
            R1.X += 5 + Offset
            R2 = R1
            R2.Y += 1
            R2.X += 1
            G.DrawString(TP1.Text, Font, Brushes.Black, R2, SF1)
            G.DrawString(TP1.Text, Font, Brushes.White, R1, SF1)
        Next
        GP3 = CreateRound(ItemHeight, 0, Width - ItemHeight - 1, Height - 1, 7)
        GP4 = CreateRound(ItemHeight + 1, 1, Width - ItemHeight - 3, Height - 3, 7)
        G.DrawPath(P2, GP3)
        G.DrawPath(P1, GP4)
    End Sub
End Class