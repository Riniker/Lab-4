using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealmApp3
{
    public partial class CompanyPage : ContentPage
    {
        Realm _realm;
        Transaction _transaction;

        public CompanyPage()
        {
            InitializeComponent();
            _realm = Realm.GetInstance();
            _transaction = _realm.BeginWrite();
        }

        private void SaveCompany(object sender, EventArgs e)
        {
            var company = (Company)BindingContext;
            if (!String.IsNullOrEmpty(company.Name))
            {
                if (company.Id == null)
                {
                    company.Id = Guid.NewGuid().ToString();
                    _realm.Add(company);
                }

                _transaction.Commit();
            }
            this.Navigation.PopAsync();
        }
        private void DeleteCompany(object sender, EventArgs e)
        {
            var company = (Company)BindingContext;
            _realm.Remove(company);
            _transaction.Commit();

            this.Navigation.PopAsync();
        }

        protected override void OnDisappearing()
        {
            _transaction?.Dispose();
            base.OnDisappearing();
        }
    }
}