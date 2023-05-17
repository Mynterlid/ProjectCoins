using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private Transform player;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = player.transform.position.x;
        temp.y = player.transform.position.y;

        transform.position = temp;
    }
}
