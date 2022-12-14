using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] Vector3 offSet;
    [Range(0.01f, 1f)][SerializeField] private float cameraSpeed;
    private Vector3 currentVelocity = Vector3.zero;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + offSet, ref currentVelocity, cameraSpeed);
    }


}
