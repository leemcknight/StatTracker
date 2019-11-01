﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using McKnight.StatTracker.Model;

namespace McKnight.StatTracker
{
    class PersonNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Person person = (Person)value;
            return string.Format("{0} {1}", person.FirstName, person.LastName);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
