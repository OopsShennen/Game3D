using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class NPCScript : MonoBehaviour
{
    public GameObject NPCPanel;
    public TextMeshProUGUI NPCContent;
    public string[] content;
    public GameObject ActiveContent;
    public GameObject Quest;
    private Coroutine coroutine;
    public List<AudioClip> npctalk;
    public AudioSource sounds;
    void Start()
    {
        ActiveContent.SetActive(false);
        NPCPanel.SetActive(false);
        Quest.SetActive(false);
        NPCContent.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NPCPanel.SetActive(true);
            sounds.PlayOneShot(npctalk[1]);
            coroutine = StartCoroutine(ReadContent());
            

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NPCPanel.SetActive(false);
            StopCoroutine(coroutine);
        }
    }
    public IEnumerator ReadContent() 
    {
        foreach (var line in content)
        {
            NPCContent.text = "";
            foreach (var item in line)
            {
                NPCContent.text += item;
                yield return new WaitForSeconds(0.1f);
                
            }
            yield return new WaitForSeconds(0.1f);
        }
        ActiveContent.SetActive(true);
    }
    public void endContent() 
    {
        NPCPanel.SetActive(false);
        StopCoroutine(coroutine);
    }
    public void KillMonster()
    {
        
        NPCPanel.SetActive(false);
        Quest.SetActive(true);
        ActiveContent.SetActive(false);
        sounds.PlayOneShot(npctalk[2]);
        if (sounds != null)
        {
            sounds.PlayOneShot(npctalk[3]);
        }

    }

}
