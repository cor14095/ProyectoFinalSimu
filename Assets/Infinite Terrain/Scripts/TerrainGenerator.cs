using System;
using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// This is a procedural terrain generator that will create infinite sized terrains based
/// on Simplex Noise. (A slightly faster than perlin implementation of coherent noise).
/// It uses a target transform and generates terrain tiles around that transform, as
/// it moves more terrain tiles are added and removed depending on the settings.
/// @author Quick Fingers
/// </summary>
public class TerrainGenerator : MonoBehaviour {

    // A container class.
    public class Pack
    {
       
        public GameObject obj1;
        public GameObject obj2;
        public GameObject obj3;
        public GameObject obj4;
    }

    // Target to track;
    public Transform target;

    // The 10x10 vertex default plane in Unity
    public Object terrainPlane;
	
    // Assets to insert
	public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject tree4;
    public GameObject tree5;
    public GameObject tree6;

    public GameObject bush;

    public GameObject rock1;
    public GameObject rock2;
    public GameObject rock3;
    public GameObject rock4;

    public GameObject house;
    public GameObject gazebo;
    public GameObject logHollow;

    public GameObject tiger;
    public GameObject rex;
    public GameObject iguana;
    // Assets summary:
    // - 6 trees.
    // - 1 bush.
    // - 4 rocks.
    // - 3 buildings.
    // - 2 animals.
    // Total of: 16.


    // (buffer * 2 + 1)^2 will be total number of planes in the scene at any one time
    public int buffer;

    // noise detail scalar. Higher values make spikier noise, values lower than 0.1 give more rolling hills
    public float detailScale;

    // as the noise always returns a value from -1 to 1 create a scalar
    public float heightScale;

    // the planes scale (default unity plane is 10 units by 10 units, any more will make localScale of terrainPlane change)
    public float planeSize = 60f;

    // plane count is the amount of planes in a single row (buffer * 2 + 1)
    private int planeCount;

    // your current position
    private int tileX;
    private int tileZ;

    // array of tiles currently on screen
    private Tile[,] terrainTiles;

    // Object to hold the Trees
    private GameObject objectHolder;
    private Pack[] objectsPack;

    // Use this for initialization
    void Start() {

        // Object to hold the Trees
        objectHolder = new GameObject();
        objectHolder.name = "Objects";

        planeCount = buffer * 2 + 1;
        tileX = Mathf.RoundToInt(target.position.x / planeSize);
        tileZ = Mathf.RoundToInt(target.position.z / planeSize);    
        Generate();
    }

    // This method is used to generate the random packs from the assets given.
	void generatePacks(int randPack,float x, float z, float heightHigh) {
		int randItem = UnityEngine.Random.Range (1, 7);
		int randAgain = UnityEngine.Random.Range (1, 4);
		if (randPack == 1) {
			if (randItem == 1) {
				GameObject vtree1 =
					(GameObject)Instantiate (tree1, new Vector3 (x * planeSize + UnityEngine.Random.Range(-20, 20), heightHigh * heightScale, z * planeSize + UnityEngine.Random.Range(-20, 20)), Quaternion.identity);
				vtree1.transform.parent = objectHolder.transform;
			} else if (randItem == 2) {
				GameObject vtree2 =
					(GameObject)Instantiate (tree2, new Vector3 (x * planeSize, heightHigh * heightScale, z * planeSize), Quaternion.identity);
				vtree2.transform.parent = objectHolder.transform;
			} else if (randItem == 3) {
				GameObject vtiger =
					(GameObject)Instantiate (tiger, new Vector3 (x * planeSize, heightHigh * heightScale, z * planeSize), Quaternion.identity);
				vtiger.transform.parent = objectHolder.transform;
			} else if (randItem == 4) {
				GameObject vrock1 =
					(GameObject)Instantiate (rock1, new Vector3 (x * planeSize, heightHigh * heightScale, z * planeSize), Quaternion.identity);
				vrock1.transform.parent = objectHolder.transform;
			} else if (randItem == 5) {
				GameObject vbush =
					(GameObject)Instantiate (bush, new Vector3 (x * planeSize, heightHigh * heightScale, z * planeSize), Quaternion.identity);
				vbush.transform.parent = objectHolder.transform;
			} else {
				GameObject vhouse =
					(GameObject)Instantiate(house, new Vector3(x * planeSize,heightHigh*heightScale , z * planeSize), Quaternion.identity);
				vhouse.transform.parent = objectHolder.transform;
			}
		}
		if (randPack == 2) {
			if (randItem == 1) {
				GameObject vtree3 =
					(GameObject)Instantiate (tree3, new Vector3 (x * planeSize, heightHigh * heightScale, z * planeSize), Quaternion.identity);
				vtree3.transform.parent = objectHolder.transform;
			} else if (randItem == 2) {
				GameObject vtree4 =
					(GameObject)Instantiate (tree4, new Vector3 (x * planeSize, heightHigh * heightScale, z * planeSize), Quaternion.identity);
				vtree4.transform.parent = objectHolder.transform;
			} else if (randItem == 3) {
				GameObject vrex =
					(GameObject)Instantiate (rex, new Vector3 (x * planeSize, heightHigh * heightScale, z * planeSize), Quaternion.identity);
				vrex.transform.parent = objectHolder.transform;
			} else if (randItem == 4) {
				GameObject vrock2 =
					(GameObject)Instantiate (rock2, new Vector3 (x * planeSize, heightHigh * heightScale, z * planeSize), Quaternion.identity);
				vrock2.transform.parent = objectHolder.transform;
			} else if (randItem == 5) {
				GameObject vrock3 =
					(GameObject)Instantiate (rock3, new Vector3 (x * planeSize, heightHigh * heightScale, z * planeSize), Quaternion.identity);
				vrock3.transform.parent = objectHolder.transform;
			} else {
				GameObject vgazebo =
					(GameObject)Instantiate(gazebo, new Vector3(x * planeSize,heightHigh*heightScale , z * planeSize), Quaternion.identity);
				vgazebo.transform.parent = objectHolder.transform;
			}
		}
		if (randPack == 3) {
			if (randItem == 1) {

				GameObject vtree5 =
					(GameObject)Instantiate (tree5, new Vector3 (x * planeSize, heightHigh * heightScale, z * planeSize), Quaternion.identity);
				
				vtree5.transform.parent = objectHolder.transform;
			} else if (randItem == 2) {
				
				GameObject vtree6 =
					(GameObject)Instantiate (tree6, new Vector3 (x * planeSize, heightHigh * heightScale, z * planeSize), Quaternion.identity);
				
				vtree6.transform.parent = objectHolder.transform;
			} else if (randItem == 3) {
				GameObject vtiger =
					(GameObject)Instantiate (tiger, new Vector3 (x * planeSize, heightHigh * heightScale, z * planeSize), Quaternion.identity);
				vtiger.transform.parent = objectHolder.transform;
			} else if (randItem == 4) {
				GameObject vrex =
					(GameObject)Instantiate (rex, new Vector3 (x * planeSize, heightHigh * heightScale, z * planeSize), Quaternion.identity);
				vrex.transform.parent = objectHolder.transform;
			} else if (randItem == 5) {
				GameObject vrock4 =
					(GameObject)Instantiate (rock4, new Vector3 (x * planeSize, heightHigh * heightScale, z * planeSize), Quaternion.identity);
				vrock4.transform.parent = objectHolder.transform;
			} else {
				GameObject vlogHollow =
					(GameObject)Instantiate(logHollow, new Vector3(x * planeSize,heightHigh*heightScale , z * planeSize), Quaternion.identity);
				vlogHollow.transform.parent = objectHolder.transform;
			}
		}

		if (randAgain == 1) {
			Debug.Log ("AGAIN");
			randPack = UnityEngine.Random.Range (1, 4);
			generatePacks (randPack, x, z, heightHigh);
		}
    }
    
    public void Generate(float detailScale, float heightScale) {

        // Destroy previous objects so they don't stack.
        // If you wanna have fun comment this 'foreach'.
        foreach (Transform child in objectHolder.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        this.detailScale = detailScale;
        this.heightScale = heightScale;
        Generate();
    }

    public void Generate() {
        if (terrainTiles != null) {
            foreach (Tile t in terrainTiles) {
                Destroy(t.gameObject);
            }
        }

        terrainTiles = new Tile[planeCount, planeCount];

        for (int x = 0; x < planeCount; x++) {
            for (int z = 0; z < planeCount; z++) {
                terrainTiles[x, z] = GenerateTile(tileX - buffer + x, tileZ - buffer + z);
            }
        }
    }

    // Given a world tile x and tile z this generates a Tile object.
    private Tile GenerateTile(int x, int z) {
		int randEmpty = UnityEngine.Random.Range (0, 2); 
        GameObject plane =
                    (GameObject)Instantiate(terrainPlane, new Vector3(x * planeSize, 0, z * planeSize), Quaternion.identity);
        plane.transform.localScale = new Vector3(planeSize * 0.1f, 1, planeSize * 0.1f);
        plane.transform.parent = transform;


        // Get the planes vertices
        Mesh mesh = plane.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
		float heightHigh = 0;
        // alter vertex Y position depending on simplex noise)
        for (int v = 0; v < vertices.Length; v++) {
            // generate the height for current vertex
            Vector3 vertexPosition = plane.transform.position + vertices[v] * planeSize / 10f;
            float height = SimplexNoise.Noise(vertexPosition.x * detailScale, vertexPosition.z * detailScale);
			if (heightHigh < height) {
				heightHigh = height;
			}
            // scale it with the heightScale field
            vertices[v].y = height * heightScale;
        }
		//Choose if ther will be an asset

		if (randEmpty!=0) {

			int randPack = UnityEngine.Random.Range (1, 4);
			generatePacks (randPack, x, z, heightHigh);
		}


        // Create assets
        /*
        GameObject tree1 =
			(GameObject)Instantiate(tree, new Vector3(x * planeSize,heightHigh*heightScale , z * planeSize), Quaternion.identity);
		GameObject rock1 =
			(GameObject)Instantiate(rock, new Vector3(x * planeSize,100 , z * planeSize), Quaternion.identity);
            */
        // Place trees inside a holder.
        //tree1.transform.parent = objectHolder.transform;
		//rock1.transform.parent = objectHolder.transform;

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        plane.AddComponent<MeshCollider>();

        Tile tile = new Tile();
        tile.gameObject = plane;
        tile.tileX = x;
        tile.tileZ = z;

        return tile;
    }


    // this function could possibly be optimized, but is a proof of concept.
    // by recording the changeX and changeZ (as -1 or 1) we can
    // remove the un needed cells and re generate the grid array with the
    // correct tiles.
    private void Cull(int changeX, int changeZ) {
        int i, j;
        Tile[] newTiles = new Tile[planeCount];
        Tile[,] newTerrainTiles = new Tile[planeCount, planeCount];

        // firstly remove the old tile gameObjects and null them from the array.
        // populate a temporary array with the newly made tiles.
        if (changeX != 0) {
            for (i = 0; i < planeCount; i++) {
                Destroy(terrainTiles[buffer - buffer * changeX, i].gameObject);

                terrainTiles[buffer - buffer * changeX, i] = null;
                newTiles[i] = GenerateTile(tileX + buffer * changeX + changeX, tileZ - buffer + i);
            }
        }
        if (changeZ != 0) {
            for (i = 0; i < planeCount; i++) {
                Destroy(terrainTiles[i, buffer - buffer * changeZ].gameObject);
                terrainTiles[i, buffer - buffer * changeZ] = null;
                newTiles[i] = GenerateTile(tileX - buffer + i, tileZ + buffer * changeZ + changeZ);
            }
        }

        // make a copy of the old terrainTiles to reference when creating the new tile map.
        Array.Copy(terrainTiles, newTerrainTiles, planeCount * planeCount);

        // go through the current tiles on screen (minus the ones we just deleted, and reapply there 
        // new position in the newTerrainTiles array.
        for (i = 0; i < planeCount; i++) {
            for (j = 0; j < planeCount; j++) {
                Tile t = terrainTiles[i, j];
                if (t != null) newTerrainTiles[-tileX - changeX + buffer + t.tileX, -tileZ - changeZ + buffer + t.tileZ] = t;
            }
        }

        // add the newly created tiles to this new array.
        for (i = 0; i < newTiles.Length; i++) {
            Tile t = newTiles[i];
            newTerrainTiles[-tileX - changeX + buffer + t.tileX, -tileZ - changeZ + buffer + t.tileZ] = t;
        }

        // set the current map to the new array.
        terrainTiles = newTerrainTiles;
    }

    // Update is called once per frame
    void Update() {
        int newTileX = Mathf.RoundToInt(target.position.x / planeSize);
        int newTileZ = Mathf.RoundToInt(target.position.z / planeSize);

        if (newTileX != tileX) {
            Cull(newTileX - tileX, 0);
            tileX = newTileX;
        }

        if (newTileZ != tileZ) {
            Cull(0, newTileZ - tileZ);
            tileZ = newTileZ;
        }
    }

    
}

public class Tile {
    public GameObject gameObject;
    public int tileX;
    public int tileZ;
}