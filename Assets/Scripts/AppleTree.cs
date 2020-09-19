using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
	[Header("Set in inspector.")]
	// prefab for instantiating apples
	public GameObject	applePrefab;

	// speed at which AppleTree moves
	public float	speed = 1f;

	// Distance where AppleTree turns around 
	public float	leftandRightEdge = 10f;

	// chance that the AppleTree will change direction
	public float	chanceToChangeDirections = 0.1f;

	// rate at which Apple will be instantiated 
	public float	secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    // Dropping apples each second
    void Start()
    {
        //drop apples every second 
        Invoke("DropApple", 2f); 
    }

    void DropApple() {
    GameObject apple = Instantiate<GameObject>(applePrefab);
    apple.transform.position = transform.position;
    Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
    	// for basic movement
    	Vector3 pos = transform.position; 
    	pos.x += speed * Time.deltaTime;
    	transform.position = pos;

    	// for changing directions
        // for moving right
        if (pos.x < -leftandRightEdge){ 
            speed = Mathf.Abs(speed);
        // for moving left 
        } else if (pos.x > leftandRightEdge){ 
            speed = -Mathf.Abs(speed); 
        }
    }
    void fixedUpdate()
    {
        // changing direction randomly is now time-based because fixedUpdate
        // to randomly change direction
        if (Random.value < chanceToChangeDirections){
            speed *= -1;
        }
    }
}
