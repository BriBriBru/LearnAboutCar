using UnityEngine;

public class RayGun : MonoBehaviour
{
    private LineRenderer _beam;
    private Camera _cam;
    private Vector3 _origine;
    private Vector3 _endPoint;
    private Vector3 _mousePos;

    void Start()
    {
        // Grabbed our laser
        _beam = this.gameObject.AddComponent<LineRenderer>();
        _beam.startWidth = 0.075f;
        _beam.endWidth = 0.075f;

        // Grab the main camera
        _cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CheckLaser();
        }

        else
        {
            _beam.enabled = false;
        }
    }

    void CheckLaser()
    {
        // Finding the origine and end point of laser
        _origine = this.transform.position + this.transform.forward * 0.5f * this.transform.lossyScale.z;

        // Finding mouse pos in 3D space
        _mousePos = Input.mousePosition;
        _mousePos.z = 300f;
        _endPoint = _cam.ScreenToWorldPoint(_mousePos);

        // Find direction of beam
        Vector3 dir = _endPoint - _origine;
        dir.Normalize();

        // Are we hitting colliders ?
        RaycastHit hit;

        if (Physics.Raycast(_origine, dir, out hit, 300f))
        {
            // If yes, then set endpoint to hit-point
            _endPoint = hit.point;
        }

        // Set end point of laser
        _beam.SetPosition(0, _origine);
        _beam.SetPosition(1, _endPoint);

        // Draw the laser !
        _beam.enabled = true;
        _beam.material = new Material(Shader.Find("Sprites/Default"));
        _beam.startColor = Color.green;
        _beam.endColor = Color.green;
    }
}
