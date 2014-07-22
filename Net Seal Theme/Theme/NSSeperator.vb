Imports System.Drawing
Imports System.Windows.Forms
Public Class NSSeperator
    Inherits Control
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)
        Height = 10
        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(55, 55, 55))
    End Sub
    Private P1, P2 As Pen
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        G = e.Graphics
        G.Clear(BackColor)
        G.DrawLine(P1, 0, 5, Width, 5)
        G.DrawLine(P2, 0, 6, Width, 6)
    End Sub
End Class