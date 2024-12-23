using UnityEngine;

public class FallingBlockTrigger : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    public float dropHeight = 10f;
    public float fallSpeed = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DropBlock();
        }
    }

    private void DropBlock()
    {
        GameObject block = Instantiate(fallingBlockPrefab, transform.position + Vector3.up * dropHeight, Quaternion.identity);
        Rigidbody rb = block.GetComponent<Rigidbody>();
        rb.velocity = Vector3.down * fallSpeed;
    }
}
