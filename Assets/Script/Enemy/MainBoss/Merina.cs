using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class Merina : EnemyBase
{
    public GameObject player;
    public BossEnemyBullet EnemyBulletPrefab;

    private int count;
    private float speed = 200.0f;
    public Slider EnemyHPSlider;

    void Start()
    {
        HP = 300;
        EnemyHPSlider.maxValue = HP;
        EnemyHPSlider.value = HP;
        StartCoroutine(CPU());
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if (HP < 0)
        {
            Destroy(gameObject);
        }
    }
    public override void TakeDamage(int PlayerBulletPower)
    {
        HP -= PlayerBulletPower;

        EnemyHPSlider.value = HP;

        if (HP < 1)
        {
            Destroy(gameObject);
        }
    }
    //CPU
    IEnumerator CPU()
    {
        // 特定の位置より上だったら
        while (transform.position.y > 3f)
        {
            transform.position -= new Vector3(0, 2, 0) * Time.deltaTime;
            yield return null; //1フレーム(0.02秒)待つ
        }
        while (true)
        {
            yield return ShotSpiralM(3, 36 ,0.02f);
            yield return new WaitForSeconds(1.0f);
            yield return ShotSpiralM(3, 35 ,0.02f);
            yield return new WaitForSeconds(1.0f);
            yield return ShotSpiralM(3, 38 ,0.02f);
            yield return new WaitForSeconds(1.0f);
        }
    }
 
    IEnumerator ShotSpiral(int count,float time)
    {
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount) * Mathf.Rad2Deg;
            Shot(angle);
            yield return new WaitForSeconds(time);
        }
    }
    IEnumerator ShotSpiralM(int o, int count,float time)
    {
        for (int w = 0; w < o; w++)
        {
            yield return new WaitForSeconds(0.1f);
            yield return ShotSpiral(count,time);
        }
    }
    private void Shot(float count)
    {

        BossEnemyBullet EnemyBullet =
       Instantiate(EnemyBulletPrefab, transform.position, Quaternion.identity);
        Rigidbody EnemyBulletRb = EnemyBullet.GetComponent<Rigidbody>();
        Vector3 angle = new Vector3(0, 0, count);
        EnemyBulletRb.AddForce(Quaternion.Euler(angle) * Vector3.up * speed);
    }
}