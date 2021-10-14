using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    private void Start()
    {
        SetResolution1080();
    }

    private void Update()
    {
        //Debug.Log(Screen.currentResolution);
    }

    public void SetResolution1080()
    {
        Screen.SetResolution(1920, 1080, true);
        //Debug.Log("Yes");
    }

    public void SetResolution900()
    {
        Screen.SetResolution(1600, 900, true);
    }

    public void SetResolution720()
    {
        Screen.SetResolution(1280, 720, true);
    }
}
