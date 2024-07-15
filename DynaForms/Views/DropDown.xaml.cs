using Autodesk.DesignScript.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace DynaForms.Views
{
    /// <summary>
    /// Interaction logic for DropDown.xaml
    /// </summary>
    [SupressImportIntoVM]    
    public partial class DropDown : Window
    {
        [IsVisibleInDynamoLibrary(false)]
        public DropDown()
        {
            InitializeComponent();
        }

        private void btn_Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}