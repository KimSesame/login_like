using TMPro;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    /// <summary>
    /// �����: GameCtrl.instance.����� �Լ�
    /// </summary>
    public static GameCtrl instance;

    public delegate void OnTurnStart();
    public delegate void OnTurnEnd();
    public OnTurnStart TurnStart;
    public OnTurnEnd TurnEnd;

    public GameObject skillTargetingWin/*��ų�� ������ ������ â*/;
    TargetSelectConnector targetSelectConnector;

    [SerializeField]
    Transform teamPosTrans, enemyPosTrans;
    public Transform[] teamPos/*�Ʊ� ��ġ ��ġ �迭*/, enemyPos/*���� ��ġ ��ġ �迭*/;

    [SerializeField]
    TMP_Text nowCostShower/*���� ���� ����� ǥ��*/;
    byte nowCost/*���� ���*/, maxCost = 6/*�ִ� ���*/;

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

    /// <summary>
    /// ���Ͽ��� ��ų�� ������ �� ȣ���Ͽ� ��� ��ų ������ ����
    /// </summary>
    /// <param name="skill"></param>
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

    /// <summary>
    /// ���Ͽ��� ��ų�� ������ �� ȣ���Ͽ� ��� ��ų ������ ����
    /// </summary>
    /// <param name="skill">����� ��ų</param>
    /// <param name="owner">��ų�� ���� ĳ����</param>
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

    /// <summary>
    /// ��ų ����� Ȯ������ �� ȣ���Ͽ� ����� �Ҹ�
    /// </summary>
    /// <param name="cost"></param>
    public void UseCost(byte cost)
    {
        nowCost -= cost;
        CostSet();
    }

    /// <summary>
    /// ���� ���� ����� ������
    /// </summary>
    public void CostSet()
    {
        nowCostShower.text = $"{nowCost}/6";
    }
}
