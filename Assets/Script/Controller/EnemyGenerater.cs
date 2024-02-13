using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGenerater : MonoBehaviour
{
    public GameObject MobOnePrefab;
    public GameObject MobTwoPrefab;
    public GameObject MobThreePrefab;
    public GameObject MobFourPrefab;
    public GameObject MobFivePrefab;
    public GameObject MobTwoRightPrefab;
    public GameObject MobTwoLeftPrefab;
    //
    public GameObject AinessPrefab;
    public GameObject GorusiPrefab;
    public GameObject MalzennPrefab;
    public GameObject CrownPrefab;
    public GameObject SuzukaPrefab;
    public GameObject KitasannPrefab;
    public GameObject BurubonnPrefab;
    public GameObject SatonoDiamondPrefab;
    public GameObject FalkoPrefab;
    public GameObject DouramentePrefab;
    public GameObject GorusiMiddleBossPrefab;
    public GameObject VirusinaPrefab;
    public GameObject VirusinaMiddleBossPrefab;
    public GameObject VivurosPrefab;


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
                Debug.Log("Stage1");
                StartCoroutine(Stage1());
                break;

            case "Stage2":
                Debug.Log("Stage2");
                StartCoroutine(Stage2());
                break;

            case "Stage3":
                Debug.Log("Stage3");
                StartCoroutine(Stage3());
                break;

            case "Stage4":
                Debug.Log("Stage4");
                StartCoroutine(Stage4());
                break;

            case "Stage5":
                Debug.Log("Stage5");
                StartCoroutine(Stage5());
                StartCoroutine(Stage5Next());
                break;

            case "Stage6":
                Debug.Log("Stage6");
                StartCoroutine(Stage6());
                break;

            case "Stage7":
                Debug.Log("Stage7");
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
                    if (GameClearController.instance.MiddleBossClear
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
                    if (GameClearController.instance.MiddleBossClear
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
                    if (GameClearController.instance.MiddleBossClear
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
                    if (GameClearController.instance.MiddleBossClear
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
                    if (GameClearController.instance.MiddleBossClear
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
                    if (GameClearController.instance.MiddleBossClear
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
                    if (GameClearController.instance.MiddleBossClear
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
        // yield return new WaitForSeconds(5);
        // MobInstanceOne();
        // yield return new WaitForSeconds(5);
        // MobOneInstanceCenterOne();
        // yield return new WaitForSeconds(1);
        // MobOneInstanceCenterTwo();
        // yield return new WaitForSeconds(1);
        // MobOneInstanceCenterThree();
        // yield return new WaitForSeconds(1);
        // MobOneInstanceCenterFour();
        // yield return new WaitForSeconds(1);
        // MobOneInstanceCenterFive();
        // yield return new WaitForSeconds(1);
        // MobOneInstanceCenterSix();
        // yield return new WaitForSeconds(5);
        // MobTwoInstanceCenterFour();
        // yield return new WaitForSeconds(8);
        yield return new WaitForSeconds(0);
        Stage1MiddleBoss();
    }
    private IEnumerator Stage2(){
        // yield return new WaitForSeconds(1);
        // MobTwoInstanceCenterFour();
        // yield return new WaitForSeconds(6);
        // MobOneInstanceCenterTwo();
        // yield return new WaitForSeconds(1);
        // MobOneInstanceCenterSix();
        // yield return new WaitForSeconds(5);
        // MobTwoInstanceCenterThree();
        // MobOneInstanceCenterOne();
        // yield return new WaitForSeconds(1);
        // MobOneInstanceCenterTwo();
        // yield return new WaitForSeconds(1);
        // MobOneInstanceCenterThree();
        // yield return new WaitForSeconds(1);
        // MobOneInstanceCenterFour();
        // yield return new WaitForSeconds(13);
        yield return new WaitForSeconds(0);
        Stage2MiddleBoss();
    }

    private IEnumerator Stage3(){
        // yield return new WaitForSeconds(1);
        // MobFiveInstanceCenterFour();
        // yield return new WaitForSeconds(2);
        // MobOneInstanceCenterTwo();
        // yield return new WaitForSeconds(15);
        // MobThreeInstanceCenterThree();
        // yield return new WaitForSeconds(25);
        // MobFourInstanceCenterSix();
        // yield return new WaitForSeconds(23);
        yield return new WaitForSeconds(0);
        Stage3MiddleBoss();
    }
    private IEnumerator Stage4(){
        // yield return MobTwoRightInstanceCenter();
        // yield return new WaitForSeconds(4);
        // yield return MobTwoLeftInstanceCenter();
        // yield return new WaitForSeconds(4);
        // yield return MobTwoRightInstanceCenter();
        // yield return new WaitForSeconds(4);
        // yield return MobTwoLeftInstanceCenter();
        // yield return new WaitForSeconds(4);
        // yield return new WaitForSeconds(11);
        yield return new WaitForSeconds(0);
        Stage4MiddleBoss();
    }

    private IEnumerator Stage5(){
        // yield return new WaitForSeconds(4);
        // MobTwoInstanceCenterFour();
        // yield return new WaitForSeconds(10);
        // MobFourInstanceCenterOne();
        // yield return new WaitForSeconds(11);
        // MobOneInstanceCenterFour();
        // yield return new WaitForSeconds(12);
        yield return new WaitForSeconds(0);
        Stage5MiddleBoss();
    }
    private IEnumerator Stage5Next(){
        // MobOneInstanceCenterTwo();
        // yield return new WaitForSeconds(2);
        // MobOneInstanceCenterThree();
        // yield return new WaitForSeconds(3);
        // MobOneInstanceCenterSix();
        // yield return new WaitForSeconds(2);
        // MobOneInstanceCenterFour();
        // yield return new WaitForSeconds(2);
        // MobOneInstanceCenterThree();
        // yield return new WaitForSeconds(3);
        yield return new WaitForSeconds(0);
        MobOneInstanceCenterFive();
    }
    private IEnumerator Stage6()
    {
        // yield return new WaitForSeconds(3);
        yield return new WaitForSeconds(0);
        Stage6MiddleBoss();
    }

    private IEnumerator Stage7()
    {
        // yield return new WaitForSeconds(3);
        yield return new WaitForSeconds(0);
        Stage7MiddleBoss();
    }
    void MobInstanceOne()
    {
        Instantiate(MobOnePrefab, new Vector3(0.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobOnePrefab, new Vector3(1.0f, 5.5f, 0.0f), transform.rotation);
        Instantiate(MobOnePrefab, new Vector3(2.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobOnePrefab, new Vector3(3.0f, 5.5f, 0.0f), transform.rotation);
        Instantiate(MobOnePrefab, new Vector3(4.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobOnePrefab, new Vector3(5.0f, 5.5f, 0.0f), transform.rotation);
        Instantiate(MobOnePrefab, new Vector3(-1.0f, 5.5f, 0.0f), transform.rotation);
        Instantiate(MobOnePrefab, new Vector3(-2.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobOnePrefab, new Vector3(-3.0f, 5.5f, 0.0f), transform.rotation);
        Instantiate(MobOnePrefab, new Vector3(-4.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobOnePrefab, new Vector3(-5.0f, 5.5f, 0.0f), transform.rotation);
    }
    private IEnumerator MobTwoRightInstanceCenter()
    {
        Instantiate(MobTwoRightPrefab, new Vector3(5.0f, 3.0f, 0.0f), transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(MobTwoRightPrefab, new Vector3(6.0f, 3.0f, 0.0f), transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(MobTwoRightPrefab, new Vector3(7.0f, 3.0f, 0.0f), transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(MobTwoRightPrefab, new Vector3(8.0f, 3.0f, 0.0f), transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(MobTwoRightPrefab, new Vector3(9.0f, 3.0f, 0.0f), transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(MobTwoRightPrefab, new Vector3(10.0f, 3.0f, 0.0f), transform.rotation);
    }
    private IEnumerator MobTwoLeftInstanceCenter()
    {
        Instantiate(MobTwoLeftPrefab, new Vector3(-5.0f, 3.0f, 0.0f), transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(MobTwoLeftPrefab, new Vector3(-6.0f, 3.0f, 0.0f), transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(MobTwoLeftPrefab, new Vector3(-7.0f, 3.0f, 0.0f), transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(MobTwoLeftPrefab, new Vector3(-8.0f, 3.0f, 0.0f), transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(MobTwoLeftPrefab, new Vector3(-9.0f, 3.0f, 0.0f), transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(MobTwoLeftPrefab, new Vector3(-10.0f, 3.0f, 0.0f), transform.rotation);
    }
    void MobOneInstanceCenterOne()
    {
        Instantiate(MobOnePrefab, new Vector3(0.0f, 6.0f, 0.0f), transform.rotation);
    }
    void MobFourInstanceCenterOne()
    {
        Instantiate(MobFourPrefab, new Vector3(0.0f, 6.0f, 0.0f), transform.rotation);
    }
    void MobFiveInstanceCenterOne()
    {
        Instantiate(MobFivePrefab, new Vector3(0.0f, 6.0f, 0.0f), transform.rotation);
    }
    void MobOneInstanceCenterTwo()
    {
        Instantiate(MobOnePrefab, new Vector3(1.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobOnePrefab, new Vector3(-1.0f, 6.0f, 0.0f), transform.rotation);
    }
    void MobFourInstanceCenterTwo()
    {
        Instantiate(MobFourPrefab, new Vector3(1.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobFourPrefab, new Vector3(-1.0f, 6.0f, 0.0f), transform.rotation);
    }
    void MobFiveInstanceCenterTwo()
    {
        Instantiate(MobFivePrefab, new Vector3(1.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobFivePrefab, new Vector3(-1.0f, 6.0f, 0.0f), transform.rotation);
    }
    void MobOneInstanceCenterThree()
    {
        Instantiate(MobOnePrefab, new Vector3(2.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobOnePrefab, new Vector3(-2.0f, 6.0f, 0.0f), transform.rotation);
    }
    void MobTwoInstanceCenterThree()
    {
        Instantiate(MobTwoPrefab, new Vector3(2.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobTwoPrefab, new Vector3(-2.0f, 6.0f, 0.0f), transform.rotation);
    }
    void MobThreeInstanceCenterThree()
    {
        Instantiate(MobThreePrefab, new Vector3(2.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobThreePrefab, new Vector3(-2.0f, 6.0f, 0.0f), transform.rotation);
    }
    void MobFiveInstanceCenterThree()
    {
        Instantiate(MobFivePrefab, new Vector3(2.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobFivePrefab, new Vector3(-2.0f, 6.0f, 0.0f), transform.rotation);
    }
    void MobOneInstanceCenterFour()
    {
        Instantiate(MobOnePrefab, new Vector3(3.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobOnePrefab, new Vector3(-3.0f, 6.0f, 0.0f), transform.rotation);
    }
    void MobTwoInstanceCenterFour()
    {
        Instantiate(MobTwoPrefab, new Vector3(3.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobTwoPrefab, new Vector3(-3.0f, 6.0f, 0.0f), transform.rotation);
    }
    void MobFourInstanceCenterFour()
    {
        Instantiate(MobFourPrefab, new Vector3(3.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobFourPrefab, new Vector3(-3.0f, 6.0f, 0.0f), transform.rotation);
    }
    void MobFiveInstanceCenterFour()
    {
        Instantiate(MobFivePrefab, new Vector3(3.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobFivePrefab, new Vector3(-3.0f, 6.0f, 0.0f), transform.rotation);
    }
    void MobOneInstanceCenterFive()
    {
        Instantiate(MobOnePrefab, new Vector3(4.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobOnePrefab, new Vector3(-4.0f, 6.0f, 0.0f), transform.rotation);
    }
    void MobOneInstanceCenterSix()
    {
        Instantiate(MobOnePrefab, new Vector3(5.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobOnePrefab, new Vector3(-5.0f, 6.0f, 0.0f), transform.rotation);
    }
    void MobFourInstanceCenterSix()
    {
        Instantiate(MobFourPrefab, new Vector3(5.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobFourPrefab, new Vector3(-5.0f, 6.0f, 0.0f), transform.rotation);
    }
    void MobFiveInstanceCenterSix()
    {
        Instantiate(MobFivePrefab, new Vector3(5.0f, 6.0f, 0.0f), transform.rotation);
        Instantiate(MobFivePrefab, new Vector3(-5.0f, 6.0f, 0.0f), transform.rotation);
    }
    void Stage1MainBoss()
    {
        Instantiate(GorusiPrefab,//生成するもの
            transform.position,
            transform.rotation//生成時の向き
            );
        MainBossFlag = true;
    }
    void Stage1MiddleBoss()
    {
        Instantiate(AinessPrefab,//生成するもの
            transform.position,//生成する場所(今回はアタッチしているオブジェクトからになる)
            transform.rotation//生成時の向き
            );
        MiddleBossFlag = true;
    }
    void Stage2MainBoss()
    {
        Instantiate(CrownPrefab,//生成するもの
            transform.position,//生成する場所(今回はアタッチしているオブジェクトからになる)
            transform.rotation//生成時の向き
            );
        MainBossFlag = true;
    }
    void Stage2MiddleBoss()
    {
        Instantiate(MalzennPrefab,//生成するもの
            transform.position,//生成する場所(今回はアタッチしているオブジェクトからになる)
            transform.rotation//生成時の向き
            );
        MiddleBossFlag = true;
    }
    void Stage3MainBoss()
    {
        Instantiate(KitasannPrefab,//生成するもの
            transform.position,//生成する場所(今回はアタッチしているオブジェクトからになる)
            transform.rotation//生成時の向き
            );
        MainBossFlag = true;
    }
    void Stage3MiddleBoss()
    {
        Instantiate(SuzukaPrefab,//生成するもの
            transform.position,//生成する場所(今回はアタッチしているオブジェクトからになる)
            transform.rotation//生成時の向き
            );
        MiddleBossFlag = true;
    }
    void Stage4MainBoss()
    {
        Instantiate(SatonoDiamondPrefab,//生成するもの
            transform.position,//生成する場所(今回はアタッチしているオブジェクトからになる)
            transform.rotation//生成時の向き
            );
        MainBossFlag = true;
    }
    void Stage4MiddleBoss()
    {
        Instantiate(BurubonnPrefab,//生成するもの
            transform.position,//生成する場所(今回はアタッチしているオブジェクトからになる)
            transform.rotation//生成時の向き
            );
        MiddleBossFlag = true;
    }

    void Stage5MainBoss()
    {
        Instantiate(DouramentePrefab,//生成するもの
            transform.position,//生成する場所(今回はアタッチしているオブジェクトからになる)
            transform.rotation//生成時の向き
            );
        MainBossFlag = true;
    }
    void Stage5MiddleBoss()
    {
        Instantiate(FalkoPrefab,//生成するもの
            transform.position,//生成する場所(今回はアタッチしているオブジェクトからになる)
            transform.rotation//生成時の向き
            );
        MiddleBossFlag = true;
    }

    void Stage6MainBoss()
    {
        Instantiate(VirusinaPrefab,//生成するもの
            transform.position,//生成する場所(今回はアタッチしているオブジェクトからになる)
            transform.rotation//生成時の向き
            );
        MainBossFlag = true;
    }
    void Stage6MiddleBoss()
    {
        Instantiate(GorusiMiddleBossPrefab,//生成するもの
            transform.position,//生成する場所(今回はアタッチしているオブジェクトからになる)
            transform.rotation//生成時の向き
            );
        MiddleBossFlag = true;
    }

    void Stage7MainBoss()
    {
        Instantiate(VivurosPrefab,//生成するもの
            transform.position,//生成する場所(今回はアタッチしているオブジェクトからになる)
            transform.rotation//生成時の向き
            );
        MainBossFlag = true;
    }
    void Stage7MiddleBoss()
    {
        Instantiate(VirusinaMiddleBossPrefab,//生成するもの
            transform.position,//生成する場所(今回はアタッチしているオブジェクトからになる)
            transform.rotation//生成時の向き
            );
        MiddleBossFlag = true;
    }
}


