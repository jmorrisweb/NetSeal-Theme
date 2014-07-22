<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim NsListViewColumnHeader1 As NetSeal.NSListView.NSListViewColumnHeader = New NetSeal.NSListView.NSListViewColumnHeader()
        Dim NsListViewColumnHeader2 As NetSeal.NSListView.NSListViewColumnHeader = New NetSeal.NSListView.NSListViewColumnHeader()
        Dim NsListViewColumnHeader3 As NetSeal.NSListView.NSListViewColumnHeader = New NetSeal.NSListView.NSListViewColumnHeader()
        Dim NsListViewColumnHeader4 As NetSeal.NSListView.NSListViewColumnHeader = New NetSeal.NSListView.NSListViewColumnHeader()
        Dim NsListViewColumnHeader5 As NetSeal.NSListView.NSListViewColumnHeader = New NetSeal.NSListView.NSListViewColumnHeader()
        Dim NsListViewColumnHeader6 As NetSeal.NSListView.NSListViewColumnHeader = New NetSeal.NSListView.NSListViewColumnHeader()
        Dim NsListViewItem1 As NetSeal.NSListView.NSListViewItem = New NetSeal.NSListView.NSListViewItem()
        Dim NsListViewSubItem1 As NetSeal.NSListView.NSListViewSubItem = New NetSeal.NSListView.NSListViewSubItem()
        Dim NsListViewItem2 As NetSeal.NSListView.NSListViewItem = New NetSeal.NSListView.NSListViewItem()
        Dim NsListViewSubItem2 As NetSeal.NSListView.NSListViewSubItem = New NetSeal.NSListView.NSListViewSubItem()
        Dim NsListViewSubItem3 As NetSeal.NSListView.NSListViewSubItem = New NetSeal.NSListView.NSListViewSubItem()
        Dim NsListViewSubItem4 As NetSeal.NSListView.NSListViewSubItem = New NetSeal.NSListView.NSListViewSubItem()
        Dim NsListViewSubItem5 As NetSeal.NSListView.NSListViewSubItem = New NetSeal.NSListView.NSListViewSubItem()
        Dim NsListViewItem3 As NetSeal.NSListView.NSListViewItem = New NetSeal.NSListView.NSListViewItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.NsTheme1 = New NetSeal.NSTheme()
        Me.NsButton1 = New NetSeal.NSButton()
        Me.NsListView1 = New NetSeal.NSListView()
        Me.NsTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "1400093895802.png")
        Me.ImageList1.Images.SetKeyName(1, "1400089944086.png")
        '
        'NsTheme1
        '
        Me.NsTheme1.AccentOffset = 42
        Me.NsTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.NsTheme1.Controls.Add(Me.NsButton1)
        Me.NsTheme1.Controls.Add(Me.NsListView1)
        Me.NsTheme1.Customization = ""
        Me.NsTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NsTheme1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.NsTheme1.Image = Nothing
        Me.NsTheme1.Location = New System.Drawing.Point(0, 0)
        Me.NsTheme1.Movable = True
        Me.NsTheme1.Name = "NsTheme1"
        Me.NsTheme1.NoRounding = False
        Me.NsTheme1.Sizable = True
        Me.NsTheme1.Size = New System.Drawing.Size(806, 313)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
        Me.NsTheme1.TabIndex = 2
        Me.NsTheme1.Text = "NsTheme1"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'NsButton1
        '
        Me.NsButton1.Location = New System.Drawing.Point(740, 284)
        Me.NsButton1.Name = "NsButton1"
        Me.NsButton1.Size = New System.Drawing.Size(54, 23)
        Me.NsButton1.TabIndex = 1
        Me.NsButton1.Text = "Debug"
        '
        'NsListView1
        '
        NsListViewColumnHeader1.Text = "First"
        NsListViewColumnHeader1.Width = 120
        NsListViewColumnHeader2.Text = "Second"
        NsListViewColumnHeader2.Width = 120
        NsListViewColumnHeader3.Text = "Third"
        NsListViewColumnHeader3.Width = 120
        NsListViewColumnHeader4.Text = "Fourth"
        NsListViewColumnHeader4.Width = 120
        NsListViewColumnHeader5.Text = "Fifth"
        NsListViewColumnHeader5.Width = 120
        NsListViewColumnHeader6.Text = "Sixth"
        NsListViewColumnHeader6.Width = 120
        Me.NsListView1.Columns = New NetSeal.NSListView.NSListViewColumnHeader() {NsListViewColumnHeader1, NsListViewColumnHeader2, NsListViewColumnHeader3, NsListViewColumnHeader4, NsListViewColumnHeader5, NsListViewColumnHeader6}
        NsListViewItem1.ImageIndex = 0
        NsListViewItem1.ImageKey = ""
        NsListViewSubItem1.Text = "Sub Item 1"
        NsListViewItem1.SubItems.Add(NsListViewSubItem1)
        NsListViewItem1.Text = "Test 1"
        NsListViewItem2.ImageIndex = -1
        NsListViewItem2.ImageKey = "1400089944086.png"
        NsListViewSubItem2.Text = "C"
        NsListViewSubItem3.Text = "I"
        NsListViewSubItem4.Text = "A"
        NsListViewSubItem5.Text = "Wants my info"
        NsListViewItem2.SubItems.Add(NsListViewSubItem2)
        NsListViewItem2.SubItems.Add(NsListViewSubItem3)
        NsListViewItem2.SubItems.Add(NsListViewSubItem4)
        NsListViewItem2.SubItems.Add(NsListViewSubItem5)
        NsListViewItem2.Text = "Test 2"
        NsListViewItem3.ImageIndex = -1
        NsListViewItem3.ImageKey = ""
        NsListViewItem3.Text = "Test 3"
        Me.NsListView1.Items.Add(NsListViewItem1)
        Me.NsListView1.Items.Add(NsListViewItem2)
        Me.NsListView1.Items.Add(NsListViewItem3)
        Me.NsListView1.Location = New System.Drawing.Point(12, 41)
        Me.NsListView1.MultiSelect = True
        Me.NsListView1.Name = "NsListView1"
        Me.NsListView1.Size = New System.Drawing.Size(782, 237)
        Me.NsListView1.SmallImageList = Me.ImageList1
        Me.NsListView1.TabIndex = 0
        Me.NsListView1.Text = "NsListView1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 313)
        Me.Controls.Add(Me.NsTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.NsTheme1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NsListView1 As NetSeal.NSListView
    Friend WithEvents NsButton1 As NetSeal.NSButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents NsTheme1 As NetSeal.NSTheme
End Class
