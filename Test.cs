using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player_State;
public class TestPlayer : MonoBehaviour
{
    public int PlayerSys;

    // ����, ��� ����
    public int Hp = 100;
    public int maxHp = 300;
    public int Mp = 100;
    public int maxMp = 300;


    //�¿� �̵�
    Rigidbody2D rbody;
    float axisH = 0.0f;     //�Է�
    public float speed = 10.0f; //�̵� �ӵ�

    //����
    //public float jump = 9.0f;
    public bool goJump = false;
    public LayerMask groundLayer; // ��
    public bool onGround = false;
    public int JumpCount = 1;
    public bool IntJC = true;

    //�뽬 (ȸ��)
    //public float dash = 15.0f;    //�뽬��
    public bool goDash = false; // �뽬 ���� �÷���

    //�÷��̾� ���°�
    public bool Plater_state_Gkill;
    bool pLyaer_HP_;//�������ͽ� Ŭ�������� �����´�.




    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();

    }


    void Update()
    {

        //���� ����
        axisH = Input.GetAxisRaw("Horizontal");
        if (axisH > 0.0f)
        {
            Debug.Log("������");
            transform.localScale = new Vector2(-1, 1);
        }
        else if (axisH < 0.0f)
        {
            Debug.Log("����");
            transform.localScale = new Vector2(1, 1);
        }

        //����
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        //�뽬
        if (Input.GetKeyDown(KeyCode.C))
        {
            Dash(); // 'Dash' �޼��� ȣ��
        }
    }

    void FixedUpdate()
    {
        float speed2 = 20.0f;

        //�̵�
        if (onGround || axisH != 0)
        {
            //���� �� �ӵ��� 0�� �ƴ�
            //�̵� �ӵ� ����
            Debug.Log("�ӵ� ����");
            rbody.velocity = new Vector2(axisH * speed2, rbody.velocity.y);




        }

        //����
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
            //���� ������ ���� Ű ����
            //���� �ϱ�
            Debug.Log("����");
            float jump2 = 50.0f;
            Vector2 jumpPw = new Vector2(0, jump2);
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);
            goJump = false;
            JumpCount++;
        }



        //�뽬
        if (goDash == true)
        {
            Debug.Log("�뽬");
            float dash = 130.0f;
            Vector2 dashPw = new Vector2(dash, 0); // ���� ���� ����
            if (axisH > 0.0f)
            {
                // �������� �ٶ� ��
                rbody.AddForce(dashPw, ForceMode2D.Impulse);
            }
            else if (axisH < 0.0f)
            {
                // ������ �ٶ� ��
                rbody.AddForce(-dashPw, ForceMode2D.Impulse);
            }
            goDash = false; //�뽬 �÷��� Off
            Debug.Log("�뽬 ��");
        }

    }


    public void Jump()
    {
        goJump = true;
        Debug.Log("���� ��ư ����");
    }

    public void Dash()
    {
        goDash = true;
        Debug.Log("�뽬 ��ư ����");
    }

    void OnCollisionEnter2D(Collision2D collision)  //���� ����
    {
        // �ε��� ��ü�� �±װ� "Ground"���
        if (collision.gameObject.CompareTag("Ground"))
        {
            goJump = false;
            Debug.Log("���� ���Ҵ�!!");
            //isGround�� true�� ����
            onGround = true;
            JumpCount = 1;


        }

    }

    void Plater_Groggy()
    {
        
    }


}
