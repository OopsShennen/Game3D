using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class DameZone : MonoBehaviour
{
    public Collider dameCollider;

    public int dame = 20;
    public string targetTag;
    public List<Collider> listDame = new List<Collider>();
    
    void Start()
    {
        dameCollider.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(targetTag) && !listDame.Contains(other))
        {
            listDame.Add(other);
            other.GetComponent<EnemiScript>().TakeDamage(dame);
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag) && !listDame.Contains(other))
        {
            listDame.Add(other);
            other.GetComponent<EnemiScript>().TakeDamage(dame);
        }
    }
    public void beginDame()
    {
        listDame.Clear();
        dameCollider.enabled=true;
    }
    public void endDame()
    {
        listDame.Clear();
        dameCollider.enabled = false;
    }
}
