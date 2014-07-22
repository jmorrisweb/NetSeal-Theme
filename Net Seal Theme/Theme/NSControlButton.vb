Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Public Class NSControlButton
    Inherits Control
    Enum Button As Byte
        None = 0
        Minimize = 1
        MaximizeRestore = 2
        Close = 3
    End Enum
    Private _ControlButton As Button = Button.Close
    Public Property ControlButton() As Button
        Get
            Return _ControlButton
        End Get
        Set(ByVal value As Button)
            _ControlButton = value
            Invalidate()
        End Set
    End Property
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)
        Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Width = 18
        Height = 20
        MinimumSize = Size
        MaximumSize = Size
        Margin = New Padding(0)
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        G = e.Graphics
        G.Clear(BackColor)
        Select Case _ControlButton
            Case Button.Minimize
                DrawMinimize(3, 10)
            Case Button.MaximizeRestore
                If FindForm().WindowState = FormWindowState.Normal Then
                    DrawMaximize(3, 5)
                Else
                    DrawRestore(3, 4)
                End If
            Case Button.Close
                DrawClose(4, 5)
        End Select
    End Sub
    Private Sub DrawMinimize(ByVal x As Integer, ByVal y As Integer)
        G.FillRectangle(Brushes.White, x, y, 12, 5)
        G.DrawRectangle(Pens.Black, x, y, 11, 4)
    End Sub
    Private Sub DrawMaximize(ByVal x As Integer, ByVal y As Integer)
        G.DrawRectangle(New Pen(Color.White, 2), x + 2, y + 2, 8, 6)
        G.DrawRectangle(Pens.Black, x, y, 11, 9)
        G.DrawRectangle(Pens.Black, x + 3, y + 3, 5, 3)
    End Sub
    Private Sub DrawRestore(ByVal x As Integer, ByVal y As Integer)
        G.FillRectangle(Brushes.White, x + 3, y + 1, 8, 4)
        G.FillRectangle(Brushes.White, x + 7, y + 5, 4, 4)
        G.DrawRectangle(Pens.Black, x + 2, y + 0, 9, 9)
        G.FillRectangle(Brushes.White, x + 1, y + 3, 2, 6)
        G.FillRectangle(Brushes.White, x + 1, y + 9, 8, 2)
        G.DrawRectangle(Pens.Black, x, y + 2, 9, 9)
        G.DrawRectangle(Pens.Black, x + 3, y + 5, 3, 3)
    End Sub
    Private ClosePath As GraphicsPath
    Private Sub DrawClose(ByVal x As Integer, ByVal y As Integer)
        If ClosePath Is Nothing Then
            ClosePath = New GraphicsPath
            ClosePath.AddLine(x + 1, y, x + 3, y)
            ClosePath.AddLine(x + 5, y + 2, x + 7, y)
            ClosePath.AddLine(x + 9, y, x + 10, y + 1)
            ClosePath.AddLine(x + 7, y + 4, x + 7, y + 5)
            ClosePath.AddLine(x + 10, y + 8, x + 9, y + 9)
            ClosePath.AddLine(x + 7, y + 9, x + 5, y + 7)
            ClosePath.AddLine(x + 3, y + 9, x + 1, y + 9)
            ClosePath.AddLine(x + 0, y + 8, x + 3, y + 5)
            ClosePath.AddLine(x + 3, y + 4, x + 0, y + 1)
        End If
        G.FillPath(Brushes.White, ClosePath)
        G.DrawPath(Pens.Black, ClosePath)
    End Sub
    Protected Overrides Sub OnMouseClick(ByVal e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim F As Form = FindForm()
            Select Case _ControlButton
                Case Button.Minimize
                    F.WindowState = FormWindowState.Minimized
                Case Button.MaximizeRestore
                    If F.WindowState = FormWindowState.Normal Then
                        F.WindowState = FormWindowState.Maximized
                    Else
                        F.WindowState = FormWindowState.Normal
                    End If
                Case Button.Close
                    F.Close()
            End Select
        End If
        Invalidate()
        MyBase.OnMouseClick(e)
    End Sub
End Class