using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SkillSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject skill1;
    float max=8;
    public static float cur=0;
    float timer=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        timer+=Time.deltaTime;
        if(cur<=max&&timer>1){
            GameObject newskill = Instantiate(skill1);
            newskill.transform.position=new Vector3(10,0.13f,0);
            cur++;
            timer=0;
        }
    }
}
