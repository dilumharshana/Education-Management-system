using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Education_Center
{
    class incomemonthly
    {
        public int[] getMonths()
        {

            int[] data = new int[12];

            String[] days = { "January", "February", "March", "April", "May", "June", "July" , "August" , "September" , "Octomber" , "November" ,"December"};

            for (int i = 0; i < 12; i++)
            {
                try {
                    var recs = months<mark_feesr>(days[i]);

                    foreach (var rec in recs)
                    {

                        data[i] += Int16.Parse(rec.fees);
                        
                    }
                }
                catch (Exception e)
                {
                    error.errorNow(e.ToString() + "in class class_attend [ NORMAL SITUATION ]");
                }
            }

            return data;
        }

        public List<T> months<T>(String month)
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("fees");

            var builder = Builders<T>.Filter;

            var filter1 = builder.Eq("month", month);

            return std.Find(filter1).ToList();
        }

    }
}
