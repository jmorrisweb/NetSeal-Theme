Imports System.Windows.Forms
Imports System.Drawing
Public Class NSColorTable
    Inherits ProfessionalColorTable
    Private BackColor As Color = Color.FromArgb(55, 55, 55)
    Public Overrides ReadOnly Property ButtonSelectedBorder() As Color
        Get
            Return BackColor
        End Get
    End Property
    Public Overrides ReadOnly Property CheckBackground() As Color
        Get
            Return BackColor
        End Get
    End Property
    Public Overrides ReadOnly Property CheckPressedBackground() As Color
        Get
            Return BackColor
        End Get
    End Property
    Public Overrides ReadOnly Property CheckSelectedBackground() As Color
        Get
            Return BackColor
        End Get
    End Property
    Public Overrides ReadOnly Property ImageMarginGradientBegin() As Color
        Get
            Return BackColor
        End Get
    End Property
    Public Overrides ReadOnly Property ImageMarginGradientEnd() As Color
        Get
            Return BackColor
        End Get
    End Property
    Public Overrides ReadOnly Property ImageMarginGradientMiddle() As Color
        Get
            Return BackColor
        End Get
    End Property
    Public Overrides ReadOnly Property MenuBorder() As Color
        Get
            Return Color.FromArgb(25, 25, 25)
        End Get
    End Property
    Public Overrides ReadOnly Property MenuItemBorder() As Color
        Get
            Return BackColor
        End Get
    End Property
    Public Overrides ReadOnly Property MenuItemSelected() As Color
        Get
            Return Color.FromArgb(65, 65, 65)
        End Get
    End Property
    Public Overrides ReadOnly Property SeparatorDark() As Color
        Get
            Return Color.FromArgb(35, 35, 35)
        End Get
    End Property
    Public Overrides ReadOnly Property ToolStripDropDownBackground() As Color
        Get
            Return BackColor
        End Get
    End Property
End Class