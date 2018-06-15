using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using BusinessLogic;
using System.ComponentModel;
using ViewModel.Commands;
using Core;

namespace ViewModel
{
    public class ViewModel
    {
        public List<string> Races { get; set; }
        public EditedBeer BeerToAdd { get; set; }
        public EditedBeer BeerToEdit { get; set; }

        public EditedProducent ProducentToAdd { get; set; }
        public EditedProducent ProducentToEdit { get; set; }

        public BindingList<IBeer> Beers { get; set; }
        public BindingList<IProducent> Producents { get; set; }

        public BindingList<String> BeerDetailsView { get; set; }
        public BindingList<String> ProducentDetailsView { get; set; }

        public CommandButtons CommandBeerAdd { get; set; }
        public CommandButtons CommandBeerEdit { get; set; }
        public CommandButtons CommandBeerRemove { get; set; }

        public CommandButtons CommandProducentAdd { get; set; }
        public CommandButtons CommandProducentEdit { get; set; }
        public CommandButtons CommandProducentRemove { get; set; }

        public CommandItemSelected CommandBeerListItemSelected { get; set; }
        public CommandItemSelected CommandProducentListItemSelected { get; set; }

        public int SelectedItemIndex { get; set; }
        private IBL Dao { get; set; }

        public ViewModel()
        {
            Dao = new BL();

            Races = Enum.GetNames(typeof(Race)).ToList();

            Beers = new BindingList<IBeer>(Dao.GetData().GetBeers());
            Producents = new BindingList<IProducent>(Dao.GetData().GetProducents());

            BeerDetailsView = new BindingList<string>();
            ProducentDetailsView = new BindingList<string>();

            makeDetailsOfSelectedBeer(Beers[0]);
            makeDetailsOfSelectedProducent(Producents[0]);

            BeerToAdd = new EditedBeer(Dao.GetData().GetNewBeer());
            BeerToEdit = new EditedBeer(Dao.GetData().GetNewBeer());

            ProducentToAdd = new EditedProducent(Dao.GetData().GetNewProducent());
            ProducentToEdit = new EditedProducent(Dao.GetData().GetNewProducent());

            SelectedItemIndex = 0;

            CommandBeerListItemSelected = new CommandItemSelected(param => this.onBeerItemSelected(SelectedItemIndex));
            CommandProducentListItemSelected = new CommandItemSelected(param => this.onProducentItemSelected(SelectedItemIndex));

            CommandBeerAdd = new CommandButtons(param => this.onAddBeerClicked(BeerToAdd._beer), param => this.CanCreateBeer(BeerToAdd));  
            CommandBeerEdit = new CommandButtons(param => this.onEditBeerClicked(), param => this.CanCreateBeer(BeerToEdit));
            CommandBeerRemove = new CommandButtons(param => this.onRemoveBeerClicked(), param => this.CanRemoveBeer());

            CommandProducentAdd = new CommandButtons(param => this.onAddProducentClicked(ProducentToAdd._producent), param => this.CanCreateProducent(ProducentToAdd));
            CommandProducentEdit = new CommandButtons(param => this.onEditProducentClicked(), param => this.CanCreateProducent(ProducentToEdit));
            CommandProducentRemove = new CommandButtons(param => this.onRemoveProducentClicked(), param => this.CanRemoveProducent());

        }

        public void onAddBeerClicked(IBeer beer)
        {
            IBeer newBeer = Dao.GetData().GetNewBeer();
            AssignValuesToBeer(newBeer, beer);
            Dao.GetData().AddNewBeer(newBeer);
            Beers[0] = Beers[0];
        }

        public void onEditBeerClicked()
        {
            makeDetailsOfSelectedBeer(BeerToEdit._beer);
            AssignValuesToBeer(Beers[SelectedItemIndex], BeerToEdit._beer);
            IBeer tempBeer = Beers[SelectedItemIndex];
            Beers[SelectedItemIndex] = tempBeer;
            Dao.GetData().EditBeer(BeerToEdit._beer, SelectedItemIndex);
        }

        public void onRemoveBeerClicked()
        {
            if(SelectedItemIndex >= 0)
            {
                Beers.RemoveAt(SelectedItemIndex);
                Dao.GetData().RemoveBeer(SelectedItemIndex);
            }
        }

        public void onBeerItemSelected( int selectedIndex )
        {
            if( selectedIndex != -1)
            {
                makeDetailsOfSelectedBeer(Beers[selectedIndex]);
                AssignValuesToEditedBeer(BeerToEdit, Beers[selectedIndex]);
                SelectedItemIndex = selectedIndex;
            }                
        }

        private void AssignValuesToEditedBeer(EditedBeer newBeer, IBeer beer)
        {

            newBeer.BeerRace = beer.Race;
            newBeer.BeerSpeciality = beer.Speciality;
            newBeer.BeerProducent = beer.Producent;
            newBeer.BeerAlcohol = beer.AlcoholPercent;
            newBeer.BeerIBU = beer.IBU;
            newBeer.BeerEBC = beer.EBC;
            newBeer.BeerServingTemperature = beer.ServingTemperature;
            newBeer.BeerBLG = beer.BLG;
            newBeer.BeerBestBefore = beer.BestBefore;
            newBeer.BeerSeaStory = beer.SeaStory;
            newBeer.BeerIngredients = beer.Ingredients;

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

        private bool CanCreateBeer( EditedBeer beer)
        {
            if (!beer.HasErrors)
                return true;

            return false;
        }

        private bool CanRemoveBeer()
        {
            if ( SelectedItemIndex >= 0 && SelectedItemIndex < Beers.Count)
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

        public void onAddProducentClicked(IProducent producent)
        {
            IProducent newProducent = Dao.GetData().GetNewProducent();
            AssignValuesToProducent(newProducent, producent);
            Dao.GetData().AddNewProducent(newProducent);
            Producents[0] = Producents[0];
        }

        public void onEditProducentClicked()
        {
            makeDetailsOfSelectedProducent(ProducentToEdit._producent);
            AssignValuesToProducent(Producents[SelectedItemIndex], ProducentToEdit._producent);
            IProducent tempProducent = Producents[SelectedItemIndex];
            Producents[SelectedItemIndex] = tempProducent;
            Dao.GetData().EditProducent(ProducentToEdit._producent, SelectedItemIndex);
        }

        public void onRemoveProducentClicked()
        {
            if (SelectedItemIndex >= 0)
            {
                Producents.RemoveAt(SelectedItemIndex);
                Dao.GetData().RemoveProducent(SelectedItemIndex);            
            }
        }

        public void onProducentItemSelected(int selectedIndex)
        {
            if (selectedIndex != -1)
            {
                makeDetailsOfSelectedProducent(Producents[selectedIndex]);
                AssignValuesToEditedProducent(ProducentToEdit, Producents[selectedIndex]);
                SelectedItemIndex = selectedIndex;
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

        private void AssignValuesToEditedProducent(EditedProducent newProducent, IProducent producent)
        {

            newProducent.ProducentName= producent.Name;
            newProducent.ProducentTown = producent.Town;
            newProducent.ProducentStreet = producent.Street;
            newProducent.ProducentStreetNumber = producent.StreetNumber;
        }

        private void AssignValuesToProducent(IProducent newProducent, IProducent producent)
        {

            newProducent.Name = producent.Name;
            newProducent.Town = producent.Town;
            newProducent.Street = producent.Street;
            newProducent.StreetNumber = producent.StreetNumber;
        }

        private bool CanCreateProducent(EditedProducent producent)
        {
            if (!producent.HasErrors)
                return true;

            return false;
        }

        private bool CanRemoveProducent()
        {
            if (SelectedItemIndex >= 0 && SelectedItemIndex < Producents.Count)
                return true;

            return false;
        }


    }
}
