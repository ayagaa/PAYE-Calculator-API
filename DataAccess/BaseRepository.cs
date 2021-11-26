using Google.Cloud.Firestore;
using Newtonsoft.Json;
using PAYE.API.Models;
using PAYE.API.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PAYE.API.DataAccess
{
    public class BaseRepository
    {
        private string collectionName;
        public FirestoreDb FirestoreDb { get; set; }

        public BaseRepository(string collectionName)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory,
                "Credentials/paye-calculator-database-firebase-adminsdk-3zme6-5dba3de79a.json");

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);

            FirestoreDb = FirestoreDb.Create("paye-calculator-database");
            this.collectionName = collectionName;
        }

        public T Add<T>(T record) where T : DbBase
        {
            CollectionReference colRef = FirestoreDb.Collection(collectionName);
            DocumentReference doc = colRef.AddAsync(record).GetAwaiter().GetResult();
            record.Id = doc.Id;
            return record;
        }

        public bool Update<T> (T record) where T : DbBase
        {
            DocumentReference recordRef = FirestoreDb.Collection(collectionName).Document(record.Id);
            recordRef.SetAsync(record, SetOptions.MergeAll).GetAwaiter().GetResult();
            return true;
        }

        public bool Delete<T>(T record) where T : DbBase
        {
            DocumentReference recordRef = FirestoreDb.Collection(collectionName).Document(record.Id);
            recordRef.SetAsync(record, SetOptions.MergeAll).GetAwaiter().GetResult();
            return true;
        }

        public T Get<T>(string Id) where T: DbBase
        {
            DocumentReference docRef = FirestoreDb.Collection(collectionName).Document(Id);
            DocumentSnapshot snapshot = docRef.GetSnapshotAsync().GetAwaiter().GetResult();

            if (snapshot.Exists)
            {
                T obj = snapshot.ConvertTo<T>();
                obj.Id = snapshot.Id;
                return obj;
            }
            return null;
        }

        public T Get<T>(T record) where T : DbBase
        {
            DocumentReference docRef = FirestoreDb.Collection(collectionName).Document(record.Id);
            DocumentSnapshot snapshot = docRef.GetSnapshotAsync().GetAwaiter().GetResult();

            if(snapshot.Exists)
            {
                T obj = snapshot.ConvertTo<T>();
                obj.Id = snapshot.Id;
                return obj;
            }
            return null;
        }

        public List<T> GetAll<T>() where T : DbBase
        {
            Query query = FirestoreDb.Collection(collectionName);

            QuerySnapshot documentSnapshots = query.GetSnapshotAsync().GetAwaiter().GetResult();
            List<T> docs = new List<T>();

            for(int i = 0; i < documentSnapshots.Documents.Count; i++)
            {
                if(documentSnapshots.Documents[i].Exists)
                {
                    Dictionary<string, object> keyValuePairs = documentSnapshots.Documents[i].ToDictionary();
                    string json = JsonConvert.SerializeObject(keyValuePairs);
                    T newObject = JsonConvert.DeserializeObject<T>(json);

                    newObject.Id = documentSnapshots.Documents[i].Id;

                    docs.Add(newObject);
                }
            }

            return docs;
        }

        public List<T> QueryRecords<T>(Query query) where T: DbBase
        {
            QuerySnapshot snapshots = query.GetSnapshotAsync().GetAwaiter().GetResult();
            List<T> docs = new List<T>();

            for(int i = 0; i < snapshots.Count; i++)
            {
                if(snapshots[i].Exists)
                {
                    Dictionary<string, object> keyValuePairs = snapshots[i].ToDictionary();
                    string json = JsonConvert.SerializeObject(keyValuePairs);
                    T newObject = JsonConvert.DeserializeObject<T>(json);

                    newObject.Id = snapshots[i].Id;

                    docs.Add(newObject);
                }
            }

            return docs;
        }

    }
}
