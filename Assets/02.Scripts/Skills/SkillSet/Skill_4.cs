using System;
using UnityEngine;

public class Skill_4 : Skill
{
    [Header("Type Defense")]
    [SerializeField]
    TypeDebuff defenseType;

    private void Awake()
    {
        skillType = SkillType.TypeDefense;
    }

    public override void UseSkill()
    {
        owner.GetSkilledDefense(owner.GetDef() * skillInfo.mass[0], (byte)skillInfo.mass[1], skillInfo.icon);
    }

    public override Enum GetSkillNum()
    {
        return defenseType;
    }
}
