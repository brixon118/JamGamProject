using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float oscillationSpeed = 30f; // Speed of oscillation in degrees per second
    [SerializeField] private float oscillationAngle = 45f; // Maximum angle of oscillation

    [SerializeField] private bool Key;

    

    public void OnKeyIn()
    {
        print("KEY IN");
        Key = true;
    }

    public void OnKeyOut() 
    {
        print("KEY OUT");
        Key = false;
    }

    private void Update()
    {
        if (Key)
        {
            // Calculate the angle based on time and oscillation parameters
            float angle = Mathf.Sin(Time.time * oscillationSpeed * Mathf.Deg2Rad) * oscillationAngle;

            // Set the rotation of the turret
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
        
    }
}
