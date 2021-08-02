# Shader Graphs MToon for URP VR

![main](README/ShaderGraphsMToon.jpg)  

## Requirements
- Unity 2020.3
    - Universal RP 10

## Getting Started

Open `Scenes/SampleScene`, and enter local VRM file path into `Sample` Component.
Then click button to load runtime.

![graph](README/shadergraph.jpg)  

## Installation
```json
{
  "dependencies" : {
    ...
    "simplestargame.shadergraphs-mtoon-for-urp-vr" : "git+https://github.com/gatari/ShaderGraphsMToonForURPVR.git?path=Assets/SimplestarGame/ShaderGraphsMToon#gatari/main",
    ...
  }
}
```

## How to use

- use `ShaderGraphsVRMImporterContext` instead of `VRMImporterContext`.

```cs
  
using System.IO;
using Cysharp.Threading.Tasks;
using SimplestarGame;
using UniGLTF;
using UnityEngine;

namespace Sample
{
    public class Sample : MonoBehaviour
    {
        [SerializeField] private string path;

        public void Load()
        {
            LoadInternal().Forget();
        }

        private async UniTask LoadInternal()
        {
            Debug.Log($"load from path : {path}");
            var data = new GlbFileParser(path).Parse();

            using var context = new ShaderGraphVRMImporterContext(data);
            var meta = await context.ReadMetaAsync();
            Debug.LogFormat(meta.Title);

            var loaded = await context.LoadAsync();
            loaded.ShowMeshes();

            Debug.Log($"load completed");
        }
    }
}
 ```
Load Result in SimpleViewer scene of [UniVRM Sample package](https://github.com/vrm-c/UniVRM).

You should learn about [MToon](https://www.slideshare.net/VirtualCast/vrm-mtoon) (Japanese).
