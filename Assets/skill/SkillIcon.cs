using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillIcon : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    private Rigidbody2D rb;
    private bool canMove = true;
    void Start()
    {   
         rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity= new Vector2(-1,0)*speed;
    }
    
    private void OnMouseDown() {//클릭시
        Destroy(gameObject);
        SkillSpawn.cur--;
    }
}
