using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //'GameManager.instance'�� �������� �ش� ��ũ��Ʈ�� ȣ��
    public static GameManager instance;

    [SerializeField]
    GameObject[] windowPrefabs/*â �����յ�*/;
    Stack<GameObject> openedWindows/*�����ִ� â���� ������ ����*/;

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

    //�� ��ȯ�� �� �� ȣ��
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

    //Ư�� â�� ��� �� ȣ��
    public void WindowCaller(byte winNum)
    {
        if (openedWindows == null)
        {
            openedWindows = new Stack<GameObject>();
        }
        openedWindows.Push(Instantiate(windowPrefabs[winNum]));
    }

    //���� �ֱ��� â�� ����
    public void WindowDestroyer()
    {
        if (openedWindows != null && openedWindows.Count > 0)
        {
            Destroy(openedWindows.Pop());
        }
    }
}
