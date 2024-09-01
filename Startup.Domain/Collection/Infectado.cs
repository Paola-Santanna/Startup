using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Startup.Domain.Collection;
public class Infectado
{
    public Infectado() { }

    public Infectado(DateTime dataNascimento, string sexo, double latitude, double longitude)
    {
        DataNascimento = dataNascimento;
        Sexo = sexo;
        Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
    }

    /*
    public Infectado(string id, DateTime dataNascimento, string sexo, GeoJson2DGeographicCoordinates localizacao)
    {
        Id = id;
        DataNascimento = dataNascimento;
        Sexo = sexo;
        Localizacao = localizacao;
    }
    */

    public ObjectId Id;    
    public DateTime DataNascimento { get; set; }
    public string Sexo { get; set; }
    public GeoJson2DGeographicCoordinates Localizacao { get; set; }
}
