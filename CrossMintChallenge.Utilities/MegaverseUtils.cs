using CrossMintChallenge.Core.Enumeration;

namespace CrossMintChallenge.Utilities;

public static class MegaverseUtils
{
    
    public static MegaverseColor ParseAndValidateColor(string color)
    {
        if (Enum.TryParse<MegaverseColor>(color, true, out var parsedColor))
        {
            return parsedColor;
        }

        throw new ArgumentException($"Invalid megaverse color: {color}");
    }

    public static MegaverseDirection ParseAndValidateDirection(string direction)
    {
        if (Enum.TryParse<MegaverseDirection>(direction, true, out var parsedDirection))
        {
            return parsedDirection;
        }

        throw new ArgumentException($"Invalid megaverse direction: {direction}");
    }
}