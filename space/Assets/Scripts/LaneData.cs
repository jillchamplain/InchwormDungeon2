using UnityEngine;

public class LaneData : MonoBehaviour
{
	public LaneData instance;
    public LaneData getInst() {  return instance; }
    public int numLanes;
    public float laneWidth;
    public float maxSegLength; 

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
}

