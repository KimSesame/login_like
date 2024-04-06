using System;
using UnityEngine;

public class SkillDefense : Skill
{
    [SerializeField]
    TypeDefense defenseType;

    private void Awake()
    {
        skillType = SkillType.TypeDefense;
    }

    public override void UseSkill()
    {

    }

    public override Enum GetSkillNum()
    {
        return defenseType;
    }
}
