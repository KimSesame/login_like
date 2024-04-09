using System;
using UnityEngine;

public class SkillBuff : Skill
{
    [Header("Type Buff")]
    [SerializeField]
    protected TypeBuff buffType;

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
