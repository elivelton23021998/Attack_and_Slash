using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeguirMouse : MonoBehaviour
{
     Text vidaInimigo;
    public LayerMask layers;
    // Start is called before the first frame update
    void Start()
    {
        vidaInimigo = GetComponent<Text>();
        vidaInimigo.text = "";
    }

    // Update is called once per frame
    void Update()
    {
    //    Vector3 mousePos = Input.mousePosition;
    //    transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        Ray raio = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(raio, out hit, 50, layers))//so vai colidir nas layerrs selecionadas
        {
            Inimigos inimigo = hit.transform.GetComponent<Inimigos>();

            if (inimigo)
            {
                // x = inimigo.x;
                vidaInimigo.text = inimigo.vida.ToString("00") + " / " + inimigo.limitedevidadonpc.ToString("00");
            }
            else
            {
                vidaInimigo.text = "";
            }
        }
    }
}
