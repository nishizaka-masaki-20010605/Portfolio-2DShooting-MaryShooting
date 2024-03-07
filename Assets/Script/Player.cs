using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject BulletPrefab;
    GameController gameController;

    public int PlayerHp;
    public Slider PlayerHpSlider;
    void Start()
    {
        PlayerHp = 10;
        PlayerHpSlider.value = 10;

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
        PlayerHpSlider.value -= 1;
        PlayerHp -= 1;
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
        + new Vector3(x, y, 0) * Time.deltaTime * 8f;

        nextPosition = new Vector3(
            Mathf.Clamp(nextPosition.x, -5.5f, 5.5f),
            Mathf.Clamp(nextPosition.y, -4.5f, 6f),
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
