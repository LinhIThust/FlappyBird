using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject obj;
    private GameObject gameController;
    public float power = 20f;
    private AudioSource audioSource;
    public AudioClip birdFly;
    public AudioClip birdDied;
    public List<Color> arrayColor;
    
    void Awake()
    {
        Debug.Log("Awakw in Bird");
    }
    void Start()
    {
        
        Color[] array = new Color[] { Color.black, Color.blue, Color.green,Color.grey,Color.red };
        arrayColor.AddRange(array);
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = birdFly;
      
        if (gameController == null)
        {
            gameController = GameObject.Find("GameController");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space)) && !gameController.GetComponent<GameController>().gameOver)
        {
            Debug.Log("xxxx");
            audioSource.Play();
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, power));
        }
        if(obj.transform.position.y > 6)
        {
            gameController.GetComponent<GameController>().gameOver = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.GetComponent<GameController>().updateScore();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.clip = birdDied;
        audioSource.Play();
        gameController.GetComponent<GameController>().birdDied();
        
    }
    public void changeColor(GameObject obj)
    {
        //obj.GetComponent<Renderer>().material
    }
}
