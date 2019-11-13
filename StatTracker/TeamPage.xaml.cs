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
using McKnight.StatTracker.Model;
using McKnight.StatTracker.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace McKnight.StatTracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TeamPage : Page
    {
        private IEnumerable<Franchise> allFranchises;

        public TeamPage()
        {
            this.InitializeComponent();
        }

        public IEnumerable<Franchise> Franchises {  get 
            {
                if(allFranchises == null)
                {
                    allFranchises = new FranchiseReader().Read();
                }
                return allFranchises.Where(franchise => franchise.LastGame > DateTime.Now); } 
        }

        private IEnumerable<Franchise> franchiseHistory;
        public IEnumerable<Franchise> FranchiseHistory { get { return franchiseHistory; } }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridView lv = (GridView)sender;
            if(lv.SelectedItem == null)
            {
                return;
            }
            franchiseHistory = allFranchises.Where(franchise => franchise.CurrentFranchiseId == ((Franchise)lv.SelectedItem).CurrentFranchiseId);
            lvHistory.ItemsSource = franchiseHistory;
        }
    }
}
