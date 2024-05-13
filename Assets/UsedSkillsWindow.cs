using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsedSkillsWindow : MonoBehaviour
{
    public GameObject imgPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CreateImage();
        Debug.Log($"{Deck.usedSkills.Count}");
    }

    void CreateImage()
    {
        Vector2 img_create_pos = new Vector2(-500, 150);

        for (int i = 0; i < Deck.usedSkills.Count; i++)
        {
            GameObject imgObject = Instantiate(imgPrefab, img_create_pos, Quaternion.identity);
            Image img = imgObject.GetComponent<Image>();
            Sprite sp = Deck.usedSkills[i];

            img.sprite = sp;

            imgObject.transform.SetParent(GameObject.Find("UsedSkillsWindow").transform, false);

            img_create_pos.x += 250;

            if (img_create_pos.x > 500)
            {
                img_create_pos.x = -500;
                img_create_pos.y -= 300;
            }
        }
    }
}
