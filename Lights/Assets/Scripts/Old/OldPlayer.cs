/*
using UnityEngine;
using System.Collections;

public class OldPlayer : MonoBehaviour {

  public AnimationCurve thetaAcceleration;
  public int maxTAFCount; //TAF = Theta acceleration frames

  public AnimationCurve radiusAcceleration;
  public int maxRAFCount; //TAF = Theta acceleration frames

  private int TAF = 0;
  private int RAF = 0;


  private Firefly ff;
  
	void Start () {
    ff = GetComponent<Firefly>();
	}
  
	void Update () {
    handleInput();

    correctFrameCount();

    applyMovement();
	}

  void handleInput()
  {
    int dRAF = 0;
    int dTAF = 0;
    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
    {
      dRAF++; //RAF is positive when going inward
    }

    if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
    {
      dRAF--; //RAF is negative when going outward
    }

    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
    {
      dTAF++; //TAF is positive when going counterclockwise
    }

    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
    {
      dTAF--; //TAF is negative when going clockwise
    }

    if (dRAF == 0)
    {
      if (RAF > 0)
      {
        RAF--;
      }

      if (RAF < 0)
      {
        RAF++;
      }
    }
    else
    {
      RAF += dRAF;
    }

    if (dTAF == 0)
    {
      if (TAF > 0)
      {
        TAF--;
      }

      if(TAF < 0)
      {
        TAF++;
      }
    }
    else
    {
      TAF += dTAF;
    }
  }

  void correctFrameCount()
  {
    if (TAF > maxTAFCount)
    {
      TAF = maxTAFCount;
    }

    if (TAF < -1 * maxTAFCount)
    {
      TAF = -1 * maxTAFCount;
    }

    if (RAF > maxRAFCount)
    {
      RAF = maxRAFCount;
    }

    if (RAF < -1 * maxRAFCount)
    {
      RAF = -1 * maxRAFCount;
    }
  }

  void applyMovement()
  {
    Color c = Color.black;
    float  dTheta = thetaAcceleration.Evaluate(Mathf.Abs((float)TAF) / (float)maxTAFCount) * (TAF > 0 ? 1 : -1);
    c.b = Mathf.Abs(dTheta);
    
    float dRadius = radiusAcceleration.Evaluate(Mathf.Abs((float)RAF) / (float)maxRAFCount) * (RAF > 0 ? 1 : -1);
    c.r = Mathf.Abs(dRadius);

    if (ff.Moving == false)
    {
      ff.moveBy(dTheta, 0);
      RAF = 0;
    }
    else
    {
      ff.moveBy(dTheta, dRadius);
    }
    

    ff.color = c;
  }
}
*/