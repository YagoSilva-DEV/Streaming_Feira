using Streamall.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.ViewModels
{
    internal class ErrorControlViewModel : ViewModelBase
    {
        public RelayCommand CloseWindowCommand { get; set; }
        private string _errorType;

		public string ErrorType
		{
			get { return _errorType; }
			set 
			{
				_errorType = value;
				OnPropertyChanged();
			}
		}

		private string _errorMessage;

		public string ErrorMessage
        {
			get { return _errorMessage; }
			set 
			{
				_errorMessage = value;
				OnPropertyChanged();
			}
		}

		public ErrorControlViewModel(string errorType, string errorMessage, Action closeWindow)
		{
			ErrorType = errorType;
			ErrorMessage = errorMessage;

			CloseWindowCommand = new RelayCommand(execute => closeWindow.Invoke());
		}

	}
}
