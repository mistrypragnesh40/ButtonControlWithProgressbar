using IntelliJ.Lang.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ButtonControlWithProgressbar.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        private bool _isBusy;
        public  bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private string _buttonText = "Click me";
        public string ButtonText
        {
            get => _buttonText;
            set => SetProperty(ref _buttonText, value);
        }

        private int _count;

        #region Commands
        public ICommand ButtonClickCommand => new Command(async () =>
        {
            IsBusy = true;
            _count++;
            await Task.Delay(500);
            ButtonText = $"Clicked {_count} time";
            IsBusy = false;
        });
        #endregion
    }
}
