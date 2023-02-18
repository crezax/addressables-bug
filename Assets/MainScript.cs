using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class MainScript : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return Addressables.LoadAssetsAsync<GameObject>("Foo", (asset) => { });

        var container = Addressables.LoadAssetAsync<GameObject>("Container.prefab");
        var inFolderWithAddress = Addressables.LoadAssetAsync<GameObject>("AddressableFolder/AddressableInFolder.prefab");
        var outsideFolderWithAddress = Addressables.LoadAssetAsync<GameObject>("AddressableOutside.prefab");

        var inFolderWithKey = Addressables.LoadAssetAsync<GameObject>(container.Result.GetComponent<ContainerScript>().addressableIn.RuntimeKey);
        var outsideFolderWithKey = Addressables.LoadAssetAsync<GameObject>(container.Result.GetComponent<ContainerScript>().addressableOut.RuntimeKey);

        Debug.Log(container.Status);
        Debug.Log(inFolderWithAddress.Status);
        Debug.Log(outsideFolderWithAddress.Status);

        Debug.Log(inFolderWithKey.Status);
        Debug.Log(outsideFolderWithKey.Status);
    }
}