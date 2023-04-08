using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Instantiate : MonoBehaviour
{
    [Header("Player")]

    public Transform player;
    public GameObject veloz, forte, suport;

    [Header("Inimigos")]
    public Transform inimigo;
    public GameObject[] IAs;//IaVeloz, IaForte, IaSuport;


    [Header("Globais")]
    float tempo = 3, respawn = 3;
    public Text relogio;

    // Start is called before the first frame update
    void Start()
    {
       // GameObject copia = GameObject.Instantiate(projetil, pontaArma, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        relogio.text = tempo.ToString("00");


        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Game");
        }

        tempo -= Time.deltaTime;

        if (tempo < 0) tempo = 0;

        ////////////////////////////////////////////////////////////            Player        ////////////////////////////////////////////////////


        if (tempo <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                GameObject copia = GameObject.Instantiate(veloz, player.position, Quaternion.identity);
                tempo = 10;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                GameObject copia = GameObject.Instantiate(forte, player.position, Quaternion.identity);
                tempo = 10;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                GameObject copia = GameObject.Instantiate(suport, player.position, Quaternion.identity);
                tempo = 10;
            }
        }


        ////////////////////////////////////////////////////////////            Inimigo        ////////////////////////////////////////////////////

        respawn -= Time.deltaTime;
        if (respawn <= 0)
        {
            GameObject copia = GameObject.Instantiate(IAs[Random.Range(0,2)], inimigo.position, Quaternion.identity);
            respawn = Random.Range(8, 15);
        }
    }
}
