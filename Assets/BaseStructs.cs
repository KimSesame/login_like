using System;

public enum Target
{
    Team,
    Enemy,
    All
}

public enum Range
{
    Single,
    Horizontal,
    Vertical,
    All
}

[Flags]
public enum TypeAttack
{
    Normal = 1,
    multiple = 2,
    Penetrate = 4,
    Delay = 8
}

[Flags]
public enum TypeDefense
{
    GetDef = 1,
    GetDec = 2,
    GetAvoid = 4,
    Reflect = 8,
    Aggro = 16,
    ImmuneDmg = 32
}

[Flags]
public enum TypeBuff
{
    Heal = 1,
    GiveDef = 2,
    GiveAtkPower = 4,
    Cleansing = 8,
    Critical = 16,
    Accel = 32
}

[Flags]
public enum TypeDebuff
{
    DOTdmg = 1,
    Weaken = 2,
    Stun = 4,
    Blind = 8,
    Mark = 16,
    Icing = 32,
    DestroyDef = 64,
    Psychokinesis = 128
}

[Flags]
public enum SkillType
{
    TypeAttack = 1,
    TypeDefense = 2,
    TypeBuff = 4,
    TypeDebuff = 8
}

[Serializable]
public struct SkillTypeAttack
{
    public bool locked;
    public Target target;
    public Range range;
}

[Serializable]
public struct SkillTypeDefense
{
    public bool locked;
    public Target target;
    public Range range;
}

[Serializable]
public struct SkillTypeBuff
{
    public bool locked;
    public Target target;
    public Range range;
}

[Serializable]
public struct Status
{
    public int atk;
    public int def;
    public int hp;
}
