using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasKihonn : MonoBehaviour
{
    [SerializeField] Text nameText;//名前
    [SerializeField] Text ContentText;//会話内容
    [SerializeField] private CanvasGroup a;//透過度
    public static CanvasKihonn instance;
    public bool BossStart = true;//ボスステージに行くときにPlayerを再び動かせるようにする
    int NextSceneCountMax =0;//中ボスとの会話が終わったかの判断につかう
    int NextSceneCountMaxNext=0;//次のステージに行くかどうかの判断につかう

    public int count = 0;//戦闘前の会話用
    public int countNext = 0;//戦闘後の会話用（分けるのはわかりやすくするため）
    int alphaCount = 0;//次のステージでCanwasが表示されないようにする保険
    private Image Leftimg;
    private Image Rightimg;

    public GameObject Player;
    string StageName;

    //表情一覧
    /* マリー　Kihonn　Nikkori Warai　Bikkuri Ikari　Konwaku Akire　Niyaniya　Ase　Kusyou　Gimonn Ikariwarai Hatena
    　　ハンナ　Kihonn Bikkuri　Nikkori Niyaniya　Naki Hatena　Warai　Kusyou
    　　マチルダ Kihonn Hatena Nikkori Kanasii　
    　　メリナ  Kihonn Sekimenn　Nikkori Warai
    　　葵　Kihonn　Hatena Nikkori　Warai　
    　　桜　Kihonn　Nikkori　Houtai　Gimonn
    　　テレサ Kihonn Ikari　Konwaku　Nikkori　Warai
    　　フィオナ　Kihonn　Nikkori Kusyou Warai
    　　*/

    string[] number = { "あら、マリーじゃない",//ビックリ
                        "えーっと、今スコーンを作ろうと思っているんだけど",//ニッコリ
                        "あら、いいじゃない",//ニッコリ
                        "それで材料を探しているんだけど",//キホン
                        "小麦、バター、砂糖、塩、",//5//キホン
                        "牛乳、卵、ベーキングパウダーね",//キホン
                        "頂戴？",//ニッコリ
                        "ふーん（ニヤニヤ）",//ニヤニヤ
                        "だめよ！",//ビックリ
                        "どうしてもほしけりゃあたしを倒して手に入れな！",//ビックリ
                        ""};//10
    string[] CharacterName1 = { "ハンナ",
                        "マリー",
                        "ハンナ",
                        "マリー",
                        "マリー",//5
                        "マリー",
                        "マリー",
                        "ハンナ",
                        "ハンナ",
                        "ハンナ"};//10

    string[] Leftimgtest = { "Kihonn","Nikkori","Nikkori","Kihonn","Kihonn",//5
                        "Kihonn","Nikkori","Nikkori","Nikkori","Nikkori"};//10
    string[] Rightimgtest =  { "Bikkuri","Bikkuri","Nikkori","Nikkori","Nikkori",//5
                        "Nikkori","Nikkori","Niyaniya","Bikkuri","Bikkuri"};//10

    string[] numberNext ={"あーん、ま・け・ちゃ・っ・た！",//泣き
                        "意外と余裕そうね",//笑い
                        "それで材料をもらいたいんだけど",//ニッコリ
                        "材料？ありませんよ？",//ハテナ
                        "へ？",//5　//ビックリ
                        "魔女仲間に配っちゃった",//笑い
                        "小麦も？",//ビックリ
                        "うん、だから家にはなにもないわ",//ニッコリ
                        "どうやって冬を越すの？？",//怒り
                        "あははは…",//苦笑
                        ""};//10
    string[] CharacterNameNext1 = { "ハンナ",
                        "マリー",
                        "マリー",
                        "ハンナ",
                        "マリー",//5
                        "ハンナ",
                        "マリー",
                        "ハンナ",
                        "マリー",
                        "ハンナ"};//10
    string[] LeftimgTestNext = { "Kihonn","Warai","Nikkori","Nikkori","Bikkuri",//5
                        "Bikkuri","Bikkuri","Bikkuri","Ikari","Ikari"};//10
    string[] RightimgTextNext =  { "Naki","Naki","Naki","Hatena","Hatena",//5
                        "Warai","Warai","Nikkori","Nikkori","Kusyou"};//10

    //Stage2

    string[] number2 =  {"お久しぶりですねマチルダさん",//ニッコリ
                        "あら、久しぶり",//ニッコリ
                        "えーっと、今スコーンの材料を探しているんですけど",//困惑
                        "いくらか分けていただけませんか？",//笑い
                        "スコーンの材料？",//5//ハテナ
                        "ええ、小麦とか…",//ニッコリ
                        "小麦とか持ってないわよ",//ハテナ
                        "私が持っているのはバターね",//ニッコリ
                        "かじると美味しいのよ",//ニッコリ
                        "そういえばコイツかなりの天然だった…",//呆れ
                        "バターでいいからよこしなさい！！",//11//笑い
                        ""};
    string[] CharacterName2 = { "マリー",
                        "マチルダ",
                        "マリー",
                        "マリー",
                        "マチルダ",//5
                        "マリー",
                        "マチルダ",
                        "マチルダ",
                        "マチルダ",
                        "マリー",//10
                        "マリー"};


    string[] Leftimgtest2 = { "Nikkori","Nikkori","Konwaku","Warai","Warai",//5
                        "Nikkori","Nikkori","Nikkori","Nikkori","Akire","Warai"};//11
    string[] Rightimgtest2 =  { "Kihonn","Nikkori","Nikkori","Nikkori","Hatena",//5
                        "Hatena","Hatena","Nikkori","Nikkori","Nikkori","Nikkori"};//11

    string[] numberNext2 = { "まけてしまった",//悲しい
                        "うーん、バターとか持ち歩くと溶けそうなんだけどな",//困惑
                        "バターは万能、カロリーたっぷり",//ニッコリ
                        "太りますよ？",//呆れ
                        "次はメリナのところに行くと良い",//5//キホン
                        "あの人魔女じゃなくて修道女なんですけど…",//困惑
                        ""};
    public string[] CharacterNameNext2 = { "マチルダ",
                        "マリー",
                        "マチルダ",
                        "マリー",
                        "マチルダ",//5
                        "マリー"};

    string[] LeftimgTestNext2 = { "Kihonn","Konwaku","Konwaku","Akire","Akire",//5
                        "Konwaku"};//10
    string[] RightimgTextNext2 =  { "Kanasii","Kanasii","Nikkori","Nikkori","Kihonn",//5
                        "Kihonn"};//10

    //Stage3
    string[] number3 =  { "魔女よ…",//キホン
                        "邪悪な魔女よ…",//キホン
                        "神に背くものよ…",//キホン
                        "悔い改めよ…",//キホン
                        "お母さんと友達な時点であなたも十分神に背いてますよ？",//5//ニッコリ
                        "…",//キホン
                        "あんなだらしない胸をした女なんて友達じゃない",//赤面
                        "ふーん（ニヤニヤ）",//8//ニヤニヤ
                        ""};
    string[] CharacterName3 = { "メリナ",
                        "メリナ",
                        "メリナ",
                        "メリナ",
                        "マリー",//5
                        "メリナ",
                        "メリナ",
                        "マリー",//8
                        ""};

    string[] Leftimgtest3 = { "Kihonn","Kihonn","Kihonn","Kihonn","Nikkori",//5
                        "Nikkori","Nikkori","Niyaniya"};//10
    string[] Rightimgtest3 =  { "Kihonn","Kihonn","Kihonn","Kihonn","Kihonn",//5
                        "Kihonn","Sekimenn","Sekimenn"};//10

    string[] numberNext3 = { "強くなったわね",//ニッコリ
                        "ええ、メリナさんが稽古をつけてくださったおかげですよ",//ニッコリ
                        "ふむ、それでは私からはこちらを授けましょう",//笑い
                        "卵です",//笑い
                        "うーん、これはまた持ち運びづらいものを",//5//困惑
                        "割らないように気をつけてください",//ニッコリ
                        "はーい",//7//汗
                        "",};
    string[] CharacterNameNext3 = { "メリナ",
                        "マリー",
                        "メリナ",
                        "メリナ",
                        "マリー",//5
                        "メリナ",
                        "マリー",
                        ""};//10

    string[] LeftimgTestNext3 = { "Kihonn","Nikkori","Nikkori","Nikkori","Konwaku",//5
                        "Konwaku","Ase"};//10
    string[] RightimgTextNext3 =  { "Nikkori","Nikkori","Warai","Warai","Warai",//5
                        "Nikkori","Nikkori"};//10
                                                  //Stage4
    string[] number4 =  { "マリー、どこに行くの",//キホン
                        "葵さん、えっとスコーンの材料を探していまして",//笑い
                        "ああ、そういえばハンナさんからなにかいただきましたね",//ハテナ
                        "ついに魔法とは無関係な人が出てきましたね",//困惑
                        "私は忍者だからね",//5//ニッコリ
                        "",};
    string[] CharacterNameFour = { "葵",
                        "マリー",
                        "葵",
                        "マリー",
                        "葵"//5
                        };//10

    string[] Leftimgtest4 = { "Kihonn","Warai","Warai","Konwaku","Konwaku"};//5
    string[] Rightimgtest4 =  { "Kihonn","Kihonn","Hatena","Hatena","Nikkori"};//5 

    string[] numberNext4 = {
                        "勝った！第三部完！",//笑い
                        "四面ボスだけどね",//笑い
                        "ちなみに葵は何をくれるの？",//ハテナ
                        "えっと、この白い粉を",//ニッコリ
                        "危ないやつじゃないよね？",//5//ハテナ
                        "べいきんぐぱうだー、とか聞いていますが",//ハテナ
                        "うーん、また持ち運びにくいものを…",//7//困惑
                        ""};
    string[] CharacterNameNextFour = { "マリー",
                        "葵",
                        "マリー",
                        "葵",
                        "マリー",//5
                        "葵",
                        "メリー"};//7

    string[] LeftimgTestNext4 = { "Warai","Warai","Hatena","Hatena","Hatena",//5
                        "Hatena","Konwaku"};//10
    string[] RightimgTextNext4 =  { "Kihonn","Warai","Warai","Nikkori","Nikkori",//5
                        "Hatena","Hatena"};//10

    //Stage5
    string[] number5 =  { "あら、マリー様、使いをよこしていただければお迎えを差し上げましたものを",//ニッコリ
                        "うーん、家は使用人を抱えられるほどお金持ちじゃないからね",//困惑
                        "さようですか",//ニッコリ
                        "実は小麦を探してまして、持っていますか？",//キホン
                        "コメならありますが…、どちらにしろただで渡すわけには行きません",//5//キホン
                        "母君からマリー様を鍛えるように仰せつかっておりますゆえ",//ニッコリ
                        "いざ、参る！",//ニッコリ
                        ""};//8
    string[] CharacterNameFive = { "桜",
                        "マリー",
                        "桜",
                        "マリー",
                        "桜",//5
                        "桜",
                        "桜",
                        "桜"};//8

    string[] Leftimgtest5 = { "Kihonn","Konwaku","Konwaku","Kihonn","Kihonn",//5
                        "Kihonn","Kihonn","Kihonn"};//10
    string[] Rightimgtest5 =  { "Nikkori","Nikkori","Nikkori","Nikkori","Kihonn",//5
                        "Nikkori","Nikkori","Kihonn"};//10

    string[] numberNext5 = { "うっ…強い…",//包帯
                        "良かった、勝てた！",//ニッコリ
                        "それでは私からはお塩をお渡しします！",//ニッコリ
                        "それは嬉しいけど",//苦笑
                        "肝心の小麦が未だに手に入ってないの",//5//苦笑
                        "ふむ、でしたらテレサさんのところに行けばいかがでしょう",//疑問
                        "もしかしたら小麦を持っているかもしれません",//7//ニッコリ
                        ""};
    string[] CharacterNameNextFive = { "桜",
                        "マリー",
                        "桜",
                        "マリー",
                        "マリー",//5
                        "桜",
                        "桜",
                        ""};

    string[] LeftimgTestNext5 = { "Kihonn","Nikkori","Nikkori","Kusyou","Kusyou",//5
                        "Kusyou","Kusyou"};//7
    string[] RightimgTextNext5 =  { "Houtai","Houtai","Nikkori","Nikkori","Nikkori",//5
                        "Gimonn","Nikkori"};//7
    string[] number6 =  { "テレサさん、小麦ってもってますか？",//疑問
                        "いきなりご挨拶ですね",//怒り
                        "小麦はあいにくと切らしております",//怒り
                        "どいつもこいつも、冬の蓄えのことを考えていないなんて",//呆れ
                        "こらしめてやらなければね！",//5//ニッコリ
                        ""};//6
    string[] CharacterNameSix = { "マリー",
                        "テレサ",
                        "テレサ",
                        "マリー",
                        "マリー",//5
                        ""};//6

    string[] Leftimgtest6 = { "Gimonn","Gimonn","Gimonn","Akire","Nikkori"};
    string[] Rightimgtest6 =  { "Kihonn","Ikari","Ikari","Ikari","Ikari"};

    string[] numberNext6 = { "テレサさんはやっぱり強いですね",// ニッコリ
                        "あなたキャラがブレブレよ？二重人格かしらね？",　//困惑
                        "外面がいいって言ってください",//ニヤニヤ
                        "褒め言葉ではないですよ",//困惑
                        "私は小麦はあいにくきらしておりますが、代わりに砂糖を持っていますよ",//5//ニッコリ
                        "お砂糖、ありがたい！",//ニッコリ
                        "砂糖は高いんですよ？大切に使ってくださいね",//笑い
                        ""};//8
    string[] CharacterNameNextSix = { "マリー",
                        "テレサ",
                        "マリー",
                        "テレサ",
                        "テレサ",//5
                        "マリー",
                        "テレサ",
                        ""};

    string[] LeftimgTestNext6 = { "Nikkori","Nikkori","Niyaniya","Niyaniya","Niyaniya",//5
                        "Nikkori","Nikkori"};//10
    string[] RightimgTextNext6 =  { "Kihonn","Konwaku","Konwaku","Konwaku","Nikkori",//5
                        "Nikkori","Warai"};//10
                                                                                   //Stage7
    string[] number7 =  { "お久しぶりですマリーさん",//ニッコリ
                        "ついに踊り子が出てきたわね",//苦笑
                        "お母さんが入っていた、魔女関係者とは一体…",//苦笑
                        "うふふ、ハンナさんからお話は伺っております",//笑い
                        "もしかして小麦をもっていたりしますか？",//5//疑問
                        "ええ、皆さん小麦を切らす頃かとおもいまして",//ニッコリ
                        "こんな格好を子ている人が一番しっかりものなの解せないわね",//苦笑
                        "あら踊り子への偏見ですよ",//苦笑
                        "偏見は正さないといけませんね",//笑い
                        "暴力で！",//笑い
                        ""};//11
    string[] CharacterNameSeven = { "フィオナ",
                        "マリー",
                        "マリー",
                        "フィオナ",
                        "マリー",//5
                        "フィオナ",
                        "マリー",
                        "フィオナ",
                        "フィオナ",
                        "フィオナ"};//10

    string[] Leftimgtest7 = { "Kihonn","Kusyou","Kusyou","Kusyou","Gimonn",//5
                        "Gimonn","Kusyou","Kusyou","Kusyou","Kusyou"};//10
    string[] Rightimgtest7 =  { "Nikkori","Nikkori","Nikkori","Warai","Warai",//5
                        "Nikkori","Nikkori","Kusyou","Warai","Warai"};//10

    string[] numberNext7 = { "強くなりましたね",//ニッコリ
                        "ハンナさんもお喜びになられるでしょう",//ニッコリ
                        "かなり大変だったけどね",//苦笑
                        "これでついにスコーンの材料が手に入るのね",//笑い
                        "早く帰ってスコーンを作っておこうっと",//5//ニッコリ
                        ""};//6
    string[] CharacterNameNextSeven = { "フィオナ",
                        "フィオナ",
                        "マリー",
                        "マリー",
                        "マリー",//5
                        ""};

    string[] LeftimgTestNext7 = { "Kihonn","Kihonn","Kusyou","Warai","Nikkori"};//10
    string[] RightimgTextNext7 =  { "Nikkori","Nikkori","Nikkori","Nikkori","Nikkori"};//10
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }//instanceに必須

    void Start()
    {
        StageName = SceneManager.GetActiveScene().name;//現在のステージ名を取得
        switch (StageName)//ステージ名によってメインボスとの会話テキスト数を取得
        {
            case "Stage1":
                NextSceneCountMax =  number.Length-2;
                NextSceneCountMaxNext = numberNext.Length-2;
                break;

            case "Stage2":
                NextSceneCountMax = number2.Length-2;
                NextSceneCountMaxNext = numberNext2.Length-2;
                break;

            case "Stage3":
                NextSceneCountMax = number3.Length-2;
                NextSceneCountMaxNext = numberNext3.Length-2;
                break;

            case "Stage4":
                NextSceneCountMax = number4.Length-2;
                NextSceneCountMaxNext = numberNext4.Length-2;
                break;

            case "Stage5":
                NextSceneCountMax = number5.Length-2;
                NextSceneCountMaxNext = numberNext5.Length-2;
                break;
            case "Stage6":
                NextSceneCountMax = number6.Length-2;
                NextSceneCountMaxNext = numberNext6.Length-2;
                break;
            case "Stage7":
                NextSceneCountMax = number7.Length-2;
                NextSceneCountMaxNext = numberNext7.Length-2;
                break;
        }

        a.alpha = 0.0f;
        ContentText.text = number[0];
        nameText.text = number[0];
        Leftimg = GameObject.Find("CharacterLeft").GetComponent<Image>();
        Rightimg = GameObject.Find("CharacterRight").GetComponent<Image>();
    }
    void Update()
    {
        if (GameController.instance.MiddleBossClear)
        {
            StartCoroutine("AlphaUp");//Canvasを表示するコルーチン
            switch (StageName)
            {
                case "Stage1":
                    Stage1();
                    break;
                case "Stage2":
                    Stage2();
                    break;
                case "Stage3":
                    Stage3();
                    break;
                case "Stage4":
                    Stage4();
                    break;
                case "Stage5":
                    Stage5();
                    break;
                case "Stage6":
                    Stage6();
                    break;
                case "Stage7":
                    Stage7();
                    break;
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (count < NextSceneCountMax)
                {
                    count++;
                }
                else if (count == NextSceneCountMax)
                {
                    StopCoroutine("AlphaUp");//Upコルーチン停止
                    StartCoroutine("AlphaDown");//キャンバスを見えるようにする
                    BossStart = false;//メインボスにつなぐために必要
                    Player.SetActive(true);
                }
            }
        }
        else if (GameController.instance.MainBossClear)
        {
            alphaCount = 0;
            StartCoroutine("AlphaUp");
            switch (StageName)
            {
                case "Stage1":
                    Stage1Next();
                    break;
                case "Stage2":
                    Stage2Next();
                    break;
                case "Stage3":
                    Stage3Next();
                    break;
                case "Stage4":
                    Stage4Next();
                    break;
                case "Stage5":
                    Stage5Next();
                    break;
                case "Stage6":
                    Stage6Next();
                    break;
                case "Stage7":
                    Stage7Next();
                    break;
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (countNext < NextSceneCountMaxNext)
                {
                    countNext++;
                }
                else if (countNext == NextSceneCountMaxNext)
                {
                    Player.SetActive(true);
                    switch (StageName)
                    {
                        case "Stage1":
                            SceneManager.LoadScene("Stage2");
                            break;
                        case "Stage2":
                            SceneManager.LoadScene("Stage3");
                            break;
                        case "Stage3":
                            SceneManager.LoadScene("Stage4");
                            break;
                        case "Stage4":
                            SceneManager.LoadScene("Stage5");
                            break;
                        case "Stage5":
                            SceneManager.LoadScene("Stage6");
                            break;
                        case "Stage6":
                            SceneManager.LoadScene("Stage7");
                            break;
                        case "Stage7":
                            SceneManager.LoadScene("EndingStage");
                            break;
                    }
                }
            }
        }
    }
    void Stage1()
    {
        ContentText.text = number[count];//会話内容を代入
        nameText.text = CharacterName1[count];//名前を代入
        Leftimg.sprite = Resources.Load<Sprite>("LeftImage/Mary" + Leftimgtest[count].ToString()); //どの画像を左側に表示させるか
        Rightimg.sprite = Resources.Load<Sprite>("RightImage/Hanna" + Rightimgtest[count].ToString()); //右側
    }
    void Stage1Next()
    {
        ContentText.text = numberNext[countNext];
        nameText.text = CharacterNameNext1[countNext];
        Leftimg.sprite = Resources.Load<Sprite>("LeftImage/Mary" + LeftimgTestNext[countNext].ToString()); //ステージによって変える部分
        Rightimg.sprite = Resources.Load<Sprite>("RightImage/Hanna" + RightimgTextNext[countNext].ToString()); //ステージによって変える部分
    }
    void Stage2()
    {
        ContentText.text = number2[count];
        nameText.text = CharacterName2[count];
        Leftimg.sprite = Resources.Load<Sprite>("LeftImage/Mary" + Leftimgtest2[count].ToString()); //ステージによって変える部分
        Rightimg.sprite = Resources.Load<Sprite>("RightImage2/Matilda" + Rightimgtest2[count].ToString()); //ステージによって変える部分
    }
    void Stage2Next()
    {
        ContentText.text = numberNext2[countNext];
        nameText.text = CharacterNameNext2[countNext];
        Leftimg.sprite = Resources.Load<Sprite>("LeftImage/Mary" + LeftimgTestNext2[countNext].ToString()); //ステージによって変える部分
        Rightimg.sprite = Resources.Load<Sprite>("RightImage2/Matilda" + RightimgTextNext2[countNext].ToString()); //ステージによって変える部分
    }
    void Stage3()
    {
        ContentText.text = number3[count];
        nameText.text = CharacterName3[count];
        Leftimg.sprite = Resources.Load<Sprite>("LeftImage/Mary" + Leftimgtest3[count].ToString()); //ステージによって変える部分
        Rightimg.sprite = Resources.Load<Sprite>("RightImage3/Merina" + Rightimgtest3[count].ToString()); //ステージによって変える部分
    }
    void Stage3Next()
    {
        ContentText.text = numberNext3[countNext];
        nameText.text = CharacterNameNext3[countNext];
        Leftimg.sprite = Resources.Load<Sprite>("LeftImage/Mary" + LeftimgTestNext3[countNext].ToString()); //ステージによって変える部分
        Rightimg.sprite = Resources.Load<Sprite>("RightImage3/Merina" + RightimgTextNext3[countNext].ToString()); //ステージによって変える部分
    }
    void Stage4()
    {
        ContentText.text = number4[count];
        nameText.text = CharacterNameFour[count];
        Leftimg.sprite = Resources.Load<Sprite>("LeftImage/Mary" + Leftimgtest4[count].ToString()); //ステージによって変える部分
        Rightimg.sprite = Resources.Load<Sprite>("RightImage4/Aoi" + Rightimgtest4[count].ToString()); //ステージによって変える部分
    }
    void Stage4Next()
    {
        ContentText.text = numberNext4[countNext];
        nameText.text = CharacterNameNextFour[countNext];
        Leftimg.sprite = Resources.Load<Sprite>("LeftImage/Mary" + LeftimgTestNext4[countNext].ToString()); //ステージによって変える部分
        Rightimg.sprite = Resources.Load<Sprite>("RightImage4/Aoi" + RightimgTextNext4[countNext].ToString()); //ステージによって変える部分
    }
    void Stage5()
    {
        ContentText.text = number5[count];
        nameText.text = CharacterNameFive[count];
        Leftimg.sprite = Resources.Load<Sprite>("LeftImage/Mary" + Leftimgtest5[count].ToString()); //ステージによって変える部分
        Rightimg.sprite = Resources.Load<Sprite>("RightImage5/Sakura" + Rightimgtest5[count].ToString()); //ステージによって変える部分
    }
    void Stage5Next()
    {
        ContentText.text = numberNext5[countNext];
        nameText.text = CharacterNameNextFive[countNext];
        Leftimg.sprite = Resources.Load<Sprite>("LeftImage/Mary" + LeftimgTestNext5[countNext].ToString()); //ステージによって変える部分
        Rightimg.sprite = Resources.Load<Sprite>("RightImage5/Sakura" + RightimgTextNext5[countNext].ToString()); //ステージによって変える部分
    }
    void Stage6()
    {
        ContentText.text = number6[count];
        nameText.text = CharacterNameSix[count];
        Leftimg.sprite = Resources.Load<Sprite>("LeftImage/Mary" + Leftimgtest6[count].ToString()); //ステージによって変える部分
        Rightimg.sprite = Resources.Load<Sprite>("RightImage6/Teresa" + Rightimgtest6[count].ToString()); //ステージによって変える部分
    }
    void Stage6Next()
    {
        ContentText.text = numberNext6[countNext];
        nameText.text = CharacterNameNextSix[countNext];
        Leftimg.sprite = Resources.Load<Sprite>("LeftImage/Mary" + LeftimgTestNext6[countNext].ToString()); //ステージによって変える部分
        Rightimg.sprite = Resources.Load<Sprite>("RightImage6/Teresa" + RightimgTextNext6[countNext].ToString()); //ステージによって変える部分
    }
    void Stage7()
    {
        ContentText.text = number7[count];
        Debug.Log(Rightimgtest7[count]);
        nameText.text = CharacterNameSeven[count];
        Leftimg.sprite = Resources.Load<Sprite>("LeftImage/Mary" + Leftimgtest7[count].ToString()); //ステージによって変える部分
        Rightimg.sprite = Resources.Load<Sprite>("RightImage7/Fiona" + Rightimgtest7[count].ToString()); //ステージによって変える部分
    }
    void Stage7Next()
    {
        ContentText.text = numberNext7[countNext];
        nameText.text = CharacterNameNextSeven[countNext];
        Leftimg.sprite = Resources.Load<Sprite>("LeftImage/Mary" + LeftimgTestNext7[countNext].ToString()); //ステージによって変える部分
        Rightimg.sprite = Resources.Load<Sprite>("RightImage7/Fiona" + RightimgTextNext7[countNext].ToString()); //ステージによって変える部分
    }
    IEnumerator AlphaDown()//このCanvasを透過する（透過なのは、Objectfalseすると表示させるのが大変なため）
    {
        while (a.alpha >= 0)
        {
            a.alpha -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        yield break;
    }
    IEnumerator AlphaUp()//Canvasを表示する
    {
        while (alphaCount < 100)
        {
            alphaCount++;
            a.alpha += 0.01f;
            yield return new WaitForSeconds(0.3f);
        }
        yield break;
    }
}