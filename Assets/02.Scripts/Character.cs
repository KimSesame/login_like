using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    GameObject skillAffectsPrefab/*��ų�� ȿ���� ���� ��ų��*/,
        dmgShowerPrefab/*���ظ� ���� �� ���ط��� ǥ���� �� ������*/;
    [SerializeField]
    Transform stateTrans/*����, ����� � ȿ���� �ް� �ִ� ���� ������ ǥ�õ��� ���� �θ� ������Ʈ*/;
    [SerializeField]
    protected Status status; //ĳ���� ���� �ɷ�ġ
    float finalAtk/*���� ���ݷ�*/,
        finalDef/*���� ����*/,
        nowHp /*���� ü��*/;

    [SerializeField]
    Image nowHpImg/*���� ü�� ǥ�� ȿ�� �̹���*/;
    [SerializeField]
    TMP_Text hpShower/*���� ü�� ǥ��*/,
        defShower/*���� �� ǥ��*/;

    Queue<SkillAffected> affectsOnTurnStart //���� ���۵� �� ȿ���� �ִ� ��ų��
        = new Queue<SkillAffected>();
    Queue<SkillAffected> affectsOnTurnEnd //���� ���� �� ȿ���� �ִ� ��ų��
        = new Queue<SkillAffected>();
    Queue<SkillAffected> affectsWhenDamaged //���ظ� ���� �� ȿ���� �ִ� ��ų��
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

    //���� ���۵� �� ȣ��
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

    //���� ����� �� ȣ��
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

    //ĳ������ ���� ���ݷ� ��ȯ
    public float GetAtk()
    {
        return finalAtk;
    }

    //ĳ������ ���� �� ��ȯ
    public float GetDef()
    {
        return finalDef;
    }

    //ĳ������ ���� ü���� ǥ��
    public void SetHpShower()
    {
        nowHpImg.fillAmount = nowHp / status.maxHp;
        hpShower.text = $"{(int)nowHp}/{(int)status.maxHp}";
    }

    //�ش� ĳ���Ͱ� ���õǾ��� �� ȣ��
    public abstract void Selected();

    //���ظ� ���� �� ȣ��
    public float GetSkilledDamaged(float mass1/*���ط�*/, bool isPenetrate/*����������� Ȯ��*/)
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

    //���� ������ ���� �� ȣ��
    public void GetSkilledMulipleDamage(float mass1, byte mass2, bool isPenetrate)
    {
        StartCoroutine(MultipleDMG(mass1, mass2, isPenetrate));
    }

    //�ð��� ������ ���� �� ȣ��
    public void GetSkilledDelayDamage(float mass, bool isPenetrate, Sprite iconV)
    {
        SkillAffected affectObj = Instantiate(skillAffectsPrefab, stateTrans).GetComponent<SkillAffected>();
        affectObj.Set(iconV, SkillAffectType.DELAY, isPenetrate, mass, 1);
        affectsOnTurnStart.Enqueue(affectObj);
    }

    //���� ���� �� ȣ��
    public void GetSkilledHeal(float mass1)
    {
        nowHp = Mathf.Clamp(nowHp + mass1, 0, status.maxHp);

        SetHpShower();
    }

    //���� �ο����� �� ȣ��
    public void GetSkilledDefense(float mass1/*��*/, byte mass2/*���� ��*/, Sprite iconV)
    {
        SkillAffected affectObj = Instantiate(skillAffectsPrefab, stateTrans).GetComponent<SkillAffected>();
        finalDef = Mathf.Clamp(finalDef + mass1, 0, status.maxHp / 2);
        affectObj.Set(iconV, SkillAffectType.DEFENSE, false, mass1, mass2);
        affectsOnTurnEnd.Enqueue(affectObj);
        defShower.text = $"{finalDef}";
    }

    //���ݷ� ������ �ο����� �� ȣ��
    public void GetSkilledAtkInc(float mass1/*���ݷ� ������*/, byte mass2/*���� ��*/, Sprite iconV)
    {
        SkillAffected affectObj = Instantiate(skillAffectsPrefab, stateTrans).GetComponent<SkillAffected>();
        finalAtk += mass1;
        affectObj.Set(iconV, SkillAffectType.ATK_INC, false, mass1, mass2);
        affectsOnTurnEnd.Enqueue(affectObj);
    }

    //ǥ���� ���� �� ȣ��
    public void GetSkilledMark(float mass/*�޴� ���� ������*/, Sprite iconV)
    {
        SkillAffected affectObj = Instantiate(skillAffectsPrefab, stateTrans).GetComponent<SkillAffected>();
        affectObj.Set(iconV, SkillAffectType.MARK, false, mass, 1);
        affectsWhenDamaged.Enqueue(affectObj);
    }

    //���� ���� ȿ�� ����
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
