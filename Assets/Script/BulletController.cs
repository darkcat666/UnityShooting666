using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float SHOT_SPEED = 0.1f;
    private Vector2 shotspeed_vec2;
    public Boss_AI1 boss;
    public GameObject gameobject;
    private int boss_cullentHP;
    private GameObject bossObject;

    private void Start()
    {
        bossObject = GameObject.Find("Boss_1");
        shotspeed_vec2 = new Vector2(0.0f, SHOT_SPEED);
        boss_cullentHP = bossObject.GetComponent<Boss_AI1>().GetBoss_HP();

    }
    void Update()
    {
        transform.Translate(0,SHOT_SPEED,0);

        if (transform.position.y > 5)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // 玉の削除
            Destroy(gameObject);

            // ボスのHP減らす
            bossObject.GetComponent<Boss_AI1>().ReduseBoss_HP();

            // ボスを少し吹き飛ばす
            bossObject.GetComponent<Boss_AI1>().Boss_A1Shoot();

            // ボスを光らせる
            StartCoroutine("FlashCoroutine");

            // ボスのHPが0以下の場合
            if (boss_cullentHP <= 0)
            {
                // ボスを殺す
                Destroy(bossObject);
            }
        }
        if (collision.gameObject.tag == "zako")
        {
            // 玉の削除
            Destroy(gameObject);

            // ボスを少し吹き飛ばす
            bossObject.GetComponent<Zakomove>().Zako_A1Shoot();
        }
    }

    IEnumerator FlashCoroutine()
    {
        Renderer bossRenderer = bossObject.GetComponent<Renderer>();
        bossRenderer.material.color = bossObject.GetComponent<Renderer>().material.color;
        bossObject.GetComponent<Renderer>().material.color = Color.black;
        yield return new WaitForSeconds(2.0f);
        bossObject.GetComponent<Renderer>().material.color = Color.white;
    }
}