using UnityEngine;

public class TargetSelectConnector : MonoBehaviour
{
    [SerializeField]
    SelectSingle selectSingle; //���� Ÿ�� ���� â
    [SerializeField]
    SelectHorizontal selectHorizontal; //���� Ÿ�� ���� â
    [SerializeField]
    SelectVertical selectVertical; //���� Ÿ�� ���� â
    [SerializeField]
    SelectAll selectAll; //��ü Ÿ�� ���� â

    public void StartTargetSelect(Skill skill)
    {
        switch (skill.GetSkillInfo().range)
        {
            case Range.Single:
                selectSingle.gameObject.SetActive(true);
                selectHorizontal.gameObject.SetActive(false);
                selectVertical.gameObject.SetActive(false);
                selectAll.gameObject.SetActive(false);
                selectSingle.StartSelect(skill);
                break;
            case Range.Horizontal:
                selectSingle.gameObject.SetActive(false);
                selectHorizontal.gameObject.SetActive(true);
                selectVertical.gameObject.SetActive(false);
                selectAll.gameObject.SetActive(false);
                selectHorizontal.StartSelect(skill);
                break;
            case Range.Vertical:
                selectSingle.gameObject.SetActive(false);
                selectHorizontal.gameObject.SetActive(false);
                selectVertical.gameObject.SetActive(true);
                selectAll.gameObject.SetActive(false);
                selectVertical.StartSelect(skill);
                break;
            case Range.All:
                selectSingle.gameObject.SetActive(false);
                selectHorizontal.gameObject.SetActive(false);
                selectVertical.gameObject.SetActive(false);
                selectAll.gameObject.SetActive(true);
                selectAll.StartSelect(skill);
                break;
        }
    }

    public void CloseSelecting()
    {
        for (int i = 0; i< 4; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        gameObject.SetActive(false);
    }
}
