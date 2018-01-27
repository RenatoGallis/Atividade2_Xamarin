using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMBasic.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NovoAlunoView : ContentPage
	{
		public NovoAlunoView ()
		{
			InitializeComponent ();
            BackgroundColor = Color.Beige;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            txtNome.Text = txtRM.Text = txtEmail.Text = string.Empty;
        }
    }
}