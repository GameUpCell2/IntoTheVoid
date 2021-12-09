using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPauseScript : MonoBehaviour
{

    public Image playPauseImage;
    public Sprite playSprite;
    public Sprite pauseSprite;
    private bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        updateImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void updateImage()
    {
        playPauseImage.sprite = isOn ? pauseSprite : playSprite;
        GameManager.Instance.IsPaused = isOn;
        Time.timeScale = isOn ? 0 : 1;
    }

    public void toggle()
    {
        isOn = !isOn;
        updateImage();
    }

}
