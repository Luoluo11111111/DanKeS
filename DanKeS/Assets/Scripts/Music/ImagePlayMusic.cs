using UnityEngine;
using UnityEngine.UI;

public class ImagePlayMusic : MonoBehaviour
{
    //�洢�����ļ�
    public AudioClip musicClip;
    //��������
    private AudioSource audioSource;
    //���Image�Ƿ�ɼ�
    private CanvasRenderer canvasRenderer;

    
    void Start()
    {
        // ��ȡAudioSource��CanvasRenderer���
        audioSource = GetComponent<AudioSource>();
        canvasRenderer = GetComponent<CanvasRenderer>();
    }

    void Update()
    {
        // ���Image�Ƿ�ɼ�����Ⱦ����Ļ��
        // ����ɼ�������δ���ţ��򲥷�����
        if (canvasRenderer.cull == false && !audioSource.isPlaying)
        {
            PlayMusic();
        }
    }

    // ��������
    private void PlayMusic()
    {
        // ��������ļ���Ϊ���򲥷�����
        if (musicClip != null)
        {
            audioSource.clip = musicClip;
            audioSource.Play();
        }
    }
    //Image ����ʱֹͣ����
    void OnDisable()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}