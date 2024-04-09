public class Skill_7 : SkillDebuff
{
    public override void UseSkill()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != null)
                targets[i].GetSkilledMark(skillInfo.mass[0], skillInfo.icon);
        }
    }
}
