using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    GameObject skillAffectsPrefab/*스킬의 효과가 남는 스킬들*/,
        dmgShowerPrefab/*피해를 받을 시 피해량을 표시해 줄 프리팹*/;
    [SerializeField]
    Transform stateTrans/*버프, 디버프 등에 효과를 받고 있는 것을 보여줄 표시들을 담을 부모 오브젝트*/;
    [SerializeField]
    protected Status status; //캐릭터 고유 능력치
    float finalAtk/*최종 공격력*/,
        finalDef/*최종 방어력*/,
        nowHp /*현재 체력*/;

    [SerializeField]
    Image nowHpImg/*현재 체력 표시 효과 이미지*/;
    [SerializeField]
    TMP_Text hpShower/*현재 체력 표시*/,
        defShower/*현재 방어도 표시*/;

    Queue<SkillAffected> affectsOnTurnStart //턴이 시작될 때 효과를 주는 스킬들
        = new Queue<SkillAffected>();
    Queue<SkillAffected> affectsOnTurnEnd //턴이 끝날 때 효과를 주는 스킬들
        = new Queue<SkillAffected>();
    Queue<SkillAffected> affectsWhenDamaged //피해를 입을 때 효과를 주는 스킬들
        = new Queue<SkillAffected>();

    private void Awake()
    {
        finalAtk = status.atk;
        finalDef = status.def;
        nowHp = status.maxHp;

        defShower.text = $"{finalDef}";

        SetHpShower();
    }

    private void OnEnable()
    {
        GameCtrl.instance.TurnStart += OnTurnStart;
        GameCtrl.instance.TurnEnd += OnTurnEnd;
    }

    private void OnDisable()
    {
        GameCtrl.instance.TurnStart -= OnTurnStart;
        GameCtrl.instance.TurnEnd -= OnTurnEnd;
    }

    //턴이 시작될 때 호출
    public void OnTurnStart()
    {
        int count = affectsOnTurnStart.Count;
        SkillAffected skillAffected;
        for (int i = 0; i < count; i++)
        {
            skillAffected = affectsOnTurnStart.Dequeue();
            switch (skillAffected.skillAffect)
            {
                case SkillAffectType.DELAY:
                    GetSkilledDamaged(skillAffected.mass, skillAffected.boolean);
                    break;

                case SkillAffectType.DOT:
                    GetSkilledDamaged(skillAffected.mass, skillAffected.boolean);
                    break;
            }
            if (skillAffected.TurnDeC()) Destroy(skillAffected.gameObject);
            else affectsOnTurnStart.Enqueue(skillAffected);
        }
    }

    //턴이 종료될 때 호출
    public void OnTurnEnd()
    {
        float defTmp = 0, atkTmp = 0;
        int count = affectsOnTurnEnd.Count;
        SkillAffected skillAffected;
        for (int i = 0; i < count; i++)
        {
            skillAffected = affectsOnTurnEnd.Dequeue();
            switch (skillAffected.skillAffect)
            {
                case SkillAffectType.DEFENSE:
                    if (skillAffected.TurnDeC()) Destroy(skillAffected.gameObject);
                    else
                    {
                        defTmp += skillAffected.mass;
                        affectsOnTurnEnd.Enqueue(skillAffected);
                    }
                    break;

                case SkillAffectType.ATK_INC:
                    if (skillAffected.TurnDeC()) Destroy(skillAffected.gameObject);
                    else
                    {
                        atkTmp += skillAffected.mass;
                        affectsOnTurnEnd.Enqueue(skillAffected);
                    }
                    break;
            }
        }

        finalAtk = atkTmp + status.atk;
        finalDef = Mathf.Clamp(defTmp + status.def, 0, status.maxHp / 2);

        defShower.text = $"{finalDef}";
    }

    //캐릭터의 최종 공격력 반환
    public float GetAtk()
    {
        return finalAtk;
    }

    //캐릭터의 최종 방어도 반환
    public float GetDef()
    {
        return finalDef;
    }

    //캐릭터의 현재 체력을 표시
    public void SetHpShower()
    {
        nowHpImg.fillAmount = nowHp / status.maxHp;
        hpShower.text = $"{(int)nowHp}/{(int)status.maxHp}";
    }

    //해당 캐릭터가 선택되었을 때 호출
    public abstract void Selected();

    //피해를 받을 때 호출
    public float GetSkilledDamaged(float mass1/*피해량*/, bool isPenetrate/*관통공격인지 확인*/)
    {
        float dmgedInc = 1;
        int count = affectsWhenDamaged.Count;
        SkillAffected skillAffected;
        for (int i = 0; i < count; i++)
        {
            skillAffected = affectsWhenDamaged.Dequeue();
            switch (skillAffected.skillAffect)
            {
                case SkillAffectType.MARK:
                    if (skillAffected.TurnDeC()) Destroy(skillAffected.gameObject);
                    else
                    {
                        dmgedInc += skillAffected.mass;
                        affectsWhenDamaged.Enqueue(skillAffected);
                    }
                    break;
            }
        }

        float dmgMass;
        if (isPenetrate) dmgMass = mass1 * dmgedInc;
        else dmgMass = Mathf.Clamp((mass1 - finalDef) * dmgedInc, 0, (mass1 - finalDef) * dmgedInc);
        
        nowHp = Mathf.Clamp(nowHp - dmgMass, 0, status.maxHp);

        Instantiate(dmgShowerPrefab, transform.position, Quaternion.identity).GetComponent<DmgMassShow>().Set(0, dmgMass);

        SetHpShower();

        if (nowHp <= 0)
        {
            Debug.Log("Dead");
            Destroy(gameObject);
        }

        return dmgMass;
    }

    //다중 공격을 받을 때 호출
    public void GetSkilledMulipleDamage(float mass1, byte mass2, bool isPenetrate)
    {
        StartCoroutine(MultipleDMG(mass1, mass2, isPenetrate));
    }

    //시간차 공격을 받을 때 호출
    public void GetSkilledDelayDamage(float mass, bool isPenetrate, Sprite iconV)
    {
        SkillAffected affectObj = Instantiate(skillAffectsPrefab, stateTrans).GetComponent<SkillAffected>();
        affectObj.Set(iconV, SkillAffectType.DELAY, isPenetrate, mass, 1);
        affectsOnTurnStart.Enqueue(affectObj);
    }

    //힐을 받을 때 호출
    public void GetSkilledHeal(float mass1)
    {
        nowHp = Mathf.Clamp(nowHp + mass1, 0, status.maxHp);

        SetHpShower();
    }

    //방어도를 부여받을 때 호출
    public void GetSkilledDefense(float mass1/*방어도*/, byte mass2/*지속 턴*/, Sprite iconV)
    {
        SkillAffected affectObj = Instantiate(skillAffectsPrefab, stateTrans).GetComponent<SkillAffected>();
        finalDef = Mathf.Clamp(finalDef + mass1, 0, status.maxHp / 2);
        affectObj.Set(iconV, SkillAffectType.DEFENSE, false, mass1, mass2);
        affectsOnTurnEnd.Enqueue(affectObj);
        defShower.text = $"{finalDef}";
    }

    //공격력 증가를 부여받을 때 호출
    public void GetSkilledAtkInc(float mass1/*공격력 증가량*/, byte mass2/*지속 턴*/, Sprite iconV)
    {
        SkillAffected affectObj = Instantiate(skillAffectsPrefab, stateTrans).GetComponent<SkillAffected>();
        finalAtk += mass1;
        affectObj.Set(iconV, SkillAffectType.ATK_INC, false, mass1, mass2);
        affectsOnTurnEnd.Enqueue(affectObj);
    }

    //표식을 받을 때 호출
    public void GetSkilledMark(float mass/*받는 피해 증가량*/, Sprite iconV)
    {
        SkillAffected affectObj = Instantiate(skillAffectsPrefab, stateTrans).GetComponent<SkillAffected>();
        affectObj.Set(iconV, SkillAffectType.MARK, false, mass, 1);
        affectsWhenDamaged.Enqueue(affectObj);
    }

    //다중 공격 효과 구현
    IEnumerator MultipleDMG(float mass1, byte mass2, bool isPenetrate)
    {
        WaitForSeconds seconds = new WaitForSeconds(0.1f);
        byte count = 0;

        while (count < mass2)
        {
            GetSkilledDamaged(mass1, isPenetrate);
            count++;

            yield return seconds;
        }
    }
}
