using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// �����: GameManager.instance.����� �Լ�
    /// </summary>
    public static GameManager instance;

    [SerializeField]
    GameObject[] windowPrefabs/*â �����յ�*/;
    Stack<GameObject> openedWindows/*�����ִ� â���� ������ ����*/;

    private void Awake()
    {
        //���� ��ȯ�ص� �ش� ������Ʈ�� �������� �ʰ� �ϰ�
        //���� ��ȯ���� �� �ش� ���� �����ϴ� GameManager��
        //����ƽ �ν��Ͻ��� this�� �ƴϸ� �ش� ������Ʈ�� ����
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
    /// �� ��ȯ�� �� �� ȣ��
    /// ��� ���: GameManager.intance.SceneChanger("�� �̸�")
    /// </summary>
    /// <param name="sceneName">�ε��� ���� ���� ��ȣ</param>
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
    /// Ư�� â�� ��� �� ȣ��
    /// ��� ���: GameManager.intance.WindowCaller(â �ε���)
    /// </summary>
    /// <param name="winNum">������ â�� ������ȣ</param>
    public void WindowCaller(byte winNum)
    {
        if (openedWindows == null)
        {
            openedWindows = new Stack<GameObject>();
        }
        openedWindows.Push(Instantiate(windowPrefabs[winNum]));
    }

    /// <summary>
    /// ���� �ֱ��� â�� ����
    /// ��� ���: GameManager.intance.WindowDestroyer()
    /// </summary>
    public void WindowDestroyer()
    {
        if (openedWindows != null && openedWindows.Count > 0)
        {
            Destroy(openedWindows.Pop());
        }
    }
}
