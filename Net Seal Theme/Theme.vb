'I will implmenent this!
'public class NSMessageBox

'    Public Shared Function ShowYesNo(text As String, caption As String) As DialogResult
'        Dim F As Form = CreateDialog(text, caption)

'        Dim B1 As New NSButton
'        Dim B2 As New NSButton

'        Dim S As New Size(90, 25)
'        B1.Size = S
'        B2.Size = S

'        B1.Location = New Point(284, 119)
'        B2.Location = New Point(188, 119)

'        B1.Text = "Yes"
'        B2.Text = "No"

'        AddHandler B1.Click, Sub() F.DialogResult = DialogResult.Yes
'        AddHandler B2.Click, Sub() F.DialogResult = DialogResult.No

'        F.Controls(0).Controls.Add(B1)
'        F.Controls(0).Controls.Add(B2)

'        Return F.ShowDialog()
'    End Function

'    Public Shared Function ShowOk(text As String, caption As String) As DialogResult
'        Dim F As Form = CreateDialog(text, caption)

'        Dim B1 As New NSButton

'        Dim S As New Size(90, 25)
'        B1.Size = S

'        B1.Location = New Point(284, 119)

'        B1.Text = "Ok"

'        AddHandler B1.Click, Sub() F.DialogResult = DialogResult.OK

'        F.Controls(0).Controls.Add(B1)

'        Return F.ShowDialog()
'    End Function

'    Private Shared Function CreateDialog(text As String, caption As String) As Form
'        Dim F As New Form

'        Dim MTheme1 As New WindowsApplication1.NSTheme()
'        Dim MControlButton1 As New WindowsApplication1.NSControlButton()
'        Dim Label1 As New System.Windows.Forms.Label()

'        MTheme1.Controls.Add(MControlButton1)
'        MTheme1.Controls.Add(Label1)
'        MTheme1.Sizable = False
'        MTheme1.Size = New System.Drawing.Size(386, 156)
'        MTheme1.Text = caption

'        MControlButton1.ControlButton = WindowsApplication1.NSControlButton.Button.Close
'        MControlButton1.Location = New System.Drawing.Point(360, 4)

'        Label1.ForeColor = System.Drawing.Color.White
'        Label1.Location = New System.Drawing.Point(12, 38)
'        Label1.Size = New System.Drawing.Size(362, 78)
'        Label1.Text = text

'        F.StartPosition = FormStartPosition.CenterParent
'        F.ClientSize = New System.Drawing.Size(386, 156)
'        F.Controls.Add(MTheme1)
'        F.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
'        F.Text = caption

'        Return F
'    End Function

'End Class