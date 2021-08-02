using System.Collections.Generic;
using UniGLTF;
using VRM;
using VRMShaders;
using Object = UnityEngine.Object;

namespace SimplestarGame
{
    public class ShaderGraphVRMImporterContext : VRMImporterContext
    {
        public ShaderGraphVRMImporterContext(GltfData data,
            IReadOnlyDictionary<SubAssetKey, Object> externalObjectMap = null)
            : base(data, externalObjectMap)
        {
            // override material descriptor
            if (glTF_VRM_extensions.TryDeserialize(GLTF.extensions, out var vrm))
            {
                MaterialDescriptorGenerator = new ShaderGraphsVRMMaterialDescriptorGenerator(vrm);
            }
        }
    }
}