using System;
using UnityEngine;

public class Skill_6 : Skill
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
                targets[i].GetSkilledMulipleDamage(owner.GetAtk() * skillInfo.mass[0], (byte)skillInfo.mass[1], isPenetrate);
        }
    }

    public override Enum GetSkillNum()
    {
        return attackType;
    }
}
