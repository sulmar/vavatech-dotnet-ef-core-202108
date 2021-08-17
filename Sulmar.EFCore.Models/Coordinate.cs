using NGeoHash;

namespace Sulmar.EFCore.Models
{


    // dotnet add package NGeoHash

    public class Coordinate : Base
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string ToGeoHash() => GeoHash.Encode(Latitude, Longitude);

        public static Coordinate FromGeoHash(string geoHash)
        {
            var decoded = GeoHash.Decode(geoHash);

            return new Coordinate { Latitude = decoded.Coordinates.Lat, Longitude = decoded.Coordinates.Lon };
        }
    }
}





