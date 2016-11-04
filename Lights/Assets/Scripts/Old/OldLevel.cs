/*
using UnityEngine;
using System.Collections.Generic;

public class OldLevel : MonoBehaviour {

  private static Level staticInstance = null;
  public Collectable colPrefab;
  public List<Collectable> collectablesList;

  public static Level instance
  {
    get
    {
      if (staticInstance == null)
      {
        staticInstance = FindObjectOfType(typeof(Level)) as Level;
      }

      if (staticInstance == null)
      {
        GameObject obj = new GameObject("Level");
        staticInstance = obj.AddComponent<Level>();
      }

      return staticInstance;
    }
  }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnApplicationQuit () {
    staticInstance = null;
	}
}
*/