using UnityEngine;
using System.Collections;

public class Noise : MonoBehaviour {
	
	Terrain terrain;
	
	void Start () {
		terrain = GetComponent<Terrain>();
		float[,] heights = new float[terrain.terrainData.heightmapWidth, terrain.terrainData.heightmapHeight];
		terrain.terrainData.SetHeights(0, 0, heights);
		GenerateNoise(5);
	}
	
	void GenerateNoise(int tileSize) {
		float[,] heights = new float[terrain.terrainData.heightmapWidth, terrain.terrainData.heightmapHeight];
		for (int i = 0; i < terrain.terrainData.heightmapWidth; i++) {
			for (int j = 0; j < terrain.terrainData.heightmapHeight; j++) {
				heights[i, j] = Mathf.PerlinNoise(((float)i / (float)terrain.terrainData.heightmapWidth) * tileSize, ((float)j / (float)terrain.terrainData.heightmapHeight) * tileSize)/10.0f;
			}
		}
		terrain.terrainData.SetHeights(0, 0, heights);	
	}
	
	void Update () {

	}
}
