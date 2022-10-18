using System;

namespace Medfar.Interview.Types
{
    public class User
    {
        public Guid id { get; set; }
        public string first_name{ get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string date_created{ get; set; }

    }
}
