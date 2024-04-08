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
    GetDec = 2, //피해 감소율 획득
    GetAvoid = 4, //회피율 획득
    Reflect = 8, //피해 반사 획득
    Aggro = 16, //도발
    ImmuneDmg = 32 //무적
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
    DELAY, //시간차 피해
    DEFENSE, //방어도 증가
    ATK_INC, //공격력 증가
    DOT, //도트 피해
    MARK //표식
}

[Serializable]
public struct SkillInfo
{
    public Sprite icon; //스킬 아이콘
    public bool locked; //스킬 잠금
    [Range(0, 6)] public byte cost; //스킬 사용 비용
    public Target target; //스킬 사용 목표 (적, 아군, 전체)
    public Range range; //스킬 사용 범위 (단독, 가로, 세로, 전체)
    public float[] mass; //스킬 사용 효과의 양
}

[Serializable]
public struct Status
{
    public ushort serialNum; //캐릭터 고유 번호
    public int atk; //공격력
    public int def; //방어력
    public int decRate; //피해 감소율
    public float avoidRate; //회피 율
    public float maxHp; //최대 체력
}
