using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Transform transform;
    public float speed = 5f;
    public Score_Manenger scoreValue;
    public float rotationspeed = 5f;
    public GameObject gameOverPanel;

    // Novo: sensibilidade do acelerômetro
    public float tiltSensitivity = 3f;

    public GameObject gamePausePanel;

    void Start()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        Movement();
        Clamp();
    }

    void Movement()
    {
        // Pega o valor do acelerômetro no eixo x
        float tilt = Input.acceleration.x * tiltSensitivity;

        // Movimento por teclado (mantido para testes no editor)
        if (Input.GetKey(KeyCode.RightArrow) || tilt > 0.1f)
        {
            float moveAmount = Input.GetKey(KeyCode.RightArrow) ? 1 : tilt;
            transform.position += new Vector3(speed * moveAmount * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation,
                                               Quaternion.Euler(0, 0, -47),
                                               rotationspeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || tilt < -0.1f)
        {
            float moveAmount = Input.GetKey(KeyCode.LeftArrow) ? 1 : -tilt;
            transform.position -= new Vector3(speed * moveAmount * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation,
                                               Quaternion.Euler(0, 0, 47),
                                               rotationspeed * Time.deltaTime);
        }

        if (transform.rotation.z != 90)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,
                                               Quaternion.Euler(0, 0, 0),
                                               10f * Time.deltaTime);
        }
    }

    void Clamp()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -1.8f, 1.8f);
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cars"))
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            gamePausePanel.SetActive(false);

        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            scoreValue.score += 10;
            Destroy(collision.gameObject);
        }
    }
}

