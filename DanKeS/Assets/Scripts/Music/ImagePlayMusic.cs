using UnityEngine;
using UnityEngine.UI;

public class ImagePlayMusic : MonoBehaviour
{
    //存储音乐文件
    public AudioClip musicClip;
    //播放音乐
    private AudioSource audioSource;
    //检测Image是否可见
    private CanvasRenderer canvasRenderer;

    
    void Start()
    {
        // 获取AudioSource和CanvasRenderer组件
        audioSource = GetComponent<AudioSource>();
        canvasRenderer = GetComponent<CanvasRenderer>();
    }

    void Update()
    {
        // 检测Image是否可见（渲染到屏幕）
        // 如果可见且音乐未播放，则播放音乐
        if (canvasRenderer.cull == false && !audioSource.isPlaying)
        {
            PlayMusic();
        }
    }

    // 播放音乐
    private void PlayMusic()
    {
        // 如果音乐文件不为空则播放音乐
        if (musicClip != null)
        {
            audioSource.clip = musicClip;
            audioSource.Play();
        }
    }
    //Image 隐藏时停止音乐
    void OnDisable()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}