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

    /// <summary>
    /// ���� ���۵� �� ȣ��
    /// </summary>
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

    /// <summary>
    /// ���� ����� �� ȣ��
    /// </summary>
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

    /// <summary>
    /// ĳ������ ���� ���ݷ� ��ȯ
    /// </summary>
    /// <returns>���� ���ݷ�</returns>
    public float GetAtk()
    {
        return finalAtk;
    }

    /// <summary>
    /// ĳ������ ���� �� ��ȯ
    /// </summary>
    /// <returns>���� ��</returns>
    public float GetDef()
    {
        return finalDef;
    }

    /// <summary>
    /// ĳ������ ���� ü���� ǥ��
    /// </summary>
    public void SetHpShower()
    {
        nowHpImg.fillAmount = nowHp / status.maxHp;
        hpShower.text = $"{(int)nowHp}/{(int)status.maxHp}";
    }

    /// <summary>
    /// �ش� ĳ���Ͱ� ���õǾ��� �� ȣ��
    /// </summary>
    public abstract void Selected();

    /// <summary>
    /// ���ظ� ���� �� ȣ��
    /// </summary>
    /// <param name="mass1">���ط�</param>
    /// <param name="isPenetrate">���� ����</param>
    /// <returns>���� ���� ���ط�</returns>
    public float GetSkilledDamaged(float mass1, bool isPenetrate)
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

    /// <summary>
    /// ���� ������ ���� �� ȣ��
    /// </summary>
    /// <param name="mass1">���ط�</param>
    /// <param name="mass2">Ƚ��</param>
    /// <param name="isPenetrate">�������</param>
    public void GetSkilledMulipleDamage(float mass1, byte mass2, bool isPenetrate)
    {
        StartCoroutine(MultipleDMG(mass1, mass2, isPenetrate));
    }

    /// <summary>
    /// �ð��� ������ ���� �� ȣ��
    /// </summary>
    /// <param name="mass">���ط�</param>
    /// <param name="isPenetrate">�������</param>
    /// <param name="iconV">��ų �̹���</param>
    public void GetSkilledDelayDamage(float mass, bool isPenetrate, Sprite iconV)
    {
        SkillAffected affectObj = Instantiate(skillAffectsPrefab, stateTrans).GetComponent<SkillAffected>();
        affectObj.Set(iconV, SkillAffectType.DELAY, isPenetrate, mass, 1);
        affectsOnTurnStart.Enqueue(affectObj);
    }

    /// <summary>
    /// ���� ���� �� ȣ��
    /// </summary>
    /// <param name="mass1">����</param>
    public void GetSkilledHeal(float mass1)
    {
        nowHp = Mathf.Clamp(nowHp + mass1, 0, status.maxHp);

        SetHpShower();
    }

    /// <summary>
    /// ���� �ο����� �� ȣ��
    /// </summary>
    /// <param name="mass1">��</param>
    /// <param name="mass2">���� ��</param>
    /// <param name="iconV">��ų �̹���</param>
    public void GetSkilledDefense(float mass1, byte mass2, Sprite iconV)
    {
        SkillAffected affectObj = Instantiate(skillAffectsPrefab, stateTrans).GetComponent<SkillAffected>();
        finalDef = Mathf.Clamp(finalDef + mass1, 0, status.maxHp / 2);
        affectObj.Set(iconV, SkillAffectType.DEFENSE, false, mass1, mass2);
        affectsOnTurnEnd.Enqueue(affectObj);
        defShower.text = $"{finalDef}";
    }

    /// <summary>
    /// ���ݷ� ������ �ο����� �� ȣ��
    /// </summary>
    /// <param name="mass1">���ݷ� ������</param>
    /// <param name="mass2">���� ��</param>
    /// <param name="iconV">��ų �̹���</param>
    public void GetSkilledAtkInc(float mass1, byte mass2, Sprite iconV)
    {
        SkillAffected affectObj = Instantiate(skillAffectsPrefab, stateTrans).GetComponent<SkillAffected>();
        finalAtk += mass1;
        affectObj.Set(iconV, SkillAffectType.ATK_INC, false, mass1, mass2);
        affectsOnTurnEnd.Enqueue(affectObj);
    }

    /// <summary>
    /// ǥ���� ���� �� ȣ��
    /// </summary>
    /// <param name="mass">�޴� ���� ������</param>
    /// <param name="iconV">��ų �̹���</param>
    public void GetSkilledMark(float mass, Sprite iconV)
    {
        SkillAffected affectObj = Instantiate(skillAffectsPrefab, stateTrans).GetComponent<SkillAffected>();
        affectObj.Set(iconV, SkillAffectType.MARK, false, mass, 1);
        affectsWhenDamaged.Enqueue(affectObj);
    }

    /// <summary>
    /// ���� ���� ȿ�� ����
    /// </summary>
    /// <param name="mass1">���ط�</param>
    /// <param name="mass2">���� Ƚ��</param>
    /// <param name="isPenetrate">�������</param>
    /// <returns></returns>
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
