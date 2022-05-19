Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Namespace WindowsApplication53

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            PopulateTable()
            pivotGridControl1.RefreshData()
            pivotGridControl1.BestFit()
            pivotGridControl1.FieldsCustomization(panel1)
        End Sub

        Private Sub PopulateTable()
            Dim myTable As DataTable = dataSet1.Tables("Data")
            myTable.Rows.Add(New Object() {"Aaa", Date.Today, 7})
            myTable.Rows.Add(New Object() {"Aaa", Date.Today.AddDays(1), 4})
            myTable.Rows.Add(New Object() {"Bbb", Date.Today, 12})
            myTable.Rows.Add(New Object() {"Bbb", Date.Today.AddDays(1), 14})
            myTable.Rows.Add(New Object() {"Ccc", Date.Today, 11})
            myTable.Rows.Add(New Object() {"Ccc", Date.Today.AddDays(1), 10})
            myTable.Rows.Add(New Object() {"Aaa", Date.Today.AddYears(1), 4})
            myTable.Rows.Add(New Object() {"Aaa", Date.Today.AddYears(1).AddDays(1), 2})
            myTable.Rows.Add(New Object() {"Bbb", Date.Today.AddYears(1), 3})
            myTable.Rows.Add(New Object() {"Bbb", Date.Today.AddDays(1).AddYears(1), 1})
            myTable.Rows.Add(New Object() {"Ccc", Date.Today.AddYears(1), 8})
            myTable.Rows.Add(New Object() {"Ccc", Date.Today.AddDays(1).AddYears(1), 22})
        End Sub

        Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
            pivotGridControl1.ShowPrintPreview()
        End Sub

        Private Sub pivotGridControl1_CustomExportHeader(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.CustomExportHeaderEventArgs)
        'TextBrick brick = e.Brick as TextBrick;
        'if (brick != null)
        '    brick.Size = new SizeF(brick.Size.Width, brick.Size.Height * 2);
        End Sub
    End Class
End Namespace
