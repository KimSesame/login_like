using System;
using UnityEngine;

public class Skill_7 : Skill
{
    [Header("Type Debuff")]
    [SerializeField]
    TypeDebuff debuffType;

    private void Awake()
    {
        skillType = SkillType.TypeDebuff;
    }

    public override void UseSkill()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != null)
                targets[i].GetSkilledMark(skillInfo.mass[0], skillInfo.icon);
        }
    }

    public override Enum GetSkillNum()
    {
        return debuffType;
    }
}
