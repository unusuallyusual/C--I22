using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOP2
{
    /// <summary>
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        private readonly string path = System.IO.Path.GetFullPath(@"..\..\..\db");
        private Worker currentWorker;
        private Repository data;
        private List<Client> withNewClient = new List<Client>();

        public WorkWindow(object someWorker)
        {
            InitializeComponent();
            data = Repository.CreateRepository(path);
            cbDepartment.ItemsSource = data.DepartmentsDb;
                
            if (someWorker.GetType() == typeof(Consultant))
                currentWorker = new Consultant();
            else
            if (someWorker.GetType() == typeof(Manager))
                currentWorker = new Manager();
            data.ClientsDb = currentWorker.ShowData(data.ClientsDb);
            //может нужно создать резервный лист клиентов???
            availabilityData(currentWorker);
        }
        
        private void btnRef(object sender, RoutedEventArgs e)
        {
            cbDepartment.Items.Refresh();
            lvClients.Items.Refresh();
        }

        private void btnAddClient(object sender, RoutedEventArgs e)
        {
            withNewClient.Add(new Client());
            lvClients.ItemsSource = string.Empty;
            lvClients.ItemsSource = withNewClient;
        }

        private void btnSave(object sender, RoutedEventArgs e)
        {
            //сохраняет данные паспорта для консультанта в виде звездочек!!
            string pathChanges = $"{path}\\{(cbDepartment.SelectedItem as Department).DepartmentName}";
            File.WriteAllText(pathChanges, string.Empty);
            foreach (Client client in withNewClient)
            {
                client.DepartamentName = (cbDepartment.SelectedItem as Department).DepartmentName;
                client.RecToFile(pathChanges);
            }
        }

        private void CbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnUpdate.IsEnabled = true;
            btnSaveChanges.IsEnabled = true;
            if (currentWorker.GetType() == typeof(Manager))
                btnCreatNew.IsEnabled = true;
            lvClients.ItemsSource = data.ClientsDb.Where(find);
            withNewClient = data.ClientsDb.Where(find).ToList();
        }
        
        private bool find(Client arg)
        {
            return arg.DepartamentName == (cbDepartment.SelectedItem as Department).DepartmentName;
        }
        /// <summary>
        /// Доступность полей с данными
        /// </summary>
        private void availabilityData(object currentWorker)
        {
            if (currentWorker.GetType() == typeof(Consultant))
            {
                textSurname.IsEnabled = false;
                textName.IsEnabled = false;
                textPatronymic.IsEnabled = false;
                textPassport.IsEnabled = false;
            }
        }
        
    }
}
