using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections;

namespace ViewModel
{
    public class EditedProducent : INotifyDataErrorInfo, INotifyPropertyChanged
    {
        public IProducent _producent;

        public EditedProducent(IProducent producent)
        {
            _producent = producent;
        }

        [Required(ErrorMessage = "Producent's name must be set.")]
        public string ProducentName
        {
            get { return _producent.Name; }
            set
            {
                _producent.Name = value;
                OnPropertyChanged(nameof(ProducentName));
                Validate();
            }
        }

        [Required(ErrorMessage = "Producent must have a town")]
        public string ProducentTown
        {
            get { return _producent.Town; }

            set
            {
                _producent.Town = value;
                OnPropertyChanged(nameof(ProducentTown));
                Validate();
            }
        }

        [Required(ErrorMessage = "Producent must have a street name")]
        public string ProducentStreet
        {
            get { return _producent.Street; }

            set
            {
                _producent.Street = value;
                OnPropertyChanged(nameof(ProducentStreet));
                Validate();
            }
        }

        [Range(0, int.MaxValue, ErrorMessage = "Producent's street number cannot be negative.")]
        [Required(ErrorMessage = "Street number must have a value")]
        public int ProducentStreetNumber
        {
            get { return _producent.StreetNumber; }

            set
            {
                _producent.StreetNumber = value;
                OnPropertyChanged(nameof(ProducentStreetNumber));
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
