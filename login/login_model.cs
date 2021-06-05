using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Education_Center
{
    class login_model
    {
        String[] loginData = new string[2];


        public String[] chekuser(String [] data)
          {

            String[] user = new String[3];

            try
            {
                MongoClient connect = dbconnector.connection();
                var db = connect.GetDatabase("educationSystem");
                var logindata = db.GetCollection<logindata>("login"); //getting student document

                var filter = Builders<logindata>.Filter.Eq("username", data[0]);
                var filter2 = Builders<logindata>.Filter.Eq("password", data[1]);

                try
                {
                    var recs = logindata.Find(filter & filter2).First();
                    user[0] = "1";
                    user[1] = recs.username;
                    user[2] = recs.role;
                }
                catch (Exception e)
                {
                    user[0] = "0";
                    error.errorNow(e.ToString() + "in class logi_model [ NORMAL SITUATION ]");

                    Email send = new Email();
                    send.toDeveloperERROR(e.ToString());
                }
            }
            catch(Exception e)
            {
                error.errorNow(e.ToString() + "in class logi_model [ DANGER SITUATION ]");

                Email send = new Email();
                send.toDeveloperERROR(e.ToString());
            }

            return user;
            
        }

  
          
    }
    }



