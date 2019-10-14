using McKnight.StatTracker.Model;
using McKnight.StatTracker.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace McKnight.StatTracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SchedulePage : Page
    {
        private IEnumerable<Schedule> schedules;

        public SchedulePage()
        {
            this.InitializeComponent();
            
        }

        public IEnumerable<Franchise> Teams
        {
            get { return new FranchiseReader().Read(); }
        }

        public IEnumerable<int> Years
        {
            get { return Enumerable.Range(1877, 141); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Schedules = new ScheduleReader()
                .ForYear((int)cboYear.SelectedValue)
                .ForTeam(((Franchise)cboTeams.SelectedItem).CurrentFranchiseId)
                .Read();
        }

        public IEnumerable<Schedule> Schedules
        {
            get { return this.schedules; }
            set {
                this.schedules = value;
                this.lvSchedule.ItemsSource = this.schedules;
            }
        }

        private void btnBoxScore_Click(object sender, RoutedEventArgs e)
        {
            Schedule schedule = (Schedule)((Button)e.OriginalSource).Tag;
            BoxScore boxScore = new BoxScoreReader()
                .ForGameNumber(schedule.GameNumber)
                .ForTeam(schedule.HomeTeamId)
                .ForDate(schedule.Date.Value)
                .Read()

                .FirstOrDefault();
            this.Frame.Navigate(typeof(BoxScorePage), boxScore);
        }

        private void btnPlays_Click(object sender, RoutedEventArgs e)
        {
            Schedule schedule = (Schedule)((Button)e.OriginalSource).Tag;
            Game game = new GameReader()
                .ForGameNumber(schedule.GameNumber)
                .ForHomeTeam(schedule.HomeTeamId, schedule.HomeTeamLeague.Substring(0,1))
                .ForDate(schedule.Date.Value)
                .Read();
            this.Frame.Navigate(typeof(PlayByPlayPage), game);
        }
    }
}
