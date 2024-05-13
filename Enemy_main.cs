using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Enemy_main : MonoBehaviour
{
    //플레이어 상태 가져오기
    bool Player_state_Gkill;

    //목적지
    public Transform target;
    //적
    NavMeshAgent agent;

    public Animator anim;

    //열거형으로 정해진 상태값을 사용
    enum State
    {
        Idle,
        Run,
        Attack,
        Gkill,
        gkillAttack
    }
    //상태 처리
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

    //플레이어 상태 확인
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


        //남은 거리가 2미터라면 공격한다.
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= 2)
        {
            state = State.Attack;
            anim.SetTrigger("Attack");
        }

        //타겟 방향으로 이동하다가
        agent.speed = 3.5f;
        //요원에게 목적지를 알려준다.
        agent.destination = target.transform.position;

    }

    private void UpdateIdle()
    {
        agent.speed = 0;
        //생성될때 목적지(Player)를 찿는다.
        target = GameObject.Find("Player").transform;
        //target을 찾으면 Run상태로 전이하고 싶다.
        if (target != null)
        {
            state = State.Run;
            //이렇게 state값을 바꿨다고 animation까지 바뀔까? no! 동기화를 해줘야한다.
            anim.SetTrigger("Run");
        }
    }

   
}