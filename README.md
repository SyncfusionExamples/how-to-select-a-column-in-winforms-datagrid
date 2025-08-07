# How to select the entire column in WinForms DataGrid (SfDataGrid)
 
## Selection
In [WinForms DataGrid](https://www.syncfusion.com/winforms-ui-controls/datagrid) (SfDataGrid) You can select the entire column in DataGrid using the [SfDataGrid.SelectCells](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.SfDataGrid.html#Syncfusion_WinForms_DataGrid_SfDataGrid_SelectCells_System_Object_Syncfusion_WinForms_DataGrid_GridColumn_System_Object_Syncfusion_WinForms_DataGrid_GridColumn_)
method. You should set the [SfDataGrid.SelectionUnit](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.SfDataGrid.html#Syncfusion_WinForms_DataGrid_SfDataGrid_SelectionUnit) property as **Cell** or **Any** and the [SfDataGrid.SelectionMode](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.SfDataGrid.html#Syncfusion_WinForms_DataGrid_SfDataGrid_SelectionMode) property as **Extended** or **Multiple** for selecting the entire column. This column selection can be performed when clicking the column header using the [SfDataGrid.CellClick](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.SfDataGrid.html#Syncfusion_WinForms_DataGrid_SfDataGrid_CellClick) event.

### C#    

```C#
public Form1()
{
    InitializeComponent();
    this.sfDataGrid.SelectionUnit = SelectionUnit.Cell;
    this.sfDataGrid.SelectionMode = GridSelectionMode.Extended;
    this.sfDataGrid.CellClick += sfDataGrid_CellClick;
}
 
void sfDataGrid_CellClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
{
    if (e.DataRow.RowType == RowType.HeaderRow && this.sfDataGrid.View.TopLevelGroup == null)
    {
        var firstRowDate = this.sfDataGrid.View.Records[0];
        var lastRowData = this.sfDataGrid.View.Records[this.sfDataGrid.View.Records.Count - 1];
        var column = e.DataColumn.GridColumn;
 
        if (firstRowDate != null && lastRowData != null)
        {
            this.sfDataGrid.ClearSelection();
            this.sfDataGrid.SelectCells(firstRowDate, column, lastRowData, column);
        }
    }
}
```

### VB

```VB
Public Sub New()
    InitializeComponent()
    Dim data = New OrderInfoCollection()
    sfDataGrid.DataSource = data.OrdersListDetails
    Me.sfDataGrid.AllowSorting = False
    Me.sfDataGrid.SelectionUnit = SelectionUnit.Cell
    Me.sfDataGrid.SelectionMode = GridSelectionMode.Extended
    AddHandler Me.sfDataGrid.CellClick, AddressOf sfDataGrid_CellClick
End Sub
 
Private Sub sfDataGrid_CellClick(ByVal sender As Object, ByVal e As Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs)
    If e.DataRow.RowType = RowType.HeaderRow AndAlso Me.sfDataGrid.View.TopLevelGroup Is Nothing Then
       Dim firstRowDate = Me.sfDataGrid.View.Records(0)
       Dim lastRowData = Me.sfDataGrid.View.Records(Me.sfDataGrid.View.Records.Count - 1)
       Dim column = e.DataColumn.GridColumn
       If firstRowDate IsNot Nothing AndAlso lastRowData IsNot Nothing Then
          Me.sfDataGrid.ClearSelection()
          Me.sfDataGrid.SelectCells(firstRowDate, column, lastRowData, column)
       End If
    End If
End Sub
```
Take a moment to peruse the [WinForms DataGrid - Selection](https://help.syncfusion.com/windowsforms/datagrid/selection) documentation, where you can find about the selection with code examples.
