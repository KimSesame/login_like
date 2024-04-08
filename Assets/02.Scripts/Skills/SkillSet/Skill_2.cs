using System;
using UnityEngine;

public class Skill_2 : Skill
{
    [Header("Type Attack")]
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
                targets[i].GetSkilledDamaged(owner.GetAtk() * skillInfo.mass[0], isPenetrate);
        }
    }

    public override Enum GetSkillNum()
    {
        return attackType;
    }
}
