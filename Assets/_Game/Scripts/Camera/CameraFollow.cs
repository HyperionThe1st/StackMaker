using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private PlayerAction player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float camera_speed;
    [SerializeField] private GameObject playerObject;

    void LateUpdate()
    {
        CameraFollowPlayer();
    }

    void CameraFollowPlayer()
    {
        if (!player.IsCheering)
        {
            transform.position = playerObject.transform.position + offset;
        }
        else
        {
            offset = Vector3.Lerp(offset, offset + new Vector3(1, 0, 0), Time.deltaTime * 0.8f);
            transform.LookAt(playerObject.transform);
        }
    }
}
























//if (!player.IsCheering)
//{
//    Vector3 stackCountOffset = new Vector3(0, 0.2f, -0.1f) * player.PlayerStack.CollectedBrickCount;
//    transform.position = Vector3.Lerp(transform.position, player.transform.position + playingModeOffset + stackCountOffset, Time.fixedDeltaTime * camera_speed);
//} else
//{
//    //Quaternion rotTarget = Quaternion.LookRotation(player.transform.position - this.transform.position);
//    //this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, Time.fixedDeltaTime * camera_speed * 2);
//    //transform.position = Vector3.Lerp(transform.position, player.transform.position + winningOffset, Time.fixedDeltaTime * 2);

//    playingModeOffset = Vector3.Lerp(playingModeOffset,playingModeOffset+new Vector3(0,0,1), Time.fixedDeltaTime*0.8f);
//    transform.LookAt(playerObject.transform);
//}