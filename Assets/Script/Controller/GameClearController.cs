using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameClearController : MonoBehaviour {

	// 配列（同じ種類の複数のデータを収納するための箱を作る）
	private GameObject[] MiddleObjects;
    private GameObject[] MainObjects;
    public static GameClearController instance;
    public bool MiddleBossClear =false;
    public bool MainBossClear =false;
        public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

	void Update () {

		MiddleObjects = GameObject.FindGameObjectsWithTag("MiddleBoss");

		if(MiddleObjects.Length == 0 && EnemyGenerater.instance.MiddleBossFlag){
            MiddleBossClear =true;
		}
        MainObjects = GameObject.FindGameObjectsWithTag("MainBoss");

		if(MainObjects.Length == 0 && EnemyGenerater.instance.MainBossFlag){
            MiddleBossClear = false;
            MainBossClear =true;
		}
	}
}
