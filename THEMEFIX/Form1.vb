Public Class Form1

    Private Sub NsButton1_Click(sender As Object, e As EventArgs) Handles NsButton1.Click
        Dim text As String = "Item " & CStr(NsListView1.Items.Count + 1) & " added"
        NsListView1.Items.Add(text)
        NsListView1.Items(0).SubItems.Add("Sub Item Test")
    End Sub
End Class