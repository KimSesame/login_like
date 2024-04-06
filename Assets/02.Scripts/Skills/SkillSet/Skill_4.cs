using System;
using UnityEngine;

public class Skill_4 : Skill
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
                targets[i].GetSkilledDefense(owner.GetDef() * skillInfo.mass[0], (byte)skillInfo.mass[1], skillInfo.icon);
        }
    }

    public override Enum GetSkillNum()
    {
        return buffType;
    }
}
