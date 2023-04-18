using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BasicVideoPlayer : MonoBehaviour
{
    VideoPlayer videoPlayer;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite playSprite;
    [SerializeField] Sprite pauseSprite;

    private void OnEnable()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        spriteRenderer.sprite = playSprite;
    }

    public void PlayOrPauseVideo()
    {
        if (videoPlayer != null)
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
                spriteRenderer.sprite = playSprite;
            }
            else
            {
                videoPlayer.Play();
                spriteRenderer.sprite = pauseSprite;
            }

        }
    }
}
