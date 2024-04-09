public class Skill_1 : SkillAttack
{
    public override void UseSkill()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != null)
                targets[i].GetSkilledDelayDamage(owner.GetAtk() * skillInfo.mass[0], isPenetrate, skillInfo.icon);
        }
    }
}
