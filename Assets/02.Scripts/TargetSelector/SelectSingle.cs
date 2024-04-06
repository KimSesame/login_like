public class SelectSingle : TargetSelector
{
    public override void Select(byte v)
    {
        targets = new Character[1];
        if (skill.GetSkillInfo().target == Target.Team && GameCtrl.instance.teamPos[v].childCount > 0) GameCtrl.instance.teamPos[v].GetChild(0).TryGetComponent(out targets[0]);
        else if (skill.GetSkillInfo().target == Target.Enemy && GameCtrl.instance.teamPos[v].childCount > 0) GameCtrl.instance.enemyPos[v].GetChild(0).TryGetComponent(out targets[0]);

        Close();
    }
}
