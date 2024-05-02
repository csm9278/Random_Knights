using System.Collections.Generic;
using UnityEngine;

public class MonsterSkillData
{
    public delegate void MonsterSKill(HeroStatueMgr mgr, ref string InfoText, bool isWeak = false);

    public static Dictionary<string, MonsterSKill> MonSkillList = new Dictionary<string, MonsterSKill>();

    public static int BoxKnightDamage = 9;
    static int RabbitTurn = 1;
    static int MoonNightTurn = 1;
    static int AliceTurn = 1;

    public static void InitMonSKillData()
    {
        MonSkillList.Add("�ҷ���", BullySkill);
        MonSkillList.Add("��¡��", SquidSkill);
        MonSkillList.Add("������ ����", FrogSkill);
        MonSkillList.Add("�ҵ���", FireSkill);
        MonSkillList.Add("���ڱ��", BoxKnightSkill);
        MonSkillList.Add("�鰳", DogSkill);
        MonSkillList.Add("���� ����", FireElementalSkill);
        MonSkillList.Add("���� ����", ForestElementalSkill);
        MonSkillList.Add("������", RabbitSkill);
        MonSkillList.Add("�����", EngineerSkill);
        MonSkillList.Add("����", GemStoneSkill);
        MonSkillList.Add("����", GhostSkill);
        MonSkillList.Add("�䳻����", MirrorManSkill);
        MonSkillList.Add("���׾Ƹ�", PoisonBoxSkill);
        MonSkillList.Add("������ȥ", DarkSoulSkill);
        MonSkillList.Add("�����", KeyManSkill);
        MonSkillList.Add("������Ʈ", MoonNightSkill);
        MonSkillList.Add("�ٸ���", AliceSkill);
        MonSkillList.Add("�巡��", DragonSkill);
        MonSkillList.Add("�����", DurahanSkill);
    }

    public static void SquidSkill(HeroStatueMgr mgr,ref string InfoText, bool isWeak = false)
    {
        InfoText = "1~3������ + 2�������� �ش�";

        int rand = Random.Range(1, 4);
        rand += 2;

        if (isWeak)
        {
            Debug.Log("��ȭ ���� " + rand + " -> " + (int)(rand * 0.75));

            rand = (int)(rand * 0.75f);
        }

        mgr._battlemgr.AddStateText("<color=orange>" + rand.ToString() + "�������� �Ծ���</color>");

        mgr.SetHp(rand);
    }
    public static void FrogSkill(HeroStatueMgr mgr,ref string InfoText, bool isWeak = false)
    {

        int rand = Random.Range(1, 4);
        rand += 2;
        InfoText = "1~3������ + 2�������� �ش�";

        if (isWeak)
        {
            Debug.Log("��ȭ ���� " + rand + " -> " + (int)(rand * 0.75));

            rand = (int)(rand * 0.75f);
        }


        mgr._battlemgr.AddStateText("<color=orange>" + rand.ToString() + "�������� �Ծ���</color>");


        mgr.SetHp(rand);
    }
    public static void BullySkill(HeroStatueMgr mgr,ref string InfoText, bool isWeak = false)
    {
        InfoText = "1~2 ������ * 2�� �������� �ش�";


        int rand = Random.Range(1, 3);
        rand *= 2;

        if (isWeak)
        {
            Debug.Log("��ȭ ���� " + rand + " -> " + (int)(rand * 0.75));

            rand = (int)(rand * 0.75f);
        }


        mgr._battlemgr.AddStateText("<color=orange>" + rand.ToString() + "�������� �Ծ���</color>");

        mgr.SetHp(rand);
    }
    public static void FireSkill(HeroStatueMgr mgr,ref string InfoText, bool isWeak = false)
    {
        InfoText = "1~2 ������ * 2�� �������� �ش�";

        int rand = Random.Range(1, 3);
        rand *= 2;

        if (isWeak)
        {
            Debug.Log("��ȭ ���� " + rand + " -> " + (int)(rand * 0.75));

            rand = (int)(rand * 0.75f);
        }


        mgr._battlemgr.AddStateText("<color=orange>" + rand.ToString() + "�������� �Ծ���</color>");

        mgr.SetHp(rand);
    }
    public static void BoxKnightSkill(HeroStatueMgr mgr,ref string InfoText, bool isWeak = false)
    {
        Debug.Log("���ڱ�� ��ų");
        Debug.Log("9 �������� �ش� ���������� 2�� ���� �ּ� 1");

        InfoText = "9 �������� �ش� ���������� 2�� ���� �ּ� 1";

        int currentDmg = BoxKnightDamage;
        if (isWeak)
        {
            Debug.Log("��ȭ ���� " + BoxKnightDamage + " -> " + (int)(currentDmg * 0.75));

            currentDmg = (int)(BoxKnightDamage * 0.75f);
        }

        mgr._battlemgr.AddStateText("<color=orange>" + currentDmg.ToString() + "�������� �Ծ���</color>");

        mgr.SetHp(currentDmg);
        BoxKnightDamage -= 2;

        if (BoxKnightDamage <= 1)
            BoxKnightDamage = 1;
    }
    public static void DogSkill(HeroStatueMgr mgr,ref string InfoText, bool isWeak = false)
    {
        Debug.Log("�鰳 ��ų");
        Debug.Log("1~3 ���ظ� �ش� 2�� ���� �ο�");

        InfoText = "1~3 ���ظ� �ش� 2�� ���� �ο�";


        int currentDmg = Random.Range(1, 4);
        if (isWeak)
        {
            Debug.Log("��ȭ ���� " + currentDmg + " -> " + (int)(currentDmg * 0.75));

            currentDmg = (int)(currentDmg * 0.75f);
        }

        mgr._battlemgr.AddStateText("<color=orange>" + currentDmg.ToString() + "�������� �Ծ���</color>");


        mgr.SetHp(currentDmg);
        mgr.AddDebuff("��", 2, true);
    }
    public static void FireElementalSkill(HeroStatueMgr mgr,ref string InfoText, bool isWeak = false)
    {
        Debug.Log("ȭ������ ��ų");
        Debug.Log("3~6 ���ظ� �ְ� 2ȭ�� ���ºο�");
        InfoText = "3~6 ���ظ� �ְ� 2ȭ�� ���� �ο�";

        int rand = Random.Range(3, 7);
        int currentDmg = rand;
        if (isWeak)
        {
            Debug.Log("��ȭ ���� " + currentDmg + " -> " + (int)(currentDmg * 0.75));

            currentDmg = (int)(currentDmg * 0.75f);
        }



        mgr.SetHp(currentDmg);
        mgr.AddDebuff("ȭ��", 2, true);
        mgr._battlemgr.AddStateText("<color=orange>" + currentDmg.ToString() + "�������� �Ծ���</color>");

    }
    public static void ForestElementalSkill(HeroStatueMgr mgr,ref string InfoText, bool isWeak = false)
    {
        Debug.Log("���� ���� ��ų");
        Debug.Log("1~6 ���ظ� �ش� 2�� ���� �ο�");
        InfoText = "1~6 ���ظ� �ش� 2�� ���� �ο�";

        int rand = Random.Range(1, 7);
        int currentDmg = rand;
        if (isWeak)
        {
            Debug.Log("��ȭ ���� " + currentDmg + " -> " + (int)(currentDmg * 0.75));

            currentDmg = (int)(currentDmg * 0.75f);
        }
        mgr._battlemgr.AddStateText("<color=orange>" + currentDmg.ToString() + "�������� �Ծ���</color>");

        mgr.AddDebuff("��", 2, true);

        if (rand % 2 == 0)
        {
            mgr.SetHp(currentDmg * 2);
        }
        else
            mgr.SetHp(currentDmg);
    }
    public static void RabbitSkill(HeroStatueMgr mgr,ref string InfoText, bool isWeak = false)
    {
        Debug.Log("������ ��ų");
        Debug.Log("3 * �ϼ� ���ظ� �ش�.");
        InfoText = "3 * �ϼ� ���ظ� �ذ� ��ȭ���� �ο�.";

        int currentDmg = 3;
        if (isWeak)
        {
            Debug.Log("��ȭ ���� " + currentDmg + " -> " + (int)(currentDmg * 0.75));

            currentDmg = (int)(currentDmg * 0.75f);
        }

        mgr.AddDebuff("��ȭ", 1,  true);
        mgr.SetHp(currentDmg * RabbitTurn);
        mgr._battlemgr.AddStateText("<color=orange>" + (currentDmg * RabbitTurn).ToString() + "�������� �Ծ���</color>");
        RabbitTurn++;

    }
    public static void EngineerSkill(HeroStatueMgr mgr,ref string InfoText, bool isWeak = false)
    {
        Debug.Log("�����Ͼ� ��ų");
        Debug.Log("1 ~ 6 �ֻ����� 2�� ������ ���Ѹ�ŭ �������� �ش�");
        InfoText = "1 ~ 6 �ֻ����� 2�� ������ ���Ѹ�ŭ �������� �ش�";

        int rand = Random.Range(1, 7);

        int currentDmg = rand;

        rand = Random.Range(1, 7);
        currentDmg += rand;

        if (isWeak)
        {
            Debug.Log("��ȭ ���� " + currentDmg + " -> " + (int)(currentDmg * 0.75));

            currentDmg = (int)(currentDmg * 0.75f);
        }
        mgr._battlemgr.AddStateText("<color=orange>" + currentDmg.ToString() + "�������� �Ծ���</color>");

        mgr.SetHp(currentDmg);
    }
    public static void GemStoneSkill(HeroStatueMgr mgr,ref string InfoText, bool isWeak = false)
    {
        Debug.Log("���� ��ų");
        Debug.Log("1 ~ 10������ ���ظ� �ش�");
        InfoText = "1 ~ 10������ ���ظ� �ش�";

        int rand = Random.Range(1, 11);

        int currentDmg = rand;

        if (isWeak)
        {
            Debug.Log("��ȭ ���� " + currentDmg + " -> " + (int)(currentDmg * 0.75));
            mgr._battlemgr.AddStateText("<color=orange>" + ((int)(currentDmg * 0.75f)).ToString() + "�������� �Ծ���</color>");

            currentDmg = (int)(currentDmg * 0.75f);
        }
        else
        {
            mgr._battlemgr.AddStateText("<color=orange>" + currentDmg.ToString() + "�������� �Ծ���</color>");

        }

        mgr.SetHp(currentDmg);
    }
    public static void GhostSkill(HeroStatueMgr mgr,ref string InfoText, bool isWeak = false)
    {
        Debug.Log("���� ��ų");
        Debug.Log("1 ~ 2������ ���ظ� ��Ƽ� �ش�. 70%Ȯ���� �������� �߰��� ��ô�Ѵ�.");
        InfoText = "1 ~ 2������ ���ظ� ��Ƽ� �ش�. 70%Ȯ���� �������� �߰��� ��ô�Ѵ�.";
        int rand;
        int currentDmg = 0;

        for (int i = 0; i < 100; i++)
        {
            rand = Random.Range(1, 3);
            currentDmg += rand;

            rand = Random.Range(1, 11);
            if (rand <= 2)
                break;
        }


        if (isWeak)
        {
            Debug.Log("��ȭ ���� " + currentDmg + " -> " + (int)(currentDmg * 0.75));

            currentDmg = (int)(currentDmg * 0.75f);
        }

        mgr._battlemgr.AddStateText("<color=orange>" + currentDmg.ToString() + "�������� �Ծ���</color>");

        mgr.SetHp(currentDmg);
        Debug.Log(currentDmg);

    }
    public static void MirrorManSkill(HeroStatueMgr mgr, ref string InfoText, bool isWeak = false)
    {
        Debug.Log("�䳻���� ��ų");
        int rand = Random.Range(0, 4);

        switch(rand)
        {
            case 0:
                MonSkillList["�����"](mgr, ref InfoText, isWeak);
                break;
            case 1:
                MonSkillList["����"](mgr, ref InfoText, isWeak);
                break;
            case 2:
                MonSkillList["����"](mgr, ref InfoText, isWeak);
                break;
            case 3:
                MonSkillList["���׾Ƹ�"](mgr, ref InfoText, isWeak);
                break;
        }

    }
    public static void PoisonBoxSkill(HeroStatueMgr mgr,ref string InfoText, bool isWeak = false)
    {
        Debug.Log("���׾Ƹ� ��ų");
        Debug.Log("1 ~ 2 ���� �������� �ְ� 3�� ���� �ο�");
        InfoText = "1 ~ 2 ���� �������� �ְ� 3�� ���� �ο�";

        int rand = Random.Range(1, 2);

        int currentDmg = rand;

        if (isWeak)
        {
            Debug.Log("��ȭ ���� " + currentDmg + " -> " + (int)(currentDmg * 0.75));

            currentDmg = (int)(currentDmg * 0.75f);
        }

        mgr._battlemgr.AddStateText("<color=orange>" + currentDmg.ToString() + "�������� �Ծ���</color>");

        mgr.AddDebuff("��", 3, true);
        mgr.SetHp(currentDmg);

    }
    public static void DarkSoulSkill(HeroStatueMgr mgr,ref string InfoText, bool isWeak = false)
    {
        Debug.Log("���� ��ȥ ��ų");
        Debug.Log("5 ~ 15 ���ظ� �ش�");
        InfoText = "5 ~ 15 ������ ���ظ� �ش�.";

        int rand = Random.Range(5, 16);

        int currentDmg = rand;

        if (isWeak)
        {
            Debug.Log("��ȭ ���� " + currentDmg + " -> " + (int)(currentDmg * 0.75));

            currentDmg = (int)(currentDmg * 0.75f);
        }
        mgr._battlemgr.AddStateText("<color=orange>" + currentDmg.ToString() + "�������� �Ծ���</color>");

        mgr.SetHp(currentDmg);

    }
    public static void KeyManSkill(HeroStatueMgr mgr,ref string InfoText, bool isWeak = false)
    {
        Debug.Log("����� ��ų");
        Debug.Log("3�� ���ظ� �ش� ����Ÿ�� 70�ۼ�Ʈ");
        InfoText = "3�� ���ظ� �ش� ����Ÿ�� 70�ۼ�Ʈ";

        int rand;
        int currentDmg = 0;

        for (int i = 0; i < 100; i++)
        {
            currentDmg += 3;

            rand = Random.Range(0, 10);
            if (rand < 7)
                break;
        }

        if (isWeak)
        {
            Debug.Log("��ȭ ���� " + currentDmg + " -> " + (int)(currentDmg * 0.75));

            currentDmg = (int)(currentDmg * 0.75f);
        }
        mgr._battlemgr.AddStateText("<color=orange>" + currentDmg.ToString() + "�������� �Ծ���</color>");

        mgr.SetHp(currentDmg);

    }
    public static void MoonNightSkill(HeroStatueMgr mgr,ref string InfoText, bool isWeak = false)
    {
        Debug.Log("������Ʈ ��ų");
        Debug.Log("8 * �ϼ� ���ظ� �ش�.");
        InfoText = "8 * �ϼ� ���ظ� �ذ� ��ȭ���� �ο�. ���� �� : " + MoonNightTurn.ToString();

        int currentDmg = 8;
        if (isWeak)
        {
            Debug.Log("��ȭ ���� " + currentDmg + " -> " + (int)(currentDmg * 0.75));

            currentDmg = (int)(currentDmg * 0.75f);
        }
        mgr._battlemgr.AddStateText("<color=orange>" + (currentDmg * MoonNightTurn).ToString() + "�������� �Ծ���</color>");

        mgr.AddDebuff("��ȭ", 1, true);
        mgr.SetHp(currentDmg * MoonNightTurn);
        MoonNightTurn++;
    }
    public static void AliceSkill(HeroStatueMgr mgr,ref string InfoText, bool isWeak = false)
    {
        Debug.Log("�ٸ��� ��ų");
        Debug.Log("5���ظ� �ְ� ��� �����̻��� 2��ŭ �ο��Ѵ�.");
        InfoText = "5���ظ� �ְ� ��� �����̻��� 2��ŭ �ο��Ѵ�.";

        int currentDmg = 5;
        if (isWeak)
        {
            Debug.Log("��ȭ ���� " + currentDmg + " -> " + (int)(currentDmg * 0.75));

            currentDmg = (int)(currentDmg * 0.75f);
        }
        mgr._battlemgr.AddStateText("<color=orange>" + currentDmg.ToString() + "�������� �Ծ���</color>");

        mgr.AddDebuff("��", 2, true);
        mgr.AddDebuff("��ȭ", 2, true);
        mgr.AddDebuff("ȭ��", 2, true);
        mgr.SetHp(currentDmg);
    }
    public static void DragonSkill(HeroStatueMgr mgr,ref string InfoText, bool isWeak = false)
    {
        Debug.Log("�巡�� ��ų");
        Debug.Log("3~6 ������ 3�踦 �ش� �������� 8�Ͻ� 5�� ����");
        InfoText = "3~6 ������ 3�踦 �ش� �������� 8�Ͻ� 5�� ����";

        int rand = Random.Range(3, 7);
        int currentDmg = rand;
        if (isWeak)
        {
            Debug.Log("��ȭ ���� " + currentDmg + " -> " + (int)(currentDmg * 0.75));

            currentDmg = (int)(currentDmg * 0.75f);
        }

        if (rand == 6)
        {
            mgr.SetHp(currentDmg * 5);
            mgr._battlemgr.AddStateText("<color=orange>" + (currentDmg * 5).ToString() + "�������� �Ծ���</color>");

        }
        else
        {
            mgr._battlemgr.AddStateText("<color=orange>" + (currentDmg * 3).ToString() + "�������� �Ծ���</color>");

            mgr.SetHp(currentDmg * 3);
        }
    }
    public static void DurahanSkill(HeroStatueMgr mgr,ref string InfoText, bool isWeak = false)
    {
        Debug.Log("����� ��ų");
        Debug.Log("4~5������ ���ظ� ��Ƽ� �ش�. 70%Ȯ���� �������� �߰��� ��ô�Ѵ�.");
        InfoText = "4~5������ ���ظ� ��Ƽ� �ش�. 70%Ȯ���� �������� �߰��� ��ô�Ѵ�.";

        int rand;
        int currentDmg = 0;

        for (int i = 0; i < 100; i++)
        {
            rand = Random.Range(4, 6);
            currentDmg += rand;

            rand = Random.Range(0, 10);
            if (rand < 3)
                break;
        }


        if (isWeak)
        {
            Debug.Log("��ȭ ���� " + currentDmg + " -> " + (int)(currentDmg * 0.75));

            currentDmg = (int)(currentDmg * 0.75f);
            mgr._battlemgr.AddStateText("<color=orange>" + ((int)(currentDmg * 0.75)).ToString() + "�������� �Ծ���</color>");

        }
        else
        mgr._battlemgr.AddStateText("<color=orange>" + currentDmg.ToString() + "�������� �Ծ���</color>");

        mgr.SetHp(currentDmg);
        Debug.Log(currentDmg);

    }
}