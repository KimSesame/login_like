using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //'GameManager.instance'의 형식으로 해당 스크립트를 호출
    public static GameManager instance;

    [SerializeField]
    GameObject[] windowPrefabs/*창 프리팹들*/;
    Stack<GameObject> openedWindows/*열려있는 창들을 저장할 스택*/;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    //씬 전환을 할 시 호출
    public void SceneChanger(string sceneName)
    {
        if (openedWindows != null)
        {
            foreach (var win in openedWindows)
            {
                Destroy(win);
            }
            openedWindows.Clear();
        }
        SceneManager.LoadScene(sceneName);
    }

    //특정 창을 띄울 시 호출
    public void WindowCaller(byte winNum)
    {
        if (openedWindows == null)
        {
            openedWindows = new Stack<GameObject>();
        }
        openedWindows.Push(Instantiate(windowPrefabs[winNum]));
    }

    //가장 최근의 창을 종료
    public void WindowDestroyer()
    {
        if (openedWindows != null && openedWindows.Count > 0)
        {
            Destroy(openedWindows.Pop());
        }
    }
}
