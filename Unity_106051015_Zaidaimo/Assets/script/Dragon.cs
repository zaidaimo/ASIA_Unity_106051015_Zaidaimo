using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public Transform tran;  //旋轉
    public Rigidbody rig;   //跑步
    public Animator ani;   //動畫觸發
    public Rigidbody rigCatch;   //抓取物品
    
    // Start is called before the first frame update
    void Start ()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        Turn();
        Run();
        Attack();
    }

    private void Turn ()
    {
        float h = Input.GetAxis ("Horizontal");   //A D鍵控制左右旋轉
        tran.Rotate (0, turn * h * Time.deltaTime , 0);   //Y軸為旋轉軸
    }

    private void Run ()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("attack")) ;   //攻擊時撥放攻擊動畫

        float v = Input.GetAxis ("Vertical");   //W S鍵控制前後
        rig.AddForce (tran.forward * speed *v *Time.deltaTime);   //區域座標

        ani.SetBool("walk", v != 0);
    }

    private void Attack ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ani.SetTrigger("attack");   //按下滑鼠左鍵就會觸發攻擊動畫
        }
    }
}
