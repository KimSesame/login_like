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

    }

    public override Enum GetSkillNum()
    {
        return attackType;
    }
}
