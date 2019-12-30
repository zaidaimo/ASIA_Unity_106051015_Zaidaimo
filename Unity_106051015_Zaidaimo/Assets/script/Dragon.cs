using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [Header("移動速度")]
    [Range(1, 2500)]
    public int speed = 10;             // 旋轉速度
    [Header("旋轉速度"), Tooltip("Dragon的旋轉速度"), Range(1.5f, 200f)]
    public float turn = 100f;         // 浮點數
    [Header("是否完成任務")]
    public bool mission;               // 是否完成任務
    [Header("玩家名稱")]
    public string _name = "Dragon";      // 角色恐龍
    public Transform tran;  //旋轉
    public Rigidbody rig;   //跑步
    public Animator ani;   //動畫觸發
    
    public Rigidbody rigCatch;   //抓取物品
    
    

    // Update is called once per frame
    void Update ()
    {
        Turn();
        Fly();
        Attack();
    }

    private void OnTriggerStay(Collider other)
    {
        //碰撞物件為 Hamburger時播放動畫Attack
         if (other.name == "Hamburger" && ani.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());   //兩物間不產生物理碰撞
            other.GetComponent<HingeJoint>().connectedBody = rigCatch;
        }
    }

    private void Turn ()
    {
        float h = Input.GetAxis ("Horizontal");   //A D鍵控制左右旋轉
        tran.Rotate (0, turn * h * Time.deltaTime , 0);   //Y軸為旋轉軸
    }

    private void Fly ()   //往前飛
    {
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("attack"))return ;   //攻擊時撥放攻擊動畫

        float v = Input.GetAxis ("Vertical");   //W S鍵控制前後
        rig.AddForce(tran.forward * speed * v * Time.deltaTime);   //區域座標

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
