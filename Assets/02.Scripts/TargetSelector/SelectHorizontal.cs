public class SelectHorizontal : TargetSelector
{
    public override void Select(byte v)
    {
        if (skill.GetSkillInfo().target == Target.All)
        {
            targets = new Character[4];
            if (GameCtrl.instance.enemyPos[v].childCount > 0) GameCtrl.instance.enemyPos[v].GetChild(0).TryGetComponent(out targets[0]);
            if (GameCtrl.instance.enemyPos[v + GameCtrl.instance.enemyPos.Length / 2].childCount > 0) GameCtrl.instance.enemyPos[v + GameCtrl.instance.enemyPos.Length / 2].GetChild(0).TryGetComponent(out targets[1]);
            if (GameCtrl.instance.teamPos[v].childCount > 0) GameCtrl.instance.teamPos[v].GetChild(0).TryGetComponent(out targets[2]);
            if (GameCtrl.instance.teamPos[v + GameCtrl.instance.teamPos.Length / 2].childCount > 0) GameCtrl.instance.teamPos[v + GameCtrl.instance.teamPos.Length / 2].GetChild(0).TryGetComponent(out targets[3]);
        }
        else
        {
            targets = new Character[2];
            if (skill.GetSkillInfo().target == Target.Team)
            {
                if (GameCtrl.instance.teamPos[v].childCount > 0) GameCtrl.instance.teamPos[v].GetChild(0).TryGetComponent(out targets[0]);
                if (GameCtrl.instance.teamPos[v + GameCtrl.instance.teamPos.Length / 2].childCount > 0) GameCtrl.instance.teamPos[v + GameCtrl.instance.teamPos.Length / 2].GetChild(0).TryGetComponent(out targets[1]);
            }
            else
            {
                if (GameCtrl.instance.enemyPos[v ].childCount > 0) GameCtrl.instance.enemyPos[v].GetChild(0).TryGetComponent(out targets[0]);
                if (GameCtrl.instance.enemyPos[v + GameCtrl.instance.enemyPos.Length / 2].childCount > 0) GameCtrl.instance.enemyPos[v + GameCtrl.instance.enemyPos.Length / 2].GetChild(0).TryGetComponent(out targets[1]);
            }
        }

        Close();
    }
}