# How to increase Field Headers height and show caption on two lines


<p>The current version of the XtraPivotGrid control does not fully support word wrap for field headers. Basically, our caption drawing mechanism supports word wrap, but the header height is not increased automatically to show an entire content. However, you can create a simple PivotGridControl descendant and adjust the header height manually. It is only necessary to override the <strong>FieldMeasures.CalculateHeaderHeight</strong> and <strong>FieldMeasures.CalculateDefaultHeaderHeight</strong> methods to accomplish this task.</p>

<br/>


