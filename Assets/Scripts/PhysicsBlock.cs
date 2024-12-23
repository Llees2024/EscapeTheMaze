using UnityEngine;

public class PushableBlock : MonoBehaviour
{
    public float pushForce = 10f;
    private Rigidbody rb;
    private bool isPushed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isPushed)
        {
            Vector3 pushDirection = collision.transform.forward;
            rb.AddForce(pushDirection * pushForce, ForceMode.Force);
            isPushed = true;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
