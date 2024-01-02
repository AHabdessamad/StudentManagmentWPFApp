using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudentManagmentWPF.Model;
using StudentManagmentWPF.ViewModel;

namespace StudentManagmentWPF.View
{
    /// <summary>
    /// Interaction logic for FieldUI.xaml
    /// </summary>
    public partial class FieldUI : UserControl
    {
        public FieldUI()
        {
            InitializeComponent();
            //if (DataContext is FieldVM fieldVM)
            //{
            //    txtId.Text = fieldVM.Fields.Count + "";
            //}
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Field obj = new Field();
            obj.Nom = txtName.Text.ToString();
            obj.Responsable = txtResponsable.Text.ToString();
            if (DataContext is FieldVM fieldVM)
            {
                fieldVM.AddElemet(obj);
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is FieldVM fieldVM)
            {
                Field obj = new Field();
                obj.Nom = txtName.Text;
                obj.Responsable = txtResponsable.Text;
                fieldVM.EditItem(obj);
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is FieldVM fieldVM)
            {
                fieldVM.deleteSelectedItem();
            }
        }

        private void TopContainerChanged(object sender, RoutedEventArgs e)
        {
            if(fieldCarousel.SelectedItem!=null && fieldCarousel.SelectedItem.GetType() == typeof(Field) && DataContext is FieldVM fieldVM)
            {
                Field obj = (Field)fieldCarousel.SelectedItem;
                Field item = new Field(obj.Id,obj.Nom,obj.Responsable);
                fieldVM.Obj = item;
            }
        }        
        private void IsAnimatingchanged(object sender, RoutedEventArgs e)
        { }

    }
}
