using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonPicker : MonoBehaviour
{
    public GameObject EnergyShieldPrefab;

    [SerializeField] private int _numEnergyShield = 3;
    [SerializeField] private float _energyShieldButtomY = -6.0f;
    [SerializeField] private float _energyShieldRadius = 1.5f;

    [SerializeField] private List<GameObject> _basketList;



    private void Start()
    {
        spawnPrefab();


    }
    private void spawnPrefab()
    {
        _basketList = new List<GameObject>();
        for (int i = 1; i <= _numEnergyShield; i++)
        {
            GameObject tBasketGo = Instantiate<GameObject>(EnergyShieldPrefab);
            tBasketGo.transform.position = new Vector3(0, _energyShieldButtomY, 0);
            tBasketGo.transform.localScale = new Vector3(1 * i, 1 * i, 1 * i);


            _basketList.Add(tBasketGo);
        }
    }
    public void DragonEggDestroyed()
    {
        GameObject[] tDragonEggArray = GameObject.FindGameObjectsWithTag("DragonEgg");
        foreach(GameObject tGo in tDragonEggArray)
        {
            Destroy(tGo);
        }

        int basketIndex = _basketList.Count - 1;
        GameObject tBasketGo = _basketList[basketIndex];
        _basketList.RemoveAt(basketIndex);
        Destroy(tBasketGo); 
        if(_basketList.Count == 0)
        {
            SceneManager.LoadScene("_0Scene");
        }
    }
  
  
}
