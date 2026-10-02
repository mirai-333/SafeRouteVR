using UnityEngine;

public class NPCMove : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float speed = 2f;

    private int currentPoint = 0;
    private bool isMoving = false;

    private void Update()
    {
        if (!isMoving) return;

        if (currentPoint >= points.Length)
        {
            gameObject.SetActive(false);
            return;
        }

        transform.position =
            Vector3.MoveTowards(
                transform.position,
                points[currentPoint].position,
                speed * Time.deltaTime);

        if (Vector3.Distance(
            transform.position,
            points[currentPoint].position) < 0.1f)
        {
            currentPoint++;
        }
    }

    public void StartMove()
    {
        isMoving = true;
    }
}