using UnityEngine;
using System.Collections;

public class Noise : MonoBehaviour {
	
	Terrain terrain;
	public int offset = 5;
	
	void Start () {
		terrain = GetComponent<Terrain>();
		GenerateNoise(0);
		GenerateNoise(1);
		ProceduralTextures();
	}
	
	void GenerateNoise(int tileSize) {
		float[,] heights = new float[terrain.terrainData.heightmapWidth, terrain.terrainData.heightmapHeight];
		for (int i = 0; i < terrain.terrainData.heightmapWidth; i++) {
			for (int j = 0; j < terrain.terrainData.heightmapHeight; j++) {
				heights[i,j] = Mathf.PerlinNoise((float)i/(float)terrain.terrainData.heightmapWidth, (float)j/(float)terrain.terrainData.heightmapHeight) / 3.0f;
			}
		}
		terrain.terrainData.SetHeights(0,0, heights);	
	}
	
	void ProceduralTextures() {
		
		float[, ,] splatmapData = new float[terrain.terrainData.alphamapWidth, terrain.terrainData.alphamapHeight, terrain.terrainData.alphamapLayers];
		
		for (int y = 0; y < terrain.terrainData.alphamapHeight; y++) {
			for (int x = 0; x < terrain.terrainData.alphamapWidth; x++) {
				float height = terrain.terrainData.GetHeight(x,y);

				Vector3 splat = new Vector3(0,1,0);
				if (height < 0.9) {
					splat = Vector3.Lerp(splat, new Vector3(0,0,1), (height-0.5f)*2 );
				} else {
					splat = Vector3.Lerp(splat, new Vector3(1,0,0), height*2 );
				}
				
				splat.Normalize();
				splatmapData[x, y, 0] = splat.x;
				splatmapData[x, y, 1] = splat.y;
				splatmapData[x, y, 2] = splat.z;
			}
		}
		terrain.terrainData.SetAlphamaps(0, 0, splatmapData);
	}
	
	void Update () {

	}

}
