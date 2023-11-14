using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportOnTrigger : MonoBehaviour
{
    public LayerMask obstacleLayer; // LayerMask for obstacles (e.g., walls)
    public float detectionRange = 5f; // Detection range for the script
    [Range(1, 180)]
    public float detectionAngle = 45f; // Detection angle for the script (limited to 1-180 degrees)
    public float detectionRotationAngle = 0f; // Rotation angle for the detection rays (in degrees)
    [SerializeField] Vector3 placeToTeleportTo = Vector3.zero;
    [SerializeField] string mainMenuSceneName = "MainMenu";
    [SerializeField] GameObject gameOverScreen;

    private void Start()
    {
        SetGameOverScreenActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void Retry()
    {
        TimeToggle();
        SetGameOverScreenActive(false);
    }

    public void TimeToggle()
    {
        Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
    }

    private void SetGameOverScreenActive(bool active)
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(active);
        }
    }

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Vector3 forwardDirection = Quaternion.Euler(0, 0, detectionRotationAngle) * transform.right;
            Vector3 directionToPlayer = player.transform.position - transform.position;
            Quaternion rotationToPlayer = Quaternion.FromToRotation(forwardDirection, directionToPlayer);

            if (Quaternion.Angle(transform.rotation, rotationToPlayer) <= detectionAngle * 0.5f && directionToPlayer.magnitude <= detectionRange)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer.normalized, detectionRange, obstacleLayer);

                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    // Teleport the object to a new position
                    transform.position = placeToTeleportTo;

                    // Activate the Game Over screen and toggle time
                    SetGameOverScreenActive(true);
                    TimeToggle();

                    Debug.Log("Player detected within triangular area. Teleporting...");
                }
                else if (hit.collider != null)
                {
                    Debug.Log("Obstacle detected: " + hit.collider.gameObject.name);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 forwardDirection = Quaternion.Euler(0, 0, detectionRotationAngle) * transform.right;
        Quaternion leftRayRotation = Quaternion.AngleAxis(-detectionAngle * 0.5f, transform.forward) * Quaternion.Euler(0, 0, detectionRotationAngle);
        Quaternion rightRayRotation = Quaternion.AngleAxis(detectionAngle * 0.5f, transform.forward) * Quaternion.Euler(0, 0, detectionRotationAngle);

        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, transform.position + leftRayRotation * forwardDirection * detectionRange);
        Gizmos.DrawLine(transform.position, transform.position + rightRayRotation * forwardDirection * detectionRange);
        Gizmos.DrawLine(transform.position + leftRayRotation * forwardDirection * detectionRange, transform.position + rightRayRotation * forwardDirection * detectionRange);
    }
}
