using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGenerater : MonoBehaviour
{
    //
    public GameObject StageOneMiddleBossPrefab;
    public GameObject StageOneBossPrefab;
    public GameObject StageTwoMiddleBossPrefab;
    public GameObject StageTwoBossPrefab;
    public GameObject StageThreeMiddleBossPrefab;
    public GameObject StageThreeBossPrefab;
    public GameObject StageFourMiddleBossPrefab;
    public GameObject StageFourBossPrefabb;
    public GameObject StageFiveMiddleBossPrefab;
    public GameObject StageFiveBossPrefab;
    public GameObject StageSixMiddleBossPrefabb;
    public GameObject StageSixBossPrefab;
    public GameObject StageSevenMiddleBossPrefab;
    public GameObject StageSevenBossPrefab;


    public static EnemyGenerater instance;
    public bool MiddleBossFlag;
    public bool MainBossFlag;
    public bool isOnceBoss = true;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        string StageName = SceneManager.GetActiveScene().name;
        switch (StageName)
        {
            case "Stage1":
                StartCoroutine(Stage1());
                break;

            case "Stage2":
                StartCoroutine(Stage2());
                break;

            case "Stage3":
                StartCoroutine(Stage3());
                break;

            case "Stage4":
                StartCoroutine(Stage4());
                break;

            case "Stage5":
                StartCoroutine(Stage5());
                break;

            case "Stage6":
                StartCoroutine(Stage6());
                break;

            case "Stage7":
                StartCoroutine(Stage7());
                break;
        }
    }

    void Update()
    {
        string StageName = SceneManager.GetActiveScene().name;
        switch (StageName)
        {
            case "Stage1":
                if (isOnceBoss)
                {
                    if (GameController.instance.MiddleBossClear
                        && !CanvasKihonn.instance.BossStart)
                    {
                        Stage1MainBoss();
                        isOnceBoss = false;
                    }
                }
                break;

            case "Stage2":
                if (isOnceBoss)
                {
                    if (GameController.instance.MiddleBossClear
                        && !CanvasKihonn.instance.BossStart)
                    {
                        Stage2MainBoss();
                        isOnceBoss = false;
                    }
                }
                break;

            case "Stage3":
                if (isOnceBoss)
                {
                    if (GameController.instance.MiddleBossClear
                        && !CanvasKihonn.instance.BossStart)
                    {
                        Stage3MainBoss();
                        isOnceBoss = false;
                    }
                }
                break;

            case "Stage4":
                if (isOnceBoss)
                {
                    if (GameController.instance.MiddleBossClear
                        && !CanvasKihonn.instance.BossStart)
                    {
                        Stage4MainBoss();
                        isOnceBoss = false;
                    }
                }
                break;

            case "Stage5":
                if (isOnceBoss)
                {
                    if (GameController.instance.MiddleBossClear
                        && !CanvasKihonn.instance.BossStart)
                    {
                        Stage5MainBoss();
                        isOnceBoss = false;
                    }
                }
                break;

            case "Stage6":
                if (isOnceBoss)
                {
                    if (GameController.instance.MiddleBossClear
                        && !CanvasKihonn.instance.BossStart)
                    {
                        Stage6MainBoss();
                        isOnceBoss = false;
                    }
                }
                break;

            case "Stage7":
                if (isOnceBoss)
                {
                    if (GameController.instance.MiddleBossClear
                        && !CanvasKihonn.instance.BossStart)
                    {
                        Stage7MainBoss();
                        isOnceBoss = false;
                    }
                }
                break;
        }
    }
    private IEnumerator Stage1(){
        yield return new WaitForSeconds(0);
        Stage1MiddleBoss();
    }
    private IEnumerator Stage2(){
        yield return new WaitForSeconds(0);
        Stage2MiddleBoss();
    }

    private IEnumerator Stage3(){
        yield return new WaitForSeconds(0);
        Stage3MiddleBoss();
    }
    private IEnumerator Stage4(){
        yield return new WaitForSeconds(0);
        Stage4MiddleBoss();
    }

    private IEnumerator Stage5(){
        yield return new WaitForSeconds(0);
        Stage5MiddleBoss();
    }
    private IEnumerator Stage6()
    {
        yield return new WaitForSeconds(0);
        Stage6MiddleBoss();
    }

    private IEnumerator Stage7()
    {
        yield return new WaitForSeconds(0);
        Stage7MiddleBoss();
    }

    void Stage1MainBoss()
    {
        Instantiate(StageOneBossPrefab,
            transform.position,
            transform.rotation
            );
        MainBossFlag = true;//中ボスが撃破サれているときにメインボスを出す
    }
    void Stage1MiddleBoss()
    {
        Instantiate(StageOneMiddleBossPrefab,//
            transform.position,//
            transform.rotation//
            );
        MiddleBossFlag = true;//中ボスがまだ撃破サれていない
    }
    void Stage2MainBoss()
    {
        Instantiate(StageTwoBossPrefab,//
            transform.position,//
            transform.rotation//
            );
        MainBossFlag = true;
    }
    void Stage2MiddleBoss()
    {
        Instantiate(StageTwoMiddleBossPrefab,//
            transform.position,//
            transform.rotation//
            );
        MiddleBossFlag = true;
    }
    void Stage3MainBoss()
    {
        Instantiate(StageThreeBossPrefab,//
            transform.position,//
            transform.rotation//
            );
        MainBossFlag = true;
    }
    void Stage3MiddleBoss()
    {
        Instantiate(StageThreeMiddleBossPrefab,//
            transform.position,//
            transform.rotation//
            );
        MiddleBossFlag = true;
    }
    void Stage4MainBoss()
    {
        Instantiate(StageFourBossPrefabb,//
            transform.position,//
            transform.rotation//
            );
        MainBossFlag = true;
    }
    void Stage4MiddleBoss()
    {
        Instantiate(StageFourMiddleBossPrefab,//
            transform.position,//
            transform.rotation//
            );
        MiddleBossFlag = true;
    }

    void Stage5MainBoss()
    {
        Instantiate(StageFiveBossPrefab,//
            transform.position,//
            transform.rotation//
            );
        MainBossFlag = true;
    }
    void Stage5MiddleBoss()
    {
        Instantiate(StageFiveMiddleBossPrefab,//
            transform.position,//
            transform.rotation//
            );
        MiddleBossFlag = true;
    }

    void Stage6MainBoss()
    {
        Instantiate(StageSixBossPrefab,//
            transform.position,//
            transform.rotation//
            );
        MainBossFlag = true;
    }
    void Stage6MiddleBoss()
    {
        Instantiate(StageSixMiddleBossPrefabb,//
            transform.position,//
            transform.rotation//
            );
        MiddleBossFlag = true;
    }

    void Stage7MainBoss()
    {
        Instantiate(StageSevenBossPrefab,//
            transform.position,//
            transform.rotation//
            );
        MainBossFlag = true;
    }
    void Stage7MiddleBoss()
    {
        Instantiate(StageSevenMiddleBossPrefab,
            transform.position,//
            transform.rotation//
            );
        MiddleBossFlag = true;
    }
}


