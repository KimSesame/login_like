public class SelectVertical : TargetSelector
{
    public override void Select(byte v)
    {
        if (skill.GetSkillInfo().target == Target.All)
        {
            targets = new Character[GameCtrl.instance.enemyPos.Length];
            if (v == 0)
            {
                for (int i = 0; i < GameCtrl.instance.enemyPos.Length / 2; i++)
                {
                    GameCtrl.instance.teamPos[i].GetChild(0).TryGetComponent(out targets[i]);
                    GameCtrl.instance.enemyPos[i].GetChild(0).TryGetComponent(out targets[i + GameCtrl.instance.enemyPos.Length / 2]);
                }
            }
            else
            {
                for (int i = 0; i < GameCtrl.instance.enemyPos.Length / 2; i++)
                {
                    GameCtrl.instance.teamPos[i + GameCtrl.instance.enemyPos.Length / 2].GetChild(0).TryGetComponent(out targets[i]);
                    GameCtrl.instance.enemyPos[i + GameCtrl.instance.enemyPos.Length / 2].GetChild(0).TryGetComponent(out targets[i + GameCtrl.instance.enemyPos.Length / 2]);
                }
            }
        }
        else
        {
            targets = new Character[GameCtrl.instance.enemyPos.Length / 2];
            if (v == 0)
            {
                for (int i = 0; i < GameCtrl.instance.enemyPos.Length / 2; i++)
                {
                    if (skill.GetSkillInfo().target == Target.Team) GameCtrl.instance.teamPos[i].GetChild(0).TryGetComponent(out targets[i]);
                    else GameCtrl.instance.enemyPos[i].GetChild(0).TryGetComponent(out targets[i]);
                }
            }
            else
            {
                for (int i = 0; i < GameCtrl.instance.enemyPos.Length / 2; i++)
                {
                    if (skill.GetSkillInfo().target == Target.Team) GameCtrl.instance.teamPos[i + GameCtrl.instance.enemyPos.Length / 2].GetChild(0).TryGetComponent(out targets[i]);
                    else GameCtrl.instance.enemyPos[i + GameCtrl.instance.enemyPos.Length / 2].GetChild(0).TryGetComponent(out targets[i]);
                }
            }
        }

        Close();
    }
}
