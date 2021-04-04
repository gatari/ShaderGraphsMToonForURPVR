using System.Collections.Generic;
using UniGLTF;
using VRM;
using Object = UnityEngine.Object;

namespace SimplestarGame
{
    public class ShaderGraphVRMImporterContext : VRMImporterContext
    {
        public ShaderGraphVRMImporterContext(GltfParser parser,
            IEnumerable<(string, Object)> externalObjectMap = null)
            : base(parser, externalObjectMap)
        {
            // intercept MToonMaterialImporter by Inserting importer
            if (glTF_VRM_extensions.TryDeserialize(GLTF.extensions, out glTF_VRM_extensions vrm))
            {
                GltfMaterialImporter.GltfMaterialParamProcessors.Insert(0,
                    new ShaderGraphsMToonMaterialImporter(VRM.materialProperties).TryCreateParam);
            }
        }
    }
}