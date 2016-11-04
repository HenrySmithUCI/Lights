using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

  public float maxSpeed;
  public float maxR;
  public float minR;

  private bool collected;

  private float theta;
  private float radius;
  private float dt;
  private float dr;

  private WorldPlayAudio wpa;
  private Firefly ff;
  
  void Start () {
    init();
	}
	
  public void init() {
    wpa = transform.parent.GetComponent<WorldPlayAudio>();
    collected = false;
    ff = GetComponent<Firefly>();
    ff.color = Color.green;
    theta = Random.Range(0, Mathf.PI * 2);
    radius = Random.Range(minR, maxR);
    dt = getRandomBand(1, maxSpeed);
    dr = getRandomBand(1, maxSpeed);
  }

  float getRandomBand(float inEdge, float outEdge, float center = 0) {
    bool positive = Random.Range(0, 2) == 0;
    if (positive) {
      return Random.Range(inEdge, outEdge) + center;
    }
    else {
      return Random.Range(-outEdge, -inEdge) + center;
    }
  }

  private bool soundTimer;

	void Update () {
    if (collected == false) {
      if (dt == 0) {
        dt = getRandomBand(1, maxSpeed);
      }

      if (dr == 0) {
        dr = getRandomBand(1, maxSpeed);
      }
    }

    theta += dt * Time.deltaTime;
    theta = theta % (Mathf.PI * 2);

    radius += dr * Time.deltaTime;

    if (radius > maxR) {
      radius = maxR;
      dr *= -1;
    }

    else if (radius < minR) {
      radius = minR;
      dr *= -1;
    }

    if (Mathf.Abs(dt) > 0)
      dt *= 0.99f;

    if (Mathf.Abs(dr) > 0)
      dr *= 0.99f;

    if (Mathf.Abs(dt) < 0.3)
      dt = 0;

    if (Mathf.Abs(dr) < 0.3)
      dr = 0;

    Vector3 pos = transform.position;

    pos.x = Mathf.Cos(theta) * radius;
    pos.y = Mathf.Sin(theta) * radius;
    pos.z = -0.3f;

    transform.localPosition = pos;

    ff.size = ((Mathf.Abs(dt) + Mathf.Abs(dr)) / 2) + (radius / 5);

    if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) < 0.5f) {
      if (collected == false) {
        becomeCollected();
      }
      if (soundTimer) {
        wpa.play();
        dt = getRandomBand(3, maxSpeed);
        dr = getRandomBand(3, maxSpeed);
        soundTimer = false;
      }
    }
    else {
      if (soundTimer == false) {
        soundTimer = true;
      }
    }
  }

  void becomeCollected() {
    transform.parent.GetComponentInChildren<Heart>().Score++;
    collected = true;
    ff.color = Color.yellow;
    GameObject go = new GameObject();
    go.AddComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
    go.AddComponent<Firefly>();
    Collectable goC = go.AddComponent<Collectable>();
    goC.maxSpeed = maxSpeed;
    goC.maxR = maxR;
    goC.minR = minR;
    go.transform.parent = transform.parent;
    goC.init();
    go.name = "Collectable";
  }
}
