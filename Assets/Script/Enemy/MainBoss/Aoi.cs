using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class Aoi : EnemyBase
{
    public GameObject player;
    public BossEnemyBullet EnemyBulletPrefab;

    private int count;
    private float speed = 200.0f;
    private float speed_one = 100.0f;
    private float speed_three = 300.0f;
    public Slider EnemyHPSlider;

    void Start()
    {
        HP = 400;
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
            yield return ShotConstantDirectionM(20, 210, 150);
            yield return ShotConstantDirectionM_left(24, 210, 150);
            yield return ShotConstantDirectionM_right(24, 210, 150);
            yield return ShotConstantDirectionM(35, 240, 110);
            yield return ShotConstantDirectionM_left(12, 210, 180);
            yield return ShotConstantDirectionM_right(20, 180, 150);
        }
    }
    private void ShotAim()
    {

        BossEnemyBullet EnemyBullet =
       Instantiate(EnemyBulletPrefab, transform.position, Quaternion.identity);
        Rigidbody EnemyBulletRb = EnemyBullet.GetComponent<Rigidbody>();
        Vector3 vector3 = player.transform.position - this.transform.position;

        EnemyBulletRb.AddForce(vector3 * 30.0f);
    }
    private void ShotAimN(int count)
    {
        Vector3 vector3 = player.transform.position - this.transform.position;
        float angle = Mathf.Atan2(vector3.x, -vector3.y) * Mathf.Rad2Deg;
        float angle_Set = angle + 180;
        for (int i = 1; i <= count; i++)
        {
            Shot(angle_Set - 15 * (count / 2 + 1) + (15 * i));
        }
    }
    IEnumerator WaveMShotAimN(int o, int n)
    {
        for (int w = 0; w < o; w++)
        {
            yield return new WaitForSeconds(0.1f);
            ShotAimN(n);
        }
    }

    private void ShotConstantDirection(int x,int y)
    {
        Shot(x);
        Shot(y);
    }
    private void ShotConstantDirection_right_two(int x,int y)
    {
        Shot_right_position(x);
        Shot_right_position(y);
    }
    private void ShotConstantDirection_left_two(int x,int y)
    {
        Shot_left_position(x);
        Shot_left_position(y);
    }
    private void ShotConstantDirection_two(int x,int y)
    {
        Shot_three(x);
        Shot_one(y);
    }
    private void ShotConstantDirection_right(int x,int y)
    {
        Shot_right_position(x);
        Shot_right_position_one(y);
    }
    private void ShotConstantDirection_left(int x,int y)
    {
        Shot_left_position_three(x);
        Shot_left_position(y);
    }
    IEnumerator ShotConstantDirectionM_right_two(int o, int x,int y)//oは数、ｘｙは角度
    {
        for (int w = 0; w < o; w++)
        {
            yield return new WaitForSeconds(0.1f);
            ShotConstantDirection_right_two(x,y);
        }
    }
    IEnumerator ShotConstantDirectionM_left_two(int o, int x,int y)//oは数、ｘｙは角度
    {
        for (int w = 0; w < o; w++)
        {
            yield return new WaitForSeconds(0.1f);
            ShotConstantDirection_left_two(x,y);
        }
    }
    IEnumerator ShotConstantDirectionM_two(int o, int x,int y)//oは数、ｘｙは角度
    {
        for (int w = 0; w < o; w++)
        {
            yield return new WaitForSeconds(0.1f);
            ShotConstantDirection_two(x,y);
        }
    }
    IEnumerator ShotConstantDirectionM_right(int o, int x,int y)//oは数、ｘｙは角度
    {
        for (int w = 0; w < o; w++)
        {
            yield return new WaitForSeconds(0.1f);
            ShotConstantDirection_right(x,y);
        }
    }
    IEnumerator ShotConstantDirectionM_left(int o, int x,int y)//oは数、ｘｙは角度
    {
        for (int w = 0; w < o; w++)
        {
            yield return new WaitForSeconds(0.1f);
            ShotConstantDirection_left(x,y);
        }
    }
    IEnumerator ShotConstantDirectionM(int o, int x,int y)//oは数、ｘｙは角度
    {
        for (int w = 0; w < o; w++)
        {
            yield return new WaitForSeconds(0.1f);
            ShotConstantDirection(x,y);
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

    private void Shot_right_position_one(float count)
    {

        BossEnemyBullet EnemyBullet =
       Instantiate(EnemyBulletPrefab, new Vector3(3.0f,2f,0f), Quaternion.identity);
        Rigidbody EnemyBulletRb = EnemyBullet.GetComponent<Rigidbody>();
        Vector3 angle = new Vector3(0, 0, count);
        EnemyBulletRb.AddForce(Quaternion.Euler(angle) * Vector3.up * speed_one);
    }
    private void Shot_left_position_three(float count)
    {

        BossEnemyBullet EnemyBullet =
       Instantiate(EnemyBulletPrefab, new Vector3(-3.0f,2f,0f), Quaternion.identity);
        Rigidbody EnemyBulletRb = EnemyBullet.GetComponent<Rigidbody>();
        Vector3 angle = new Vector3(0, 0, count);
        EnemyBulletRb.AddForce(Quaternion.Euler(angle) * Vector3.up * speed_three);
    }

    private void Shot(float count)
    {

        BossEnemyBullet EnemyBullet =
       Instantiate(EnemyBulletPrefab, transform.position, Quaternion.identity);
        Rigidbody EnemyBulletRb = EnemyBullet.GetComponent<Rigidbody>();
        Vector3 angle = new Vector3(0, 0, count);
        EnemyBulletRb.AddForce(Quaternion.Euler(angle) * Vector3.up * speed);
    }
    private void Shot_three(float count)
    {

        BossEnemyBullet EnemyBullet =
       Instantiate(EnemyBulletPrefab, transform.position, Quaternion.identity);
        Rigidbody EnemyBulletRb = EnemyBullet.GetComponent<Rigidbody>();
        Vector3 angle = new Vector3(0, 0, count);
        EnemyBulletRb.AddForce(Quaternion.Euler(angle) * Vector3.up * speed_three);
    }
    private void Shot_one(float count)
    {

        BossEnemyBullet EnemyBullet =
       Instantiate(EnemyBulletPrefab, transform.position, Quaternion.identity);
        Rigidbody EnemyBulletRb = EnemyBullet.GetComponent<Rigidbody>();
        Vector3 angle = new Vector3(0, 0, count);
        EnemyBulletRb.AddForce(Quaternion.Euler(angle) * Vector3.up * speed_one);
    }
}