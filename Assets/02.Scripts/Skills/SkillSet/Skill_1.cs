using System;
using UnityEngine;

public class Skill_1 : Skill
{
    [SerializeField]
    TypeAttack attackType;
    [SerializeField]
    bool isPenetrate;

    private void Awake()
    {
        skillType = SkillType.TypeAttack;
    }

    public override void UseSkill()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != null)
                targets[i].GetSkilledDelayDamage(owner.GetAtk() * skillInfo.mass[0], isPenetrate, skillInfo.icon);
        }
    }

    public override Enum GetSkillNum()
    {
        return attackType;
    }
}
