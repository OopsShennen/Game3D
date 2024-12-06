using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class WalkSound : MonoBehaviour
{
    public AudioSource walk;
    public List<AudioClip> clips;
    public int pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Walk()
    {
        pos = (int)Mathf.Floor(Random.Range(0, clips.Count));
        walk.PlayOneShot(clips[pos]);
    }
}
