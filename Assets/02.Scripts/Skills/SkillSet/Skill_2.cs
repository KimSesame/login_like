public class Skill_2 : SkillAttack
{
    public override void UseSkill()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != null)
                targets[i].GetSkilledDamaged(owner.GetAtk() * skillInfo.mass[0], isPenetrate);
        }
    }
}
