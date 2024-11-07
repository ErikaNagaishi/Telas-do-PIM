using DataGridViewAutoFilter;
using System.ComponentModel;

namespace Telas_do_PIM.configuration
{
    class DataGridViewAutoFilterCheckBoxColumn : DataGridViewCheckBoxColumn
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Type DefaultHeaderCellType => typeof(DataGridViewAutoFilterColumnHeaderCell);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Browsable(false)]
        [DefaultValue(DataGridViewColumnSortMode.Programmatic)]
        public new DataGridViewColumnSortMode SortMode
        {
            get
            {
                return base.SortMode;
            }
            set
            {
                if (value == DataGridViewColumnSortMode.Automatic)
                {
                    throw new InvalidOperationException("A SortMode value of Automatic is incompatible with the DataGridViewAutoFilterColumnHeaderCell type. Use the AutomaticSortingEnabled property instead.");
                }

                base.SortMode = value;
            }
        }

        [DefaultValue(true)]
        public bool FilteringEnabled
        {
            get
            {
                return ((DataGridViewAutoFilterColumnHeaderCell)base.HeaderCell).FilteringEnabled;
            }
            set
            {
                ((DataGridViewAutoFilterColumnHeaderCell)base.HeaderCell).FilteringEnabled = value;
            }
        }

        [DefaultValue(true)]
        public bool AutomaticSortingEnabled
        {
            get
            {
                return ((DataGridViewAutoFilterColumnHeaderCell)base.HeaderCell).AutomaticSortingEnabled;
            }
            set
            {
                ((DataGridViewAutoFilterColumnHeaderCell)base.HeaderCell).AutomaticSortingEnabled = value;
            }
        }

        [DefaultValue(20)]
        public int DropDownListBoxMaxLines
        {
            get
            {
                return ((DataGridViewAutoFilterColumnHeaderCell)base.HeaderCell).DropDownListBoxMaxLines;
            }
            set
            {
                ((DataGridViewAutoFilterColumnHeaderCell)base.HeaderCell).DropDownListBoxMaxLines = value;
            }
        }

        public DataGridViewAutoFilterCheckBoxColumn()
        {
            base.DefaultHeaderCellType = typeof(DataGridViewAutoFilterColumnHeaderCell);
            base.SortMode = DataGridViewColumnSortMode.Programmatic;
        }

        public static void RemoveFilter(DataGridView dataGridView)
        {
            DataGridViewAutoFilterColumnHeaderCell.RemoveFilter(dataGridView);
        }

        public static string GetFilterStatus(DataGridView dataGridView)
        {
            return DataGridViewAutoFilterColumnHeaderCell.GetFilterStatus(dataGridView);
        }
    }
}
