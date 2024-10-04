using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource music;

    [Header("Audio Clip")]
    public AudioClip background;


    public static AudioManager instance;



    private void Awake()
    {

        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        music.clip = background;
        music.Play();
    }

   
}
