using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using McKnight.StatTracker.Model;

namespace McKnight.StatTracker
{
    public class FranchiseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Franchise franchise = (Franchise)value;
            return string.Format("{0} {1}", franchise.Location, franchise.Nickname);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
