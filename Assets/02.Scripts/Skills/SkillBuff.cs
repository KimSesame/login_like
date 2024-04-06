using System;
using UnityEngine;

public class SkillBuff : Skill
{
    [SerializeField]
    TypeBuff buffType;

    private void Awake()
    {
        skillType = SkillType.TypeBuff;
    }

    public override void UseSkill()
    {

    }

    public override Enum GetSkillNum()
    {
        return buffType;
    }
}
