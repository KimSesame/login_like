using System;
using UnityEngine;

public class SkillAttack : Skill
{
    [Header("Type Attack")]
    [SerializeField]
    protected TypeAttack attackType;
    [SerializeField]
    protected bool isPenetrate, isLifeAbsorb;

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
