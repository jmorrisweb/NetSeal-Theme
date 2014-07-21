Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.Windows.Forms.Design
Imports System.Windows.Forms

''Learning about UITypeEditor's, going to implement a custom editor.
Public Class BorderStyleEditor
    Inherits UITypeEditor

    Public Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As UITypeEditorEditStyle
        Return UITypeEditorEditStyle.Modal
    End Function

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

    Public Overrides Function GetPaintValueSupported( _
        ByVal context As ITypeDescriptorContext) As Boolean

        Return True

    End Function

    Public Overrides Sub PaintValue(ByVal e As PaintValueEventArgs)

    End Sub
End Class