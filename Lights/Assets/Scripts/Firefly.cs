using UnityEngine;
using System.Collections;

[System.Serializable]
public class Firefly : MonoBehaviour {

  [SerializeField]
  private Color c;

  [SerializeField]
  private float s;

  private SpriteRenderer l;

  public void Start()
  {
    
    resetLight();
  }

  public void resetLight()
  {
    if (l == null) {
      l = GetComponent<SpriteRenderer>();
    }

    l.color = c;
    transform.localScale = new Vector3(s * 0.25f, s * 0.25f, 1);
  }

  public float size { get { return s; } set { s = value; resetLight(); } }
  public Color color { get { return c; } set { c = value;  resetLight(); } }
}
