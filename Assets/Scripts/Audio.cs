using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource audioSource;

    // ���������� ��� ������� �������
    void Start()
    {
        // �������� ��������� AudioSource
        audioSource = GetComponent<AudioSource>();
        // ������������� ������
        PlayMusic();
    }

    // ����� ��� ��������������� ������
    void PlayMusic()
    {
        // ���������, �� ��������������� �� ��� ������
        if (!audioSource.isPlaying)
        {
            // ������������� ����������� ���������������
            audioSource.loop = true;
            // ��������� ��������������� ������
            audioSource.Play();
        }
    }
}
