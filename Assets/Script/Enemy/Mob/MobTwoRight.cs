using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class MobTwoRight : EnemyBase
{
    public GameObject player;
    public EnemyBulletAny EnemyBulletPrefab;
    private float x;
    private float y;
    private float speed;
    void Start()
    {
        HP = 8;
        StartCoroutine(CPU());
        StartCoroutine(Move());
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if (HP < 0)
        {
            Destroy(gameObject);
        }
        Destroy();
        transform.Translate(new Vector3(x, y, 0) * speed * Time.deltaTime*0.1f);
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
        while (true)
        {
            yield return WaveNPlayerAimShot(1, 1);
            yield return new WaitForSeconds(3f);
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

    void PlayerAimShot(int count, float speed)
    {
        if (player != null)
        {
            Vector3 diffPosition = player.transform.position - transform.position;
            float angleP = Mathf.Atan2(diffPosition.y, diffPosition.x);

            int bulletCount = count;
            for (int i = 0; i < bulletCount; i++)
            {
                float angle = (i) * ((Mathf.PI / 2f) / bulletCount);


                Shot(angleP + angle, speed);
            }
        }
    }
    private IEnumerator Move(){
        x = -5;
        y = -2;
        speed = 3;
        yield return new WaitForSeconds(5f);
        x = -4;
        y = 3;
        speed = 3;
    }
    void Destroy(){
        if( transform.position.x < -12 || transform.position.x > 12 ||
            transform.position.y < -6 || transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }
}

