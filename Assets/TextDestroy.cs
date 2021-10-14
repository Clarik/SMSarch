using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDestroy : MonoBehaviour
{
    public float time;

    private void Start()
    {
        StartCoroutine(TimeToDestroy());
    }

    IEnumerator TimeToDestroy()
    {
        yield return new WaitForSeconds(time);
        destroyText();
    }

    public void destroyText()
    {
        Destroy(this.gameObject);
    }
}
