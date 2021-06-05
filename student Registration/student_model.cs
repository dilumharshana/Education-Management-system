using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Education_Center
{
    class student_model
    {


        //getting connection with mongodb


        //creating a new document (NEW STUDENT)
        public void register_new_student(String[] newData)
        {

            //cheking connection

            try
            {
              
                var newStudent = new student
                {
                    index = newData[0],
                    initials = newData[1],
                    firstname = newData[2],
                    lastname = newData[3],
                    address = newData[4],
                    dob = newData[5],
                    gender = newData[6],
                    grade = newData[7],
                    school = newData[8],
                    phone = newData[9],
                    email = newData[10],
                    admitionmonth = newData[11],
                    stream = newData[12],
                    sub1 = newData[13],
                    sub2 = newData[14],
                    sub3 = newData[15]

                };


                var newParent = new parent
                {
                    index = newData[0],
                    initials = newData[17],
                    firstname = newData[18],
                    lastname = newData[19],
                    address = newData[20],
                    nic = newData[21],
                    gender = newData[22],
                    phone = newData[23],
                    email = newData[24],
                };


                var connect = new MongoClient();
                var db = connect.GetDatabase("educationSystem");

                //inserting student
                var collectionSTD = db.GetCollection<student>("al_students");
                collectionSTD.InsertOne(newStudent);

                //inserting parent
                var collectionPRT = db.GetCollection<parent>("parent");
                collectionPRT.InsertOne(newParent);


                Console.WriteLine("done");
            }
            catch (Exception e)
            {
                Console.WriteLine("Sorry something went wrong -#59");
            }



        }





        //searching for student and returning result
        public String[] found(String index)
        {
            String[] user = new string[19];

            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<studentr>("al_students");
            var par = db.GetCollection<parentr>("parent");

            //inserting student
            var filter = Builders<studentr>.Filter.Eq("index", index);
            var filter2 = Builders<parentr>.Filter.Eq("index", index);
           
            try
            {
                
               
                var recs = std.Find(filter).First();

                user[0] = recs.index;
                user[1] = recs.initials;
                user[2] = recs.firstname;
                user[3] = recs.lastname;
                user[4] = recs.address;
                user[5] = recs.dob;
                user[6] = recs.gender;
                user[7] = recs.grade;
                user[8] = recs.school;
                user[9] = recs.phone;
                user[10] = recs.admitionmonth;
                user[11] = recs.email;
                user[12] = recs.stream;
                user[13] = recs.sub1;
                user[14] = recs.sub2;
                user[15] = recs.sub3;

                var precs = par.Find(filter2).First();

                user[16] = precs.firstname + " " + precs.lastname;
                user[17] = precs.phone;
                user[18] = precs.email;

            }
            catch (Exception e)
            {
                user[0] = null;
                error.errorNow(e.ToString() + "in class student_registration [ NORMAL SITUATION ]");
            }



            return user;

        }






    }
}
