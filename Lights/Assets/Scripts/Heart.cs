using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour {

  public int maxScore;
  public float maxSize;
  public AnimationCurve sizeChange;

  private Firefly ff;
  private int score;

  void Start() {
    score = 0;
    ff = GetComponent<Firefly>();
    updateSize();
  }

  void updateSize() {
    if (score < maxScore) {
      ff.size = sizeChange.Evaluate((float)score / (float)maxScore) * maxSize;
      ff.color = Color.HSVToRGB(1f / 12f, 1, (float)score / (float)maxScore);
    }
    else {
      ff.size = sizeChange.Evaluate(1) * maxSize;
      ff.color = Color.HSVToRGB(1f / 12f, 1,1);
    }
  }

  public int Score { get { return score; } set { score = value; updateSize(); } }
}
