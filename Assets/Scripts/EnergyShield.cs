using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnergyShield : MonoBehaviour
{
    [SerializeField] private Text _scoreGT;



    private void Start()
    {
        scoreText();
    }
    private void Update()
    {
        moveMouse();



    }
    private void scoreText()
    {
        GameObject scoreGO = GameObject.Find("Score");
        _scoreGT = scoreGO.GetComponent<Text>();
        _scoreGT.text = "0";
    }

    private void moveMouse()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }
    private void OnCollisionEnter(Collision coll)
    {
        
        GameObject collided = coll.gameObject;
        if(collided.tag == "DragonEgg")
        {
          
            Destroy(collided);
        }
        int score = int.Parse(_scoreGT.text);
        score++;
        _scoreGT.text = score.ToString();



    }
}
