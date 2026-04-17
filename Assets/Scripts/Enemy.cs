    using System.Collections;
    using UnityEngine;

    public class Enemy : MonoBehaviour
    {
        public int health = 100;
        private Rigidbody rb;

        public Material hitMat;
        private Renderer rend;
        private Material originalMaterial;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rend = GetComponent<Renderer>();
            originalMaterial = rend.material;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!this.enabled) return;

            if (collision.gameObject.tag == "Damage")
            {
                health -= 10;
                if (health <= 0)
                {
                    Die();
                }
                else
                {
                    StartCoroutine(Blink());
                }
            }
        Debug.Log("Hit by: " + collision.gameObject.name);
    }

        void Die()
        {
            rb.freezeRotation = false;
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 5);
            this.enabled = false;
        }

        IEnumerator Blink()
        {
            rend.material = hitMat;
            yield return new WaitForSeconds(0.1f);
            rend.material = originalMaterial;
        }

  

}