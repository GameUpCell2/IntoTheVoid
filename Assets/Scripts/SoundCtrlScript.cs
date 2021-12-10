using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundCtrlScript : MonoBehaviour
{

    public Image soundImage;
    public Sprite isMutedSprite;
    public Sprite isNotMutedSprite;
    private bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        isOn = PlayerPrefs.GetInt("IsMute") == 1;
        updateImage();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void updateImage()
    {
        soundImage.sprite = isOn ? isNotMutedSprite : isMutedSprite;
        GameManager.Instance.IsMute = isOn;
        PlayerPrefs.SetInt("IsMute", isOn? 0: 1);
    }

    public void toggle()
    {
        isOn = !isOn;
        updateImage();
    }

}
