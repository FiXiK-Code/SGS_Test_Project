using SgsTestProject.Data;
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

        private List<Sity> _sity_content = new List<Sity>();
        private List<Facility> _facility_content = new List<Facility>();
        private List<Team> _team_content = new List<Team>();
        private List<string> _staff_content = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 1; i < 5; i++)
            {
                _sity_content.Add(new Sity
                {
                    Id = i,
                    Name = $"Sity {i}"
                });
            }

            var buferId = 1;
            for (int i = 1; i < 9; i++)
            {
                _facility_content.Add(new Facility
                {
                    Id = i,
                    Name = $"Facility {i}",
                    SityId = buferId
                });
                if(i % 2 == 0) { buferId++; }
            }

            buferId = 1;
            for (int i = 1; i < 17; i++)
            {
                _team_content.Add(new Team
                {
                    Id = i,
                    Name = $"Team {i}",
                    FacilityId = buferId
                });
                if (i % 2 == 0) { buferId++; }
            }

            for (int i = 1; i < 33; i++)
            {
                _staff_content.Add($"Staff {i}");
            }
            


            sity_CB.ItemsSource = _sity_content.Select(p => p.Name);
            facility_CB.ItemsSource = _facility_content.Select(p => p.Name);
            team_CB.ItemsSource = _team_content.Select(p => p.Name);
            staff_CB.ItemsSource = _staff_content;

        }

        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var parent = sender as ComboBox;

            if (parent.SelectedValue == null) return;

            var selected = Convert.ToInt32(parent.SelectedValue.ToString().Split(' ').Last());


            switch (parent.Name)
            {
                case "sity_CB":

                    var facility_content = _facility_content.Where(p => p.SityId == selected);

                    facility_CB.ItemsSource = facility_content.Select(p => p.Name);
                   
                    team_CB.ItemsSource = _team_content.Where(p => facility_content.Select(o => o.Id).Contains(p.FacilityId)).Select(p => p.Name);

                    break;
                case "facility_CB":

                    var team_content = _team_content.Where(p => p.FacilityId == selected);

                    team_CB.ItemsSource = team_content.Select(p => p.Name);

                    if (sity_CB.SelectedValue == null)
                    {
                        var selectedObject = _facility_content.FirstOrDefault(p => p.Id == selected);
                        sity_CB.ItemsSource = _sity_content.Where(p => p.Id == selectedObject.SityId).Select(p => p.Name);
                    }

                    break;
                case "team_CB":

                    if (facility_CB.SelectedValue == null)
                    {
                        var selectedObject = _team_content.FirstOrDefault(p => p.Id == selected);
                        facility_CB.ItemsSource = _facility_content.Where(p => p.Id == selectedObject.FacilityId).Select(p => p.Name);
                    }
                    if (sity_CB.SelectedValue == null)
                    {
                        var selectedObject = _team_content.FirstOrDefault(p => p.Id == selected);
                        var selectedParent = _facility_content.FirstOrDefault(p => p.Id == selectedObject.FacilityId);
                        sity_CB.ItemsSource = _sity_content.Where(p => p.Id == selectedParent.SityId).Select(p => p.Name);
                    }

                    break;
               
                
            }
            
            


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sity_CB.SelectedValue = null;
            sity_CB.ItemsSource = _sity_content.Select(p => p.Name);

            facility_CB.SelectedValue = null;
            facility_CB.ItemsSource = _facility_content.Select(p => p.Name);

            team_CB.SelectedValue = null;
            team_CB.ItemsSource = _team_content.Select(p => p.Name);

            staff_CB.SelectedValue = null;
            staff_CB.ItemsSource = _staff_content;
        }
    }
}
