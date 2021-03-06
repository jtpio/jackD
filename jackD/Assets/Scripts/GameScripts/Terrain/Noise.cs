using UnityEngine;
using System.Collections;

public class Noise : MonoBehaviour {
	
	Terrain terrain;
	public int offset = 5;
	
	void Start () {
	}
	
	public void GenerateNoise(int tileSize) {
		terrain = GetComponent<Terrain>();
		float[,] heights = new float[terrain.terrainData.heightmapWidth, terrain.terrainData.heightmapHeight];
		for (int i = 0; i < terrain.terrainData.heightmapWidth; i++) {
			for (int j = 0; j < terrain.terrainData.heightmapHeight; j++) {
				heights[i,j] = 
					Mathf.PerlinNoise(
						(float)(i)/(float)terrain.terrainData.heightmapWidth * tileSize, 
						(float)(j)/(float)terrain.terrainData.heightmapHeight * tileSize
					) / 3.0f;
			}
		}
		terrain.terrainData.SetHeights(0,0, heights);	
	}
	
	void Update () {

	}

}
