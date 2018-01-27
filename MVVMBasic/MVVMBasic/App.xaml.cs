using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MVVMBasic.ViewModel;
using Xamarin.Forms;

namespace MVVMBasic
{
	public partial class App : Application
	{
        public static AlunoViewModel AlunoVM { get;  set; }

        public App ()
		{

			InitializeComponent();
            InitializeApplication();

            MainPage = new NavigationPage(new View.AlunoView() { BindingContext = App.AlunoVM, BackgroundColor = Color.Beige });
            
      

        }

        private void InitializeApplication()
        {
            // throw new NotImplementedException();
            if (AlunoVM == null) AlunoVM = new AlunoViewModel();
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
