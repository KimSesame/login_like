using UnityEngine;
using UnityEngine.UI;

public abstract class TargetSelector : MonoBehaviour
{
    TargetSelectConnector connector;

    protected GameObject targetEnemy, targetTeam;

    protected Skill skill/*사용할 스킬*/;

    protected Character[] targets/*스킬의 범위에 해당하는 타깃 배열*/;

    private void Awake()
    {
        connector = transform.parent.GetComponent<TargetSelectConnector>();

        targetEnemy = transform.GetChild(0).gameObject;
        targetTeam = transform.GetChild(1).gameObject;
        
        Transform[] targetEnemyTrans = new Transform[targetEnemy.transform.childCount],
            targetTeamTrans = new Transform[targetEnemy.transform.childCount];

        for (int i = 0; i < targetEnemy.transform.childCount; i++)
        {
            targetEnemyTrans[i] = targetEnemy.transform.GetChild(i);
            targetTeamTrans[i] = targetTeam.transform.GetChild(i);
        }

        for (byte i = 0; i < targetEnemyTrans.Length; i++)
        {
            byte index = i;
            targetEnemyTrans[index].GetComponent<Button>().onClick.AddListener(() => Select(index));
            targetTeamTrans[index].GetComponent<Button>().onClick.AddListener(() => Select(index));
        }
    }

    //레일에서 스킬을 선택하면 해당 함수를 호출하여 사용 범위를 설정
    //(빈 곳을 클릭하면 스킬 사용 취소)
    public void StartSelect(Skill skillV)
    {
        skill = skillV;

        switch (skill.GetSkillInfo().target)
        {
            case Target.Team:
                targetEnemy.SetActive(false);
                targetTeam.SetActive(true);
                break;

            case Target.Enemy:
                targetEnemy.SetActive(true);
                targetTeam.SetActive(false);
                break;

            case Target.All:
                targetEnemy.SetActive(true);
                targetTeam.SetActive(true);
                break;
        }
    }

    //스킬의 범위를 확정했을 때 호출
    public abstract void Select(byte v);

    //스킬 사용을 취소하거나 스킬 사용을 확정했을 때 호출
    protected void Close()
    {
        if (targets[0] != null)
        {
            skill.TargetSelected(targets);
            skill.UseSkill();
            GameCtrl.instance.UseCost(skill.GetSkillInfo().cost);
        }

        connector.CloseSelecting();
    }

    //스킬 타깃을 반환
    public Character[] GetTargets()
    {
        return targets;
    }
}
