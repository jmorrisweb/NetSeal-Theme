Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.Windows.Forms.Design
Imports System.Windows.Forms

Public Class BorderStyleEditor
    Inherits UITypeEditor

    ' Indicate that we display a dropdown.
    Public Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As UITypeEditorEditStyle
        Return UITypeEditorEditStyle.Modal
    End Function

    ' Edit a line style
    Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object
        Dim editor_service As IWindowsFormsEditorService = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
        If editor_service Is Nothing Then
            Return MyBase.EditValue(context, provider, value)
        Else
            If editor_service.ShowDialog(New NSListView_Items_Editor_Dialog) = DialogResult.OK Then
                Return value
            Else
                Return value
            End If
        End If
    End Function

    ' Indicate that we draw values in the Properties window.
    Public Overrides Function GetPaintValueSupported( _
        ByVal context As ITypeDescriptorContext) As Boolean

        Return True

    End Function

    ' Draw a BorderStyles value.
    Public Overrides Sub PaintValue(ByVal e As PaintValueEventArgs)

    End Sub
End Class