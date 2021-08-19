using NGeoHash;

namespace Sulmar.EFCore.Models
{

    public class Coordinate : Base
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }



    // dotnet add package NGeoHash
    public static class CoordinateExtensions
    {
        public static string ToGeoHash(this Coordinate coordinate)
        {
            return GeoHash.Encode(coordinate.Latitude, coordinate.Longitude);
        }

        public static Coordinate ToCoordinate(this string geoHash)
        {
            var decoded = GeoHash.Decode(geoHash);

            return new Coordinate { Latitude = decoded.Coordinates.Lat, Longitude = decoded.Coordinates.Lon };
        }
    }
}





