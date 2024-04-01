using System;
using UnityEngine;

public class SkillAttack : Skill
{
    [SerializeField]
    TypeAttack attackType;

    private void Awake()
    {
        skillType = SkillType.TypeAttack;
    }

    public override void UseSkill()
    {
        if (skillInfo.locked) Debug.Log("Skill a locked");
        else Debug.Log("Use skill a");
    }

    public override SkillInfo GetSkillInfo()
    {
        return skillInfo;
    }

    public override SkillType GetSkillType()
    {
        return skillType;
    }

    public override Enum GetSkillNum()
    {
        return attackType;
    }
}
