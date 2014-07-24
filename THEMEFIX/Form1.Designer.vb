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
        Dim NsListViewItem1 As NetSeal.NSListView.NSListViewItem = New NetSeal.NSListView.NSListViewItem()
        Dim NsListViewSubItem1 As NetSeal.NSListView.NSListViewSubItem = New NetSeal.NSListView.NSListViewSubItem()
        Dim NsListViewSubItem2 As NetSeal.NSListView.NSListViewSubItem = New NetSeal.NSListView.NSListViewSubItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.NsTheme1 = New NetSeal.NSTheme()
        Me.NsListView1 = New NetSeal.NSListView()
        Me.NsButton1 = New NetSeal.NSButton()
        Me.NsTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "checkmark.png")
        Me.ImageList1.Images.SetKeyName(1, "checkmark.png")
        '
        'NsTheme1
        '
        Me.NsTheme1.AccentOffset = 42
        Me.NsTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.NsTheme1.Controls.Add(Me.NsListView1)
        Me.NsTheme1.Controls.Add(Me.NsButton1)
        Me.NsTheme1.Customization = ""
        Me.NsTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NsTheme1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.NsTheme1.Image = Nothing
        Me.NsTheme1.Location = New System.Drawing.Point(0, 0)
        Me.NsTheme1.Movable = True
        Me.NsTheme1.Name = "NsTheme1"
        Me.NsTheme1.NoRounding = False
        Me.NsTheme1.Sizable = True
        Me.NsTheme1.Size = New System.Drawing.Size(521, 394)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
        Me.NsTheme1.TabIndex = 0
        Me.NsTheme1.Text = "NsTheme1"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'NsListView1
        '
        NsListViewColumnHeader1.ShowCheckBox = False
        NsListViewColumnHeader1.Text = "Test"
        NsListViewColumnHeader1.Width = 60
        NsListViewColumnHeader2.ShowCheckBox = False
        NsListViewColumnHeader2.Text = "Test 2"
        NsListViewColumnHeader2.Width = 60
        NsListViewColumnHeader3.ShowCheckBox = False
        NsListViewColumnHeader3.Text = "Test 3"
        NsListViewColumnHeader3.Width = 60
        Me.NsListView1.Columns.Add(NsListViewColumnHeader1)
        Me.NsListView1.Columns.Add(NsListViewColumnHeader2)
        Me.NsListView1.Columns.Add(NsListViewColumnHeader3)
        NsListViewItem1.ImageIndex = -1
        NsListViewItem1.ImageKey = ""
        NsListViewSubItem1.Text = "Test"
        NsListViewSubItem2.Text = "Testbox"
        NsListViewItem1.SubItems.Add(NsListViewSubItem1)
        NsListViewItem1.SubItems.Add(NsListViewSubItem2)
        NsListViewItem1.Tag = Nothing
        NsListViewItem1.Text = "Test"
        Me.NsListView1.Items.Add(NsListViewItem1)
        Me.NsListView1.Location = New System.Drawing.Point(12, 36)
        Me.NsListView1.MultiSelect = True
        Me.NsListView1.Name = "NsListView1"
        Me.NsListView1.Size = New System.Drawing.Size(497, 176)
        Me.NsListView1.SmallImageList = Me.ImageList1
        Me.NsListView1.TabIndex = 2
        Me.NsListView1.Text = "NsListView1"
        '
        'NsButton1
        '
        Me.NsButton1.Location = New System.Drawing.Point(456, 361)
        Me.NsButton1.Name = "NsButton1"
        Me.NsButton1.Size = New System.Drawing.Size(53, 23)
        Me.NsButton1.TabIndex = 1
        Me.NsButton1.Text = "Debug"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 394)
        Me.Controls.Add(Me.NsTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.NsTheme1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NsTheme1 As NetSeal.NSTheme
    Friend WithEvents NsButton1 As NetSeal.NSButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents NsListView1 As NetSeal.NSListView
End Class
