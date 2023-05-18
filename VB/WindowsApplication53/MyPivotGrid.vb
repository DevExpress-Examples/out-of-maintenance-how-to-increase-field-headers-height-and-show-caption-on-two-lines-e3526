Imports DevExpress.XtraPivotGrid
Imports DevExpress.XtraPivotGrid.Data
Imports DevExpress.XtraPivotGrid.ViewInfo
Imports DevExpress.XtraPivotGrid.Printing
Imports DevExpress.PivotGrid.Printing

Namespace WindowsApplication53

    Public Class MyPivotGridControl
        Inherits PivotGridControl

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal viewInfoData As PivotGridViewInfoData)
            MyBase.New(viewInfoData)
        End Sub

        Protected Overrides Function CreateData() As PivotGridViewInfoData
            Return New MyPivotGridViewInfoData(Me)
        End Function

        Protected Overrides Function CreatePrinter() As PivotGridPrinter
            Dim printer As MyPivotGridPrinter = New MyPivotGridPrinter(Me)
            printer.Owner = Me
            Return printer
        End Function
    End Class

    Public Class MyPivotGridViewInfoData
        Inherits PivotGridViewInfoData

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal control As IViewInfoControl)
            MyBase.New(control)
        End Sub

        Protected Overrides Function CreateFieldMeasures(ByVal data As PivotGridViewInfoData, ByVal appearances As PivotGridAppearancesBase, ByVal visualItems As PivotVisualItems) As FieldMeasures
            Return New MyFieldMeasures(data, appearances, visualItems)
        End Function
    End Class

    Public Class MyFieldMeasures
        Inherits FieldMeasures

        Public Sub New(ByVal data As PivotGridViewInfoData, ByVal appearances As PivotGridAppearancesBase, ByVal visualItems As PivotVisualItems)
            MyBase.New(data, appearances, visualItems)
        End Sub

        Protected Overrides Function CalculateHeaderHeight(ByVal field As PivotFieldItemBase) As Integer
            Return 40
        End Function
    End Class

    Public Class MyPivotGridPrinter
        Inherits PivotGridPrinter

        Public Sub New(ByVal pivotGridControl As PivotGridControl)
            MyBase.New(pivotGridControl)
        End Sub

        Protected Overrides Function DrawHeaderBrick(ByVal field As PivotFieldItemBase, ByVal bounds As System.Drawing.Rectangle) As DevExpress.XtraPrinting.VisualBrick
            Return MyBase.DrawHeaderBrick(field, bounds)
        End Function

        Protected Overrides Function CreatePivotPrintBestFitter() As PivotPrintBestFitter
            Return New MyPivotPrintBestFitter(Data, Me)
        End Function
    End Class

    Public Class MyPivotPrintBestFitter
        Inherits PivotPrintBestFitter

        Public Sub New(ByVal data As PivotGridData, ByVal printer As PivotGridPrinterBase)
            MyBase.New(data, printer, New MyPrintCellSizeProvider(data, data.VisualItems, printer))
        End Sub
    End Class

    Public Class MyPrintCellSizeProvider
        Inherits PrintCellSizeProvider

        Public Sub New(ByVal data As PivotGridData, ByVal visualItems As PivotVisualItemsBase, ByVal printer As PivotGridPrinterBase)
            MyBase.New(data, visualItems, printer)
        End Sub

        Protected Overrides Function CalculateHeaderHeight(ByVal field As PivotFieldItemBase) As Integer
            Return 40
        'return base.CalculateHeaderHeight(field);
        End Function
    End Class
End Namespace
