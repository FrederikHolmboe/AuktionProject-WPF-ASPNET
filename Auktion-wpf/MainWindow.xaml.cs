using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AuktionsEntity.Model;

namespace Auktion_wpf
{
    delegate void RefreshDelegate(ListView l1);
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AuktionsEntities context = new AuktionsEntities();
        CollectionViewSource auktionViewSource;
        public MainWindow()
        {
            InitializeComponent();
            auktionViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("salgsudbudSetViewSource")));

            DataContext = this;




        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource salgsudbudSetViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("salgsudbudSetViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // salgsudbudSetViewSource.Source = [generic data source]
            context.SalgsudbudSet.Load();

            auktionViewSource.Source = context.SalgsudbudSet.Local;

            Thread t = new Thread(new ThreadStart(RefreshListen));
            t.Start();
        }

       

        private void RefreshListen()
        {
            while (true)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    auktionViewSource.View.Refresh();
                }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
                Thread.Sleep(1000);
            }
        }

        private void OnWindowclose(object sender, EventArgs e)
        {
            //For at slippe for de trælse tråde der kører forevigt
            Environment.Exit(Environment.ExitCode);
        }




    



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var b1 = new SalgsudbudSet();
            b1.Maengde = Int32.Parse(createMængde.Text);
            b1.Type = createType.Text;
            b1.Tidsfrist = (DateTime)createDate.SelectedDate;
            
            context.SalgsudbudSet.Add(b1);
            context.SaveChanges();
            auktionViewSource.View.Refresh();

        }
    }
}
