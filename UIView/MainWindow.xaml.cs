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
using Interfaces;
using BusinessLogic;
using System.ComponentModel;

namespace UIView
{
    public partial class MainWindow : Window 
    {
        public List<IBeer> Beers { get; set; }
        public List<IProducent> Producents { get; set; }
        public BindingList<String> BeerDetailsView { get; set; }
        public BindingList<String> ProducentDetailsView { get; set; }

        private void makeDetailsOfSelectedBeer( object obj)
        {
            BeerDetailsView.Clear();
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                String name = descriptor.Name;
                object value = descriptor.GetValue(obj);
                if (name == "producent")
                {
                    IProducent producent = (IProducent)descriptor.GetValue(obj);
                    BeerDetailsView.Add($"{name}: {producent.Name}");
                }
                else
                {
                    BeerDetailsView.Add($"{name}: {value.ToString()}");
                }     
            }
        }

        private void makeDetailsOfSelectedProducent(object obj)
        {
            ProducentDetailsView.Clear();
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                String name = descriptor.Name;
                object value = descriptor.GetValue(obj);  
                ProducentDetailsView.Add($"{name}: {value.ToString()}");
            }
        }

        public MainWindow()
        {
            IBL Dao = new BL();
            Beers = Dao.getData().getBeers();
            Producents = Dao.getData().getProducents();
            BeerDetailsView = new BindingList<string>();
            ProducentDetailsView = new BindingList<string>();
            makeDetailsOfSelectedBeer(Beers[0]);
            makeDetailsOfSelectedProducent(Producents[0]);
            InitializeComponent();      
        }

        private void BeerNames_Selected(object sender, RoutedEventArgs e)
        {
            Beers[BeerNames.SelectedIndex].IBU = BeerNames.SelectedIndex;    
            makeDetailsOfSelectedBeer( Beers[BeerNames.SelectedIndex] );
        }

        private void ProducentNames_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
