using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item_Data", menuName = "Scriptable Object/item_Data", order = int.MaxValue)]
//�����޴��ٿ� item_Data��� scriptableobject�� �����ϴ� �޴��� ����
public class item_data : ScriptableObject
{
    [SerializeField]
    private Sprite item_sprite;
    public Sprite Item_Sprite { get { return item_sprite; }}
    [SerializeField]
    private int idx;//�������� �ε���
    public int IDX { get { return idx; } }
    [SerializeField]
    private string item_name;//�������̸�
    public string Item_name { get { return item_name; } }
    [SerializeField]
    private string item_contents;//�����ۼ���
    public string Item_contents { get { return item_contents; } }
    [SerializeField]
    private int price;//����
    public int Price { get { return price; } }
    [SerializeField]
    private float upRatio;//������ Ȯ��
    public float UpRatio { get { return upRatio; } }
    [SerializeField]
    private float damage;//������ Ȯ��
    public float Damage { get { return damage; } }
    [SerializeField]
    private float hp;//������ Ȯ��
    public float HP { get { return hp; } }
    [SerializeField]
    private string type;//
    public string Type { get { return type; } }

}
