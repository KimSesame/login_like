using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //�ٸ� ��ũ��Ʈ���� �ش� ��ũ��Ʈ�� ���� ������ �� �ְ�
    //static ������ instance ����
    //�ش� ��ũ��Ʈ ȣ�� ���: GameManager.instance.����� �Լ�
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

    //�� ��ȯ�� �� �� ȣ��
    //��� ���: GameManager.intance.SceneChanger("�� �̸�")
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
    //��� ���: GameManager.intance.WindowCaller(â �ε���)
    public void WindowCaller(byte winNum)
    {
        if (openedWindows == null)
        {
            openedWindows = new Stack<GameObject>();
        }
        openedWindows.Push(Instantiate(windowPrefabs[winNum]));
    }

    //���� �ֱ��� â�� ����
    //��� ���: GameManager.intance.WindowDestroyer()
    public void WindowDestroyer()
    {
        if (openedWindows != null && openedWindows.Count > 0)
        {
            Destroy(openedWindows.Pop());
        }
    }
}
