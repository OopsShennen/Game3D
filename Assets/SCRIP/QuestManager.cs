using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public int questCount = 0;
    public Text questText;
    private NPCScript npc;
    // Start is called before the first frame update
    void Start()
    {
        npc = FindObjectOfType<NPCScript>();
    }

    // Update is called once per frame
    void Update()
    {
        questText.text = "Kill:" + questCount.ToString()+ "/3";
       
        if(questCount == 3)
        {
            if (npc != null && npc.Quest != null)
            {
                npc.Quest.SetActive(false);
                npc.sounds.PlayOneShot(npc.npctalk[4]);
            }
        }
    }
}
