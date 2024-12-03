using UnityEngine;

public class Ship : MonoBehaviour
{

    [SerializeField] private float speedX;
    [SerializeField] private float resetXPosistion;

    private float shipWidth;

    private GameManager game;

    [SerializeField] int scoreAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game = FindObjectOfType<GameManager>();

        shipWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
  
        transform.position += new Vector3(speedX * Time.deltaTime, 0, 0);

        float sinY = Mathf.Sin(Time.time);  
        transform.position = new Vector3(transform.position.x, sinY, transform.position.z);

        if (transform.position.x + (shipWidth / 2f) < 0)
        {
            transform.position = new Vector3(resetXPosistion, transform.position.y, transform.position.z);

            game.AddScore(-scoreAmount);
        }
    }

    private void OnMouseDown()
    {
        transform.position = new Vector3(resetXPosistion, Random.Range(-5.0f, 0.0f), transform.position.z);

        game.AddScore(scoreAmount);
    }
}
