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

            byte[] bytes;

            using (var stream = File.OpenRead(path))
            {
                bytes = new byte[stream.Length];
                await stream.ReadAsync(bytes, 0, (int) stream.Length);
            }

            var parser = new GltfParser();
            parser.Parse(path, bytes);

            using (var context = new ShaderGraphVRMImporterContext(parser))
            {
                var meta = await context.ReadMetaAsync();
                Debug.LogFormat(meta.Title);

                await context.LoadAsync();

                context.ShowMeshes();
                context.DisposeOnGameObjectDestroyed();
            }
            
            Debug.Log($"load completed");
        }
    }
}