/*
using UnityEngine;
using System.Collections;

public class OldFirefly: MonoBehaviour{

  public float maxSpeed;
  public float maxRadius;
  public float minRadius;
  public Color color;
  public float size;

  private float theta;
  private float radius;
  private Light l;

  public void Start()
  {
    l = GetComponent<Light>();
  }

  public void Update()
  {
    correctPosition();
    setStates();
  }

  private bool moving;
  public bool Moving { get { return moving; } }

  void correctPosition()
  {
    if (radius > maxRadius)
    {
      radius = maxRadius;
      moving = false;
    }
    else if (radius < minRadius)
    {
      radius = minRadius;
      moving = false;
    }
    else
    {
      moving = true;
    }

    theta = theta % (Mathf.PI * 2);
  }

  void setStates()
  {
    l.color = color;
    l.range = size;

    Vector3 pos = new Vector3();
    pos.z = size / -10;
    pos.x = Mathf.Cos(theta) * radius;
    pos.y = Mathf.Sin(theta) * radius;

    transform.position = pos;
  }

  public void moveBy(float dt, float dr)
  {
    float distanceAsked = Mathf.Abs(dr) + Mathf.Abs(dt * radius);
    if (distanceAsked >= 1)
    {
      radius += (dr / distanceAsked) * maxSpeed;
      theta += (dt / distanceAsked) * (maxSpeed);
    }
    else
    {
      radius += dr * maxSpeed;
      theta += dt * maxSpeed;
    }
  }
}
*/