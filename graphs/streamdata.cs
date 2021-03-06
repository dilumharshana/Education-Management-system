using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Education_Center
{
    public struct Data
    {
        public List<string> strms;
        public int[] amount;
    }


    class streamdata
    {


        public Data getData(String streamis) {


            List<String> subsofstreams = new List<string>();



            var subs = subjects<subjectr>(streamis);

            if (streamis == "Common")
            {
                subs = subjects<subjectr>(streamis);
            }

            foreach(var sub in subs)
            {
                //cheking if subject name existing in array cuz we dont want to get both grade 12 & 13 we just wnat to subjects only

                if (!subsofstreams.Contains(sub.name)) {
                    subsofstreams.Add(sub.name);
                }
                
            }


            int[] data = new int[subsofstreams.Count]; // arrays to hold number of students for each subjects

            for (int i=0; i< subsofstreams.Count; i++)
            {
                var recs = students<studentr>(subsofstreams[i]);

                foreach (var rec in recs)
                {
                    
                    data[i] += 1;
                }
            }

            Data senddata = new Data();
            senddata.strms = subsofstreams;
            senddata.amount = data;

            return senddata;
        }


        //getting number of students that followong the subject
        public List<T> subjects<T>(String stream)
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("subjects");

             var builder = Builders<T>.Filter;

            var filter1 = builder.Eq("stream", stream);

            return std.Find(filter1).ToList();
        }

        //getting number of students that followong the subject
        public List<T> commonsubjects<T>(String stream)
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("subjects");

            var builder = Builders<T>.Filter;

            var filter1 = builder.Eq("name", "ICT") | builder.Eq("name", "English");

            return std.Find(filter1).ToList();
        }

        public List<T> students<T>(String subject)
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("al_students");

            var builder = Builders<T>.Filter;

            var filter1 = builder.Eq("sub1", subject) | builder.Eq("sub2", subject)  | builder.Eq("sub3", subject);

            return std.Find(filter1).ToList();
        }
    }

    

}
