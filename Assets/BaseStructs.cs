using System;
using UnityEngine;

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

public enum TypeAttack
{
    Normal = 1,
    multiple = 2,
    Penetrate = 4,
    Delay = 8
}

public enum TypeDefense
{
    GetDef = 1,
    GetDec = 2,
    GetAvoid = 4,
    Reflect = 8,
    Aggro = 16,
    ImmuneDmg = 32
}

public enum TypeBuff
{
    Heal = 1,
    GiveDef = 2,
    GiveAtkPower = 4,
    Cleansing = 8,
    Critical = 16,
    Accel = 32
}

public enum TypeDebuff
{
    DOT_dmg = 1,
    Weaken = 2,
    Stun = 4,
    Blind = 8,
    Mark = 16,
    Icing = 32,
    DestroyDef = 64,
    Psychokinesis = 128
}

public enum SkillType
{
    TypeAttack,
    TypeDefense,
    TypeBuff,
    TypeDebuff
}

[Serializable]
public struct SkillInfo
{
    public Sprite icon;
    public bool locked;
    public byte serialNum;
    public byte cost;
    public Target target;
    public Range range;
    public float mass;
}

[Serializable]
public struct Status
{
    public int atk;
    public int def;
    public int hp;
}
