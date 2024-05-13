using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player_State;
public class TestPlayer : MonoBehaviour
{
    public int PlayerSys;

    // 피통, 기몬 스텟
    public int Hp = 100;
    public int maxHp = 300;
    public int Mp = 100;
    public int maxMp = 300;


    //좌우 이동
    Rigidbody2D rbody;
    float axisH = 0.0f;     //입력
    public float speed = 10.0f; //이동 속도

    //점프
    //public float jump = 9.0f;
    public bool goJump = false;
    public LayerMask groundLayer; // 땅
    public bool onGround = false;
    public int JumpCount = 1;
    public bool IntJC = true;

    //대쉬 (회피)
    //public float dash = 15.0f;    //대쉬력
    public bool goDash = false; // 대쉬 개시 플래그

    //플레이어 상태값
    public bool Plater_state_Gkill;
    bool pLyaer_HP_;//스테이터스 클래스에서 가져온다.




    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();

    }


    void Update()
    {

        //방향 조절
        axisH = Input.GetAxisRaw("Horizontal");
        if (axisH > 0.0f)
        {
            Debug.Log("오른쪽");
            transform.localScale = new Vector2(-1, 1);
        }
        else if (axisH < 0.0f)
        {
            Debug.Log("왼쪽");
            transform.localScale = new Vector2(1, 1);
        }

        //점프
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        //대쉬
        if (Input.GetKeyDown(KeyCode.C))
        {
            Dash(); // 'Dash' 메서드 호출
        }
    }

    void FixedUpdate()
    {
        float speed2 = 20.0f;

        //이동
        if (onGround || axisH != 0)
        {
            //지면 위 속도가 0이 아님
            //이동 속도 갱신
            Debug.Log("속도 갱신");
            rbody.velocity = new Vector2(axisH * speed2, rbody.velocity.y);




        }

        //점프
        if (JumpCount < 3)
        {
            IntJC = true;
        }
        if (JumpCount > 2)
        {
            IntJC = false;
        }
        if (goJump && IntJC == true)
        {
            onGround = false;
            //지면 위에서 점프 키 눌림
            //점프 하기
            Debug.Log("점프");
            float jump2 = 50.0f;
            Vector2 jumpPw = new Vector2(0, jump2);
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);
            goJump = false;
            JumpCount++;
        }



        //대쉬
        if (goDash == true)
        {
            Debug.Log("대쉬");
            float dash = 130.0f;
            Vector2 dashPw = new Vector2(dash, 0); // 점프 벡터 생성
            if (axisH > 0.0f)
            {
                // 오른쪽을 바라볼 때
                rbody.AddForce(dashPw, ForceMode2D.Impulse);
            }
            else if (axisH < 0.0f)
            {
                // 왼쪽을 바라볼 때
                rbody.AddForce(-dashPw, ForceMode2D.Impulse);
            }
            goDash = false; //대쉬 플래그 Off
            Debug.Log("대쉬 끝");
        }

    }


    public void Jump()
    {
        goJump = true;
        Debug.Log("점프 버튼 눌림");
    }

    public void Dash()
    {
        goDash = true;
        Debug.Log("대쉬 버튼 눌림");
    }

    void OnCollisionEnter2D(Collision2D collision)  //착지 판정
    {
        // 부딪힌 물체의 태그가 "Ground"라면
        if (collision.gameObject.CompareTag("Ground"))
        {
            goJump = false;
            Debug.Log("벽에 막았다!!");
            //isGround를 true로 변경
            onGround = true;
            JumpCount = 1;


        }

    }

    void Plater_Groggy()
    {
        
    }


}
