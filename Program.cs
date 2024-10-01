///Link conf
///https://www.omnicalculator.com/pt/outras/latitude-longitude-distancia

//guaxupe -> campinas
Console.WriteLine(DistanceCalculator.GetDistance("-21.3131481", "-46.7472346", "-22.8948207", "-47.1958465"));

public static class DistanceCalculator
{
    private const double EarthRadiusKm = 6371.0; // Raio da Terra em quilômetros

    public static double GetDistance(string latA, string longA, string latB, string longB)
    {
        double lat1 = ToDouble(latA);
        double lon1 = ToDouble(longA);
        double lat2 = ToDouble(latB);
        double lon2 = ToDouble(longB);

        // Converte graus para radianos
        double lat1Rad = DegreesToRadians(lat1);
        double lon1Rad = DegreesToRadians(lon1);
        double lat2Rad = DegreesToRadians(lat2);
        double lon2Rad = DegreesToRadians(lon2);

        // Calcula a diferença
        double dlat = lat2Rad - lat1Rad;
        double dlon = lon2Rad - lon1Rad;

        // Fórmula de Haversine
        double a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) +
                   Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                   Math.Sin(dlon / 2) * Math.Sin(dlon / 2);
        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        // Calcula a distância
        return EarthRadiusKm * c; // Distância em quilômetros
    }

    private static double ToDouble(string value)
    {
        if (!Double.TryParse(value.Replace(".", ","), out double doubleResult))
            throw new Exception($"Erro ao converter {value} para double");

        return doubleResult;
    }

    private static double DegreesToRadians(double degrees)
    {
        return degrees * (Math.PI / 180);
    }
}
