using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, Vector2.zero);

            bool blocked = false; // 클릭이 차단되었는지 여부를 추적

            foreach (var hit in hits)
            {
                if (hit.collider != null)
                {
                    // 클릭 차단을 위한 조건, 예를 들어 태그 확인
                    if (hit.collider.CompareTag("Blocker"))
                    {
                        Debug.Log("클릭 차단 오브젝트에 맞았습니다: " + hit.collider.gameObject.name);
                        blocked = true;
                        break; // 차단 오브젝트에 이미 맞았으므로 추가 검사 중단
                    }
                }
            }
        }   
    }
}
