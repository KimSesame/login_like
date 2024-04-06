using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyCharacters : MonoBehaviour
{
    public float health = 20;
    public float shield = 0;
    public float attackDamage = 3;
    public KeyCode attackKey = KeyCode.Q;
    public GameObject opponent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(attackKey))
            Attack();
    }

    void Attack()
    {
        opponent.GetComponent<OpponentCharacters>().TakeDamage(attackDamage);
    }
}
