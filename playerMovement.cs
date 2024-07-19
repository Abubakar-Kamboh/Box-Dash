using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody PlayerRb;
    
    public AudioSource jumpAudioSource;
    public float Force = 10f;
    public float RotationForce = 1.1f;
    public bool IsGround = false;
    public GameObject ObstacleSpawner;
    public GameObject PlayerParticleSystem;
    public Text ScoreText;
    public Text HighScoreText;
    public int score = 0;
    static int HighScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        // PlayerRb = GetComponent<Rigidbody>();
        //ObstacleSpawner = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && IsGround==true)
        {
            PlayerRb.AddForce(Vector3.up * Force, ForceMode.Impulse);
            PlayerRb.AddTorque(new Vector3(0,0,-1) *RotationForce , ForceMode.Impulse);
           PlayerParticleSystem.SetActive(false);
            IsGround = false;
            jumpAudioSource.Play();
        }
        
        ScoreText.text = "Score \n " + score.ToString();
        if(score>HighScore)
        {
            HighScore=score;
           
        }
        HighScoreText.text = "HighScore : " + HighScore.ToString();


    }
    private void OnTriggerEnter(Collider collision)
    {
        
        if(collision.gameObject.CompareTag("obstacle"))
        {

            Destroy(gameObject);
            
            Destroy(ObstacleSpawner);
        }
        if (collision.gameObject.CompareTag("Point"))
        {
            score = score + 25;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsGround = true;
            PlayerParticleSystem.SetActive(true);

        }
        else
        {
            IsGround = false;
            PlayerParticleSystem.SetActive(false);
        }

    }

}
