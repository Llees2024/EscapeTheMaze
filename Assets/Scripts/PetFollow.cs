using UnityEngine;

public class PetFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 3f;
    public float followDistance = 2f;

    private void Update()
    {
        Vector3 targetPosition = player.position;
        targetPosition.y = transform.position.y;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > followDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
