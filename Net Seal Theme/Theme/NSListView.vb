Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing.Design

Public Class NSListView
    Inherits Control
    Property SmallImageList As ImageList
    Public Class NSListViewCollection
        Inherits List(Of NSListViewItem)
        Private Parent As NSListView
        Public Sub New(Parent As NSListView)
            Me.Parent = Parent
        End Sub
        Public Shadows Sub Add(Item As String)
            Dim TempAdd_ As New NSListViewItem
            If Me.Parent.SmallImageList IsNot Nothing Then
                TempAdd_.ImageList_ = Me.Parent.SmallImageList
            End If
            TempAdd_.Text = Item
            MyBase.Add(TempAdd_)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub Add(Item As NSListViewItem)
                If Me.Parent.SmallImageList IsNot Nothing Then
                    Item.ImageList_ = Me.Parent.SmallImageList
                End If
                MyBase.Add(Item)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub AddRange(Range As List(Of NSListViewItem))
            If Me.Parent.SmallImageList IsNot Nothing Then
                For Each NSListViewItem In Range
                    NSListViewItem.ImageList_ = Me.Parent.SmallImageList
                Next
            End If
            MyBase.AddRange(Range)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub Clear()
            MyBase.Clear()
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub Remove(Item As NSListViewItem)
            MyBase.Remove(Item)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub RemoveAt(Index As Integer)
            MyBase.RemoveAt(Index)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub RemoveAll(Predicate As System.Predicate(Of NSListViewItem))
            MyBase.RemoveAll(Predicate)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub RemoveRange(Index As Integer, Count As Integer)
            MyBase.RemoveRange(Index, Count)
            Parent.InvalidateScroll()
        End Sub
    End Class

    Public Class NSListViewItem
        'Private Fields
        Private ImageKey_ As String = String.Empty
        Private ImageIndex_ As Integer = -1
        'Friend Fields
        Friend ImageList_ As ImageList
        <BrowsableAttribute(False)> _
        Public ReadOnly Property ImageList As ImageList
            Get
                Return ImageList_
            End Get
        End Property

        <TypeConverterAttribute(GetType(ImageKeyConverter))> _
        Public Property ImageKey As String
            Get
                Return ImageKey_
            End Get
            Set(value As String)
                If value <> String.Empty Then
                    ImageIndex = -1
                End If
                ImageKey_ = value
            End Set
        End Property
        <TypeConverterAttribute(GetType(ImageIndexConverter))> _
        Public Property ImageIndex As Integer
            Get
                Return ImageIndex_
            End Get
            Set(value As Integer)
                If value <> -1 Then
                    ImageKey_ = String.Empty
                End If
                ImageIndex_ = value
            End Set
        End Property
        Property Text As String
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Property SubItems As New List(Of NSListViewSubItem)

        Protected UniqueId As Guid

        Sub New()
            UniqueId = Guid.NewGuid()
        End Sub
        Friend Sub New(Imagelist As ImageList)
            UniqueId = Guid.NewGuid()
            ImageList_ = Imagelist
        End Sub

        Public Overrides Function ToString() As String
            Return Text
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If TypeOf obj Is NSListViewItem Then
                Return (DirectCast(obj, NSListViewItem).UniqueId = UniqueId)
            End If

            Return False
        End Function

    End Class

    Public Class NSListViewSubItem
        Property Text As String

        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class

    Public Class NSListViewColumnHeader
        Property Text As String
        Property Width As Integer = 60

        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class

    Private _Items As New NSListViewCollection(Me)

    ', Editor(GetType(BorderStyleEditor), GetType(UITypeEditor))
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public ReadOnly Property Items As NSListViewCollection
        Get
            Return _Items
        End Get
    End Property

    Private _SelectedItems As New List(Of NSListViewItem)
    Public ReadOnly Property SelectedItems() As NSListViewItem()
        Get
            Return _SelectedItems.ToArray()
        End Get
    End Property

    Private _Columns As New List(Of NSListViewColumnHeader)
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property Columns() As NSListViewColumnHeader()
        Get
            Return _Columns.ToArray()
        End Get
        Set(ByVal value As NSListViewColumnHeader())
            _Columns = New List(Of NSListViewColumnHeader)(value)
            InvalidateColumns()
        End Set
    End Property

    Private _MultiSelect As Boolean = True
    Public Property MultiSelect() As Boolean
        Get
            Return _MultiSelect
        End Get
        Set(ByVal value As Boolean)
            _MultiSelect = value

            If _SelectedItems.Count > 1 Then
                _SelectedItems.RemoveRange(1, _SelectedItems.Count - 1)
            End If

            Invalidate()
        End Set
    End Property

    Private ItemHeight As Integer = 24
    Public Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(value As Font)
            MyBase.Font = value
            InvalidateLayout()
        End Set
    End Property

    Private VS As NSVScrollBar

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, True)

        P1 = New Pen(Color.FromArgb(55, 55, 55))
        P2 = New Pen(Color.FromArgb(35, 35, 35))
        P3 = New Pen(Color.FromArgb(65, 65, 65))

        B1 = New SolidBrush(Color.FromArgb(62, 62, 62))
        B2 = New SolidBrush(Color.FromArgb(65, 65, 65))
        B3 = New SolidBrush(Color.FromArgb(47, 47, 47))
        B4 = New SolidBrush(Color.FromArgb(50, 50, 50))

        VS = New NSVScrollBar
        VS.SmallChange = ItemHeight
        VS.LargeChange = ItemHeight

        AddHandler VS.Scroll, AddressOf HandleScroll
        AddHandler VS.MouseDown, AddressOf VS_MouseDown
        Controls.Add(VS)

        InvalidateLayout()
    End Sub

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        InvalidateLayout()
        MyBase.OnSizeChanged(e)
    End Sub

    Private Sub HandleScroll(sender As Object)
        Invalidate()
    End Sub

    Private Sub InvalidateScroll()
        Invalidate()
    End Sub

    Private Sub InvalidateLayout()
        VS.Location = New Point(Width - VS.Width - 1, 1)
        VS.Size = New Size(18, Height - 2)

        Invalidate()
    End Sub

    Private ColumnOffsets As Integer()
    Private Sub InvalidateColumns()
        Dim Width As Integer = 3
        ColumnOffsets = New Integer(_Columns.Count - 1) {}

        For I As Integer = 0 To _Columns.Count - 1
            ColumnOffsets(I) = Width
            Width += Columns(I).Width
        Next

        Invalidate()
    End Sub

    Private Sub VS_MouseDown(sender As Object, e As MouseEventArgs)
        Focus()
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Focus()

        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim Offset As Integer = CInt(VS.Percent * (VS.Maximum - (Height - (ItemHeight * 2))))
            Dim Index As Integer = ((e.Y + Offset - ItemHeight) \ ItemHeight)

            If Index > _Items.Count - 1 Then Index = -1

            If Not Index = -1 Then
                'TODO: Handle Shift key

                If ModifierKeys = Keys.Control AndAlso _MultiSelect Then
                    If _SelectedItems.Contains(_Items(Index)) Then
                        _SelectedItems.Remove(_Items(Index))
                    Else
                        _SelectedItems.Add(_Items(Index))
                    End If
                Else
                    _SelectedItems.Clear()
                    _SelectedItems.Add(_Items(Index))
                End If
            End If

            Invalidate()
        End If

        MyBase.OnMouseDown(e)
    End Sub

    Private P1, P2, P3 As Pen
    Private B1, B2, B3, B4 As SolidBrush
    Private GB1 As LinearGradientBrush

    'I am so sorry you have to witness this. I tried warning you. ;.;

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim TextHeight As Integer = CInt(Graphics.FromHwnd(Handle).MeasureString("@", Font).Height) + 6
        If SmallImageList IsNot Nothing Then
            If SmallImageList.ImageSize.Height >= TextHeight Then
                ItemHeight = SmallImageList.ImageSize.Height + 7 '+1 over 6 to vertically center image
            Else
                ItemHeight = TextHeight
            End If
        Else
            ItemHeight = TextHeight
        End If
        If VS IsNot Nothing Then
            If VS.Maximum <> (_Items.Count * ItemHeight) Then
                VS.Maximum = (_Items.Count * ItemHeight)
            End If
            If VS.SmallChange <> ItemHeight Then
                VS.SmallChange = ItemHeight
            End If
            If VS.LargeChange <> ItemHeight Then
                VS.LargeChange = ItemHeight
            End If
        End If
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        G.Clear(BackColor)

        Dim X, Y, Y2, X2 As Integer
        Dim H As Single

        G.DrawRectangle(P1, 1, 1, Width - 3, Height - 3)

        Dim R1 As Rectangle
        Dim CI As NSListViewItem

        Dim Offset As Integer = CInt(VS.Percent * (VS.Maximum - (Height - (ItemHeight * 2))))

        Dim StartIndex As Integer
        If Offset = 0 Then StartIndex = 0 Else StartIndex = (Offset \ ItemHeight)

        Dim EndIndex As Integer = Math.Min(StartIndex + (Height \ ItemHeight), _Items.Count - 1)

        For I As Integer = StartIndex To EndIndex
            CI = Items(I)

            R1 = New Rectangle(0, ItemHeight + (I * ItemHeight) + 1 - Offset, Width, ItemHeight - 1)

            H = G.MeasureString(CI.Text, Font).Height
            Y = R1.Y + CInt((ItemHeight / 2) - (H / 2))
            X2 = 9
            If _SelectedItems.Contains(CI) Then
                If I Mod 2 = 0 Then
                    G.FillRectangle(B1, R1)
                Else
                    G.FillRectangle(B2, R1)
                End If
            Else
                If I Mod 2 = 0 Then
                    G.FillRectangle(B3, R1)
                Else
                    G.FillRectangle(B4, R1)
                End If
            End If

            G.DrawLine(P2, 0, R1.Bottom, Width, R1.Bottom)

            If Columns.Length > 0 Then
                R1.Width = Columns(0).Width
                G.SetClip(R1)
            End If

            If CI.ImageList IsNot Nothing And CI.ImageList Is Me.SmallImageList Then
                Y2 = R1.Y + CInt((ItemHeight / 2) - (CI.ImageList.ImageSize.Height / 2)) - 1
                If CI.ImageIndex <> -1 Then
                    G.DrawImage(CI.ImageList.Images(CI.ImageIndex), New Point(3, Y2))
                    X2 = CI.ImageList.ImageSize.Width + 6
                End If
                If CI.ImageKey <> String.Empty Then
                    G.DrawImage(CI.ImageList.Images(CI.ImageKey), New Point(3, Y2))
                    X2 = CI.ImageList.ImageSize.Width + 6
                End If
            End If
            G.DrawString(CI.Text, Font, Brushes.Black, X2 + 1, Y + 1)
            G.DrawString(CI.Text, Font, Brushes.White, X2, Y)

            If CI.SubItems IsNot Nothing And Columns.Count > 1 Then
                For I2 As Integer = 0 To Math.Min(CI.SubItems.Count + 1, _Columns.Count) - 2
                    X = ColumnOffsets(I2 + 1) + 4

                    R1.X = X
                    R1.Width = Columns(I2).Width
                    G.SetClip(R1)

                    G.DrawString(CI.SubItems(I2).Text, Font, Brushes.Black, X + 1, Y + 1)
                    G.DrawString(CI.SubItems(I2).Text, Font, Brushes.White, X, Y)
                Next
            End If

            G.ResetClip()
        Next

        R1 = New Rectangle(0, 0, Width, ItemHeight)

        GB1 = New LinearGradientBrush(R1, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0F)
        G.FillRectangle(GB1, R1)
        G.DrawRectangle(P3, 1, 1, Width - 22, ItemHeight - 2)

        Dim LH As Integer = Math.Min(VS.Maximum + ItemHeight - Offset, Height)

        Dim CC As NSListViewColumnHeader
        For I As Integer = 0 To _Columns.Count - 1
            CC = Columns(I)

            H = G.MeasureString(CC.Text, Font).Height
            Y = CInt((ItemHeight / 2) - (H / 2))
            X = ColumnOffsets(I)

            G.DrawString(CC.Text, Font, Brushes.Black, X + 1, Y + 1)
            G.DrawString(CC.Text, Font, Brushes.White, X, Y)

            G.DrawLine(P2, X - 3, 0, X - 3, LH)
            G.DrawLine(P3, X - 2, 0, X - 2, ItemHeight)
        Next

        G.DrawRectangle(P2, 0, 0, Width - 1, Height - 1)

        G.DrawLine(P2, 0, ItemHeight, Width, ItemHeight)
        G.DrawLine(P2, VS.Location.X - 1, 0, VS.Location.X - 1, Height)
    End Sub
    Protected Shadows Sub Invalidate()
        Dim ReUpdate As Boolean = False
        For Each CI As NSListViewItem In Me.Items
            If CI.ImageList_ IsNot Me.SmallImageList Then
                CI.ImageList_ = Me.SmallImageList
                ReUpdate = True
            End If
        Next
        If ReUpdate Then
            Invalidate()
        Else
            MyBase.Invalidate()
        End If
    End Sub
    Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
        Dim Move As Integer = -((e.Delta * SystemInformation.MouseWheelScrollLines \ 120) * (ItemHeight \ 2))

        Dim Value As Integer = Math.Max(Math.Min(VS.Value + Move, VS.Maximum), VS.Minimum)
        VS.Value = Value

        MyBase.OnMouseWheel(e)
    End Sub

End Class