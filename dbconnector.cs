using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Education_Center
{
    class dbconnector
    {

        //generating mongodb connection and return the connection
        public static  MongoClient connection() 
            {
                 return new MongoClient("mongodb://localhost");
            }
    }
}
