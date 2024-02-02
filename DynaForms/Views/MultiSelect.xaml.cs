using Autodesk.DesignScript.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DynaForms.Views
{
    /// <summary>
    /// Interaction logic for MultiSelect.xaml
    /// </summary>
    /// 
    [SupressImportIntoVM]    
    public partial class MultiSelect : Window
    {
        public MultiSelect()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            MoveSelectedItems(lstUnselected,lstSelected);
        }

        private void btnSelectAll_Click(object sender, RoutedEventArgs e)
        {
            MoveAllItems(lstUnselected,lstSelected);
        }

        private void btnDeselect_Click(object sender, RoutedEventArgs e)
        {
            MoveSelectedItems(lstSelected, lstUnselected);
        }

        private void btnDeselectAll_Click(object sender, RoutedEventArgs e)
        {
            MoveAllItems(lstSelected,lstUnselected);
        }

        private void btnMoveUp_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = this.lstSelected.SelectedIndex;
            if(selectedIndex > 0)
            {
                var itemToMoveUp = this.lstSelected.Items[selectedIndex];
                this.lstSelected.Items.Remove(itemToMoveUp);
                this.lstSelected.Items.Insert(selectedIndex-1, itemToMoveUp);
                this.lstSelected.SelectedIndex = selectedIndex-1;
            }
        }

        private void btnMoveDown_Click(object sender, RoutedEventArgs e)
        {
            if (this.lstSelected.SelectedIndex != -1)
            {
                var selectedIndex = this.lstSelected.SelectedIndex;
                if(selectedIndex + 1 < this.lstSelected.Items.Count)
                {
                    var itemToMoveDown = this.lstSelected.Items[selectedIndex];
                    this.lstSelected.Items.Remove(itemToMoveDown);
                    this.lstSelected.Items.Insert(selectedIndex+1, itemToMoveDown);
                    this.lstSelected.SelectedIndex=selectedIndex+1;
                }
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= false;
            Close();
        }

        #region Functions

        //Enable and disable selection buttons.
        private void SetButtonsEditable()
        {
            btnSelect.IsEnabled = lstUnselected.Items.Count > 0;
            btnSelectAll.IsEnabled = lstSelected.Items.Count > 0;
            btnDeselect.IsEnabled = lstSelected.Items.Count > 0;
            btnDeselectAll.IsEnabled = lstSelected.Items.Count > 0;
        }
        
        private void MoveSelectedItems(ListBox lstFrom, ListBox lstTo)
        {
            while(lstFrom.SelectedItems.Count > 0)
            {
                var item = lstFrom.SelectedItems[0];
                lstTo.Items.Add(item);
                lstFrom.Items.Remove(item);
            }
            SetButtonsEditable();

        }

        private void MoveAllItems(ListBox lstFrom, ListBox lstTo)
        {
            for (int i=0; i<lstFrom.Items.Count; i++)
            {
                lstTo.Items.Add(lstFrom.Items[i]);
            }
            lstFrom.Items.Clear();
            SetButtonsEditable();
        }

        #endregion
    }
}
