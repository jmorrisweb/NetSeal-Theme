Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Text
Public Class NSLabel
    Inherits Control
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)
        Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        B1 = New SolidBrush(Color.FromArgb(205, 150, 0))
    End Sub
    Private _Value1 As String = "NET"
    Public Property Value1() As String
        Get
            Return _Value1
        End Get
        Set(ByVal value As String)
            _Value1 = value
            Invalidate()
        End Set
    End Property
    Private _Value2 As String = "SEAL"
    Public Property Value2() As String
        Get
            Return _Value2
        End Get
        Set(ByVal value As String)
            _Value2 = value
            Invalidate()
        End Set
    End Property
    Private B1 As SolidBrush
    Private PT1, PT2 As PointF
    Private SZ1, SZ2 As SizeF
    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        G.Clear(BackColor)
        SZ1 = G.MeasureString(Value1, Font, Width, StringFormat.GenericTypographic)
        SZ2 = G.MeasureString(Value2, Font, Width, StringFormat.GenericTypographic)
        PT1 = New PointF(0, Height \ 2 - SZ1.Height / 2)
        PT2 = New PointF(SZ1.Width + 1, Height \ 2 - SZ1.Height / 2)
        G.DrawString(Value1, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1)
        G.DrawString(Value1, Font, Brushes.White, PT1)
        G.DrawString(Value2, Font, Brushes.Black, PT2.X + 1, PT2.Y + 1)
        G.DrawString(Value2, Font, B1, PT2)
    End Sub
End Class