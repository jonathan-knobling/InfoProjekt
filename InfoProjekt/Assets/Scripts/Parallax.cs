using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    [Header("Variables")]
    [SerializeField] private Camera cam;
    [SerializeField] private Transform player;
    private Vector2 startPosition;
    private float startZ;

    private Vector2 travel => (Vector2)cam.transform.position - startPosition; // die distanz die sich die cam von der startposition bewegt hat
    private float distanceFromPlayer => transform.position.z - player.position.z; // die distanz in z richtung des objekts vom spieler

    private float clippingPlane => (cam.transform.position.z + (distanceFromPlayer < 0 ? cam.farClipPlane : cam.nearClipPlane)); // wenn hinter dem spieler farClippingPlane(50) + camZ(-25) = 25 sonst nearClippingPlane(0) + CamZ(-25) = -25 also die koordinaten der clipping planes | clipping planes sind die grenzen was man noch in der cam sehen kann also alles von 0 (direkt an der cam) bis 50 weit weg von der cam
    private float parallaxFactor => Mathf.Abs(distanceFromPlayer) / clippingPlane; // parallax factor des objekts von -1 bis 1 (wie schnell sich das objekt bewegt)

    public void Start()
    {
        startPosition = transform.position; // beim start des programms die start position festlegen
        startZ = transform.position.z;
    }

    public void Update()
    {
        Vector2 newPos = startPosition + travel * parallaxFactor; // neue position des objekts
        transform.position = new Vector3(newPos.x, transform.position.y, startZ);
    }

}
