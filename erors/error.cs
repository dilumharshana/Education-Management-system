using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Education_Center
{
    class error
    {
        public static void errorNow(String erroris)
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<errorW>("errorlist");

            var errorReport = new errorW
            {
                error = erroris,
            };

            std.InsertOne(errorReport);
        }

    }
}

class errorW
{
    public String error { get; set; }
}

class errorR
{
    public object _id { get; set; }
    public String error { get; set; }
}
