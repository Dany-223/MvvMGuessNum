using MvvMGuessNum.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace MvvMGuessNum.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public GameViewModel()
        {
            GuessCommand = new RelayCommand(GuessNum);
            NewGameCommand = new RelayCommand(NewGame);
        }

        public ICommand GuessCommand {  get;  }
        public ICommand NewGameCommand {  get; }
        
        public bool IsEnable
        {
            get => field;
            set
            {
                field = value;
                OnPropertyChanged(nameof(IsEnable));
            }
        } = true;

        public int RandomNum
        {
            get => field;
            set
            {
                field = value;
                OnPropertyChanged(nameof(RandomNum));
            }
        }

        public string Message
        {
            get => field;
            set
            {
                field = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public string Enter
        {
            get => field;
            set
            {
                field = value;
                OnPropertyChanged(nameof(Enter));
            }
        }

        public int Popitka
        {
            get => field;
            set
            {
                field = value;
                OnPropertyChanged(nameof(Popitka));
            }
        } = 5;

        private void NewGame(object parametr)
        {
            IsEnable = true;
            Popitka = 5;
            Message = "";
        }

        private void GuessNum(object parametr)
        {
            GenerateNum();
            if (RandomNum < int.Parse(Enter))
            {
                Message = $"<{int.Parse(Enter)}";
                Popitka -= 1;
            }
            if (RandomNum > int.Parse(Enter))
            {
                Message = $">{int.Parse(Enter)}";
                Popitka -= 1;
            }
            if (RandomNum == int.Parse(Enter))
            {
                Message = $"={RandomNum}";
                IsEnable = false;
            }
            if (Popitka == 0)
            {
                Message = "0 пт";
                IsEnable = false;
            }
        }

        private int GenerateNum()
        {
            Random rand = new Random();
            RandomNum = rand.Next(1, 101);
            return RandomNum;
        }

        private bool CanGuess(object parametr)
        {
            return !string.IsNullOrEmpty(parametr.ToString());
        }
        
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
