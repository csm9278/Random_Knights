using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ExpBarManager : MonoBehaviour
{
    public Image expGage;
    public Text infoText;
    public Text levelupText;

    public string[] InfoText = { "�ִ�ü���� 2 �ö����ϴ�.\n�ൿ���� 1 �ö����ϴ�.", "�ִ�ü���� 2 �ö����ϴ�." };
    float getOneExp;

    WaitForSeconds wait0_3f = new WaitForSeconds(0.3f);
    private void Start() => StartFunc();

    private void StartFunc()
    {
        levelupText.text = "";
        infoText.text = "";
        expGage.fillAmount = (float)GlobalData.hero.Exp / GlobalData.maxExp[GlobalData.hero.lv - 1];

        getOneExp = 1.0f / GlobalData.maxExp[GlobalData.hero.lv - 1];
        Debug.Log(getOneExp);
    }

    private void Update() => UpdateFunc();

    private void UpdateFunc()
    {
        
    }

    public IEnumerator GetExpCo(int getExp)
    {
        GlobalData.hero.gold++;

        yield return new WaitForSeconds(1.0f);


        for (int i = 0; i < getExp; i++)
        {
            expGage.fillAmount += getOneExp;
            SoundMgr.Instance.PlayEffSound("gainxp", 0.3f);

            if (expGage.fillAmount >= 0.95f)
            {
                infoText.text = InfoText[(GlobalData.hero.lv - 1) % 2];

                expGage.fillAmount = 0.0f;
                if(GlobalData.hero.lv - 1 >= 4)
                {
                    levelupText.text = "�ִ� ���� �޼� !!";
                }
                else
                {
                    levelupText.text = "���� �� !!";
                    getOneExp = 1.0f / GlobalData.maxExp[GlobalData.hero.lv - 1];
                }

                SoundMgr.Instance.PlayEffSound("levelup");
                GlobalData.hero.GetExp(getExp);
                GlobalData.isLevelUp = true;

                yield return new WaitForSeconds(1.0f);

                yield break;
            }

            yield return wait0_3f;

        }
        GlobalData.hero.GetExp(getExp);
    }
}