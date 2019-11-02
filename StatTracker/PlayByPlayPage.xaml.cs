using McKnight.StatTracker.Model;
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
    public sealed partial class PlayByPlayPage : Page
    {
        private Game game;
        private bool togglePitches = false;
        public PlayByPlayPage()
        {
            this.InitializeComponent();
        }

        public Game Game
        {
            get { return this.game; }
            set { this.game = value; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.Game = (Game)e.Parameter;
            base.OnNavigatedTo(e);
        }

        public bool TogglePitches
        {
            get { return togglePitches; }
            set { this.togglePitches = value;  }
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            this.TogglePitches = !this.TogglePitches;
        }
    }
}
