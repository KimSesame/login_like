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
    bool selected;
    public Transform moveTarget;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && !selected)
        {
            rb.velocity = new Vector2(-1, 0) * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
            Vector3 currentPosition = transform.position;
            transform.position = currentPosition;
        }

        if (selected)
        {
            transform.position = Vector3.Lerp(transform.position, moveTarget.position, Time.deltaTime * 4);
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * 2);
            transform.Rotate(Vector3.forward * 2);
            if ((transform.position - moveTarget.position).sqrMagnitude < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }
    
    private void OnMouseDown()
    {
        //클릭시
        if (click == true)
        {
            Deck.usedSkills.Add(gameObject.GetComponent<SpriteRenderer>().sprite);

            SkillSpawn.cur--;

            GetComponent<Skill>().SkillSelected();
            selected = true;
            Destroy(GetComponent<BoxCollider2D>());
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // "Wall" 태그를 가진 오브젝트와 충돌 시 멈춤
        if (collision.gameObject.transform.position.x < transform.position.x && collision.gameObject.CompareTag("Wall"))
        {
            canMove = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // "Wall" 태그를 가진 오브젝트와 충돌이 끝나면 다시 이동 가능
        if (collision.gameObject.transform.position.x < transform.position.x && collision.gameObject.CompareTag("Wall"))
        {
            canMove = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        click = true;

        Deck.deck.Remove(gameObject);
    }

    public void MoveToTrashBox(Transform targetPos)
    {

    }
}
