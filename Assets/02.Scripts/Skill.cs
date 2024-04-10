using System;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField]
    protected SkillInfo skillInfo/*해당 스킬의 정보*/;
    protected SkillType skillType /*해당 스킬의 종류*/;
    protected Character[] targets/*스킬 사용 타깃들 배열*/;
    [SerializeField]
    public Character owner; //해당 스킬의 주인 캐릭터
    protected ushort serialNum; //캐릭터 고유 번호

    public void SkillSelected()
    {
        if (skillType == SkillType.TypeDefense) GameCtrl.instance.SelectSkill(this, owner);
        else GameCtrl.instance.SelectSkill(this);
    }

    //스킬을 사용할 때 해당 함수를 호출하여 타깃을 전달
    public void TargetSelected(Character[] targetsV)
    {
        targets = targetsV;
    }

    //해당 스킬의 사용이 확정되었을 때 호출하여 스킬을 사용
    public abstract void UseSkill();

    //해당 스킬의 정보를 반환
    public SkillInfo GetSkillInfo()
    {
        return skillInfo;
    }

    //해당 스킬의 종류를 반환
    public SkillType GetSkillType()
    {
        return skillType;
    }

    //해당 스킬의 상세 종류를 반환
    public abstract Enum GetSkillNum();
}
