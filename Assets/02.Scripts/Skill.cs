using System;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField]
    protected SkillInfo skillInfo;
    protected SkillType skillType;

    public abstract void UseSkill();

    public abstract SkillInfo GetSkillInfo();

    public abstract SkillType GetSkillType();

    public abstract Enum GetSkillNum();
}
