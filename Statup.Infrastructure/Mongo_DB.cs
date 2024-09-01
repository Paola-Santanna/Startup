using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Startup.Domain.Collection;

namespace Statup.Infrastructure;
public class Mongo_DB
{
    public Mongo_DB(IConfiguration configuration)
    {
        try
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration["ConnectionString"]));
            var client = new MongoClient(settings);
            DB = client.GetDatabase(configuration["NomeBanco"]);
        }
        catch (Exception ex)
        {
            throw new MongoException("It was not possible to connect to MongoDB", ex);
        }
    }

    public IMongoDatabase DB { get; }

    private void MapClasses()
    {
        var ConventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
        ConventionRegistry.Register("camelCase", ConventionPack, t => true);

        if (!BsonClassMap.IsClassMapRegistered(typeof(Infectado)))
        {
            BsonClassMap.RegisterClassMap<Infectado>(i =>
            {
                i.AutoMap();
                i.UnmapMember(x => x.Id);
                i.SetIgnoreExtraElements(true);
            });
        }
    }
}

