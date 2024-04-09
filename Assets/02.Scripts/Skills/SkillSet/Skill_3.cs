public class Skill_3 : SkillBuff
{
    public override void UseSkill()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != null)
                targets[i].GetSkilledHeal(owner.GetAtk() * skillInfo.mass[0]);
        }
    }
}
