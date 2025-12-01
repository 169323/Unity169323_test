using UnityEngine;
using UnityEngine.ProBuilder;

public class ProBuilderTable : MonoBehaviour
{
    void Start()
    {
        CreateTable();
    }

    void CreateTable()
    {
        // BLAT
        float topWidth = 2.5f;          // szerokosc blatu
        float topDepth = 1.2f;          // glebokosc blatu
        float topThickness = 0.15f;     // grubosc blatu
        float topHeight = 1.0f;         // wysokosc na ktorej stoi blat

        // NOGI
        float legWidth = 0.2f;          // grubosc nogi
        float legHeight = 1.0f;         // wysokosc nogi

        // POLKA POD BLATEM
        float shelfHeight = 0.4f;
        float shelfThickness = 0.05f;

        // Pozycja blatu w scenie
        Vector3 tablePosition = new(1, 0, 0);

        // Tworzenie rodzica dla stolu
        GameObject table = new GameObject("Table");

        // Brazowy material dla stolu (URP)
        Material woodMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"))
        {
            color = new Color(0.5f, 0.3f, 0.1f),
            name = "Wood Material"
        };
        woodMaterial.SetFloat("_Smoothness", 0.4f);
        woodMaterial.SetFloat("_Metallic", 0.0f);

        // 1. BLAT
        ProBuilderMesh top = ShapeGenerator.GenerateCube(PivotLocation.Center,
            new Vector3(topWidth, topThickness, topDepth));
        top.name = "Top";
        top.transform.SetParent(table.transform);
        top.transform.localPosition = new Vector3(tablePosition.x, topHeight, tablePosition.z);
        ApplyMaterialToMesh(top, woodMaterial);

        // 2. NOGI (4 sztuki)
        // PRZOD LEWY | PRZOD PRAWA | TYLNA LEWA | TYLNA PRAWA
        ProBuilderMesh leg1 = CreateLeg(table, tablePosition.x - topWidth / 2 + legWidth / 2, legHeight / 2, tablePosition.z - topDepth / 2 + legWidth / 2, legWidth, legHeight);
        ProBuilderMesh leg2 = CreateLeg(table, tablePosition.x + topWidth / 2 - legWidth / 2, legHeight / 2, tablePosition.z - topDepth / 2 + legWidth / 2, legWidth, legHeight);
        ProBuilderMesh leg3 = CreateLeg(table, tablePosition.x - topWidth / 2 + legWidth / 2, legHeight / 2, tablePosition.z + topDepth / 2 - legWidth / 2, legWidth, legHeight);
        ProBuilderMesh leg4 = CreateLeg(table, tablePosition.x + topWidth / 2 - legWidth / 2, legHeight / 2, tablePosition.z + topDepth / 2 - legWidth / 2, legWidth, legHeight);

        // Nadanie materialu nogom
        ApplyMaterialToMesh(leg1, woodMaterial);
        ApplyMaterialToMesh(leg2, woodMaterial);
        ApplyMaterialToMesh(leg3, woodMaterial);
        ApplyMaterialToMesh(leg4, woodMaterial);

        // Odswiezenie siatek
        top.ToMesh(); top.Refresh();
        leg1.ToMesh(); leg1.Refresh();
        leg2.ToMesh(); leg2.Refresh();
        leg3.ToMesh(); leg3.Refresh();
        leg4.ToMesh(); leg4.Refresh();

        

        // 3. POLKA POD BLATEM
        ProBuilderMesh shelf = ShapeGenerator.GenerateCube(PivotLocation.Center,
            new Vector3(topWidth * 0.9f, shelfThickness, topDepth * 0.9f));
        shelf.name = "Shelf";
        shelf.transform.SetParent(table.transform);
        shelf.transform.localPosition = new Vector3(tablePosition.x, shelfHeight, tablePosition.z);
        ApplyMaterialToMesh(shelf, woodMaterial);
        shelf.ToMesh();
        shelf.Refresh();

        Debug.Log("Stol URP utworzony pomyslnie (blat i nogi maja material)!");
    }

    ProBuilderMesh CreateLeg(GameObject parent, float x, float y, float z, float width, float height)
    {
        ProBuilderMesh leg = ShapeGenerator.GenerateCube(PivotLocation.Center,
            new Vector3(width, height, width));
        leg.name = "Leg";
        leg.transform.SetParent(parent.transform);
        leg.transform.localPosition = new Vector3(x, y, z);
        return leg;
    }

    void ApplyMaterialToMesh(ProBuilderMesh mesh, Material material)
    {
        MeshRenderer renderer = mesh.GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            renderer.sharedMaterial = material;
        }
    }
}