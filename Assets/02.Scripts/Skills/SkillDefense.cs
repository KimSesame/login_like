using System;
using UnityEngine;

public class SkillDefense : Skill
{
    [Header("Type Defense")]
    [SerializeField]
    protected TypeDefense defenseType;

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
