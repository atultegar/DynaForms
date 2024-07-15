using DynaForms.Views;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DynaForms
{
    public class Forms
    {
        internal Forms()
        {
            
        }

        /// <summary>
        /// Form with dropdown for input
        /// </summary>
        /// <param name="list"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        [STAThread]
        public static object FormDropDown(List<object> list, string title = "item")
        {
            DropDown window = new DropDown();

            window.lbl_1.Content = $"Select {title} from dropdown";
            window.cb_1.ItemsSource = list;

            var res = window.ShowDialog();
            if(!res.HasValue && res.Value)
            {
                window.Close();
            }
            var idx = window.cb_1.SelectedIndex;
            return list[idx];
        }

        /// <summary>
        /// Form with list box for inputs
        /// </summary>
        /// <param name="list"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        [STAThread]
        public static IList<object> FormListSelect(List<object> list, string title = "items")
        {            
            SelectionList window = new SelectionList();

            window.lbl_1.Content = $"Select {title} from the List Box";
            window.lstBox.ItemsSource = list;

            var res = window.ShowDialog();
            if(!res.HasValue && res.Value)
                window.Close();
            IList<object> output = (IList<object>)window.lstBox.SelectedItems;

            return output;
        }

        /// <summary>
        /// Form with list boxes for multiple selection
        /// </summary>
        /// <param name="list"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        [STAThread]
        public static IList<object> FormMultiSelect(List<object> list, string title = "items")
        {
            IList<object> output = new List<object>();
            MultiSelect window = new MultiSelect();

            window.lbl_1.Content = $"Select {title} from left list box";
            
            for(int i=0; i<list.Count; i++)
            {
                window.lstUnselected.Items.Add(list[i]);
            }

            var res = window.ShowDialog();
            if(res.HasValue && res.Value)
                window.Close();

            for (int j=0; j < window.lstSelected.Items.Count; j++)
            {
                output.Add(window.lstSelected.Items[j]);
            }

            return output;
        }

        /// <summary>
        /// Form with textbox for input
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [STAThread]
        public static object FormTextInput(string title = "Write text")
        {
            object output = null;
            TextInput window = new TextInput();

            //window.lbl_1.Content = title;
            window.tb_1.Text = title;

            var res = window.ShowDialog();
            if(res.HasValue && res.Value)
                window.Close();

            output = window.txt_1.Text;

            return output;
        }
    }
}
