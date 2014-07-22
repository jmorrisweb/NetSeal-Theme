Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Windows.Forms
<DefaultEvent("SelectedIndexChanged")> _
Public Class NSPaginator
    Inherits Control
    Public Event SelectedIndexChanged(sender As Object, e As EventArgs)
    Private TextBitmap As Bitmap
    Private TextGraphics As Graphics
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)
        Size = New Size(202, 26)
        TextBitmap = New Bitmap(1, 1)
        TextGraphics = Graphics.FromImage(TextBitmap)
        InvalidateItems()
        B1 = New SolidBrush(Color.FromArgb(50, 50, 50))
        B2 = New SolidBrush(Color.FromArgb(55, 55, 55))
        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(55, 55, 55))
        P3 = New Pen(Color.FromArgb(65, 65, 65))
    End Sub
    Private _SelectedIndex As Integer
    Public Property SelectedIndex() As Integer
        Get
            Return _SelectedIndex
        End Get
        Set(ByVal value As Integer)
            _SelectedIndex = Math.Max(Math.Min(value, MaximumIndex), 0)
            Invalidate()
        End Set
    End Property
    Private _NumberOfPages As Integer
    Public Property NumberOfPages() As Integer
        Get
            Return _NumberOfPages
        End Get
        Set(ByVal value As Integer)
            _NumberOfPages = value
            _SelectedIndex = Math.Max(Math.Min(_SelectedIndex, MaximumIndex), 0)
            Invalidate()
        End Set
    End Property
    Public ReadOnly Property MaximumIndex As Integer
        Get
            Return NumberOfPages - 1
        End Get
    End Property
    Private ItemWidth As Integer
    Public Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(value As Font)
            MyBase.Font = value
            InvalidateItems()
            Invalidate()
        End Set
    End Property
    Private Sub InvalidateItems()
        Dim S As Size = TextGraphics.MeasureString("000 ..", Font).ToSize()
        ItemWidth = S.Width + 10
    End Sub
    Private GP1, GP2 As GraphicsPath
    Private R1 As Rectangle
    Private SZ1 As Size
    Private PT1 As Point
    Private P1, P2, P3 As Pen
    Private B1, B2 As SolidBrush
    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias
        Dim LeftEllipse, RightEllipse As Boolean
        If _SelectedIndex < 4 Then
            For I As Integer = 0 To Math.Min(MaximumIndex, 4)
                RightEllipse = (I = 4) AndAlso (MaximumIndex > 4)
                DrawBox(I * ItemWidth, I, False, RightEllipse)
            Next
        ElseIf _SelectedIndex > 3 AndAlso _SelectedIndex < (MaximumIndex - 3) Then
            For I As Integer = 0 To 4
                LeftEllipse = (I = 0)
                RightEllipse = (I = 4)
                DrawBox(I * ItemWidth, _SelectedIndex + I - 2, LeftEllipse, RightEllipse)
            Next
        Else
            For I As Integer = 0 To 4
                LeftEllipse = (I = 0) AndAlso (MaximumIndex > 4)
                DrawBox(I * ItemWidth, MaximumIndex - (4 - I), LeftEllipse, False)
            Next
        End If
    End Sub
    Private Sub DrawBox(x As Integer, index As Integer, leftEllipse As Boolean, rightEllipse As Boolean)
        R1 = New Rectangle(x, 0, ItemWidth - 4, Height - 1)
        GP1 = CreateRound(R1, 7)
        GP2 = CreateRound(R1.X + 1, R1.Y + 1, R1.Width - 2, R1.Height - 2, 7)
        Dim T As String = CStr(index + 1)
        If leftEllipse Then T = ".. " & T
        If rightEllipse Then T = T & " .."
        SZ1 = G.MeasureString(T, Font).ToSize()
        PT1 = New Point(R1.X + (R1.Width \ 2 - SZ1.Width \ 2), R1.Y + (R1.Height \ 2 - SZ1.Height \ 2))
        If index = _SelectedIndex Then
            G.FillPath(B1, GP1)
            Dim F As New Font(Font, FontStyle.Underline)
            G.DrawString(T, F, Brushes.Black, PT1.X + 1, PT1.Y + 1)
            G.DrawString(T, F, Brushes.White, PT1)
            F.Dispose()
            G.DrawPath(P1, GP2)
            G.DrawPath(P2, GP1)
        Else
            G.FillPath(B2, GP1)
            G.DrawString(T, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1)
            G.DrawString(T, Font, Brushes.White, PT1)
            G.DrawPath(P3, GP2)
            G.DrawPath(P1, GP1)
        End If
    End Sub
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim NewIndex As Integer
            Dim OldIndex As Integer = _SelectedIndex
            If _SelectedIndex < 4 Then
                NewIndex = (e.X \ ItemWidth)
            ElseIf _SelectedIndex > 3 AndAlso _SelectedIndex < (MaximumIndex - 3) Then
                NewIndex = (e.X \ ItemWidth)
                Select Case NewIndex
                    Case 2
                        NewIndex = OldIndex
                    Case Is < 2
                        NewIndex = OldIndex - (2 - NewIndex)
                    Case Is > 2
                        NewIndex = OldIndex + (NewIndex - 2)
                End Select
            Else
                NewIndex = MaximumIndex - (4 - (e.X \ ItemWidth))
            End If

            If (NewIndex < _NumberOfPages) AndAlso (Not NewIndex = OldIndex) Then
                SelectedIndex = NewIndex
                RaiseEvent SelectedIndexChanged(Me, Nothing)
            End If
        End If
        MyBase.OnMouseDown(e)
    End Sub
End Class