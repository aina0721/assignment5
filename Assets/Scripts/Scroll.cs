using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] float speed; // “®‚­‘¬‚³

    [SerializeField] float endPos;
    [SerializeField] float movePos;

    void Update()
    {
        transform.Translate(speed, 0, 0);

        if (transform.position.x > endPos)
        {
            transform.position = new Vector3(movePos, transform.position.y, 0);
        }
    }
}
