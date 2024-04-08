using System;
using UnityEngine;

public enum Target
{
    Team, //�� ���
    Enemy, //�� ���
    All //��� ���
}

public enum Range
{
    Single, //���� Ÿ��
    Horizontal, //���� ���� Ÿ��
    Vertical, //���� ���� Ÿ��
    All //�� ���� Ÿ��
}

[Flags]
public enum TypeAttack
{
    Normal = 1, //�Ϲ� ����
    multiple = 2, //���� ����
    Delay = 4, //�ð��� ����
}

[Flags]
public enum TypeDefense
{
    GetDef = 1, //�� ȹ��
    GetDec = 2, //���� ������ ȹ��
    GetAvoid = 4, //ȸ���� ȹ��
    Reflect = 8, //���� �ݻ� ȹ��
    Aggro = 16, //����
    ImmuneDmg = 32 //����
}

[Flags]
public enum TypeBuff
{
    Heal = 1, //ȸ��
    GiveDef = 2, //�� �ο�
    GiveAtkPower = 4, //���ݷ� �ο�
    Cleansing = 8, //��ȭ
    Critical = 16 //ġ��Ÿ �ο�
}

[Flags]
public enum TypeDebuff
{
    DOT_dmg = 1, //��Ʈ ����
    Weaken = 2, //��ȭ
    Stun = 4, //����
    Blind = 8, //�Ǹ�
    Mark = 16, //ǥ��
    DestroyDef = 32, //�� ����
    Psychokinesis = 64 //������
}

public enum SkillType
{
    TypeAttack,
    TypeDefense,
    TypeBuff,
    TypeDebuff
}

public enum SkillAffectType
{
    DELAY, //�ð��� ����
    DEFENSE, //�� ����
    ATK_INC, //���ݷ� ����
    DOT, //��Ʈ ����
    MARK //ǥ��
}

[Serializable]
public struct SkillInfo
{
    public Sprite icon; //��ų ������
    public bool locked; //��ų ���
    [Range(0, 6)] public byte cost; //��ų ��� ���
    public Target target; //��ų ��� ��ǥ (��, �Ʊ�, ��ü)
    public Range range; //��ų ��� ���� (�ܵ�, ����, ����, ��ü)
    public float[] mass; //��ų ��� ȿ���� ��
}

[Serializable]
public struct Status
{
    public ushort serialNum; //ĳ���� ���� ��ȣ
    public int atk; //���ݷ�
    public int def; //����
    public int decRate; //���� ������
    public float avoidRate; //ȸ�� ��
    public float maxHp; //�ִ� ü��
}
