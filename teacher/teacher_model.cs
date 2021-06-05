using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Education_Center
{
    class teacher_model
    {

        public void register_new_teacher(String[] newData)
        {
            var newTeacher = new teacher
            {
                index = newData[0],
                name = newData[1],
                sub = newData[2],
                address = newData[3],
                gender = newData[4],
                phone = newData[5],
                email = newData[6]

            };

            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");

            var collectionTEA = db.GetCollection<teacher>("teachers");
            collectionTEA.InsertOne(newTeacher);


        }

        public String[] found(String index)
        {
            String[] user = new string[7];

            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var tea = db.GetCollection<teacherR>("teacher");

            
            var filter = Builders<teacherR>.Filter.Eq("index", index);

            var recs = tea.Find(filter).First();

            user[0] = recs.index;
            user[1] = recs.name;
            user[2] = recs.sub;
            user[3] = recs.address;
            user[4] = recs.gender;
            user[5] = recs.phone;
            user[6] = recs.email;

            var precs = tea.Find(filter).First();

            return user;
        }
            

    }
}
