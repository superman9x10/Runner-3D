using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPooling : MonoBehaviour
{
    [SerializeField] Camera _camera;
    Transform mainPlayerPos;
    private void Update()
    {
        mainPlayerPos = _camera.GetComponent<CameraFollow>().getMainPlayerPos();
        if(mainPlayerPos != null)
        {
            transform.position = mainPlayerPos.position;
        }
    }
}
