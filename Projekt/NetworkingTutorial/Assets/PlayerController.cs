using UnityEngine;
using UnityEngine.Networking;
namespace S3
{

    public class PlayerController : NetworkBehaviour {

        public GameObject bulletPrefab;
        public Transform bulletSpawn;

        void Update()
        {

            if (!isLocalPlayer)
                return;

            float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            //Final movement vector
            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);

            if (Input.GetKeyDown(KeyCode.Space))
                CmdFire();
        }

        public override void OnStartLocalPlayer()
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }

        [Command]
        void CmdFire()
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6.0f;

            NetworkServer.Spawn(bullet);

            Destroy(bullet, 2);
        }
    }

}
