using Core.Interface;

namespace Core.Abstract
{
    public abstract class AObjectController : IObjectController
    {
        public virtual void Create() { }
        public virtual void Initialize() { }
        public virtual void Start() { }
    }
}
