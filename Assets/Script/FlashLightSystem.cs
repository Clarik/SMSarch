using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    public BatteryBar bar;

    public Transform flashLight;
    private Vector2 zoom;
    public float zoomEachTick;
    public float maxZoom;

    Vector3 difference;
    float rotZ;

    public float maxBatteryTime;
    private float batteryTime;

    bool on;

    GameManager gm;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }
    private void Start()
    {
        zoom = flashLight.transform.localScale;
        on = false;
        batteryTime = maxBatteryTime;

        bar.SetMaxBattery(maxBatteryTime);

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }
    private void Update()
    {
        if(!gm.IsGamePause())
        {
            // No battery
            if (batteryTime <= 0f)
                on = false;

            // If FlashLight on mode
            if (on)
            {
                flashLight.gameObject.SetActive(true);
                difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                flashLight.rotation = Quaternion.Euler(0, 0, rotZ + 180f);

                if (Input.GetKey(KeyCode.Z))
                {
                    if (Input.GetMouseButton(0))
                    {
                        if (flashLight.transform.localScale.x < maxZoom)
                        {
                            zoom = new Vector2(flashLight.transform.localScale.x + zoomEachTick, flashLight.transform.localScale.y);
                            flashLight.transform.localScale = zoom;
                        }
                    }
                    else if (Input.GetMouseButton(1))
                    {
                        if (flashLight.transform.localScale.x > -maxZoom)
                        {
                            zoom = new Vector2(flashLight.transform.localScale.x - zoomEachTick, flashLight.transform.localScale.y);
                            flashLight.transform.localScale = zoom;
                        }
                    }
                }
                else if (Input.GetMouseButtonDown(0))
                    on = !on;
                batteryTime -= Time.deltaTime;
            }
            // FlashLight off
            else if (on == false)
            {
                if (batteryTime < maxBatteryTime)
                    batteryTime += Time.deltaTime * Random.value;
                else
                    batteryTime = maxBatteryTime;
                flashLight.gameObject.SetActive(false);
                if (Input.GetMouseButtonDown(0))
                    on = !on;
            }

            bar.SetBattery(batteryTime);
        }
    }
}
