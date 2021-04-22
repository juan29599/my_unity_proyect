using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class movimientocarro : MonoBehaviour
{
    public WheelCollider Llanta1;
    public WheelCollider Llanta2;
    public WheelCollider Llanta3;
    public WheelCollider Llanta4;
    public int desAceleracion = 80;

    public float Velocidad;
    public int VelocidadMaxima = 200;
    public int Aceleracion = 100;

    // Start is called before the first frame update
    void Start()
    {
        //centro de masa del carro (no funciona)
        //transform.Rigidbody.centerOfMass = new Vector3(0, -1f, 0);
    }

    void Update() {
        Velocidad = (2 * Mathf.PI * Llanta1.radius) * Llanta1.rpm * 60 / 1000;
        Velocidad = Mathf.Round(Velocidad);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //aceleracion
        if (Mathf.Abs(Velocidad) < VelocidadMaxima)
        {
            Llanta1.motorTorque = Aceleracion * Input.GetAxis("Vertical");
            Llanta2.motorTorque = Aceleracion * Input.GetAxis("Vertical");
        }
        else {
            Llanta1.motorTorque = 0;
            Llanta2.motorTorque = 0;
        }

        //desAcelerar al dejar de pulsar la tecla
        if (Input.GetAxis("Vertical") == 0)
        {
            Llanta1.brakeTorque = desAceleracion;
            Llanta2.brakeTorque = desAceleracion;
        }
        else {
            Llanta1.brakeTorque = 0;
            Llanta2.brakeTorque = 0;
        }

        //rotacion del carro
        Llanta3.steerAngle = -10 * Input.GetAxis("Horizontal");
        Llanta4.steerAngle = -10 * Input.GetAxis("Horizontal");
    }
    
}
