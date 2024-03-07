using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class TeresaMiddle : EnemyBase
{
    public GameObject player;
    public BossEnemyBullet EnemyBulletPrefab;

    private int count;
    private float speed = 200.0f;
    public Slider EnemyHPSlider;
    private int angle_x = 15;
    private int angle_y = 75;
    void Start()
    {
        HP = 600;
        EnemyHPSlider.maxValue = HP;
        EnemyHPSlider.value = HP;
        StartCoroutine(CPU());
        StartCoroutine(Kousi());
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
            yield return WaveMShotAimN(3,8);
            yield return new WaitForSeconds(3.0f);
        }
    }
    IEnumerator Kousi(){
        // 特定の位置より上だったら
        while (transform.position.y > 3f)
        {
            transform.position -= new Vector3(0, 2, 0) * Time.deltaTime;
            yield return null; //1フレーム(0.02秒)待つ
        }
        while(true){
            angle_x  = angle_x + 60;
            angle_y  = angle_y + 60;
            yield return ShotConstantDirectionM(10, angle_x,angle_y);//oは数、ｘｙは角度
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

    private void Shot(float count)
    {

        BossEnemyBullet EnemyBullet =
       Instantiate(EnemyBulletPrefab, transform.position, Quaternion.identity);
        Rigidbody EnemyBulletRb = EnemyBullet.GetComponent<Rigidbody>();
        Vector3 angle = new Vector3(0, 0, count);
        EnemyBulletRb.AddForce(Quaternion.Euler(angle) * Vector3.up * speed);
    }
}