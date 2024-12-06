using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class EnemiScript : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;
    public QuestManager questManager;
    public AudioSource enemisound;
    public List<AudioClip> enemisoundClip;
    public void TakeDamage(int dame)
    {
        
        HP -= dame;
        if (HP <= 0)
        {
            questManager.questCount++;
            animator.SetTrigger("die");
            enemisound.PlayOneShot(enemisoundClip[1]);
            Destroy(gameObject, 5f);
            
            
            
        }
        else
        {
            animator.SetTrigger("damage");
            enemisound.PlayOneShot(enemisoundClip[0]);

        }
    }
}
