using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour {
	
	public Terrain terrain;
	protected List<Terrain> blocks;
	
	void Start () {
		blocks  = new List<Terrain>();
		for (int i = 0; i < 5; i++) {
			//Terrain t = (Terrain) Instantiate(terrain, new Vector3(60, 0, 0), Quaternion.identity);	
		}
		Instantiate(terrain, new Vector3(60, 0, 0), Quaternion.identity);	
	}
	
	void Update () {
		
	}
}
