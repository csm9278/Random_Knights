using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroStatueMgr : MonoBehaviour
{
    public BattleManager _battlemgr;

    //����� �������ͽ� ����
    public Image hpBarImg;
    public Text hpText;
    public Text heroNameText;
    public Text goldText;
    public Text LvText;

    public Dictionary<string, int> debuffDic = new Dictionary<string, int>();

    private void Start() => StartFunc();

    private void StartFunc()
    {

        HeroStatusInit();
    }

    private void Update() => UpdateFunc();

    private void UpdateFunc()
    {
        
    }


    public void HeroStatusInit()
    {
        heroNameText.text = GlobalData.heroName;
        hpText.text = GlobalData.hero.curHp.ToString() + " / " + GlobalData.hero.maxHp.ToString();
        hpBarImg.fillAmount = (float)GlobalData.hero.curHp / GlobalData.hero.maxHp;

        goldText.text = "x " + GlobalData.hero.gold.ToString();
        LvText.text = "Lv. " + GlobalData.hero.lv.ToString();
    }

    public void RefreshStatus()
    {

    }

    public void SetHp(int dam)
    {
        if (dam <= 2)
            SoundMgr.Instance.PlayEffSound("LowDamage");
        else if (3 <= dam && dam <= 5)
            SoundMgr.Instance.PlayEffSound("MediumDamage");
        else if (6 <= dam)
            SoundMgr.Instance.PlayEffSound("HugeDamage");

        GlobalData.hero.curHp -= dam;

        if (GlobalData.hero.curHp <= 0)
            GlobalData.hero.curHp = 0;

        hpText.text = GlobalData.hero.curHp.ToString() + " / " + GlobalData.hero.maxHp.ToString();
        hpBarImg.fillAmount = (float)GlobalData.hero.curHp / GlobalData.hero.maxHp;
    }

    public void AddDebuff(string debuffName, int debuffCount, bool isHero = false)
    {
        if (debuffDic.ContainsKey(debuffName) && debuffDic[debuffName] > 0)
        {
            debuffDic[debuffName] += debuffCount;

            if (debuffName == "��")
                _battlemgr.AddDebuffNodeCountFunc(DebuffNodeMgr.DebuffType.Poison, debuffCount, isHero);
            else if (debuffName == "��ȭ")
                _battlemgr.AddDebuffNodeCountFunc(DebuffNodeMgr.DebuffType.Weak, debuffCount, isHero);
            else if (debuffName == "ȭ��")
                _battlemgr.AddDebuffNodeCountFunc(DebuffNodeMgr.DebuffType.Fire, debuffCount, isHero);
        }
        else
        {
            debuffDic.Add(debuffName, debuffCount);
            if (debuffName == "��")
                _battlemgr.debuffNodeFunc(DebuffNodeMgr.DebuffType.Poison, debuffCount, isHero);
            else if (debuffName == "��ȭ")
                _battlemgr.debuffNodeFunc(DebuffNodeMgr.DebuffType.Weak, debuffCount, isHero);
            else if (debuffName == "ȭ��")
                _battlemgr.debuffNodeFunc(DebuffNodeMgr.DebuffType.Fire, debuffCount, isHero);
        }

        if (debuffName == "��")
            SoundMgr.Instance.PlayEffSound("applypoison", 0.4f);
        else if (debuffName == "��ȭ")
            SoundMgr.Instance.PlayEffSound("applyweaken", 0.4f);
        else if (debuffName == "ȭ��")
            SoundMgr.Instance.PlayEffSound("fire", 0.5f);

        Debug.Log(debuffName + ": " + debuffDic[debuffName]);
    }

    public void DebuffEff()
    {
        if (debuffDic.ContainsKey("��"))
        {
            PoisonEff(debuffDic["��"]);
            //Debug.Log(debuffDic["��"] + " ��ŭ �� ������");
            _battlemgr.AddStateText("<color=darkblue>" + debuffDic["��"].ToString() + "�� �������� �Ծ���.</color>");
            debuffDic["��"]--;
            //Debug.Log(debuffDic["��"] + " ���� �� ī��Ʈ");
            SoundMgr.Instance.PlayEffSound("poison", 0.4f);

            if (debuffDic["��"] <= 0)
                debuffDic.Remove("��");
        }
    }

    public void DecreaseDebuff(string debuffName)
    {
        if(debuffDic.ContainsKey(debuffName))
        {
            debuffDic[debuffName]--;

            if (debuffDic[debuffName] <= 0)
                debuffDic.Remove(debuffName);
        }
    }

    public void PoisonEff(int PoisonCount)
    {
        Debug.Log("�� �� ��� �� : " + GlobalData.hero.curHp.ToString() + " - " + PoisonCount);

        GlobalData.hero.curHp -= PoisonCount;
        Debug.Log("����� ���� �� : " + GlobalData.hero.curHp.ToString());

        if (GlobalData.hero.curHp <= 0)
            GlobalData.hero.curHp = 0;

        hpText.text = GlobalData.hero.curHp.ToString() + " / " + GlobalData.hero.maxHp.ToString();
        hpBarImg.fillAmount = (float)GlobalData.hero.curHp / GlobalData.hero.maxHp;
    }
}