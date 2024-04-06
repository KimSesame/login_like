using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillAffected : MonoBehaviour
{
    public SkillAffectType skillAffect/*�ش� ��ų�� ����*/;
    public Image iconImg/*�ش� ��ų�� ������ ǥ�� �̹���*/;
    public TMP_Text remainTurnShower/*ȿ���� ���� ���� �� ǥ��*/;
    public bool boolean/*���� ������ bool Ÿ�� ������ ����*/;
    public float mass/*�ش� ��ų�� ȿ����*/;
    public byte remainTurn/*���� ��*/;

    //�ش� ��ũ��Ʈ�� �ʱ� ����
    public void Set(Sprite iconV, SkillAffectType skillAffectType, bool booleanV, float massV, byte remainV)
    {
        iconImg.sprite = iconV;
        skillAffect = skillAffectType;
        boolean = booleanV;
        mass = massV;
        remainTurn = remainV;
        remainTurnShower.text = $"{remainTurn}";
    }

    //���� ������ �ش� ��ų�� ���� ȿ�� ���� ���� �����ϰ�
    //���� ���� ���� ��� true��
    //���� ȿ���� ���ӵ� ��� false�� ��ȯ
    public bool TurnDeC()
    {
        remainTurn--;
        remainTurnShower.text = $"{remainTurn}";
        if (remainTurn <= 0) return true;
        else return false;
    }
}
