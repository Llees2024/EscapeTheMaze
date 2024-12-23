using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject blueCubePrefab;
    public float shootCooldown = 1f;
    private float timeSinceLastShot = 0f;

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= shootCooldown && Input.GetMouseButtonDown(0)) // Left click to shoot
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    ShootBlueCube(); // Shoot towards the clicked enemy
                    timeSinceLastShot = 0f; // Reset cooldown after shooting
                }
            }
        }
    }

    void ShootBlueCube()
    {
        // Spawn the blue cube in front of the player
        GameObject blueCube = Instantiate(blueCubePrefab, transform.position + transform.forward, Quaternion.identity);
        Rigidbody rb = blueCube.GetComponent<Rigidbody>();

        // Apply velocity to shoot the cube in the direction the player is facing
        rb.velocity = transform.forward * 10f; // Adjust the speed as needed
    }
}
