using UnityEngine;
using UnityEngine.UI;

public abstract class TargetSelector : MonoBehaviour
{
    TargetSelectConnector connector;

    protected GameObject targetEnemy, targetTeam;

    protected Skill skill/*����� ��ų*/;

    protected Character[] targets/*��ų�� ������ �ش��ϴ� Ÿ�� �迭*/;

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

    /// <summary>
    /// ���Ͽ��� ��ų�� �����ϸ� �ش� �Լ��� ȣ���Ͽ� ��� ������ ����
    /// (�� ���� Ŭ���ϸ� ��ų ��� ���)
    /// </summary>
    /// <param name="skillV">��� ��ų</param>
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

    /// <summary>
    /// ��ų�� ������ Ȯ������ �� ȣ��
    /// </summary>
    /// <param name="v">������ ��ġ ��ȣ</param>
    public abstract void Select(byte v);

    /// <summary>
    /// ��ų ����� ����ϰų� ��ų ����� Ȯ������ �� ȣ��
    /// </summary>
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

    /// <summary>
    /// ��ų Ÿ���� ��ȯ
    /// </summary>
    /// <returns>���õ� Ÿ���</returns>
    public Character[] GetTargets()
    {
        return targets;
    }
}
