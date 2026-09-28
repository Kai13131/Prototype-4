using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    bool lightIsOn = false;
    Light flashLight;

    public float battery = 100f;
    public float batteryDrain = 1f;

    public Slider batteryBar;

    public GameObject gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flashLight = GetComponent<Light>();

        batteryBar.maxValue = 100f;
        batteryBar.value = battery;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            lightIsOn = !lightIsOn;
            flashLight.enabled = lightIsOn;
        }

        if (lightIsOn)
        {
            battery -= batteryDrain * Time.deltaTime;
        }

        if (battery <= 0)
        {
            battery = 0;
            lightIsOn = false;
            flashLight.enabled = false;

            GameOverManager gameover = FindAnyObjectByType<GameOverManager>();
            gameover.GameOver();
        }

        batteryBar.value = battery;
    }

    public void AddBattery(float mount)
    {
        battery += mount;

        if(battery > 100)
        {
            battery = 100;
        }
    }


}
