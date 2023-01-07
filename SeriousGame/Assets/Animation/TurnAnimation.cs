using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAnimation : MonoBehaviour
{
    private Animator m_Animator;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.SetTrigger("TrStart");

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_Animator.SetTrigger("TrStart");
        }
    }
}
