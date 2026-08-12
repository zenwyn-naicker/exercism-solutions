public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    
    // TODO: implement equality and GetHashCode() methods

    public override bool Equals(object obj)
        => obj is FacialFeatures other
            && EyeColor == other.EyeColor
            && PhiltrumWidth == other.PhiltrumWidth;
    
    public override int GetHashCode()
        => HashCode.Combine(EyeColor, PhiltrumWidth);
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    
    // TODO: implement equality and GetHashCode() methods

    public override bool Equals(object obj)
        => obj is Identity other
            && Email == other.Email
            && FacialFeatures.Equals(other.FacialFeatures);

    public override int GetHashCode()
        => HashCode.Combine(Email, FacialFeatures);
}

public class Authenticator
{
    private List<Identity> identities = new List<Identity>();
    
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
        => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity)
        => identity.Equals(new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m)));

    public bool Register(Identity identity)
    {
        if (identities.Contains(identity))
        {
            return false;
        }
        identities.Add(identity);
        return true;
    }

    public bool IsRegistered(Identity identity)
        => identities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB)
        => ReferenceEquals(identityA, identityB);
}
