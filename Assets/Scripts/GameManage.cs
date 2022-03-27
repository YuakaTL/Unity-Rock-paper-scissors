using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    public Text text;
    public Image enemyImg;
    public AudioClip winSound;
    public AudioClip loseSound;
    private AudioSource myAudioSource;

    //Detect when you use the toggle, ensures music isn’t played multiple times
    int count = 4;

    void GameStart()
    {
        text.text = "Ready !";
        count = 4;
        Invoke("CountDown", 1);
    }

    void CountDown()
    {
        if (count == 1)
        {
            text.text = CheckWinner();
            Invoke("GameStart", 3);
        }
        else
        {
            count -= 1;
            text.text = count.ToString();
            Invoke("CountDown", 1);
            gameObject.GetComponent<Enemy>().updateEnemyImg();
        }
    }

    string CheckWinner()
    {
        // 0 是石頭
        // 1 是布
        // 2 是剪刀
        int player = gameObject.GetComponent<Player>().GetPlayerHand();
        int enemy = gameObject.GetComponent<Enemy>().GetEnemyHand();
        switch (player - enemy)
        {
            case 1:
            case -2:
                myAudioSource.clip = winSound;
                myAudioSource.Play();
                return "You Win!";
            case 0:
                return "Tie";
            default:
                myAudioSource.clip = loseSound;
                myAudioSource.Play();
                return "You Lose QQ";
        }
    }

    void Awake()
    {
        Time.timeScale = 0f;
        myAudioSource = gameObject.AddComponent<AudioSource>();
        myAudioSource.playOnAwake = false;
    }

    void Start()
    {
        text.text = "按空格開始遊戲\n P 暫停遊戲 \n Esc 結束遊戲";
        Invoke("GameStart", 2);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            text.text = "暫停\n 空格開始遊戲 \n Esc 結束遊戲";
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
