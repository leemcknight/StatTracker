using McKnight.StatTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace McKnight.StatTracker
{
    public class UriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Franchise franchise = (Franchise)value;
            return new Uri("ms-appx:///Data/franchises/img/svg/" + franchise.CurrentFranchiseId + ".svg");
            //return new Uri("ms-appx:///Data/franchises/img/svg/CHN.svg");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
