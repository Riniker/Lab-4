using System;
using Realms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RealmApp3
{
    public partial class MainPage : ContentPage
    {
        private Realm _realm;

        public MainPage()
        {
            InitializeComponent();
            _realm = Realm.GetInstance();
        }
        protected override void OnAppearing()
        {
            companyList.ItemsSource = _realm.All<Company>();
            base.OnAppearing();
        }
        // обработка нажатия элемента в списке
        private async void TapItem(object sender, ItemTappedEventArgs e)
        {
            Company selectedCompany = (Company)e.Item;
            CompanyPage companyPage = new CompanyPage
            {
                BindingContext = selectedCompany
            };
            await Navigation.PushAsync(companyPage);
        }
        // обработка нажатия кнопки добавления
        private async void CreateCompany(object sender, EventArgs e)
        {
            CompanyPage companyPage = new CompanyPage
            {
                BindingContext = new Company()
            };
            await Navigation.PushAsync(companyPage);
        }
    }
}
