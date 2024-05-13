using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckWindow : MonoBehaviour
{
    public GameObject imgPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SkillSpawn.isScrollFilled)
        {
            CreateImage();
        }
    }

    void CreateImage()
    {
        Vector2 img_create_pos = new Vector2(-500, 150);

        for (int i = 0; i < Deck.deck.Count; i++)
        {
            GameObject imgObject = Instantiate(imgPrefab, img_create_pos,Quaternion.identity);
            Image img = imgObject.GetComponent<Image>();
            Sprite sp = Deck.deck[i].GetComponent<SpriteRenderer>().sprite;

            img.sprite = sp;

            imgObject.transform.SetParent(GameObject.Find("DeckWindow").transform, false);

            img_create_pos.x += 250;

            if(img_create_pos.x>500)
            {
                img_create_pos.x = -500;
                img_create_pos.y -= 300;
            }
        }
    }
}
