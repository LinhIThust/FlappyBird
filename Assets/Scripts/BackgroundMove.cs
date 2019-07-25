using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMove : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveSpeed = 0;
    private GameObject obj;
    private GameObject gameController;
    private Vector3 fristPosition;
   void Awake()
    {
        Debug.Log("awake in background");
    }
    void Start()
    {

        obj = gameObject;        
        if (gameController == null)
        {
            gameController = GameObject.Find("GameController");
        }
        fristPosition = obj.transform.position;
    }

    private float setMoveSpeed()
    {
        if(gameController.GetComponent<GameController>().gameOver)
            return 0;
        return 2f;
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = setMoveSpeed();
        obj.transform.Translate(-1 * Time.deltaTime * moveSpeed, 0, 0);
        if(Vector3.Distance(fristPosition,obj.transform.position) > 50)
        {
            SceneManager.LoadScene(0); 
        }
       
    }
}
