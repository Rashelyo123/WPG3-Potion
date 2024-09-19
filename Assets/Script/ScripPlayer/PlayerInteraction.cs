using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private IngredientSO heldIngredient;
    [SerializeField] private GameInput gameInput;

    [SerializeField] private float capsuleRadius = 0.5f; // Jari-jari capsule
    [SerializeField] private float capsuleHeight = 2f; // Tinggi capsule

    private void Start()
    {
        gameInput.OnInteract += GameInput_OnInteract; // Subscribe ke event OnInteract
    }

    private void GameInput_OnInteract(object sender, System.EventArgs e)
    {
        Interact(); // Panggil fungsi Interact ketika tombol interaksi ditekan
    }

    private void Interact()
    {
        Vector3 capsuleBottom = transform.position - Vector3.up * (capsuleHeight / 2f);
        Vector3 capsuleTop = transform.position + Vector3.up * (capsuleHeight / 2f);
        Vector3 direction = transform.forward;
        float maxDistance = 5f;

        Debug.DrawLine(capsuleBottom, capsuleTop, Color.red, 2f); // Untuk visualisasi di scene
        Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.blue, 2f); // Visualisasi raycast untuk referensi

        if (Physics.CapsuleCast(capsuleBottom, capsuleTop, capsuleRadius, direction, out RaycastHit hit, maxDistance))
        {
            Debug.Log("CapsuleCast hit: " + hit.transform.name); // Cek objek yang kena capsulecast

            if (hit.transform.TryGetComponent(out IngredientContainer ingredientContainer))
            {
                // Mengambil bahan dari container
                heldIngredient = ingredientContainer.TakeIngredient();
                Debug.Log("Mengambil bahan: " + heldIngredient.ingredientName);
            }
            else if (hit.transform.TryGetComponent(out MortarAndPestle mortarAndPestle) && heldIngredient != null)
            {
                // Proses bahan di mortar
                heldIngredient = mortarAndPestle.ProcessIngredient(heldIngredient);
                Debug.Log("Mengolah bahan menjadi: " + heldIngredient.ingredientName);
            }
            else if (hit.transform.TryGetComponent(out Cauldron cauldron) && heldIngredient != null)
            {
                // Tambahkan bahan ke dalam cauldron
                cauldron.AddIngredient(heldIngredient);
                heldIngredient = null; // Kosongkan bahan yang dipegang
                Debug.Log("Menambahkan bahan ke dalam cauldron.");
            }
            else
            {
                Debug.Log("Tidak ada interaksi yang cocok ditemukan.");
            }
        }
        else
        {
            Debug.Log("CapsuleCast tidak mengenai apapun.");
        }
    }
}
