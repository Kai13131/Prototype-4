using UnityEngine;

public class BatteryAdd : MonoBehaviour
{
    public float batteryAmout = 25f;

    private void OnTriggerEnter(Collider other)
    {
        FlashLight flashLight = other.GetComponentInChildren<FlashLight>();

        if(flashLight != null)
        {
            flashLight.AddBattery(batteryAmout);
            Destroy(gameObject);
        }
    }
}
