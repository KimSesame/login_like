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

    /// <summary>
    /// 스킬을 사용할 때 해당 함수를 호출하여 타깃을 전달
    /// </summary>
    /// <param name="targetsV">스킬의 영향을 받는 타깃들</param>
    public void TargetSelected(Character[] targetsV)
    {
        targets = targetsV;
    }

    /// <summary>
    /// 해당 스킬의 사용이 확정되었을 때 호출하여 스킬을 사용
    /// </summary>
    public abstract void UseSkill();

    /// <summary>
    /// 해당 스킬의 정보를 반환
    /// </summary>
    /// <returns>스킬 정보</returns>
    public SkillInfo GetSkillInfo()
    {
        return skillInfo;
    }

    /// <summary>
    /// 해당 스킬의 종류를 반환
    /// </summary>
    /// <returns>스킬 타입</returns>
    public SkillType GetSkillType()
    {
        return skillType;
    }

    /// <summary>
    /// 해당 스킬의 상세 종류를 반환
    /// </summary>
    /// <returns>스킬 종류</returns>
    public abstract Enum GetSkillNum();
}
