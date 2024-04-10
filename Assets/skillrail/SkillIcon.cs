using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillIcon : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 9f;
    private Rigidbody2D rb;
    private bool canMove = true;

    private bool click = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            rb.velocity = new Vector2(-1, 0) * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
            Vector3 currentPosition = transform.position;
            transform.position = currentPosition;
        }

    }

    private void OnMouseDown()
    {//클릭시
        if (click == true)
        {
            Destroy(gameObject);
            SkillSpawn.cur--;

            GetComponent<Skill>().SkillSelected();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // "Wall" 태그를 가진 오브젝트와 충돌 시 멈춤
        if (collision.gameObject.tag == "Wall")
        {
            canMove = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // "Wall" 태그를 가진 오브젝트와 충돌이 끝나면 다시 이동 가능
        if (collision.gameObject.tag == "Wall")
        {
            canMove = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        click = true;
    }
}
