using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using BusinessLogic;
using System.ComponentModel;
using ViewModel.Commands;
using System.Collections;

namespace ViewModel
{
    public class BeersViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public IBeer BeerToAdd { get; set; }
        public EditedBeer BeerToEdit { get; set; }
        public IProducent ProducentToAdd { get; set; }
        public BindingList<IBeer> Beers { get; set; }
        public BindingList<IProducent> Producents { get; set; }
        public BindingList<String> BeerDetailsView { get; set; }
        public BindingList<String> ProducentDetailsView { get; set; }
        public CommandButtons CommandAdd { get; set; }
        public CommandButtons CommandEdit { get; set; }
        public CommandButtons CommandRemove { get; set; }
        public CommandItemSelected CommandListItemSelected { get; set; }
        public int SelectedItemIndex { get; set; }
        private IBL Dao { get; set; }

        public BeersViewModel()
        {
            Dao = new BL();
            Beers = new BindingList<IBeer>(Dao.getData().getBeers());
            Producents = new BindingList<IProducent>(Dao.getData().getProducents());
            BeerDetailsView = new BindingList<string>();
            ProducentDetailsView = new BindingList<string>();
            makeDetailsOfSelectedBeer(Beers[0]);
            makeDetailsOfSelectedProducent(Producents[0]);
            BeerToAdd = Dao.getData().GetNewBeer();
       //     BeerToEdit = new EditedBeer(Dao.getData().GetNewBeer());
            ProducentToAdd = Dao.getData().GetNewProducent();
            CommandAdd = new CommandButtons(param => this.onAddClicked(BeerToAdd), param => this.CanCreateBeer());
            SelectedItemIndex = 0;
            CommandListItemSelected = new CommandItemSelected(param => this.onItemSelected(SelectedItemIndex));
         //   CommandEdit = new CommandButtons(param => this.onEditClicked());
         //   CommandRemove = new CommandButtons(param => this.onRemoveClicked());
        }

        public void onAddClicked(IBeer beer)
        {
            IBeer newBeer = Dao.getData().GetNewBeer();
            AssignValuesToBeer(newBeer, beer);
            Dao.getData().AddNewBeer(newBeer);
            Beers.Add(newBeer);
        }

        public void onEditClicked()
        {
            Console.WriteLine("edit clicked");
        }

        public void onRemoveClicked()
        {
            Console.WriteLine("remove clicked");
        }

        public void onItemSelected( int selectedIndex )
        {  
            makeDetailsOfSelectedBeer( Beers[selectedIndex] );
        }

        private void AssignValuesToBeer(IBeer newBeer, IBeer beer)
        {
            
            newBeer.Race = beer.Race;
            newBeer.Speciality = beer.Speciality;
            newBeer.Producent = beer.Producent;
            newBeer.AlcoholPercent = beer.AlcoholPercent;
            newBeer.IBU = beer.IBU;
            newBeer.EBC = beer.EBC;
            newBeer.ServingTemperature = beer.ServingTemperature;
            newBeer.BLG = beer.BLG;
            newBeer.BestBefore = beer.BestBefore;
            newBeer.SeaStory = beer.SeaStory;
            newBeer.Ingredients = beer.Ingredients;
             
        }

        private bool CanCreateBeer()
        {
            if (this.BeerToEdit == null)
                return true;
            if (!this.BeerToEdit.HasErrors)
                return true;

            return false;
        }

        private void makeDetailsOfSelectedBeer(object obj)
        {
            BeerDetailsView.Clear();
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                String name = descriptor.Name;
                object value = descriptor.GetValue(obj);
                if (name == "Producent")
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

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region INotifyDataErrorInfo
        public bool HasErrors => _errors.Count > 0;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                return _errors[propertyName];
            }
            return null;
        }
        #endregion

        protected Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        protected void RemoveErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
            }
        }

        protected void AddError(string propertyName, string errorMsg)
        {
            List<string> propertyErrors = null;
            if (_errors.ContainsKey(propertyName))
            {
                propertyErrors = _errors[propertyName];
            }
            else
            {
                propertyErrors = new List<string>();
                _errors.Add(propertyName, propertyErrors);
            }
            propertyErrors.Add(errorMsg);
        }

        protected void OnErrorChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            //ErrorsChanged?.Invoke
        }

        IEnumerable INotifyDataErrorInfo.GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }

    }
}
