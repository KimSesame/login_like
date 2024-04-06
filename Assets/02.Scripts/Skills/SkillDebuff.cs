using System;
using UnityEngine;

public class SkillDebuff : Skill
{
    [SerializeField]
    TypeDebuff debuffType;

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
