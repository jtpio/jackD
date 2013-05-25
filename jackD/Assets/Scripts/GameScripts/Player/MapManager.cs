using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapManager : MonoBehaviour {
	
	// prefabs
	public Terrain terrain;
	public GameObject trigger;
	public Transform itemPrefab;
	
	public int spawnRate = 1; // over 1000
	
	protected Terrain[,] grid;
	
	protected float terrainSize;
	protected Vector2 nextBlock;
	
	void Start () {
		terrainSize = terrain.terrainData.size.x;
		
		grid = new Terrain[3,3];
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i,j] = (Terrain) Instantiate(terrain, new Vector3(i * terrainSize, 0, j * terrainSize), Quaternion.identity);
			}
		}
	}
	
	void Update () {
		
		// map generation
		Vector2 currInds = this.currentIndices();
		if ( currInds.x != 1 ) {
			this.Step( new Vector2(currInds.x,1));
		}
		if ( currInds.y != 1 ) {
			this.Step( new Vector2(1,currInds.y));
		}
		
		if (Random.Range (0,100) < spawnRate) {
			Vector3 playerPos = transform.position;
			for (int i = 0; i < 5; i++) {
				float posX = playerPos.x + Random.Range(-50, 50); 
				float posZ = playerPos.z + Random.Range(-50, 50);
				Vector3 posItem = new Vector3(posX, playerPos.y+2, posZ);
				Instantiate(itemPrefab, posItem, Quaternion.identity);
			}
			
		}
		
	}
	
	Vector2 currentIndices () {
		Vector3 playerPos = transform.position;
		float half = 0.5f*terrainSize;
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				Vector3 pos = grid[i,j].transform.position;
				if ( Mathf.Abs(pos.x + half - playerPos.x)<half && Mathf.Abs(pos.z + half -playerPos.z)<half ) {
					Vector2 rv = new Vector2(i,j);
					return rv;
				}
			}
		}
		
		return (new Vector2(1,1));
	}
	
	void Step(Vector2 center) {
		Terrain[,] newGrid = new Terrain[3,3];
		Vector2 diff = center + (new Vector2(2,2));
		
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				newGrid[i,j] = grid[(i+(int)diff.x)%3,(j+(int)diff.y)%3];
			}
		}
		
		// going up
		if (center.x == 1 && center.y == 2) {
			for (int i = 0; i < 3; i++) {
				TranslateTerrain(grid[i,0], 0, 0, 3*terrainSize);
			}
			grid = newGrid;
		} else if (center.x == 1 && center.y == 0) {
			// going dozn
			for (int i = 0; i < 3; i++) {
				TranslateTerrain(grid[i,2], 0, 0, -3*terrainSize);
			}
			grid = newGrid;
		} else if (center.x == 0 && center.y == 1) {
			// going left
			for (int i = 0; i < 3; i++) {
				TranslateTerrain(grid[2,i], -3*terrainSize, 0, 0);
			}
			grid = newGrid;
		} else if (center.x == 2 && center.y == 1) {
			//going right
			for (int i = 0; i < 3; i++) {
				TranslateTerrain(grid[0,i], 3*terrainSize, 0, 0);
			}
			grid = newGrid;
		} else {
			Debug.Log ("oh shit " + center);
		}
		
	}
	
	void TranslateTerrain(Terrain t, float dx, float dy, float dz) {
		Vector3 oldPos = t.transform.position;
		Vector3 newPos = new Vector3(oldPos.x + dx, oldPos.y + dy, oldPos.z + dz);
		t.transform.position = newPos;
	}
	
}
