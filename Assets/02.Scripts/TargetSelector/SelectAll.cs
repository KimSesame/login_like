public class SelectAll : TargetSelector
{
    public override void Select(byte v)
    {
        if (skill.GetSkillInfo().target == Target.All)
        {
            targets = new Character[GameCtrl.instance.enemyPos.Length];
            
            for (int i = 0; i < GameCtrl.instance.enemyPos.Length / 2; i++)
            {
                GameCtrl.instance.teamPos[i].GetChild(0).TryGetComponent(out targets[i]);
                GameCtrl.instance.enemyPos[i].GetChild(0).TryGetComponent(out targets[i + GameCtrl.instance.enemyPos.Length / 2]);
            }
        }
        else
        {
            targets = new Character[GameCtrl.instance.enemyPos.Length / 2];
            
            for (int i = 0; i < GameCtrl.instance.enemyPos.Length / 2; i++)
            {
                if (skill.GetSkillInfo().target == Target.Team) GameCtrl.instance.teamPos[i].GetChild(0).TryGetComponent(out targets[i]);
                else GameCtrl.instance.enemyPos[i].GetChild(0).TryGetComponent(out targets[i]);
            }
        }

        Close();
    }
}
