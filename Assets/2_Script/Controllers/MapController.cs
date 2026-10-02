using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private RectTransform youIcon;
    [SerializeField] private RectTransform[] mapPoints;

    [SerializeField] private Transform xrPlayer;
    [SerializeField] private Transform mainCamera;




    public void MoveToPoint(int index)
    {
        youIcon.position =
            mapPoints[index].position;

        youIcon.rotation =
            mapPoints[index].rotation;
    }


    public void MoveToFinalPoint(Transform point)
    {
        xrPlayer.position = point.position;
        xrPlayer.rotation = point.rotation;
    }

    public void MoveToUnderDesk(Transform headPoint)
    {

        Vector3 offset = xrPlayer.position - mainCamera.position;

        xrPlayer.position = headPoint.position + offset;
        xrPlayer.rotation = headPoint.rotation;
    }
}
