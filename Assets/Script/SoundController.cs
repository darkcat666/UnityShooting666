using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public AudioClip sound1;
    public AudioClip yamero_voice;
    AudioSource audioSource1;
    AudioSource audioSource2;

    void Start()
    {
        //Componentを取得
        audioSource1 = GetComponent<AudioSource>();
        audioSource2= GetComponent<AudioSource>();
    }

    void Update()
    {
        // 左
        if (Input.GetKey(KeyCode.Space))
        {
            //音(sound1)を鳴らす
            audioSource1.PlayOneShot(sound1);
        }
    }

    public void Yamero_screem()
    {
        //音(sound1)を鳴らす
        audioSource2.PlayOneShot(yamero_voice);
    }
}
