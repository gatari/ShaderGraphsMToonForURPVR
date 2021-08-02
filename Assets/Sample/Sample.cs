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