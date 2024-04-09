using System;
using UnityEngine;

public class SkillDebuff : Skill
{
    [Header("Type Debuff")]
    [SerializeField]
    protected TypeDebuff debuffType;

    private void Awake()
    {
        skillType = SkillType.TypeDebuff;
    }

    public override void UseSkill()
    {

    }

    public override Enum GetSkillNum()
    {
        return debuffType;
    }
}
