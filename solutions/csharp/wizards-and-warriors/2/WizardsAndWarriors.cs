abstract class Character
{
    private string _characterType;

    protected Character(string characterType)
    {
        _characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString()
        => $"Character is a {_characterType}";
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (target.Vulnerable())
        {
            return 10;
        }

        return 6;
    }
}

class Wizard : Character
{
    private bool _isSpellPrepared;

    public Wizard() : base("Wizard")
    {
    }

    public void PrepareSpell()
    {
        _isSpellPrepared = true;
    }

    public override bool Vulnerable()
        => !_isSpellPrepared;

    public override int DamagePoints(Character target)
    {
        if (_isSpellPrepared)
        {
            return 12;
        }

        return 3;
    }
}