using UnityEngine;
using System.Collections;

public class NoiseTest : MonoBehaviour {
	
	Terrain terrain;
	public int offset = 128;
	public float t = 100f;
	
	void Start () {
		GenerateNoise(20);
	}
	
	public void GenerateNoise(int tileSize) {
		terrain = GetComponent<Terrain>();
		float[,] heights = new float[terrain.terrainData.heightmapWidth, terrain.terrainData.heightmapHeight];
		for (int i = 0; i < terrain.terrainData.heightmapWidth; i++) {
			for (int j = 0; j < terrain.terrainData.heightmapHeight; j++) {
				heights[i,j] = 
					0.50f +
					0.25f * Mathf.Sin(4 * Mathf.PI * i + 4 * t) * Mathf.Sin(2 * Mathf.PI * j + t) +
					0.10f * Mathf.Cos(3 * Mathf.PI * i + 5 * t) * Mathf.Cos(5 * Mathf.PI * j + 3 * t) +
					0.15f * Mathf.Sin(Mathf.PI * i + 0.6f * t);
			}
		}
		terrain.terrainData.SetHeights(0, 0, heights);	
	}
	
	
	
	void Update () {

	}

}
