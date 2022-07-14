using System;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform[] positionsForCamera;
    [SerializeField] private GameObject[] players;

    private float[] distanceToPositionForCamera;

    private void Start()
    {
        distanceToPositionForCamera = new float[positionsForCamera.Length];

        SetCameraPosition();
    }

    private void Update()
    {
        SetCameraPosition();
    }

    private void SetCameraPosition()
    {
        float minDistance = 100f;

        for (int i = 0; i < positionsForCamera.Length; i++)
            distanceToPositionForCamera[i] = CalculateDistanceBetweenPlayerAndCameras(i, GetTarget());

        int actualMinDistanceIndex = SetMinDistanceIndex(minDistance);

        transform.position = positionsForCamera[actualMinDistanceIndex].position;
    }

    private float CalculateDistanceBetweenPlayerAndCameras(int cameraIndex, Transform target)
    {
        return (float)Math.Round(Vector2.Distance(positionsForCamera[cameraIndex].position, target.position), 3);
    }

    private int SetMinDistanceIndex(float minDistance)
    {
        int actualMinDistanceIndex = 0;

        for (int i = 0; i < distanceToPositionForCamera.Length; i++)
        {
            if (distanceToPositionForCamera[i] < minDistance)
            {
                minDistance = distanceToPositionForCamera[i];
                actualMinDistanceIndex = i;
            }
        }

        return actualMinDistanceIndex;
    }

    private Transform GetTarget()
    {
        GameObject target = null;

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].activeInHierarchy)
            {
                target = players[i];
                break;
            }
        }

        return target.transform;
    }
}
