using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
       target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        var targetPos = target.position;
        if(targetPos.y <= 0)
        {
            targetPos = new Vector3(targetPos.x, 0f, -10f);
        }
        else
        {
            targetPos = new Vector3(targetPos.x, targetPos.y, -10f);
        }

        Camera.main.transform.position = targetPos;
    }
}
