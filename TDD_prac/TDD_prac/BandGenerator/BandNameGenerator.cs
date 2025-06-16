namespace TDD_prac.BandGenerator;

public class BandNameGenerator
{
    public string GenerateBandName(string band)
    {
        if (band.Split(" ").Length > 1)
        {
            throw new Exception("Band name should not contain multiple words.");
        }

        var bandNameWithoutFirstCharacter = band[1..].ToLower();
        var capitalizedBandName = (char.ToUpper(band[0]) + bandNameWithoutFirstCharacter);

        if (band.First() != band.Last())
        {
            return "The " + capitalizedBandName;
        }

        return capitalizedBandName + bandNameWithoutFirstCharacter;
    }
}