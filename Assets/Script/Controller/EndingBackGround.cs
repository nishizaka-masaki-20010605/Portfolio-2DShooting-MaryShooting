using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingBackGround : MonoBehaviour
{
    [SerializeField] Text nameText;//名前
    [SerializeField] Text ContentText;//会話内容
    private Image Leftimg;
    private Image Rightimg;
    string[] numberEnding = {
                        "",
      　　　　　　　　　　"あら、ちゃんと材料集められたの？",//ニッコリ
                        "大変だったけどね",//苦笑
                        "まあこれでスコーンが作れるから",//笑い
                        "うん、じゃあ出来たら呼んでね？",//笑い
                        "私は全然役に立てないからさ",//5//苦笑
                        "うん、料理下手くそだしね",//怒り笑い
                        "家に帰ってさっさと寝てろ！",//8//笑い
                        ""};
    public string[] CharacterNameEnding = { "",
                        "ハンナ",
                        "マリー",
                        "マリー",
                        "ハンナ",
                        "ハンナ",//5
                        "マリー",
                        "マリー",
                        ""};
    string[] Leftimgtest = {"Kihonn","Kihonn","Kusyou","Warai","Warai","Warai",//5
                        "Ikariwarai","Warai"};//10
    string[] Rightimgtest =  { "Kihonn","Nikkori","Nikkori","Nikkori","Warai","Kusyou",//5
                        "Kusyou","Kusyou"};//10

                        
    int EndingCount;
    int EndingMax =7;

    // Update is called once per frame
    void Start(){
        ContentText.text = numberEnding[0];
        nameText.text = CharacterNameEnding[0];
        Leftimg = GameObject.Find("CharacterLeft").GetComponent<Image>();
        Rightimg = GameObject.Find("CharacterRight").GetComponent<Image>();
        Leftimg.sprite = Resources.Load<Sprite>("LeftImage/Mary" + Leftimgtest[EndingCount].ToString()); //ステージによって変える部分
        Rightimg.sprite = Resources.Load<Sprite>("RightImage/Hanna" + Rightimgtest[EndingCount].ToString()); //ステージによって変える部分
    }
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (EndingCount < EndingMax)
                {
                    EndingCount++;
                    StageEnding();
                }
                else if (EndingCount == EndingMax)
                {
                    SceneManager.LoadScene("Opening");
                }
            }
    }
    void StageEnding()
    {
        ContentText.text = numberEnding[EndingCount];
        nameText.text = CharacterNameEnding[EndingCount];
        Leftimg.sprite = Resources.Load<Sprite>("LeftImage/Mary" + Leftimgtest[EndingCount].ToString()); //ステージによって変える部分
        Rightimg.sprite = Resources.Load<Sprite>("RightImage/Hanna" + Rightimgtest[EndingCount].ToString()); //ステージによって変える部分
    }

}
