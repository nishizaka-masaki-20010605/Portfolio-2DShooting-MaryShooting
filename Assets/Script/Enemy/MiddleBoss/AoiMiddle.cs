using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class AoiMiddle : EnemyBase
{
    public GameObject player;
    public BossEnemyBullet EnemyBulletPrefab;

    private int count;
    public Slider EnemyHPSlider;

    public int[] Stage_four_all_direction_count;//9,12,15,18
    public int[] Stage_four_all_direction_wave;//18

    void Start()
    {
        speed = GameData.instance.Enemy_bullet_speed;
        HP = GameData.instance.Enemy_HP_base*GameData.instance.stage_boss_four;
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
        while (transform.position.y > GameData.instance.Enemy_position)
        {
            transform.position -= new Vector3(0, 2, 0) * Time.deltaTime;
            yield return null; //1フレーム(0.02秒)待つ
        }
        while (true)
        {
            yield return ShotAllDirection(9, 18);
            yield return new WaitForSeconds(1.0f);
            yield return ShotAllDirection_right(12, 18);
            yield return new WaitForSeconds(1.0f);
            yield return ShotAllDirection_left(15, 18);
            yield return new WaitForSeconds(1.0f);
            yield return ShotAllDirection(18, 18);
            yield return new WaitForSeconds(1.0f);
        }
    }

    private void ShotAllDirection(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            Shot(i*360/count);
        }
    }
    private void ShotAllDirection_right(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            Shot_right_position(i*360/count);
        }
    }
    IEnumerator ShotAllDirection_right(int count, int wave)
    {
        for (int w = 0; w < wave; w++)
        {
            yield return new WaitForSeconds(0.1f);
            ShotAllDirection_right(count);
        }
    }
    private void ShotAllDirection_left(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            Shot_left_position(i*360/count);
        }
    }
    IEnumerator ShotAllDirection_left(int count, int wave)
    {
        for (int w = 0; w < wave; w++)
        {
            yield return new WaitForSeconds(0.1f);
            ShotAllDirection_left(count);
        }
    }
    IEnumerator ShotAllDirection(int count, int wave)
    {
        for (int w = 0; w < wave; w++)
        {
            yield return new WaitForSeconds(0.1f);
            ShotAllDirection(count);
        }
    }
    private void ShotN(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            Shot(180 - 15 * (count / 2 + 1) + (15 * i));
        }
    }
    private void Shot_right_position(float count)
    {

        BossEnemyBullet EnemyBullet =
       Instantiate(EnemyBulletPrefab, new Vector3(3.0f,2f,0f), Quaternion.identity);
        Rigidbody EnemyBulletRb = EnemyBullet.GetComponent<Rigidbody>();
        Vector3 angle = new Vector3(0, 0, count);
        EnemyBulletRb.AddForce(Quaternion.Euler(angle) * Vector3.up * speed);
    }
    private void Shot_left_position(float count)
    {

        BossEnemyBullet EnemyBullet =
       Instantiate(EnemyBulletPrefab, new Vector3(-3.0f,2f,0f), Quaternion.identity);
        Rigidbody EnemyBulletRb = EnemyBullet.GetComponent<Rigidbody>();
        Vector3 angle = new Vector3(0, 0, count);
        EnemyBulletRb.AddForce(Quaternion.Euler(angle) * Vector3.up * speed);
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