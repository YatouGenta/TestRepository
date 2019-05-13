using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// プレイヤー操作系
/// </summary>
public class PlayerController : MonoBehaviour
{
    //移動速度
    [SerializeField]
    private float moveSpeed = 1500f;
    //ジャンプ速度
    [SerializeField]
    private float jumpSpeed = 5000f;
    //接地フラグ
    private bool isGround = false;

    private Rigidbody2D rigidbody2D;
    private Vector2 movement;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
    }

    private void FixedUpdate()
    {
        //プレイヤー移動処理
        MovePlayer();
    }

    /// <summary>
    /// プレイヤー移動処理
    /// </summary>
    private void MovePlayer()
    {
        Vector2 moveVector = movement.normalized;
        moveVector.x *= moveSpeed;
        //移動入力判定
        if (Input.GetButtonDown("Jump") && isGround)
        {
            isGround = false;
            moveVector.y = jumpSpeed;
        }
        rigidbody2D.AddForce(moveVector);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //今のところはゴールしかないので触れたら遷移させる
        SceneManager.LoadScene("Title");
    }

}
