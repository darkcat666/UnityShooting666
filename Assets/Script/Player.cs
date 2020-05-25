using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public SoundController soundController;
    public float SHOT_SPEED = 0.1f;
    public Vector2 SPEED = new Vector2(0.05f, 0.05f);
    public bool moai_flag;
    private Vector2 Position;
    private Vector2 ShotPosition;
    private Vector2 shotspeed_vec2;

    void Start()
    {
        moai_flag = false;
        soundController = GetComponent<SoundController>();
    }

    void Update()
    {
        Move();
        yamero();
        resetMyPosition();
    }

    // モアイに当たったらやめろーという
    void yamero()
    {
        if (moai_flag == true)
        {
            soundController.Yamero_screem();

            // やめろというおじさんの悲痛な叫びを聞いたら、フラグを消す
            moai_flag = false;
        }
    }

    // モアイと当たったら、やめろフラグを付ける　→　yamero()
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zako")
        {
            moai_flag = true;
        }
    }

    // 現在位置リセット（条件）
    void resetMyPosition()
    {
        if (this.transform.position.x < -12f)
        {
            ResetImplement();
        }
        if (this.transform.position.x > 12f)
        {
            ResetImplement();
        }
        if (this.transform.position.y < -9f)
        {
            ResetImplement();
        }
        if (this.transform.position.y > 9f)
        {
            ResetImplement();
        }
    }

    // 現在位置をリセット（中身）
    void ResetImplement()
    {
        this.transform.position = new Vector3(0, -4f, 0);
    }

    // 移動関数
    void Move()
    {
        // 現在位置をPositionに代入
        Position = transform.position;
        shotspeed_vec2 = new Vector2(0.0f, SHOT_SPEED);
        // 左キーを押し続けていたら
        if (Input.GetKey("left"))
        {
            // 代入したPositionに対して加算減算を行う
            Position.x -= SPEED.x;
        }
        else if (Input.GetKey("right"))
        { // 右キーを押し続けていたら
          // 代入したPositionに対して加算減算を行う
            Position.x += SPEED.x;
        }
        else if (Input.GetKey("up"))
        { // 上キーを押し続けていたら\
          // 代入したPositionに対して加算減算を行う
            Position.y += SPEED.y;
        }
        else if (Input.GetKey("down"))
        { // 下キーを押し続けていたら
          // 代入したPositionに対して加算減算を行う
            Position.y -= SPEED.y;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, SHOT_SPEED, 0), Quaternion.identity);
        }

        // 現在の位置に加算減算を行ったPositionを代入する
        transform.position = Position;
    }

    public void readAndMakeEnemy()
    {

    }
}