using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap.Unity;

public class Player : MonoBehaviour
{
    public RigidFinger ring;
    public RigidFinger middle;
    public RigidFinger index;
    public Text text;
    public Sprite[] sprites;
    public Image image;
    
    public int GetPlayerHand()
    {
        if (
            middle.GetFingerJointStretchMecanim(1) > -50
            && ring.GetFingerJointStretchMecanim(1) > -50
        )
        {
            text.text = "布";
        }
        else if (
            middle.GetFingerJointStretchMecanim(1) > -50
            && index.GetFingerJointStretchMecanim(1) > -50
        )
        {
            text.text = "剪刀";
        }
        else
        {
            text.text = "石頭";
        }

        if (text.text == "石頭")
        {
            return 0;
        }
        if (text.text == "布")
        {
            return 1;
        }
        if (text.text == "剪刀")
        {
            return 2;
        }
        return 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (
            middle.GetFingerJointStretchMecanim(1) > -50
            && ring.GetFingerJointStretchMecanim(1) > -50
        )
        {
            image.sprite = sprites[1];
            image.gameObject.SetActive(true);
            text.text = "布";
        }
        else if (
            middle.GetFingerJointStretchMecanim(1) > -50
            && index.GetFingerJointStretchMecanim(1) > -50
        )
        {
            image.sprite = sprites[2];
            image.gameObject.SetActive(true);
            text.text = "剪刀";
        }
        else
        {
            image.sprite = sprites[0];
            image.gameObject.SetActive(true);
            text.text = "石頭";
        }
    }
}
