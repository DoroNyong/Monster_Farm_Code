using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventMessage : MonoBehaviour
{

    [SerializeField] private GameObject eventMessage;
    [SerializeField] private TMP_Text eventMessageText;
    [SerializeField] private Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // �̺�Ʈ �߻��� ���
    public void EventMessageStart(string message)
    {
        eventMessage.SetActive(true);
        animator.SetTrigger("EventMessageStart");
        eventMessageText.text = message; // ��������Ʈ ��� ����
        StartCoroutine("EventMessage_End");
    }

    IEnumerator EventMessage_End()
    {
        yield return new WaitForSecondsRealtime(5.0f);
        animator.SetTrigger("EventMessageEnd");
        yield return new WaitForSecondsRealtime(animator.GetCurrentAnimatorStateInfo(0).length + 0.01f);
        eventMessage.SetActive(false);
    }

    public void EventMessageStop()
    {
        StopCoroutine("EventMessage_End");
    }

    public void SetEventMessageOff()
    {
        eventMessage.SetActive(false);
    }
}
