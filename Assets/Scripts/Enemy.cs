using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap.Unity;

public class Enemy : MonoBehaviour
{
    public string[] textArray = new string[] { "石頭", "布", "剪刀" };
    public Text text;
    public Sprite[] sprites;
    public Image image;

    public int GetEnemyHand()
    {
        int value = Random.Range(0, 3);
        image.sprite = sprites[value];
        image.gameObject.SetActive(true);
        text.text = textArray[value];
        text.gameObject.SetActive(true);
        return value;
    }

    public void updateEnemyImg()
    {
        int value = Random.Range(0, 3);
        image.sprite = sprites[value];
        image.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        text.gameObject.SetActive(false);
        image.sprite = sprites[Random.Range(0, 3)];
    }

    // Update is called once per frame
    void Update() { }
}
