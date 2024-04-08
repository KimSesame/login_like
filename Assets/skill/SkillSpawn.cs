using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SkillSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject skill1;
    public GameObject skill2;
    public GameObject skill3;
    public GameObject skill4;
    public GameObject skill5;
    public GameObject skill6;
    public GameObject skill7;

    public List<GameObject> slist = new List<GameObject>();
    List<int> numbers = new List<int> { 0,1, 2, 3, 4, 5, 6 };
    float max=8;
    public static float cur=0;

    public int sufflecount=0;
    float timer=0;
    void Start()
    {
        ShuffleList(numbers);
        slist.Add(skill1);
        slist.Add(skill2);
        slist.Add(skill3);
        slist.Add(skill4);
        slist.Add(skill5);
        slist.Add(skill6);
        slist.Add(skill7);
    }

    // Update is called once per frame
    void Update()
    {   
        //숫자를 랜덤으로 뽑기
        timer+=Time.deltaTime;
        if(cur<=max&&timer>1){
            if(sufflecount==7){
                sufflecount=0;
                ShuffleList(numbers);
            }
            GameObject newskill = Instantiate(slist[numbers[sufflecount]]);
            sufflecount++;
            newskill.transform.position=new Vector3(10,0.13f,0);
            cur++;
            timer=0;
        }
    }

    void ShuffleList<T>(List<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
