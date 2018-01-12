using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapRotate : MonoBehaviour
{
    public Transform Player;

	void LateUpdate()
    {
        Vector3 newPosition = Player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(90f, Player.eulerAngles.y, 0f);
    }

}
