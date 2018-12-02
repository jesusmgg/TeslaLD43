using Tesla.GameScript;
using UnityEngine;

namespace Tesla.Animation
{
    public class FishSchoolAnimationController : BaseAnimationController
    {
        Animator animator;
        new SpriteRenderer renderer;
        
        FishSchoolGameScript gameScript;

        public Material outlineMaterial;
        Material originalMaterial;

        void Start()
        {
            animator = GetComponent<Animator>();
            renderer = GetComponent<SpriteRenderer>();

            gameScript = GetComponent<FishSchoolGameScript>();

            originalMaterial = renderer.material;
        }

        void Update()
        {
            renderer.material = gameScript.isHighlighted ? outlineMaterial : originalMaterial;
        }
    }
}