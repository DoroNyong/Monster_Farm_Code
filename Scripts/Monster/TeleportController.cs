using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public List<GameObject> MonsterSpwanPos = new List<GameObject>();//roommanager�� �־��ֱ����� �����صѰ͵�
    public List<GameObject> MonsterTargetPos = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        RoomManager roomManager = RoomManager.Instance;
        roomManager.MonsterSpwanPos = MonsterSpwanPos;
        roomManager.MonsterTargetPos = MonsterTargetPos;
    }

}
