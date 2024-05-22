using System;
using UnityEngine;

public enum Target
{
    Team, //팀 대상
    Enemy, //적 대상
    All //모든 대상
}

public enum Range
{
    Single, //단일 타깃
    Horizontal, //수평 범위 타깃
    Vertical, //수직 범위 타깃
    All //전 범위 타깃
}

[Flags]
public enum TypeAttack
{
    Normal = 1, //일반 공격
    multiple = 2, //다중 공격
    Delay = 4, //시간차 공격
}

[Flags]
public enum TypeDefense
{
    GetDef = 1, //방어도 획득
    GetAvoid = 2, //회피율 획득
    Reflect = 4, //피해 반사 획득
    Aggro = 8, //도발
    ImmuneDmg = 16 //무적
}

[Flags]
public enum TypeBuff
{
    Heal = 1, //회복
    GiveDef = 2, //방어도 부여
    GiveAtkPower = 4, //공격력 부여
    Cleansing = 8, //정화
    Critical = 16 //치명타 부여
}

[Flags]
public enum TypeDebuff
{
    DOT_dmg = 1, //도트 피해
    Weaken = 2, //약화
    Stun = 4, //기절
    Blind = 8, //실명
    Mark = 16, //표식
    DestroyDef = 32, //방어도 제거
    Psychokinesis = 64 //염동력
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
    /// 시간차 피해
    /// </summary>
    DELAY,
    /// <summary>
    /// 방어도 증가
    /// </summary>
    DEFENSE,
    /// <summary>
    /// 공격력 증가
    /// </summary>
    ATK_INC,
    /// <summary>
    /// 도트 피해
    /// </summary>
    DOT,
    /// <summary>
    /// 표식
    /// </summary>
    MARK
}

[Serializable]
public struct SkillInfo
{ 
    /// <summary>
    /// 스킬 아이콘
    /// </summary>
    public Sprite icon;
    /// <summary>
    /// 스킬 잠금
    /// </summary>
    public bool locked;
    /// <summary>
    /// 스킬 정보
    /// </summary>
    public string descript;
    /// <summary>
    /// 스킬 사용 비용
    /// </summary>
    [Range(0, 6)] public byte cost;
    /// <summary>
    /// 스킬 사용 목표 (적, 아군, 전체)
    /// </summary>
    public Target target;
    /// <summary>
    /// 스킬 사용 범위 (단독, 가로, 세로, 전체)
    /// </summary>
    public Range range;
    /// <summary>
    /// 스킬 사용 효과의 양
    /// </summary>
    public float[] mass;
}

[Serializable]
public struct Status
{
    /// <summary>
    /// 캐릭터 고유 번호
    /// </summary>
    public ushort serialNum;
    /// <summary>
    /// 최대 체력
    /// </summary>
    [Space(10)]
    public float maxHp;
    /// <summary>
    /// 최대 마나
    /// </summary>
    public float maxMp;
    /// <summary>
    /// 공격력 
    /// </summary>
    [Space(10)]
    public int atk;
    /// <summary>
    /// 주문력
    /// </summary>
    public int magicPower;
    /// <summary>
    /// 방어력
    /// </summary>
    [Space(10)]
    public int def;
    /// <summary>
    /// 마법 저항력
    /// </summary>
    public int magicDef;
    /// <summary>
    /// 명중률
    /// </summary>
    [Space(10)]
    public float accuracy;
    /// <summary>
    /// 회피율
    /// </summary>
    public float avoidRate;
    /// <summary>
    /// 치명타율
    /// </summary>
    public float criticalRate;
    /// <summary>
    /// 군중제어 저향력
    /// </summary>
    public float ccResistance;
}
