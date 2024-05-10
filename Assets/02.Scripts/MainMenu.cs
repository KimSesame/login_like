using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject setting_p;
    public GameObject selectmode_p;
    public GameObject developer_p;
    public GameObject selectch_p;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartBtn(){
        selectmode_p.SetActive(true);
    }

    public void OnClickSettingBtn(){
        setting_p.SetActive(true);
    }

    public void OnClickDevelopBtn(){
        developer_p.SetActive(true);
    }

    public void OnClickExitBtn(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; 
        #else
            Application.Quit();
        #endif
    }

    public void OnClickBack(){
        selectmode_p.SetActive(false);
        setting_p.SetActive(false);
        developer_p.SetActive(false);
        selectch_p.SetActive(false);
    }

    public void OnclickSelectCh(){
        selectch_p.SetActive(true);
    }
}
