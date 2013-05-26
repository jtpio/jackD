using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapManager : MonoBehaviour {
	
	// prefabs
	public Terrain terrain;
	public Transform[] items;
	public Transform plant;
	
	public float itemRate = 1; // over 100
	public float plantRate = 1; // over 100
	
	protected Terrain[,] grid;
	
	protected float terrainSize;
	protected Vector2 nextBlock;
	
	void Awake() {
		terrainSize = terrain.terrainData.size.x;
		
		grid = new Terrain[3,3];
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i,j] = (Terrain) Instantiate(terrain, new Vector3(i * terrainSize, 0, j * terrainSize), Quaternion.identity);
			}
		}
	}
	
	void Start () {
		
	}
	
	void Update () {
		
		// map generation
		Vector2 currInds = this.currentIndices();
		if ( currInds.x != 1 ) {
			Step( new Vector2(currInds.x,1));
			Glue ();
		}
		if ( currInds.y != 1 ) {
			Step( new Vector2(1,currInds.y));
			Glue ();
		}
		
		if (Random.Range (0,100) < itemRate) {
			Spawn("item", 5);
		}
		
		if (Random.Range(0, 200) < plantRate) {
			Spawn("plant", 7);	
		}
	}
	
	void Spawn(string type, int nb) {
		Vector3 playerPos = transform.position;
		for (int i = 0; i < nb; i++) {
			float posX = playerPos.x + Random.Range(-50, 50); 
			float posZ = playerPos.z + Random.Range(-50, 50);
			Vector3 posItem = new Vector3(posX, playerPos.y+2, posZ);
			
			Vector3 direction = -Vector3.up;
			RaycastHit hit;
			if (Physics.Raycast(posItem, direction, out hit, 1000f)) {
				posItem = hit.point;
			}
			Vector3 newPos = new Vector3(posItem.x, posItem.y + 1, posItem.z);
			if (type.Equals("plant")) {
				Instantiate(plant, newPos, Quaternion.identity);
			} else {
				int prefab = (int)Random.Range(0, items.Length-1);
				Instantiate(items[prefab], newPos, Quaternion.identity);
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
	
	void Glue() {
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				Terrain t = grid[i,j];
				Terrain top = (i-1)>=0 ? grid[i-1,j]:null;
				Terrain bottom = (i+1)<3 ? grid[i+1,j]:null;
				Terrain left = (j-1)>=0 ? grid[i,j-1]:null;
				Terrain right = (j+1)<3 ? grid[i,j+1]:null;
				t.SetNeighbors(left, top, right, bottom);
			}
		}
	}
	
	void TranslateTerrain(Terrain t, float dx, float dy, float dz) {
		Vector3 oldPos = t.transform.position;
		Vector3 newPos = new Vector3(oldPos.x + dx, oldPos.y + dy, oldPos.z + dz);
		t.transform.position = newPos;
	}
	
}
