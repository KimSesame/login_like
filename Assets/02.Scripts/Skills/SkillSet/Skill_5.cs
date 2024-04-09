public class Skill_5 : SkillDebuff
{
    public override void UseSkill()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != null)
                targets[i].GetSkilledAtkInc(owner.GetAtk() * skillInfo.mass[0], (byte)skillInfo.mass[1], skillInfo.icon);
        }
    }
}
