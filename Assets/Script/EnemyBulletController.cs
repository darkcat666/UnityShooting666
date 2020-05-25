using UnityEngine;
using System.Collections;

public class EnemyBulletController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float SHOT_SPEED = -0.2f;
    private Vector2 shotspeed_vec2;
    public Boss_AI1 boss;
    private int boss_cullentHP;
    private GameObject PlayerObject;

    private void Start()
    {
        PlayerObject = GameObject.Find("Player");
        shotspeed_vec2 = new Vector2(0.0f, SHOT_SPEED);
    }
    void Update()
    {
        this.transform.Translate(0, SHOT_SPEED, 0);

        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // 玉の削除
            Destroy(gameObject);

            // ボスを少し吹き飛ばす
            PlayerObject.GetComponent<Boss_AI1>().Boss_A1Shoot();

            // ボスを光らせる
            StartCoroutine("FlashCoroutine");

        }
    }

    IEnumerator FlashCoroutine()
    {
        Renderer bossRenderer = PlayerObject.GetComponent<Renderer>();
        bossRenderer.material.color = PlayerObject.GetComponent<Renderer>().material.color;
        PlayerObject.GetComponent<Renderer>().material.color = Color.black;
        yield return new WaitForSeconds(2.0f);
        PlayerObject.GetComponent<Renderer>().material.color = Color.white;
    }
}