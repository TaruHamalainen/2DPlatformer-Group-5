using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHandRotator : MonoBehaviour
{
    [SerializeField] private Transform arm;
    [SerializeField] private float rotationAngle = 90f;



    private void Update()
    {


        Vector3 pos = Camera.main.WorldToScreenPoint(arm.transform.position);
        Vector3 dir = Input.mousePosition - pos + new Vector3(0, 0, 90);
        float angle = Mathf.Atan2(dir.y * transform.localScale.x, dir.x * transform.localScale.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -rotationAngle, rotationAngle);
        arm.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);




    }
}
