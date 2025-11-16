using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int correctNum;

    [SerializeField] Text fText; // ふりがな用のテキスト
    [SerializeField] Text qText; // 問題用のテキスト
    [SerializeField] Text aText; // 答え用のテキスト

    private string[] _furigana = {"さーもん", "あかえび", "にあなご", "うなぎのかばやき", "かずのこ",
                                  "あぶりかきばたーしょうゆ", "おおつぶがい", "ねぎまぐろぐんかん",
                                  "こつぶなっとうまき", "えびふらいあぼかどろーる"};
    private string[] _question = {"サーモン", "赤えび", "煮あなご", "うなぎの蒲焼き", "数の子",
                                  "炙り牡蠣バター醤油", "大つぶ貝", "ねぎまぐろ軍艦",
                                  "小粒納豆巻", "海老フライアボカドロール"};
    private string[] _answer = {"sa-monn", "akaebi","nianago", "unaginokabayaki", "kazunoko",
                                "aburikakibata-syouyu", "ootubugai", "negimagurogunnkann",
                                "kotubunattoumaki", "ebihuraiabokadoro-ru"};

    private string _fString;
    private string _qString;
    private string _aString;

    private int _qNum;

    private int _aNum;

    void Start()
    {
        OutPut();
    }

    void Update()
    {
        if (Input.GetKeyDown(_aString[_aNum].ToString()))
        {
            Correct();

            if (_aNum >= _aString.Length)
            {
                OutPut();
                correctNum++;
            }
        }
        else if (Input.anyKeyDown)
        {
            Miss();
        }

        if (correctNum >= 5)
        {
            SceneManager.LoadScene("GameClear");
        }
    }

    // 問題を出す
    void OutPut()
    {
        _aNum = 0;

        _qNum = Random.Range(0, _question.Length);

        _fString = _furigana[_qNum];
        _qString = _question[_qNum];
        _aString = _answer[_qNum];

        // 文字を変更する
        fText.text = _fString;
        qText.text = _qString;
        aText.text = _aString;
    }

    // 正解したとき
    void Correct()
    {
        _aNum++;
        aText.text = "<color=#6A6A6A>" + _aString.Substring(0, _aNum) + "</color>" + _aString.Substring(_aNum);
        Debug.Log("_aNum");
    }

    // 間違えたとき
    void Miss()
    {
        aText.text = "<color=#6A6A6A>" + _aString.Substring(0, _aNum) + "</color>"
            + "<color=#FF0000>" + _aString.Substring(_aNum, 1) + "</color>"
            + _aString.Substring(_aNum + 1);
    }
}
