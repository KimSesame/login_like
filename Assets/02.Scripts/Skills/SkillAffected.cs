using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillAffected : MonoBehaviour
{
    public SkillAffectType skillAffect/*해당 스킬의 종류*/;
    public Image iconImg/*해당 스킬의 아이콘 표시 이미지*/;
    public TMP_Text remainTurnShower/*효과의 남은 지속 턴 표시*/;
    public bool boolean/*여러 종류의 bool 타입 변수를 담음*/;
    public float mass/*해당 스킬의 효과량*/;
    public byte remainTurn/*남은 턴*/;

    //해당 스크립트의 초기 설정
    public void Set(Sprite iconV, SkillAffectType skillAffectType, bool booleanV, float massV, byte remainV)
    {
        iconImg.sprite = iconV;
        skillAffect = skillAffectType;
        boolean = booleanV;
        mass = massV;
        remainTurn = remainV;
        remainTurnShower.text = $"{remainTurn}";
    }

    //턴이 끝나고 해당 스킬의 남은 효과 지속 턴을 감소하고
    //남은 턴이 없을 경우 true를
    //아직 효과가 지속될 경우 false를 반환
    public bool TurnDeC()
    {
        remainTurn--;
        remainTurnShower.text = $"{remainTurn}";
        if (remainTurn <= 0) return true;
        else return false;
    }
}
