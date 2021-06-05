using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Education_Center
{
    class weekclasses
    {
        public int[] getclassess() {

            int[] data = new int[7];

            String[] days = { "Sunday" , "Monday" , "Tuesday" , "Wednesday" , "Thursday" , "Friday" , "Saturday"};

            for (int i=0; i<7; i++)
            {
                var recs = subjects<subjectr>(days[i]);

                foreach (var rec in recs)
                {
                    data[i] += 1;
                }
            }

         return data;
        }

        public List<T> subjects<T>(String day)
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("subjects");

             var builder = Builders<T>.Filter;

            var filter1 = builder.Eq("day", day);

            return std.Find(filter1).ToList();
        }
    }

    

}
