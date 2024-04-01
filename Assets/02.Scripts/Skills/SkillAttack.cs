using UnityEngine;

public class SkillAttack : MonoBehaviour
{
    [SerializeField]
    SkillTypeAttack typeAttack;

    public void UseSkill()
    {
        if (typeAttack.locked) Debug.Log("Skill a locked");
        else Debug.Log("Use skill a");
    }
}
