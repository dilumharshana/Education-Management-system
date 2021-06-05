using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace Education_Center
{
    class streamincome
    {
        public int[] getData(String month , String year)
        {

            int[] data = new int[5];

            String[] strms = { "Science", "Commerce", "Art", "Technology", "Common"};

            for (int i = 0; i <5; i++)
            {
                try {
                    var recs = months<mark_feesr>(strms[i] , month , year);

                    foreach (var rec in recs)
                    {

                        data[i] += Int16.Parse(rec.fees);
                    }
                }
                catch (Exception e)
                {
                    error.errorNow(e.ToString() + "in class graphs-> streamincome [ NORMAL SITUATION ]");
                }
            }

            return data;
        }

        public int[] getDataY( String year)
        {

            int[] data = new int[5];

            String[] strms = { "Science", "Commerce", "Art", "Technology", "Common" };

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    var recs = years<mark_feesr>(strms[i], year);

                    foreach (var rec in recs)
                    {

                        data[i] += Int16.Parse(rec.fees);
                    }
                }
                catch (Exception e)
                {
                    error.errorNow(e.ToString() + "in class graphs->streamincomne [ NORMAL SITUATION ]");
                }
            }

            return data;
        }

        //get income for month
        public List<T> months<T>(String stream , String month , String year)
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("fees");

            var builder = Builders<T>.Filter;

            var filter1 = builder.Eq("stream", stream)  & builder.Eq("month", month) & builder.Eq("year", year);

            return std.Find(filter1).ToList();
        }


        //get income for year
        public List<T> years<T>(String stream,  String year)
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("fees");

            var builder = Builders<T>.Filter;

            var filter1 = builder.Eq("stream", stream) &  builder.Eq("year", year);

            return std.Find(filter1).ToList();
        }
    }
}
