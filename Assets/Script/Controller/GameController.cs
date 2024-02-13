using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverText;

    //public Text ScoreText;
    //int score = 0;
    void Start()
    {
        //ゲームオーバーテキストを非表示
        gameOverText.SetActive(false);

        //スコアテキストを表示
        //ScoreText.text = "SCORE:" + score;
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
        
    }
    //スコア加算メソッド
    // public void AddScore()
    // {
    //     score += 100;
    //     ScoreText.text = "SCORE:" + score;
    // }
    public void GameOver()
    {
        gameOverText.SetActive(true);
    }
}
