using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public static List<GameObject> deck = new List<GameObject>();
    public static List<GameObject> usedSkills = new List<GameObject> ();

    public GameObject popup;


    // Start is called before the first frame update
    void Start()
    {
        /*
        deck.Add(skill1);
        deck.Add(skill2);
        deck.Add(skill3);
        deck.Add(skill4);
        deck.Add(skill5);
        deck.Add(skill6);
        deck.Add(skill7);
        */
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void updateDeckWindow()
    {

    }

    private void OnMouseDown()
    {
        popup.SetActive(!popup.activeSelf);
    }
}
