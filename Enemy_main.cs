using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Enemy_main : MonoBehaviour
{
    //�÷��̾� ���� ��������
    bool Player_state_Gkill;

    //������
    public Transform target;
    //��
    NavMeshAgent agent;

    public Animator anim;

    //���������� ������ ���°��� ���
    enum State
    {
        Idle,
        Run,
        Attack,
        Gkill,
        gkillAttack
    }
    //���� ó��
    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Idle)
        {
            UpdateIdle();
        }
        else if (state == State.Run)
        {
            UpdateRun();
        }
        else if (state == State.Attack)
        {
            UpdateAttack();
        }
        else if (state == State.gkillAttack)
        {
            updategKillAttack();
        }
        else if (state == State.Gkill)
        {
            UpdateGkill();
        }

    }

    //�÷��̾� ���� Ȯ��
    private void UpdateGkill()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (Player_state_Gkill == true)
        {
                if (distance <= 1)
                {
                    state = State.Gkill;
                }
        }


    }

    private void updategKillAttack()
    {
        
    }

    private void UpdateAttack()
    {
        agent.speed = 0;
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance > 2)
        {
            state = State.Run;
            anim.SetTrigger("Run");
        }
    }

    private void UpdateRun()
    {


        //���� �Ÿ��� 2���Ͷ�� �����Ѵ�.
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= 2)
        {
            state = State.Attack;
            anim.SetTrigger("Attack");
        }

        //Ÿ�� �������� �̵��ϴٰ�
        agent.speed = 3.5f;
        //������� �������� �˷��ش�.
        agent.destination = target.transform.position;

    }

    private void UpdateIdle()
    {
        agent.speed = 0;
        //�����ɶ� ������(Player)�� �O�´�.
        target = GameObject.Find("Player").transform;
        //target�� ã���� Run���·� �����ϰ� �ʹ�.
        if (target != null)
        {
            state = State.Run;
            //�̷��� state���� �ٲ�ٰ� animation���� �ٲ��? no! ����ȭ�� ������Ѵ�.
            anim.SetTrigger("Run");
        }
    }

   
}