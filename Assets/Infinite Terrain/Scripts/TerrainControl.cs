using UnityEngine;
using System.Collections;

public class TerrainControl : MonoBehaviour {

    // the terrain generator component.
    public TerrainGenerator generator;
    public FlyCamera flyCamera;
    // Value ranges.
    public float maxDetail;
    public float minDetail;
    public float minHeight;
    public float maxHeight;

    private float detailScale;
    private float heightScale;
    
    void Start() {
        detailScale = generator.detailScale;
        heightScale = generator.heightScale;
    }

}
