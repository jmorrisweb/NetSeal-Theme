Public Class Form1

    Private Sub NsButton1_Click(sender As Object, e As EventArgs) Handles NsButton1.Click
        Dim text As String = "Item " & CStr(NsListView1.Items.Count + 1) & " added"
        NsListView1.Items.Add(Text)
        NsListView1.Items(0).SubItems.Add("Sub Item Test")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        NsListView1.Columns(0).Width = Me.Width
    End Sub
End Class