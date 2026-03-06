using LaererVikaren.Models;
using LaererVikaren.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaererVikaren.ViewModels
{
    public class SubstituteViewmodel : TEntityViewModelBase<Substitute>
    {
        private string _firstName = string.Empty;
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName == value) return;
                _firstName = value;
                OnPropertyChanged();
            }
        }

        private string _lastName = string.Empty;
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName == value) return;
                _lastName = value;
                OnPropertyChanged();
            }
        }

        private int _phoneNumber;
        public int PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (_phoneNumber == value) return;
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }


        public SubstituteViewmodel(Substitute substitute) : base(substitute)
        {
            this.FirstName = substitute.FirstName;
            this.LastName = substitute.LastName;
            this.PhoneNumber = substitute.PhoneNumber;
        }
    }
}
