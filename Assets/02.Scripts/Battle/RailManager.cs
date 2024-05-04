using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RailManager : MonoBehaviour
{
    //public BattleManager battleManager;
    public int skillCount;
    public GameObject[] skillPrefabs;
    public int railMax = -1;

    private bool[] usedSkills;
    private int[] rail;

    void Awake()
    {
        Physics2D.gravity = new Vector2(-9.81f, 0);

        //battleManager = GetComponent<BattleManager>();
        rail = new int[skillCount];
        usedSkills = new bool[skillCount];

        for (int i = 0; i < skillCount; i++)
        {
            rail[i] = -1;
            usedSkills[i] = false;
        }
    }

    void Start()
    {
        InvokeRepeating(nameof(SpawnSkill), 1, 3);
    }

    int SpawnSkill()
    {
        int idx = Random.Range(0, skillCount);

        if (usedSkills[idx] == false)
        {
            Instantiate(skillPrefabs[idx], transform.position, Quaternion.identity);
            usedSkills[idx] = true;
            railMax++;
            return idx;
        }

        return -1;
    }

}
