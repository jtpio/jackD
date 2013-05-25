using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapManager : MonoBehaviour {
	
	// prefabs
	public Terrain terrain;
	public GameObject trigger;
	
	protected Terrain[,] grid;
	
	protected float terrainSize;
	
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
	}
	
	void OnTriggerEnter(Collider other) {
		GameObject box = other.gameObject;
		GameObject parent = box.transform.parent.gameObject;
		Vector2 pos = GetBoxPos(parent);
		Debug.Log ("Triggered object at " + pos);
		Step(pos);
	}
	
	void Step(Vector2 center) {
	
		Terrain[,] newGrid = new Terrain[3,3];
		
		// going up
		if (center.x == 1 && center.y == 2) {
			for (int i = 0; i < 3; i++) {
				TranslateTerrain(grid[i,0], 0, 0, 3*terrainSize);
			}
			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 3; j++) {
					newGrid[i,j] = grid[i,(j+1)%3];
				}
			}
			grid = newGrid;
		} else if (center.x == 1 && center.y == 0) {
			// going dozn
			for (int i = 0; i < 3; i++) {
				TranslateTerrain(grid[i,2], 0, 0, -3*terrainSize);
			}
			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 3; j++) {
					newGrid[i,j] = grid[i,(j+2)%3];
				}
			}
			grid = newGrid;
		} else if (center.x == 0 && center.y == 1) {
			// going left
			for (int i = 0; i < 3; i++) {
				TranslateTerrain(grid[2,i], -3*terrainSize, 0, 0);
			}
			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 3; j++) {
					newGrid[i,j] = grid[(i+2)%3,j];
				}
			}
			grid = newGrid;
		} else if (center.x == 2 && center.y == 1) {
			//going right
			for (int i = 0; i < 3; i++) {
				TranslateTerrain(grid[0,i], 3*terrainSize, 0, 0);
			}
			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 3; j++) {
					newGrid[i,j] = grid[(i+1)%3,j];
				}
			}
			grid = newGrid;
		}
	}
	
	void TranslateTerrain(Terrain t, float dx, float dy, float dz) {
		Vector3 oldPos = t.transform.position;
		Vector3 newPos = new Vector3(oldPos.x + dx, oldPos.y + dy, oldPos.z + dz);
		t.transform.position = newPos;
	}
	
	Vector2 GetBoxPos(GameObject obj) {
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				if (grid[i,j].transform.gameObject.GetInstanceID() ==  obj.GetInstanceID()) return (new Vector2(i,j));
			}
		}
		return (new Vector2(-1,-1));
	}
}
