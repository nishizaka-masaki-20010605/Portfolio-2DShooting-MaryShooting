using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class MobTwo : EnemyBase
{
    public GameObject player;
    public EnemyBulletAny EnemyBulletPrefab;
    void Start()
    {
        HP = 25;
        StartCoroutine(CPU());
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if (HP < 0)
        {
            Destroy(gameObject);
        }
        Destroy();
    }
    void Shot(float angle, float speed)
    {
        EnemyBulletAny bullet = Instantiate(EnemyBulletPrefab, transform.position, transform.rotation);
        bullet.Setting(angle, speed);
    }
    public override void TakeDamage(int PlayerBulletPower)
    {
        HP -= PlayerBulletPower;


        if (HP < 1)
        {
            Destroy(gameObject);
        }
    }
    //CPU
    IEnumerator CPU()
    {
        // 特定の位置より上だったら
        while (transform.position.y > 3.0f)
        {
            transform.position -= new Vector3(0, 4, 0) * Time.deltaTime;
            yield return null; //1フレーム(0.02秒)待つ
        }
        while (true)
        {
            yield return WaveNPlayerAimShot(1, 5);
            yield return new WaitForSeconds(3f);
            transform.position -= new Vector3(0, 2, 0)*Time.deltaTime;
        }
    }

    IEnumerator WaveNShotM(int n, int m)
    {
        for (int w = 0; w < n; w++)
        {
            yield return new WaitForSeconds(0.3f);
            ShotN(m, 2);
        }
    }
    IEnumerator WaveNShotMCurve(int n, int m)
    {
        for (int w = 0; w < n; w++)
        {
            yield return new WaitForSeconds(0.3f);
            yield return ShotNCurve(m, 2);
        }
    }
    IEnumerator WaveNPlayerAimShot(int n, int m)
    {
        for (int w = 0; w < n; w++)
        {
            yield return new WaitForSeconds(1f);
            PlayerAimShot(m, 3);
        }
    }

    void ShotN(int count, float speed)
    {
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount);
            Shot(angle, speed);
        }
    }

    IEnumerator ShotNCurve(int count, float speed)
    {
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount);
            Shot(angle - Mathf.PI / 2f, speed);
            Shot(-angle - Mathf.PI / 2f, speed);
            yield return new WaitForSeconds(0.1f);
        }
    }
    void PlayerAimShot(int count, float speed)
    {
        //この弾幕前にplayerが倒されていたら何もしない
        if (player != null)
        {
            Vector3 diffPosition = player.transform.position - transform.position;
            float angleP = Mathf.Atan2(diffPosition.y, diffPosition.x);

            int bulletCount = count;
            for (int i = 0; i < bulletCount; i++)
            {
                float angle = (i - bulletCount / 2f) * ((Mathf.PI / 2f) / bulletCount);


                Shot(angleP + angle, speed);
            }
        }

    }
    void Destroy(){
        if( transform.position.x < -6 || transform.position.x > 6 ||
            transform.position.y < -6 || transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }
}
