using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
  // Use this for initialization
  public Rigidbody rb;
  public float vel;
  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }
  // Update is called once per frame
  void Update () {
    if(Input.GetMouseButton(0))
    {
      transform.Translate(Vector3.forward*vel);      
    }
    if (transform.position.y > 2) transform.position+=new Vector3(0, -0.3f, 0);
  }
}
