using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapManager : MonoBehaviour {
	
	public Terrain[] terrains;
	protected Terrain[,] grid;
	protected int gridWidth = 3;
	protected int gridHeight = 3;
	
	void Start () {
		grid = new Terrain[gridWidth,gridHeight];
	}
	
	void Update () {
		
	}
}
