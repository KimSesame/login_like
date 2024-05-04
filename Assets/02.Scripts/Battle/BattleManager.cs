using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public int totalMana;
    public int currentMana;
    public GameObject[] skills;
    public int skillCount;
    public int railLimit;
    public TextMeshProUGUI totalManaText;
    public TextMeshProUGUI currentManaText;

    void Awake()
    {
        UpdateMana();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMana();
    }

    // Update Mana UI
    void UpdateMana()
    {
        totalManaText.text = totalMana.ToString();
        currentManaText.text = currentMana.ToString();

        // Change current Mana font color
        if (currentMana <= 0)
            currentManaText.color = Color.red;
        else
            currentManaText.color = Color.black;


    }

}
