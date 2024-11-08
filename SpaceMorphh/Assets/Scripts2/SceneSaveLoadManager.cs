using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class ObjectSaveData
{
    public string prefabName;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
}

public class SceneSaveLoadManager : MonoBehaviour
{
    private List<GameObject> loadedObjects = new List<GameObject>();
    private string saveFilePath;

    private void Awake()
    {
        // Inicializar saveFilePath en Awake para evitar el error
        saveFilePath = Path.Combine(Application.persistentDataPath, "sceneSaveData.json");
    }

    public void SaveScene()
    {
        List<ObjectSaveData> objectDataList = new List<ObjectSaveData>();

        foreach (Transform child in transform)
        {
            GameObject obj = child.gameObject;
            string prefabName = obj.name;

            // Solo guarda objetos específicos que se encuentran en Resources/PrefabsDef
            if (prefabName == "bathroomSink" || prefabName == "bathtub" || prefabName == "chairdesk" ||
                prefabName == "kitchenSink" || prefabName == "tablecross" || prefabName == "television" ||
                prefabName == "washer" || prefabName == "toilet" || prefabName == "laptop" ||
                prefabName == "LoungeSofa" || prefabName == "moneda" || prefabName == "Cama")
            {
                ObjectSaveData data = new ObjectSaveData
                {
                    prefabName = prefabName,
                    position = obj.transform.position,
                    rotation = obj.transform.rotation,
                    scale = obj.transform.localScale
                };
                objectDataList.Add(data);
            }
        }

        string json = JsonUtility.ToJson(new { objects = objectDataList }, true);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Escena guardada en: " + saveFilePath);
    }

    public void LoadScene()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            var objectDataList = JsonUtility.FromJson<SceneData>(json).objects;

            // Elimina los objetos cargados previamente para evitar duplicados
            foreach (GameObject obj in loadedObjects)
            {
                Destroy(obj);
            }
            loadedObjects.Clear();

            foreach (ObjectSaveData data in objectDataList)
            {
                GameObject prefab = Resources.Load<GameObject>("PrefabsDef/" + data.prefabName);
                if (prefab != null)
                {
                    GameObject obj = Instantiate(prefab, data.position, data.rotation);
                    obj.transform.localScale = data.scale;
                    loadedObjects.Add(obj);
                }
                else
                {
                    Debug.LogWarning("Prefab no encontrado en Resources/PrefabsDef: " + data.prefabName);
                }
            }

            Debug.Log("Escena cargada desde: " + saveFilePath);
        }
        else
        {
            Debug.LogWarning("No se encontró archivo de guardado en: " + saveFilePath);
        }
    }

    [System.Serializable]
    private class SceneData
    {
        public List<ObjectSaveData> objects;
    }
}
