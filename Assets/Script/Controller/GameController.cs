using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverText;

	private GameObject[] MiddleObjects;
    private GameObject[] MainObjects;

    public static GameController instance;

    public bool MiddleBossClear =false;
    public bool MainBossClear =false;
    
        public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        //ゲームオーバーテキストを非表示
        gameOverText.SetActive(false);
    }
    void Update()
    {
        if(gameOverText.activeSelf == true)
        {
            //もしスペースボタンが押されたらシーンの再読み込み
            if (Input.GetKeyDown(KeyCode.Z))
            {
               SceneManager.LoadScene("Stage1");
            }
        }
		MiddleObjects = GameObject.FindGameObjectsWithTag("MiddleBoss");//ここにないと、ステージをスタートしてすぐに会話が始まってしまう

		if(MiddleObjects.Length == 0 && EnemyGenerater.instance.MiddleBossFlag){
            MiddleBossClear =true;
		}
        MainObjects = GameObject.FindGameObjectsWithTag("MainBoss");

		if(MainObjects.Length == 0 && EnemyGenerater.instance.MainBossFlag){
            MiddleBossClear = false;//中ボスのフラグ解除
            MainBossClear =true;//メインボスが今いるという信号
		}
        
    }
    public void GameOver()
    {
        gameOverText.SetActive(true);
    }
}
