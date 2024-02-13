using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class SakuraMiddle : EnemyBase
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
            yield return ShotRandomSpawnW(10,180,4.0f,-4.0f, 1.0f,-1.0f);
            yield return new WaitForSeconds(5.0f);
            yield return WaveMShotAimN(5,12);
            yield return new WaitForSeconds(5.0f);
            yield return ShotConstantDirectionM(12, 210, 150);
            yield return new WaitForSeconds(5.0f);
            yield return ShotAllDirection(18, 3);
            yield return new WaitForSeconds(5.0f);
            yield return ShotNCurveM(2,16);
            yield return new WaitForSeconds(5.0f);
            yield return ShotSpiralM(6, 7 ,0.02f);
            yield return new WaitForSeconds(5.0f);
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
    private void ShotAllDirection(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            Shot(i*360/count);
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
    IEnumerator ShotNRandom(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            int randomValue = Random.Range(1, 360);;
            Shot(randomValue);
            yield return new WaitForSeconds(0.02f);
        }
    }
    IEnumerator WaveMShotN(int o, int n)
    {
        for (int w = 0; w < o; w++)
        {
            yield return new WaitForSeconds(0.1f);
            ShotN(n);
        }
    }
    IEnumerator ShotNCurve(int count)
    {
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount) * Mathf.Rad2Deg;
            Shot(angle);
            Shot(-angle);
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator ShotNCurveM(int o, int n)
    {
        for (int w = 0; w < o; w++)
        {
            yield return new WaitForSeconds(1.0f);
            yield return ShotNCurve(n);;
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