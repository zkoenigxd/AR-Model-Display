using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BasicVideoPlayer : MonoBehaviour
{
    VideoPlayer videoPlayer;
    [SerializeField] RenderTexture videoTexture;
    [SerializeField] Texture2D playerTexture;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite playSprite;
    [SerializeField] Sprite pauseSprite;

    private void OnEnable()
    {
        if (playerTexture != null)
            this.gameObject.GetComponent<Renderer>().material.mainTexture = playerTexture;
        videoPlayer = GetComponent<VideoPlayer>();
        spriteRenderer.sprite = playSprite;
        videoPlayer.prepareCompleted += ConfigureTexture;
    }

    void ConfigureTexture(VideoPlayer vp)
    {
        vp.texture.wrapMode = TextureWrapMode.Mirror;
    }

    public void PlayOrPauseVideo()
    {
        if (videoPlayer != null)
        {
            if (videoTexture != null)
                this.gameObject.GetComponent<Renderer>().material.mainTexture = videoTexture;
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
