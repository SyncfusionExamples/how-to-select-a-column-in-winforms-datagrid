using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid.Styles;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Enums;

namespace GettingStarted
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var data = new OrderInfoCollection();
            sfDataGrid.DataSource = data.OrdersListDetails;

            this.sfDataGrid.AllowSorting = false;
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

    }
}
