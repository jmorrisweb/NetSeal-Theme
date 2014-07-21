Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Text
Public Class NSContextMenu
    Inherits ContextMenuStrip
    Sub New()
        Renderer = New ToolStripProfessionalRenderer(New NSColorTable())
        ForeColor = Color.White
    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        MyBase.OnPaint(e)
    End Sub
End Class