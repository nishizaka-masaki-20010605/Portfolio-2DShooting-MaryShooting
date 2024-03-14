using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject BulletPrefab;
    GameController gameController;

    public int PlayerHp;//10
    public Slider PlayerHpSlider;
    public float Player_speed;//8
    public float MinX;//-5.5
    public float MaxX;//5.5
    public float MinY;//-4.5
    public float MaxY;//6
    public int EnemyDamage;//1
    void Start()
    {
        PlayerHpSlider.value = PlayerHp;

        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    
    void Update()
    {
        if (GameController.instance.MiddleBossClear
            &&  CanvasKihonn.instance.BossStart)
        {
            gameObject.SetActive(false);
        }
        else if(GameController.instance.MiddleBossClear  
                &&  !CanvasKihonn.instance.BossStart)
        {
            Move();
            Shot();
            Destroy();
        }else if(GameController.instance.MainBossClear){
            gameObject.SetActive(false);
        }
        {
            Move();
            Shot();
            Destroy();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EnemyBullet")||other.CompareTag("Enemy"))
        {
        PlayerHpSlider.value -= EnemyDamage;
        PlayerHp -= EnemyDamage;
        Destroy(other.gameObject);
        }

    }

    void Destroy(){
            if(PlayerHp <= 0){
        gameObject.SetActive(false);
        SceneChange();
        }
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 nextPosition = transform.position
        + new Vector3(x, y, 0) * Time.deltaTime * Player_speed;

        nextPosition = new Vector3(
            Mathf.Clamp(nextPosition.x, MinX, MaxX),
            Mathf.Clamp(nextPosition.y, MinY, MaxY),
            nextPosition.z
        );
        transform.position = nextPosition;
    }

    void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine("ShotN");

        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            StopCoroutine("ShotN");
        }
    }
    IEnumerator ShotN()
    {
        while (true)
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.1f);
        }
    }

     void SceneChange()
    {
         gameController.GameOver();

    }
}
