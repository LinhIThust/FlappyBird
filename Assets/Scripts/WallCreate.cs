using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreate : MonoBehaviour
{
    // Start is called before the first frme update
    private float moveSpeed = 0;
    private float oldPosition = 4;
    private GameObject obj;
    private Vector3 fristPosition;
    private GameObject gameController;

    void Start()
    {
        obj = gameObject;
        fristPosition = obj.transform.position;
        if (gameController == null)
        {
            gameController = GameObject.Find("GameController");
        }
    }
    private float setMoveSpeed()
    {
        if (gameController.GetComponent<GameController>().gameOver)
            return 0;
        return 2f;
    }

    void Update()
    {
        moveSpeed = setMoveSpeed();
        obj.transform.Translate(-1 * Time.deltaTime * moveSpeed, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("WallReset"))
        {
            obj.transform.position = new Vector3(oldPosition, Random.Range(1, 4), 0);
        }
    }


}
