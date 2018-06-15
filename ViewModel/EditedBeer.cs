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
    public class EditedBeer : INotifyDataErrorInfo, INotifyPropertyChanged
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
                OnPropertyChanged(nameof(BeerRace));
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
                OnPropertyChanged(nameof(BeerSpeciality));
                Validate();
            }
        }

        [Required(ErrorMessage = "Beer must have a Producent")]
        public IProducent BeerProducent
        {
            get { return _beer.Producent; }

            set
            {
                _beer.Producent = value;
                OnPropertyChanged(nameof(BeerProducent));
                Validate();
            }
        }

        [Range(0, double.MaxValue, ErrorMessage = "Beer alcohol cannot be negative.")]
        [Required(ErrorMessage = "Alcohol must have a value")]
        public double BeerAlcohol
        {
            get { return _beer.AlcoholPercent; }

            set
            {
                _beer.AlcoholPercent = value;
                OnPropertyChanged(nameof(BeerAlcohol));
                Validate();
            }
        }

        [Range(0, int.MaxValue, ErrorMessage = "IBU cannot be negative.")]
        [Required(ErrorMessage = "Beer must have a IBU")]
        public int BeerIBU
        {
            get { return _beer.IBU; }

            set
            {
                _beer.IBU = value;
                OnPropertyChanged(nameof(BeerIBU));
                Validate();
            }
        }

        [Range(0, int.MaxValue, ErrorMessage = "EBC cannot be negative.")]
        public int BeerEBC
        {
            get { return _beer.EBC; }

            set
            {
                _beer.EBC = value;
                OnPropertyChanged(nameof(BeerEBC));
                Validate();
            }
        }

        [Range(0, int.MaxValue, ErrorMessage = "Serving temperature cannot be negative.")]
        public int BeerServingTemperature
        {
            get { return _beer.ServingTemperature; }

            set
            {
                _beer.ServingTemperature = value;
                OnPropertyChanged(nameof(BeerServingTemperature));
                Validate();
            }
        }

        [Range(0, double.MaxValue, ErrorMessage = "BLG cannot be negative.")]
        public double BeerBLG
        {
            get { return _beer.BLG; }

            set
            {
                _beer.BLG = value;
                OnPropertyChanged(nameof(BeerBLG));
                Validate();
            }
        }

        [Required(ErrorMessage = "Beer must have a date")]
        public DateTime BeerBestBefore
        {
            get { return _beer.BestBefore; }

            set
            {
                _beer.BestBefore = value;
                OnPropertyChanged(nameof(BeerBestBefore));
                Validate();
            }
        }

        public string BeerSeaStory
        {
            get { return _beer.SeaStory; }

            set
            {
                _beer.SeaStory = value;
                OnPropertyChanged(nameof(BeerSeaStory));
                Validate();
            }
        }

        [Required(ErrorMessage = "Beer must have some ingredients")]
        public string BeerIngredients
        {
            get { return _beer.Ingredients; }

            set
            {
                _beer.Ingredients = value;
                OnPropertyChanged(nameof(BeerIngredients));
                Validate();
            }
        }

        public void Validate()
        {
            var validationContext = new ValidationContext(this, null, null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(this, validationContext, validationResults, true);

            foreach (var kv in _errors.ToList())
            {
                if (validationResults.All(r => r.MemberNames.All(m => m != kv.Key)))
                {
                    _errors.Remove(kv.Key);
                    RaiseErrorChanged(kv.Key);
                }
            }

            var q = from r in validationResults
                    from m in r.MemberNames
                    group r by m into g
                    select g;

            foreach (var prop in q)
            {
                var messages = prop.Select(r => r.ErrorMessage).ToList();

                if (_errors.ContainsKey(prop.Key))
                {
                    _errors.Remove(prop.Key);
                }
                _errors.Add(prop.Key, messages);

                RaiseErrorChanged(prop.Key);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        protected void AddError(string propertyName, string errorMessage)
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
            propertyErrors.Add(errorMessage);
        }

        protected void RemoveErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
            }
        }

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
        protected void RaiseErrorChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
