using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelLegendaryRandomizer.MongoLegendaryMarvelRandomizer
{
    public abstract class MongoRepositoryBase
    {
        protected static MongoClient Client { get; private set; }
        protected static MongoServer Server { get; private set; }
        protected static MongoDatabase Database { get; private set; }

        static MongoRepositoryBase()
        {
            if (Client == null)
            {
                // todo - get this in the config.
                const string connectionString = "mongodb://localhost/";
                Client = new MongoClient(connectionString);
                Server = Client.GetServer();
                Database = Server.GetDatabase("legendarymarvelrandomizer");
            }
        }
    }
}
