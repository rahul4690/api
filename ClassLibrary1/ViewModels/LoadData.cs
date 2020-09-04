using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models.ViewModels
{
    public class ResponseListObject<T>
    {
        public ResponseListObject()
        {
            loadData = new List<T>();
        }
        public bool status { get; set; }
        public string message { get; set; }
    
        public IList<T> loadData { get; set; }
    }

    public class ResponseObject
    {
        public bool status { get; set; }
        public string message { get; set; }
    }

    public class AnalyticsObject
    {
        public int userCount { get; set; }
    }
}
