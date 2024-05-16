using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 사용방법: GameManager.instance.사용할 함수
    /// </summary>
    public static GameManager instance;

    [SerializeField]
    GameObject[] windowPrefabs/*창 프리팹들*/;
    Stack<GameObject> openedWindows/*열려있는 창들을 저장할 스택*/;

    private void Awake()
    {
        //씬을 전환해도 해당 오브젝트가 없어지지 않게 하고
        //씬을 전환했을 때 해당 씬에 존재하는 GameManager의
        //스태틱 인스턴스가 this가 아니면 해당 오브젝트를 삭제
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

    /// <summary>
    /// 씬 전환을 할 시 호출
    /// 사용 방법: GameManager.intance.SceneChanger("씬 이름")
    /// </summary>
    /// <param name="sceneName">로드할 씬의 고유 번호</param>
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

    /// <summary>
    /// 특정 창을 띄울 시 호출
    /// 사용 방법: GameManager.intance.WindowCaller(창 인덱스)
    /// </summary>
    /// <param name="winNum">생성할 창의 고유번호</param>
    public void WindowCaller(byte winNum)
    {
        if (openedWindows == null)
        {
            openedWindows = new Stack<GameObject>();
        }
        openedWindows.Push(Instantiate(windowPrefabs[winNum]));
    }

    /// <summary>
    /// 가장 최근의 창을 종료
    /// 사용 방법: GameManager.intance.WindowDestroyer()
    /// </summary>
    public void WindowDestroyer()
    {
        if (openedWindows != null && openedWindows.Count > 0)
        {
            Destroy(openedWindows.Pop());
        }
    }
}
