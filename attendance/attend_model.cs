using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
namespace Education_Center
{
    class attend_model
    {


        public void mark(String[] newData)
        {
            
            //inserint attendance

            try
            {

                var newStudent = new mark_std
                {
                    index = newData[0],
                    name = newData[1],
                    date = newData[2],
                    time = newData[3],
                    sub = newData[4],
                    month = newData[5],
                    year = newData[6],
                    stream = newData[7]

                };


                var connect = new MongoClient();
                var db = connect.GetDatabase("educationSystem");

                //inserting student
                var collectionSTD = db.GetCollection<mark_std>("attendance");
                collectionSTD.InsertOne(newStudent);

                

            }
            catch (Exception e)
            {
                frm_Alert("Something went wrong");
                error.errorNow(e.ToString() + "in class class_attend [ DANGER SITUATION ]");
                Email send = new Email();
                send.toDeveloperERROR(e.ToString());
            }

            

        }

        private void frm_Alert(string v)
        {
            throw new NotImplementedException();
        }
    }
}
