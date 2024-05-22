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
    GetAvoid = 2, //ȸ���� ȹ��
    Reflect = 4, //���� �ݻ� ȹ��
    Aggro = 8, //����
    ImmuneDmg = 16 //����
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
    /// <summary>
    /// �ð��� ����
    /// </summary>
    DELAY,
    /// <summary>
    /// �� ����
    /// </summary>
    DEFENSE,
    /// <summary>
    /// ���ݷ� ����
    /// </summary>
    ATK_INC,
    /// <summary>
    /// ��Ʈ ����
    /// </summary>
    DOT,
    /// <summary>
    /// ǥ��
    /// </summary>
    MARK
}

[Serializable]
public struct SkillInfo
{ 
    /// <summary>
    /// ��ų ������
    /// </summary>
    public Sprite icon;
    /// <summary>
    /// ��ų ���
    /// </summary>
    public bool locked;
    /// <summary>
    /// ��ų ����
    /// </summary>
    public string descript;
    /// <summary>
    /// ��ų ��� ���
    /// </summary>
    [Range(0, 6)] public byte cost;
    /// <summary>
    /// ��ų ��� ��ǥ (��, �Ʊ�, ��ü)
    /// </summary>
    public Target target;
    /// <summary>
    /// ��ų ��� ���� (�ܵ�, ����, ����, ��ü)
    /// </summary>
    public Range range;
    /// <summary>
    /// ��ų ��� ȿ���� ��
    /// </summary>
    public float[] mass;
}

[Serializable]
public struct Status
{
    /// <summary>
    /// ĳ���� ���� ��ȣ
    /// </summary>
    public ushort serialNum;
    /// <summary>
    /// �ִ� ü��
    /// </summary>
    [Space(10)]
    public float maxHp;
    /// <summary>
    /// �ִ� ����
    /// </summary>
    public float maxMp;
    /// <summary>
    /// ���ݷ� 
    /// </summary>
    [Space(10)]
    public int atk;
    /// <summary>
    /// �ֹ���
    /// </summary>
    public int magicPower;
    /// <summary>
    /// ����
    /// </summary>
    [Space(10)]
    public int def;
    /// <summary>
    /// ���� ���׷�
    /// </summary>
    public int magicDef;
    /// <summary>
    /// ���߷�
    /// </summary>
    [Space(10)]
    public float accuracy;
    /// <summary>
    /// ȸ����
    /// </summary>
    public float avoidRate;
    /// <summary>
    /// ġ��Ÿ��
    /// </summary>
    public float criticalRate;
    /// <summary>
    /// �������� �����
    /// </summary>
    public float ccResistance;
}
