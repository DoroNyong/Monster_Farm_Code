using System;
using System.Collections.Generic;
using UnityEngine;

// ���� å�� ��Ģ (Single Responsibility Principle): �� Ŭ������ �ϳ��� �ֿ� ����� ����Ѵ�.
// FloorActivationStrategy�� Ư�� ���� Ȱ��ȭ�ϴ� ������ ����ϰ�, FloorController_Fix�� �������� �ʱ�ȭ�ϰ� ����ϴ� å���� ���� �ִ�.
public interface IFloorActivationStrategy  // �������̽� : �������� �����ؾ� �ϴ� ����� �������̽�
{
    void Activate();
}

public class FloorActivationStrategy : IFloorActivationStrategy  // ��ũ��Ʈ ���� Ŭ���� : �� ������ ������ �����ϴ� Ŭ����
{
    private GameObject floor;

    public FloorActivationStrategy(GameObject floor)
    {
        this.floor = floor;
    }

    public void Activate()
    {
        floor.SetActive(true);
    }
}

public class FloorController_Fix : MonoBehaviour  // ���ؽ�Ʈ Ŭ���� : ���� ��ü�� ����ϴ� Ŭ������, �ʿ信 ���� ������ �������� ������ �� �ִ�.
                                                  // ������: FloorController_Fix Ŭ�������� floorStrategies ��ųʸ��� ���� �پ��� ���ǿ� ���� ������ �������� �߰��� �� �ְ� ��.
                                                  // �̷ν� ���� ���� ���� Ȱ��ȭ ������ ���� ������ �� �ִ�.
{
    private Dictionary<Func<int, bool>, IFloorActivationStrategy> floorStrategies = new Dictionary<Func<int, bool>, IFloorActivationStrategy>();
    // Func<int, bool>�� �����ϴ� ���� : ���Ͱ� �� ���� �����ϴ����� �Բ� '�� ���� �̻��̸� ����'�� ���� ������ �ο��Ϸ���

    private int monsters;

    [Header("FirstFloor")]
    public GameObject firstFloor_First;
    public GameObject firstFloor_Second;

    [Header("SecondFloor")]
    public GameObject secondFloor_First;
    public GameObject secondFloor_Second;

    [Header("ThirdFloor")]
    public GameObject thirdFloor_First;
    public GameObject thirdFloor_Second;

    private void Awake()
    {
        Init();
    }
    void Start()
    {
        monsters = MonsterManager.Instance.GetCurMonsterData().Count;
        InitializeStrategies();

        foreach (var strategy in floorStrategies)
        {
            if (strategy.Key(monsters))
            {
                strategy.Value.Activate();
            }
        }
    }

    private void InitializeStrategies()
    {
        // monsterCount�� Ư�� ���� �� �̻��̸� ���� ����
        floorStrategies.Add(monsterCount => monsterCount >= 1, new FloorActivationStrategy(firstFloor_First));
        floorStrategies.Add(monsterCount => monsterCount >= 3, new FloorActivationStrategy(firstFloor_Second));
        floorStrategies.Add(monsterCount => monsterCount >= 5, new FloorActivationStrategy(secondFloor_First));
        floorStrategies.Add(monsterCount => monsterCount >= 8, new FloorActivationStrategy(secondFloor_Second));
        floorStrategies.Add(monsterCount => monsterCount >= 11, new FloorActivationStrategy(thirdFloor_First));
        floorStrategies.Add(monsterCount => monsterCount >= 13, new FloorActivationStrategy(thirdFloor_Second));
    }
    // Ȯ�强: �ڵ�� ���� 3���� ���� ���� ���ǰ� ������ �ٷ�� ������, ���߿� �� ���� ���̳� �ٸ� ������ �߰��Ǿ �����ϰ� ��ó�� �� �ִ�.

    private void Init()
    {
        firstFloor_First.SetActive(false);
        firstFloor_Second.SetActive(false);
        secondFloor_First.SetActive(false);
        secondFloor_Second.SetActive(false);
        thirdFloor_First.SetActive(false);
        thirdFloor_Second.SetActive(false);
    }
}



