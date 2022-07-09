using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform targetPlayer;
    Vector3 targetOffset;

    private void Awake()
    {
        targetOffset = transform.position - targetPlayer.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetPlayer.position + targetOffset, 0.125f);
    }


}
