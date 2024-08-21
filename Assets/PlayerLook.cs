using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] float mouseSense = 100f;
    [SerializeField] Transform player, playerArms;

    float xAxisClamp = 0;
    public Vector3 cameraOffset;  // Desplazamiento de la cámara respecto al personaje

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        float rotateX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float rotateY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        xAxisClamp -= rotateY;

        Vector3 rotPlayerArms = playerArms.rotation.eulerAngles;
        Vector3 rotPlayer = player.rotation.eulerAngles;

        rotPlayerArms.x = Mathf.Clamp(rotPlayerArms.x - rotateY, -90f, 90f);
        rotPlayerArms.z = 0;
        rotPlayer.y += rotateX;

        playerArms.rotation = Quaternion.Euler(rotPlayerArms);
        player.rotation = Quaternion.Euler(rotPlayer);

        // Hacer que la cámara siga al personaje
        transform.position = player.position + cameraOffset;
    }

    private void OnValidate()
    {
        // Actualizar el offset de la cámara en la escena cuando se hacen cambios en el Inspector
        if (player != null)
        {
            cameraOffset = transform.position - player.position;
        }
    }
}
