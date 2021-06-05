using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Education_Center
{
    class registerddata
    {
        public int[] getMonths()
        {

            int[] data = new int[12];

            String[] days = { "January", "February", "March", "April", "May", "June", "July" , "August" , "September" , "Octomber" , "November" ,"December"};

            for (int i = 0; i < 12; i++)
            {
                try {
                    var recs = months<studentr>(days[i]);

                    foreach (var rec in recs)
                    {

                        data[i] += 1;
                    }
                }
                catch (Exception e)
                {
                    error.errorNow(e.ToString() + "in class graphs-> registerddata [ NORMAL SITUATION ]");
                }
            }

            return data;
        }

        public List<T> months<T>(String month)
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("al_students");

            var builder = Builders<T>.Filter;

            var filter1 = builder.Eq("admitionmonth", month);

            return std.Find(filter1).ToList();
        }

    }
}
