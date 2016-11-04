using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

  public float maxSpeed;
  public float thetaJ; //Jerk
  public float radiusJ;
  public float maxR;
  public float minR;

  private float theta;
  private float radius;
  private float dt;
  private float dr;

  private Firefly ff;

	void Start () {
    //transform.parent.GetComponent<WorldPlayAudio>().play();
    ff = GetComponent<Firefly>();
    theta = 0;
    radius = 0;
    dt = 0;
    dr = 0;
	}

	void Update () {
    handleInput();
    correctInput();
    setFirefly();
    setPosition();
  }

  private float thetaA; // acceleration
  private float radiusA;

  void handleInput()
  {
    thetaA = 0;
    radiusA = 0;

    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
      radiusA += radiusJ;

    if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
      radiusA -= radiusJ;

    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
      thetaA += thetaJ;

    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
      thetaA -= thetaJ;

    if (thetaA == 0)
      dt *= 0.98f;

    if (radiusA == 0)
      dr *= 0.90f;

  }

  void correctInput()
  {
    if (Mathf.Abs((dt + thetaA) * radius) < maxSpeed)
      dt += thetaA;
    else
      dt = maxSpeed / radius * (dt > 0 ? 1 : -1);

    if (Mathf.Abs(dr + radiusA) < maxSpeed)
      dr += radiusA;
    else
      dr = maxSpeed * (dr > 0 ? 1 : -1);

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

    if (Mathf.Abs(dt * radius) < 0.01)
      dt = 0;

    if (Mathf.Abs(dr) < 0.01)
      dr = 0;
  }

  private Color color1 = Color.blue;
  private Color color2 = Color.red;
  private float t = 0;

  void setFirefly()
  {
    t += Time.deltaTime;
    if (t >= 1) {
      t = 0;
      Color colorT = color1;
      color1 = color2;
      color2 = colorT;
    }

    ff.color = Color.Lerp(color1,color2,t);
    ff.size = radius;
  }

  void setPosition()
  {
    Vector3 pos = transform.position;
    
    pos.x = Mathf.Cos(theta) * radius;
    pos.y = Mathf.Sin(theta) * radius;
    pos.z = -0.3f;

    transform.localPosition = pos;
  }
}
