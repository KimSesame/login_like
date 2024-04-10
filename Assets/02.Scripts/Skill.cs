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

    //��ų�� ����� �� �ش� �Լ��� ȣ���Ͽ� Ÿ���� ����
    public void TargetSelected(Character[] targetsV)
    {
        targets = targetsV;
    }

    //�ش� ��ų�� ����� Ȯ���Ǿ��� �� ȣ���Ͽ� ��ų�� ���
    public abstract void UseSkill();

    //�ش� ��ų�� ������ ��ȯ
    public SkillInfo GetSkillInfo()
    {
        return skillInfo;
    }

    //�ش� ��ų�� ������ ��ȯ
    public SkillType GetSkillType()
    {
        return skillType;
    }

    //�ش� ��ų�� �� ������ ��ȯ
    public abstract Enum GetSkillNum();
}
