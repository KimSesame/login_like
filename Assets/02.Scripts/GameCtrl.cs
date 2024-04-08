using TMPro;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    //'GameCtrl.instance'�� �������� �ش� ��ũ��Ʈ�� ȣ��
    public static GameCtrl instance;

    public delegate void OnTurnStart();
    public delegate void OnTurnEnd();
    public OnTurnStart TurnStart;
    public OnTurnEnd TurnEnd;

    public GameObject skillTargetingWin/*��ų�� ������ ������ â*/;
    TargetSelectConnector targetSelectConnector;

    [SerializeField]
    Transform teamPosTrans, enemyPosTrans;
    public Transform[] teamPos/*�Ʊ� ��ġ ��ġ �迭*/, 
        enemyPos/*���� ��ġ ��ġ �迭*/;

    [SerializeField]
    TMP_Text nowCostShower/*���� ���� ����� ǥ��*/;
    byte nowCost/*���� ���*/, maxCost/*�ִ� ���*/ = 6;

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

    //���Ͽ��� ��ų�� ������ �� ȣ���Ͽ� ��� ��ų ������ ����
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

    //���Ͽ��� ��ų�� ������ �� ȣ���Ͽ� ��� ��ų ������ ����
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

    //��ų ����� Ȯ������ �� ȣ���Ͽ� ����� �Ҹ�
    public void UseCost(byte cost)
    {
        nowCost -= cost;
        CostSet();
    }

    //���� ���� ����� ������
    public void CostSet()
    {
        nowCostShower.text = $"{nowCost}/6";
    }
}
