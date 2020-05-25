using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_AI1 : MonoBehaviour
{
    private float elapseTime;
    public float shotInterval;
    private float tmpShotInterval;
    public float ENEMY_SHOT_SPEED = 0.2f;
    public GameObject enemyBullet;
    public Transform target;
    public AudioClip sound1;
    public float moveSpeed;
    public int Boss_HP;
    AudioSource audioSource;
    public Rigidbody2D rigidbody2;

    void Start()
    {
        tmpShotInterval = shotInterval;
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("searchAndCaved_ON");
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        elapseTime += Time.deltaTime;
        if (elapseTime > shotInterval)
        {
            EnemyShoot();
            shotInterval += tmpShotInterval;
        }
    }

    public int GetBoss_HP()
    {
        return Boss_HP;
    }

    public void ReduseBoss_HP()
    {
        this.Boss_HP = GetBoss_HP() - 1;
    }

    public void Boss_A1Shoot()
    {
        rigidbody2.AddForce(new Vector2(0, 0.2f),ForceMode2D.Impulse);
    }

    public void EnemyShoot()
    {
        Instantiate(enemyBullet, transform.position + new Vector3(0, ENEMY_SHOT_SPEED, 0), Quaternion.AngleAxis(1, Vector3.right));
    }

    IEnumerator searchAndCaved_ON()
    {
        Vector2 tmp = GameObject.Find("Player").transform.position;

        //5秒停止
        yield return new WaitForSeconds(5);

        //音(sound1)を鳴らす
        audioSource.PlayOneShot(sound1);

        // プレイヤーに近づく
        float distance = Vector2.Distance(transform.position, tmp);

        //targetの方に少しずつ向きが変わる
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.3f);

        //targetに向かって進む
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        StartCoroutine("searchAndCaved_ON");
    }

    IEnumerator searchAndCaved_OFF()
    {
        //5秒停止
        yield return new WaitForSeconds(5);

        StartCoroutine("searchAndCaved_ON");
    }
}
