using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace SgsTestProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<string> _sity_content = new List<string>();
        private List<string> _facility_content = new List<string>();
        private List<string> _staff_content = new List<string>();
        private List<string> _team_content = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 1; i < 33; i++)
            {
                if (i <= 4) _sity_content.Add($"Sity {i}");
                if (i <= 8) _facility_content.Add($"Facility {i}");
                if (i <= 16) _team_content.Add($"Team {i}"); 
                _staff_content.Add($"Staff {i}");
            }


            sity_CB.ItemsSource = _sity_content;
            facility_CB.ItemsSource = _facility_content;
            staff_CB.ItemsSource = _staff_content;
            team_CB.ItemsSource = _team_content;

        }

        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var parent = sender as ComboBox;

            if (parent.SelectedValue == null) return;

            var from = (Convert.ToInt32(parent.SelectedValue.ToString().Split(' ').Last())  * 2) - 1;
            var to = from + 1;


            switch (parent.Name)
            {
                case "sity_CB":
                    
                    facility_CB.ItemsSource = _facility_content.Where(p => Convert.ToInt32(p.Split(' ').Last()) >= from && (Convert.ToInt32(p.Split(' ').Last()) <= to));
                    from = (from * 2) -1;
                    to = from + 1;

                    team_CB.ItemsSource = _team_content.Where(p => Convert.ToInt32(p.Split(' ').Last()) >= from && (Convert.ToInt32(p.Split(' ').Last()) <= to + 2));
                    from = (from * 2) - 1;
                    to = from + 1;

                    staff_CB.ItemsSource = _staff_content.Where(p => Convert.ToInt32(p.Split(' ').Last()) >= from && (Convert.ToInt32(p.Split(' ').Last()) <= to + 6));

                    break;
                case "facility_CB":

                    team_CB.ItemsSource = _team_content.Where(p => Convert.ToInt32(p.Split(' ').Last()) >= from && (Convert.ToInt32(p.Split(' ').Last()) <= to));
                    from = (from * 2) - 1;
                    to = from + 1;

                    staff_CB.ItemsSource = _staff_content.Where(p => Convert.ToInt32(p.Split(' ').Last()) >= from && (Convert.ToInt32(p.Split(' ').Last()) <= to + 2));

                    break;
                case "team_CB":

                    staff_CB.ItemsSource = _staff_content.Where(p => Convert.ToInt32(p.Split(' ').Last()) >= from && (Convert.ToInt32(p.Split(' ').Last()) <= to));

                    break;
                case "staff_CB":

                    

                    break;
                
            }
            
            


        }
    }
}
