Imports Themebase
Imports System.Drawing
Imports System.Windows.Forms

Public Class NSTheme
    Inherits ThemeContainer
    Private _AccentOffset As Integer = 42
    Public Property AccentOffset() As Integer
        Get
            Return _AccentOffset
        End Get
        Set(ByVal value As Integer)
            _AccentOffset = value
            Invalidate()
        End Set
    End Property
    Sub New()
        Header = 30
        BackColor = Color.FromArgb(50, 50, 50)
        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(60, 60, 60))
        B1 = New SolidBrush(Color.FromArgb(50, 50, 50))
    End Sub
    Protected Overrides Sub ColorHook()
    End Sub
    Private R1 As Rectangle
    Private P1, P2 As Pen
    Private B1 As SolidBrush
    Private Pad As Integer
    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
        DrawBorders(P2, 1)
        G.DrawLine(P1, 0, 26, Width, 26)
        G.DrawLine(P2, 0, 25, Width, 25)
        Pad = Math.Max(Measure().Width + 20, 80)
        R1 = New Rectangle(Pad, 17, Width - (Pad * 2) + _AccentOffset, 8)
        G.DrawRectangle(P2, R1)
        G.DrawRectangle(P1, R1.X + 1, R1.Y + 1, R1.Width - 2, R1.Height)
        G.DrawLine(P1, 0, 29, Width, 29)
        G.DrawLine(P2, 0, 30, Width, 30)
        DrawText(Brushes.Black, HorizontalAlignment.Left, 8, 1)
        DrawText(Brushes.White, HorizontalAlignment.Left, 7, 0)
        G.FillRectangle(B1, 0, 27, Width, 2)
        DrawBorders(Pens.Black)
    End Sub
End Class