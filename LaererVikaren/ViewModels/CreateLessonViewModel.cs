using LaererVikaren.Commands;
using LaererVikaren.Models;
using LaererVikaren.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Input;

namespace LaererVikaren.ViewModels
{
    public class CreateLessonViewModel : BaseRegisterViewModel<Substitute>
    {

        public ObservableCollection<SubstituteViewmodel> SubstituteVM { get; set; }

        private DateTime? _lessonDate = DateTime.Today;
        public DateTime? LessonDate
        {
            get => _lessonDate;
            set
            {
                if (_lessonDate == value) return;
                _lessonDate = value;
                OnPropertyChanged();
            }
        }

        private int _timeframe;
        public int Timeframe
        {
            get => _timeframe;
            set
            {
                if (_timeframe == value) return;
                _timeframe = value;
                OnPropertyChanged();
            }
        }

        private string _subject = string.Empty;
        public string Subject
        {
            get => _subject;
            set
            {
                if (_subject == value) return;
                _subject = value;
                OnPropertyChanged();
            }
        }

        public CreateLessonViewModel() : base(new SubstituteRepository())
        {
            SubstituteVM = new ObservableCollection<SubstituteViewmodel>();
        }

        public ICommand FindMatchingSubstitute { get; } = new FindMatchingSubstitute();

        public override bool CheckEntity()
        {
            bool result = true;
            if (Timeframe < 1 || Timeframe > 3)
            {
                result = false;
            }
            if (string.IsNullOrWhiteSpace(Subject))
            {
                result = false;
            }

            return result;

        }

        public void FindMatchingSub()
        {
            if (entityRepo is SubstituteRepository repo)
            {
                List<Substitute> substitutes = repo.GetMatchingSubstitutes(LessonDate, Timeframe, Subject);
                UpdateSubstituteVM(substitutes);
            }
            else
            {
                throw new InvalidOperationException("Repository is not a SubstituteRepository.");
            }
        }

        public void UpdateSubstituteVM(List<Substitute> substitutes)
        {
            try
            {
                SubstituteVM.Clear();
                foreach (Substitute sub in substitutes)
                {
                    SubstituteViewmodel SVM = new(sub);
                    SubstituteVM.Add(SVM);
                }
            }
            catch (IOException e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}

