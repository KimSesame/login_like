using System;
using UnityEngine;

public class Skill_3 : Skill
{
    [SerializeField]
    TypeBuff buffType;

    private void Awake()
    {
        skillType = SkillType.TypeBuff;
    }

    public override void UseSkill()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != null)
                targets[i].GetSkilledHeal(owner.GetAtk() * skillInfo.mass[0]);
        }
    }

    public override Enum GetSkillNum()
    {
        return buffType;
    }
}
