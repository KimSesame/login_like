public class Skill_4 : SkillDefense
{
    public override void UseSkill()
    {
        owner.GetSkilledDefense(owner.GetDef() * skillInfo.mass[0], (byte)skillInfo.mass[1], skillInfo.icon);
    }
}
