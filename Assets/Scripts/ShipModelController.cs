using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModelController : MonoBehaviour
{   
    public static ShipModelController instance;
    public Spaceship[] shipModels;
    
    void Start()
    {
        if (instance != null)
		{
			Destroy(gameObject);
		} else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Spaceship s in shipModels)
		{
			// Change ships color to defined color on instatiation
            Renderer shipRenderer = s.shipPrefab.GetComponent<Renderer>();
            shipRenderer.material.SetColor("_Color", s.shipColor); 
		}
    }

}
