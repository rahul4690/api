using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models.ViewModels
{
    public class ResponseListObject<T>
    {
        public ResponseListObject()
        {
            data = new List<T>();
        }
        public bool status { get; set; }
        public string message { get; set; }
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public int totalCount { get; set; }
        public int totalPages { get; set; }
        public IList<T> data { get; set; }
    }

    public class ResponseObject
    {
        public bool status { get; set; }
        public string message { get; set; }

    }

    public class AnalyticsObject
    {
        public int totalUsersCount { get; set; }
    }

}
