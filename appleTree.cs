using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // Start is called before the first frame update
    public GameObject applePrefab; // apple prefab

    public float speed = 20f; // speed of tree

    public float leftAndRightEdge = 20f; // distance before turning

    public float changeDirChance = .005f;

    public float appleDropDelay = .7f;

    void Start()
    {
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        // basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }

    }

    private void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1; // change direction
        }

    }

    void DropApple()
    { 
        GameObject apple = Instantiate<GameObject>(applePrefab);

        apple.transform.position = transform.position;

        Invoke("DropApple", appleDropDelay);
    }
}
