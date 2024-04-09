public class Skill_6 : SkillAttack
{
    public override void UseSkill()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != null)
                targets[i].GetSkilledMulipleDamage(owner.GetAtk() * skillInfo.mass[0], (byte)skillInfo.mass[1], isPenetrate);
        }
    }
}
