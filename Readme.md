<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/WindowsApplication53/Form1.cs) (VB: [Form1.vb](./VB/WindowsApplication53/Form1.vb))
* [MyPivotGrid.cs](./CS/WindowsApplication53/MyPivotGrid.cs) (VB: [MyPivotGrid.vb](./VB/WindowsApplication53/MyPivotGrid.vb))
* [Program.cs](./CS/WindowsApplication53/Program.cs) (VB: [Program.vb](./VB/WindowsApplication53/Program.vb))
<!-- default file list end -->
# How to increase Field Headers height and show caption on two lines


<p>The current version of the XtraPivotGrid control does not fully support word wrap for field headers. Basically, our caption drawing mechanism supports word wrap, but the header height is not increased automatically to show an entire content. However, you can create a simple PivotGridControl descendant and adjust the header height manually. It is only necessary to override the <strong>FieldMeasures.CalculateHeaderHeight</strong> and <strong>FieldMeasures.CalculateDefaultHeaderHeight</strong> methods to accomplish this task.</p>

<br/>


