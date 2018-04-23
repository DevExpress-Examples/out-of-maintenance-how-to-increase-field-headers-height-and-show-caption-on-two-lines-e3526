Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraPivotGrid
Imports DevExpress.XtraPivotGrid.Data
Imports DevExpress.XtraPivotGrid.ViewInfo
Imports DevExpress.XtraPivotGrid.Printing

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
			Dim printer As New MyPivotGridPrinter(Me)
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
		Protected Overrides Function CreateViewInfo() As PivotGridViewInfo
			Return New MyPivotGridViewInfo(Me)
		End Function
	End Class
	Public Class MyPivotGridViewInfo
		Inherits PivotGridViewInfo
		Public Sub New(ByVal data As PivotGridViewInfoData)
			MyBase.New(data)
		End Sub

		Protected Overrides Function CreateFieldMeasures() As FieldMeasures
			Return New MyFieldMeasures(Data, PrintAndPaintAppearance)
		End Function
	End Class
	Public Class MyFieldMeasures
		Inherits FieldMeasures
		Public Sub New(ByVal data As PivotGridViewInfoData, ByVal appearances As PivotGridAppearancesBase)
			MyBase.New(data, appearances)
		End Sub
		Protected Overrides Function CalculateHeaderHeight(ByVal field As PivotFieldItemBase) As Integer
			Return 40
		End Function
		Protected Overrides Function CalculateDefaultHeaderHeight() As Integer
			Return 40
		End Function


	End Class

	Public Class MyPivotGridPrintViewInfo
		Inherits PivotGridPrintViewInfo
		Public Sub New(ByVal data As PivotGridViewInfoData, ByVal isPSOwner As Boolean)
			MyBase.New(data, isPSOwner)
		End Sub
		Protected Overrides Function CreateFieldMeasures() As FieldMeasures
			Return New MyFieldMeasuresPrinting(Data, PrintAndPaintAppearance)
		End Function

	End Class
	Public Class MyFieldMeasuresPrinting
		Inherits FieldMeasuresPrinting
		Public Sub New(ByVal data As PivotGridViewInfoData, ByVal appearances As PivotGridAppearancesBase)
			MyBase.New(data, appearances)
		End Sub
		Protected Overrides Function CalculateDefaultHeaderHeight() As Integer
			Return 40
		End Function
		Protected Overrides Function CalculateHeaderHeight(ByVal field As PivotFieldItemBase) As Integer
			Return 40
		End Function
	End Class

	Public Class MyPivotGridPrinter
		Inherits PivotGridPrinter
		Public Sub New(ByVal pivotGridControl As PivotGridControl)
			MyBase.New(pivotGridControl)
		End Sub
		Protected Overrides Function CreateViewInfo(ByVal data As PivotGridViewInfoData) As PivotGridPrintViewInfo
			Return New MyPivotGridPrintViewInfo(data, True)
		End Function
	End Class

End Namespace
