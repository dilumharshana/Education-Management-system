using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Education_Center
{
        class mongo
        {
            public static void main(String [] args)
            {
            insert data = new insert();
            data.insertR(new person {firstName="dilum" , lastName = "harshana" });

            }
        }

    class mongodb
    {
        public MongoClient getcon()
        {
            MongoClient connect = new MongoClient();
          
            return connect;
        }

    }

    class person 
    {
        public String firstName { get; set; }
        public String lastName { get; set; }


    }

    class insert
    {
        public void insertR<T>( T recod)
           {
            mongodb ob = new mongodb();
            var connect = ob.getcon();
            var db = connect.GetDatabase("educationCenter");
            var col = db.GetCollection<T>("al_students");

            col.InsertOne(recod);
           }
    }
}
