using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MVVMBasic.Model;
using MVVMBasic.View;
namespace MVVMBasic.ViewModel
{

   public class AlunoViewModel  : INotifyPropertyChanged
    {
        public Aluno AlunoModel { get; set; }

        public ObservableCollection<Aluno> Alunos { get; set; } = new ObservableCollection<Aluno>();

        public OnAdicionarAlunoCMD OnAdicionarAlunoCMD { get; }
        public ICommand OnNovoCMD { get; private set; }
        public ICommand OnSairCMD { get; private set; }

        public AlunoViewModel()
        {
            AlunoModel = new Aluno();
            OnAdicionarAlunoCMD = new OnAdicionarAlunoCMD(this);
            OnSairCMD = new Command(OnSair);
            OnNovoCMD = new Command(OnNovo);
        }

     

        internal void Adicionar(Aluno aluno)
        {
            // throw new NotImplementedException();
            try {

                if (aluno == null)
                    throw new Exception("Usuário inválido");
                aluno.Id = Guid.NewGuid();
                Alunos.Add(aluno);
                App.Current.MainPage.Navigation.PopAsync();
            } catch (Exception) {
                App.Current.MainPage.DisplayAlert("Falhou", "Desculpe, ocorreu um erro inesperado =(", "OK");
            }
        }

        private async void OnSair()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void OnNovo()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NovoAlunoView() { BindingContext = App.AlunoVM });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
   public class OnAdicionarAlunoCMD : ICommand
    {

        private AlunoViewModel alunoVM;

        public OnAdicionarAlunoCMD(AlunoViewModel paramVM)
        {
            alunoVM = paramVM;

        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            if (parameter != null) return true;

            return false;
        }

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
            alunoVM.Adicionar(parameter as Aluno);
        }   

    }
}
