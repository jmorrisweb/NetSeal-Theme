Public Class Form1

    Private Sub NsButton1_Click(sender As Object, e As EventArgs) Handles NsButton1.Click
        For i As Integer = 0 To 1000
            Dim text As String = "Item " & CStr(NsListView1.Items.Count + 1) & " added"
            NsListView1.Items.Add(text, "Sub Item Test", "Sub Item 2 Test")
        Next
    End Sub

    Private Sub NsListView1_Click(sender As Object, e As EventArgs) Handles NsListView1.Click

    End Sub
End Class