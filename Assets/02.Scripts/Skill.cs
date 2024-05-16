using System;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField]
    protected SkillInfo skillInfo/*�ش� ��ų�� ����*/;
    protected SkillType skillType /*�ش� ��ų�� ����*/;
    protected Character[] targets/*��ų ��� Ÿ��� �迭*/;
    [SerializeField]
    public Character owner; //�ش� ��ų�� ���� ĳ����
    protected ushort serialNum; //ĳ���� ���� ��ȣ

    public void SkillSelected()
    {
        if (skillType == SkillType.TypeDefense) GameCtrl.instance.SelectSkill(this, owner);
        else GameCtrl.instance.SelectSkill(this);
    }

    /// <summary>
    /// ��ų�� ����� �� �ش� �Լ��� ȣ���Ͽ� Ÿ���� ����
    /// </summary>
    /// <param name="targetsV">��ų�� ������ �޴� Ÿ���</param>
    public void TargetSelected(Character[] targetsV)
    {
        targets = targetsV;
    }

    /// <summary>
    /// �ش� ��ų�� ����� Ȯ���Ǿ��� �� ȣ���Ͽ� ��ų�� ���
    /// </summary>
    public abstract void UseSkill();

    /// <summary>
    /// �ش� ��ų�� ������ ��ȯ
    /// </summary>
    /// <returns>��ų ����</returns>
    public SkillInfo GetSkillInfo()
    {
        return skillInfo;
    }

    /// <summary>
    /// �ش� ��ų�� ������ ��ȯ
    /// </summary>
    /// <returns>��ų Ÿ��</returns>
    public SkillType GetSkillType()
    {
        return skillType;
    }

    /// <summary>
    /// �ش� ��ų�� �� ������ ��ȯ
    /// </summary>
    /// <returns>��ų ����</returns>
    public abstract Enum GetSkillNum();
}
