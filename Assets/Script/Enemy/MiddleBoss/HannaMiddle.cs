using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class HannaMiddle : EnemyBase
{
    public GameObject player;
    public BossEnemyBullet EnemyBulletPrefab;

    private int count;
    private float speed = 200.0f;
    public Slider EnemyHPSlider;

    void Start()
    {
        HP = 100;
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
            yield return new WaitForSeconds(1.0f);
            yield return ShotRandomSpawnW(40,180,5.0f,-5.0f, 3.0f,0.0f);
        }
    }


    private void ShotN(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            Shot(180 - 15 * (count / 2 + 1) + (15 * i));
        }
    }
    IEnumerator ShotNRandom(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            int randomValue = Random.Range(1, 360);;
            Shot(randomValue);
            yield return new WaitForSeconds(0.02f);
        }
    }

    private void ShotRandomSpawn(float count,float dx,float fx, float dy,float fy)
    {
		float x = Random.Range(dx, fx);
		float y = Random.Range(dy, fy);
        BossEnemyBullet EnemyBullet =
       Instantiate(EnemyBulletPrefab, new Vector3(x, y, 0), Quaternion.identity);
        Rigidbody EnemyBulletRb = EnemyBullet.GetComponent<Rigidbody>();
        Vector3 angle = new Vector3(0, 0, count);
        EnemyBulletRb.AddForce(Quaternion.Euler(angle) * Vector3.up * speed);
    }
    IEnumerator ShotRandomSpawnW(int number,float count,float dx,float fx, float dy,float fy){
        for (int w = 0; w < number; w++)
        {
            yield return new WaitForSeconds(0.1f);
            ShotRandomSpawn(count,dx,fx,dy,fy);;
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