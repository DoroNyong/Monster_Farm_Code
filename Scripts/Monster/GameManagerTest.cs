using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTest : MonoBehaviour
{
    private static GameManagerTest instance = null;
    public static GameManagerTest Instance
    {
        get 
        {
            if(!instance)
            {
                instance = FindObjectOfType(typeof(GameManagerTest)) as GameManagerTest;
            }
            return instance;
        }
    }

    private void Awake()
    {
       if(null == instance) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
       else
        {
            Destroy(gameObject);
        }
    }

    private List<MonsterData> cur_Monsters = new List<MonsterData>();

    // Start is called before the first frame update
    void Start()
    {
        cur_Monsters = MonsterManager.Instance.GetMonsterData();//�ϴ��� �׽�Ʈ�� ���� �׳� ��ü�� �ܾ�� ���� ��Ŀ� ���� ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<MonsterData> GetCurMonsterData()
    {
        return cur_Monsters;
    }
}
