using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum MonsterCode
{
    Salamander,
    Yeti,
    Slime,
    Golem,
    Shadow,
    Skeleton,
    Dragon,
    Rabbit,
    Tree,
    Wolf,
    Bat,
    Zombie,
    Flower,
    AxeBlock,
    Orc,
    Alsapphire,
    DarkShell

}

//[System.Serializable]
public struct MonsterData
{
    public MonsterCode code;

    public float fire;
    public float water;
    public float wind;
    public float thunder;
    public float light;
    public float darkness;

    public string[] hateList;
    public string[] managementList;

    public string name;
    public int grade;
    public int rageCount;
    public int maxSpell;
    public int attack;
    public float speed;
    public float maxHP;

    public string thumbnailPath;// => ���� �ʻ�ȭ�� ��뿹��
    public string prefabPath;
}



public class MonsterManager : MonoBehaviour
{
    private static MonsterManager instance = null;

    private List<MonsterData> m_MonsterData = new List<MonsterData>();

    public List<MonsterData> monsters = new List<MonsterData>();



    public static MonsterManager Instance
    {
        get
        {
            if(!instance)
            {
                instance = FindObjectOfType(typeof(MonsterManager)) as MonsterManager;
            }
            return instance;
        }
    }

    private void Awake()
    {
        if(null == instance) 
        {
            instance = this;
            LoadData();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void LoadData()
    {
        //string monsterDataJSON = File.ReadAllText(Application.dataPath + "/Resources/JSON/MonsterData.json");
        string monsterDataJSON = File.ReadAllText(Application.streamingAssetsPath + "/JSON/MonsterData.json");
        m_MonsterData = JsonHelper.FromJson<MonsterData>(monsterDataJSON);
    }

    public List<MonsterData> GetMonsterData()//���� ����Ʈ ��ü
    {
        return m_MonsterData;
    }

    public MonsterData GetMonsterData(MonsterCode code)//�ش� ���� �����͸�
    {
        return m_MonsterData[(int)code];
    }
    public List<MonsterData> GetCurMonsterData()
    {
        return monsters;
    }


}
