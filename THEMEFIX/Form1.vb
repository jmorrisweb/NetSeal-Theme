Public Class Form1

    Private Sub NsButton1_Click(sender As Object, e As EventArgs) Handles NsButton1.Click
        Dim Temp As New NetSeal.NSListView.NSListViewItem
        Dim Temp2 As New NetSeal.NSListView.NSListViewSubItem
        Temp2.Text = "W00T"
        Temp.SubItems.Add(Temp2)
        Temp.Text = "Top KeK"
        NsListView1.Items.Add(Temp)
    End Sub
End Class