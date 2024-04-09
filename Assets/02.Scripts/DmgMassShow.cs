using TMPro;
using UnityEngine;

public class DmgMassShow : MonoBehaviour
{
    public void Set(byte dmgType, float mass)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -6f);
        GetComponent<TMP_Text>().text = $"{mass}";
        Destroy(gameObject, 1);
    }
}
