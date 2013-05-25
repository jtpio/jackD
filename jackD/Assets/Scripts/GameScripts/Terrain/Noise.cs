using UnityEngine;
using System.Collections;

public class Noise : MonoBehaviour {
	
	Terrain terrain;
	public int offset = 5;
	
	void Start () {
		terrain = GetComponent<Terrain>();
		GenerateNoise(0);
		GenerateNoise(3);
	}
	
	void GenerateNoise(int tileSize) {
		float[,] heights = new float[terrain.terrainData.heightmapWidth, terrain.terrainData.heightmapHeight];
		for (int i = 0; i < terrain.terrainData.heightmapWidth; i++) {
			for (int j = 0; j < terrain.terrainData.heightmapHeight; j++) {
				
				int coeff = tileSize;
				if (i < offset || j < offset || i > terrain.terrainData.heightmapWidth - offset || j > terrain.terrainData.heightmapHeight - offset) {
					coeff = 0;	
				}
				heights[i, j] = Mathf.PerlinNoise(((float)i / (float)terrain.terrainData.heightmapWidth) * coeff, ((float)j / (float)terrain.terrainData.heightmapHeight) * coeff)/10.0f;
			}
		}
		terrain.terrainData.SetHeights(0, 0, heights);	
	}
	
	void Update () {

	}
	
	
}
