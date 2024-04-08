using TMPro;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    //'GameCtrl.instance'의 형식으로 해당 스크립트를 호출
    public static GameCtrl instance;

    public delegate void OnTurnStart();
    public delegate void OnTurnEnd();
    public OnTurnStart TurnStart;
    public OnTurnEnd TurnEnd;

    public GameObject skillTargetingWin/*스킬의 범위를 설정할 창*/;
    TargetSelectConnector targetSelectConnector;

    [SerializeField]
    Transform teamPosTrans, enemyPosTrans;
    public Transform[] teamPos/*아군 배치 위치 배열*/, 
        enemyPos/*적군 배치 위치 배열*/;

    [SerializeField]
    TMP_Text nowCostShower/*현재 남은 비용을 표시*/;
    byte nowCost/*현재 비용*/, maxCost/*최대 비용*/ = 6;

    private void Awake()
    {
        instance = this;

        teamPos = new Transform[teamPosTrans.childCount];
        enemyPos = new Transform[enemyPosTrans.childCount];

        for (int i = 0; i < teamPosTrans.childCount; i++)
        {
            teamPos[i] = teamPosTrans.GetChild(i);
            enemyPos[i] = enemyPosTrans.GetChild(i);
        }

        targetSelectConnector = skillTargetingWin.GetComponent<TargetSelectConnector>();

        nowCost = maxCost;

        CostSet();
    }

    //레일에서 스킬을 선택할 때 호출하여 사용 스킬 정보를 전달
    public void SelectSkill(Skill skill)
    {
        if (skill.GetSkillInfo().cost > nowCost)
        {
            Debug.Log("Not enough cost");
        }
        else
        {
            skillTargetingWin.SetActive(true);
            targetSelectConnector.StartTargetSelect(skill);
        }
    }

    //레일에서 스킬을 선택할 때 호출하여 사용 스킬 정보를 전달
    public void SelectSkill(Skill skill, Character owner)
    {
        if (skill.GetSkillInfo().cost > nowCost)
        {
            Debug.Log("Not enough cost");
        }
        else
        {
            skillTargetingWin.SetActive(true);
            targetSelectConnector.StartTargetSelect(skill);
        }
    }

    public void TurnEnder()
    {
        TurnEnd();
        nowCost = maxCost;
        CostSet();
        TurnStart();
    }

    //스킬 사용을 확정했을 때 호출하여 비용을 소모
    public void UseCost(byte cost)
    {
        nowCost -= cost;
        CostSet();
    }

    //현재 남은 비용을 보여줌
    public void CostSet()
    {
        nowCostShower.text = $"{nowCost}/6";
    }
}
