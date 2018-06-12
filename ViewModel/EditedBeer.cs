using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Core;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class EditedBeer : BeersViewModel
    {
        public IBeer _beer;

        public EditedBeer(IBeer beer)
        {
            _beer = beer;
        }

        [Required(ErrorMessage = "Beer Race must be set.")]
        public Race BeerRace
        {
            get { return _beer.Race; }
            set
            {
                _beer.Race = value;
                OnPropertyChanged("Race");
                Validate();
            }
        }

        [Required(ErrorMessage = "Beer must have a Speciality")]
        public Speciality BeerSpeciality
        {
            get { return _beer.Speciality; }

            set
            {
                _beer.Speciality = value;
                OnPropertyChanged("Speciality");
                Validate();
            }
        }

        //public IProducent BeerProducent
        //{
        //    get { return _beer.Producent; }

        //    set
        //    {
        //        _beer.Producent = value;
        //        OnPropertyChanged(nameof(BeerProducent));
        //        Validate();
        //    }
        //}

        public double BeerAlcohol
        {
            get { return _beer.AlcoholPercent; }

            set
            {
                _beer.AlcoholPercent = value;
                OnPropertyChanged("AlcoholPercent");
                Validate();
            }
        }
     

        public void Validate()
        {
            RemoveErrors(nameof(BeerAlcohol));
   //         RemoveErrors(nameof(Name));

            if (BeerAlcohol < 0)
            {
                AddError(nameof(BeerAlcohol), "Alcohol percent must be >= 0");
            }

            //if (ProductionYear > DateTime.Now.Year)
            //{
            //    AddError(nameof(ProductionYear), "Production Year cannot be greater than " + DateTime.Now.Year);
            //}

            //if (Name.Length < 3)
            //{
            //    AddError(nameof(Name), "Name must be longer than 2 characters");
            //}

            //if (Name.StartsWith("0"))
            //{
            //    AddError(nameof(Name), "Name cannot starts with 0");
            //}

        }
    }
}
